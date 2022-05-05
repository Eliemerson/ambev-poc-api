using Ambev.Poc.Dev.Domain.Models.AppSettings;
using System.Data.SqlClient;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class BaseRepository
    {
        protected readonly AppSettings _appSettings;
        protected readonly string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AmbevPoc;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public BaseRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        protected SqlConnection GetSqlConnection()
           => new SqlConnection(connection);
    }
}
