using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiExercicio.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidosProdutosRepositorio _pedidosProdutosRepositorio;

        public PedidosProdutosController(IPedidosProdutosRepositorio pedidosProdutosRepositorio)
        {

            _pedidosProdutosRepositorio = pedidosProdutosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosProdutosModel>>> BuscarPedidosProdutos()
        {
            List<PedidosProdutosModel> pedidosProdutos = await _pedidosProdutosRepositorio.BuscarPedidosProdutos();
            return Ok(pedidosProdutos);
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<PedidosProdutosModel>> BuscarPorId(int Id)
        {
            PedidosProdutosModel pedidosProdutos = await _pedidosProdutosRepositorio.BuscarPorId(Id);
            return Ok(pedidosProdutos);
        }

        [HttpPost]

        public async Task<ActionResult<PedidosProdutosModel>> Adicionar([FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            PedidosProdutosModel pedidosProdutos = await _pedidosProdutosRepositorio.Adicionar(pedidosProdutosModel);
            return Ok(pedidosProdutos);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<PedidosProdutosModel>> Atualizar(int Id, [FromBody] PedidosProdutosModel pedidosProdutosModel)
        {
            pedidosProdutosModel.Id = Id;
            PedidosProdutosModel pedidosProdutos = await _pedidosProdutosRepositorio.Atualizar(pedidosProdutosModel, Id);
            return Ok(pedidosProdutos);
        }

        [HttpDelete]

        public async Task<ActionResult<PedidosProdutosModel>> Apagar(int Id)
        {
            bool apagado = await _pedidosProdutosRepositorio.Apagar(Id);
            return Ok(apagado);
        }
    }
}

