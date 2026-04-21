using System.Windows.Input;

namespace RotaSegura.ViewModels;

public class TruckPageViewModel : BaseViewModel
{
    public ICommand SaveTruckCommand { get; }
    public bool IsNotPremium => false;

    public TruckPageViewModel()
    {
        SaveTruckCommand = new Command(async () => {
            if (Shell.Current != null)
            {
                await Shell.Current.DisplayAlertAsync("Aviso", "Botão funcionando no protótipo!", "OK");
            }
        });
    }
}