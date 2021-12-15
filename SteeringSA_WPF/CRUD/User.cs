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
    public class User
    {
        #region PROPERTIES
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        #endregion

        #region SINGLETON
        private static User _instance;

        public static User Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new User();

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
        public void Register(string username, string password, string role)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_USER, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_name", username);
                cmd.Parameters.AddWithValue("@User_Password", password);
                cmd.Parameters.AddWithValue("@User_rol", role);

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
                CustomMessageBox.Show(successMsg, "Usuario Registrado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        /// <summary>
        /// Permite editar el nombre de usuario
        /// </summary>
        /// <param name="id">Codigo del servicio</param>
        public void Edit(string username, string newUsernName, string newPassword)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.EDIT_USER, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_name", username);
                cmd.Parameters.AddWithValue("@new_name", newUsernName);
                cmd.Parameters.AddWithValue("@New_pass", newPassword);

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
                CustomMessageBox.Show(successMsg, "Usuario Editado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        /// <summary>
        /// Permite editar la contraseña
        /// </summary>
        /// <param name="id">Codigo del servicio</param>
        public void EditPassword(string username, string newPassword)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.EDIT_USER, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_name", username);
                cmd.Parameters.AddWithValue("@New_pass", newPassword);

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
                CustomMessageBox.Show(successMsg, "Nombre de Usuario Editado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        /// <summary>
        /// Permite eliminar un conductor
        /// </summary>
        /// <param name="username">nombre de usuario</param>
        public void Delete(string username)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_USER, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_name", username);

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
                CustomMessageBox.Show(successMsg, "Usuario Eliminado", CustomMessageBox.CMessageBoxType.Success);
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
            cmd.Parameters.AddWithValue("@User_name", id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    Username = reader.GetString(0);
                    Role = reader.GetString(1);
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
