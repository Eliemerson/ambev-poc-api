using Ambev.Poc.Dev.Domain.Entities;
using Ambev.Poc.Dev.Domain.Interfaces.Repository;
using Ambev.Poc.Dev.Domain.Models.AppSettings;
using Ambev.Poc.Dev.Domain.Models.Customer.Response;
using Dapper;
using System.Data.SqlClient;

namespace Ambev.Poc.Dev.Data.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppSettings appSettings) : base(appSettings)
        {

        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomers()
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = "Select * From Customer Where IsActive = @IsActive";
                var customerEntyty = await connection.QueryAsync<CustomerResponseModel>(sql, new { IsActive = true });

                return customerEntyty;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get costomer {ex.Message}");
            }
        }

        public async Task<CustomerEntity> GetCustomerById(int customerId)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = "Select * From Customer Where Id = @CustomerId AND IsActive = @IsActive";
                var customerEntyty = await connection.QueryAsync<CustomerEntity>(sql, new { CustomerId = customerId, IsActive = true });

                return customerEntyty.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get costomer {ex.Message}");
            }
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomerSameEmail(string email)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            try
            {
                var sql = "Select * From Customer Where Email = @Email AND IsActive = @IsActive";
                var resultQuery = await connection.QueryAsync<CustomerEntity>(sql, new { Email = email, IsActive = true });

                return resultQuery;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error get costomer {ex.Message}");
            }
        }

        public async Task<int> CreateCostomer(CustomerEntity entity)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            var idInsert = 0;
            try
            {
                var sql = "INSERT INTO Customer(Guid, Name, LastName, Email, IsActive) VALUES(@Guid, @Name, @LastName, @Email, @IsActive)";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@Guid", entity.Guid);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@LastName", entity.LastName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@IsActive", true);

                    idInsert = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }

                transaction.Commit();
                return idInsert;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error create costomer {ex.Message}");
            }
        }
        public async Task<CustomerEntity> UpdateCustomer(CustomerEntity customerEntity)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = "UPDATE Customer SET Name = @Name, LastName = @LastName WHERE Id = @CustomerId";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerEntity.Id);
                    cmd.Parameters.AddWithValue("@Name", customerEntity.Name);
                    cmd.Parameters.AddWithValue("@LastName", customerEntity.LastName);
                    await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();

                var resultEntityUpdated = await GetCustomerById(customerEntity.Id);
                return resultEntityUpdated;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error delete costomer {ex.Message}");
            }
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            using var connection = GetSqlConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var sql = "UPDATE Customer SET IsActive = @IsActive WHERE Id = @CustomerId";
                using (var cmd = new SqlCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@IsActive", false);
                    await cmd.ExecuteNonQueryAsync();
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error delete costomer {ex.Message}");
            }
        }
    }
}
