package com.msf.HC_digital.ui.home;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.msf.HC_digital.databinding.FragmentHomeBinding;

import java.util.ArrayList;

import modelo.Caso;

public class HomeFragment extends Fragment {

    private FragmentHomeBinding binding;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        HomeViewModel homeViewModel =
                new ViewModelProvider(this).get(HomeViewModel.class);

        binding = FragmentHomeBinding.inflate(inflater, container, false);
        View root = binding.getRoot();

        ArrayList<Caso> casos = new ArrayList<Caso>();
        casos.add(new Caso(1L, "Especialidad 1", "Exploracion 1", "Diagnostico 1", "1", "Recetas 1",1,1));
        casos.add(new Caso(2L, "Especialidad 2", "Exploracion 2", "Diagnostico 2", "2", "Recetas 2",2,2));
        casos.add(new Caso(3L, "Especialidad 3", "Exploracion 3", "Diagnostico 3", "3", "Recetas 3",3,3));
        casos.add(new Caso(5L, "Especialidad 4", "Exploracion 4", "Diagnostico 4", "4", "Recetas 4",3,3));
        casos.add(new Caso(4L, "Especialidad 5", "Exploracion 5", "Diagnostico 5", "5", "Recetas 5",3,3));

        RecyclerView rv = binding.rvListaCasos;

        GridLayoutManager grilla = new GridLayoutManager(getContext(), 1, GridLayoutManager.VERTICAL, false);
        rv.setLayoutManager(grilla);
        CasosAdapter adapter = new CasosAdapter(getContext(), casos, getLayoutInflater());
        rv.setAdapter(adapter);

        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}