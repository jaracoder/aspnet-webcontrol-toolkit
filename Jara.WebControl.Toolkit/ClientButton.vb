Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal),
 AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal),
 ToolboxBitmap(GetType(Button)),
 DefaultEvent("Click"), DefaultProperty("Text")>
Public Class ClientButton
    Inherits WebControls.WebControl
    Implements IPostBackEventHandler

    Public Event Click As EventHandler
    Public Event Command As CommandEventHandler

    Private Const ButtonName As String = "__clientButton"

    <Browsable(True),
     Category("Behavior"),
     Description("Indica si habilita o deshabilita la prevención de llamadas múltiples.")>
    Public Property PreventClickTwice() As Boolean
        Get
            Dim o As Object = MyBase.ViewState("DisableAfterClick")
            Return IIf(IsNothing(o), False, CBool(o))
        End Get
        Set(Value As Boolean)
            MyBase.ViewState("DisableAfterClick") = Value
        End Set
    End Property

    <Browsable(True),
     Category("Behavior"),
     Description("Obtiene o establece el nombre de comando asociado al control que se pasa al evento Command.")>
    Public Property CommandName() As String
        Get
            Dim o As Object = MyBase.ViewState("CommandName")
            Return IIf(IsNothing(o), String.Empty, CStr(o))
        End Get
        Set(Value As String)
            MyBase.ViewState("CommandName") = Value
        End Set
    End Property

    <Browsable(True),
     Category("Behavior"),
     Description("Obtiene o establece un parámetro opcional que se pasa al evento Command junto con la propiedad CommandName asociada.")>
    Public Property CommandArgument() As String
        Get
            Dim o As Object = MyBase.ViewState("CommandArgument")
            Return IIf(IsNothing(o), String.Empty, CStr(o))
        End Get
        Set(Value As String)
            MyBase.ViewState("CommandArgument") = Value
        End Set
    End Property

    <Browsable(True),
     Category("Appearance"),
     Description("Valor del texto cuando se realiza el cambio de estado.")>
    Public Property DisabledText() As String
        Get
            Dim o As Object = MyBase.ViewState("DisabledText")
            Return IIf(IsNothing(o), String.Empty, CStr(o))
        End Get
        Set(Value As String)
            MyBase.ViewState("DisabledText") = Value
        End Set
    End Property

    <Browsable(True),
     Category("Appearance"),
     Description("Valor del texto.")>
    Public Property Text() As String
        Get
            Dim o As Object = MyBase.ViewState("Text")
            Return IIf(IsNothing(o), "Button", CStr(o))
        End Get
        Set(Value As String)
            MyBase.ViewState("Text") = Value
        End Set
    End Property

    <Browsable(True),
     Category("Behavior"),
     Description("Indica si el control provoca que se desencadene la validación.")>
    Public Property CausesValidation() As Boolean
        Get
            Dim o As Object = MyBase.ViewState("CausesValidation")
            Return IIf(IsNothing(o), True, CBool(o))
        End Get
        Set(Value As Boolean)
            MyBase.ViewState("CausesValidation") = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New(HtmlTextWriterTag.Input)
    End Sub

    <Browsable(False)>
    Friend ReadOnly Property GetPreventClickTwiceEvent() As String
        Get
            Return "if (typeof(Page_ClientValidate) == 'function') Page_ClientValidate(); "
        End Get
    End Property

    <Browsable(False)>
    Friend ReadOnly Property GetPreventClickTwiceValidateEvent() As String
        Get
            Return "if (typeof(Page_ClientValidate) == 'function') { if(Page_ClientValidate()) { " +
                    GetPreventClickTwiceJavascript + " }} else { " +
                    GetPreventClickTwiceJavascript + " }"
        End Get
    End Property

    <Browsable(False)>
    Friend ReadOnly Property GetPreventClickTwiceJavascript() As String
        Get
            Return "document.getElementsByName('" + ButtonName + "').item(0).setAttribute('name'," +
                   "this.getAttribute('name')); this.disabled = true; " +
                   IIf(DisabledText = String.Empty, String.Empty, "this.value = '" + DisabledText + "';") +
                   "this.form.submit();"
        End Get
    End Property

    Protected Overrides Sub RenderContents(writer As HtmlTextWriter)
    End Sub

    Protected Overrides Sub AddAttributesToRender(writer As HtmlTextWriter)
        Dim strOnClick As String

        If IsNothing(MyBase.Page) Then
            MyBase.Page.VerifyRenderingInServerForm(Me)
        End If

        writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit")
        writer.AddAttribute(HtmlTextWriterAttribute.Name, MyBase.UniqueID)
        writer.AddAttribute(HtmlTextWriterAttribute.Value, Me.Text)

        If Not IsNothing(MyBase.Page) And CausesValidation And MyBase.Page.Validators.Count > 0 Then
            If PreventClickTwice Then
                strOnClick = Me.GetPreventClickTwiceValidateEvent()
            Else
                strOnClick = Me.GetPreventClickTwiceEvent()
            End If

            If Attributes.Count > 0 And Not IsNothing(Attributes("onclick")) Then
                strOnClick = String.Concat(Attributes("onclick"), strOnClick)
                Attributes.Remove("onclick")
            End If

            writer.AddAttribute("language", "javascript")
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, strOnClick)
        ElseIf PreventClickTwice Then
            strOnClick = GetPreventClickTwiceJavascript()

            If Attributes.Count > 0 And Not IsNothing(Attributes("onclick")) Then
                strOnClick = String.Concat(Attributes("onclick"), strOnClick)
                Attributes.Remove("onclick")
            End If

            writer.AddAttribute("language", "javascript")
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, strOnClick)
        End If

        MyBase.AddAttributesToRender(writer)
    End Sub

    Protected Overrides Sub OnInit(e As EventArgs)
        If PreventClickTwice And Not IsHiddenFieldRegistered() Then
            Page.RegisterHiddenField(ButtonName, "")
        End If

        MyBase.OnInit(e)
    End Sub

    Private Function IsHiddenFieldRegistered() As Boolean
        For Each ctl As Control In MyBase.Page.Controls
            If TypeOf ctl Is HtmlControls.HtmlInputHidden Then
                If ctl.ID = ButtonName Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Protected Overridable Sub OnClick(e As EventArgs)
        RaiseEvent Click(Me, e)
    End Sub

    Protected Overridable Sub OnCommand(e As CommandEventArgs)
        RaiseEvent Command(Me, e)
    End Sub

    Private Sub RaisePostBackEvent(eventArgument As String) Implements IPostBackEventHandler.RaisePostBackEvent
        If CausesValidation Then
            Page.Validate()
        End If

        OnClick(New EventArgs)
        OnCommand(New CommandEventArgs(CommandName, CommandArgument))
    End Sub
End Class
