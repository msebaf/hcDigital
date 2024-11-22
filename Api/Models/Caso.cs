namespace Api.Models;

public class Caso
{
    public long Id { get; set; }

    public long ProfesionalId { get; set; }

    public long IntervencionId {get;set;}

    public long PacienteId {get;set;}

    public String? Exploracion {get;set;}

    public String? DiagnosticoPresuntivo {get;set;}

    public bool? Terminado {get;set;}

    public long? DiagnosticoId {get;set;}


}
