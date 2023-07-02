using AnaliseAcaoIcaros.Models.MainClass;
using System.Security.Principal;

namespace AnaliseAcaoIcaros.Models;

public class Papel : Entity, IEntity
{
    public DateTime Data { get; set; }
    public string Operacao { get; set; }
    public string Titulo { get; set; }
    public string Setor { get; set; }
    public string Classe { get; set; }
    public int Qtd { get; set; }
    public decimal Valor { get; set; }
    public decimal Taxa { get; set; }

    public Guid IdCarteira { get; set; }
    public virtual Carteira Carteira { get; set; }
    public virtual ICollection<Dividendos> Dividendos { get; set;}

}
