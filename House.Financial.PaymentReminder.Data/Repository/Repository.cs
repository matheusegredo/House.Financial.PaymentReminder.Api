using House.Financial.PaymentReminder.Data.Interfaces;
using System.Data.SqlClient;
using Dapper;
using System.Text;

namespace House.Financial.PaymentReminder.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    {
        private readonly string _connection = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=house-financial;Integrated Security=SSPI;";

        public string TableName { get; }
        
        public abstract string Identifier { get; }

        protected Repository(string tableName)
        {
            TableName = tableName;
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            using var connection = new SqlConnection(_connection);
            connection.Open();

            var sqlBuilder = new StringBuilder();

            sqlBuilder.Append($"INSERT INTO {TableName} VALUES (");

            foreach (var property in entity.GetType().GetProperties())
            {
                if (Equals(property.Name, Identifier))
                    continue;

                sqlBuilder.Append($"@{property.Name},");
            }

            sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            sqlBuilder.Append(')');

            await connection.ExecuteAsync(sqlBuilder.ToString(), entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connection);
            connection.Open();

            return await connection.QueryAsync<TEntity>($"SELECT * FROM {TableName}");
        }

        public async Task<TEntity> GetById(int id)
        {
            using var connection = new SqlConnection(_connection);
            connection.Open();

            return await connection.QueryFirstAsync<TEntity>($"SELECT TOP 1 * FROM {TableName} WHERE {Identifier} = @id", new { id });
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
