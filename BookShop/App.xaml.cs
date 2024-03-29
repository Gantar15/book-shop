﻿using BookShop.ViewModels;
using BookShop.ViewModels.Common;
using BookShop.Views;
using System.Windows;

namespace BookShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Current.MainWindow = new AuthWindow(new AuthViewModel());
            Current.MainWindow.Closing += AuthWindow_Closing;
            Current.MainWindow.Show();
        }

        private void AuthWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var view = Current.MainWindow as AuthWindow;
            if (view is null || !view.VM.IsLoggedIn)
            {
                return;
            }

            switch (LoggedinUser.Role)
            {
                case "Admin":
                    Current.MainWindow = new AdminWindow(new AdminViewModel(view.VM.db));
                    break;
                case "User":
                default:
                    Current.MainWindow = new Home(new HomeViewModel(view.VM.db));
                    break;
            }
            Current.MainWindow.Closing -= AuthWindow_Closing;
            Current.MainWindow.Show();
        }
    }
}
