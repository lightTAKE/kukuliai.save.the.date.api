using kukuliai.save.the.date.api.Persistence.ReadModels;

namespace kukuliai.save.the.date.api.Persistence.Repositories;

public interface IRespondPleaseRepository
{
    Task<IEnumerable<Responder>> SelectAll();

    Task AddResponder(string name, bool attending, bool needTransport, string comments);
}