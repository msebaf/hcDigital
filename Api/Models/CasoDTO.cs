using System.Security.Policy;

namespace Api.Models;

public class CasoDTO
{
    public long Id { get; set; }

    public string? NombreProfesional { get; set; }

    public string? Especialidad { get; set; }

    public String? FechaApertura { get; set; }


    public long? IntervencionId { get; set; }

    public long? Intervenciones { get; set; }

    public long? Recetas { get; set; }

    public long PacienteId { get; set; }

    public String? Exploracion { get; set; }

    public String? DiagnosticoPresuntivo { get; set; }

    public bool? Terminado { get; set; }

    public string? Diagnostico { get; set; }
    
    public string? Especialidades { get; set; }
    


}
