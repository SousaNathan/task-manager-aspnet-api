using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;
using TaskManager.Domain.Repositories.User;
using TaskManager.Domain.Security.Cryptography;
using TaskManager.Domain.Security.Tokens;
using TaskManager.Exception.ExceptionBase;

namespace TaskManager.Application.UseCases.Login.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository userReadOnlyRepository;
    private readonly IPasswordEncripter _passwordEncripter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(
        IUserReadOnlyRepository readOnlyRepository,
        IPasswordEncripter passwordEncripter,
        IAccessTokenGenerator accessTokenGenerator)
    {
        _accessTokenGenerator = accessTokenGenerator;
        userReadOnlyRepository = readOnlyRepository;
        _passwordEncripter = passwordEncripter;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
    {
        var user = await userReadOnlyRepository.GetUserByEmail(request.Email);

        if (user is null)
        {
            throw new InvalidLoginException();
        }

        var passwordMatch = _passwordEncripter.Verify(request.Password, user.Password);

        if (!passwordMatch)
        {
            throw new InvalidLoginException();
        }

        return new ResponseRegisterUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
