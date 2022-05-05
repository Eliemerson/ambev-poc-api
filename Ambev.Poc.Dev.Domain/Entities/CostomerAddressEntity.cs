namespace Ambev.Poc.Dev.Domain.Entities
{
    public class CostomerAddressEntity : EntityBase
    {
        public int CostomerId { get; set; }
        public string Adress { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string Complement { get; set; }
        public bool IsMain { get; set; }
    }
}
