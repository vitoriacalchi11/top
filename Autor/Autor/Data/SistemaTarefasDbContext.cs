using Autor.Data.Map;
using Autor.Models;
using Microsoft.EntityFrameworkCore;

namespace Autor.Data
{
    public class SistemaTarefasDbContext : DbContext
    {
        public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<EditoraModel> Editoras { get; set; }
        public DbSet<EmprestimoModel> Emprestimos { get; set; }
        public DbSet<ReservaModel> Reservas { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        public DbSet<LoginModel> Login { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
