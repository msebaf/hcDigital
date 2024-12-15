package com.msf.HC_digital.ui.home;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.msf.HC_digital.R;

import java.util.List;

import modelo.Caso;

public class CasosAdapter extends RecyclerView.Adapter<CasosAdapter.ViewHolder> {
    private Context context;
    private List<Caso> casos;
    private LayoutInflater inflater;

    public CasosAdapter(Context context, List<Caso> casos, LayoutInflater inflater) {
        this.context = context;
        this.casos = casos;
        this.inflater = LayoutInflater.from(context);
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View root = inflater.inflate(R.layout.caso, parent, false);
        return new ViewHolder(root);
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        holder.profesional.setText(casos.get(position).getNombreProfesional());
        holder.especialidad.setText(casos.get(position).getEspecialidad());
        holder.exploracion.setText(casos.get(position).getExploracion());
        holder.diagnostico.setText(casos.get(position).getDiagnostico());
        holder.intervenciones.setText(casos.get(position).getIntervenciones() +"");
        holder.recetas.setText(casos.get(position).getRecetas()+"");
    }

    @Override
    public int getItemCount() {
        return casos.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        TextView profesional;
        TextView especialidad;
        TextView exploracion;
        TextView diagnostico;
        TextView intervenciones;
        TextView recetas;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            profesional = itemView.findViewById(R.id.tvProfesionalCard);
            especialidad = itemView.findViewById(R.id.tvEspecialidadCard);
            exploracion = itemView.findViewById(R.id.tvExploracionCard);
            diagnostico = itemView.findViewById(R.id.tvDiagCard);
            intervenciones = itemView.findViewById(R.id.tvNintervencionesCard);
            recetas = itemView.findViewById(R.id.tvRecetasCard);

        }
    }
}
