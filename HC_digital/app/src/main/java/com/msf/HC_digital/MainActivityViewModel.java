package com.msf.HC_digital;

import android.app.Application;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.util.Log;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;

import com.google.gson.Gson;

import modelo.LoginRequest;
import modelo.Profesional;
import request.ApiClient;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivityViewModel extends AndroidViewModel {

    private Context context;
    public MainActivityViewModel(@NonNull Application application) {
        super(application);
        this.context = application.getApplicationContext();
    }

    public void login(String Dni, String Password) {
        LoginRequest miLogin = new LoginRequest(Dni, Password);
       ApiClient.EndPointHcDigital end = ApiClient.getEndPointHcDigital();
       Log.d("paso 2 miLogin", miLogin.toString());
       Call<String> call = end.login(miLogin);
       Log.d("paso 3 call resultado", call.toString());
        call.enqueue(new Callback<String>() {
            @Override
            public void onResponse(Call<String> call, Response<String> response) {
                if (response.isSuccessful()) {
                    Log.d("Respuesta", response.body());
                    Toast.makeText(context, "Login exitoso", Toast.LENGTH_LONG).show();
                    SharedPreferences sp = context.getSharedPreferences( "token.xml", 0 );
                    SharedPreferences.Editor editor = sp.edit();
                    editor.putString("token", "Bearer: " +  response.body());
                    editor.commit();
                    //---- obtener el profesional ya que el login fue exitoso -----------

                    Call<Profesional> callP = end.getProfesional(response.body(), "123");
                    Log.d("paso 3 call resultado", call.toString());
                    callP.enqueue(new Callback<Profesional>() {
                        @Override
                        public void onResponse(Call<Profesional> callP, Response<Profesional> response) {
                            if (response.isSuccessful()) {
                                Log.d("Respuesta", String.valueOf(response.body()));
                                Log.d("Respuesta", String.valueOf(response.body().getDni()));
                                Log.d("Respuesta", response.body().getNombre());
                                Log.d("Respuesta", String.valueOf(response.code()));
                                Gson gson = new Gson();
                                String profesionalJson = gson.toJson(response.body());
                                Log.d("Respuesta", profesionalJson);


                            } else {
                                try {

                                    String errorMessage = response.errorBody().string();
                                    Log.d("Respuesta", errorMessage);
                                    if (errorMessage.contains("Profesional no encontrado")){
                                        Toast.makeText(context, "Profesional no encontrado", Toast.LENGTH_LONG).show();
                                    } else if (errorMessage.contains("Contraseña incorrecta")) {
                                        Toast.makeText(context, "Contraseña incorrecta", Toast.LENGTH_LONG).show();

                                    }
                                } catch (Exception e) {
                                    Log.d("Reaspuesta", "No se pudo leer el error del servidor: " + e.getMessage());
                                }
                            }
                            Intent intent = new Intent(context, MenuInicial.class);
                            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                            context.startActivity(intent);
                        }



                        @Override
                        public void onFailure(Call<Profesional> call, Throwable t) {
                            Log.d("Respuesta", "quisio");
                            Log.d("Error", t.getMessage());
                            Toast.makeText(context, "Error de Login", Toast.LENGTH_LONG).show();

                        }
                    });



                } else {
                    try {

                        String errorMessage = response.errorBody().string();
                        Log.d("Respuesta", errorMessage);
                        if (errorMessage.contains("Profesional no encontrado")){
                            Toast.makeText(context, "Profesional no encontrado", Toast.LENGTH_LONG).show();
                        } else if (errorMessage.contains("Contraseña incorrecta")) {
                            Toast.makeText(context, "Contraseña incorrecta", Toast.LENGTH_LONG).show();

                        }
                    } catch (Exception e) {
                        Log.d("Reaspuesta", "No se pudo leer el error del servidor: " + e.getMessage());
                    }
                }
            }



            @Override
            public void onFailure(Call<String> call, Throwable t) {
                Log.d("Respuesta", "quisio");
                Log.d("Error", t.getMessage());
                Toast.makeText(context, "Error de Login", Toast.LENGTH_LONG).show();

            }
        });






    }

}
