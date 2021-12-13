using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SteeringSA_WPF
{
    public static class WindowManager
    {
        public static string ClientID { get; set; }
        public static string DriverID { get; set; }
        public static string VehicleID { get; set; }
        public static string ReportID { get; set; }
        public static string ServiceID { get; set; }
        public static string MaintenanceID { get; set; }
        public static string Username { get; set; }
        public static string ChosenDriver { get; set; }
        public static string ChosenClient { get; set; }
        public static string ChosenReport { get; set; }
        public static string ChosenMaintenance { get; set; }
        public static string ChosenVehicle { get; set; }
        public static string ChosenService { get; set; }
        public static string ChosenServiceType { get; set; }

        /// <summary>
        /// Cambia la ventana (control de usuario) presentado actualmente por uno nuevo.
        /// </summary>
        /// <param name="newWindowName">Nombre de la nueva ventana</param>
        /// <param name="userControl">Nueva ventana</param>
        public static void ChangeWindow(string newWindowName, object userControl)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Tb_WindowTitle.Text = newWindowName;
                    (window as MainWindow).DataContext = userControl;
                }
            }
        }

        /// <summary>
        /// Cambia solamente el nombre de la ventana
        /// </summary>
        /// <param name="newWindowName">Nuevo nombre de la ventana</param>
        public static void ChangeWindowName(string newWindowName)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Tb_WindowTitle.Text = newWindowName;
                }
            }
        }

        public static void ShowWindow(Window window)
        {
            window.ShowDialog();
        }

        public static void ChangeUsername(string username)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).Tb_Username.Text = username;
                    (window as MainWindow).Wp_Username.Visibility = Visibility.Visible;
                    (window as MainWindow).Img_Logo.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
