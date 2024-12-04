

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
    
    var paciente = _context.Paciente.FirstOrDefault(x => x.Id == id);

    if (paciente == null)
    {
        return NotFound();
    }

   

        var pacienteDTO = new PacienteDTO
    {
        Id = paciente.Id,
        Dni = paciente.Dni,
        Nombre = paciente.Nombre,
        Apellido = paciente.Apellido,
        FechaNacimiento = paciente.FechaNacimiento?.ToString("yyyy-MM-dd"), // Conversión de DateTime a string
        Telefono = paciente.Telefono,
        Mail = paciente.Mail,
        Direccion = paciente.Direccion,
        LugarNacimiento = paciente.LugarNacimiento
    };

    return Ok(pacienteDTO);
}

[HttpGet("n/{dni}")]
public IActionResult getPaciente_Dni(String dni)
{
    
    var paciente = _context.Paciente.FirstOrDefault(x => x.Dni == dni);

    if (paciente == null)
    {
        return NotFound();
    }

   

         var pacienteDTO = new PacienteDTO
    {
        Id = paciente.Id,
        Dni = paciente.Dni,
        Nombre = paciente.Nombre,
        Apellido = paciente.Apellido,
        FechaNacimiento = paciente.FechaNacimiento?.ToString("yyyy-MM-dd"), // Conversión de DateTime a string
        Telefono = paciente.Telefono,
        Mail = paciente.Mail,
        Direccion = paciente.Direccion,
        LugarNacimiento = paciente.LugarNacimiento
    };

    return Ok(pacienteDTO);
}


    
[HttpPost]
    public PacienteDTO nuevoPaciente(PacienteDTO paciente)
    {
        Console.WriteLine("-------------------" + paciente.FechaNacimiento + "-------------------");
      
      if(paciente.Dni != null)
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
                res =  Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
                paciente.Id = res;
                Console.WriteLine("-------------"+ res);
                Console.WriteLine("-------------"+ paciente.Nombre);
            }
        }
        return paciente;
      }else
      {
        paciente.Dni = "-1";
         return paciente;
      }
      
      
      
    
    } 
    
   
}
