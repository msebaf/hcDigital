

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PatologiaController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public PatologiaController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getPatologia(int id)
{
    
    var Patologia = _context.Patologia.FirstOrDefault(x => x.Id == id);

    if (Patologia == null)
    {
        return NotFound();
    }

   

        return Ok(Patologia);
}

[HttpGet("patologias/{stringPatologias}")]
public List<Patologia> BuscadorPatologias(String stringPatologias)
    {

        List<Patologia> Patologias = new List<Patologia>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"SELECT Id, Nombre from Patologia where Nombre like CONCAT('%', @stringPatologias, '%');";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@stringPatologias", stringPatologias);
                connection.Open();
                using (var reader = command.ExecuteReader())

                {

                    while (reader.Read())
                    {
                        Patologia Patologia = new Patologia
                        {
                            Id = reader.GetInt32(0), 
                            Nombre = reader.GetString(1), 
                        
                            
                        };
                        Patologias.Add(Patologia);
                    }
                }

            }
            connection.Close();
        }
        return Patologias;
    }

    
   
}
