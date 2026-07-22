namespace CargaBR.Models;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsPremium { get; set; }
    public DateTime? SubscriptionExpiration { get; set; }
}
