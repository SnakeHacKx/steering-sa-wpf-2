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
    /// Interaction logic for Choose_ServiceType.xaml
    /// </summary>
    public partial class Choose_ServiceType : Window
    {
        public delegate void DChangeServiceTypeID();
        public event DChangeServiceTypeID ChangeServiceTypeID;
        private bool isFilterGridOpen;

        public Choose_ServiceType()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
        }

        

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ServicesTypesData, TableID.TYPE_SERVICE, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_TYPE_SERVICE), ref Tb_RecordCount);
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ServicesTypesData, TableID.TYPE_SERVICE, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_TYPE_SERVICE_BYCODE,
                TableID.TYPE_SERVICE, Txt_ServiceTypeID.Text), ref Tb_RecordCount);
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

        private void Dgv_ServicesTypesData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                WindowManager.ChosenServiceType = columnValue;
            }
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
            Txt_MaxCost.Text = "";
            Txt_MinCost.Text = "";
            Txt_ServiceTypeID.Text = "";
            Txt_ServiceTypeNameFilter.Text = "";
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string minCost;
            string maxCost;
            string serviceTypeName;

            if (Txt_MinCost.Text == "") minCost = null;
            else minCost = Txt_MinCost.Text;

            if (Txt_MaxCost.Text == "") maxCost = null;
            else maxCost = Txt_MaxCost.Text;

            if (Txt_ServiceTypeNameFilter.Text == "") serviceTypeName = null;
            else serviceTypeName = Txt_ServiceTypeNameFilter.Text;


            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ServicesTypesData, TableID.TYPE_SERVICE, CRUD.ServiceType.Instance.FilterBy(minCost, maxCost, serviceTypeName), ref Tb_RecordCount);
        }

        private void Btn_ChooseServiceType_Click(object sender, RoutedEventArgs e)
        {
            ChangeServiceTypeID();
            Close();
        }

        private void Btn_EditServiceType_Click(object sender, RoutedEventArgs e)
        {
            Dh_EditServiceType.ShowDialog(Dh_EditServiceType.DialogContent);
            CRUD.ServiceType.Instance.ReadFields(StoreProcedure.SEARCH_TYPE_SERVICE_BYCODE, WindowManager.ChosenServiceType);
            Tb_ServiceTypeID.Text = WindowManager.ChosenServiceType;
            Txt_ServiceTypeName.Text = CRUD.ServiceType.Instance.Nombre;
            Txt_ServiceTypeCost.Text = CRUD.ServiceType.Instance.Costo_Dia.ToString();
        }

        private void Btn_BHAccept_Click(object sender, RoutedEventArgs e)
        {
            CRUD.ServiceType.Instance.Edit(WindowManager.ChosenServiceType, Txt_ServiceTypeName.Text,
                   Txt_ServiceTypeCost.Text);
            ClearDialogHostFields();
            RefreshDataGrid();
        }

        private void ClearDialogHostFields()
        {
            Txt_ServiceTypeName.Text = "";
            Txt_ServiceTypeCost.Text = "";
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (WindowManager.LoggedUserRole == UserRole.ROLE_EMPLOYEE)
            {
                CustomMessageBox.Show("Esta acción no puede ser realizada debido a que su usuario no está autorizado",
                "Eliminar Tipo de Servicio",
                CustomMessageBox.CMessageBoxType.Info);
                return;
            }

            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("Esta acción hará un cambio permanente en la base de datos ¿Está seguro/a que desea realizarla?",
                "Eliminar Tipo de Servicio",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.ServiceType.Instance.Delete(WindowManager.ChosenServiceType);
                RefreshDataGrid();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
