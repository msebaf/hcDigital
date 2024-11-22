

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



    
   
}
