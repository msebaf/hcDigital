namespace Api.Models;

public class DiagnosticoDTO
{
    public long Id { get; set; }

    public string? Profesional { get; set; }

    public string? Patologia {get; set;}

    public String? FechaDiagnostico {get;set;}

    //public Intervencion? Intervencion{get;set;}

    public bool Cronico {get;set;}




}
