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

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for Register_ServicesView.xaml
    /// </summary>
    public partial class Register_ServicesView : Window
    {
        private string clientID;
        public Register_ServicesView(string clientID)
        {
            InitializeComponent();
            this.clientID = clientID;

            Tb_ClientDNI.Text = clientID;
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
            WindowManager.ShowWindow(new Windows.Choose_Driver());
        }

        private void Btn_ChooseVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddService_Click(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;
            CRUD.Service.Instance.Register(Txt_ServiceTypeID.Text,
                Txt_DriverDNI.Text,
                Tb_ClientDNI.Text,
                Txt_VehicleRegistration.Text,
                Dtp_ServiceBeginDate.Text,
                Dtp_ServiceEndDate.Text,
                description);
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            Txt_ServiceTypeID.Text = "";
            Txt_DriverDNI.Text = "";
            Tb_ClientDNI.Text = "";
            Txt_VehicleRegistration.Text = "";
            Dtp_ServiceBeginDate.Text = "";
            Dtp_ServiceEndDate.Text = "";
            Txt_Description.Document.Blocks.Clear();
            Txt_Description.Document.Blocks.Add(new Paragraph(new Run("")));
        }
    }
}
