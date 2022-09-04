<%@ Page Title="ClientButton" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="ClientButton.aspx.vb" Inherits="ClientButton" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>ClientButton</span>
    </div>

    <h3>ClientButton
        <small class="text-muted">Botón de código cliente</small>
    </h3>

    <p>
        El control <code>ClientButton</code> hereda las funcionalidades del objeto <code>Button</code> y además proporciona las siguientes:
    </p>
    <ul>
        <li><code>DisableAfterClick: (true|false)</code> Por defecto está establecido en <code>false</code>. 
            Cuando se establece en <code>true</code> el control de deshabilita cuando el usuario ejecuta el evento 
            <code>Click</code> para prevenir múltiples llamadas.</li>


        <li><code>DisabledText: (string)</code> Establece el nuevo texto del botón cuando se deshabilita.</li>
    </ul>
    
    <br />

    <wc:ClientButton runat="server" Text="¡Haz clic!" ToolTip="¡Haz clic ahora para ver el resultado!" 
        DisableAfterClick="true" DisabledText="Cargando, un momento por favor..." />
    <br />
    <br />

    <h4>Uso</h4>
    <pre class="prettyprint linenums">&lt;wc:ClientButton runat=&quot;server&quot; Text=&quot;Presiona el botón&quot; ToolTip=&quot;¡Haz clic ahora para ver el resultado!&quot; 
            DisableAfterClick=&quot;true&quot; DisabledText=&quot;Cargando, un momento por favor...&quot; /&gt;</pre>

</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>
