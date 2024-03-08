using ApiExercicio.Data.Map;
using ApiExercicio.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExercicio.Data
{
    public class SistemaTarefasDbContext : DbContext
    {
        public SistemaTarefasDbContext(DbContextOptions<SistemaTarefasDbContext> options) : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<CategoriasModel> Categorias { get; set; }
        public DbSet<ProdutosModel> Produtos { get; set; }
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new CategoriasMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
