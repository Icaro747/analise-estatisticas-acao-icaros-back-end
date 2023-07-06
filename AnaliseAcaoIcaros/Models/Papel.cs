using AnaliseAcaoIcaros.Models.MainClass;
using System.Security.Principal;

namespace AnaliseAcaoIcaros.Models;

public class Papel : Entity, IEntity
{
    public string Titulo { get; set; }
    public string Setor { get; set; }
    public string Classe { get; set; }

    public Guid IdCarteira { get; set; }
    public virtual Carteira Carteira { get; set; }
    public virtual ICollection<Dividendos> Dividendos { get; set;}
    public virtual ICollection<Movimentacao> movimentacoes { get; set; }
}
