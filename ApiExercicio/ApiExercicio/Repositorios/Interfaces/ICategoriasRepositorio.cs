using ApiExercicio.Models;

namespace ApiExercicio.Repositorios.Interfaces
{
    public interface ICategoriasRepositorio
    {
        Task<List<CategoriasModel>> BuscarTodasCategorias();

        Task<CategoriasModel> BuscarPorId(int Id);

        Task<CategoriasModel> Adicionar(CategoriasModel categorias);

        Task<CategoriasModel> Atualizar(CategoriasModel categorias, int Id);
        Task<bool> Apagar(int Id);
    }
}
