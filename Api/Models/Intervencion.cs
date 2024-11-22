namespace Api.Models;

public class Intervencion
{
    public long Id { get; set; }

    public long PacienteId { get; set; }

    public long ProfesionalId { get; set; }

    public long? PrestacionId { get; set; }

    public DateTime FechaPrestacion { get; set; }

    public string? Observaciones { get; set; }

    public string? Actuaciones { get; set; }

    public long? CasoId { get; set; }



}
