using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Paciente
    {
        public long? Id { get; set; }
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public String? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Mail { get; set; }
        public string? Direccion { get; set; }
        public string? LugarNacimiento { get; set; }
    }
}
