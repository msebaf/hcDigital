

using Api.Models;
using Microsoft.AspNetCore.Authorization;
using MySql.Data.MySqlClient;


using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PacienteController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public PacienteController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";



    [HttpGet("id/{id}")]
public IActionResult getPaciente(int id)
{
    
    var Paciente = _context.Paciente.FirstOrDefault(x => x.Id == id);

    if (Paciente == null)
    {
        return NotFound();
    }

   

        return Ok(Paciente);
}

[HttpGet("dni/{dni}")]
public IActionResult getPaciente_Dni(String dni)
{
    
    var Paciente = _context.Paciente.FirstOrDefault(x => x.Dni == dni);

    if (Paciente == null)
    {
        return null;
    }

   

        return Ok(Paciente);
}


    
[HttpPost]
    public int nuevoPaciente(Paciente paciente)
    {
      var nPaciente = getPaciente_Dni(paciente.Dni);
      if(nPaciente == null)
      {
       int res = 0;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            var query = @"INSERT INTO paciente (Nombre, Direccion, Telefono, FechaNacimiento, Apellido, Mail, Dni, LugarNacimiento) 
            VALUES (@Nombre, @Direccion, @Telefono, @FechaNacimiento, @Apellido, @Mail, @Dni, @LugarNacimiento);
        SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                command.Parameters.AddWithValue("@Apellido", paciente.Apellido);
                command.Parameters.AddWithValue("@FechaNacimiento", paciente.FechaNacimiento);
                command.Parameters.AddWithValue("@Mail", paciente.Mail);
                command.Parameters.AddWithValue("@Dni", paciente.Dni);
                command.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                command.Parameters.AddWithValue("@Direccion", paciente.Direccion);
                command.Parameters.AddWithValue("@LugarNacimiento", paciente.LugarNacimiento);



                connection.Open();
                res = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                paciente.Id = res;
            }
        }
        return res;
      }else
      {
         return -1;
      }
      
      
      
    
    } 
    
   
}
