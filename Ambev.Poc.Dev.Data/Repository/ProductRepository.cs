using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;
using Ambev.Poc.Dev.Domain.Models.Product.Response;
using Dapper;
using System.Data.SqlClient;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppSettings appSettings) : base(appSettings)
        {

        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProducts()
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = "Select * From Product Where IsActive = @IsActive";
                var productEntity = await connection.QueryAsync<ProductResponseModel>(sql, new { IsActive = true });

                return productEntity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get product {ex.Message}");
            }
        }

        public async Task<ProductEntity> GetProducById(int productId)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = "Select * From Product Where Id = @ProductId AND IsActive = @IsActive";
                var productEntity = await connection.QueryAsync<ProductEntity>(sql, new { ProductId = productId, IsActive = true });

                return productEntity.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get product {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetProductBySku(string sku)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = "Select * From Product Where Sku = @Sku AND IsActive = @IsActive";
                var resultQuery = await connection.QueryAsync<ProductEntity>(sql, new { Sku = sku, IsActive = true });

                return resultQuery;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get product {ex.Message}");
            }
        }

        public async Task<int> CreateProduct(ProductEntity entity)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            var idInsert = 0;
            try
            {
                var sql = "INSERT INTO Product(Guid, Name, Sku, Price, Category, IsActive) VALUES(@Guid, @Name, @Sku, @Price, @Category, @IsActive);SELECT SCOPE_IDENTITY();";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@Guid", entity.Guid);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Sku", entity.Sku);
                    cmd.Parameters.AddWithValue("@Price", entity.Price);
                    cmd.Parameters.AddWithValue("@Category", entity.Category);
                    cmd.Parameters.AddWithValue("@IsActive", true);

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

        public async Task<ProductEntity> UpdateProduct(ProductEntity productEntity)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = "UPDATE Product SET Name = @Name, Sku = @Sku, Price = @Price, Category = @Category  WHERE Id = @ProductId";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productEntity.Id);
                    cmd.Parameters.AddWithValue("@Name", productEntity.Name);
                    cmd.Parameters.AddWithValue("@Sku", productEntity.Sku);
                    cmd.Parameters.AddWithValue("@Price", productEntity.Price);
                    cmd.Parameters.AddWithValue("@Category", productEntity.Category);

                    await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();

                var resultEntityUpdated = await GetProducById(productEntity.Id);
                return resultEntityUpdated;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error delete product {ex.Message}");
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = "UPDATE Product SET IsActive = @IsActive WHERE Id = @ProductId";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@IsActive", false);
                    await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error delete product {ex.Message}");
            }
        }
    }
}
