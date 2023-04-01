using Dapper;
using Microsoft.Data.SqlClient;

namespace kukuliai.save.the.date.api.Persistence.Clients;

public class SqlClient : ISqlClient
{
    private readonly string _connectionString;

    public SqlClient(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
    {
        await using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync(CancellationToken.None);
            var commandParams = new CommandDefinition(sql, param, cancellationToken: CancellationToken.None);
            return await connection.QueryAsync<T>(commandParams);
        }
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null)
    {
        await using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync(CancellationToken.None);
            var commandParams = new CommandDefinition(sql, param, cancellationToken: CancellationToken.None);
            return await connection.ExecuteAsync(commandParams);
        }
    }
}