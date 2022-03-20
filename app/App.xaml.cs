using CasinoSimulation.ViewModel;
using CasinoSimulation.View;
using System.Windows;
using CasinoSimulation.Model.Global;
using System.Diagnostics;

namespace CasinoSimulation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Navigation _navigation;
        protected override void OnStartup(StartupEventArgs e)
        {
            Debug.WriteLine("ee");
            _navigation = new Navigation();
            User user = new User(5000);
            _navigation.CurrentViewModel = new MenuViewModel(_navigation, user);
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.DataContext = new MainViewModel(_navigation);
            MainWindow.Show();

        }
    }
}
