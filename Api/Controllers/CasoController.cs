

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CasoController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public CasoController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getCaso(int id)
{
    
    var caso = _context.Caso.FirstOrDefault(x => x.Id == id);

    if (caso == null)
    {
        return NotFound();
    }

   

        return Ok(caso);
}


   [HttpGet("n/{id}")]
public IActionResult getCasos(long id)
{
    
    var casos = _context.Caso.Where(x => x.PacienteId == id).ToList();

    if (casos == null)
    {
        return NotFound();
    }

   
    var casosDTO = new List<CasoDTO>();

    foreach (var caso in casos)
    {
       var profesional = _context.Profesional.FirstOrDefault(x => x.Id == caso.ProfesionalId);
        var intervenciones = _context.Intervencion.Where(x => x.CasoId == caso.Id).ToList(); //todas las intervenciones puede ser asociadas a un caso
        int intervencionesCount = intervenciones.Count;
        var primeraIntervencion = _context.Intervencion.FirstOrDefault(x => x.Id == caso.IntervencionId); // El caso almacena el id de la pimera intervencion
        var diagnostico = _context.Diagnostico.FirstOrDefault(x => x.Id == caso.DiagnosticoId);
        var patologia = diagnostico == null? null  : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
        var recetas = new List<Receta>();
        foreach (var interv in intervenciones)
        {
            var recetasForInterv = _context.Receta.Where(x => x.IntervencionId == interv.Id).ToList();
            recetas.AddRange(recetasForInterv);
        }
        int recetasCount = recetas.Count;
        var casoDTO = new CasoDTO
        {
            Id = caso.Id,
            FechaApertura = primeraIntervencion?.FechaPrestacion.ToString("yyyy-MM-dd"),
            NombreProfesional = profesional?.Nombre + " " + profesional?.Apellido,
            Intervenciones = intervencionesCount,
            Recetas = recetasCount,
            Diagnostico =  patologia?.Nombre,
            DiagnosticoPresuntivo = caso.DiagnosticoPresuntivo,
            Terminado = caso.Terminado,
            IntervencionId = primeraIntervencion?.Id,
            PacienteId = id,
            Exploracion = caso.Exploracion,
            


            
        };
        casosDTO.Add(casoDTO);
    }
        return Ok(casosDTO);
}


    
   
}
