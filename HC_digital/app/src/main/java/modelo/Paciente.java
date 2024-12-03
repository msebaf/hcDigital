package modelo;


import com.google.gson.annotations.SerializedName;

public class Paciente {

    @SerializedName("id")
    private long Id;
    @SerializedName("dni")
    private String Dni;
    @SerializedName("nombre")
    private String Nombre;
    @SerializedName("apellido")
    private String Apellido;
    @SerializedName("telefono")
    private String Telefono;
    @SerializedName("mail")
    private String Mail;
    @SerializedName("direccion")
    private String Direccion;
    @SerializedName("lugarNacimiento")
    private String LugarNacimiento;
    @SerializedName("fechaNacimiento")
    private String FechaNacimiento;

    public Paciente() {}



    public Paciente(String dni, String nombre, String apellido, String telefono,
                    String mail, String direccion, String lugarNacimiento, String fechaNacimiento) {

        Dni = dni;
        Nombre = nombre;
        Apellido = apellido;
        Telefono = telefono;
        Mail = mail;
        Direccion = direccion;
        LugarNacimiento = lugarNacimiento;
        FechaNacimiento = fechaNacimiento;
    }

    public Long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    public String getDni() {
        return Dni;
    }

    public void setDni(String dni) {
        Dni = dni;
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

    public String getDireccion() {
        return Direccion;
    }

    public void setDireccion(String direccion) {
        Direccion = direccion;
    }

    public String getLugarNacimiento() {
        return LugarNacimiento;
    }

    public void setLugarNacimiento(String lugarNacimiento) {
        LugarNacimiento = lugarNacimiento;
    }

    public String getFechaNacimiento() {
        return FechaNacimiento;
    }

    public void setFechaNacimiento(String fechaNacimiento) {
        FechaNacimiento = fechaNacimiento;
    }

    @Override
    public String toString() {
        return "Paciente{" +
                "Id=" + Id +
                ", Dni='" + Dni + '\'' +
                ", Nombre='" + Nombre + '\'' +
                ", Apellido='" + Apellido + '\'' +
                ", Telefono='" + Telefono + '\'' +
                ", Mail='" + Mail + '\'' +
                ", Direccion='" + Direccion + '\'' +
                ", LugarNacimiento='" + LugarNacimiento + '\'' +
                ", FechaNacimiento='" + FechaNacimiento + '\'' +
                '}';
    }
}
