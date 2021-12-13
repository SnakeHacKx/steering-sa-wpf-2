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
    /// Interaction logic for Choose_Service.xaml
    /// </summary>
    public partial class Choose_Service : Window
    {
        public delegate void ChangeServiceIDDelegate();
        public event ChangeServiceIDDelegate ChangeServiceID;

        public Choose_Service()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_TogggleFilters_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_ChooseService_Click(object sender, RoutedEventArgs e)
        {
            ChangeServiceID();
            Close();
        }

        private void Dgv_ServicesData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                WindowManager.ChosenService = columnValue;
            }
        }
    }
}
