namespace RotaSegura
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.FlyoutBehavior = FlyoutBehavior.Locked;
        }
    }
}