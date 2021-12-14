﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SteeringSA_WPF.Views
{
    /// <summary>
    /// Interaction logic for ServicesView.xaml
    /// </summary>
    public partial class ServicesView : UserControl
    {
        private bool isFilterGridOpen;
        private string chosenVehicleID;

        public ServicesView()
        {
            InitializeComponent();
            RefreshDataGrid();
            isFilterGridOpen = true;
            
        }

        private void Btn_ViewProfile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.ChangeWindow(WindowsTitle.HOME, new ViewModels.HomeViewModel());
        }

        private void Btn_TogggleFilters_Click(object sender, RoutedEventArgs e)
        {
            if (isFilterGridOpen)
            {
                isFilterGridOpen = false;
                Bor_Filters.Visibility = Visibility.Collapsed;
                Btn_TogggleFilters.Content = "Mostrar Filtros";
            }
            else
            {
                isFilterGridOpen = true;
                Bor_Filters.Visibility = Visibility.Visible;
                Btn_TogggleFilters.Content = "Ocultar Filtros";
                Dtp_ServiceBeginDate.Text = "";
                Dtp_ServiceEndDate.Text = "";
            }
        }

        /// <summary>
        /// Botón para refrescar el DataGrid.
        /// </summary>
        private void Btn_RefreshDataGrid_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
            Txt_ClientDNI.Text = "";
            Txt_DriverDNI.Text = "";
            Txt_IDReport.Text = "";
            Txt_MaxCost.Text = "";
            Txt_MinCost.Text = "";
            Txt_VehicleID.Text = "";
            Cb_Servicetype.Text = "";
            Dtp_ServiceBeginDate.Text = "";
            Dtp_ServiceEndDate.Text = "";
        }

        /// <summary>
        /// Refresca los datos del DataGrid.
        /// </summary>
        private void RefreshDataGrid()
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ServicesData, TableID.SERVICE, CRUD.GenericCRUD.Instance.SelectAllRecords(StoreProcedure.SHOW_ALL_SERVICE), ref Tb_RecordCount);
        }

        private void Btn_Filter_Click(object sender, RoutedEventArgs e)
        {
            string minCost;
            string maxCost;
            string beginDate;
            string endDate;
            string clientID;
            string driverID;
            string type;
            string vehicleRegis;

            if (Txt_MinCost.Text == "") minCost = null;
            else minCost = Txt_MinCost.Text;

            if (Txt_MaxCost.Text == "") maxCost = null;
            else maxCost = Txt_MaxCost.Text;

            if (Dtp_ServiceBeginDate.Text == "") beginDate = null;
            else beginDate = Dtp_ServiceBeginDate.Text;

            if (Dtp_ServiceEndDate.Text == "") endDate = null;
            else endDate = Dtp_ServiceEndDate.Text;

            if (Txt_ClientDNI.Text == "") clientID = null;
            else clientID = Txt_ClientDNI.Text;

            if (Txt_DriverDNI.Text == "") driverID = null;
            else driverID = Txt_DriverDNI.Text;

            if (Cb_Servicetype.Text == "") type = null;
            else type = Cb_Servicetype.Text;

            if (Txt_VehicleID.Text == "") vehicleRegis = null;
            else vehicleRegis = Txt_VehicleID.Text;

            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ServicesData, TableID.SERVICE, CRUD.Service.Instance.FilterBy(minCost, maxCost, beginDate, endDate, clientID, driverID, type, vehicleRegis), ref Tb_RecordCount);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Dtp_ServiceBeginDate.Text = "";
            Dtp_ServiceEndDate.Text = "";
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            UtilitiesDataGrid.RefreshDataGrid(ref Dgv_ServicesData, TableID.SERVICE, CRUD.GenericCRUD.Instance.SearchBy(StoreProcedure.SEARCH_SERVICE_BYCODE,
                "@Codigo_Servicio", Txt_IDReport.Text), ref Tb_RecordCount);
        }

        private void Btn_EditService_Click(object sender, RoutedEventArgs e)
        {
            Windows.Edit_Service editService = new Windows.Edit_Service(chosenVehicleID);
            editService.RefreshDatagrid += new Windows.Edit_Service.DRefreshDatagrid(RefreshDataGrid);
            editService.ShowDialog();
        }

        private void Dgv_ServicesData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string columnValue = UtilitiesDataGrid.GetColumnValue(sender, 0);

            if (columnValue != null)
            {
                chosenVehicleID = columnValue;
            }
        }
    }
}
