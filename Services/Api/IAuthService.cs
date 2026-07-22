using CargaBR.Models;

namespace CargaBR.Services.Api;

public record AuthResult(bool Success, string? ErrorMessage = null, User? User = null);

public record RegisterRequest(string FullName, string Cpf, string Email, string Password);

public interface IAuthService
{
    Task<bool> IsAuthenticatedAsync();

    Task<User?> GetCurrentUserAsync();

    Task<AuthResult> LoginAsync(string email, string password);

    Task<AuthResult> RegisterAsync(RegisterRequest request);

    Task LogoutAsync();
}
