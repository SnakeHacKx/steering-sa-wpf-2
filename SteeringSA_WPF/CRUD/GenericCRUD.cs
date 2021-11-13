using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SteeringSA_WPF.CRUD
{
    class GenericCRUD
    {
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

        public DataTable SelectParticularRecord(string procedureName, string variableName, string value)
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
    }
}
