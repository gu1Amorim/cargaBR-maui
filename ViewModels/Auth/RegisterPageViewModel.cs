using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Services.Api;

namespace CargaBR.ViewModels.Auth;

public partial class RegisterPageViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string fullName = string.Empty;

    [ObservableProperty]
    private string cpf = string.Empty;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private string confirmPassword = string.Empty;

    public RegisterPageViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        if (IsBusy) return;

        ErrorMessage = null;

        if (string.IsNullOrWhiteSpace(FullName))
        {
            ErrorMessage = "Informe seu nome completo.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Cpf))
        {
            ErrorMessage = "Informe seu CPF.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
        {
            ErrorMessage = "Informe um e-mail válido.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Password) || Password.Length < 6)
        {
            ErrorMessage = "A senha deve ter ao menos 6 caracteres.";
            return;
        }

        if (Password != ConfirmPassword)
        {
            ErrorMessage = "As senhas não coincidem.";
            return;
        }

        try
        {
            IsBusy = true;
            var request = new RegisterRequest(FullName, Cpf, Email, Password);
            var result = await _authService.RegisterAsync(request);

            if (result.Success)
                await Shell.Current.GoToAsync("//main/home");
            else
                ErrorMessage = result.ErrorMessage ?? "Não foi possível concluir o cadastro.";
        }
        catch (Exception)
        {
            ErrorMessage = "Falha de comunicação. Tente novamente.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private static Task GoToLoginAsync() => Shell.Current.GoToAsync("//login");
}
