namespace TaskManager.Communication.Responses;

internal class ResponseCreateTaskJson
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty;
}
