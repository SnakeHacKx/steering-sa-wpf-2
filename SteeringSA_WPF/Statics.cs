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

        public const string CLIENT_PROFILE = "Cliente";
        public const string VEHICLE_PROFILE = "Vehículo";
        public const string CHOOSE_PLANT_IMAGE = "Elegir Imagen de Planta";
        public const string DRIVER_PROFILE = "Conductor";

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
        public const string CLIENT = "Cedula_Cliente";
        public const string DRIVER = "Cedula";
        public const string VEHICLE = "Placa";
        public const string MAINTENANCE = "";
        public const string REPORT = "";
        public const string SERVICE = "Cod_Servicio";
        public const string TYPE_SERVICE = "Cod_tipo_servicio";
    }

    /// <summary>
    /// Contiene todos los nombres de las variables de cada tabla de la base de datos.
    /// </summary>
    public static class TableVariable
    {
        #region CLIENT
        // EJEMPLO: public const string NombreDeLaTabla_NombreDeLaVariable = "Nombre exacto que tiene la variable en la base de datos"
        public const string CLIENT_CEDULA = "Cedula_Cliente";
        public const string CLIENT_NOMBRE = "Nombre_Cliente";
        public const string CLIENT_APELLIDO = "Apellido_Cliente";
        public const string CLIENT_TELEFONO = "Telefono_Cliente";
        public const string CLIENT_FECHA_NACIMIENTO = "Fecha_Nacimiento_Cliente";
        public const string CLIENT_DIRECCION = "Direccion_CLiente";
        #endregion

        #region DRIVER
        public const string DRIVER_CEDULA = "Cedula";
        public const string DRIVER_NOMBRE = "Nombre";
        public const string DRIVER_APELLIDO = "Apellido";
        public const string DRIVER_TELEFONO = "Telefono";
        public const string DRIVER_FECHA_NACIMIENTO = "Fecha_de_nacimiento";
        public const string DRIVER_TIPO_SANGRE = "Tipo_de_sangre";
        public const string DRIVER_TIPO_LICENCIA = "Tipo_de_licencia";
        #endregion

        #region VEHICLE
        public const string VEHICLE_PLACA = "Placa";
        public const string VEHICLE_MOTOR = "Motor";
        public const string VEHICLE_TIPO = "Tipo";
        public const string VEHICLE_ESTADO = "Estado";
        public const string VEHICLE_PASAJERO = "pasajero";
        public const string VEHICLE_TIPO_COMBUSTIBLE = "Tipo_de_combustible";
        public const string VEHICLE_COLOR = "Color";
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
        public const string INSERT_CLIENT = "PROC_REGISTRAR_CLIENTE";
        public const string UPDATE_CLIENT = "PROC_ACTUALIZAR_DATOS_CLIENTE";
        public const string DELETE_CLIENT = "PROC_ELIMINAR_CLIENTE";
        #endregion

        #region DRIVER
        public static string SELECT_DRIVER_ALL = "Select_DriverAll";
        public const string INSERT_DRIVER = "PROC_REGISTRAR_CONDUCTOR";
        public const string UPDATE_DRIVER = "PROC_ACTUALIZAR_CONDUCTOR";
        public const string DELETE_DRIVER = "PROC_ELIMINAR_CONDUCTOR";
        #endregion

        #region VEHICLE
        // EJEMPLO: public const string QueHace_NombreDelProcAlmacenado = "Nombre exacto que tiene el procedimiento en la base de datos"
        public const string INSERT_VEHICLE = "PROC_REGISTRAR_VEHICULO";
        public const string UPDATE_VEHICLE = "PROC_ACTUALIZAR_DATOS_VEHICULO";
        public const string DELETE_VEHICLE = "PROC_ELIMINAR_VEHICULO";

        /*public const string SELECT_PERSON_ALL = "Select_PersonAll";
        public const string SELECT_PERSON_NAME_BYID = "Select_PersonName_ByPersonID";
        public const string SELECT_PERSON_BY_NAME = "Select_PersonByName";
        public const string SELECT_PERSON_BY_ID = "Select_PersonByID";*/
        #endregion

        #region MAINTENANCE
        public const string INSERT_MAINTENANCE = "PROC_REGISTRAR_MANTENIMIENTO";
        public const string UPDATE_MAINTENANCE = "PROC_ACTUALIZAR_MANTENIMIENTO";
        public const string DELETE_MAINTENANCE = "PROC_ELIMINAR_MANTENIMIENTO";
        #endregion

        #region REPORT
        public const string INSERT_REPORT = "PROC_REGISTRAR_REPORTE";
        public const string UPDATE_REPORT = "PROC_ACTUALIZAR_ESTADO_REPORTES";
        public const string DELETE_REPORT = "PROC_ELIMINAR_REPORTE";
        #endregion

        #region SERVICE
        public const string INSERT_SERVICE = "PROC_REGISTRAR_SERVICIO";
        public const string UPDATE_SERVICE = "PROC_ACTUALIZAR_DATOS_SERVICIO";
        public const string DELETE_SERVICE = "PROC_ELIMINAR_SERVICIO";
        #endregion

        #region TYPE_SERVICE
            public const string INSERT_TYPE_SERVICE = "PROC_REGISTRAR_TIPO_SERVICIO";
            public const string UPDATE_TYPE_SERVICE = "PROC_ACTUALIZAR_DATOS_T_SERVICIOS";
            public const string DELETE_TYPE_SERVICE = "PROC_ELIMINAR_TIPO_SERVICIO";
        #endregion

    }
}