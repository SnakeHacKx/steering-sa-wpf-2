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
        public DriverView()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.DRIVER_PROFILE, new Profile_DriverViewModel());
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new HomeViewModel());
        }

        private void Btn_AddDriver_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.ADD_DRIVERS, new Register_DriverViewModel());
        }

        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_DriversData, TableID.DRIVER, GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SELECT_DRIVER_ALL), ref Tb_RecordCount);
        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
