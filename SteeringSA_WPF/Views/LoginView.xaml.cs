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

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        //public delegate void ChangeUsernameText();
        //public event ChangeUsernameText ChangeUsername;

        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicia la sesión
        /// </summary>
        private void Btn_LogIn_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Txt_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void Txt_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            DBConnection.Instance.SetConnectionString(Txt_User.Text, Txt_Password.Password);

            if (!DBConnection.Instance.TestConnection())
            {
                CustomMessageBox.Show("Error al iniciar sesión, inténtelo nuevamente", "Error", CustomMessageBox.CMessageBoxType.Error);
                Txt_Password.Password = "";
                Txt_User.Text = "";
                return;
            }

            WindowManager.ChangeUsername(Txt_User.Text);
            WindowManager.ChangeWindow(WindowsTitle.HOME, new HomeViewModel());
        }
    }
}
