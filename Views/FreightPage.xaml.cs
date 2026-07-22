using CargaBR.ViewModels;

namespace CargaBR.Views;

public partial class FreightPage : ContentPage
{
    private readonly FreightPageViewModel _viewModel;

    public FreightPage(FreightPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadFreightsCommand.Execute(null);
    }
}
