Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal),
AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal),
DefaultEvent("DataBinding"), DefaultProperty("Contacts"),
ParseChildren(True, "Contacts"), 'ParseChildren = habilita el análisis de los elementos de la colección (que sean Contacts)
ToolboxBitmap(GetType(View))>
Public Class ContactsView
    Inherits WebControls.WebControl

    Private contactsList As ArrayList

    <Category("Data"),
    Description("Lista de contactos asociados al control."),
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    Editor(GetType(ContactCollectionEditor), GetType(UITypeEditor)), 'Editor = Asocia un editor de colecciones similar a "Items en un DropDownList".
    PersistenceMode(PersistenceMode.InnerDefaultProperty)>
    Public ReadOnly Property Contacts() As ArrayList
        Get
            If contactsList Is Nothing Then
                contactsList = New ArrayList
            End If

            Return contactsList
        End Get
    End Property

    Protected Overrides Sub RenderContents(writer As HtmlTextWriter)
        Dim t As Table = CreateContactsTable()
        If t IsNot Nothing Then
            t.RenderControl(writer)
        End If
    End Sub

    Private Function CreateContactsTable() As Table
        Dim t As Table = Nothing
        If (contactsList IsNot Nothing) AndAlso
            (contactsList.Count > 0) Then
            t = New Table
            For Each item As Contact In contactsList
                Dim aContact As Contact = TryCast(item, Contact)
                If aContact IsNot Nothing Then
                    Dim r As New TableRow
                    Dim c1 As New TableCell
                    c1.Text = aContact.Name
                    r.Controls.Add(c1)

                    Dim c2 As New TableCell
                    c2.Text = aContact.Email
                    r.Controls.Add(c2)

                    Dim c3 As New TableCell
                    c3.Text = aContact.Phone
                    r.Controls.Add(c3)

                    t.Controls.Add(r)
                End If
            Next
        End If
        Return t
    End Function

End Class

Public Class ContactCollectionEditor
    Inherits CollectionEditor

    Public Sub New(ByVal newType As Type)
        MyBase.New(newType)
    End Sub

    Protected Overrides Function CanSelectMultipleInstances() As Boolean
        Return False
    End Function

    Protected Overrides Function CreateCollectionItemType() As Type
        Return GetType(Contact)
    End Function
End Class

<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class Contact

    Private _name As String
    Private _email As String
    Private _phone As String

    Public Sub New()
        Me.New(String.Empty, String.Empty, String.Empty)
    End Sub

    Public Sub New(name As String, email As String, phone As String)
        _name = name
        _email = email
        _phone = phone
    End Sub

    <Category("Data"),
     Description("Establece el valor nombre."),
     NotifyParentPropertyAttribute(True)>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    <Category("Data"),
     Description("Establece el valor email."),
     NotifyParentPropertyAttribute(True)>
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    <Category("Data"),
     Description("Establece el valor teléfono."),
     NotifyParentPropertyAttribute(True)>
    Public Property Phone() As String
        Get
            Return _phone
        End Get
        Set(value As String)
            _phone = value
        End Set
    End Property
End Class