using CargaBR.ViewModels.Auth;

namespace CargaBR.Views.Auth;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
