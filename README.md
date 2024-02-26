# How to change value of other columns while changing the value in a combobox column in WinForms DataGrid (SfDataGrid)

## Change the value of other columns

You can change the value of other columns when changing value in GridComboBoxColumn of a row using the [CellComboBoxSelectionChanged](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html?_ga=2.142611645.967019853.1668146580-766490130.1650530957&_gl=1*19fri0z*_ga*NzY2NDkwMTMwLjE2NTA1MzA5NTc.*_ga_WC4JKKPHH0*MTY2ODE0ODc4MS4yOTYuMS4xNjY4MTQ4OTUzLjAuMC4w) event.

## C# 

```C#
this.sfDataGrid1.CellComboBoxSelectionChanged += sfDataGrid1_CellComboBoxSelectionChanged;
 
void sfDataGrid1_CellComboBoxSelectionChanged(object sender, CellComboBoxSelectionChangedEventArgs e)
{
   if (e.GridColumn.MappingName == "ShipCityID" && e.SelectedIndex == 0)
      (e.Record as OrderInfo).ShipCountry = "Canada";
}
```

## VB

```VB
AddHandler Me.sfDataGrid1.CellComboBoxSelectionChanged, AddressOf sfDataGrid1_CellComboBoxSelectionChanged
 
Private Sub sfDataGrid1_CellComboBoxSelectionChanged(ByVal sender As Object, ByVal e As CellComboBoxSelectionChangedEventArgs)
   If e.GridColumn.MappingName = "ShipCityID" AndAlso e.SelectedIndex = 0 Then
 TryCast(e.Record, OrderInfo).ShipCountry = "Canada"
   End If
End Sub
```