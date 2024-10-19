namespace TaskManager.Communication.Requests;

public class RequestRegisterTaskJson
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
}
