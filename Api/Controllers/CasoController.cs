

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



            var diagnostico = _context.Diagnostico.FirstOrDefault(x => x.Id == caso.DiagnosticoId);
            var patologia = diagnostico == null ? null : _context.Patologia.FirstOrDefault(x => x.Id == diagnostico.PatologiaId);
            var recetas = new List<Receta>();

            int recetasCount = recetas.Count;
            var Especialidades = _context.EspecialidadProfesional.Where(x => x.ProfesionalId == profesional.Id).ToList();
            String EspecialidadesString = "";

            foreach (var Especialidad in Especialidades)
            {
                var esp = _context.Especialidad.FirstOrDefault(x => x.Id == Especialidad.EspecialidadId);
                EspecialidadesString = EspecialidadesString + esp.Nombre + "-";
            }
            var casoDTO = new CasoDTO
            {
                Id = caso.Id,
                NombreProfesional = profesional?.Nombre + " " + profesional?.Apellido,
                Recetas = recetasCount,
                Diagnostico = patologia?.Nombre,
                DiagnosticoPresuntivo = caso.DiagnosticoPresuntivo,
                Terminado = caso.Terminado,
                PacienteId = id,
                Exploracion = caso.Exploracion,
                Especialidad = EspecialidadesString




            };
            casosDTO.Add(casoDTO);
        }
        return Ok(casosDTO);
    }

    [HttpPost]
    public IActionResult CrearCaso([FromBody] Caso nuevoCaso)
    {
        try
        {

            _context.Caso.Add(nuevoCaso);
            _context.SaveChanges();
            return Ok(nuevoCaso);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Error al guardar el caso: {e.Message}");
        }
    }
            


        [HttpPut("cerrar/{id}")]
        public IActionResult CerrarCaso(long id)
        {
            try
            {
                var caso = _context.Caso.FirstOrDefault(x => x.Id == id);
                if (caso == null)
                {
                    return NotFound($"No se encontró el caso con ID {id}");
                }

                caso.Terminado = true;
                _context.SaveChanges();

                return Ok($"Caso con ID {id} marcado como cerrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al cerrar el caso: {ex.Message}");
            }
        }





}
