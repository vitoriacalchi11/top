using ApiExercicio.Models;

namespace ApiExercicio.Repositorios.Interfaces
{
    public interface IPedidosProdutosRepositorio
    {
        Task<List<PedidosProdutosModel>> BuscarPedidosProdutos();

        Task<PedidosProdutosModel> BuscarPorId(int Id);

        Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidoProdutos);

        Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidoProdutos, int Id);
        Task<bool> Apagar(int Id);
    }
}
