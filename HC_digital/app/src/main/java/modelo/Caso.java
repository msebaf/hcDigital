package modelo;

public class Caso {

    private Long id;
    private String nombreProfesional;
    private String especialidad;
    private String exploracion;
    private String diagnosticoPresuntivo;
    private String diagnostico;
    private int recetas;
    private int intervenciones;


    public Caso(Long id, String nombreProfesional, String especialidad, String exploracion, String diagnosticoPresuntivo, String diagnostico, int recetas, int intervenciones) {
        this.id = id;
        this.nombreProfesional = nombreProfesional;
        this.especialidad = especialidad;
        this.exploracion = exploracion;
        this.diagnosticoPresuntivo = diagnosticoPresuntivo;
        this.diagnostico = diagnostico;
        this.recetas = recetas;
        this.intervenciones = intervenciones;
    }


    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getNombreProfesional() {
        return nombreProfesional;
    }

    public void setNombreProfesional(String nombreProfesional) {
        this.nombreProfesional = nombreProfesional;
    }

    public String getEspecialidad() {
        return especialidad;
    }

    public void setEspecialidad(String especialidad) {
        this.especialidad = especialidad;
    }

    public String getExploracion() {
        return exploracion;
    }

    public void setExploracion(String exploracion) {
        this.exploracion = exploracion;
    }

    public String getDiagnosticoPresuntivo() {
        return diagnosticoPresuntivo;
    }

    public void setDiagnosticoPresuntivo(String diagnosticoPresuntivo) {
        this.diagnosticoPresuntivo = diagnosticoPresuntivo;
    }

    public String getDiagnostico() {
        return diagnostico;
    }

    public void setDiagnostico(String diagnostico) {
        this.diagnostico = diagnostico;
    }

    public int getRecetas() {
        return recetas;
    }

    public void setRecetas(int recetas) {
        this.recetas = recetas;
    }

    public int getIntervenciones() {
        return intervenciones;
    }

    public void setIntervenciones(int intervenciones) {
        this.intervenciones = intervenciones;
    }
}
