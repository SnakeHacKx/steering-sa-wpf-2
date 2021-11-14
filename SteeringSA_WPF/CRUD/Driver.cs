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
    class Driver
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

        public void Register(string idClient, string name, string surname, string phoneNumber, string birthDate, string bloodType, string licenseType)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_CLIENT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_CEDULA, idClient);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_NOMBRE, name);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_APELLIDO, surname);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_TELEFONO, phoneNumber);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_FECHA_NACIMIENTO, birthDate);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_TIPO_SANGRE, bloodType);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_TIPO_LICENCIA, licenseType);

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
                CustomMessageBox.Show(successMsg, "Cliente Registrado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        public void Edit(string idClient, string name, string surname, string phoneNumber, string birthDate, string bloodType, string licenseType)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_CLIENT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_CEDULA, idClient);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_NOMBRE, name);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_APELLIDO, surname);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_TELEFONO, phoneNumber);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_FECHA_NACIMIENTO, birthDate);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_TIPO_SANGRE, bloodType);
                cmd.Parameters.AddWithValue(TableVariable.DRIVER_TIPO_LICENCIA, licenseType);

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
                CustomMessageBox.Show(successMsg, "Cliente Editado", CustomMessageBox.CMessageBoxType.Success);
            }
            else if (errorMsg != "")
            {
                CustomMessageBox.Show(errorMsg, "Error", CustomMessageBox.CMessageBoxType.Error);
            }
        }

        public void Delete(string id)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.DELETE_CLIENT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_CEDULA, id);

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

        public void ReadFields(string procedureName, string idClient)
        {
            SqlCommand cmd = new SqlCommand(procedureName, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(TableVariable.CLIENT_CEDULA, idClient);

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
