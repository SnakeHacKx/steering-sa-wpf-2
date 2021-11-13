using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace SteeringSA_WPF
{
    public class DBConnection
    {
        private SqlConnection _mySqlConnection;
        private string _SuccessMsg;
        private string _ErrorMsg;

        public SqlConnection SQLConnection { get { return _mySqlConnection; } }

        private static DBConnection _instance;

        public static DBConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBConnection();
                }

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        public void ConectToDatabase()
        {
            string myStringConnection = ConfigurationManager.ConnectionStrings["SteeringSA_WPF.Properties.Settings.SteeringSAConnectionString"].ConnectionString;

            _mySqlConnection = new SqlConnection(myStringConnection);
        }

        #region METODOS AUXILIARES
        public void ShowMessageFromDB(SqlCommand cmd)
        {
            _SuccessMsg = null;
            _ErrorMsg = null;

            _SuccessMsg = cmd.Parameters["@MsgSuccess"].Value.ToString();
            _ErrorMsg = cmd.Parameters["@MsgError"].Value.ToString();

            if (_SuccessMsg != null) MessageBox.Show(_SuccessMsg, "Éxito");
            else if (_ErrorMsg != null) MessageBox.Show(_ErrorMsg, "Error");
            else MessageBox.Show("Error no identificado", "Error");
        }

        //public void FillComboBox(string entityName, ref ComboBox comboBox, string keyName)
        //{
        //    DataTable dataTable = new DataTable();
        //    FillTable(entityName, keyName, dataTable);
        //    comboBox.ItemsSource = dataTable;
        //}

        //public void FillTable(string entityName, string keyName, DataTable dataTable)
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT" + keyName + " FROM " + entityName, SQLConnection);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    dataTable.Clear();
        //    da.Fill(dataTable);
        //}
        #endregion
    }
}
