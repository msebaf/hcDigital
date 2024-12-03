

using Api.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MySql.Data.MySqlClient;
using Microsoft.IdentityModel.Tokens;



using Microsoft.AspNetCore.Mvc;



namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfesionalController : ControllerBase
{

private readonly DataContext _context;
private readonly IConfiguration _config;
    public ProfesionalController(DataContext contexto, IConfiguration config)
    {
        _context = contexto;
        _config = config;
    }


String connectionString = "Server=localhost;User=root;Password=;Database=hc_digital;SslMode=none";


    [HttpPost("{login}")]
    public IActionResult Login(LoginView login)
    {
        var profesional = _context.Profesional.FirstOrDefault(x => x.Dni == login.Dni);
        

        if (profesional == null)
            {
                Console.WriteLine("----------------No encontrado---------------");
                return NotFound(new { message = "Profesional no encontrado" });
            }

            if (profesional.Contrasenia != login.Contrasenia)
            {
                Console.WriteLine("----------------Contraseña incorrecta---------------");
                return BadRequest(new { message = "Contraseña incorrecta" });
            }


        // agregar la comparacion por hasheo

        var key = new SymmetricSecurityKey(
						System.Text.Encoding.ASCII.GetBytes(_config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name, profesional.Dni),
						new Claim("Id", profesional.Id.ToString()),
						//new Claim(ClaimTypes.Role, "Propietario"),
					};

					var token = new JwtSecurityToken(
						issuer: _config["TokenAuthentication:Issuer"],
						audience: _config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddMinutes(60),
						signingCredentials: credenciales
					);
          Console.WriteLine("Token: " +token);
					return Ok(new JwtSecurityTokenHandler().WriteToken(token));
    }



    [HttpGet("n/{Dni}")]
    
public IActionResult getProfesional(String Dni)
{
    
    var profesional = _context.Profesional.FirstOrDefault(x => x.Dni.Equals(Dni));

    if (profesional == null)
    {
        return NotFound();
    }

        Console.WriteLine(profesional.Nombre);

        return Ok(profesional);
}



    
   
}
