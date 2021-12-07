using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SteeringSA_WPF.CRUD
{
    class GenericCRUD
    {
        public string ClientCount { get; set; }
        public string DriverCount { get; set; }
        public string VehicleCount { get; set; }
        public string ReportCount { get; set; }
        public string MaintenanceCount { get; set; }
        public string ServiceCount { get; set; }


        #region SINGLETON
        private static GenericCRUD _instance;

        public static GenericCRUD Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GenericCRUD();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        public DataTable SearchBy(string procedureName, string variableName, string value)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(variableName, value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            using (da)
            {
                DataTable dataTable = new DataTable();

                try
                {
                    da.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(ex.Message, "Error en la base de datos", CustomMessageBox.CMessageBoxType.Error);
                    return null;
                }

                return dataTable;
            }
        }

        public DataTable SelectParticularRecord(string procedureName, string variableName1, string value1, string variableName2, string value2)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(variableName1, value1);
            cmd.Parameters.AddWithValue(variableName2, value2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            using (da)
            {
                DataTable dataTable = new DataTable();

                try
                {
                    da.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(ex.Message, "Error en la base de datos", CustomMessageBox.CMessageBoxType.Error);
                    return null;
                }

                return dataTable;
            }
        }

        public DataTable SelectAllRecords(string procedureName)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            using (da)
            {
                DataTable dataTable = new DataTable();

                da.Fill(dataTable);

                return dataTable;
            }
        }
        /// <summary>
        /// Recupera la cantidad de registros de cada tabla en la base de datos
        /// </summary>
        public void GetRecordsCount()
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.GET_TOTALS, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    ClientCount = reader.GetString(0);
                    DriverCount = reader.GetString(1);
                    VehicleCount = reader.GetString(2);
                    ReportCount = reader.GetString(3);
                    MaintenanceCount = reader.GetString(4);
                    ServiceCount = reader.GetString(5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBConnection.Instance.SQLConnection.Close();
            }
        }
    }
}
