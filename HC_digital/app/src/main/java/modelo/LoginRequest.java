package modelo;

public class LoginRequest {
    public String Dni;
    public String Contrasenia;

    public LoginRequest(String dni, String password) {
        Dni = dni;
        Contrasenia = password;
    }

    public String getDni() {
        return Dni;
    }

    public String getContrasenia() {
        return Contrasenia;
    }

}

