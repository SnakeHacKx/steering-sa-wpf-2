using SteeringSA_WPF.CRUD;
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
    /// Interaction logic for DriverView.xaml
    /// </summary>
    public partial class DriverView : UserControl
    {
        private bool isFilterGridOpen;
        public DriverView()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = false;
        }

        /// <summary>
        /// Botón ver pefil del conductor.
        /// </summary>
        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.DRIVER_PROFILE, new Profile_DriverViewModel());
        }

        /// <summary>
        /// Botón volver a la ventana anterior.
        /// </summary>
        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new HomeViewModel());
        }

        /// <summary>
        /// Botón que nos lleva a la ventana de añadir conductor.
        /// </summary>
        private void Btn_AddDriver_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.ADD_DRIVERS, new Register_DriverViewModel());
        }

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_DriversData, TableID.DRIVER, GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_DRIVER), ref Tb_RecordCount);
        }

        /// <summary>
        /// Botón para refrescar el DataGrid.
        /// </summary>
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
    }
}
