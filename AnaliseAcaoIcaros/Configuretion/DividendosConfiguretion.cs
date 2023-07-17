using AnaliseAcaoIcaros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaliseAcaoIcaros.Configuretion;

public class DividendosConfiguretion : IEntityTypeConfiguration<Dividendos>
{
    public void Configure(EntityTypeBuilder<Dividendos> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.Valor).HasPrecision(10, 2).IsRequired();
        builder.HasOne(x => x.Papel).WithMany(x => x.Dividendos).HasForeignKey(x => x.IdPapel);
        builder.Property(x => x.IdPapel).IsRequired();
    }
}
