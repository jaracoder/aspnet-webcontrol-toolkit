<%@ Page Title="Grid" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeFile="Grid.aspx.vb" Inherits="Grid" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>Grid</span>
    </div>

    <h2>Grid 
        <small class="text-muted">Tabla enlazada a datos</small>
    </h2>

    <p>
        Implementación inicial de una tabla enlazada a datos utilizando el plug-in <a target="_blank" href="//datatables.net" title="Ir a la página oficial de DataTables.">DataTables</a> para jQuery. 
    </p>
    <p>
        Es un control compuesto de un <code>GridView</code> utilizado para mostrar la información en la tabla 
        con la opción de vincularlo a un control enlazado a datos <code>SqlDataSource</code> del que se obtiene la información a partir de una 
        consulta SQL especificada en la propiedad <code>SelectCommand</code> del control enlazado a datos. 
    </p>
    <p>
        Integra un control secundario como filtro de búsqueda compuesto de un <code>DropDownList</code>, 
        un <code>TextBox</code> y un <code>Button</code> para ejecutar las consultas de búsqueda sobre los registros de la tabla de datos. 
    </p>
    <p>
        Los valores de búsqueda del <code>DropDownList</code> se cargan automáticamente recorriendo 
        las columnas especificadas en la definición del control <code>Grid</code>.
    </p>

    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:Grid runat="server" ID="gridContacts" DataSourceID="dataSourceGrid">
        <wc:Column runat="server" Value="Id">Id</wc:Column>
        <wc:Column runat="server" Value="Name">Nombre</wc:Column>
        <wc:Column runat="server" Value="Email">Email</wc:Column>
        <wc:Column runat="server" Value="Phone">Teléfono</wc:Column>
    </wc:Grid>

    <asp:SqlDataSource ID="dataSourceGrid" runat="server"
        ConnectionString="<%$ ConnectionStrings:csLocalDatabase %>"
        SelectCommand="SELECT Id, Name, Email, Phone FROM Contact" />

    <br />

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">&lt;wc:Grid runat=&quot;server&quot; ID=&quot;gridContacts&quot; DataSourceID=&quot;dataSourceGrid&quot;&gt;
    &lt;wc:Column runat=&quot;server&quot; Value=&quot;Id&quot;&gt;Id&lt;/wc:Column&gt;
    &lt;wc:Column runat=&quot;server&quot; Value=&quot;Name&quot;&gt;Nombre&lt;/wc:Column&gt;
    &lt;wc:Column runat=&quot;server&quot; Value=&quot;Email&quot;&gt;Email&lt;/wc:Column&gt;
    &lt;wc:Column runat=&quot;server&quot; Value=&quot;Phone&quot;&gt;Teléfono&lt;/wc:Column&gt;
&lt;/wc:Grid&gt;

&lt;asp:SqlDataSource ID=&quot;dataSourceGrid&quot; runat=&quot;server&quot; 
    ConnectionString=&quot;&lt;%$ ConnectionStrings:[NombreConnectionString] %&gt;&quot; 
    SelectCommand=&quot;[Consulta]&quot; /&gt;</pre>

</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
    <script src="Assets/js/vendor/jquery.dataTables.min.js"></script>
    <script src="Assets/js/vendor/jquery.dataTables.bootstrap.js"></script>
</asp:Content>
