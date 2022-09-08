Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal),
AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal),
ToolboxData("<{0}:Text runat='server'></{0}:Text>"), ToolboxBitmap(GetType(TextBox)),
DefaultEvent("TextChanged"), DefaultProperty("Text")>
Public Class Text
    Inherits TextBox

    <Bindable(True),
     Category("Data"),
     Description("Establece el nombre de la columna asociada al control."),
     DefaultValue(""),
     Localizable(True)>
    Property Columna() As String
        Get
            Dim s As String = CStr(ViewState("Columna"))
            If s Is Nothing Then
                Return "[" & ID & "]"
            Else
                Return s
            End If
        End Get

        Set(Value As String)
            ViewState("Columna") = Value
        End Set
    End Property


    Protected Overrides Sub RenderContents(ByVal output As HtmlTextWriter)
        Dim mostrarColumna As String = Columna
        If Context IsNot Nothing Then
            Dim columna As String = Context.User.Identity.Name
            If Not String.IsNullOrEmpty(mostrarColumna) Then
                mostrarColumna = columna
            End If
        End If

        If Not String.IsNullOrEmpty(mostrarColumna) Then
            output.WriteEncodedText(mostrarColumna)
        End If
    End Sub

End Class