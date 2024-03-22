using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {

        private readonly SistemaTarefasDbContext _dbContext;

        public LivroRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
        {
            _dbContext = bibliotecaApiDbContext;
        }

        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livros.ToListAsync();
        }
        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();

            return livro;
        }

        public async Task<bool> Apagar(int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro de Id: {id} não foi encontrado.");
            }

            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if (livroPorId == null)
            {
                throw new Exception($"Livro de Id: {id} não foi encontrado.");
            }

            livroPorId.Titulo = livroPorId.Titulo;
            livroPorId.Genero = livroPorId.Genero;
            livroPorId.ISBN = livroPorId.ISBN;
            livroPorId.AnoPublicacao = livroPorId.AnoPublicacao;
            livroPorId.Sinopse = livroPorId.Sinopse;

            _dbContext.Livros.Update(livroPorId);
            await _dbContext.SaveChangesAsync();
            return livroPorId;
        }
    }
}
