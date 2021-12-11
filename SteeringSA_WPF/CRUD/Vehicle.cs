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
    public class Vehicle
    {
        #region PROPERTIES
        public string IDPlaca { get; set; }
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public string Pasajeros { get; set; }
        public string TipoCombustible { get; set; }
        public string Color { get; set; }
        #endregion

        #region SINGLETON
        private static Vehicle _instance;

        public static Vehicle Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Vehicle();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region CRUD

        public void Register(string idVehicle, string model, string type, int passengers, string fuelType, string color)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_VEHICLE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_PLACA, idVehicle);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_MODELO, model);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_TIPO, type);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_PASAJERO, passengers);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_TIPO_COMBUSTIBLE, fuelType);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_COLOR, color);

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
                CustomMessageBox.Show(successMsg, "Vehículo Registrado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        public void Edit(string idVehicle, string model, string type, string state, int passengers, string fuelType, string color)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_VEHICLE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_PLACA, idVehicle);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_MODELO, model);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_TIPO, type);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_ESTADO, state);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_PASAJERO, passengers);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_TIPO_COMBUSTIBLE, fuelType);
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_COLOR, color);

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
                CustomMessageBox.Show(successMsg, "Vehículo Editado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        public void Delete(string id)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_VEHICLE, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.VEHICLE_PLACA, id);

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
                CustomMessageBox.Show(successMsg, "Vehículo Eliminado", CustomMessageBox.CMessageBoxType.Success);
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
            cmd.Parameters.AddWithValue(TableVariable.VEHICLE_PLACA, id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    IDPlaca = reader.GetString(0);
                    Tipo = reader.GetString(1);
                    Modelo = reader.GetString(2);
                    Pasajeros = reader.GetString(3);
                    Color = reader.GetString(4);
                    TipoCombustible = reader.GetString(5);
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

        public DataTable FilterBy(string model, string type, string minPassengers, string maxPassengers, string fuelType, string state, string color)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.FILTERS_VEHICLE, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(TableVariable.VEHICLE_TIPO, type);
            cmd.Parameters.AddWithValue(TableVariable.VEHICLE_MODELO, model);
            cmd.Parameters.AddWithValue(TableVariable.VEHICLE_COLOR, color);
            cmd.Parameters.AddWithValue("@pasajero_init", minPassengers);
            cmd.Parameters.AddWithValue("@pasajero_top", maxPassengers);
            cmd.Parameters.AddWithValue("@Tipo_de_combustible", fuelType);
            cmd.Parameters.AddWithValue("@Estado_vehiculo", state);

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
