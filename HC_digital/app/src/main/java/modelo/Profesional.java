package modelo;

import com.google.gson.annotations.SerializedName;

public class Profesional {

    @SerializedName("id")
    private long Id;

    @SerializedName("nombre")
    private String Nombre;

    @SerializedName("apellido")
    private String Apellido;

    @SerializedName("matriculaProvincial")
    private String MatriculaProvincial;

    @SerializedName("matriculaNacional")
    private String MatriculaNacional;

    @SerializedName("dni")
    private String Dni;

    @SerializedName("telefono")
    private String Telefono;

    @SerializedName("mail")
    private String Mail;


    public Profesional() {}
    public Profesional( long id, String nombre, String apellido, String matriculaProvincial, String matriculaNacional, String dni, String telefono, String mail) {
        Mail = mail;
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        MatriculaProvincial = matriculaProvincial;
        MatriculaNacional = matriculaNacional;
        Dni = dni;
        Telefono = telefono;
    }

    public Profesional(long id, String mail, String telefono, String dni, String matriculaProvincial, String apellido, String nombre) {
        Id = id;
        Mail = mail;
        Telefono = telefono;
        Dni = dni;
        MatriculaProvincial = matriculaProvincial;
        Apellido = apellido;
        Nombre = nombre;
    }

    public Profesional(String matriculaNacional,long id, String mail, String telefono, String dni, String apellido, String nombre) {
        Id = id;
        Mail = mail;
        Telefono = telefono;
        Dni = dni;
        MatriculaProvincial = matriculaNacional;
        Apellido = apellido;
        Nombre = nombre;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String nombre) {
        Nombre = nombre;
    }

    public String getApellido() {
        return Apellido;
    }

    public void setApellido(String apellido) {
        Apellido = apellido;
    }

    public long getId() {
        return Id;
    }


    public String getMatriculaProvincial() {
        return MatriculaProvincial;
    }

    public void setMatriculaProvincial(String matriculaProvincial) {
        MatriculaProvincial = matriculaProvincial;
    }

    public String getMatriculaNacional() {
        return MatriculaNacional;
    }

    public void setMatriculaNacional(String matriculaNacional) {
        MatriculaNacional = matriculaNacional;
    }

    public String getDni() {
        return Dni;
    }

    public void setDni(String dni) {
        Dni = dni;
    }

    public String getTelefono() {
        return Telefono;
    }

    public void setTelefono(String telefono) {
        Telefono = telefono;
    }

    public String getMail() {
        return Mail;
    }

    public void setMail(String mail) {
        Mail = mail;
    }
}
