using ApiExercicio.Data;
using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiExercicio.Repositorios
{
    public class CategoriasRepositorio : ICategoriasRepositorio
    {

        private readonly SistemaTarefasDbContext _dbContext;

        public CategoriasRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<CategoriasModel> BuscarPorId(int Id)
        {
            return await _dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<CategoriasModel>> BuscarTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }
        public async Task<CategoriasModel> Adicionar(CategoriasModel categorias)
        {
            await _dbContext.Categorias.AddAsync(categorias);
            await _dbContext.SaveChangesAsync();

            return categorias;
        }

        public async Task<bool> Apagar(int Id)
        {
            CategoriasModel categoriasPorId = await BuscarPorId(Id);

            if (categoriasPorId == null)
            {
                throw new Exception($"Pedido do ID: {Id} Não encontrado");
            }

            _dbContext.Categorias.Remove(categoriasPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CategoriasModel> Atualizar(CategoriasModel categorias, int Id)
        {
            CategoriasModel categoriasPorId = await BuscarPorId(Id);

            if (categoriasPorId == null)
            {
                throw new Exception($"pedidos id {Id} Não encontrado");
            }

            categoriasPorId.Nome = categorias.Nome;
            categoriasPorId.Status = categorias.Status;

            _dbContext.Categorias.Update(categoriasPorId);
            await _dbContext.SaveChangesAsync();
            return categoriasPorId;
        }

    }
}
