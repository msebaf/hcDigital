namespace Api.Models;

public class Receta
{
    public long Id { get; set; }

    public long PacienteId { get; set; }

    public long ProfesionalId { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    public Intervencion intervencionId { get; set;}

    public long? MedicacionId { get; set; }

    public long? EstudioId { get; set; }

    public long? PrestacioId { get; set; }

    public String? Indicaciones { get; set; }

    public bool TratamientoCronico { get; set; }

    public bool? Consumida { get; set; }
    
    


}
