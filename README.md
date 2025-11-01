# How to Change Value of Other Columns While Changing the Value in a Combobox Column in WinForms DataGrid?

This example illustrates how to change value of other column while changing the value in combobox column in [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid).

You can change the value of other columns when changing value in GridComboBoxColumn of a row using the [CellComboBoxSelectionChanged](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_CellComboBoxSelectionChanged) event.

#### C#

``` csharp
this.sfDataGrid1.CellComboBoxSelectionChanged += sfDataGrid1_CellComboBoxSelectionChanged;
 
void sfDataGrid1_CellComboBoxSelectionChanged(object sender, CellComboBoxSelectionChangedEventArgs e)
{
   if (e.GridColumn.MappingName == "ShipCityID" && e.SelectedIndex == 0)
        (e.Record as OrderInfo).ShipCountry = "Canada";
}
```
#### VB

``` VB
AddHandler Me.sfDataGrid1.CellComboBoxSelectionChanged, AddressOf sfDataGrid1_CellComboBoxSelectionChanged
 
Private Sub sfDataGrid1_CellComboBoxSelectionChanged(ByVal sender As Object, ByVal e As CellComboBoxSelectionChangedEventArgs)
    If e.GridColumn.MappingName = "ShipCityID" AndAlso e.SelectedIndex = 0 Then
        TryCast(e.Record, OrderInfo).ShipCountry = "Canada"
    End If
End Sub
```