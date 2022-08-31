Imports System.Data

Partial Class SimpleDataBoundColumn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            simpleDataBound.DataSource = CreateDataSource()
            simpleDataBound.DataBind()
        End If
    End Sub

    Function CreateDataSource() As ICollection
        Dim dt As DataTable = New DataTable
        Dim dr As DataRow

        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))
        dt.Columns.Add(New DataColumn("ImageValue", GetType(String)))

        Dim i As Integer
        For i = 0 To 8
            dr = dt.NewRow

            dr(0) = i
            dr(1) = "Description for item " & i.ToString
            dr(2) = 1.23 * (i + 1)
            dr(3) = "Image" & i.ToString & ".jpg"

            dt.Rows.Add(dr)
        Next

        Return New DataView(dt)
    End Function




End Class
