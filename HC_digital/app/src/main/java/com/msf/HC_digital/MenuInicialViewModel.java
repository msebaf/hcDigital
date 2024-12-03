package com.msf.HC_digital;

import android.app.Application;
import android.content.Context;
import android.content.SharedPreferences;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.MutableLiveData;

import modelo.Paciente;
import request.ApiClient;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MenuInicialViewModel extends AndroidViewModel {
    private Context context;
    public MutableLiveData<Boolean> mostrarDialogo = new MutableLiveData<>();
    public MutableLiveData<String> mensajeToast = new MutableLiveData<>();

    public MenuInicialViewModel(@NonNull Application application) {
        super(application);
        this.context = application.getApplicationContext();
    }

    public void iniciarIntervencion(String dni) {
        ApiClient.EndPointHcDigital end = ApiClient.getEndPointHcDigital();
        SharedPreferences sp = context.getSharedPreferences("token.xml", Context.MODE_PRIVATE);
        String token = sp.getString("token", "");

        Call<Paciente> call = end.getPaciente(token, dni);
        call.enqueue(new Callback<Paciente>() {
            @Override
            public void onResponse(Call<Paciente> call, Response<Paciente> response) {
                if (response.isSuccessful()) {
                    // Si la respuesta es exitosa, mostrar un mensaje Toast
                    mensajeToast.postValue("Intervención iniciada");
                } else {
                    // Si la respuesta no es exitosa, notificar para mostrar el diálogo
                    mostrarDialogo.postValue(true);
                }
            }

            @Override
            public void onFailure(Call<Paciente> call, Throwable t) {
                mensajeToast.postValue("Intervención no iniciada");
            }
        });
    }
}
