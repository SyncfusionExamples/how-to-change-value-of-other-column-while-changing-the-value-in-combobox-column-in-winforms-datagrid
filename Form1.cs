#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCommon.Grid;
using System.Windows.Forms.VisualStyles;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input.Enums;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Globalization;
using Syncfusion.WinForms.ListView;
using Syncfusion.WinForms.ListView.Enums;

namespace ColumnTypes
{
    public partial class Form1 : Form
    {
        #region Fields
        OrderInfoCollection orderInfo;
        #endregion

        #region Constuctor
        public Form1()
        {
            InitializeComponent();
            orderInfo = new OrderInfoCollection();
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.DataSource = orderInfo.OrdersListDetails;
            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            NumberFormatInfo numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.CurrencyDecimalDigits = 0;
            numberFormat.CurrencyGroupSizes = new int[] { };

            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                MappingName = "UnitPrice",
                HeaderText = "Unit Price",
                FormatMode = FormatMode.Currency,
                NumberFormatInfo = numberFormat
            });

            numberFormat = Application.CurrentCulture.NumberFormat.Clone() as NumberFormatInfo;
            numberFormat.NumberDecimalDigits = 0;
            numberFormat.NumberGroupSizes = new int[] { };
            this.sfDataGrid1.Columns.Add(new GridNumericColumn()
            {
                HeaderText = "Quantity",
                MappingName = "Quantity",
                FormatMode = FormatMode.Numeric,
                NumberFormatInfo = numberFormat
            });

            this.sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "Discount", HeaderText = "Discount", FormatMode = FormatMode.Percent });
            this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ShipCountry", HeaderText = "Ship Country" });
            this.sfDataGrid1.Columns.Add(new GridComboBoxColumn() { MappingName = "ShipCityID", HeaderText = "Ship City", DisplayMember = "ShipCityName", ValueMember = "ShipCityID", DropDownStyle = DropDownStyle.DropDownList, DataSource = orderInfo.ShipCityDetails });

            this.sfDataGrid1.CellComboBoxSelectionChanged += sfDataGrid1_CellComboBoxSelectionChanged;
        }

        void sfDataGrid1_CellComboBoxSelectionChanged(object sender, CellComboBoxSelectionChangedEventArgs e)
        {
            if (e.GridColumn.MappingName == "ShipCityID" && e.SelectedIndex == 0)
                (e.Record as OrderInfo).ShipCountry = "Canada";
        }

        #endregion
    }
}
