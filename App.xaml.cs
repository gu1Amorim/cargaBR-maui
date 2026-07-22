using CargaBR.Services.Theme;

namespace CargaBR;

public partial class App : Application
{
    public App(IThemeService themeService)
    {
        InitializeComponent();

        themeService.ApplyPersistedTheme();

        MainPage = new AppShell();
    }
}
