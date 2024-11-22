

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EstudioController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public EstudioController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getEstudio(int id)
{
    
    var Estudio = _context.Estudio.FirstOrDefault(x => x.Id == id);

    if (Estudio == null)
    {
        return NotFound();
    }

   

        return Ok(Estudio);
}



    
   
}
