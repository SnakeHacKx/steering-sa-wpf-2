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
    public class Maintenance
    {
        #region PROPERTIES
        public string IDMantenimiento { get; set; }
        public string PlacaVehiculo { get; set; }
        public string IDReporte { get; set; }
        public string Costo { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        #endregion

        #region SINGLETON
        private static Maintenance _instance;

        public static Maintenance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Maintenance();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region CRUD
        public void Register(string vehicleRegistration, string reportID, string cost, string date,  string description, string state)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_MAINTENANCE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_PLACA_VEHICULO, vehicleRegistration);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_COD_REPORTE, reportID);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_COSTO, cost);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_FECHA, date);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_DESCRIPCION, description);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_ESTADO, state);

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

        public void Edit(int id, string vehicleRegistration, string reportID, string cost, string date, string description, string state)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_MAINTENANCE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_CODIGO, id);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_PLACA_VEHICULO, vehicleRegistration);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_COD_REPORTE, reportID);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_COSTO, cost);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_FECHA, date);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_DESCRIPCION, description);
                cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_ESTADO, state);

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
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_MAINTENANCE, DBConnection.Instance.SQLConnection);
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
            cmd.Parameters.AddWithValue(TableVariable.MAINTENANCE_CODIGO, id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    IDMantenimiento = reader.GetString(0);
                    PlacaVehiculo = reader.GetString(1);
                    IDReporte = reader.GetString(2);
                    Costo = reader.GetString(3);
                    Fecha = reader.GetString(4);
                    Descripcion = reader.GetString(5);
                    Estado = reader.GetString(6);
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

        public DataTable FilterBy(string minCost, string maxCost, string beginDate, string endDate, string vehicleID, string vehicleType)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.FILTERS_MAINTENANCE, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Placa_vehiculo", vehicleID);
            cmd.Parameters.AddWithValue("@Tipo_vehiculo", vehicleType);

            if (beginDate == null)
                cmd.Parameters.AddWithValue("@Fecha_inicial", null);
            else
            {
                //MessageBox.Show(DateTime.Parse(beginDate).ToString());
                cmd.Parameters.AddWithValue("@Fecha_inicial", DateTime.Parse(beginDate));
            }

            if (endDate == null)
                cmd.Parameters.AddWithValue("@Fecha_final", null);
            else
            {
                //MessageBox.Show(DateTime.Parse(endDate).ToString());
                cmd.Parameters.AddWithValue("@Fecha_final", DateTime.Parse(endDate));
            }

            if (minCost == null)
                cmd.Parameters.AddWithValue("@Costo_inicial", minCost);
            else
                cmd.Parameters.AddWithValue("@Costo_inicial", decimal.Parse(minCost));

            if (maxCost == null)
                cmd.Parameters.AddWithValue("@Costo_final", maxCost);
            else
                cmd.Parameters.AddWithValue("@Costo_final", decimal.Parse(maxCost));

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
