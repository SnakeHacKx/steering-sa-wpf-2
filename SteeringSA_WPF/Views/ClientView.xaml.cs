using SteeringSA_WPF.ViewModels;
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
    /// Interaction logic for ClientView.xaml
    /// </summary>
    public partial class ClientView : UserControl
    {
        private bool isFilterGridOpen;

        public ClientView()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.CLIENT_PROFILE, new ClientProfileViewModel());
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new HomeViewModel());
        }

        private void Btn_AddClient_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.ADD_CLIENTE, new Register_ClientViewModel());
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
            Txt_Address.Text = "";
            Txt_ClientDNI.Text = "";
            Txt_ClientName.Text = "";
            Txt_MaxAge.Text = "";
            Txt_MinAge.Text = "";
        }

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ClientsData, TableID.CLIENT, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_CLIENT), ref Tb_RecordCount);
        }

        private void Dgv_ClientsData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                WindowManager.ClientID = columnValue;
            }
        }

        private void Txt_MinAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Txt_MaxAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ClientsData, TableID.DRIVER, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_CLIENT_BYID,
                TableID.CLIENT, Txt_ClientDNI.Text), ref Tb_RecordCount);
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            string address = "";
            string minAge = "";
            string maxAge = "";

            if (Txt_ClientName.Text == "") name = null;
            else name = Txt_ClientName.Text;

            if (Txt_Address.Text == "-") address = null;
            else address = Txt_Address.Text;

            if (Txt_MinAge.Text == "") minAge = null;
            else minAge = Txt_MinAge.Text;

            if (Txt_MaxAge.Text == "") maxAge = null;
            else maxAge = Txt_MaxAge.Text;

            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ClientsData, TableID.CLIENT, CRUD.Client.Instance.FilterBy(name, address, minAge, maxAge), ref Tb_RecordCount);
        }
    }
}
