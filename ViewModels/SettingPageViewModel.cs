using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Services.Api;
using CargaBR.Services.Theme;

namespace CargaBR.ViewModels;

public partial class SettingPageViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    private readonly IThemeService _themeService;

    public string[] ThemeOptions { get; } = ["Claro", "Escuro", "Sistema"];

    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string userCpf = string.Empty;

    [ObservableProperty]
    private bool isPremium;

    [ObservableProperty]
    private string subscriptionRenewalText = string.Empty;

    [ObservableProperty]
    private string selectedThemeOption;

    public SettingPageViewModel(IAuthService authService, IThemeService themeService)
    {
        _authService = authService;
        _themeService = themeService;

        selectedThemeOption = _themeService.CurrentTheme switch
        {
            AppTheme.Light => ThemeOptions[0],
            AppTheme.Dark => ThemeOptions[1],
            _ => ThemeOptions[2]
        };
    }

    partial void OnSelectedThemeOptionChanged(string value)
    {
        var theme = value switch
        {
            "Claro" => AppTheme.Light,
            "Escuro" => AppTheme.Dark,
            _ => AppTheme.Unspecified
        };

        _themeService.SetTheme(theme);
    }

    [RelayCommand]
    private async Task LoadProfileAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            var user = await _authService.GetCurrentUserAsync();

            UserName = user?.FullName ?? string.Empty;
            UserCpf = user?.Cpf ?? string.Empty;
            IsPremium = user?.IsPremium ?? false;
            SubscriptionRenewalText = user?.SubscriptionExpiration is { } expiration
                ? $"Renova em: {expiration:dd/MM/yyyy}"
                : "Sem assinatura ativa";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task OpenPersonalDataAsync()
    {
        if (Shell.Current is not null)
            await Shell.Current.DisplayAlertAsync("Dados Pessoais", "Funcionalidade pendente de integração com a API.", "OK");
    }

    [RelayCommand]
    private async Task OpenDocumentsAsync()
    {
        if (Shell.Current is not null)
            await Shell.Current.DisplayAlertAsync("Documentos e CNH", "Funcionalidade pendente de integração com a API.", "OK");
    }

    [RelayCommand]
    private async Task LogoutAsync()
    {
        await _authService.LogoutAsync();
        if (Shell.Current is not null)
            await Shell.Current.GoToAsync("//login");
    }
}
