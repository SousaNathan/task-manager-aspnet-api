namespace TaskManager.Domain.Security.Tokens;

public interface ITokenProvider
{
    string TokenOnRequest();
}
