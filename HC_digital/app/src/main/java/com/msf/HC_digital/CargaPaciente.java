package com.msf.HC_digital;

import android.app.DatePickerDialog;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.lifecycle.ViewModelProvider;

import com.msf.HC_digital.databinding.ActivityCargaPacienteBinding;

import java.util.Calendar;

public class CargaPaciente extends AppCompatActivity {
    private ActivityCargaPacienteBinding binding;
    private CargaPacienteViewModel mv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        //setContentView(R.layout.activity_carga_paciente);
        binding = ActivityCargaPacienteBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        mv = new ViewModelProvider(this).get(CargaPacienteViewModel.class);


        String dni = getIntent().getStringExtra("DNI");
        binding.etDni.setText(dni);

        binding.btnAgregarPaciente.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.d("Respuesta", "Click botón paciente");
                mv.cargarPaciente(binding.etDni.getText().toString(), binding.etNombre.getText().toString(), binding.etApellido.getText().toString(), binding.etTelefono.getText().toString(), binding.etMail.getText().toString(), binding.etDireccion.getText().toString(), binding.etLugarNacimiento.getText().toString(), binding.etFechaNacimiento.getText().toString());
            }
        });




        binding.etFechaNacimiento.setOnClickListener(v -> {
            // Obtener la fecha actual para inicializar el selector
            Calendar calendar = Calendar.getInstance();
            int year = calendar.get(Calendar.YEAR);
            int month = calendar.get(Calendar.MONTH);
            int day = calendar.get(Calendar.DAY_OF_MONTH);

            // Mostrar el DatePickerDialog
            DatePickerDialog datePickerDialog = new DatePickerDialog(
                    CargaPaciente.this,
                    (view, year1, month1, dayOfMonth) -> {
                        // Actualizar el campo de texto con la fecha seleccionada
                        String selectedDate = dayOfMonth + "/" + (month1 + 1) + "/" + year1;
                        binding.etFechaNacimiento.setText(selectedDate);
                    },
                    year, month, day
            );
            datePickerDialog.show();
        });






        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

    }
}