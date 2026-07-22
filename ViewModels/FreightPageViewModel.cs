using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Models;
using CargaBR.Services.Api;

namespace CargaBR.ViewModels;

public partial class FreightPageViewModel : BaseViewModel
{
    private readonly IFreightService _freightService;

    public ObservableCollection<Freight> Freights { get; } = [];

    public FreightPageViewModel(IFreightService freightService)
    {
        _freightService = freightService;
    }

    [RelayCommand]
    private async Task LoadFreightsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            ErrorMessage = null;

            Freights.Clear();
            foreach (var freight in await _freightService.GetMyFreightsAsync())
                Freights.Add(freight);
        }
        catch (Exception)
        {
            ErrorMessage = "Não foi possível carregar os transportes.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task RegisterTransportAsync()
    {
        if (Shell.Current is not null)
            await Shell.Current.DisplayAlertAsync("Registrar Transporte", "Funcionalidade pendente de integração com a API.", "OK");
    }
}
