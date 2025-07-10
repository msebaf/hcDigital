

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



[HttpGet("estudios/{stringEstudios}")]
public List<Estudio> BuscadorEstudios(String stringEstudios)
    {

        List<Estudio> estudios = new List<Estudio>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"
                SELECT Id, Nombre
                    FROM estudio
                    WHERE Nombre LIKE CONCAT('%', @StringEstudios, '%')";
                using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@stringEstudios", stringEstudios);
                connection.Open();
                using (var reader = command.ExecuteReader())

                {

                    while (reader.Read())
                    {
                        Estudio estudio = new Estudio
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            
                        
                            
                        };
                        estudios.Add(estudio);
                    }
                }

            }
            connection.Close();
        }
        return estudios;
    }




}
