<%@ Page Title="Historial de versiones" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Changes.aspx.vb" Inherits="Changes" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>Changes</span>
    </div>
    
    <h2>Historial de versiones</h2>
    <br />

    <b>Ver. 1.0.0.5 - 28/08/2022</b>
    <hr />
    <ul>
        <li>Añade la sección de implementación de código en la página de QuickContacts.</li>
        <li>Añade la librería Prettyprint para formatear y estilizar el código fuente.</li>
        <li>Crea la página de inicio y redacta la información inicial y objetivos del proyecto</li>
        <li>Establece el documento por defecto en el Web.config hacia la página de inicio.</li>
        <li>Diseña el footer de la aplicación añadiendo el copyright y el historial de versiones.</li>
    </ul>
    <b>Ver. 1.0.0.4 - 20/02/2017</b>
    <hr />
    <ul>
        <li>Programación en Grid.cs, muestra solo las columnas establecidas en el control.</li>
        <li>Añadido campos de columnas en el DropDownList, depende de las columnas que muestra el grid.</li>
        <li>Diseño general y espacios.</li>
        <li>Refactorización de código</li>
    </ul>
    <b>Ver. 1.0.0.3 - 18/02/2017</b>
    <hr />
    <ul>
        <li>Creación de ejemplo de Microsoft a modo de tutorial (MyHierarchicalDataBoundControl)</li>
    </ul>
    <b>Ver. 1.0.0.2 - 16/02/2017</b>
    <hr />
    <ul>
        <li>Parada de 7 años aproximadamente hasta volver a retomarlo</li>
        <li>Creación de ejemplo de Microsoft a modo de tutorial (SimpleDataBoundColumn)</li>
        <li>Creación de ejemplo de Microsoft a modo de tutorial (CompositeDataBoundColumn)</li>
        <li>Creación de ejemplo de Microsoft a modo de tutorial (Register Component)</li>
        <li>Creación de menu en el Site.Master.</li>
        <li>Creación del componente Grid.</li>
        <li>Añadido archivo de clase SQL.</li>
        <li>Modificado y adaptado la clase SQL.</li>
        <li>Creación del Historial de Versiones.</li>
        <li>Limpieza y refactorización de código en el proyecto.</li>
        <li>Puesta al día la bateria de pruebas.</li>
        <li>Cambio de nombre parcial de UCJAR Controls a .NET Apolox.</li>
        <li>Creación de ejemplo de Microsoft a modo de tutorial (QuickContacts - Colecciones
            de datos).</li>
    </ul>
    <b>Ver. 1.0.0.1 - 22/04/2010</b>
    <hr />
    <ul>
        <li>Inicio del proyecto</li>
        <li>creación de la estructura interna</li>
        <li>primer esqueleto de código</li>
        <li>Establecido nombre del proyecto UCJAR Controls</li>
    </ul>
</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>