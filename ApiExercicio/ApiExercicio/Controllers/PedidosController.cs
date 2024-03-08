using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiExercicio.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepositorio _pedidosRepositorio;

        public PedidosController(IPedidosRepositorio pedidosRepositorio)
        {

            _pedidosRepositorio = pedidosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidosModel>>> BuscarTodosPedidos()
        {
            List<PedidosModel> pedidos = await _pedidosRepositorio.BuscarTodosPedidos();
            return Ok(pedidos);
        }
        [HttpGet("{Id}")]

        public async Task<ActionResult<PedidosModel>> BuscarPorId(int Id)
        {
            PedidosModel pedidos = await _pedidosRepositorio.BuscarPorId(Id);
            return Ok(pedidos);
        }

        [HttpPost]

        public async Task<ActionResult<PedidosModel>> Adicionar([FromBody] PedidosModel pedido)
        {
            PedidosModel pedidos = await _pedidosRepositorio.Adicionar(pedido);
            return Ok(pedidos);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<PedidosModel>> Atualizar(int Id, [FromBody] PedidosModel pedidosModel)
        {
            pedidosModel.Id = Id;
            PedidosModel pedidos = await _pedidosRepositorio.Atualizar(pedidosModel, Id);
            return Ok(pedidos);
        }

        [HttpDelete]

        public async Task<ActionResult<PedidosModel>> Apagar(int Id)
        {
            bool apagado = await _pedidosRepositorio.Apagar(Id);
            return Ok(apagado);
        }
    }

}
