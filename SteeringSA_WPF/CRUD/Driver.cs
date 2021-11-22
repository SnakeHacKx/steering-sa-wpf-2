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
    public class Driver
    {
        #region PROPERTIES
        public string IDCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public string TipoSangre { get; set; }
        public string TipoLicencia { get; set; }
        #endregion

        #region SINGLETON
        private static Driver _instance;

        public static Driver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Driver();

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
        /// Permite registrar un conductor
        /// </summary>
        /// <param name="id">Cédula</param>
        /// <param name="name">Nombre</param>
        /// <param name="surname">Apellido</param>
        /// <param name="phoneNumber">Número Telefónico</param>
        /// <param name="birthDate">Fecha de Nacimiento</param>
        /// <param name="bloodType">Tipo de Sangre</param>
        /// <param name="licenseType">Tipo de Licencia</param>
        public void Register(string id, string name, string surname, string phoneNumber, string birthDate, string bloodType, string licenseType)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_DRIVER, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", id);
                cmd.Parameters.AddWithValue("@nombre", name);
                cmd.Parameters.AddWithValue("@apellido", surname);
                cmd.Parameters.AddWithValue("@telefono", phoneNumber);
                cmd.Parameters.AddWithValue("@fechaNac", birthDate);
                cmd.Parameters.AddWithValue("@tipoSangre", bloodType);
                cmd.Parameters.AddWithValue("@tipoLicencia", licenseType);

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
                CustomMessageBox.Show(successMsg, "Conductor Registrado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        /// <summary>
        /// Permite editar un conductor
        /// </summary>
        /// <param name="id">Cédula</param>
        /// <param name="name">Nombre</param>
        /// <param name="surname">Apellido</param>
        /// <param name="phoneNumber">Número Telefónico</param>
        /// <param name="birthDate">Fecha de Nacimiento</param>
        /// <param name="bloodType">Tipo de Sangre</param>
        /// <param name="licenseType">Tipo de Licencia</param>
        public void Edit(string id, string name, string surname, string phoneNumber, string birthDate, string bloodType, string licenseType)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_CLIENT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", id);
                cmd.Parameters.AddWithValue("@nombre", name);
                cmd.Parameters.AddWithValue("@apellido", surname);
                cmd.Parameters.AddWithValue("@telefono", phoneNumber);
                cmd.Parameters.AddWithValue("@fechaNac", birthDate);
                cmd.Parameters.AddWithValue("@tipoSangre", bloodType);
                cmd.Parameters.AddWithValue("@tipoLecencia", licenseType);

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
                CustomMessageBox.Show(successMsg, "Conductor Editado", CustomMessageBox.CMessageBoxType.Success);
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
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_DRIVER, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_CEDULA, id);

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
                CustomMessageBox.Show(successMsg, "Cliente Eliminado", CustomMessageBox.CMessageBoxType.Success);
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
            cmd.Parameters.AddWithValue(TableVariable.CLIENT_CEDULA, id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    IDCedula = reader.GetString(0);
                    Nombre = reader.GetString(1);
                    Apellido = reader.GetString(2);
                    Telefono = reader.GetString(3);
                    FechaNacimiento = reader.GetString(4);
                    TipoSangre = reader.GetString(5);
                    TipoLicencia = reader.GetString(6);
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
