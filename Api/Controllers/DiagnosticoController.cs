

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DiagnosticoController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public DiagnosticoController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getDiagnostico(int id)
{
    
    var Diagnostico = _context.Diagnostico.FirstOrDefault(x => x.Id == id);

    if (Diagnostico == null)
    {
        return NotFound();
    }

   

        return Ok(Diagnostico);
}



   [HttpGet("Cronicas/{id}")]
public IActionResult getCronicas(long id)
{
    
    var diagnosticos = _context.Diagnostico.Where(x => x.PacienteId == id && x.Cronico == true).ToList();

    if (diagnosticos == null)
    {
        return NotFound();
    }

   
    var diagnosticosDTO = new List<DiagnosticoDTO>();

    foreach (var diagnostico in diagnosticos)
    {
        var profesional = _context.Profesional.FirstOrDefault(x => x.Id == diagnostico.ProfesionalId);
        var patologia = _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
        String fecha = diagnostico.FechaDiagnostico.ToString("yyyy-MM-dd");

        DiagnosticoDTO diagnosticoDTO = new DiagnosticoDTO
        {
            Id = diagnostico.Id,
            FechaDiagnostico = fecha,
            Profesional = profesional?.Nombre + " " + profesional?.Apellido,
            Patologia = patologia?.Nombre,
            Cronico = diagnostico.Cronico
        };

      diagnosticosDTO.Add(diagnosticoDTO);
    }

    return Ok(diagnosticosDTO);
    
}
}
