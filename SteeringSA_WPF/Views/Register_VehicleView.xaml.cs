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
    /// Interaction logic for Register_VehicleView.xaml
    /// </summary>
    public partial class Register_VehicleView : UserControl
    {
        public Register_VehicleView()
        {
            InitializeComponent();
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearFormFields()
        {
            Txt_Matricula.Text = "";
            Txt_Motor.Text = "";
            Cb_Color.Text = "";
            Cb_Fuel.Text = "";
            Cb_MaxPassengerNumber.Text = "";
            Cb_VehicleType.Text = "";
        }

        private void Btn_AddVehicle_Click(object sender, RoutedEventArgs e)
        {
            CRUD.Vehicle.Instance.Register(Txt_Matricula.Text,
                Txt_Motor.Text, 
                Cb_VehicleType.Text,
                int.Parse(Cb_MaxPassengerNumber.Text), 
                Cb_Fuel.Text, Cb_Color.Text);

            ClearFormFields();
        }
    }
}
