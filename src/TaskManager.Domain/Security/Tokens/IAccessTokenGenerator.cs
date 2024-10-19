using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}
