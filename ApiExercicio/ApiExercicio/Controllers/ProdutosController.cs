using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiExercicio.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosRepositorio _produtoRepositorio;

        public ProdutosController(IProdutosRepositorio produtosRepositorio)
        {
            _produtoRepositorio = produtosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutosModel>>> BuscarTodosProdutos()
        {
            List<ProdutosModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<ProdutosModel>> BuscarPorId(int Id)
        {
            ProdutosModel produtos = await _produtoRepositorio.BuscarPorId(Id);
            return Ok(produtos);
        }

        [HttpPost]

        public async Task<ActionResult<ProdutosModel>> Adicionar([FromBody] ProdutosModel produtosModel)
        {
            ProdutosModel produtos = await _produtoRepositorio.Adicionar(produtosModel);
            return Ok(produtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutosModel>> Atualizar(int id, [FromBody] ProdutosModel produtosModel)
        {
            produtosModel.Id = id;
            ProdutosModel produtos = await _produtoRepositorio.Atualizar(produtosModel, id);
            return Ok(produtos);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProdutosModel>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
