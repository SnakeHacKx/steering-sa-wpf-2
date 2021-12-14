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
    /// Interaction logic for Edit_Vehicle.xaml
    /// </summary>
    public partial class Edit_Vehicle : Window
    {
        private string vehicleID;
        public delegate void DRefreshProfileInfo();
        public event DRefreshProfileInfo RefreshProfileInfo;

        public Edit_Vehicle(string vehicleID)
        {
            InitializeComponent();
            GetVehicleInfo();
            this.vehicleID = vehicleID;
        }

        private void GetVehicleInfo()
        {
            Txt_Model.Text = CRUD.Vehicle.Instance.Modelo;
            Cb_VehicleType.Text = CRUD.Vehicle.Instance.Tipo;
            Cb_Fuel.Text = CRUD.Vehicle.Instance.TipoCombustible;
            Cb_Color.Text = CRUD.Vehicle.Instance.Color;
            Cb_MaxPassengerNumber.Text = CRUD.Vehicle.Instance.Pasajeros.ToString();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_EditVehicle_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea editar este vehículo?",
                "Editar Vehículo",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Vehicle.Instance.Edit(vehicleID,
                Txt_Model.Text,
                Cb_VehicleType.Text,
                int.Parse(Cb_MaxPassengerNumber.Text),
                Cb_Fuel.Text, Cb_Color.Text);
                RefreshProfileInfo();
                Close();
            }
        }
    }
}
