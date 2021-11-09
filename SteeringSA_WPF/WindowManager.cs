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
    }
}
