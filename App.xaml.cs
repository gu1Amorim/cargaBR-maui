namespace RotaSegura;

public partial class App : Application
{
    [Obsolete]
    public App()
    {
        InitializeComponent();

        // Verificação direta
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
        {
            // Desktop: USA O SHELL (Menu Lateral)
            MainPage = new AppShell();
        }
        else
        {
            // Mobile: USA A MAINPAGE (NavBar com Bolinha)
            MainPage = new MainPage();
        }
    }
}