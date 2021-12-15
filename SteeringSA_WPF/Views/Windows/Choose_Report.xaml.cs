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
    /// Interaction logic for Choose_Report.xaml
    /// </summary>
    public partial class Choose_Report : Window
    {
        private bool isFilterGridOpen;
        public delegate void DChangeReportID();
        public event DChangeReportID ChangeReportID;

        public Choose_Report()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ReportsData, TableID.REPORT, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_REPORT_BYCODE,
                TableID.REPORT, Txt_IDReport.Text), ref Tb_RecordCount);
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ReportsData, TableID.REPORT, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_REPORT), ref Tb_RecordCount);
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string beginDate;
            string endDate;
            string state;

            if (Dtp_MaintenanceDateMin.Text == "")
            {
                beginDate = null;
            }
            else beginDate = Dtp_MaintenanceDateMin.Text;

            if (Dtp_MaintenanceDateMax.Text == "")
            {
                endDate = null;
            }
            else endDate = Dtp_MaintenanceDateMax.Text;

            if (Cb_State.Text == "-") state = null;
            else state = Cb_State.Text;

            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ReportsData, TableID.REPORT, CRUD.Report.Instance.FilterBy(beginDate, endDate, state), ref Tb_RecordCount);
        }

        private void Btn_ChooseReport_Click(object sender, RoutedEventArgs e)
        {
            ChangeReportID();
            Close();
        }

        private void Dgv_ReportsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                WindowManager.ChosenReport = columnValue;
            }
        }
    }
}
