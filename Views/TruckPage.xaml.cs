using RotaSegura.ViewModels;

namespace RotaSegura;

public partial class TruckPage : ContentPage
{
    public TruckPage(TruckPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}