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
        private string userID;
        public Edit_User(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void Txt_Password_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Txt_ConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_AddClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
