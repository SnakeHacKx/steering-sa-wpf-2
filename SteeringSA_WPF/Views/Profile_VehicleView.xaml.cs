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
    /// Interaction logic for Profile_VehicleView.xaml
    /// </summary>
    public partial class Profile_VehicleView : UserControl
    {
        public Profile_VehicleView()
        {
            InitializeComponent();
            RefreshProfileInfo();
        }

        private void RefreshProfileInfo()
        {
            CRUD.Vehicle.Instance.ReadFields(StoreProcedure.SEARCH_VEHICLE_BYPLACA, WindowManager.VehicleID);

            Tb_VehicleModel.Text = CRUD.Vehicle.Instance.Modelo;
            Tb_Type.Text = CRUD.Vehicle.Instance.Tipo;
            Tb_State.Text = CRUD.Vehicle.Instance.Estado;
            Tb_Fuel.Text = CRUD.Vehicle.Instance.TipoCombustible;
            Tb_Color.Text = CRUD.Vehicle.Instance.Color;
            Tb_Passengers.Text = CRUD.Vehicle.Instance.Pasajeros.ToString();
            Tb_Registration.Text = CRUD.Vehicle.Instance.IDPlaca;
        }

        private void Btn_DeleteVehicle_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("Esta acción hará un cambio permanente en la base de datos ¿Está seguro/a que desea realizarla?",
                "Eliminar Vehículo",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Vehicle.Instance.Delete(Tb_Registration.Text);
                WindowManager.ChangeWindow(WindowsTitle.HOME, new ViewModels.HomeViewModel());
            }
        }

        private void Btn_EditVehicle_Click(object sender, RoutedEventArgs e)
        {
            Windows.Edit_Vehicle editVehicle = new Windows.Edit_Vehicle(Tb_Registration.Text);
            editVehicle.RefreshProfileInfo += new Windows.Edit_Vehicle.DRefreshProfileInfo(RefreshProfileInfo);
            editVehicle.ShowDialog();
        }

        private void Btn_ShowMaintenances_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ShowReports_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_VEHICLES, new ViewModels.VehicleViewModel());
        }

        private void Btn_AddMaintenance_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ShowWindow(new Register_MaintenanceView(Tb_Registration.Text));
        }

        private void Btn_AddReport_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ShowWindow(new Register_ReportView(Tb_Registration.Text));
        }

        private void Btn_DownloadDoc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
