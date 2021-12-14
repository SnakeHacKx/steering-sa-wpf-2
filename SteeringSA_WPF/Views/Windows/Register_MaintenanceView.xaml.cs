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

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for Register_MaintenanceView.xaml
    /// </summary>
    public partial class Register_MaintenanceView : Window
    {
        private string vehicleID;
        private bool isRoutineMaintenance;
        public Register_MaintenanceView(string vehicleID)
        {
            InitializeComponent();
            this.vehicleID = vehicleID;
            Tb_VehicleRegistration.Text = vehicleID;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_FindReport_Click(object sender, RoutedEventArgs e)
        {
            Windows.Choose_Report chooseReport = new Windows.Choose_Report();
            chooseReport.ChangeReportID += new Windows.Choose_Report.DChangeReportID(ChangeReportID);
            chooseReport.ShowDialog();
        }

        public void ChangeReportID()
        {
            Txt_ReportID.Text = WindowManager.ChosenReport;
        }

        private void Btn_AddMaintenance_Click(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;

            description = description.Replace("\n", "").Replace("\r", "");

            CRUD.Maintenance.Instance.Register(Tb_VehicleRegistration.Text,
                Txt_ReportID.Text,
                Txt_Cost.Text,
                Dtp_MaintenanceDate.Text,
                description,
                Cb_MaintenanceState.Text);
            ClearFormFields();
        }

        private void ClearFormFields()
        {
            Txt_ReportID.Text = "";
            Txt_Cost.Text = "";
            Dtp_MaintenanceDate.Text = "";
            Txt_Description.Document.Blocks.Clear();
            Txt_Description.Document.Blocks.Add(new Paragraph(new Run("")));
        }

        private void Btn_ChooseMaintenanceType_Click(object sender, RoutedEventArgs e)
        {
            FormMaintenanceType.Visibility = Visibility.Collapsed;
            BigForm.Visibility = Visibility.Visible;

            if (Cb_MaintenanceType.Text == "Rutinario")
            {
                //VehicleRegistration.Visibility = Visibility.Visible;
                isRoutineMaintenance = true;
            }
            else
            {
                //VehicleRegistration.Visibility = Visibility.Collapsed;
                isRoutineMaintenance = false;
            }
        }

        private void Btn_SetS_RMaintenance_Click(object sender, RoutedEventArgs e)
        {
            Txt_ReportID.Text = "S/R";
        }
    }
}
