<%@ Page Title="TextBoxData" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="TextBoxData.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>TextBoxData</span>
    </div>

    <h3>TextBoxData
        <small class="text-muted">Control de texto enlazado a datos</small>
    </h3>
    <p>
        El control <code>TextBoxData</code> proporciona las mismas funcionalidades que un TextBox 
        convencional con el añadido de poder realizar una vinculación con un motor de 
        acceso a datos.
    </p>
    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:TextBoxData runat="server" ID="txtData"></wc:TextBoxData>

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">&lt;wc:TextBoxData runat=&quot;server&quot; ID=&quot;txtData&quot;&gt;&lt;/wc:TextBoxData&gt;</pre>
</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>
