namespace AnaliseAcaoIcaros.Models.MainClass
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
