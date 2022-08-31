Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls




<AspNetHostingPermission(SecurityAction.Demand,
        Level:=Web.AspNetHostingPermissionLevel.Minimal),
        AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level:=Web.AspNetHostingPermissionLevel.Minimal)>
Public Class SimpleDataBoundColumn
    Inherits DataBoundControl

    Public Property DataTextField() As String
        Get
            Dim o As Object = ViewState("DataTextField")

            If o Is Nothing Then
                Return String.Empty
            Else
                Return CStr(o)
            End If
        End Get
        Set(value As String)
            ViewState("DataTextField") = value

            If Initialized Then
                OnDataPropertyChanged()
            End If
        End Set
    End Property


    Protected Overrides Sub PerformSelect()
        If Not IsBoundUsingDataSourceID Then
            OnDataBinding(EventArgs.Empty)
        End If

        GetData.Select(CreateDataSourceSelectArguments, AddressOf OnDataSourceViewSelectCallback)

        RequiresDataBinding = True
        MarkAsDataBound()

        OnDataBound(EventArgs.Empty)
    End Sub

    Private Sub OnDataSourceViewSelectCallback(ByVal retrivedData As IEnumerable)
        If IsBoundUsingDataSourceID Then
            OnDataBinding(EventArgs.Empty)
        End If

        PerformDataBinding(retrivedData)
    End Sub

    Protected Overrides Sub PerformDataBinding(ByVal retrivedData As IEnumerable)
        MyBase.PerformDataBinding(retrivedData)

        If retrivedData IsNot Nothing Then
            Dim tbl As New Table
            Dim row As TableRow
            Dim cell As TableCell
            Dim dataStr As String = String.Empty

            Dim dataItem As Object
            For Each dataItem In retrivedData
                If DataTextField.Length > 0 Then
                    dataStr = DataBinder.GetPropertyValue(dataItem, DataTextField, Nothing)
                Else
                    Dim props As PropertyDescriptorCollection = TypeDescriptor.GetProperties(dataItem)

                    If props.Count >= 1 Then
                        If Nothing <> props(0).GetValue(dataItem) Then
                            dataStr = props(0).GetValue(dataItem).ToString
                        End If
                    End If
                End If

                row = New TableRow
                tbl.Rows.Add(row)
                cell = New TableCell
                cell.Text = dataStr
                row.Cells.Add(cell)
            Next

            Controls.Add(tbl)
        End If
    End Sub


End Class