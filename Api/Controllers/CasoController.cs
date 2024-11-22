

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
    
    var Caso = _context.Caso.FirstOrDefault(x => x.Id == id);

    if (Caso == null)
    {
        return NotFound();
    }

   

        return Ok(Caso);
}



    
   
}
