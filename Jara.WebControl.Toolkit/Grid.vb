Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<AspNetHostingPermission(SecurityAction.Demand, Level:=AspNetHostingPermissionLevel.Minimal)>
<AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)>
<DefaultProperty("Columns")>
    <ParseChildren(True, "Columns")>
    <ToolboxData("<{0}:Grid runat=""server""> </{0}:Grid>")>
    Public Class Grid
        Inherits CompositeDataBoundControl

        Private gridView As GridView
        Private dropSearch As DropDownList
        Private txtSearch As TextBox
        Private btnSearch As Button

        Private columnsList As ArrayList

        <Category(".NET Apolox")>
        <Description("Lista de columnas del grid.")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        <Editor(GetType(ColumnCollectionEditor), GetType(UITypeEditor))>
        <PersistenceMode(PersistenceMode.InnerDefaultProperty)>
        Public Property Columns() As ArrayList
            Get
                If columnsList Is Nothing Then
                    columnsList = New ArrayList
                End If

                Return columnsList
            End Get
            Set(value As ArrayList)
                columnsList = value
            End Set
        End Property

    Protected Overrides Function CreateChildControls(dataSource As IEnumerable, dataBinding As Boolean) As Integer
        If dataSource Is Nothing Then
            Return 0
        End If

        Controls.Clear()

        Me.dropSearch = New DropDownList
        Dim item As ListItem
        For Each column As Column In columnsList
            item = New ListItem
            item.Value = column.Value
            item.Text = column.Text

            dropSearch.Items.Add(item)
        Next
        Me.Controls.Add(dropSearch)

        Me.txtSearch = New TextBox
        Me.Controls.Add(txtSearch)

        Me.btnSearch = New Button
        Me.btnSearch.ID = "button1"
        Me.btnSearch.Text = "Buscar"
        '  AddHandler btnSearch.Click, AddressOf submitButton_Click
        Me.Controls.Add(btnSearch)

        Me.gridView = New GridView
        Me.gridView.ID = "grid1"
        Me.gridView.AllowPaging = True
        Me.gridView.PageSize = 5
        Me.gridView.AllowSorting = True
        Me.gridView.CssClass = "table table-striped table-bordered table-hover dataTable context-menu-one"
        Me.gridView.ForeColor = Drawing.Color.Gray

        Me.gridView.AutoGenerateColumns = False
        For Each column As Column In columnsList
            Dim boundField As New BoundField
            boundField.HeaderText = column.Text
            boundField.DataField = column.Value
            boundField.SortExpression = column.Value

            Me.gridView.Columns.Add(boundField)
        Next
        Me.gridView.DataSource = dataSource
        AddHandler Me.gridView.PageIndexChanged, AddressOf PageIndexChanged

        Me.Controls.Add(gridView)

        If Not Page.IsPostBack Then
            Me.gridView.DataBind()
        End If

        Return True
    End Function

    Protected Sub PageIndexChanged(sender As Object, e As EventArgs)
            DirectCast(sender, GridView).SelectedIndex = -1
        End Sub

        Protected Overrides Sub PerformSelect()
            'Llama a DataBinding sino tiene un data source asociado.
            If Not IsBoundUsingDataSourceID Then
                OnDataBinding(EventArgs.Empty)
            End If

            'El método GetData devuelve un objeto de tipo DataSourceView asociado con el data bound.
            GetData().Select(CreateDataSourceSelectArguments(), AddressOf OnDataSourceViewSelectCallback)

            RequiresDataBinding = False
            MarkAsDataBound()
            OnDataBound(EventArgs.Empty)
        End Sub

    Private Sub OnDataSourceViewSelectCallback(retrievedData As IEnumerable)
        'Llama a DataBinding si tiene un data source asociado.
        If IsBoundUsingDataSourceID Then
            OnDataBinding(EventArgs.Empty)
        End If

        PerformDataBinding(retrievedData)
    End Sub

    Protected Overrides Sub PerformDataBinding(retrivedData As IEnumerable)
        MyBase.PerformDataBinding(retrivedData)
    End Sub

    Public Overrides Sub DataBind()
            MyBase.DataBind()

            Controls.Clear()
            ClearChildViewState()
            TrackViewState()
        End Sub

    Protected Overrides Sub OnDataBinding(e As EventArgs)
        MyBase.OnDataBinding(e)
    End Sub

    Protected Overrides Sub Render(writer As HtmlTextWriter)
        AddAttributesToRender(writer)

        writer.RenderBeginTag(HtmlTextWriterTag.Div)
        dropSearch.RenderControl(writer)
        writer.Write("&nbsp;&nbsp;")
        txtSearch.RenderControl(writer)
        writer.Write("&nbsp;&nbsp;")
        btnSearch.RenderControl(writer)
        writer.RenderEndTag()

        writer.RenderBeginTag(HtmlTextWriterTag.Div)
        writer.AddStyleAttribute(HtmlTextWriterStyle.MarginTop, "13px")
        gridView.RenderControl(writer)
        writer.RenderEndTag()
    End Sub

End Class

    Public Class ColumnCollectionEditor
        Inherits CollectionEditor

    Public Sub New(newType As Type)
        MyBase.New(newType)
    End Sub

    Protected Overrides Function CanSelectMultipleInstances() As Boolean
            Return False
        End Function

        Protected Overrides Function CreateCollectionItemType() As Type
            Return GetType(Column)
        End Function

        Protected Overrides Function CreateInstance(itemType As Type) As Object
            Return MyBase.CreateInstance(itemType)
        End Function
    End Class

    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class Column
        Inherits TableCell

        Private _name As String
        Private _value As String
        Private _visible As Boolean

        Public Sub New()
            Me.New(String.Empty, String.Empty, True)
        End Sub

    Public Sub New(name As String, value As String, visible As Boolean)
        _name = name
        _value = value
        _visible = visible
    End Sub

    <Category("Apariencia")>
        <Description("El nombre visible de la columna.")>
        <DefaultValue("")>
        <NotifyParentPropertyAttribute(True)>
        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
        End Property

        <Category("Apariencia")>
        <Description("El valor de la columna.")>
        <DefaultValue("")>
        <NotifyParentPropertyAttribute(True)>
        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(value As String)
                _value = value
            End Set
        End Property
End Class