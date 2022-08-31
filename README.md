# ASP.NET.WebControl.Toolkit
Es una librería desarrollada en Visual Basic .NET con un conjunto de controles personalizados gratuitos y de código abierto para aplicaciones web compatibles con .NET Framework 4.8.

Actualmente se han desarrollado los siguientes controles:

- CompositeDataBound
- Grid
- Register
- SimpleDataBound
- TextBoxData
- QuickContacts


## Configuración inicial 🚀

Descargar la última versión disponible de la librería, añadir la referencia en el proyecto de Visual Studio y añadir la siguientes etiquetas:

_Para utilizar la librería solo a nivel de página (.aspx):_
```
<%@ Register TagPrefix="wc" Namespace="Jara.WebControl.Toolkit" Assembly="WebControlToolkit" %>
```

_Para utilizar la librería a nivel de aplicación (web.config):_
```
<pages>
    <controls>
        <add tagPrefix="wc" namespace="Jara.WebControl.Toolkit" assembly="WebControlToolkit" />
    </controls>
</pages>
```

## Referencias 🌐
Documentación oficial de [Microsoft (MSDN)]([https://github.com/jaracoder](https://docs.microsoft.com/en-us/previous-versions/aspnet/9txe1d4x(v=vs.100)?redirectedfrom=MSDN)) como base de conocimiento para desarrollar los controles de la librería.

## Licencia 📄

Este proyecto está bajo la licencia de GNU General Public License v3.0. Puedes conocer más detalles en el archivo [LICENSE.md](LICENSE.md).

---
_escrito con ❤️ por [jaracoder](https://github.com/jaracoder)._
