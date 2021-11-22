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
    /// Interaction logic for MaintenanceView.xaml
    /// </summary>
    public partial class MaintenanceView : UserControl
    {
        public MaintenanceView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Botón que permite ver el perfil del vehículo
        /// </summary>
        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Botón ir a la pantalla anterior.
        /// </summary>
        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new ViewModels.HomeViewModel());
        }
    }
}
