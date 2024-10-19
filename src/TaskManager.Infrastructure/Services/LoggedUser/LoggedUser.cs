using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Security.Tokens;
using TaskManager.Domain.Services.LoggedUser;
using TaskManager.Infrastructure.DataAccess;

namespace TaskManager.Infrastructure.Services.LoggedUser;

internal class LoggedUser : ILoggedUser
{
    private readonly TaskManagerDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(TaskManagerDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<User> Get()
    {
        string token = _tokenProvider.TokenOnRequest();
        var tokenHendler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHendler.ReadJwtToken(token);
        var identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

        return await _dbContext.Users
            .AsNoTracking()
            .FirstAsync(u => u.UserIdentifier == Guid.Parse(identifier));
    }
}
