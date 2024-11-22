

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicacionController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public MedicacionController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getMedicacion(int id)
{
    
    var Medicacion = _context.Medicacion.FirstOrDefault(x => x.Id == id);

    if (Medicacion == null)
    {
        return NotFound();
    }

   

        return Ok(Medicacion);
}



    
   
}
