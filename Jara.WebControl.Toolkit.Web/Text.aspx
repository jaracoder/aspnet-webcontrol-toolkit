<%@ Page Title="Text" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Text.aspx.vb" Inherits="Text" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>Text</span>
    </div>

    <h3>Text
        <small class="text-muted">Control de texto enlazado a datos</small>
    </h3>
    <p>
        El control <code>Text</code> hereda las funcionalidades de un <code>TextBox</code>
        convencional con el añadido de poder realizar una vinculación con un 
        origen de datos.
    </p>
    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:Text runat="server" ID="txtData" />

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">&lt;wc:Text runat=&quot;server&quot; ID=&quot;txtData&quot;&gt;&lt;/wc:Text&gt;</pre>
</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>
