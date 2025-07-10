

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


[HttpGet("medicaciones/{stringMedicamentos}")]
public List<Medicacion> BuscadorPatologias(String stringMedicamentos)
    {

        List<Medicacion> medicaciones = new List<Medicacion>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"
                SELECT Id, NombreGenerico, NombreComercial, Presentacion
                    FROM medicacion
                    WHERE NombreGenerico LIKE CONCAT('%', @stringMedicamentos, '%')
                    OR NombreComercial LIKE CONCAT('%', @stringMedicamentos, '%');";
                using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@stringMedicamentos", stringMedicamentos);
                connection.Open();
                using (var reader = command.ExecuteReader())

                {

                    while (reader.Read())
                    {
                        Medicacion medicacion = new Medicacion
                        {
                            Id = reader.GetInt32(0),
                            NombreGenerico = reader.GetString(1),
                            NombreComercial = reader.GetString(2),
                            Presentacion = reader.GetString(3), 
                        
                            
                        };
                        medicaciones.Add(medicacion);
                    }
                }

            }
            connection.Close();
        }
        return medicaciones;
    }





}
