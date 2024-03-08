using ApiExercicio.Data;
using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiExercicio.Repositorios
{
    public class PedidosProdutosRepositorio: IPedidosProdutosRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public PedidosProdutosRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<PedidosProdutosModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidosProdutos
                .Include(x => x.Produtos)
                .Include(y => y.Categorias)
                .FirstOrDefaultAsync(z => z.Id == id);
        }
        public async Task<List<PedidosProdutosModel>> BuscarPedidosProdutos()
        {
            return await _dbContext.PedidosProdutos
                .Include(x => x.Produtos)
                .Include(y => y.Categorias)
                .ToListAsync();
        }
        public async Task<PedidosProdutosModel> Adicionar(PedidosProdutosModel pedidoProduto)
        {
            await _dbContext.PedidosProdutos.AddAsync(pedidoProduto);
            await _dbContext.SaveChangesAsync();

            return pedidoProduto;
        }

        public async Task<bool> Apagar(int Id)
        {
            PedidosProdutosModel pedidosProdutosPorId = await BuscarPorId(Id);

            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"Pedidoprodutos do ID: {Id} Não encontrado");
            }

            _dbContext.PedidosProdutos.Remove(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosProdutosModel> Atualizar(PedidosProdutosModel pedidoProduto, int Id)
        {
            PedidosProdutosModel pedidosProdutosPorId = await BuscarPorId(Id);

            if (pedidosProdutosPorId == null)
            {
                throw new Exception($"Pedidoprodutos id {Id} Não encontrado");
            }

            pedidosProdutosPorId.Quantidade = pedidoProduto.Quantidade;

            _dbContext.PedidosProdutos.Update(pedidosProdutosPorId);
            await _dbContext.SaveChangesAsync();
            return pedidosProdutosPorId;
        }
    }
}
