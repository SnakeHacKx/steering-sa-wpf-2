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
    /// Interaction logic for Register_ClientView.xaml
    /// </summary>
    public partial class Register_ClientView : UserControl
    {
        public Register_ClientView()
        {
            InitializeComponent();
        }

        private void Btn_AddClient_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea registrar este cliente?",
                "Registrar Cliente",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Client.Instance.Register(Txt_DNI.Text, Txt_Name.Text, Txt_Surname.Text, Txt_PhoneNumber.Text, Dtp_BirthDate.Text, Txt_Address.Text);
                ClearFormFields();
            }
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_CLIENTS, new ViewModels.ClientViewModel());
        }

        private void ClearFormFields()
        {
            Txt_DNI.Text = "";
            Txt_Name.Text = "";
            Txt_Surname.Text = "";
            Txt_PhoneNumber.Text = "";
            Dtp_BirthDate.Text = DateTime.Now.ToString();
            Txt_Address.Text = "";
        }
    }
}
