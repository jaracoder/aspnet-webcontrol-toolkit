Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<AspNetHostingPermission(SecurityAction.Demand,
            Level:=AspNetHostingPermissionLevel.Minimal),
            AspNetHostingPermission(SecurityAction.InheritanceDemand,
            Level:=AspNetHostingPermissionLevel.Minimal),
            DefaultEvent("Submit"),
            DefaultProperty("ButtonText"),
            ToolboxData("<{0}:Register runat=""server""> </{0}:Register>")>
Public Class Register
    Inherits CompositeControl

    Private submitButton As Button
    Private nameTextBox As TextBox
    Private nameLabel As Label
    Private emailTextBox As TextBox
    Private emailLabel As Label
    Private emailValidator As RequiredFieldValidator
    Private nameValidator As RequiredFieldValidator

    Private Shared ReadOnly EventSubmitKey As New Object

    <Bindable(True),
     Category("Appearance"),
     DefaultValue(""),
     Description("El texto que se mostrará en el botón.")>
    Public Property ButtonText As String
        Get
            EnsureChildControls()
            Return submitButton.Text
        End Get
        Set(value As String)
            EnsureChildControls()
            submitButton.Text = value
        End Set
    End Property

    <
        Bindable(True),
        Category("Default"),
        DefaultValue(""),
        Description("El nombre de usuario.")
        >
    Public Property Name As String
        Get
            EnsureChildControls()
            Return nameTextBox.Text
        End Get
        Set(value As String)
            EnsureChildControls()
            nameTextBox.Text = value
        End Set
    End Property

    <
        Bindable(True),
        Category("Appearance"),
        DefaultValue(""),
        Description("El mensaje de error para la validación del nombre de usuario.")
        >
    Public Property NameErrorMesage As String
        Get
            EnsureChildControls()
            Return nameValidator.ErrorMessage
        End Get
        Set(value As String)
            EnsureChildControls()
            nameValidator.ErrorMessage = value
            nameValidator.ToolTip = value
        End Set
    End Property

    <
        Bindable(True),
        Category("Appearance"),
        DefaultValue(""),
        Description("El texto para la etiqueta del nombre de usuario.")
        >
    Public Property NameLabelText As String
        Get
            EnsureChildControls()
            Return nameLabel.Text
        End Get
        Set(value As String)
            EnsureChildControls()
            nameLabel.Text = value
        End Set
    End Property

    <
        Bindable(True),
        Category("Default"),
        DefaultValue(""),
        Description("La dirección de email.")
        >
    Public Property Email As String
        Get
            EnsureChildControls()
            Return emailTextBox.Text
        End Get
        Set(value As String)
            EnsureChildControls()
            emailTextBox.Text = value
        End Set
    End Property

    <
        Bindable(True),
        Category("Appearance"),
        DefaultValue(""),
        Description("El mensaje de error para la validación de la dirección de email.")
        >
    Public Property EmailErrorMesage As String
        Get
            EnsureChildControls()
            Return emailValidator.ErrorMessage
        End Get
        Set(value As String)
            EnsureChildControls()
            emailValidator.ErrorMessage = value
            emailValidator.ToolTip = value
        End Set
    End Property

    <
        Bindable(True),
        Category("Appearance"),
        DefaultValue(""),
        Description("El texto para la etiqueta de la dirección de email.")
        >
    Public Property EmailLabelText As String
        Get
            EnsureChildControls()
            Return emailLabel.Text
        End Get
        Set(value As String)
            EnsureChildControls()
            emailLabel.Text = value
        End Set
    End Property

    Public Custom Event Submit As EventHandler
        AddHandler(value As EventHandler)
            Events.AddHandler(EventSubmitKey, value)
        End AddHandler

        RemoveHandler(value As EventHandler)
            Events.RemoveHandler(EventSubmitKey, value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As System.EventArgs)
            Dim submitHandler As EventHandler = CType(Events(EventSubmitKey), EventHandler)
            If submitHandler IsNot Nothing Then
                submitHandler(Me, e)
            End If
        End RaiseEvent
    End Event

    Protected Overridable Sub OnSubmit(ByVal e As EventArgs)
        Dim submitHandler As EventHandler =
                CType(Events(EventSubmitKey), EventHandler)

        If submitHandler IsNot Nothing Then
            submitHandler(Me, e)
        End If
    End Sub

    Private Sub submitButton_Click(ByVal source As Object, ByVal e As EventArgs)
        OnSubmit(EventArgs.Empty)
    End Sub

    Protected Overrides Sub CreateChildControls()
        Controls.Clear()

        nameLabel = New Label

        nameTextBox = New TextBox
        nameTextBox.ID = "nameTextBox"

        nameValidator = New RequiredFieldValidator
        nameValidator.ID = "validator1"
        nameValidator.ControlToValidate = nameTextBox.ID
        nameValidator.Text = "Error de validación."
        nameValidator.Display = ValidatorDisplay.Static

        emailLabel = New Label

        emailTextBox = New TextBox
        emailTextBox.ID = "emailTextBox"

        emailValidator = New RequiredFieldValidator
        emailValidator.ID = "validator2"
        emailValidator.ControlToValidate = emailTextBox.ID
        emailValidator.Text = "Error de validación."
        emailValidator.Display = ValidatorDisplay.Static


        submitButton = New Button
        submitButton.ID = "button1"
        AddHandler submitButton.Click, AddressOf submitButton_Click

        Me.Controls.Add(nameLabel)
        Me.Controls.Add(nameTextBox)
        Me.Controls.Add(nameValidator)
        Me.Controls.Add(emailLabel)
        Me.Controls.Add(emailTextBox)
        Me.Controls.Add(emailValidator)
        Me.Controls.Add(submitButton)
    End Sub

    Protected Overrides Sub Render(writer As System.Web.UI.HtmlTextWriter)
        AddAttributesToRender(writer)

        writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1", False)
        writer.RenderBeginTag(HtmlTextWriterTag.Table)

        writer.RenderBeginTag(HtmlTextWriterTag.Tr)
        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        nameLabel.RenderControl(writer)
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        nameTextBox.RenderControl(writer)
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        nameValidator.RenderControl(writer)
        writer.RenderEndTag()
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Tr)
        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        emailLabel.RenderControl(writer)
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        emailTextBox.RenderControl(writer)
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        emailValidator.RenderControl(writer)
        writer.RenderEndTag()
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Tr)
        writer.AddAttribute(HtmlTextWriterAttribute.Colspan, "2", False)
        writer.AddAttribute(HtmlTextWriterAttribute.Align, "right", False)
        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        submitButton.RenderControl(writer)
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Td)
        writer.Write("&nbsp")
        writer.RenderEndTag()
        writer.RenderEndTag()

        writer.RenderEndTag()
    End Sub

End Class