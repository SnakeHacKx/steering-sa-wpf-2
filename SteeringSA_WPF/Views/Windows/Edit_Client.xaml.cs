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
using System.Windows.Shapes;

namespace SteeringSA_WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for Edit_Client.xaml
    /// </summary>
    public partial class Edit_Client : Window
    {
        private string clientID;
        public delegate void DRefreshProfileInfo();
        public event DRefreshProfileInfo RefreshProfileInfo;

        public Edit_Client(string clientID)
        {
            InitializeComponent();
            RefreshClientInfo();
            this.clientID = clientID;
        }

        private void RefreshClientInfo()
        {
            Txt_Name.Text = CRUD.Client.Instance.FullName;
            Txt_PhoneNumber.Text = CRUD.Client.Instance.PhoneNumber;
            Dtp_BirthDate.Text = CRUD.Client.Instance.BirthDate.ToString();
            Txt_Address.Text = CRUD.Client.Instance.Address;
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_EditClient_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea editar este cliente?",
                "Editar Cliente",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Client.Instance.Edit(clientID, Txt_Name.Text, Txt_Surname.Text, Txt_PhoneNumber.Text, Dtp_BirthDate.Text, Txt_Address.Text);
                RefreshProfileInfo();
                Close();
            }
        }
    }
}
