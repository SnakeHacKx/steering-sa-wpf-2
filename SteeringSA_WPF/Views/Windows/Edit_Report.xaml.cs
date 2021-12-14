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
    /// Interaction logic for Edit_Report.xaml
    /// </summary>
    public partial class Edit_Report : Window
    {
        private string reportID;
        public delegate void DRefreshDatagrid();
        public event DRefreshDatagrid RefreshDatagrid;

        public Edit_Report(string reportID)
        {
            InitializeComponent();
            this.reportID = reportID;
            GetDriverInfo();
        }

        private void GetDriverInfo()
        {
            CRUD.Report.Instance.ReadFields(StoreProcedure.SEARCH_REPORT_BYCODE, reportID);

            Tb_VehicleRegistration.Text = CRUD.Report.Instance.PlacaVehiculo;
            Tb_TodaysDate.Text = CRUD.Report.Instance.Fecha;
            Txt_Description.Document.Blocks.Clear();
            Txt_Description.Document.Blocks.Add(new Paragraph(new Run(CRUD.Report.Instance.Descripcion)));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_EditReport_Click(object sender, RoutedEventArgs e)
        {
            string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;

            description = description.Replace("\n", "").Replace("\r", "");

            CRUD.Report.Instance.Edit(reportID, Tb_VehicleRegistration.Text, description, Tb_TodaysDate.Text);
            RefreshDatagrid();
            Close();
        }
    }
}
