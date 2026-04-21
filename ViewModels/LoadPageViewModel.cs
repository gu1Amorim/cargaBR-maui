using System.Windows.Input;

namespace RotaSegura.ViewModels
{
    public class LoadPageViewModel : BaseViewModel
    {
        public ICommand SaveTruckCommand { get; }
        public bool IsNotPremium => false;

        public LoadPageViewModel()
        {
            SaveTruckCommand = new Command(async () => {
                if (Shell.Current != null)
                {
                    await Shell.Current.DisplayAlertAsync("Aviso", "Botão funcionando no protótipo!", "OK");
                }
            });
        }
    }
}
