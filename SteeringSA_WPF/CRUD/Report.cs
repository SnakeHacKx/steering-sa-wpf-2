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
    public class Report
    {
        #region PROPERTIES
        public string IDReporte { get; set; }
        public string PlacaVehiculo { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        #endregion

        #region SINGLETON
        private static Report _instance;

        public static Report Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Report();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region CRUD
        public void Register(string vehicleRegister, string description, string todaysDate)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_REPORT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.REPORT_PLACA_VEHICULO, vehicleRegister);
                cmd.Parameters.AddWithValue(TableVariable.REPORT_DESCRIPCION, description);
                cmd.Parameters.AddWithValue(TableVariable.REPORT_FECHA, todaysDate);

                cmd.Parameters.Add("@MsgSuccess", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MsgError", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                DBConnection.Instance.SQLConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBConnection.Instance.SQLConnection.Close();
            }

            string successMsg = cmd.Parameters["@MsgSuccess"].Value.ToString();
            string errorMsg = cmd.Parameters["@MsgError"].Value.ToString();

            if (successMsg != "")
            {
                CustomMessageBox.Show(successMsg, "Reporte Registrado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        public void Edit(string id, string vehicleRegistration, string description, string addDate)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_REPORT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.REPORT_CODIGO, id);
                cmd.Parameters.AddWithValue(TableVariable.REPORT_PLACA_VEHICULO, vehicleRegistration);
                cmd.Parameters.AddWithValue(TableVariable.REPORT_DESCRIPCION, description);
                cmd.Parameters.AddWithValue(TableVariable.REPORT_FECHA, addDate);

                cmd.Parameters.Add("@MsgSuccess", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MsgError", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                DBConnection.Instance.SQLConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBConnection.Instance.SQLConnection.Close();
            }

            string successMsg = cmd.Parameters["@MsgSuccess"].Value.ToString();
            string errorMsg = cmd.Parameters["@MsgError"].Value.ToString();

            if (successMsg != "")
            {
                CustomMessageBox.Show(successMsg, "Reporte Editado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        public void Delete(string id)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_REPORT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.REPORT_CODIGO, id);

                cmd.Parameters.Add("@MsgSuccess", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@MsgError", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                DBConnection.Instance.SQLConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                DBConnection.Instance.SQLConnection.Close();
            }

            string successMsg = cmd.Parameters["@MsgSuccess"].Value.ToString();
            string errorMsg = cmd.Parameters["@MsgError"].Value.ToString();

            if (successMsg != "")
            {
                CustomMessageBox.Show(successMsg, "Reporte Eliminado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }
        #endregion

        #region LECTURA DE DATOS

        public void ReadFields(string procedureName, string id)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_Reporte", id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    IDReporte = reader.GetString(0);
                    PlacaVehiculo = reader.GetString(1);
                    Fecha = reader.GetString(2);
                    Estado = reader.GetString(3);
                    Descripcion = reader.GetString(4);
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

        public DataTable ShowReportsByVehicle(string vehicleID)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.SHOW_REPORTS_BYVEHICLE, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Placa_Vehiculo", vehicleID);

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

        public DataTable FilterBy(string beginDate, string endDate, string state)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.FILTERS_REPORT, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Estado_reporte", state);

            if (beginDate == null)
                cmd.Parameters.AddWithValue("@Fecha_inicio", null);
            else
            {
                //MessageBox.Show(DateTime.Parse(beginDate).ToString());
                cmd.Parameters.AddWithValue("@Fecha_inicio", DateTime.Parse(beginDate));
            }

            if (endDate == null)
                cmd.Parameters.AddWithValue("@Fecha_final", null);
            else
            {
                //MessageBox.Show(DateTime.Parse(endDate).ToString());
                cmd.Parameters.AddWithValue("@Fecha_final", DateTime.Parse(endDate));
            }

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
    }
}
