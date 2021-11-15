using System;
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
    /// Interaction logic for Register_DriverView.xaml
    /// </summary>
    public partial class Register_DriverView : UserControl
    {
        public Register_DriverView()
        {
            InitializeComponent();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new ViewModels.HomeViewModel());
        }

        private void Btn_AddDriver_Click(object sender, RoutedEventArgs e)
        {
            CRUD.Driver.Instance.Register(Txt_DNI.Text,
                Txt_Name.Text, 
                Txt_Surname.Text,
                Txt_PhoneNumber.Text,
                Dtp_BirthDate.Text, 
                Cb_BloodType.Text,
                Cb_LicenseType.Text);
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            Txt_DNI.Text = "";
            Txt_Name.Text = "";
            Txt_Surname.Text = "";
            Txt_PhoneNumber.Text = "";
            Dtp_BirthDate.Text = DateTime.Now.ToString();
            Cb_BloodType.Text = "";
            Cb_LicenseType.Text = "";
            Cb_BloodType.SelectedItem = null;
            Cb_LicenseType.SelectedItem = null;
        }
    }
}
