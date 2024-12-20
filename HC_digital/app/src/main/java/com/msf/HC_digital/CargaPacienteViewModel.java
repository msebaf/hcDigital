package com.msf.HC_digital;

import android.app.Application;
import android.content.Context;
import android.content.SharedPreferences;
import android.util.Log;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

import modelo.Paciente;
import request.ApiClient;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CargaPacienteViewModel extends AndroidViewModel {
    public Context context;
    public CargaPacienteViewModel(@NonNull Application application) {
        super(application);
        this.context = application.getApplicationContext();
    }

    public void cargarPaciente(String dni, String nombre, String apellido, String telefono, String mail, String direccion, String lugarNacimiento, String fechaNacimiento) {
        Log.d("Respuesta", "metodo carga paciente");
        DateTimeFormatter formatoEntrada = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        DateTimeFormatter formatoSalida = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        LocalDate fecha = LocalDate.parse(fechaNacimiento, formatoEntrada);
        String fechaSalida  = fecha.format(formatoSalida);;
        Log.d("Respuesta", fechaSalida.toString());
        Paciente paciente = new Paciente(dni, nombre, apellido, telefono, mail, direccion, lugarNacimiento, fechaSalida );
        Log.d("Respuesta", paciente.getFechaNacimiento().toString());
        ApiClient.EndPointHcDigital end = ApiClient.getEndPointHcDigital();
        SharedPreferences sp = context.getSharedPreferences("token.xml", Context.MODE_PRIVATE);
        String token = sp.getString("token", "");

        Call<Paciente> call = end.nuevoPaciente(token, paciente);
        call.enqueue(new Callback<Paciente>() {
            @Override
            public void onResponse(Call<Paciente> call, Response<Paciente> response) {
                if (response.isSuccessful()) {
                    Log.d("Respuesta", response.body().toString());
                } else {
                    Log.d("Respuesta", "No se pudo cargar el paciente respuesta ok");
                }
            }

            @Override
            public void onFailure(Call<Paciente> call, Throwable t) {
                Log.d("Respuesta", "No se pudo cargar el paciente falla");
            }
        });
    }
}
