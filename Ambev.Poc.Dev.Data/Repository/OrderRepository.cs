using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;
using System.Data.SqlClient;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppSettings appSettings) : base(appSettings)
        {

        }

        public async Task<int> CreateProduct(OrderProductEntity entity)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            int idInsert = 0;
            try
            {
                var sql = "INSERT INTO OrderProduct(Guid, ProductId, CustomerId, TotalOrder, Amount)  output INSERTED.ID VALUES(@Guid, @ProductId, @CustomerId, @TotalOrder, @Amount);SELECT SCOPE_IDENTITY();";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@Guid", entity.Guid);
                    cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);
                    cmd.Parameters.AddWithValue("@CustomerId", entity.CustomerId);
                    cmd.Parameters.AddWithValue("@TotalOrder", entity.TotalOrder);
                    cmd.Parameters.AddWithValue("@Amount", entity.Amount);

                    //idInsert = Convert.ToInt32(cmd.ExecuteScalar());

                    idInsert = await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();
                return idInsert;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error create product {ex.Message}");
            }
        }
    }
}
