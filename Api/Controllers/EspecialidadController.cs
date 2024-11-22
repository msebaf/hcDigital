

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EspecialidadController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public EspecialidadController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getEspecialidad(int id)
{
    
    var Especialidad = _context.Especialidad.FirstOrDefault(x => x.Id == id);

    if (Especialidad == null)
    {
        return NotFound();
    }

   

        return Ok(Especialidad);
}



    
   
}
