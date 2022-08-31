<%@ Page Title="CompositeDataBoundColumn" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="CompositeDataBoundColumn.aspx.vb" Inherits="CompositeDataBoundColumn" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>CompositeDataBoundColumn</span>
    </div>

    <h3>CompositeDataBoundColumn
        <small class="text-muted">Control avanzado enlazado a datos</small>
    </h3>

    <p>
        El control <code>CompositeDataBoundColumn</code> proporciona un ejemplo avanzado de cómo vincular y usar un origen de datos 
        en un control utilizando la clase <code>CompositeDataBoundControl</code>.
    </p>
    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:CompositeDataBoundColumn ID="compostDataBound" runat="server" />

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">&lt;wc:CompositeDataBoundColumn ID=&quot;compostDataBound&quot; runat=&quot;server&quot; /&gt;</pre>
</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>