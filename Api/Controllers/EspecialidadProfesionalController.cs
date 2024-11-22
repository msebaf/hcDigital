

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EspecialidadProfesionalController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public EspecialidadProfesionalController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getEspecialidadProfesional(int id)
{
    
    var EspecialidadProfesional = _context.EspecialidadProfesional.FirstOrDefault(x => x.Id == id);

    if (EspecialidadProfesional == null)
    {
        return NotFound();
    }

   

        return Ok(EspecialidadProfesional);
}



    
   
}
