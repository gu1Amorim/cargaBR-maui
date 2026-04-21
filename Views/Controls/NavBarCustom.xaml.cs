using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages; 

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

        int newIndex = int.Parse(btn.CommandParameter.ToString()!);
        if (newIndex == _currentIndex) return;

        double columnWidth = this.Width / 5;

        double targetX = (newIndex - _currentIndex) * columnWidth;

        double finalX = newIndex * columnWidth;

        await SelectionCircle.TranslateToAsync(finalX, 0, 150, Easing.CubicOut);

        _currentIndex = newIndex;
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<int>(newIndex), "PageChanged");
    }
}