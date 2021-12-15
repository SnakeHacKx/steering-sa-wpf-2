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
    /// Interaction logic for Edit_Driver.xaml
    /// </summary>
    public partial class Edit_Driver : Window
    {
        private string driverID;
        public delegate void DRefreshProfileInfo();
        public event DRefreshProfileInfo RefreshProfileInfo;

        public Edit_Driver(string driverID)
        {
            InitializeComponent();
            GetDriverInfo();
            this.driverID = driverID;
        }

        private void GetDriverInfo()
        {
            Txt_Name.Text = CRUD.Driver.Instance.Name;
            Txt_Surname.Text = CRUD.Driver.Instance.Surname;
            Txt_PhoneNumber.Text = CRUD.Driver.Instance.PhoneNumber;
            Cb_BloodType.Text = CRUD.Driver.Instance.BloodType;
            Cb_LicenseType.Text = CRUD.Driver.Instance.LicenseType;
            Dtp_BirthDate.Text = CRUD.Driver.Instance.BirthDate;
        }

        private void Dtp_BirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int ageInYears = GetDifferenceInYears(Dtp_BirthDate.SelectedDate.Value, DateTime.Today);

            if (ageInYears < 18)
            {
                CustomMessageBox.Show("El conductor debe ser mayor de edad", "Error", CustomMessageBox.CMessageBoxType.Error);
                Dtp_BirthDate.SelectedDate = new DateTime(1950, 1, 1);
                return;
            }

            if (Tb_Age != null)
                Tb_Age.Text = ageInYears.ToString();
        }

        /// <summary>
        /// Obtiene la diferencia de años entre dos fechas.
        /// </summary>
        /// <param name="startDate">Fecha inicial.</param>
        /// <param name="endDate">Fecha final.</param>
        /// <returns>La diferencia entre las fechas.</returns>
        private int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            return endDate.Year - startDate.Year - 1 + (((endDate.Month > startDate.Month) || ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_EditDriver_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea editar este conductor?",
                "Editar Conductor",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Driver.Instance.Edit(driverID,
                Txt_Name.Text,
                Txt_Surname.Text,
                Txt_PhoneNumber.Text,
                Dtp_BirthDate.Text,
                Cb_BloodType.Text,
                Cb_LicenseType.Text);
                RefreshProfileInfo();
                Close();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
