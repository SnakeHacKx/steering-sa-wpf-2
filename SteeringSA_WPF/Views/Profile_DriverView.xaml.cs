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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for Profile_DriverView.xaml
    /// </summary>
    public partial class Profile_DriverView : UserControl
    {
        public Profile_DriverView()
        {
            InitializeComponent();
            RefreshProfileInfo();
        }

        private void RefreshProfileInfo()
        {
            CRUD.Driver.Instance.ReadFields(StoreProcedure.SEARCH_DRIVER_BYID, WindowManager.DriverID);

            Tb_Name.Text = CRUD.Driver.Instance.FullName;
            Tb_PhoneNumber.Text = CRUD.Driver.Instance.PhoneNumber;
            Tb_BloodType.Text = CRUD.Driver.Instance.BloodType;
            Tb_DriverDNI.Text = CRUD.Driver.Instance.ID;
            Tb_LicenseType.Text = CRUD.Driver.Instance.LicenseType;
            Tb_BirthDate.Text = CRUD.Driver.Instance.BirthDate;
            Tb_Age.Text = CRUD.Driver.Instance.Age.ToString();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_DRIVERS, new ViewModels.DriverViewModel());
        }

        private void Btn_EditDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_DeleteDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_DownloadDoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
