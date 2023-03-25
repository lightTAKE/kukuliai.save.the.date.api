using Microsoft.AspNetCore.Mvc;

namespace kukuliai.save.the.date.api.Controllers;

[ApiController]
[Route("rsvp/")]
public class PleaseRespondController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "hello";
    }
}