using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppSettings appSettings) : base(appSettings)
        {

        }
    }
}
