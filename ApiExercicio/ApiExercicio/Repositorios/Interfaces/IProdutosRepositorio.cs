using ApiExercicio.Models;

namespace ApiExercicio.Repositorios.Interfaces
{

    public interface IProdutosRepositorio
    {
        Task<List<ProdutosModel>> BuscarTodosProdutos();

        Task<ProdutosModel> BuscarPorId(int Id);

        Task<ProdutosModel> Adicionar(ProdutosModel produtos);

        Task<ProdutosModel> Atualizar(ProdutosModel produtos, int Id);
        Task<bool> Apagar(int Id);
    }

}
