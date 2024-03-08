using ApiExercicio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiExercicio.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProdutoId);
            builder.HasOne(x => x.Produtos);
            builder.Property(x => x.CategoriaId);
            builder.HasOne(x => x.Categorias);
        }
    }
}
