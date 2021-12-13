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
    public class ServiceType
    {
        #region PROPERTIES
        public string ID { get; set; }
        public string Nombre { get; set; }
        public decimal Costo_Dia { get; set; }
        #endregion

        #region SINGLETON
        private static ServiceType _instance;

        public static ServiceType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceType();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region CRUD

        /// <summary>
        /// Permite registrar un servicio
        /// </summary>
        public void Register(string name, string cost)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_TYPE_SERVICE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", name);
                

                if (cost == null)
                    cmd.Parameters.AddWithValue("@Costo", cost);
                else
                    cmd.Parameters.AddWithValue("@Costo", decimal.Parse(cost));

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
                CustomMessageBox.Show(successMsg, "Tipo de Servicio Registrado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        /// <summary>
        /// Permite editar un servicio
        /// </summary>
        /// <param name="id">Codigo del servicio</param>
        public void Edit(string id, string name, string cost)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_TYPE_SERVICE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableID.SERVICE, id);
                cmd.Parameters.AddWithValue(TableVariable.TYPE_SERVICE_NOMBRE, name);

                if (cost == null)
                    cmd.Parameters.AddWithValue(TableVariable.TYPE_SERVICE_COSTO, cost);
                else
                    cmd.Parameters.AddWithValue(TableVariable.TYPE_SERVICE_COSTO, decimal.Parse(cost));

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
                CustomMessageBox.Show(successMsg, "Tipo de Servicio Editado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        /// <summary>
        /// Permite eliminar un conductor
        /// </summary>
        /// <param name="id">Cédula</param>
        public void Delete(string id)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_TYPE_SERVICE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_CODIGO, id);

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
                CustomMessageBox.Show(successMsg, "Servicio Eliminado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }
        #endregion

        #region LECTURA DE DATOS

        /// <summary>
        /// Permite traer los campos de la tabla Conductor
        /// </summary>
        /// <param name="procedureName">Nombre del procedimiento almacenado.</param>
        /// <param name="idClient">Cédula del Conductor</param>
        public void ReadFields(string procedureName, string id)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(TableVariable.TYPE_SERVICE_CODIGO, id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    ID = reader.GetInt32(0).ToString();
                    Nombre = reader.GetString(1);
                    Costo_Dia = reader.GetDecimal(2);
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

        public DataTable FilterBy(string minCost, string maxCost, string beginDate, string endDate, string clientID, string driverID, string serviceType, string vehicleID)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.FILTERS_SERVICE, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CLIENTE, clientID);
            cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CONDUCTOR, driverID);
            cmd.Parameters.AddWithValue("@Placa_Vehiculo", vehicleID);
            cmd.Parameters.AddWithValue("@Tipo_Servicio", serviceType);

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
