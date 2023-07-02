using AnaliseAcaoIcaros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnaliseAcaoIcaros.Configuretion;

public class PapelCofiguration : IEntityTypeConfiguration<Papel>
{
    public void Configure(EntityTypeBuilder<Papel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.Operacao).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Titulo).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Setor).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Classe).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Qtd).IsRequired();
        builder.Property(x => x.Taxa).HasPrecision(10, 2).IsRequired();
        builder.Property(x => x.Valor).HasPrecision(10, 2).IsRequired();
        builder.HasOne(x => x.Carteira).WithMany(x => x.Papels).HasForeignKey(x => x.IdCarteira);
        builder.Property(x => x.IdCarteira).IsRequired();
    }
}
