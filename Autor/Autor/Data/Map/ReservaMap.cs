using Autor.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Autor.Data.Map
{
    public class ReservaMap : IEntityTypeConfiguration<ReservaModel>
    {
        public void Configure(EntityTypeBuilder<ReservaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.LivroId).IsRequired();
            builder.HasOne(x => x.Livro);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.HasOne(x => x.Usuario);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.DataReserva).IsRequired().HasColumnType("date");
        }
    }
}
