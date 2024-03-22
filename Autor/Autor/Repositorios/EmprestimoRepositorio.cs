using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public EmprestimoRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
        {
            _dbContext = bibliotecaApiDbContext;
        }

        public async Task<EmprestimoModel> BuscarPorId(int id)
        {
            return await _dbContext.Emprestimos
                .Include(y => y.Livro)
                .Include(z => z.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EmprestimoModel>> BuscarTodosEmprestimos()
        {
            return await _dbContext.Emprestimos
                .Include(y => y.Livro)
                .Include(z => z.Usuario)
                .ToListAsync();
        }
        public async Task<EmprestimoModel> Adicionar(EmprestimoModel emprestimo)
        {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();

            return emprestimo;
        }

        public async Task<bool> Apagar(int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);
            if (emprestimoPorId == null)
            {
                throw new Exception($"Empréstimo do Id: {id} não foi encontrado.");
            }

            _dbContext.Emprestimos.Remove(emprestimoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<EmprestimoModel> Atualizar(EmprestimoModel emprestimo, int id)
        {
            EmprestimoModel emprestimoPorId = await BuscarPorId(id);
            if (emprestimoPorId == null)
            {
                throw new Exception($"Empréstimo do Id: {id} não foi encontrado.");
            }

            emprestimoPorId.DataEmprestimo = emprestimoPorId.DataEmprestimo;
            emprestimoPorId.DataDevolucao = emprestimoPorId.DataDevolucao;
            emprestimoPorId.Status = emprestimoPorId.Status;
            emprestimoPorId.LivroId = emprestimoPorId.LivroId;
            emprestimoPorId.UsuarioId = emprestimoPorId.UsuarioId;

            _dbContext.Emprestimos.Update(emprestimoPorId);
            await _dbContext.SaveChangesAsync();
            return emprestimoPorId;
        }
    }
}
