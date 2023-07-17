using AnaliseAcaoIcaros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaliseAcaoIcaros.Configuretion;

public class MovimentacaoConfiguretion : IEntityTypeConfiguration<Movimentacao>
{
    public void Configure(EntityTypeBuilder<Movimentacao> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.Operacao).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Qtd).IsRequired();
        builder.Property(x => x.Taxa).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.Valor).HasPrecision(10, 2).IsRequired();
        builder.HasOne(x => x.Papel).WithMany(x => x.movimentacoes).HasForeignKey(x => x.IdPapel);
        builder.Property(x => x.IdPapel).IsRequired();
    }
}
