using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringSA_WPF
{
    /// <summary>
    /// Contiene todos los títulos que se mostrarán en cada ventana.
    /// </summary>
    public static class WindowsTitle
    {
        public const string HOME = "Inicio";

        public const string VIEW_CLIENTS = "Clientes";
        public const string VIEW_DRIVERS = "Conductores";
        public const string VIEW_VEHICLES = "Vehículos";
        public const string VIEW_MAINTENANCE = "Mantenimientos";
        public const string VIEW_REPORTS = "Reportes";
        public const string VIEW_SERVICES = "Servicios";

        public const string PERSON_PROFILE = "Cliente";
        public const string VEHICLE_PROFILE = "Vehículo";
        public const string DRIVER_PROFILE = "Vehículo";
        public const string CHOOSE_PLANT_IMAGE = "Elegir Imagen de Planta";
        public const string LAND_PROFILE = "Perfil de Land";

        public const string ADD_CLIENTE = "Agregar Cliente";
        public const string ADD_DRIVERS = "Agregar Conductor";
        public const string ADD_VEHICLES = "Agregar Vehículo";
        public const string ADD_MAINTENANCE = "Agregar Mantenimiento";
        public const string ADD_REPORTS = "Agregar Reporte";
        public const string ADD_SERVICES = "Agregar Servicio";

        public const string EDIT_CLIENT = "Editar Cliente";
        public const string EDIT_DRIVER = "Editar Conductor";
        public const string EDIT_VEHICLE = "Editar Vehículo";
        public const string EDIT_MAINTENANCE = "Editar Mantenimiento";
        public const string EDIT_REPORT = "Editar Reporte";
        public const string EDIT_SERVICE = "Editar Servicio";

        public const string LOGIN = "Iniciar Sesión";
        public const string SIGNUP_USER = "Registrar Usuario";
    }

    /// <summary>
    /// Contiene el nombre de los IDs de cada tabla de la base de datos.
    /// </summary>
    public static class TableID
    {
        // Todo en mayuscula porque significa que es constante
        //EJEMPLO: public const string NombreTabla = "Nombre exacto que tiene la llave primaria en la base de datos"
        public const string CLIENT = "";
        public const string DRIVER = "";
        public const string VEHICLE = "";
        public const string MAINTENANCE = "";
        public const string REPORT = "";
        public const string SERVICE = "";
    }

    /// <summary>
    /// Contiene todos los nombres de los campos de cada tabla de la base de datos.
    /// </summary>
    public static class TableVariable
    {
        #region CLIENT
        // EJEMPLO: public const string NombreDeLaTabla_NombreDeLaVariable = "Nombre exacto que tiene la variable en la base de datos"
        public const string CLIENT_CLIENT_NAME = "ClientName";
        #endregion

        #region VEHICLE

        #endregion

        #region MAINTENANCE

        #endregion

        #region REPORT

        #endregion

        #region SERVICE

        #endregion
    }

    /// <summary>
    /// Contiene todos los nombres de los procedimientos almacenados alojados en la base de datos.
    /// </summary>
    public static class StoreProcedure
    {
        #region CLIENT

        #endregion

        #region DRIVER

        #endregion

        #region VEHICLE
        // EJEMPLO: public const string QueHace_NombreDelProcAlmacenado = "Nombre exacto que tiene el procedimiento en la base de datos"
        public const string INSERT_PERSON = "Insert_Person";
        public const string UPDATE_PERSON = "Update_Person";
        public const string DELETE_PERSON = "Delete_Person";

        public const string SELECT_PERSON_ALL = "Select_PersonAll";
        public const string SELECT_PERSON_NAME_BYID = "Select_PersonName_ByPersonID";
        public const string SELECT_PERSON_BY_NAME = "Select_PersonByName";
        public const string SELECT_PERSON_BY_ID = "Select_PersonByID";
        #endregion

        #region MAINTENANCE
        
        #endregion

        #region REPORT
        
        #endregion

        #region SERVICE
        
        #endregion

    }
}