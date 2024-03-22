using Autor.Data;
using Autor.Models;
using Autor.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autor.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDbContext bibliotecaApiDbContext)
        {
            _dbContext = bibliotecaApiDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();

        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o Id: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Email = usuario.Email;
            // Verifica se uma nova senha foi fornecida 
            if (!string.IsNullOrEmpty(usuario.Senha))
            {
                usuarioPorId.Senha = usuario.Senha;
            }

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o Id: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public Task<UsuarioModel> Adcionar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
