package com.msf.HC_digital.ui.asentarIntervencion;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import com.msf.HC_digital.databinding.FragmentAsentarIntervencionBinding;

public class AsentarIntervencionFragment extends Fragment {

    private AsentarIntervencionViewModel mViewModel;
    private FragmentAsentarIntervencionBinding binding;

    public static AsentarIntervencionFragment newInstance() {
        return new AsentarIntervencionFragment();
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {

        binding = FragmentAsentarIntervencionBinding.inflate(inflater, container, false);
        View root = binding.getRoot();
        return root;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        mViewModel = new ViewModelProvider(this).get(AsentarIntervencionViewModel.class);
        // TODO: Use the ViewModel
    }

}