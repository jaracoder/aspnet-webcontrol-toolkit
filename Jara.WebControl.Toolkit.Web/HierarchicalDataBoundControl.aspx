<%@ Page Title="HierarchicalDataBoundControl" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="HierarchicalDataBoundControl.aspx.vb" Inherits="HierarchicalDataBoundControl" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>HierarchicalDataBoundControl</span>
    </div>

    <h3>HierarchicalDataBoundControl
        <small class="text-muted">Control básico compuesto</small>
    </h3>

    <p>
        El control <code>HierarchicalDataBoundControl</code> es un ejemplo básico de un control compuesto utilizando un 
        <code>GridView</code> como control principal y varios controles secundarios para filtrar la información 
        enlazada a un origen de datos.
    </p>
    <br />


    <h4>Ejemplo</h4>
    <hr />
    <wc:MyHierarchicalDataBoundControl ID="MyHierarchicalDataBoundControl1" runat="server" DataSourceID="dataSourceGrid" />
    <asp:XmlDataSource ID="XmlDataSource1" runat="server"  />
    <asp:SqlDataSource ID="dataSourceGrid" runat="server"
        ConnectionString="<%$ ConnectionStrings:csLocalDatabase %>"
        SelectCommand="SELECT Id, Name, Email, Phone FROM Contact" />

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">&lt;wc:MyHierarchicalDataBoundControl ID=&quot;MyHierarchicalDataBoundControl1&quot; runat=&quot;server&quot; DataSourceID=&quot;dataSourceGrid&quot; /&gt;
    &lt;asp:XmlDataSource ID=&quot;XmlDataSource1&quot; runat=&quot;server&quot;/&gt;
    &lt;asp:SqlDataSource ID=&quot;dataSourceGrid&quot; runat=&quot;server&quot;
        ConnectionString=&quot;&lt;%$ ConnectionStrings:csLocalDatabase %&gt;&quot;
        SelectCommand=&quot;SELECT Id, Name, Email, Phone FROM Contact&quot; /&gt;</pre>
</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>
