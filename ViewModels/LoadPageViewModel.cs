using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Models;
using CargaBR.Services.Api;

namespace CargaBR.ViewModels;

public partial class LoadPageViewModel : BaseViewModel
{
    private readonly ILoadService _loadService;

    public ObservableCollection<Load> Loads { get; } = [];

    public LoadPageViewModel(ILoadService loadService)
    {
        _loadService = loadService;
    }

    [RelayCommand]
    private async Task LoadLoadsAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            ErrorMessage = null;

            Loads.Clear();
            foreach (var load in await _loadService.GetAvailableLoadsAsync())
                Loads.Add(load);
        }
        catch (Exception)
        {
            ErrorMessage = "Não foi possível carregar as cargas disponíveis.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AcceptLoadAsync(Load load)
    {
        if (Shell.Current is null) return;

        try
        {
            IsBusy = true;
            await _loadService.AcceptLoadAsync(load.Id);
            await Shell.Current.DisplayAlertAsync("Sucesso", $"Carga \"{load.Description}\" aceita!", "OK");
            await LoadLoadsAsync();
        }
        finally
        {
            IsBusy = false;
        }
    }
}
