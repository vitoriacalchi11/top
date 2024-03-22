using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public ReservaRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
        {
            _dbContext = bibliotecaApiDbContext;
        }

        public async Task<ReservaModel> BuscarPorId(int id)
        {
            return await _dbContext.Reservas
                .Include(y => y.Livro)
                .Include(z => z.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReservaModel>> BuscarTodasReservas()
        {
            return await _dbContext.Reservas
                .Include(y => y.Livro)
                .Include(z => z.Usuario)
                .ToListAsync();
        }
        public async Task<ReservaModel> Adicionar(ReservaModel reserva)
        {
            await _dbContext.Reservas.AddAsync(reserva);
            await _dbContext.SaveChangesAsync();

            return reserva;
        }

        public async Task<bool> Apagar(int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);
            if (reservaPorId == null)
            {
                throw new Exception($"Reserva do Id: {id} não foi encontrado.");
            }

            _dbContext.Reservas.Remove(reservaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ReservaModel> Atualizar(ReservaModel reserva, int id)
        {
            ReservaModel reservaPorId = await BuscarPorId(id);
            if (reservaPorId == null)
            {
                throw new Exception($"Reserva do Id: {id} não foi encontrado.");
            }

            reservaPorId.DataReserva = reservaPorId.DataReserva;
            reservaPorId.Status = reservaPorId.Status;
            reservaPorId.LivroId = reservaPorId.LivroId;
            reservaPorId.UsuarioId = reservaPorId.UsuarioId;


            _dbContext.Reservas.Update(reservaPorId);
            await _dbContext.SaveChangesAsync();
            return reservaPorId;
        }
    }
}
