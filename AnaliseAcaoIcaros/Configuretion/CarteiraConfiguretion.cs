using AnaliseAcaoIcaros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaliseAcaoIcaros.Configuretion;

public class CarteiraConfiguretion : IEntityTypeConfiguration<Carteira>
{
    public void Configure(EntityTypeBuilder<Carteira> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
    }
}
