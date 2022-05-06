using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;
using Ambev.Poc.Dev.Domain.Models.OrderProduct.Response;
using Dapper;
using System.Data.SqlClient;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(AppSettings appSettings) : base(appSettings)
        {

        }


        public async Task<IEnumerable<OrderProductResponse>> GetAllOrders()
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = @"SELECT OP.Id, OP.ProductId, 
                                 OP.CustomerId, 
	                             OP.TotalOrder, 
	                             OP.Amount,
	                             P.Name AS ProductName, 
	                             CONCAT(C.Name, ' ', C.LastName) AS CustomerName
                            FROM OrderProduct OP
                            INNER JOIN Product P ON P.Id = OP.ProductId
                            INNER JOIN Customer C ON C.Id = OP.CustomerId
                            ORDER BY OP.Id DESC";

                var orderModelResponse = await connection.QueryAsync<OrderProductResponse>(sql);

                return orderModelResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get order {ex.Message}");
            }
        }

        public async Task<OrderProductResponse> GetOrderById(int orderId)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = @"SELECT OP.Id, OP.ProductId, 
                                 OP.CustomerId, 
	                             OP.TotalOrder, 
	                             OP.Amount,
	                             P.Name AS ProductName, 
	                             CONCAT(C.Name, ' ', C.LastName) AS CustomerName
                            FROM OrderProduct OP
                            INNER JOIN Product P ON P.Id = OP.ProductId
                            INNER JOIN Customer C ON C.Id = OP.ProductId
                            WHERE OP.Id = @OrderId";
                var orderModelResponse = await connection.QueryAsync<OrderProductResponse>(sql, new { OrderId = orderId });

                return orderModelResponse.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get order {ex.Message}");
            }
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

                    idInsert = Convert.ToInt32(await cmd.ExecuteScalarAsync());
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
