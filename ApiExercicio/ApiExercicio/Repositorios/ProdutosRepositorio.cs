using ApiExercicio.Data;
using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiExercicio.Repositorios
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public ProdutosRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<ProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutosModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<ProdutosModel> Adicionar(ProdutosModel produtos)
        {
            await _dbContext.Produtos.AddAsync(produtos);
            await _dbContext.SaveChangesAsync();

            return produtos;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutosModel produtosPorId = await BuscarPorId(id);

            if (produtosPorId == null)
            {
                throw new Exception($"Usuario id {id} Não encontrado");
            }

            _dbContext.Produtos.Remove(produtosPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProdutosModel> Atualizar(ProdutosModel produtos, int Id)
        {
            ProdutosModel produtosPorId = await BuscarPorId(Id);

            if (produtosPorId == null)
            {
                throw new Exception($"Usuario id {Id} Não encontrado");
            }

            produtosPorId.Nome = produtos.Nome;
            produtosPorId.Descricao = produtos.Descricao;
            produtosPorId.Preco = produtos.Preco;

            _dbContext.Produtos.Update(produtosPorId);
            await _dbContext.SaveChangesAsync();
            return produtosPorId;
        }


    }
}
    

