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
    /// Interaction logic for Edit_Maintenance.xaml
    /// </summary>
    public partial class Edit_Maintenance : Window
    {
        private string maintenanceID;
        public delegate void DRefreshDatagrid();
        public event DRefreshDatagrid RefreshDatagrid;

        public Edit_Maintenance(string maintenanceID)
        {
            InitializeComponent();
            this.maintenanceID = maintenanceID;
            GetDriverInfo();
        }

        private void GetDriverInfo()
        {
            CRUD.Maintenance.Instance.ReadFields(StoreProcedure.SEARCH_MAINTENANCE_BYCODE, maintenanceID);

            Tb_VehicleRegistration.Text = CRUD.Maintenance.Instance.PlacaVehiculo;
            Txt_ReportID.Text = CRUD.Maintenance.Instance.IDReporte;
            Txt_Cost.Text = CRUD.Maintenance.Instance.Costo.ToString();
            Txt_Description.Document.Blocks.Clear();
            Txt_Description.Document.Blocks.Add(new Paragraph(new Run(CRUD.Maintenance.Instance.Descripcion)));
            Cb_MaintenanceState.Text = CRUD.Maintenance.Instance.Estado;
            Dtp_MaintenanceDate.Text = CRUD.Maintenance.Instance.Fecha;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        private void Btn_EditMaintenance_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea editar este mantenimiento?",
                "Editar Mantenimiento",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;

                //description = System.Text.RegularExpressions.Regex.Replace(description, @"\s+", string.Empty);
                description = description.Replace("\n", "").Replace("\r", "");

                CRUD.Maintenance.Instance.Edit(int.Parse(maintenanceID), Tb_VehicleRegistration.Text,
                    Txt_ReportID.Text,
                    Txt_Cost.Text,
                    Dtp_MaintenanceDate.Text,
                    description,
                    Cb_MaintenanceState.Text);

                RefreshDatagrid();
                Close();
            }
        }

        private void Btn_SetSRMaintenance_Click(object sender, RoutedEventArgs e)
        {
            Txt_ReportID.Text = "S/R";
        }
    }
}
