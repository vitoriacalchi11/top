using ApiExercicio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiExercicio.Data.Map
{
    public class ProdutosMap : IEntityTypeConfiguration<ProdutosModel>
    {
        public void Configure(EntityTypeBuilder<ProdutosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Preco).IsRequired();
        }
    }
}
