﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for Register_ServicesView.xaml
    /// </summary>
    public partial class Register_ServicesView : Window
    {
        public Register_ServicesView()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindowName(WindowsTitle.CLIENT_PROFILE);
            this.Close();
        }

        private void Btn_ChooseServiceType_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ChooseDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ChooseVehicle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
