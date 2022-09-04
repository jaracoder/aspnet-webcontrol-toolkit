Imports System.ComponentModel
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Design.WebControls
Imports System.Web.UI.WebControls



<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal),
AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal),
Designer(GetType(MyHierarchicalDataBoundControlDesigner)),
ToolboxItem(False)>
Public Class MyHierarchicalDataBoundControl
    Inherits HierarchicalDataBoundControl

End Class

Public Class MyHierarchicalDataBoundControlDesigner
    Inherits HierarchicalDataBoundControlDesigner

    Private Const bracketClose As String = ">"
    Private Const spanOpen As String = "<span"
    Private Const spanClose As String = "</span>"

    Public Overrides Function GetDesignTimeHtml() As String
        Dim markup As String = MyBase.GetDesignTimeHtml

        If markup Is Nothing OrElse markup = String.Empty Then
            Return GetEmptyDesignTimeHtml()
        End If

        Dim markupUC As String = markup.ToUpper
        Dim charX As Integer

        charX = markupUC.IndexOf(spanOpen)
        If charX >= 0 Then
            charX = markupUC.IndexOf(bracketClose, charX + spanOpen.Length)
            If charX >= 0 Then
                If String.Compare(markupUC, charX + 1, spanClose, 0, spanClose.Length) = 0 Then
                    Return GetEmptyDesignTimeHtml()
                End If
            End If
        End If

        Return markup
    End Function

    Protected Overrides Function GetEmptyDesignTimeHtml() As String
        Return "<b>Hola juan, vas bien</b>"
    End Function

    Protected Overrides Sub PreFilterProperties(properties As System.Collections.IDictionary)
        Dim namingContainer As String = "NamingContainer"
        MyBase.PreFilterProperties(properties)

        Dim selectProp As PropertyDescriptor = CType(properties(namingContainer), PropertyDescriptor)
        properties(namingContainer) = TypeDescriptor.CreateProperty(selectProp.ComponentType, selectProp, BrowsableAttribute.Yes)
    End Sub


End Class