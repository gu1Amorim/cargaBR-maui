using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages; // Adicione este namespace

namespace RotaSegura;

public partial class NavBarCustom : ContentView
{
    private int _currentIndex = 0;

    public NavBarCustom()
    {
        InitializeComponent();
    }

    private async void NavigateCommand(object sender, EventArgs e)
    {
        if (sender is not Button btn || btn.CommandParameter == null) return;

        int newIndex = int.Parse(btn.CommandParameter.ToString());
        if (newIndex == _currentIndex) return;

        // Lógica de animação
        double columnWidth = this.Width / 4;
        double targetX = newIndex * columnWidth;

        await SelectionCircle.TranslateToAsync(targetX, 0, 100, Easing.Linear);

        _currentIndex = newIndex;

        // CORREÇÃO AQUI: 
        // Em vez de enviar 'newIndex' puro, enviamos o ValueChangedMessage
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<int>(newIndex), "PageChanged");
    }
}