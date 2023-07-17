using AnaliseAcaoIcaros.Models.MainClass;

namespace AnaliseAcaoIcaros.Models;

public class CotacoesAcoes : Entity, IEntity
{
    public string Acao { get; set; }
    public decimal ValorAtual { get; set; }
    public DateTime DataObtida { get; set; }
}
