namespace Api.Models;

public class RecetaDTO
{
    public long Id { get; set; }

    public string? PacienteId { get; set; } //Los datos del paciente no seran necesarios para la vista porque estan guardados en la aplicacion al iniciar intervencion

    public String? Profesional { get; set; }

    public String? FechaCreacion { get; set; }

    public String? FechaVencimiento { get; set; }

    public long IntervencionId { get; set;}

    public string? MedicacionGenerico { get; set; }

    public string? MedicacionComercial { get; set; }

    public String? Presentacion { get; set; }

    public String? Estudio { get; set; }

    public String? Prestacion { get; set; }

    public String? Indicaciones { get; set; }

    public bool TratamientoCronico { get; set; }

    public bool? Consumida { get; set; }
    public String? Diagnostico { get; set; }
    
    


}
