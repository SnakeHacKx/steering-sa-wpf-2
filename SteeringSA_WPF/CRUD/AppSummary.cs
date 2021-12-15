using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SteeringSA_WPF.CRUD
{
    public class AppSummary
    {
        #region PROPERTIES
        public string ServicesCount { get; set; }
        public string DriversCount { get; set; }
        public string VehiclesCount { get; set; }
        public string ReportsCount { get; set; }
        public string MaintenanceCount { get; set; }
        public string ServiceTypesCount { get; set; }
        public string ClientsCount { get; set; }
        public string Profits { get; set; }
        public string Expenses { get; set; }
        public string Balance { get; set; }
        public string Registers { get; set; }
        public string Edits { get; set; }
        public string Deletes { get; set; }
        public string TotalActions { get; set; }
        #endregion

        #region SINGLETON
        private static AppSummary _instance;

        public static AppSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSummary();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region LECTURA DE DATOS
        public void ReadFields()
        {
            SqlCommand cmd = new SqlCommand("PROC_OBTENER_INFORME", DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    ServicesCount = reader.GetString(0);
                    DriversCount = reader.GetString(1);
                    VehiclesCount = reader.GetString(2);
                    ReportsCount = reader.GetString(3);
                    MaintenanceCount = reader.GetString(4);
                    ServiceTypesCount = reader.GetString(5);
                    ClientsCount = reader.GetString(6);
                    Profits = reader.GetString(7);
                    Expenses = reader.GetString(8);
                    Balance = reader.GetString(9);
                    Registers = reader.GetString(10);
                    Edits = reader.GetString(11);
                    Deletes = reader.GetString(12);
                    TotalActions = reader.GetString(13);
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
        #endregion
    }
}
