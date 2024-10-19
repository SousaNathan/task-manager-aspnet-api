namespace TaskManager.Communication.Responses;

public class ResponseGetShortTaskJson
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;

    public string Category { get; set; } = string.Empty;
}
