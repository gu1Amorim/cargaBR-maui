using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages; // Adicione este namespace aqui

namespace RotaSegura;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        TrocarTela(0);

        // Note que agora usamos ValueChangedMessage<int> em vez de apenas int
        WeakReferenceMessenger.Default.Register<ValueChangedMessage<int>, string>(this, "PageChanged", (recipient, message) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                // Aqui acessamos o .Value da mensagem que contém o seu index
                TrocarTela(message.Value);
            });
        });
    }

    private void TrocarTela(int index)
    {
        ContentArea.Content = index switch
        {
            0 => new HomePage().Content,
            1 => new SalesPage().Content,
            2 => new ProductPage().Content,
            3 => new SettingsPage().Content,
            _ => new HomePage().Content,
        };
    }
}