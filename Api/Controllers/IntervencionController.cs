

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



    
   
}
