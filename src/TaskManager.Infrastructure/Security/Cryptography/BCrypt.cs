using TaskManager.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace TaskManager.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncripter
{
    public string Encript(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
    {
        return BC.Verify(password, passwordHash);
    }
}
