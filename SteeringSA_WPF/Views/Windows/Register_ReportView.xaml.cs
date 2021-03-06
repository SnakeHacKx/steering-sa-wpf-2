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
    /// Interaction logic for Register_ReportView.xaml
    /// </summary>
    public partial class Register_ReportView : Window
    {
        private string vehicleID;
        public Register_ReportView(string vehicleID)
        {
            InitializeComponent();
            this.vehicleID = vehicleID;
            Tb_TodaysDate.Text = DateTime.Now.ToString();
            Tb_VehicleRegistration.Text = vehicleID;
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_AddReport_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea registrar este reporte?",
                "Registrar Reporte",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string description = new TextRange(Txt_Description.Document.ContentStart, Txt_Description.Document.ContentEnd).Text;

                description = description.Replace("\n", "").Replace("\r", "");

                CRUD.Report.Instance.Register(Tb_VehicleRegistration.Text,
                    description,
                    Tb_TodaysDate.Text);
                ClearFormFields();
            }
        }

        private void ClearFormFields()
        {
            Txt_Description.Document.Blocks.Clear();
            Txt_Description.Document.Blocks.Add(new Paragraph(new Run("")));
        }
    }
}
