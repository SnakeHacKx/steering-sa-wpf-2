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

        /// <summary>
        /// Ingresa el ConnectionString en la conexión a la base de datos.
        /// </summary>
        /// <param name="user">Nombre de usuario de la base de datos</param>
        /// <param name="password">Contraseña del usuario de la base de datos.</param>
        public void SetConnectionString(string user, string password)
        {
            //string myStringConnection = ConfigurationManager.ConnectionStrings["SteeringSA_WPF.Properties.Settings.SteeringSAConnectionString"].ConnectionString;
            string myStringConnection = string.Format("Server=26.60.194.233,49172;Initial Catalog=Steering_SA;User ID={0};Password={1};Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False", user, password);

            _mySqlConnection = new SqlConnection(myStringConnection);
        }

        /// <summary>
        /// Prueba la conexión a la base de datos.
        /// </summary>
        /// <returns>True: Conexión con exito a la base de datos<para>False:Conexión fallida con la base de datos.</para></returns>
        public bool TestConnection()
        {
            try
            {
                SQLConnection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                // not really necessary
                SQLConnection.Close();
            }
        }

        #region METODOS AUXILIARES
        /// <summary>
        /// Muestra un mensaje que viene desde la base de datos.
        /// </summary>
        /// <param name="cmd">Comando de SQL</param>
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
