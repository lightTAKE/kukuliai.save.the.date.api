namespace kukuliai.save.the.date.api.Persistence.ReadModels;

public class Responder
{
    public int Id { get; set; }

    public string Name { get; set; }

    public bool Attending { get; set; }

    public bool NeedTransport { get; set; }

    public string Comments { get; set; }
}