using System.Windows;
using MVVM.Models;
using MVVM.Services;
using MVVM.ViewModels;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DemoNavigationService _navgationService;

        public App()
        {
            _navgationService = new DemoNavigationService();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainViewModel = new MainViewModel(_navgationService);

            var mainWindow = new MainWindow(){DataContext = mainViewModel};

            mainWindow.Show();

        }
    }
}
