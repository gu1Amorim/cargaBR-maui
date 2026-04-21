using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using RotaSegura;
using RotaSegura.Services;
using RotaSegura.ViewModels;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif
namespace RotaSegura
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FASolid");
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

            // ViewModels
            builder.Services.AddTransient<HomePageViewModel>();
            builder.Services.AddTransient<TruckPageViewModel>();
            builder.Services.AddTransient<LoadPageViewModel>();
            builder.Services.AddTransient<FreightPageViewModel>();
            builder.Services.AddTransient<SettingPageViewModel>();

            // Views
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
