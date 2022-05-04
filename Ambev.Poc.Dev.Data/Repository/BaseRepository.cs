using Ambev.Poc.Dev.Domain.Models.AppSettings;
using System.Data.SqlClient;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class BaseRepository
    {
        protected readonly AppSettings _appSettings;
        public BaseRepository(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        protected SqlConnection GetSqlConnection()
           => new SqlConnection(string.Format(_appSettings.ConnectionStrings.DefautConnection));
    }
}
