using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiExercicio.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;

        public CategoriasController(ICategoriasRepositorio categoriasRepositorio)
        {

            _categoriasRepositorio = categoriasRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriasModel>>> BuscarTodosUsuario()
        {
            List<CategoriasModel> categorias = await _categoriasRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<CategoriasModel>> BuscarPorId(int Id)
        {
            CategoriasModel categorias = await _categoriasRepositorio.BuscarPorId(Id);
            return Ok(categorias);
        }

        [HttpPost]

        public async Task<ActionResult<CategoriasModel>> Adicionar([FromBody] CategoriasModel usuarioModel)
        {
            CategoriasModel categorias = await _categoriasRepositorio.Adicionar(usuarioModel);
            return Ok(categorias);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<CategoriasModel>> Atualizar(int Id, [FromBody] CategoriasModel usuarioModel)
        {
            usuarioModel.Id = Id;
            CategoriasModel categorias = await _categoriasRepositorio.Atualizar(usuarioModel, Id);
            return Ok(categorias);
        }

        [HttpDelete]

        public async Task<ActionResult<CategoriasModel>> Apagar(int Id)
        {
            bool apagado = await _categoriasRepositorio.Apagar(Id);
            return Ok(apagado);
        }
    }
}
