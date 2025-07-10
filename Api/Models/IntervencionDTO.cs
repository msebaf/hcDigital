namespace Api.Models;

public class IntervencionDTO
{
    public long Id { get; set; }

    public long PacienteId { get; set; }

    public String? Profesional { get; set; }

    public String? Prestacion { get; set; }

    public String? FechaPrestacion { get; set; }

    public string? Observaciones { get; set; }

    public string? Actuaciones { get; set; }

    public long? CasoId { get; set; }

    public String? Diagnostico { get; set; }
    
    public int? Recetas { get; set; }



}
