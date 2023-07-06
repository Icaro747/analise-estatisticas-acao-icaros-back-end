using AnaliseAcaoIcaros.Models.MainClass;

namespace AnaliseAcaoIcaros.Models;

public class Movimentacao : Entity, IEntity
{
    public DateTime Data { get; set; }
    public string Operacao { get; set; }
    public int Qtd { get; set; }
    public decimal Valor { get; set; }
    public decimal Taxa { get; set; }

    public Guid IdPapel { get; set; }
    public virtual Papel Papel { get; set; }
}
