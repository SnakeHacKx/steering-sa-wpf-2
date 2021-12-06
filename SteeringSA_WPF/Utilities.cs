using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace SteeringSA_WPF
{
    public static class UtilitiesDataGrid
    {
        /// <summary>
        /// Actualiza un DataGrid con los valores más recientes
        /// </summary>
        /// <param name="dataGrid">DataGrid a actualizar</param>
        /// <param name="tableID">ID de la tabla de la Base de Datos</param>
        /// <param name="dataTable">Tabla de datos procedente de la Base de Datos</param>
        public static void RefreshDataGrid(ref DataGrid dataGrid, string tableID, DataTable dataTable, ref TextBlock recordQuantity)
        {
            dataGrid.SelectedValuePath = tableID;
            dataGrid.ItemsSource = dataTable.DefaultView;
            recordQuantity.Text = dataGrid.Items.Count.ToString();
        }

        public static string GetColumnValue(object sender, int column)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView selectedRow = dg.SelectedItem as DataRowView;

            if (selectedRow != null)
            {
                return selectedRow[column].ToString();
            }

            return null;
        }
    }

    public static class Utilities
    {
        public static void FillCombobox(ref ComboBox combo, string tableID, DataTable dataTable)
        {
            combo.SelectedValuePath = tableID;
            combo.ItemsSource = dataTable.DefaultView;
        }

        public static bool IsInputNumeric(string str)
        {
            Regex reg = new Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        public static bool IsAValidDNI(string str)
        {
            Regex reg = new Regex("^[0 - 9]{ 3} -[0 - 9]{ 4}-[0 - 9]{ 4}");
            return reg.IsMatch(str);
        }
    }
}
