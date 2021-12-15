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
    /// Interaction logic for Choose_Vehicle.xaml
    /// </summary>
    public partial class Choose_Vehicle : Window
    {
        private bool isFilterGridOpen;
        public delegate void DChangeVehicleID();
        public event DChangeVehicleID ChangeVehicleID;

        public Choose_Vehicle()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
        }

        private void Dgv_VehiclesData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                WindowManager.ChosenVehicle = columnValue;
            }
        }

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_VehiclesData, TableID.VEHICLE, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_AVAILABLE_VEHICLES), ref Tb_RecordCount);
            ClearInputs();
        }

        private void ClearInputs()
        {
            Txt_VehicleRegistration.Text = "";
            Txt_MaxPassengerCount.Text = "";
            Txt_MinPassengerCount.Text = "";
            Txt_VehicleModel.Text = "";
            Cb_Color.Text = "-";
            Cb_Fuel.Text = "-";
            Cb_State.Text = "-";
            Cb_VehicleType.Text = "-";
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Btn_TogggleFilters_Click(object sender, RoutedEventArgs e)
        {
            if (isFilterGridOpen)
            {
                isFilterGridOpen = false;
                Bor_Filters.Visibility = Visibility.Collapsed;
                Btn_TogggleFilters.Content = "Mostrar Filtros";
            }
            else
            {
                isFilterGridOpen = true;
                Bor_Filters.Visibility = Visibility.Visible;
                Btn_TogggleFilters.Content = "Ocultar Filtros";
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_VehiclesData, TableID.VEHICLE, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_VEHICLE_BYPLACA,
                TableID.VEHICLE, Txt_VehicleRegistration.Text), ref Tb_RecordCount);
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string color;
            string minPassengers;
            string maxPassengers;
            string fuelType;
            string vehicleType;
            string vehicleModel;
            string state;

            if (Cb_Color.Text == "-") color = null;
            else color = Cb_Color.Text;

            if (Txt_MinPassengerCount.Text == "") minPassengers = null;
            else minPassengers = Txt_MinPassengerCount.Text;

            if (Txt_MaxPassengerCount.Text == "") maxPassengers = null;
            else maxPassengers = Txt_MaxPassengerCount.Text;

            if (Cb_Fuel.Text == "-") fuelType = null;
            else fuelType = Cb_Fuel.Text;

            if (Cb_VehicleType.Text == "-") vehicleType = null;
            else vehicleType = Cb_VehicleType.Text;

            if (Txt_VehicleModel.Text == "") vehicleModel = null;
            else vehicleModel = Txt_VehicleModel.Text;

            if (Cb_State.Text == "-") state = null;
            else state = Cb_State.Text;

            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_VehiclesData, TableID.VEHICLE, CRUD.Vehicle.Instance.FilterBy(vehicleModel, vehicleType, minPassengers, maxPassengers, fuelType, state, color), ref Tb_RecordCount);
        }

        private void Btn_ChooseVehicle_Click(object sender, RoutedEventArgs e)
        {
            ChangeVehicleID();
            Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
