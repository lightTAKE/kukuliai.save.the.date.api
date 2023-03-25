using kukuliai.save.the.date.api.Persistence.Clients;
using kukuliai.save.the.date.api.Persistence.ReadModels;

namespace kukuliai.save.the.date.api.Persistence.Repositories;

public class RespondPleaseRepository : IRespondPleaseRepository
{
    private readonly ISqlClient _sqlClient;
    private readonly string _selectAllStatement;

    public RespondPleaseRepository(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
        _selectAllStatement = @"SELECT * FROM dbo.rsvp";
    }
    
    public Task<IEnumerable<Responder>> SelectAll()
    {
        return _sqlClient.QueryAsync<Responder>(_selectAllStatement);
    }
}