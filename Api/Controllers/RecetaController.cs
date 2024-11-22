

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



    
   
}
