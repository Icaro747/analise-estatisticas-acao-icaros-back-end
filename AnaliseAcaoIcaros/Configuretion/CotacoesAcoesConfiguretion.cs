using AnaliseAcaoIcaros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaliseAcaoIcaros.Configuretion;

public class CotacoesAcoesConfiguretion : IEntityTypeConfiguration<CotacoesAcoes>
{
    public void Configure(EntityTypeBuilder<CotacoesAcoes> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Acao).HasMaxLength(6).IsRequired();
        builder.Property(x => x.DataObtida).IsRequired();
        builder.Property(x => x.ValorAtual).HasPrecision(10, 2).IsRequired();
    }
}
