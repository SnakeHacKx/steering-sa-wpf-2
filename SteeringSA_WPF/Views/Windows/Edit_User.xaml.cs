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
    /// Interaction logic for Edit_User.xaml
    /// </summary>
    public partial class Edit_User : Window
    {
        private bool toggleUsernameTextBox;
        private bool togglePasswordsTextBox;
        private string username;
        public delegate void DRefreshDatagrid();
        public event DRefreshDatagrid RefreshDatagrid;

        public Edit_User(string username)
        {
            InitializeComponent();
            this.username = username;
            toggleUsernameTextBox = false;
            togglePasswordsTextBox = false;
            Tb_ActualUsername.Text = username;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_EditUser_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea editar este usuario?",
                "Editar Usuario",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (toggleUsernameTextBox == true && togglePasswordsTextBox == true)
                {
                    if (Txt_Password.Password == Txt_ConfirmPassword.Password)
                    {
                        if (Txt_Password.Password.Length < 8)
                        {
                            CustomMessageBox.Show("Las contraseñas deben tener mínimio 8 caracteres, favor inténtelo nuevamente", "La contraseña es muy débil", CustomMessageBox.CMessageBoxType.Error);
                            ClearPassworsInputs();
                            return;
                        }
                        CRUD.User.Instance.Edit(username, Txt_NewUserName.Text, Txt_Password.Password);
                        RefreshDatagrid();
                    }
                    else
                    {
                        CustomMessageBox.Show("Las contraseñas no coinciden, favor inténtelo nuevamente", "Las contraseñas no coinciden", CustomMessageBox.CMessageBoxType.Error);
                        ClearPassworsInputs();
                    }
                    
                }
                else if (toggleUsernameTextBox == true && togglePasswordsTextBox == false)
                {
                    CRUD.User.Instance.Edit(username, Txt_NewUserName.Text, null);
                    RefreshDatagrid();
                }
                else if (toggleUsernameTextBox == false && togglePasswordsTextBox == true)
                {
                    if (Txt_Password.Password == Txt_ConfirmPassword.Password)
                    {
                        if(Txt_Password.Password.Length < 8)
                        {
                            CustomMessageBox.Show("Las contraseñas deben tener mínimio 8 caracteres, favor inténtelo nuevamente", "La contraseña es muy débil", CustomMessageBox.CMessageBoxType.Error);
                            ClearPassworsInputs();
                            return;
                        }
                        CRUD.User.Instance.Edit(username, null, Txt_Password.Password);
                        RefreshDatagrid();
                    }
                    else
                    {
                        CustomMessageBox.Show("Las contraseñas no coinciden, favor inténtelo nuevamente", "Las contraseñas no coinciden", CustomMessageBox.CMessageBoxType.Error);
                        ClearPassworsInputs();
                    }
                }
                else
                {
                    CustomMessageBox.Show("Debe elegir un campo para editar", "Nada que editar", CustomMessageBox.CMessageBoxType.Info);
                }
            }
        }

        private void ClearPassworsInputs()
        {
            Txt_ConfirmPassword.Password = "";
            Txt_Password.Password = "";
        }

        private void Btn_EditUsername_Click(object sender, RoutedEventArgs e)
        {
            if (toggleUsernameTextBox == false)
            {
                Txt_NewUserName.Visibility = Visibility.Visible;
                toggleUsernameTextBox = true;
            }
            else
            {
                Txt_NewUserName.Visibility = Visibility.Collapsed;
                toggleUsernameTextBox = false;
            }
               
        }

        private void Btn_EditPassword_Click(object sender, RoutedEventArgs e)
        {
            if (togglePasswordsTextBox == false)
            {
                PasswordInputs.Visibility = Visibility.Visible;
                togglePasswordsTextBox = true;
            }
            else
            {
                PasswordInputs.Visibility = Visibility.Collapsed;
                togglePasswordsTextBox = false;
            }
        }
    }
}
