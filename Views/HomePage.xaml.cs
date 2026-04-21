using RotaSegura.ViewModels;

namespace RotaSegura;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}