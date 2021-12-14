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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for ClientProfileView.xaml
    /// </summary>
    public partial class ClientProfileView : UserControl
    {
        public ClientProfileView()
        {
            InitializeComponent();
            RefreshProfileInfo();
        }

        private void RefreshProfileInfo()
        {
            CRUD.Client.Instance.ReadFields(StoreProcedure.SEARCH_CLIENT_BYID, WindowManager.ClientID);

            Tb_ClientDNI.Text = CRUD.Client.Instance.ID;
            Tb_Name.Text = CRUD.Client.Instance.FullName;
            Tb_PhoneNumber.Text = CRUD.Client.Instance.PhoneNumber;
            Tb_ClientDNI.Text = CRUD.Client.Instance.ID;
            Tb_BirthDate.Text = CRUD.Client.Instance.BirthDate.ToString();
            Tb_Age.Text = CRUD.Client.Instance.Age.ToString();
            Tb_Address.Text = CRUD.Client.Instance.Address;
        }

        private void Btn_ShowServices_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(CRUD.Client.Instance.PhoneNumber);
        }

        private void Btn_ShowReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_CLIENTS, new ViewModels.ClientViewModel());
        }

        private void Btn_AddService_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ShowWindow(new Register_ServicesView(Tb_ClientDNI.Text));
        }

        private void Btn_EditClient_Click(object sender, RoutedEventArgs e)
        {
            Windows.Edit_Client chooseServiceType = new Windows.Edit_Client(Tb_ClientDNI.Text);
            chooseServiceType.RefreshProfileInfo += new Windows.Edit_Client.DRefreshProfileInfo(RefreshProfileInfo);
            chooseServiceType.ShowDialog();
        }

        private void Btn_DeleteClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_DownloadDoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
