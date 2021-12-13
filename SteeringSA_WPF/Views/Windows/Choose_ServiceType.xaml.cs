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

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ChooseServiceType_Click(object sender, RoutedEventArgs e)
        {
            ChangeServiceTypeID();
            Close();
        }
    }
}
