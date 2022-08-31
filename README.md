# ASP.NET WebControl Toolkit
Es una librería desarrollada en Visual Basic .NET con un conjunto de controles personalizados gratuitos y de código abierto para aplicaciones web compatibles con .NET Framework 4.8.

Actualmente se han desarrollado los siguientes controles:

- `CompositeDataBound`
- `Grid`
- `Register`
- `SimpleDataBound`
- `TextBoxData`
- `QuickContacts`


## Configuración inicial 🚀

Descargar la última versión disponible de la librería y añadir la referencia en el proyecto.

Para utilizar solo a nivel de página `.aspx`:
```CSHARP
<%@ Register TagPrefix="wc" Namespace="Jara.WebControl.Toolkit" Assembly="WebControlToolkit" %>
```

Para utilizar a nivel de aplicación `web.config`:
```XML
<pages>
    <controls>
        <add tagPrefix="wc" namespace="Jara.WebControl.Toolkit" assembly="WebControlToolkit" />
    </controls>
</pages>
```

## Referencias 🌐
Documentación oficial de [Microsoft (MSDN)]([https://github.com/jaracoder](https://docs.microsoft.com/en-us/previous-versions/aspnet/9txe1d4x(v=vs.100)?redirectedfrom=MSDN)) como base de desarrollo.

## Licencia 📄

Este proyecto está bajo la licencia de [GNU General Public License v3.0](https://github.com/jaracoder/ASP.NET.WebControl.Toolkit/blob/main/LICENSE.MD).

---
_escrito con ❤️ por [jaracoder](https://github.com/jaracoder)._
