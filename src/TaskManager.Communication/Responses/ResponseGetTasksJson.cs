namespace TaskManager.Communication.Responses;

public class ResponseGetTasksJson
{
    public List<ResponseGetTaskJson> Tasks { get; set; } = [];
}
