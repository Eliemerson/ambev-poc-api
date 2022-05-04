namespace Ambev.Poc.Dev.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; protected set; }
        protected EntityBase() => Guid = Guid.NewGuid();
        public Guid Guid { get; protected set; }
    }
}
