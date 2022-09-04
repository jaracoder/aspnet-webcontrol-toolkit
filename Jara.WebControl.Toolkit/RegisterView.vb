Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal),
AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal),
DefaultEvent("Submit"), DefaultProperty("ButtonText"),
ToolboxBitmap(GetType(View))>
Public Class RegisterView
    Inherits CompositeControl

    Private nameTextBox, emailTextBox As TextBox
    Private nameLabel, emailLabel As Label
    Private nameValidator, emailValidator As RequiredFieldValidator
    Private submitButton As Button

    Private Shared ReadOnly EventSubmitKey As New Object

    <Bindable(True), Category("Data"), DefaultValue(""),
     Description("Establece el valor del control Nombre.")>
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

    <Bindable(True), Category("Data"), DefaultValue(""),
     Description("Establece el valor del control Email.")>
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

    <Bindable(True), Category("Appearance"), DefaultValue(""),
     Description("Establece el valor del texto del botón.")>
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

    <Bindable(True), Category("Appearance"), DefaultValue(""),
     Description("Establece el valor de la etiqueta del control Nombre.")>
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

    <Bindable(True), Category("Appearance"), DefaultValue(""),
     Description("Establece el valor de la etiqueta del control Email.")>
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

    <Bindable(True), Category("Appearance"), DefaultValue(""),
     Description("Establece el valor del mensaje de error de validación del control Nombre.")>
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

    <Bindable(True), Category("Appearance"), DefaultValue(""),
     Description("El mensaje de error para la validación de la dirección de email.")>
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

    Protected Overridable Sub OnSubmit(e As EventArgs)
        Dim submitHandler As EventHandler = CType(Events(EventSubmitKey), EventHandler)

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
        emailLabel = New Label

        nameTextBox = New TextBox
        nameTextBox.ID = "nameTextBox"

        emailTextBox = New TextBox
        emailTextBox.ID = "emailTextBox"

        nameValidator = New RequiredFieldValidator
        With nameValidator
            .ID = "validator1"
            .ControlToValidate = nameTextBox.ID
            .Text = "Error de validación."
            .Display = ValidatorDisplay.Static
        End With

        emailValidator = New RequiredFieldValidator
        With emailValidator
            .ID = "validator2"
            .ControlToValidate = emailTextBox.ID
            .Text = "Error de validación."
            .Display = ValidatorDisplay.Static
        End With

        submitButton = New Button
        submitButton.ID = "button1"
        AddHandler submitButton.Click, AddressOf submitButton_Click

        Controls.Add(nameLabel)
        Controls.Add(nameTextBox)
        Controls.Add(nameValidator)
        Controls.Add(emailLabel)
        Controls.Add(emailTextBox)
        Controls.Add(emailValidator)
        Controls.Add(submitButton)
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