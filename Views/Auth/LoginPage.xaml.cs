using CargaBR.ViewModels.Auth;

namespace CargaBR.Views.Auth;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
