using Autor.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Autor.Data.Map
{
    public class AvaliacaoMap : IEntityTypeConfiguration<AvaliacaoModel>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LivroId).IsRequired();
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.Pontuacao).IsRequired();
            builder.Property(x => x.Comentario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataAvaliacao).IsRequired().HasColumnType("date");
        }
    }
}
