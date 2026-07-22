using CargaBR.Services.Api;

namespace CargaBR.Views;

public partial class SplashPage : ContentPage
{
    private readonly IAuthService _authService;

    public SplashPage(IAuthService authService)
    {
        InitializeComponent();
        _authService = authService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var isAuthenticated = await _authService.IsAuthenticatedAsync();
        await Shell.Current.GoToAsync(isAuthenticated ? "//main/home" : "//login");
    }
}
