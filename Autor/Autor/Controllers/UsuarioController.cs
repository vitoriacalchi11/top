using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autor.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {

            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuario()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int Id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(Id);
            return Ok(usuario);
        }

        [HttpPost]

        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(int Id, [FromBody] UsuarioModel usuarioModel)
        {
            usuarioModel.Id = Id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, Id);
            return Ok(usuario);
        }

        [HttpDelete]

        public async Task<ActionResult<UsuarioModel>> Apagar(int Id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(Id);
            return Ok(apagado);
        }
    }
}

