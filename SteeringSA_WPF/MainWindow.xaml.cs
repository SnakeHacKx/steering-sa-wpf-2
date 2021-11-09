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

namespace SteeringSA_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tb_WindowTitle.Text = WindowsTitle.LOGIN;
            DataContext = new LoginViewModel();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        /// <summary>
        /// Evento que permite crear un borde a la ventana cuando esta no está maximizada.
        /// </summary>
        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            if (this.WindowState == WindowState.Normal)
            {

                MainWindowBorder.BorderThickness = new Thickness(1);
                MainWindowBorder.BorderBrush = (Brush)bc.ConvertFrom("#4FCDF5");
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                MainWindowBorder.BorderThickness = new Thickness(0);
            }
        }

        /// <summary>
        /// Permite arrastrar la ventana al dejar hundido el botón izquierdo del ratón en la parte de arriba de esta.
        /// </summary>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        private void Btn_ShutdownApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Maximiza la aplicación si esta se encuentra en modo normal, de lo contrario, minimiza la ventana a su estado normal.
        /// </summary>
        private void Btn_MaximizeWindow_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        /// <summary>
        /// Minimiza la ventana por completo.
        /// </summary>
        private void Btn_MinimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
