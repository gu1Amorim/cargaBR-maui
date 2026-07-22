using CargaBR.ViewModels;

namespace CargaBR.Views;

public partial class LoadPage : ContentPage
{
    private readonly LoadPageViewModel _viewModel;

    public LoadPage(LoadPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadLoadsCommand.Execute(null);
    }
}
