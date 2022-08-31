<%@ Page Title="QuickContacts" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="QuickContacts.aspx.vb" Inherits="QuickContacts" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel='stylesheet' type='text/css' href="assets/css/vendor/bootstrap.min.css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <a href="Home.aspx">Inicio</a>
        <span>></span>
        <span>QuickContacts</span>
    </div>

    <h3>QuickContacts
              <small class="text-muted">Libreta de direcciones de contactos</small>
    </h3>
    <p>
        El control <code>QuickContacts</code> permite almacenar una lista de contactos en una libreta de direcciones. 
        El control expone una lista de <code>Contact</code> con todos los objetos de contacto. 
        La clase <code>Contact</code> tiene las propiedades <code>Name, Email y Phone</code>.
    </p>
    <br />

    <h4>Ejemplo</h4>
    <hr />
    <wc:QuickContacts ID="QuickContacts1" runat="server" BorderStyle="Solid" BorderWidth="1px">
        <wc:Contact Name="Juan Antonio" Email="juan@gmail.com" Phone="966123123" />
        <wc:Contact Name="Carlos" Email="carlos@gmail.com" Phone="966234234" />
        <wc:Contact Name="Amador" Email="amador@gmail.com" Phone="623104804" />
        <wc:Contact Name="Silvia" Email="silvina10@gmail.com" Phone="923000234" />
        <wc:Contact Name="Paco" Email="pacosalas@gmail.com" Phone="900125147" />
        <wc:Contact Name="Susana" Email="susana.hi@gmail.com" Phone="618471454" />
        <wc:Contact Name="Alicia" Email="alicia@gmail.com" Phone="654185124" />
        <wc:Contact Name="Gregorio" Email="gregorio@gmail.com" Phone="623158595" />
        <wc:Contact Name="Esteban" Email="esteban@gmail.com" Phone="854845456" />
        <wc:Contact Name="Toñi" Email="toñi123@gmail.com" Phone="968525142" />
        <wc:Contact Name="Dolores" Email="dolores@gmail.com" Phone="630152530" />
        <wc:Contact Name="Esther" Email="esther@gmail.com" Phone="912355362" />
        <wc:Contact Name="Marga" Email="marga@gmail.com" Phone="980141514" />
        <wc:Contact Name="Steve" Email="steve@gmail.com" Phone="623525268" />
        <wc:Contact Name="Jose Antonio" Email="jose.antonio@gmail.com" Phone="695565525" />
        <wc:Contact Name="Ana" Email="ana-gilbert@gmail.com" Phone="615212125" />
        <wc:Contact Name="Vicenta" Email="vicentica92@gmail.com" Phone="648554752" />
        <wc:Contact Name="Javier" Email="javiserrano@gmail.com" Phone="632625252" />
        <wc:Contact Name="Eva" Email="evitaluna@gmail.com" Phone="901141514" />
        <wc:Contact Name="Angela" Email="angela.rivera@gmail.com" Phone="623522255" />
    </wc:QuickContacts>

    <h4>Implementación</h4>
    <hr />
    <pre class="prettyprint linenums">
&lt;%@ Register Assembly=&quot;UCJAR&quot; Namespace=&quot;UCJAR.NET.Controls.Apolox.es&quot; TagPrefix=&quot;cc2&quot; %&gt;

&lt;cc2:QuickContacts ID=&quot;QuickContacts1&quot; runat=&quot;server&quot; BorderStyle=&quot;Solid&quot; BorderWidth=&quot;1px&quot;&gt;
    &lt;cc2:Contact Name=&quot;Juan Antonio&quot; Email=&quot;juan@gmail.com&quot; Phone=&quot;966123123&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Carlos&quot; Email=&quot;carlos@gmail.com&quot; Phone=&quot;966234234&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Amador&quot; Email=&quot;amador@gmail.com&quot; Phone=&quot;623104804&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Silvia&quot; Email=&quot;silvina10@gmail.com&quot; Phone=&quot;923000234&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Paco&quot; Email=&quot;pacosalas@gmail.com&quot; Phone=&quot;900125147&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Susana&quot; Email=&quot;susana.hi@gmail.com&quot; Phone=&quot;618471454&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Alicia&quot; Email=&quot;alicia@gmail.com&quot; Phone=&quot;654185124&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Gregorio&quot; Email=&quot;gregorio@gmail.com&quot; Phone=&quot;623158595&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Esteban&quot; Email=&quot;esteban@gmail.com&quot; Phone=&quot;854845456&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Toñi&quot; Email=&quot;toñi123@gmail.com&quot; Phone=&quot;968525142&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Dolores&quot; Email=&quot;dolores@gmail.com&quot; Phone=&quot;630152530&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Esther&quot; Email=&quot;esther@gmail.com&quot; Phone=&quot;912355362&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Marga&quot; Email=&quot;marga@gmail.com&quot; Phone=&quot;980141514&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Steve&quot; Email=&quot;steve@gmail.com&quot; Phone=&quot;623525268&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Jose Antonio&quot; Email=&quot;jose.antonio@gmail.com&quot; Phone=&quot;695565525&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Ana&quot; Email=&quot;ana-gilbert@gmail.com&quot; Phone=&quot;615212125&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Vicenta&quot; Email=&quot;vicentica92@gmail.com&quot; Phone=&quot;648554752&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Javier&quot; Email=&quot;javiserrano@gmail.com&quot; Phone=&quot;632625252&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Eva&quot; Email=&quot;evitaluna@gmail.com&quot; Phone=&quot;901141514&quot; /&gt;
    &lt;cc2:Contact Name=&quot;Angela&quot; Email=&quot;angela.rivera@gmail.com&quot; Phone=&quot;623522255&quot; /&gt;
&lt;/cc2:QuickContacts&gt;</pre>

    <h4>Referencias</h4>
    <hr />
    <p>
        Puede ver el código del ejemplo en el siguiente <a target="_blank" href="https://msdn.microsoft.com/es-es/library/9txe1d4x(v=vs.100).aspx">enlace</a>. 
    </p>
</asp:Content>
<asp:Content ID="ScriptContent" runat="server" ContentPlaceHolderID="ScriptContent">
</asp:Content>
