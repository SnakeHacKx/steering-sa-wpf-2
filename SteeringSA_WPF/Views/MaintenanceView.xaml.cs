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
    /// Interaction logic for MaintenanceView.xaml
    /// </summary>
    public partial class MaintenanceView : UserControl
    {
        private bool isFilterGridOpen;
        private string chosenMaintenanceID;

        public MaintenanceView()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
        }

        /// <summary>
        /// Botón que permite ver el perfil del vehículo
        /// </summary>
        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Botón ir a la pantalla anterior.
        /// </summary>
        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new ViewModels.HomeViewModel());
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

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_MaintenanceData, TableID.MAINTENANCE, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_MAINTENANCE), ref Tb_RecordCount);
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string minCost;
            string maxCost;
            string beginDate;
            string endDate;
            string state;
            string vehicleID;
            string vehicleType;

            if (Txt_MinCost.Text == "") minCost = null;
            else minCost = Txt_MinCost.Text;

            if (Txt_MaxCost.Text == "") maxCost = null;
            else maxCost = Txt_MaxCost.Text;

            if (Dtp_MaintenanceBeginDate.Text == "") beginDate = null;
            else beginDate = Dtp_MaintenanceBeginDate.Text;

            if (Dtp_MaintenanceEndDate.Text == "") endDate = null;
            else endDate = Dtp_MaintenanceEndDate.Text;

            if (Txt_VehicleID.Text == "") vehicleID = null;
            else vehicleID = Txt_VehicleID.Text;

            if (Cb_State.Text == "-") state = null;
            else state = Cb_State.Text;

            if (Cb_VehicleType.Text == "") vehicleType = null;
            else vehicleType = Cb_VehicleType.Text;


            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_MaintenanceData, TableID.MAINTENANCE, CRUD.Maintenance.Instance.FilterBy(minCost, maxCost, beginDate, endDate, vehicleID, vehicleType), ref Tb_RecordCount);
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_MaintenanceData, TableID.MAINTENANCE, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_MAINTENANCE_BYCODE,
                TableID.MAINTENANCE, Txt_MaintenanceID.Text), ref Tb_RecordCount);
        }

        private void Btn_EditMaintenance_Click(object sender, RoutedEventArgs e)
        {
            Windows.Edit_Maintenance editMaintenance = new Windows.Edit_Maintenance(chosenMaintenanceID);
            editMaintenance.RefreshDatagrid += new Windows.Edit_Maintenance.DRefreshDatagrid(RefreshDataGrid);
            editMaintenance.ShowDialog();
        }

        private void Dgv_MaintenanceData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                chosenMaintenanceID = columnValue;
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("Esta acción hará un cambio permanente en la base de datos ¿Está seguro/a que desea realizarla?",
                "Eliminar Mantenimiento",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Maintenance.Instance.Delete(chosenMaintenanceID);
                RefreshDataGrid();
            }
        }
    }
}
  