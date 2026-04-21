using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RotaSegura;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        TrocarTela(0);

        WeakReferenceMessenger.Default.Register<ValueChangedMessage<int>, string>(this, "PageChanged", (recipient, message) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TrocarTela(message.Value);
            });
        });
    }

    private void TrocarTela(int index)
    {
        if (Handler?.MauiContext == null) return;

        ContentPage? page = index switch
        {
            0 => Handler.MauiContext.Services.GetService<HomePage>(),
            1 => Handler.MauiContext.Services.GetService<TruckPage>(),
            2 => Handler.MauiContext.Services.GetService<LoadPage>(),
            3 => Handler.MauiContext.Services.GetService<FreightPage>(),
            4 => Handler.MauiContext.Services.GetService<SettingPage>(),
            _ => Handler.MauiContext.Services.GetService<HomePage>(),
        };

        if (page != null)
        {
            ContentArea.Content = page.Content;
        }
    }
}