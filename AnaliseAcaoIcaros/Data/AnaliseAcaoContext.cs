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
        modelBuilder.ApplyConfiguration(new PapelCofiguration());
        modelBuilder.ApplyConfiguration(new CarteiraCofiguration());
        modelBuilder.ApplyConfiguration(new DividendosCofiguration());
    }

    public DbSet<Papel> Papels { get; set; }
    public DbSet<Carteira> Carteiras { get; set; }
    public DbSet<Dividendos> Dividendos { get; set; }
}
