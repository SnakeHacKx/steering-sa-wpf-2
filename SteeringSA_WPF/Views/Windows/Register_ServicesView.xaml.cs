using MaterialDesignThemes.Wpf;
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

        public void ChangeDriverID()
        {
            Txt_DriverDNI.Text = WindowManager.ChosenDriver;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_ChooseServiceType_Click(object sender, RoutedEventArgs e)
        {
            //WindowManager.ShowWindow(new Windows.Choose_ServiceType());
            Windows.Choose_ServiceType chooseServiceType = new Windows.Choose_ServiceType();
            chooseServiceType.ChangeServiceTypeID += new Windows.Choose_ServiceType.DChangeServiceTypeID(ChangeServiceTypeID);
            chooseServiceType.ShowDialog();
        }

        public void ChangeServiceTypeID()
        {
            Txt_ServiceTypeID.Text = WindowManager.ChosenServiceType;
            Tb_ServiceTypeCode.Text = WindowManager.ChosenServiceType;

            CRUD.ServiceType.Instance.ReadFields(StoreProcedure.SEARCH_TYPE_SERVICE_BYCODE, WindowManager.ChosenServiceType);
            Tb_ServiceTypeName.Text = CRUD.ServiceType.Instance.Nombre;
            Tb_ServiceTypeCost.Text = CRUD.ServiceType.Instance.Costo_Dia.ToString();
        }

        private void Btn_ChooseDriver_Click(object sender, RoutedEventArgs e)
        {
            Windows.Choose_Driver chooseDriver = new Windows.Choose_Driver();
            chooseDriver.ChangeDriverID += new Windows.Choose_Driver.DChangeDriverID(ChangeDriverID);
            chooseDriver.ShowDialog();
            //WindowManager.ShowWindow(new Windows.Choose_Driver());
        }

        private void Btn_ChooseVehicle_Click(object sender, RoutedEventArgs e)
        {
            Windows.Choose_Vehicle chooseVehicle = new Windows.Choose_Vehicle();
            chooseVehicle.ChangeVehicleID += new Windows.Choose_Vehicle.DChangeVehicleID(ChangeVehicleID);
            chooseVehicle.ShowDialog();
        }

        public void ChangeVehicleID()
        {
            Txt_VehicleRegistration.Text = WindowManager.ChosenVehicle;
        }

        private void Btn_AddService_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea registrar este servicio?",
                "Registrar Servicio",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;

                description = description.Replace("\n", "").Replace("\r", "");

                CRUD.Service.Instance.Register(Txt_ServiceTypeID.Text,
                    Txt_DriverDNI.Text,
                    Tb_ClientDNI.Text,
                    Txt_VehicleRegistration.Text,
                    Dtp_ServiceBeginDate.Text,
                    Dtp_ServiceEndDate.Text,
                    description);
                ClearFormFields();
            }
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

        private void Btn_AddServiceType_Click(object sender, RoutedEventArgs e)
        {
            Dh_AddServiceType.ShowDialog(Dh_AddServiceType.DialogContent);
        }

        private void Btn_BHAccept_Click(object sender, RoutedEventArgs e)
        {
            CRUD.ServiceType.Instance.Register(Txt_ServiceTypeName.Text,
                Txt_ServiceTypeCost.Text);
            ClearDialogHostFields();
        }

        private void ClearDialogHostFields()
        {
            Txt_ServiceTypeName.Text = "";
            Txt_ServiceTypeCost.Text = "";
        }

        private void Txt_ServiceTypeID_TextChanged(object sender, TextChangedEventArgs e)
        {
            InfoServiceType.Visibility = Visibility.Visible;
        }
    }
}
