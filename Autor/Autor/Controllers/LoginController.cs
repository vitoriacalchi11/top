using Autor.Data;
using Autor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Autor.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly SistemaTarefasDbContext _dbContext;

        public LoginController(SistemaTarefasDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.Email == login.Login && u.Senha == login.Senha);

            if (usuario != null)
            {
                var token = GerarToken(usuario);
                return Ok(new { token });
            }
            return BadRequest(new { mensagem = "Credenciais inválidas. Por favor, verifique e tente novamente." });
        }

        private string GerarToken(UsuarioModel usuario)
        {
            string chaveSecreta = "c40fc6e2-350e-45d6-84f9-11f11ea39e0c";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", usuario.Email)
            };

            var token = new JwtSecurityToken(
                issuer: "empresa",
                audience: "aplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
