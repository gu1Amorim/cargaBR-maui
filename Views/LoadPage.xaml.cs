using RotaSegura.ViewModels;

namespace RotaSegura;

public partial class LoadPage : ContentPage
{
	public LoadPage(LoadPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}