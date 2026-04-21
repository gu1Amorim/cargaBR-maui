using RotaSegura.ViewModels;

namespace RotaSegura;

public partial class FreightPage : ContentPage
{
	public FreightPage(FreightPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}