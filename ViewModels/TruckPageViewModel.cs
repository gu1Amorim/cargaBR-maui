using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CargaBR.Models;
using CargaBR.Services;
using CargaBR.Services.Api;

namespace CargaBR.ViewModels;

public partial class TruckPageViewModel : BaseViewModel
{
    private readonly ITruckService _truckService;
    private readonly ISubscriptionService _subscriptionService;

    [ObservableProperty]
    private Truck? truck;

    public ObservableCollection<Trailer> Trailers { get; } = [];

    public bool IsNotPremium => !_subscriptionService.IsFeatureAccessible("TruckPage");

    public TruckPageViewModel(ITruckService truckService, ISubscriptionService subscriptionService)
    {
        _truckService = truckService;
        _subscriptionService = subscriptionService;
    }

    [RelayCommand]
    private async Task LoadTruckDataAsync()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            ErrorMessage = null;

            Truck = await _truckService.GetMyTruckAsync();

            Trailers.Clear();
            foreach (var trailer in await _truckService.GetTrailersAsync())
                Trailers.Add(trailer);
        }
        catch (Exception)
        {
            ErrorMessage = "Não foi possível carregar os dados do caminhão.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AddTrailerAsync()
    {
        if (Shell.Current is null) return;

        var description = await Shell.Current.DisplayPromptAsync("Nova Carreta", "Descrição da carreta:");
        if (string.IsNullOrWhiteSpace(description)) return;

        var plate = await Shell.Current.DisplayPromptAsync("Nova Carreta", "Placa da carreta:");
        if (string.IsNullOrWhiteSpace(plate)) return;

        try
        {
            IsBusy = true;
            var trailer = new Trailer { Description = description, Plate = plate };
            if (await _truckService.AddTrailerAsync(trailer))
                Trailers.Add(trailer);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
