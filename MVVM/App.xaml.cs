using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MVVM.Models;
using MVVM.ViewModels;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var demoModel = new DemoModel();
            var demoViewModel = new DemoViewModel(demoModel);
            var mainViewModel = new MainViewModel(demoViewModel);

            var mainWindow = new MainWindow(){DataContext = mainViewModel};

            mainWindow.Show();

        }
    }
}
