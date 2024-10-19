using System.ComponentModel.DataAnnotations;

namespace TaskManager.Communication.Requests;

public class RequestCreateUserJson
{
    public long Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
