using kukuliai.save.the.date.api.Persistence.Clients;
using kukuliai.save.the.date.api.Persistence.ReadModels;

namespace kukuliai.save.the.date.api.Persistence.Repositories;

public class RespondPleaseRepository : IRespondPleaseRepository
{
    private readonly ISqlClient _sqlClient;
    private readonly string _selectAllStatement;
    private readonly string _upsertResponderStatement;

    public RespondPleaseRepository(ISqlClient sqlClient)
    {
        _sqlClient = sqlClient;
        _selectAllStatement = @"SELECT * FROM dbo.rsvp";
        _upsertResponderStatement = @"
            IF NOT EXISTS (SELECT 1 FROM [dbo].[rsvp] WHERE [Name] = @Name)
                INSERT INTO [dbo].[rsvp]
                VALUES(@Name, @Attending, @NeedTransport, @Comments)
            ELSE
                UPDATE [dbo].[rsvp]
                SET [Attending] = @Attending, [NeedTransport] = @NeedTransport, [Comments] = @Comments
                WHERE [Name] = @Name";
    }
    
    public Task<IEnumerable<Responder>> SelectAll()
    {
        return _sqlClient.QueryAsync<Responder>(_selectAllStatement);
    }

    public Task AddResponder(string name, bool attending, bool needTransport, string comments)
    {
        var parameters = new { Name = name, Attending = attending, NeedTransport = needTransport, Comments = comments };
        return _sqlClient.ExecuteAsync(_upsertResponderStatement, parameters);
    }
}