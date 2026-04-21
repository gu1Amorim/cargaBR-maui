using RotaSegura.ViewModels;

namespace RotaSegura;

public partial class SettingPage : ContentPage
{
	public SettingPage(SettingPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}