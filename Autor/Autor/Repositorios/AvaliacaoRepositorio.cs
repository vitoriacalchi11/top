using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public AvaliacaoRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
        {
            _dbContext = bibliotecaApiDbContext;
        }

        public async Task<AvaliacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Avaliacoes
                .Include(y => y.Livro)
                .Include(z => z.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AvaliacaoModel>> BuscarTodasAvaliacoes()
        {
            return await _dbContext.Avaliacoes
                .Include(y => y.Livro)
                .Include(z => z.Usuario)
                .ToListAsync();
        }
        public async Task<AvaliacaoModel> Adicionar(AvaliacaoModel avaliacao)
        {
            await _dbContext.Avaliacoes.AddAsync(avaliacao);
            await _dbContext.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<bool> Apagar(int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);
            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliação do Id: {id} não foi encontrado.");
            }

            _dbContext.Avaliacoes.Remove(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<AvaliacaoModel> Atualizar(AvaliacaoModel avaliacao, int id)
        {
            AvaliacaoModel avaliacaoPorId = await BuscarPorId(id);
            if (avaliacaoPorId == null)
            {
                throw new Exception($"Avaliação do Id: {id} não foi encontrado.");
            }

            avaliacaoPorId.Pontuacao = avaliacaoPorId.Pontuacao;
            avaliacaoPorId.Comentario = avaliacaoPorId.Comentario;
            avaliacaoPorId.DataAvaliacao = avaliacaoPorId.DataAvaliacao;
            avaliacaoPorId.LivroId = avaliacaoPorId.LivroId;
            avaliacaoPorId.UsuarioId = avaliacaoPorId.UsuarioId;

            _dbContext.Avaliacoes.Update(avaliacaoPorId);
            await _dbContext.SaveChangesAsync();
            return avaliacaoPorId;
        }
    }
}
