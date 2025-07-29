namespace Api.Models;

public class Diagnostico
{
    public long Id { get; set; }

    public long ProfesionalId { get; set; }

    public long PacienteId { get; set; }

    public long? PatologiaId {get; set;}

    public DateTime FechaDiagnostico {get;set;}

    public long? IntervencionId {get;set;}

    public bool Cronico {get;set;}




}
