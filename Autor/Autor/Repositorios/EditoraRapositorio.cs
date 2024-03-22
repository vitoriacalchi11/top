using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
    public class EditoraRepositorio : IEditoraRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public EditoraRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
        {
            _dbContext = bibliotecaApiDbContext;
        }

        public async Task<EditoraModel> BuscarPorId(int id)
        {
            return await _dbContext.Editoras.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EditoraModel>> BuscarTodasEditoras()
        {
            return await _dbContext.Editoras.ToListAsync();
        }
        public async Task<EditoraModel> Adicionar(EditoraModel editora)
        {
            await _dbContext.Editoras.AddAsync(editora);
            await _dbContext.SaveChangesAsync();

            return editora;
        }

        public async Task<bool> Apagar(int id)
        {
            EditoraModel editoraPorId = await BuscarPorId(id);
            if (editoraPorId == null)
            {
                throw new Exception($"Editora de Id: {id} não foi encontrado.");
            }

            _dbContext.Editoras.Remove(editoraPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<EditoraModel> Atualizar(EditoraModel editora, int id)
        {
            EditoraModel editoraPorid = await BuscarPorId(id);
            if (editoraPorid == null)
            {
                throw new Exception($"Editora de Id: {id} não foi encontrado.");
            }

            editoraPorid.Nome = editoraPorid.Nome;
            editoraPorid.Localizacao = editoraPorid.Localizacao;
            editoraPorid.AnoFundacao = editoraPorid.AnoFundacao;
            

            _dbContext.Editoras.Update(editoraPorid);
            await _dbContext.SaveChangesAsync();
            return editoraPorid;
        }
    }
}
