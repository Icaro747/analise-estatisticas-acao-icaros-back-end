using AnaliseAcaoIcaros.Models.MainClass;

namespace AnaliseAcaoIcaros.Models
{
    public class Dividendos : Entity, IEntity
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public Guid IdPapel { get; set; }
        public virtual Papel Papel { get; set; }
    }
}
