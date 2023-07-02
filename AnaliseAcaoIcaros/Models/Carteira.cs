using AnaliseAcaoIcaros.Models.MainClass;

namespace AnaliseAcaoIcaros.Models;

public class Carteira : Entity, IEntity
{
    public string Nome { get; set; }

    public virtual ICollection<Papel> Papels { get; set; }
}
