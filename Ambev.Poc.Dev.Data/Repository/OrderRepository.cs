using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppSettings appSettings) : base(appSettings)
        {

        }
    }
}
