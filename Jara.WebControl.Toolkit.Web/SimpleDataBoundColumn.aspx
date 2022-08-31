<%@ Page Title="SimpleDataBoundColumn" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="SimpleDataBoundColumn.aspx.vb" Inherits="SimpleDataBoundColumn" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>SimpleDataBoundColumn</span>
    </div>

    <h3>SimpleDataBoundColumn
        <small class="text-muted">Control básico enlazado a datos</small>
    </h3>

    <p>
        Ejemplo básico de cómo vincular y usar un origen de datos en un control usando la
        clase DataBoundControl. El tutorial se puede encontrar en la siguiente url <a href="https://msdn.microsoft.com/es-es/library/ms366540(v=vs.100).aspx"
            target="_blank">https://msdn.microsoft.com/es-es/library/ms366540(v=vs.100).aspx</a>
    </p>
    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:SimpleDataBoundColumn ID="simpleDataBound" runat="server" />

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">&lt;wc:SimpleDataBoundColumn ID=&quot;simpleDataBound&quot; runat=&quot;server&quot; /&gt;</pre>
</asp:Content>