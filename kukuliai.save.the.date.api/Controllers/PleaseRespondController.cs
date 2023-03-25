using kukuliai.save.the.date.api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kukuliai.save.the.date.api.Controllers;

[ApiController]
[Route("rsvp/")]
public class PleaseRespondController : ControllerBase
{
    private readonly IRespondPleaseRepository _respondPleaseRepository;

    public PleaseRespondController(IRespondPleaseRepository respondPleaseRepository)
    {
        _respondPleaseRepository = respondPleaseRepository;
    }
    
    [HttpGet]
    public async Task<string> Get()
    {
        var result = await _respondPleaseRepository.SelectAll();
        return JsonConvert.SerializeObject(result);
    }
}