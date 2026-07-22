using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Services.Api;

namespace CargaBR.ViewModels;

public partial class HomePageViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    private readonly ILoadService _loadService;
    private readonly IFreightService _freightService;

    [ObservableProperty]
    private string userName = string.Empty;

    [ObservableProperty]
    private string userCpf = string.Empty;

    [ObservableProperty]
    private decimal monthlyEarnings;

    [ObservableProperty]
    private int deliveriesCount;

    public HomePageViewModel(IAuthService authService, ILoadService loadService, IFreightService freightService)
    {
        _authService = authService;
        _loadService = loadService;
        _freightService = freightService;
    }

    [RelayCommand]
    private async Task LoadDashboardAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            ErrorMessage = null;

            var user = await _authService.GetCurrentUserAsync();
            UserName = user?.FullName ?? string.Empty;
            UserCpf = user?.Cpf ?? string.Empty;

            var freights = await _freightService.GetMyFreightsAsync();
            MonthlyEarnings = freights.Sum(f => f.Value);
            DeliveriesCount = freights.Count;
        }
        catch (Exception)
        {
            ErrorMessage = "Não foi possível carregar os dados do painel.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task ImportInvoiceAsync()
    {
        if (Shell.Current is not null)
            await Shell.Current.DisplayAlertAsync("Importar Nota Fiscal", "Funcionalidade pendente de integração com a API.", "OK");
    }

    [RelayCommand]
    private static Task GoToLoadsAsync() => Shell.Current.GoToAsync("//main/load");

    [RelayCommand]
    private static Task GoToTruckAsync() => Shell.Current.GoToAsync("//main/truck");
}
