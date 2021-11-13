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
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        static CustomMessageBox customMessageBox;
        static DialogResult result = System.Windows.Forms.DialogResult.No;

        public enum CMessageBoxType
        {
            Error,
            Info,
            Warning,
            Confirm,
            Success
        }

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
                    customMessageBox.Header.Background = new SolidColorBrush(Color.FromRgb(155, 58, 74));
                    customMessageBox.Body.Background = new SolidColorBrush(Color.FromRgb(233, 87, 111));
                    // Texto
                    customMessageBox.Tb_HeaderMessage.Foreground = Brushes.White;
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
                    customMessageBox.Header.Background = new SolidColorBrush(Color.FromRgb(22, 100, 162));
                    customMessageBox.Body.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
                    // Texto
                    customMessageBox.Tb_HeaderMessage.Foreground = Brushes.White;
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
                    customMessageBox.Header.Background = new SolidColorBrush(Color.FromRgb(229, 223, 49));
                    customMessageBox.Body.Background = new SolidColorBrush(Color.FromRgb(232, 232, 119));
                    // Texto
                    customMessageBox.Tb_HeaderMessage.Foreground = Brushes.Black;
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
                    customMessageBox.Header.Background = new SolidColorBrush(Color.FromRgb(22, 100, 162));
                    customMessageBox.Body.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
                    // Texto
                    customMessageBox.Tb_HeaderMessage.Foreground = Brushes.White;
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
                    customMessageBox.messageIcon.Foreground = Brushes.White;
                    // Color
                    customMessageBox.Header.Background = new SolidColorBrush(Color.FromRgb(10, 102, 72));
                    customMessageBox.Body.Background = new SolidColorBrush(Color.FromRgb(15, 153, 109));
                    // Texto
                    customMessageBox.Tb_HeaderMessage.Foreground = Brushes.White;
                    customMessageBox.Tb_Message.Foreground = Brushes.White;
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

        //private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.ChangedButton == MouseButton.Left)
        //        this.DragMove();
        //}

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
