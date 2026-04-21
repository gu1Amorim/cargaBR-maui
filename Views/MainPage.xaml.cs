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
        ContentArea.Content = index switch
        {
            0 => new HomePage().Content,
            1 => new TruckPage().Content,
            2 => new LoadPage().Content,
            3 => new FreightPage().Content,
            4 => new SettingPage().Content,
            _ => new HomePage().Content,
        };
    }
}