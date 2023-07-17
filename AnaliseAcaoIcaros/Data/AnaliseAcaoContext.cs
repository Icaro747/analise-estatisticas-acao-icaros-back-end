using AnaliseAcaoIcaros.Configuretion;
using AnaliseAcaoIcaros.Models;
using Microsoft.EntityFrameworkCore;

namespace AnaliseAcaoIcaros.Data;

public class AnaliseAcaoContext : DbContext
{
    public AnaliseAcaoContext(DbContextOptions<AnaliseAcaoContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PapelConfiguretion());
        modelBuilder.ApplyConfiguration(new CarteiraConfiguretion());
        modelBuilder.ApplyConfiguration(new DividendosConfiguretion());
        modelBuilder.ApplyConfiguration(new MovimentacaoConfiguretion());
        modelBuilder.ApplyConfiguration(new CotacoesAcoesConfiguretion());
    }

    public DbSet<Papel> Papels { get; set; }
    public DbSet<Carteira> Carteiras { get; set; }
    public DbSet<Dividendos> Dividendos { get; set; }
    public DbSet<Movimentacao> Movimentacao { get; set; }
    public DbSet<CotacoesAcoes> CotacoesAcoes { get; set; }
}
