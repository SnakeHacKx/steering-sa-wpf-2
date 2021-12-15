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
    /// Interaction logic for Register_DriverView.xaml
    /// </summary>
    public partial class Register_DriverView : UserControl
    {
        public Register_DriverView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ir a la ventana anterior.
        /// </summary>
        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_DRIVERS, new ViewModels.DriverViewModel());
        }

        /// <summary>
        /// Botón de registrar el conductor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddDriver_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea registrar este conductor?",
                "Registrar Conductor",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.Driver.Instance.Register(Txt_DNI.Text,
                Txt_Name.Text,
                Txt_Surname.Text,
                Txt_PhoneNumber.Text,
                Dtp_BirthDate.Text,
                Cb_BloodType.Text,
                Cb_LicenseType.Text);
                ClearFormFields();
            }
        }

        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void ClearFormFields()
        {
            Txt_DNI.Text = "";
            Txt_Name.Text = "";
            Txt_Surname.Text = "";
            Txt_PhoneNumber.Text = "";
            Dtp_BirthDate.SelectedDate = new DateTime(1950, 1, 1);
            Cb_BloodType.Text = "";
            Cb_LicenseType.Text = "";
            Cb_BloodType.SelectedItem = null;
            Cb_LicenseType.SelectedItem = null;
        }

        /// <summary>
        /// Evento que al cambiar la fecha, verifica si el conductor es mayor de edad.
        /// </summary>
        private void Dtp_BirthDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int ageInYears = GetDifferenceInYears(Dtp_BirthDate.SelectedDate.Value, DateTime.Today);

            if (ageInYears < 18)
            {
                CustomMessageBox.Show("El conductor debe ser mayor de edad", "Error", CustomMessageBox.CMessageBoxType.Error);
                Dtp_BirthDate.SelectedDate = DateTime.Today;
            }
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
    }
}
