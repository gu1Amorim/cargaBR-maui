using CargaBR.ViewModels;

namespace CargaBR.Views;

public partial class TruckPage : ContentPage
{
    private readonly TruckPageViewModel _viewModel;

    public TruckPage(TruckPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadTruckDataCommand.Execute(null);
    }
}
