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
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, Surname); } }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string BirthDate { get; set; }
        public string BloodType { get; set; }
        public string LicenseType { get; set; }
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
            cmd.Parameters.AddWithValue(TableVariable.DRIVER_CEDULA, id);

            SqlDataReader reader;
            DBConnection.Instance.SQLConnection.Open();
            reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    ID = reader.GetString(0);
                    Name = reader.GetString(1);
                    Surname = reader.GetString(2);
                    PhoneNumber = reader.GetString(3);
                    BirthDate = reader.GetString(4);
                    Age = reader.GetInt32(5);
                    BloodType = reader.GetString(6);
                    LicenseType = reader.GetString(7);
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

        public DataTable FilterBy(string name, string license, string minAge, string maxAge)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.FILTERS_DRIVER, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(TableVariable.DRIVER_NOMBRE, name);
            cmd.Parameters.AddWithValue(TableVariable.DRIVER_TIPO_LICENCIA, license);

            if (minAge == null)
                cmd.Parameters.AddWithValue("@Edad_menor", minAge);
            else
                cmd.Parameters.AddWithValue("@Edad_menor", int.Parse(minAge));

            if (maxAge == null)
                cmd.Parameters.AddWithValue("@Edad_mayor", maxAge);
            else
                cmd.Parameters.AddWithValue("@Edad_mayor", int.Parse(maxAge));

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
