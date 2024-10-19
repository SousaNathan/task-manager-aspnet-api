namespace TaskManager.Communication.Requests;

public class RequestCreateTaskJson
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
}
