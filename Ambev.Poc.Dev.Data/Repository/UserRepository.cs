using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppSettings appSettings) : base(appSettings)
        {

        }
    }
}
