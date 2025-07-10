

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IntervencionController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public IntervencionController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getIntervencion(int id)
{
    
    var Intervencion = _context.Intervencion.FirstOrDefault(x => x.Id == id);

    if (Intervencion == null)
    {
        return NotFound();
    }

   

        return Ok(Intervencion);
}


    [HttpGet("Todas/{id}")]

public IActionResult getIntervencionesTodas(long id)
{
    
    var Intervenciones = _context.Intervencion.Where(x => x.PacienteId == id).OrderByDescending(x => x.FechaPrestacion).ToList();

    if (Intervenciones == null)
    {
        return NotFound();
    }

        var intervencionesDTO = new List<IntervencionDTO>();

        foreach (var Intervencion in Intervenciones)
        {
            var profesional = _context.Profesional.FirstOrDefault(x => x.Id == Intervencion.ProfesionalId);
            var prestacion = _context.Prestacion.FirstOrDefault(x => x.Id == Intervencion.PrestacionId);
            var diagnostico = _context.Diagnostico.FirstOrDefault(x => x.IntervencionId == Intervencion.Id);
            var patologia = diagnostico == null? null  : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
            var recetas = _context.Receta.Count(x => x.IntervencionId == Intervencion.Id);

            var IntervencionDTO = new IntervencionDTO
            {
                Id = Intervencion.Id,
                FechaPrestacion = Intervencion.FechaPrestacion.ToString("yyyy-MM-dd"),
                Profesional = profesional?.Nombre + " " + profesional?.Apellido,
                Prestacion = prestacion?.Nombre,
                Diagnostico = patologia != null ? patologia.Nombre : "Sin diagnóstico",
                Observaciones = Intervencion.Observaciones,
                Recetas = recetas,
                CasoId = Intervencion.CasoId,
                Actuaciones = Intervencion.Actuaciones,

           
            };

            intervencionesDTO.Add(IntervencionDTO);
            }
        

        return Ok(intervencionesDTO);
    }

    
   
}
