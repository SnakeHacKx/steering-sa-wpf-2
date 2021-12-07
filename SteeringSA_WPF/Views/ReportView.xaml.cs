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
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        private bool isFilterGridOpen;
        public ReportView()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }

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
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ReportsData, TableID.REPORT, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_REPORT), ref Tb_RecordCount);
        }

        /// <summary>
        /// Botón para refrescar el DataGrid.
        /// </summary>
        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Dtp_MaintenanceDateMin.Text = "";
            Dtp_MaintenanceDateMax.Text = "";
        }
    }
}
