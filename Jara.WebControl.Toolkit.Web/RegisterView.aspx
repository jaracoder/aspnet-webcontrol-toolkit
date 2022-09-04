<%@ Page Title="RegisterView" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="RegisterView.aspx.vb" Inherits="RegisterView" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>RegisterView</span>
    </div>

    <h3>RegisterView
        <small class="text-muted">Control de registro de usuario</small>
    </h3>

    <p>
        El control <code>RegisterView</code> es un ejemplo básico de cómo crear un control compuesto de varios componentes.
        Deriva de la clase <code>CompositeControl</code>, el ejemplo se puede encontrar en el siguiente <a target="_blank" href="https://msdn.microsoft.com/es-es/library/3257x3ea(d=printer,v=vs.100).aspx">enlace</a>.
    </p>
    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:RegisterView ID="RegisterView" runat="server" ButtonText="Validar" NameLabelText="Nombre: " EmailLabelText="Email: "
        EmailErrorMesage="Introduce un email válido. "
        NameErrorMesage="Introduce un nombre vállido. " />

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />

</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>
