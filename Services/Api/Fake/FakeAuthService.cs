using CargaBR.Models;

namespace CargaBR.Services.Api.Fake;

public class FakeAuthService : IAuthService
{
    private const string TokenKey = "auth_token";

    private static User? _currentUser;

    public async Task<bool> IsAuthenticatedAsync()
    {
        await Task.Delay(300); // TODO: trocar por verificação real (ex.: validade de JWT)
        return !string.IsNullOrEmpty(Preferences.Default.Get(TokenKey, string.Empty));
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        await Task.Delay(300); // TODO: substituir por chamada HTTP real (GET /auth/me)
        return _currentUser;
    }

    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        await Task.Delay(1200); // TODO: substituir por chamada HTTP real (POST /auth/login)
        Preferences.Default.Set(TokenKey, "fake-token");

        _currentUser = new User
        {
            Id = 1,
            FullName = "João Silva",
            Cpf = "123.456.789-00",
            Email = email,
            IsPremium = true,
            SubscriptionExpiration = DateTime.Now.AddMonths(1)
        };

        return new AuthResult(true, User: _currentUser);
    }

    public async Task<AuthResult> RegisterAsync(RegisterRequest request)
    {
        await Task.Delay(1200); // TODO: substituir por chamada HTTP real (POST /auth/register)
        Preferences.Default.Set(TokenKey, "fake-token");

        _currentUser = new User
        {
            Id = 1,
            FullName = request.FullName,
            Cpf = request.Cpf,
            Email = request.Email,
            IsPremium = false,
            SubscriptionExpiration = null
        };

        return new AuthResult(true, User: _currentUser);
    }

    public Task LogoutAsync()
    {
        Preferences.Default.Remove(TokenKey);
        _currentUser = null;
        return Task.CompletedTask;
    }
}
