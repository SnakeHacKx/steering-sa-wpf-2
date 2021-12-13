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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            CRUD.GenericCRUD.Instance.GetRecordsCount();
            Tb_ClientCount.Text = CRUD.GenericCRUD.Instance.ClientCount;
            Tb_DriverCount.Text = CRUD.GenericCRUD.Instance.DriverCount;
            Tb_VehicleCount.Text = CRUD.GenericCRUD.Instance.VehicleCount;
            Tb_ReportCount.Text = CRUD.GenericCRUD.Instance.ReportCount;
            Tb_MaintenanceCount.Text = CRUD.GenericCRUD.Instance.MaintenanceCount;
            Tb_ServicesCount.Text = CRUD.GenericCRUD.Instance.ServiceCount;
        }

        /// <summary>
        /// Cambia a la pantalla de ver clientes.
        /// </summary>
        private void Btn_ViewClients_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_CLIENTS, new ClientViewModel());
        }

        /// <summary>
        /// Cambia a la pantalla de ver conductores.
        /// </summary>
        private void Btn_ViewDrivers_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_DRIVERS, new DriverViewModel());
        }

        /// <summary>
        /// Cambia a la pantalla de ver vehículos.
        /// </summary>
        private void Btn_ViewVehicles_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_VEHICLES, new VehicleViewModel());
        }

        /// <summary>
        /// Cambia a la pantalla de ver reportes.
        /// </summary>
        private void Btn_ViewReports_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_REPORTS, new ReportViewModel());
        }

        /// <summary>
        /// Cambia a la pantalla de ver mantenimientos.
        /// </summary>
        private void Btn_ViewMaintenances_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_MAINTENANCE, new MaintenanceViewModel());
        }

        /// <summary>
        /// Cambia a la pantalla de ver servicios.
        /// </summary>
        private void Btn_ViewServices_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_SERVICES, new ServicesViewModel());
        }

        private void Btn_ShowHistory_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HISTORY, new HistoryViewModel());
        }

        private void Btn_ShowUsers_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_USERS, new UserViewModel());
        }
    }
}
