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
    public class Client
    {
        #region PROPERTIES
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, Surname); } }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        #endregion

        #region SINGLETON
        private static Client _instance;

        public static Client Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Client();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        #endregion

        #region CRUD

        public void Register(string idClient, string name, string surname, string phoneNumber, string birthDate, string address)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.INSERT_CLIENT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_CEDULA, idClient);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_NOMBRE, name);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_APELLIDO, surname);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_TELEFONO, phoneNumber);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_FECHA_NACIMIENTO, birthDate);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_DIRECCION, address);

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

        public void Edit(string idClient, string name, string surname, string phoneNumber, DateTime birthDate, string address)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.UPDATE_CLIENT, DBConnection.Instance.SQLConnection);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_CEDULA, idClient);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_NOMBRE, name);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_APELLIDO, surname);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_TELEFONO, phoneNumber);
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_FECHA_NACIMIENTO, birthDate.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue(TableVariable.CLIENT_DIRECCION, address);

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
                    ID = reader.GetString(0);
                    Name = reader.GetString(1);
                    Surname = reader.GetString(2);
                    BirthDate = reader.GetDateTime(3);
                    Age = reader.GetInt32(4);
                    PhoneNumber = reader.GetString(5);
                    Address = reader.GetString(6);
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

        public DataTable FilterBy(string name, string address, string minAge, string maxAge)
        {
            SqlCommand cmd = new SqlCommand(StoreProcedure.FILTERS_CLIENT, DBConnection.Instance.SQLConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(TableVariable.CLIENT_NOMBRE, name);
            cmd.Parameters.AddWithValue(TableVariable.CLIENT_DIRECCION, address);

            if (minAge == null)
                cmd.Parameters.AddWithValue("@Edad_inicial", minAge);
            else
                cmd.Parameters.AddWithValue("@Edad_inicial", int.Parse(minAge));

            if (maxAge == null)
                cmd.Parameters.AddWithValue("@Edad_final", maxAge);
            else
                cmd.Parameters.AddWithValue("@Edad_final", int.Parse(maxAge));

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
