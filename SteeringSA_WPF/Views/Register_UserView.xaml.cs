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
    /// Interaction logic for Register_UserView.xaml
    /// </summary>
    public partial class Register_UserView : UserControl
    {
        public Register_UserView()
        {
            InitializeComponent();
        }

        private void ClearFormFields()
        {
            Txt_UserName.Text = "";
            Txt_Password.Password = "";
            Txt_ConfirmPassword.Password = "";
            Cb_Role.Text = "";
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.VIEW_USERS, new ViewModels.UserViewModel());
        }

        private void Btn_AddUser_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("¿Está seguro/a que desea registrar este usuario?",
                "Registrar Usuario",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            { 
                if (Txt_Password.Password == Txt_ConfirmPassword.Password)
                {
                    CRUD.User.Instance.Register(Txt_UserName.Text, Txt_Password.Password, Cb_Role.Text);
                }
                else
                {
                    CustomMessageBox.Show("Las contraseñas no coinciden, inténtelo nuevamente", "Error", CustomMessageBox.CMessageBoxType.Error);
                }

                ClearFormFields();
            }
        }
    }
}
