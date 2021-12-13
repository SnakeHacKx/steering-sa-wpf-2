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
        public const string VIEW_USERS = "Usuarios";

        public const string CLIENT_PROFILE = "Cliente";
        public const string VEHICLE_PROFILE = "Vehículo";
        public const string DRIVER_PROFILE = "Conductor";

        public const string ADD_CLIENTE = "Agregar Cliente";
        public const string ADD_DRIVERS = "Agregar Conductor";
        public const string ADD_VEHICLES = "Agregar Vehículo";
        public const string ADD_MAINTENANCE = "Agregar Mantenimiento";
        public const string ADD_REPORTS = "Agregar Reporte";
        public const string ADD_SERVICES = "Agregar Servicio";
        public const string ADD_USERS = "Agregar Usuario";

        public const string EDIT_CLIENT = "Editar Cliente";
        public const string EDIT_DRIVER = "Editar Conductor";
        public const string EDIT_VEHICLE = "Editar Vehículo";
        public const string EDIT_MAINTENANCE = "Editar Mantenimiento";
        public const string EDIT_REPORT = "Editar Reporte";
        public const string EDIT_SERVICE = "Editar Servicio";
        
        
        public const string CHOOSE_DRIVER = "Elegir Conductor";
        public const string CHOOSE_CLIENT = "Elegir Cliente";
        public const string CHOOSE_SERVICE = "Elegir Servicio";
        public const string CHOOSE_REPORT = "Elegir Reporte";
        public const string CHOOSE_VEHICLE= "Elegir Vehículo";
        public const string CHOOSE_MAINTENANCE = "Elegir Mantenimiento";

        public const string LOGIN = "Iniciar Sesión";
        public const string SIGNUP_USER = "Registrar Usuario";
        public const string HISTORY = "Historial";
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
        public const string MAINTENANCE = "Cod_Mantenimiento";
        public const string REPORT = "Cod_reporte";
        public const string SERVICE = "Cod_Servicio";
        public const string TYPE_SERVICE = "Cod_tipo_servicio";
        public const string USER = "Cod_tipo_servicio";
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
        public const string VEHICLE_MODELO = "Modelo_vehiculo";
        public const string VEHICLE_TIPO = "Tipo";
        public const string VEHICLE_PASAJERO = "pasajero";
        public const string VEHICLE_ESTADO= "Estado";
        public const string VEHICLE_TIPO_COMBUSTIBLE = "Tipo_de_combustible";
        public const string VEHICLE_COLOR = "Color";
        #endregion

        #region MAINTENANCE
        public const string MAINTENANCE_CODIGO = "Cod_Mantenimiento";
        public const string MAINTENANCE_PLACA_VEHICULO = "Placa_Vehiculo";
        public const string MAINTENANCE_COD_REPORTE = "Cod_reporte";
        public const string MAINTENANCE_COSTO = "Costo";
        public const string MAINTENANCE_FECHA = "Fecha";
        public const string MAINTENANCE_DESCRIPCION = "Descripcion";
        public const string MAINTENANCE_ESTADO = "Estado";
        #endregion

        #region REPORT 
        public const string REPORT_CODIGO = "Cod_reporte";
        public const string REPORT_PLACA_VEHICULO = "Placa_Vehiculo";
        public const string REPORT_ESTADO = "Estado";
        public const string REPORT_DESCRIPCION = "Descripcion";
        public const string REPORT_FECHA = "Fecha";
        #endregion

        #region SERVICE
        public const string SERVICE_CODIGO = "Cod_Servicio";
        public const string SERVICE_COD_TIPO_SERVICIO = "Cod_Tipo_servicio";
        public const string SERVICE_CEDULA_CONDUCTOR = "Cedula_Conductor";
        public const string SERVICE_PLACA_VEHICULO = "Placa";
        public const string SERVICE_CEDULA_CLIENTE = "Cedula_Cliente";
        public const string SERVICE_FECHA_INICIO = "Fecha_inicio";
        public const string SERVICE_FECHA_FINAL = "Fecha_finalizacion";
        public const string SERVICE_MONTO_TOTAL = "Monto_Total_Servicio";
        #endregion

        #region TYPE_SERVICE
        public const string TYPE_SERVICE_CODIGO = "Cod_tipo_servicio";
        public const string TYPE_SERVICE_NOMBRE = "Nombre_servicio";
        public const string TYPE_SERVICE_COSTO = "Costo_servicio";
        public const string TYPE_SERVICE_DESCRIPCION = "Descripcion_servicio";
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
        public const string SHOW_ALL_CLIENT = "PROC_LISTAR_TODOS_CLIENTES";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_CLIENT_BYID = "PROC_BUSCAR_CEDULA_CLIENTE";//BUSCA POR CEDULA
        public const string FILTERS_CLIENT = "PROC_FILTRO_CLIENTE";// Formato [Nombre o apellido], inicio rango de edad, final rango de edad, direccion
        #endregion

        #region DRIVER
        public const string INSERT_DRIVER = "PROC_REGISTRAR_CONDUCTOR";
        public const string UPDATE_DRIVER = "PROC_ACTUALIZAR_CONDUCTOR";
        public const string DELETE_DRIVER = "PROC_ELIMINAR_CONDUCTOR";
        public const string SHOW_ALL_DRIVER = "PROC_LISTAR_TODOS_CONDUCTORES";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_DRIVER_BYID = "PROC_BUSCAR_CEDULA_CONDUCTOR";//BUSCA POR CEDULA
        public const string FILTERS_DRIVER = "PROC_FILTRO_CONDUCTOR";//Formato [Nombre o apellido], tipo de licencia, inicio rango de edad, final rango de edad
        #endregion

        #region VEHICLE
        // EJEMPLO: public const string QueHace_NombreDelProcAlmacenado = "Nombre exacto que tiene el procedimiento en la base de datos"
        public const string INSERT_VEHICLE = "PROC_REGISTRAR_VEHICULO";
        public const string UPDATE_VEHICLE = "PROC_ACTUALIZAR_DATOS_VEHICULO";
        public const string DELETE_VEHICLE = "PROC_ELIMINAR_VEHICULO";
        public const string SHOW_ALL_VEHICLE = "PROC_LISTAR_TODOS_VEHICULOS";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_VEHICLE_BYPLACA = "PROC_BUSCAR_VEHICULO_POR_PLACA";//BUSCA POR PLACA
        public const string FILTERS_VEHICLE = "PROC_FILTRO_VEHICULO"; //Formato Modelo, tipo de vehiculo, rango inicial pasajeros, rango final pasajeros, tipo de combustible,estado,color
        #endregion

        #region MAINTENANCE
        public const string INSERT_MAINTENANCE = "PROC_REGISTRAR_MANTENIMIENTO";
        public const string UPDATE_MAINTENANCE = "PROC_ACTUALIZAR_MANTENIMIENTO";
        public const string DELETE_MAINTENANCE = "PROC_ELIMINAR_MANTENIMIENTO";
        public const string SHOW_ALL_MAINTENANCE = "PROC_LISTAR_TODOS_MANTENIMIENTOS";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_BYCODE_MAINTENANCE = "PROC_BUSCAR_CODIGO_MANTENIMIENTO";//BUSCA POR EL CODIGO
        public const string FILTERS_MAINTENANCE = "PROC_FILTRO_MANTENIMIENTO";//Formato inicio rango de costo, final rango de costo, inicio rango de fecha, final rango de fechas,estado,placa de vehiculo,tipo de vehiculo
        #endregion

        #region REPORT
        public const string INSERT_REPORT = "PROC_REGISTRAR_REPORTE";
        public const string UPDATE_REPORT = "PROC_ACTUALIZAR_ESTADO_REPORTES";
        public const string DELETE_REPORT = "PROC_ELIMINAR_REPORTE";
        public const string SHOW_ALL_REPORT = "PROC_LISTAR_TODOS_REPORTES";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_BYCODE_REPORT = "PROC_BUSCAR_CODIGO_REPORTE";//BUSCA POR EL CODIGO
        public const string FILTERS_REPORT = "PROC_FILTRO_REPORTE";//Formato inicio rango de fechas, final rango de fechas, estado

        #endregion

        #region SERVICE
        public const string INSERT_SERVICE = "PROC_REGISTRAR_SERVICIO";
        public const string UPDATE_SERVICE = "PROC_ACTUALIZAR_DATOS_SERVICIO";
        public const string DELETE_SERVICE = "PROC_ELIMINAR_SERVICIO";
        public const string SHOW_ALL_SERVICE = "PROC_LISTAR_TODOS_SERVICIOS";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_SERVICE_BYCODE = "PROC_BUSCAR_CODIGO_SERVICIO";//BUSCA POR EL CODIGO
        public const string FILTERS_SERVICE = "PROC_FILTRO_SERVICIO";//Formato Cedula cliente, Cedula conductor, Placa vehiculo, tipo de servicio, tipo de vehiculo, inicio rango de costo, final rango de costo,inicio rango de fecha, final rango de fechas

        #endregion

        #region TYPE_SERVICE
        public const string INSERT_TYPE_SERVICE = "PROC_REGISTRAR_TIPO_SERVICIO";
        public const string UPDATE_TYPE_SERVICE = "PROC_ACTUALIZAR_DATOS_T_SERVICIOS";
        public const string DELETE_TYPE_SERVICE = "PROC_ELIMINAR_TIPO_SERVICIO";
        public const string SHOW_ALL_TYPE_SERVICE = "PROC_LISTAR_TODOS_T_SERVICIOS";//MUESTRA TODOS LOS DATOS GENERALES
        public const string SEARCH_BY_TYPE_SERVICE = "PROC_BUSCAR_CODIGO_TIPO_SERVICIO"; //BUSCA POR EL CODIGO
        public const string SEARCH_TYPE_SERVICE_NAME = "PROC_OBTENER_NOMBRES_T_SERVICIO";
        public const string FILTERS_TYPE_SERVICE = "PROC_FILTRO_TIPO_SERVICIO";
        #endregion

        #region USERS
        public const string INSERT_USER = "PROC_REGISTRAR_USUARIO";
        public const string DELETE_USER = "PROC_ELIMINAR_USUARIO";
        public const string UPDATE_USER_NAME = "PROC_CAMBIAR_NOMBRE_DE_USUARIO";
        public const string UPDATE_USER_PASSWORD = "PROC_CAMBIAR_CONTRASEÑA_USUARIO";
        public const string SHOW_ALL_USERS = "PROC_MOSTRAR_USUARIOS";//Muesta unicamente el nombre de usuario y que rol tiene en el sistema(empleado o administrador)
        public const string GET_TOTALS = "PROC_TOTALES_EN_TABLAS";
        #endregion
    }
}