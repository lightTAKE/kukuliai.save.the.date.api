namespace kukuliai.save.the.date.api.Persistence.Clients;

public interface ISqlClient
{
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null);
}