using ApiExercicio.Models;

namespace ApiExercicio.Repositorios.Interfaces
{
    public interface IPedidosRepositorio
    {
        Task<List<PedidosModel>> BuscarTodosPedidos();

        Task<PedidosModel> BuscarPorId(int Id);

        Task<PedidosModel> Adicionar(PedidosModel pedido);

        Task<PedidosModel> Atualizar(PedidosModel pedido, int Id);
        Task<bool> Apagar(int Id);
    }
}
