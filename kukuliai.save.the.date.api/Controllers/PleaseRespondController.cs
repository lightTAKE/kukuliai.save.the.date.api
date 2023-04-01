using kukuliai.save.the.date.api.Controllers.Models;
using kukuliai.save.the.date.api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace kukuliai.save.the.date.api.Controllers;

[ApiController]
[Route("rsvp-restapi")]
public class PleaseRespondController : ControllerBase
{
    private readonly IRespondPleaseRepository _respondPleaseRepository;

    public PleaseRespondController(IRespondPleaseRepository respondPleaseRepository)
    {
        _respondPleaseRepository = respondPleaseRepository;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var result = await _respondPleaseRepository.SelectAll();
        return Ok(result);
    }

    [HttpPost("respond")]
    public async Task<IActionResult> Respond([FromBody] RespondPleaseRequest request)
    {
        await _respondPleaseRepository.AddResponder(request.Name, request.Attending, request.NeedTransport, request.Comments);
        return Ok();
    }
}