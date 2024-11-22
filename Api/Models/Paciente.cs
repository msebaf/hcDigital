namespace Api.Models;

public class Paciente
{
    public long Id { get; set; }

    public String Dni { get; set; }

    public String Nombre { get; set; }

    public String Apellido { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public String? Telefono { get; set; }

    public String? Mail { get; set; }

    public String Direccion { get; set; }

    public String LugarNacimiento { get; set; }


}
