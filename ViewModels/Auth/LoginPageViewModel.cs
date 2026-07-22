using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Services.Api;

namespace CargaBR.ViewModels.Auth;

public partial class LoginPageViewModel : BaseViewModel
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    public LoginPageViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy) return;

        ErrorMessage = null;

        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains('@'))
        {
            ErrorMessage = "Informe um e-mail válido.";
            return;
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Informe a senha.";
            return;
        }

        try
        {
            IsBusy = true;
            var result = await _authService.LoginAsync(Email, Password);

            if (result.Success)
                await Shell.Current.GoToAsync("//main/home");
            else
                ErrorMessage = result.ErrorMessage ?? "Não foi possível entrar.";
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
    private static Task GoToRegisterAsync() => Shell.Current.GoToAsync("//register");
}
