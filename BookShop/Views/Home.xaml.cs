﻿using BookShop.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BookShop.Views
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home(HomeViewModel vm)
        {
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(() => Close());
            InitializeComponent();
        }
    }
}
