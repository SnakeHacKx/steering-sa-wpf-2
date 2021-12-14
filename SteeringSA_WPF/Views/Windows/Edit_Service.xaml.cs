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

namespace SteeringSA_WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for Edit_Service.xaml
    /// </summary>
    public partial class Edit_Service : Window
    {
        private string serviceID;
        public delegate void DRefreshDatagrid();
        public event DRefreshDatagrid RefreshDatagrid;

        public Edit_Service(string serviceID)
        {
            InitializeComponent();
            this.serviceID = serviceID;
            GetServiceInfo();
        }

        private void GetServiceInfo()
        {
            CRUD.Service.Instance.ReadFields(StoreProcedure.SEARCH_SERVICE_BYCODE, serviceID);

            Txt_ServiceTypeID.Text = CRUD.Service.Instance.ServiceTypeID;
            Tb_ClientDNI.Text = CRUD.Service.Instance.ClientID;
            Txt_DriverDNI.Text = CRUD.Service.Instance.DriverID;
            Txt_VehicleRegistration.Text = CRUD.Service.Instance.VehicleID;
            Dtp_ServiceBeginDate.Text = CRUD.Service.Instance.BeginDate;
            Dtp_ServiceEndDate.Text = CRUD.Service.Instance.EndDate;
            Txt_Description.Document.Blocks.Clear();
            Txt_Description.Document.Blocks.Add(new Paragraph(new Run(CRUD.Service.Instance.Description)));

            ChangeServiceTypeInfo();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_ChooseVehicle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ChooseServiceType_Click(object sender, RoutedEventArgs e)
        {
            Choose_ServiceType chooseServiceType = new Choose_ServiceType();
            chooseServiceType.ChangeServiceTypeID += new Choose_ServiceType.DChangeServiceTypeID(ChangeServiceTypeID);
            chooseServiceType.ShowDialog();
        }

        public void ChangeServiceTypeID()
        {
            Txt_ServiceTypeID.Text = WindowManager.ChosenServiceType;
            ChangeServiceTypeInfo();
        }

        private void ChangeServiceTypeInfo()
        {
            Tb_ServiceTypeCode.Text = Txt_ServiceTypeID.Text;
            CRUD.ServiceType.Instance.ReadFields(StoreProcedure.SEARCH_TYPE_SERVICE_BYCODE, Txt_ServiceTypeID.Text);
            Tb_ServiceTypeName.Text = CRUD.ServiceType.Instance.Nombre;
            Tb_ServiceTypeCost.Text = CRUD.ServiceType.Instance.Costo_Dia.ToString();
        }

        private void Btn_ChooseDriver_Click(object sender, RoutedEventArgs e)
        {
            Choose_Driver chooseDriver = new Choose_Driver();
            chooseDriver.ChangeDriverID += new Choose_Driver.DChangeDriverID(ChangeDriverID);
            chooseDriver.ShowDialog();
        }

        public void ChangeDriverID()
        {
            Txt_DriverDNI.Text = WindowManager.ChosenDriver;
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

        private void Btn_AddServiceType_Click(object sender, RoutedEventArgs e)
        {
            Dh_AddServiceType.ShowDialog(Dh_AddServiceType.DialogContent);
           
        }

        private void Btn_EditService_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea editar este servicio?",
                "Editar Servicio",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;

                description = description.Replace("\n", "").Replace("\r", "");

                CRUD.Service.Instance.Edit(serviceID,
                    Txt_ServiceTypeID.Text,
                    Txt_DriverDNI.Text,
                    Tb_ClientDNI.Text,
                    Txt_VehicleRegistration.Text,
                    Dtp_ServiceBeginDate.Text,
                    Dtp_ServiceEndDate.Text,
                    description);

                RefreshDatagrid();
                Close();
            }
        }
    }
}
