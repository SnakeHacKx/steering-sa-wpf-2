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
    /// Interaction logic for AppReportView.xaml
    /// </summary>
    public partial class AppReportView : UserControl
    {
        public AppReportView()
        {
            InitializeComponent();
            CRUD.AppSummary.Instance.ReadFields();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Tb_Balance.Text = CRUD.AppSummary.Instance.Balance;
            Tb_ClientsCount.Text = CRUD.AppSummary.Instance.ClientsCount;
            Tb_Deletes.Text = CRUD.AppSummary.Instance.Deletes;
            Tb_DriversCount.Text = CRUD.AppSummary.Instance.DriversCount;
            Tb_Edits.Text = CRUD.AppSummary.Instance.Edits;
            Tb_Expenses.Text = CRUD.AppSummary.Instance.Expenses;
            Tb_MaintenancesCount.Text = CRUD.AppSummary.Instance.MaintenanceCount;
            Tb_Profits.Text = CRUD.AppSummary.Instance.Profits;
            Tb_Registers.Text = CRUD.AppSummary.Instance.Registers;
            Tb_ReportsCount.Text = CRUD.AppSummary.Instance.ReportsCount;
            Tb_ServiceTypesCount.Text = CRUD.AppSummary.Instance.ServicesCount;
            Tb_TotalActions.Text = CRUD.AppSummary.Instance.TotalActions;
            Tb_VehiclesCount.Text = CRUD.AppSummary.Instance.VehiclesCount;
        }
    }
}
