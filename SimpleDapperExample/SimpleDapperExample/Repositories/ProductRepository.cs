using Dapper;
using SimpleDapperExample.Entities;
using System.Data.SqlClient;

namespace SimpleDapperExample.Repositories
{
    public class ProductRepository : IProductRepository
    {
        string conStr = "Data Source = .; Initial Catalog = DapperDb; Integrated Security = SSPI; TrustServerCertificate = True";
        public void Delete(int id)
        {
            using (var conn = new SqlConnection(conStr))
            {
                var command = "Delete From Products Where Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id);
                conn.Execute(command, parameters);
            }
        }

        public List<Product> GetAll()
        {
            using(var conn = new SqlConnection(conStr))
            {
                var query = "Select * From Products";
                var products = conn.Query<Product>(query).ToList();
                return products;
            }
        }

        public Product GetById(int id)
        {
            using (var conn = new SqlConnection(conStr))
            {
                var query = "Select * From Products Where Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", id);
                var product = conn.Query<Product>(query, parameters).SingleOrDefault();
                return product;
            }
        }

        public void Insert(Product product)
        {
            using (var conn = new SqlConnection(conStr))
            {
                var command = "Insert Into Products(Name, Price) Values(@Name, @Price)";
                var parameters = new DynamicParameters();
                parameters.Add("Name", product.Name);
                parameters.Add("Price", product.Price);
                conn.Execute(command, parameters);
            }
        }

        public int InsertWithSP(Product product)
        {
            using (var conn = new SqlConnection(conStr))
            {
                var command = "usp_InsertProduct";
                var parameters = new DynamicParameters();
                parameters.Add("Name", product.Name);
                parameters.Add("Price", product.Price);
                parameters.Add("ProductId", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                conn.Execute(command, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var productId = parameters.Get<Int32>("ProductId");
                return productId;
            }
        }

        public void Update(Product product)
        {
            using (var conn = new SqlConnection(conStr))
            {
                var command = "Update Products Set Name = @Name, Price = @Price Where Id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("Id", product.Id);
                parameters.Add("Name", product.Name);
                parameters.Add("Price", product.Price);
                conn.Execute(command, parameters);
            }
        }
    }
}
