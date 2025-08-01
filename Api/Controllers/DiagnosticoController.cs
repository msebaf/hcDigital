

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

        var diagnosticos = _context.Diagnostico.Where(x => x.PacienteId == id && x.Cronico == true).OrderByDescending(x => x.FechaDiagnostico).ToList();

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
                Cronico = diagnostico.Cronico,

            };

            diagnosticosDTO.Add(diagnosticoDTO);
        }

        return Ok(diagnosticosDTO);

    }

    [HttpGet("Todos/{id}")]
    public IActionResult getDiagnosticos(long id)
    {

        var diagnosticos = _context.Diagnostico.Where(x => x.PacienteId == id).OrderByDescending(x => x.FechaDiagnostico).ToList();

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
                Cronico = diagnostico.Cronico,

            };

            diagnosticosDTO.Add(diagnosticoDTO);
        }

        return Ok(diagnosticosDTO);

    }

        [HttpPost]
        public IActionResult CrearDiagnostico([FromBody] Diagnostico nuevoDiagnostico)
        {
            try
            {
                if (nuevoDiagnostico == null)
                    return BadRequest("El diagnóstico es nulo.");

                
                nuevoDiagnostico.FechaDiagnostico = DateTime.Now;

                _context.Diagnostico.Add(nuevoDiagnostico);
                _context.SaveChanges();

                return CreatedAtAction(nameof(getDiagnostico), new { id = nuevoDiagnostico.Id }, nuevoDiagnostico);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
}
