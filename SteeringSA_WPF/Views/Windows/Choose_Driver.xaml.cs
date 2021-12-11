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
    /// Interaction logic for Choose_Driver.xaml
    /// </summary>
    public partial class Choose_Driver : Window
    {
        private bool isFilterGridOpen;

        public Choose_Driver()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = false;
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_DriversData, TableID.DRIVER, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_DRIVER_BYID,
                TableID.DRIVER, Txt_DriverDNI.Text), ref Tb_RecordCount);
        }

        private void Txt_MaxAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utilities.IsInputNumeric(e.Text);
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
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_DriversData, TableID.DRIVER, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_DRIVER), ref Tb_RecordCount);
            Txt_DriverName.Text = "";
            Cb_LicenseType.Text = "-";
            Txt_MinAge.Text = "";
            Txt_MaxAge.Text = "";
            Txt_DriverDNI.Text = "";
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            string license = "";
            string minAge = "";
            string maxAge = "";

            if (Txt_DriverName.Text == "") name = null;
            else name = Txt_DriverName.Text;

            if (Cb_LicenseType.Text == "-") license = null;
            else license = Cb_LicenseType.Text;

            if (Txt_MinAge.Text == "") minAge = null;
            else minAge = Txt_MinAge.Text;

            if (Txt_MaxAge.Text == "") maxAge = null;
            else maxAge = Txt_MaxAge.Text;

            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_DriversData, TableID.DRIVER, CRUD.Driver.Instance.FilterBy(name, license, minAge, maxAge), ref Tb_RecordCount);
        }

        private void Txt_MinAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Utilities.IsInputNumeric(e.Text);
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_ChooseDriver_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
