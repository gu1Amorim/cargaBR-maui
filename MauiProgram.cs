using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using CargaBR;
using CargaBR.Services;
using CargaBR.Services.Api;
using CargaBR.Services.Api.Fake;
using CargaBR.Services.Theme;
using CargaBR.ViewModels;
using CargaBR.ViewModels.Auth;
using CargaBR.Views;
using CargaBR.Views.Auth;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
namespace CargaBR
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 7 Free-Solid-900.otf", "FASolid");
                });
            builder.ConfigureLifecycleEvents(events => {
#if WINDOWS
                events.AddWindows(wnd => wnd.OnWindowCreated(window => {
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    WindowId windowId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
                    appWindow.Resize(new SizeInt32(1200, 800)); // Tamanho padrão Desktop
                }));
#endif
            });

            // Services
            builder.Services.AddSingleton<ISubscriptionService, SubscriptionService>();
            builder.Services.AddSingleton<IThemeService, ThemeService>();

            // Serviços fake (ativos por padrão neste protótipo).
            // Quando a API real estiver pronta, troque as linhas abaixo por AddHttpClient<TInterface, TImplementation>
            // apontando para ApiSettings.BaseUrl (requer o pacote Microsoft.Extensions.Http, já referenciado no csproj).
            builder.Services.AddSingleton<IAuthService, FakeAuthService>();
            builder.Services.AddSingleton<ITruckService, FakeTruckService>();
            builder.Services.AddSingleton<ILoadService, FakeLoadService>();
            builder.Services.AddSingleton<IFreightService, FakeFreightService>();

            // ViewModels
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<RegisterPageViewModel>();
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<TruckPageViewModel>();
            builder.Services.AddTransient<LoadPageViewModel>();
            builder.Services.AddTransient<FreightPageViewModel>();
            builder.Services.AddTransient<SettingPageViewModel>();

            // Views
            builder.Services.AddTransient<SplashPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<TruckPage>();
            builder.Services.AddTransient<LoadPage>();
            builder.Services.AddTransient<FreightPage>();
            builder.Services.AddTransient<SettingPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
