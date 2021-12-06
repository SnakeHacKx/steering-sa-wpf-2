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
    class Service
    {
        #region PROPERTIES
        public string ID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ClientFullName { get; set; }
        public string DriverFullName { get; set; }
        public string DriverID { get; set; }
        public string ClientID { get; set; }
        public string VehicleID { get; set; }
        public string VehicleType { get; set; }
        public string VehicleColor { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string Duration { get; set; }
        public string TotalCost { get; set; }
        #endregion

        #region SINGLETON
        private static Service _instance;

        public static Service Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Service();

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
        /// <param name="idServiceType">Codigo del tipo de servicio</param>
        /// <param name="driverID">Cedula del conductor</param>
        /// <param name="vehicleID">Cedula del cliente</param>
        /// <param name="beginDate">Fecha de inicio</param>
        /// <param name="endDate">Fecha de Finalizacion</param>
        public void Register(string idServiceType, string driverID, string clientID, string vehicleID, string beginDate, string endDate)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_SERVICE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_COD_TIPO_SERVICIO, idServiceType);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CONDUCTOR, driverID);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CLIENTE, clientID);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_PLACA_VEHICULO, vehicleID);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_FECHA_INICIO, beginDate);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_FECHA_FINAL, endDate);

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
                CustomMessageBox.Show(successMsg, "Servicio Registrado", CustomMessageBox.CMessageBoxType.Success);
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
        /// <param name="idServiceType">Codigo del tipo de servicio</param>
        /// <param name="driverID">Cedula del conductor</param>
        /// <param name="vehicleID">Cedula del cliente</param>
        /// <param name="beginDate">Fecha de inicio</param>
        /// <param name="endDate">Fecha de Finalizacion</param>
        public void Edit(string id, string idServiceType, string driverID, string clientID, string vehicleID, string beginDate, string endDate)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_SERVICE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableID.SERVICE, id);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_COD_TIPO_SERVICIO, idServiceType);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CONDUCTOR, driverID);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CLIENTE, clientID);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_PLACA_VEHICULO, vehicleID);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_FECHA_INICIO, beginDate);
                cmd.Parameters.AddWithValue(TableVariable.SERVICE_FECHA_FINAL, endDate);

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
                CustomMessageBox.Show(successMsg, "Servicio Editado", CustomMessageBox.CMessageBoxType.Success);
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
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_SERVICE, DBConnection.Instance.SQLConnection);
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
            cmd.Parameters.AddWithValue(TableVariable.SERVICE_CODIGO, id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    ID = reader.GetString(0);
                    Type = reader.GetString(1);
                    Description = reader.GetString(2);
                    ClientFullName = reader.GetString(3);
                    DriverFullName = reader.GetString(4);
                    DriverID = reader.GetString(5);
                    ClientID = reader.GetString(6);
                    VehicleID = reader.GetString(7);
                    VehicleType = reader.GetString(8);
                    VehicleColor = reader.GetString(9);
                    BeginDate = reader.GetString(10);
                    EndDate = reader.GetString(11);
                    Duration = reader.GetString(12);
                    TotalCost = reader.GetString(13);
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

            //if (minCost == null) MessageBox.Show("minCost NULL");
            //if (maxCost == null) MessageBox.Show("maxCost NULL");
            //if (beginDate == null) MessageBox.Show("beginDate NULL");
            //if (endDate == null) MessageBox.Show("endDate NULL");
            //if (clientID == null) MessageBox.Show("clientID NULL");
            //if (driverID == null) MessageBox.Show("driverID NULL");
            //if (serviceType == null) MessageBox.Show("serviceType NULL");
            //if (vehicleID == null) MessageBox.Show("vehicleID NULL");

            cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CLIENTE, clientID);
            cmd.Parameters.AddWithValue(TableVariable.SERVICE_CEDULA_CONDUCTOR, driverID);
            cmd.Parameters.AddWithValue("@Placa_Vehiculo", vehicleID);
            cmd.Parameters.AddWithValue("@Tipo_Servicio", serviceType);
            cmd.Parameters.AddWithValue("@Fecha_inicial", beginDate);
            cmd.Parameters.AddWithValue("@Fecha_final", endDate);

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
