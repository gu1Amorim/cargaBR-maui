using CargaBR.ViewModels;

namespace CargaBR.Views;

public partial class SettingPage : ContentPage
{
    private readonly SettingPageViewModel _viewModel;

    public SettingPage(SettingPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadProfileCommand.Execute(null);
    }
}
