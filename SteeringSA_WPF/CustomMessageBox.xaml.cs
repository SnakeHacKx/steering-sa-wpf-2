using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SteeringSA_WPF
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        private static CustomMessageBox customMessageBox;
        private static DialogResult result = System.Windows.Forms.DialogResult.No;

        public CustomMessageBox()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Tipos de mensajes.
        /// </summary>
        public enum CMessageBoxType
        {
            Error,
            Info,
            Warning,
            Confirm,
            Success
        }

        /// <summary>
        /// Muestra un mensaje personalizado.
        /// </summary>
        /// <param name="message">Mensaje.</param>
        /// <param name="title">Título de la ventana de mensaje</param>
        /// <param name="type">Tipo del mensaje.</param>
        /// <returns></returns>
        public static DialogResult Show(string message, string title, CMessageBoxType type)
        {

            customMessageBox = new CustomMessageBox();
            customMessageBox.Tb_Message.Text = message;

            customMessageBox.Tb_HeaderMessage.Text = title;

            // ICONO
            switch (type)
            {
                case CMessageBoxType.Error:
                    // Icono
                    customMessageBox.messageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Error;
                    customMessageBox.messageIcon.Foreground = Brushes.White;
                    //Color
                    customMessageBox.Pic_Background.Source = new BitmapImage(new Uri(@"/Images/bg_mb_error.png", UriKind.Relative));
                    // Texto
                    customMessageBox.Tb_Message.Foreground = Brushes.White;
                    // Botones
                    customMessageBox.Btn_OK.Visibility = Visibility.Visible;
                    customMessageBox.Btn_Cancel.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_No.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_Yes.Visibility = Visibility.Collapsed;
                    break;

                case CMessageBoxType.Info:
                    // Icono
                    customMessageBox.messageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.InfoCircle;
                    customMessageBox.messageIcon.Foreground = Brushes.White;
                    // Color
                    customMessageBox.Pic_Background.Source = new BitmapImage(new Uri(@"/Images/bg_mb_info.png", UriKind.Relative));
                    // Texto
                    customMessageBox.Tb_Message.Foreground = Brushes.White;
                    // Botones
                    customMessageBox.Btn_OK.Visibility = Visibility.Visible;
                    customMessageBox.Btn_Cancel.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_No.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_Yes.Visibility = Visibility.Collapsed;
                    break;

                case CMessageBoxType.Warning:
                    // Icono
                    customMessageBox.messageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Warning;
                    customMessageBox.messageIcon.Foreground = Brushes.Black;
                    // Color
                    customMessageBox.Pic_Background.Source = new BitmapImage(new Uri(@"/Images/bg_mb_warning.png", UriKind.Relative));
                    // Texto
                    customMessageBox.Tb_Message.Foreground = Brushes.Black;
                    // Botones
                    customMessageBox.Btn_OK.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_Cancel.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_No.Visibility = Visibility.Visible;
                    customMessageBox.Btn_Yes.Visibility = Visibility.Visible;
                    break;

                case CMessageBoxType.Confirm:
                    // Icono
                    customMessageBox.messageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.QuestionMark;
                    customMessageBox.messageIcon.Foreground = Brushes.White;
                    // Color
                    customMessageBox.Pic_Background.Source = new BitmapImage(new Uri(@"/Images/bg_mb_info.png", UriKind.Relative));
                    // Texto
                    customMessageBox.Tb_Message.Foreground = Brushes.White;
                    // Botones
                    customMessageBox.Btn_OK.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_Cancel.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_No.Visibility = Visibility.Visible;
                    customMessageBox.Btn_Yes.Visibility = Visibility.Visible;
                    break;

                case CMessageBoxType.Success:
                    // Icono
                    customMessageBox.messageIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckBold;
                    customMessageBox.messageIcon.Foreground = Brushes.Black;
                    // Color
                    customMessageBox.Pic_Background.Source = new BitmapImage(new Uri(@"/Images/bg_mb_success.png", UriKind.Relative));
                    // Texto
                    customMessageBox.Tb_Message.Foreground = Brushes.Black;
                    // Botones
                    customMessageBox.Btn_OK.Visibility = Visibility.Visible;
                    customMessageBox.Btn_Cancel.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_No.Visibility = Visibility.Collapsed;
                    customMessageBox.Btn_Yes.Visibility = Visibility.Collapsed;
                    break;
            }

            customMessageBox.ShowDialog();
            return result;
        }

        /// <summary>
        /// Permite mover la ventana al mantener pulsado la parte de arriba.
        /// </summary>
        private void Body_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Botón de OK que aparece en la ventana de mensaje.
        /// </summary>
        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.OK;
            customMessageBox.Close();
        }


        //private void Btn_Yes_Click(object sender, RoutedEventArgs e)
        //{
        //    result = System.Windows.Forms.DialogResult.Yes;
        //    customMessageBox.Close();
        //}

        //private void Btn_OK_Click(object sender, RoutedEventArgs e)
        //{
        //    result = System.Windows.Forms.DialogResult.OK;
        //    customMessageBox.Close();
        //}

        //private void Btn_No_Click(object sender, RoutedEventArgs e)
        //{
        //    result = System.Windows.Forms.DialogResult.No;
        //    customMessageBox.Close();
        //}

        //private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        //{
        //    result = System.Windows.Forms.DialogResult.Cancel;
        //    customMessageBox.Close();
        //}
    }
}
