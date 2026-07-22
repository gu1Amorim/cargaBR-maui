using CommunityToolkit.Mvvm.ComponentModel;

namespace CargaBR.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty]
    private string? errorMessage;

    public bool IsNotBusy => !IsBusy;
}
