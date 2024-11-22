

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PrestacionController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public PrestacionController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getPrestacion(int id)
{
    
    var Prestacion = _context.Prestacion.FirstOrDefault(x => x.Id == id);

    if (Prestacion == null)
    {
        return NotFound();
    }

   

        return Ok(Prestacion);
}

[HttpGet("prestaciones/{stringPrestaciones}")]
public List<Prestacion> BuscadorPrestaciones(String stringPrestaciones)
    {

        List<Prestacion> Prestaciones = new List<Prestacion>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Nombre from Prestacion where Nombre like CONCAT('%', @stringPrestaciones, '%');";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@stringPrestaciones", stringPrestaciones);
                connection.Open();
                using (var reader = command.ExecuteReader())

                {

                    while (reader.Read())
                    {
                        Prestacion Prestacion = new Prestacion
                        {
                            Id = reader.GetInt32(0), 
                            Nombre = reader.GetString(1), 
                        
                            
                        };
                        Prestaciones.Add(Prestacion);
                    }
                }

            }
            connection.Close();
        }
        return Prestaciones;
    }

    
   
}
