Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls


<DefaultProperty("Text"),
 ToolboxData("<{0}:TextBoxData runat=server></{0}:TextBox>")>
Public Class TextBoxData
    Inherits TextBox

    <Bindable(True),
        Category("JAR"),
        DefaultValue(""),
        Description("El nombre de la columna en el motor de datos"),
        Localizable(True)>
    Property Columna() As String
        Get
            Dim s As String = CStr(ViewState("Columna"))
            If s Is Nothing Then
                Return "[" & Me.ID & "]"
            Else
                Return s
            End If
        End Get

        Set(ByVal Value As String)
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