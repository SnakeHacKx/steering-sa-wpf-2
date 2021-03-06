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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private string chosenUser;

        public UserView()
        {
            InitializeComponent();
            RefreshDataGrid();
        }

        private void Dgv_UsersData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserProfile.Visibility == Visibility.Collapsed)
                UserProfile.Visibility = Visibility.Visible;

            Tb_UserName.Text = UtilitiesDataGrid.GetColumnValue(sender, 0);
            Tb_Role.Text = UtilitiesDataGrid.GetColumnValue(sender, 1);
        }

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshUsersDataGrid(ref Dgv_UsersData, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_USERS), ref Tb_RecordCount);
        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {
            //WindowManager.ChangeWindow(WindowsTitle.SIGNUP_USER_PROFILE, new UserProfileViewModel());
        }

        private void Btn_RefreshDataGrid_Click_1(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
            UserProfile.Visibility = Visibility.Collapsed;
        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new ViewModels.HomeViewModel());
        }

        private void Btn_AddUser_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.ADD_USER, new ViewModels.Register_UserViewModel());
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult result = CustomMessageBox.Show("Esta acción hará un cambio permanente en la base de datos ¿Está seguro/a que desea realizarla?",
                "Eliminar Usuario",
                CustomMessageBox.CMessageBoxType.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                CRUD.User.Instance.Delete(Tb_UserName.Text);
                RefreshDataGrid();
            }
        }

        private void Btn_EditUser_Click(object sender, RoutedEventArgs e)
        {
            Windows.Edit_User editUser = new Windows.Edit_User(Tb_UserName.Text);
            editUser.RefreshDatagrid += new Windows.Edit_User.DRefreshDatagrid(RefreshDataGrid);
            editUser.ShowDialog();
        }
    }
}
