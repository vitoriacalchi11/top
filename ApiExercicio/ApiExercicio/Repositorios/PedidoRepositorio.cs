using ApiExercicio.Data;
using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiExercicio.Repositorios
{
    public class PedidoRepositorio : IPedidosRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public PedidoRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<PedidosModel> BuscarPorId(int Id)
        {
            return await _dbContext.Pedidos
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<PedidosModel>> BuscarTodosPedidos()
        {
            return await _dbContext.Pedidos
                .Include(x => x.Usuario)
                .ToListAsync();
        }
        public async Task<PedidosModel> Adicionar(PedidosModel pedido)
        {
            await _dbContext.Pedidos.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            return pedido;
        }

        public async Task<bool> Apagar(int Id)
        {
            PedidosModel pedidosPorId = await BuscarPorId(Id);

            if (pedidosPorId == null)
            {
                throw new Exception($"Pedido do ID: {Id} Não encontrado");
            }

            _dbContext.Pedidos.Remove(pedidosPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PedidosModel> Atualizar(PedidosModel pedidos, int Id)
        {
            PedidosModel pedidosPorId = await BuscarPorId(Id);

            if (pedidosPorId == null)
            {
                throw new Exception($"pedidos id {Id} Não encontrado");
            }

            pedidosPorId.EnderecoEntrega = pedidos.EnderecoEntrega;

            _dbContext.Pedidos.Update(pedidosPorId);
            await _dbContext.SaveChangesAsync();
            return pedidosPorId;
        }
    }
}
