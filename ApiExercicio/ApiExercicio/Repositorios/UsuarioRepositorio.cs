using ApiExercicio.Data;
using ApiExercicio.Models;
using ApiExercicio.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiExercicio.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDbContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDbContext sistemaTarefasDbContext)
        {
            _dbContext = sistemaTarefasDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int Id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adcionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario id {Id} Não encontrado");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int Id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(Id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario id {Id} Não encontrado");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }

        
    }
}
