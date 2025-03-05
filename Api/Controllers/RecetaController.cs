

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RecetaController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public RecetaController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getReceta(int id)
{
    
    var Receta = _context.Receta.FirstOrDefault(x => x.Id == id);

    if (Receta == null)
    {
        return NotFound();
    }

   

        return Ok(Receta);
}



   [HttpGet("Vigentes/{id}")]
public IActionResult getRecetas(long id)
{
    
    var recetas = _context.Receta.Where(x => x.PacienteId == id && (x.TratamientoCronico == true || x.Consumida == false)).OrderByDescending(x => x.FechaCreacion).ToList();

    if (recetas == null)
    {
        return NotFound();
    }

   
        var recetasDTO = new List<RecetaDTO>();
        foreach (var receta in recetas)
        {
            var profesional = _context.Profesional.FirstOrDefault(x => x.Id == receta.ProfesionalId);
            var estudio = _context.Estudio.FirstOrDefault(x => x.Id == receta.EstudioId);
            var medicacion = _context.Medicacion.FirstOrDefault(x => x.Id == receta.MedicacionId);
            var diagnosticoN = _context.Intervencion.FirstOrDefault(x => x.Id == receta.IntervencionId);
            var diagnostico  =diagnosticoN== null? null  : _context.Diagnostico.FirstOrDefault(x => x.Id == diagnosticoN.Id);
            var patologia = diagnostico == null? null  : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
            var Prestacion = _context.Prestacion.FirstOrDefault(x => x.Id == receta.PrestacionId);
           
            var recetaDTO = new RecetaDTO
            {
                Id = receta.Id,
                FechaCreacion = receta.FechaCreacion.ToString("yyyy-MM-dd"),
                FechaVencimiento = receta.FechaVencimiento.ToString("yyyy-MM-dd"),
                Profesional = profesional?.Nombre + " " + profesional?.Apellido,
                Estudio = estudio?.Nombre,
                MedicacionGenerico = medicacion?.NombreGenerico,
                MedicacionComercial = medicacion?.NombreComercial,
                Presentacion = medicacion?.Presentacion,
                Diagnostico = patologia?.Nombre,
                Prestacion = Prestacion?.Nombre,
                Consumida = receta.Consumida,
                TratamientoCronico = receta.TratamientoCronico,
                Indicaciones = receta.Indicaciones,
                IntervencionId = receta.IntervencionId
            };

            recetasDTO.Add(recetaDTO);
        }
        return Ok(recetasDTO);
}
    
    
   [HttpGet("Todas/{id}")]
public IActionResult getRecetasTodas(long id)
{
    
    var recetas = _context.Receta.Where(x => x.PacienteId == id).OrderByDescending(x => x.FechaCreacion).ToList();

    if (recetas == null)
    {
        return NotFound();
    }

   
        var recetasDTO = new List<RecetaDTO>();
        foreach (var receta in recetas)
        {
            var profesional = _context.Profesional.FirstOrDefault(x => x.Id == receta.ProfesionalId);
            var estudio = _context.Estudio.FirstOrDefault(x => x.Id == receta.EstudioId);
            var medicacion = _context.Medicacion.FirstOrDefault(x => x.Id == receta.MedicacionId);
            var diagnosticoN = _context.Intervencion.FirstOrDefault(x => x.Id == receta.IntervencionId);
            var diagnostico  =diagnosticoN== null? null  : _context.Diagnostico.FirstOrDefault(x => x.Id == diagnosticoN.Id);
            var patologia = diagnostico == null? null  : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
            var Prestacion = _context.Prestacion.FirstOrDefault(x => x.Id == receta.PrestacionId);
           
            var recetaDTO = new RecetaDTO
            {
                Id = receta.Id,
                FechaCreacion = receta.FechaCreacion.ToString("yyyy-MM-dd"),
                FechaVencimiento = receta.FechaVencimiento.ToString("yyyy-MM-dd"),
                Profesional = profesional?.Nombre + " " + profesional?.Apellido,
                Estudio = estudio?.Nombre,
                MedicacionGenerico = medicacion?.NombreGenerico,
                MedicacionComercial = medicacion?.NombreComercial,
                Presentacion = medicacion?.Presentacion,
                Diagnostico = patologia?.Nombre,
                Prestacion = Prestacion?.Nombre,
                Consumida = receta.Consumida,
                TratamientoCronico = receta.TratamientoCronico,
                Indicaciones = receta.Indicaciones,
                IntervencionId = receta.IntervencionId
            };

            recetasDTO.Add(recetaDTO);
        }
        return Ok(recetasDTO);
}
   
}
