package com.msf.HC_digital;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.lifecycle.ViewModelProvider;

import com.msf.HC_digital.databinding.ActivityMenuInicialBinding;

public class MenuInicial extends AppCompatActivity {
    private ActivityMenuInicialBinding binding;
    private MenuInicialViewModel mv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        binding = ActivityMenuInicialBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        mv = new ViewModelProvider(this).get(MenuInicialViewModel.class);

        // Ajustar los insets para el diseño edge-to-edge
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Configurar el botón "Paciente"
        binding.btPaciente.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("Log", "Click botón paciente");
                mv.iniciarIntervencion(binding.etDniPaciente.getText().toString());
            }
        });

        // Observar el LiveData para mostrar el diálogo de confirmación
        mv.mostrarDialogo.observe(this, mostrar -> {
            if (mostrar != null && mostrar) {
                mostrarDialogoConfirmacion();
            }
        });

        // Observar el LiveData para mostrar mensajes Toast
        mv.mensajeToast.observe(this, mensaje -> {
            if (mensaje != null) {
                Toast.makeText(this, mensaje, Toast.LENGTH_LONG).show();
            }
        });
    }

    private void mostrarDialogoConfirmacion() {
        new AlertDialog.Builder(this)
                .setTitle("Confirmación")
                .setMessage("No se encontro a nadie con ese DNI.¿Quiere cargar una nuevo paciente?")
                .setPositiveButton("Nuevo psciente", (dialog, which) -> {
                    Log.d("DIALOGO", "Se presionó Aceptar");
                    Intent intent = new Intent(this, CargaPaciente.class);
                    intent.putExtra("DNI", binding.etDniPaciente.getText().toString());
                    startActivity(intent);

                })
                .setNegativeButton("Cancelar", (dialog, which) -> {
                    Log.d("DIALOGO", "Se presionó Cancelar");
                })
                .show();
    }
}
