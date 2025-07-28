

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

        var hoy = DateOnly.FromDateTime(DateTime.Today);

        var recetas = _context.Receta
            .Where(x => x.PacienteId == id &&
                        (x.TratamientoCronico == true || x.Consumida == false) &&
                        x.FechaVencimiento >= hoy)
            .OrderByDescending(x => x.FechaCreacion)
            .ToList();


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
            var diagnostico = diagnosticoN == null ? null : _context.Diagnostico.FirstOrDefault(x => x.Id == diagnosticoN.Id);
            var patologia = diagnostico == null ? null : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
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
            var diagnostico = diagnosticoN == null ? null : _context.Diagnostico.FirstOrDefault(x => x.Id == diagnosticoN.Id);
            var patologia = diagnostico == null ? null : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
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


    [HttpPut("{id}")]
    public IActionResult AnularReceta(long id)
    {
        var receta = _context.Receta.FirstOrDefault(r => r.Id == id);
        if (receta == null)
        {
            return NotFound(new { mensaje = "Receta no encontrada" });
        }

        // Setea la fecha de vencimiento a ayer
        receta.FechaVencimiento = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

        _context.SaveChanges();

        return Ok(new { mensaje = "Receta anulada (fecha de vencimiento actualizada a ayer)" });
    }

[HttpPost]
public IActionResult CrearReceta([FromBody] Receta receta)
{
    // Asumimos que los datos como ProfesionalId, PacienteId, etc. ya vienen correctamente cargados en el objeto

    receta.FechaCreacion = DateOnly.FromDateTime(DateTime.Today);
    
    // Si no se especifica vencimiento, se le da uno por defecto (1 mes)
    if (receta.FechaVencimiento == default)
        receta.FechaVencimiento = DateOnly.FromDateTime(DateTime.Today.AddMonths(1));

    receta.Consumida = false;

    _context.Receta.Add(receta);
    _context.SaveChanges();

    return Ok(new { mensaje = "Receta creada correctamente", id = receta.Id });
}



}
