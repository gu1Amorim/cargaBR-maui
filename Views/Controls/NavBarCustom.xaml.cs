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

    private void NavigateCommand(object sender, EventArgs e)
    {
        if (sender is not Button btn || btn.CommandParameter == null) return;

        int newIndex = int.Parse(btn.CommandParameter.ToString()!);

        if (newIndex == _currentIndex) return;

        UpdateVisuals(newIndex);

        _currentIndex = newIndex;
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<int>(newIndex), "PageChanged");
    }

    private void UpdateVisuals(int index)
    {
        var icons = new List<Microsoft.Maui.Controls.Shapes.Path> { Icon0, Icon1, Icon2, Icon3, Icon4 };
        var labels = new List<Label> { Text0, Text1, Text2, Text3, Text4 };

        for (int i = 0; i < icons.Count; i++)
        {
            bool isSelected = (i == index);

            icons[i].Fill = isSelected ? Color.FromArgb("#2196F3") : Colors.Gray;

            labels[i].TextColor = isSelected ? Color.FromArgb("#2196F3") : Colors.Gray;

            labels[i].FontAttributes = isSelected ? FontAttributes.Bold : FontAttributes.None;
        }
    }
} 