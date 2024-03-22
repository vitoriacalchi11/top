using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
   
        public class AutorRepositorio : IAutorRepositorio
        {
            private readonly SistemaTarefasDbContext _dbContext;

            public AutorRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
            {
                _dbContext = bibliotecaApiDbContext;
            }

            public async Task<AutorModel> BuscarPorId(int id)
            {
                return await _dbContext.Autores.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<List<AutorModel>> BuscarTodosAutores()
            {
                return await _dbContext.Autores.ToListAsync();
            }
            public async Task<AutorModel> Adicionar(AutorModel autor)
            {
                await _dbContext.Autores.AddAsync(autor);
                await _dbContext.SaveChangesAsync();

                return autor;
            }

            public async Task<bool> Apagar(int id)
            {
                AutorModel autorPorId = await BuscarPorId(id);
                if (autorPorId == null)
                {
                    throw new Exception($"Autor de Id: {id} não foi encontrado.");
                }

                _dbContext.Autores.Remove(autorPorId);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            public async Task<AutorModel> Atualizar(AutorModel autor, int id)
            {
                AutorModel autorPorId = await BuscarPorId(id);
                if (autorPorId == null)
                {
                    throw new Exception($"Autor de Id: {id} não foi encontrado.");
                }

                autorPorId.Nome = autorPorId.Nome;
                autorPorId.Nacionalidade = autorPorId.Nacionalidade;
                autorPorId.DataNascimento = autorPorId.DataNascimento;

                _dbContext.Autores.Update(autorPorId);
                await _dbContext.SaveChangesAsync();
                return autorPorId;
            }
        }
    }

