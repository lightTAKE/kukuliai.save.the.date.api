using System.ComponentModel.DataAnnotations;

namespace kukuliai.save.the.date.api.Controllers.Models;

public class RespondPleaseRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public bool Attending { get; set; }

    public bool NeedTransport { get; set; }

    public string Comments { get; set; }
}