<%@ Page Title="Inicio" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Home.aspx.vb" Inherits="Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div>
        <span>Inicio</span>
    </div>

    <h4>Definición y objetivos</h4>
    <hr />
    <p>
        <b>ASP.NET WebControl Toolkit</b> es una librería desarrollada en VB.NET con un conjunto de <b>controles personalizados gratuitos y 
        de código abierto</b> para aplicaciones web compatibles con .NET Framework 4.8.
    </p>
    <p>
        El objetivo del proyecto es disponer de una <strong>librería de controles con características y funcionalidades extendidas</strong>
        a los controles que proporciona la plataforma .NET.
    </p>

    <br />
    <h4>Controles de la librería</h4>
    <hr />
    <p>La librería dispone de los siguientes controles:</p>

    <div class="toolbox">
        <div class="toolbox-img">
            <img src="Assets/img/toolbox.jpg" alt="Controles toolbox" />
        </div>
        <div class="toolbox-ul">
            <ul>
                <li><a href="ClientButton.aspx">ClientButton</a></li>
                <li><a href="ContactsView.aspx">ContactsView</a></li>
                <li><a href="Grid.aspx">Grid</a></li>
                <li><a href="RegisterView.aspx">RegisterView</a></li>
                <li><a href="Text.aspx">Text</a></li>
            </ul>
        </div>
        <div style="clear:both;"></div>
    </div>

    <br />
    <h4>Utilizar la librería</h4>
    <hr />
    <p>
        Descargar la última versión disponible de la librería, añadir la referencia en el proyecto de Visual Studio y añadir la siguientes etiquetas:
    </p>

    <p>
        Para utilizar la librería solo a nivel de página (.aspx):
    </p>
    <pre class="prettyprint linenums">&lt;%@ Register TagPrefix=&quot;wc&quot; Namespace=&quot;Jara.WebControl.Toolkit&quot; Assembly=&quot;WebControlToolkit&quot; %&gt;</pre>

    <p>
        Para utilizar la librería a nivel de aplicación (web.config):
    </p>
    <pre class="prettyprint linenums">&lt;pages&gt;
    &lt;controls&gt;
        &lt;add tagPrefix=&quot;wc&quot; namespace=&quot;Jara.WebControl.Toolkit&quot; assembly=&quot;WebControlToolkit&quot; /&gt;
    &lt;/controls&gt;
&lt;/pages&gt;</pre>

    <br />
    <h4>Ejemplos</h4>
    <hr />
    <p>Los siguientes controles se han desarrollado a modo de ejemplo:</p>
    <ul>
        <li><a href="CompositeDataBoundColumn.aspx">CompositeDataBound</a></li>
        <li><a href="HierarchicalDataBoundControl.aspx">HierarchicalDataBoundControl</a></li>
        <li><a href="SimpleDataBoundColumn.aspx">SimpleDataBound</a></li>
    </ul>

    <br />
    <h4>Documentación</h4>
    <hr />
    <p>Aquí puedes consultar la documentación y ver ejemplos de los controles, además en el <a href="Changes.aspx" title="Registro de cambios">historial de versiones</a> puedes consultar el detalle de cambios por versiones.</p>

    <br />
    <h4>Referencias</h4>
    <hr />
    <p>
        Se utiliza la documentación oficial de <a target="_blank" href="https://msdn.microsoft.com/es-es/library/9txe1d4x(v=vs.100).aspx">Microsoft (MSDN)</a> como base de conocimiento para desarrollar los controles de la librería.
    </p>

    <br />
    <h4>Autor</h4>
    <hr />
    <p>Ideado y desarrollado por Juan Antonio Ripoll Armengol.</p>

    <br />
    <h4>Licencia</h4>
    <hr />
    <p>Este proyecto está bajo la licencia de GNU General Public License v3.0.</p>
</asp:Content>
