using System.Windows.Input;

namespace RotaSegura.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand SaveTruckCommand { get; }
        public bool IsNotPremium => false;

        public HomePageViewModel()
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
