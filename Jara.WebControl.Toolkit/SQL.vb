Imports System.Data.SqlClient

''' <copyright company='Jaracoder'>
''' Copyright (c) 2017 All Rights Reserved
''' </copyright>
''' <author>Juan Antonio Ripoll Armengol</author>
''' <date>11/02/2017</date>
''' <summary>
''' Management of connections to the SQL Server 
''' database engine and the processing of information.
''' 
''' </summary>
Public Class SQL

    Private Shared _Connection As SqlConnection
    Private Shared _Cmd As SqlCommand
    Private Shared _Adapter As SqlDataAdapter
    Private Shared _Reader As SqlDataReader


    ''' <summary>
    ''' Ejecuta una consulta en el motor de base de datos que no requiera leer datos.
    ''' (INSERT INTO, UPDATE, DELETE)
    ''' </summary>
    ''' <param name="Sql">Consulta SQL para ejecutar (INSERT INTO, UPDATE, DELETE)</param>
    ''' <returns>Retorna Long con el número de filas afectadas en 
    ''' la consulta ejecutada.</returns>
    ''' <remarks>Modifique la base de datos o la ruta del servidor 
    ''' en Web.config (ConnectionsStrings)</remarks>
    Public Shared Function Execute(Sql As String, Optional Cnx As String = Nothing, Optional WebConfigCnxName As String = Nothing) As Long
        If Cnx Is Nothing And WebConfigCnxName Is Nothing Then
            Throw New Exception("No hay conexiones con bases de datos")
        End If

        Dim FilasAfectadas As Long = 0

        Try
            If Cnx Is Nothing Then
                Open(GetConnectionFromWebConfig(WebConfigCnxName))
            Else
                Open(Cnx)
            End If

            _Cmd = New SqlCommand(Sql, _Connection)
            FilasAfectadas = _Cmd.ExecuteNonQuery()

        Catch ex As Exception
            FilasAfectadas = 0
        Finally
            Close()
        End Try

        Return FilasAfectadas
    End Function


    ''' <summary>
    ''' Devuelve un DataTable con los datos de la consulta SQL.
    ''' </summary>
    ''' <param name="Sql">Consulta SQL. SELECT para filtrar la información.</param>
    ''' <returns>Retorna un DataTable con la información.</returns>
    ''' <remarks>Se puede vincular con multitud de controler .NET</remarks>
    Public Shared Function GetDatatable(Sql As String, Optional Cnx As String = Nothing,
                                        Optional WebConfigCnxName As String = Nothing) As DataTable
        If Cnx Is Nothing And WebConfigCnxName Is Nothing Then
            Throw New Exception("No hay conexiones con bases de datos")
        End If

        Dim DataSet As New DataSet
        Dim DataAdapter As New SqlDataAdapter

        Try
            If Cnx Is Nothing Then
                Open(GetConnectionFromWebConfig(WebConfigCnxName))
            Else
                Open(Cnx)
            End If

            _Cmd = New SqlCommand(Sql, _Connection)

            DataAdapter.SelectCommand = _Cmd
            DataAdapter.SelectCommand.Connection = _Connection
            DataAdapter.Fill(DataSet)

        Catch
            DataSet = Nothing
        Finally
            Close()
        End Try

        Return DataSet.Tables(0)
    End Function


    ''' <summary>
    ''' Lee una columna de tipo número en el motor de base de datos.
    ''' </summary>
    ''' <param name="Sql">La consulta SQL que debe tener en el SELECT un campo de tipo NÚMERO
    ''' Ejemplo: "Select SALDO (Numero) From Saldos". Entonces se devolverá el valor de la 
    ''' columna saldo en Entero.</param>
    ''' <returns>Retorna el valor de la columna implementada en el SELECT de la consulta SQL 
    ''' en tipo Integer</returns>
    ''' <remarks>Preparar en la consulta SQL, la columna de tipo NÚMERO.
    ''' Ejemplo SQL: "Select SALDO (Numero) From Saldos".</remarks>
    Public Shared Function GetNumber(Sql As String, Optional Cnx As String = Nothing, Optional WebConfigCnxName As String = Nothing) As String
        If Cnx Is Nothing And WebConfigCnxName Is Nothing Then
            Throw New Exception("No hay conexiones con bases de datos")
        End If

        Dim Dato As String = Nothing

        Try
            If Cnx Is Nothing Then
                Open(GetConnectionFromWebConfig(WebConfigCnxName))
            Else
                Open(Cnx)
            End If

            _Cmd = New SqlCommand(Sql, _Connection)
            _Reader = _Cmd.ExecuteReader()

            If _Reader.Read Then
                Dim objecto As Object = _Reader.GetValue(0)
                Dim tipo As Type = _Reader.GetProviderSpecificFieldType(0)

                Dato = ParserValue(objecto, tipo)
            Else
                Dato = 0
            End If

        Catch ex As Exception
            Dato = Nothing
        Finally
            Close()
        End Try

        Return Dato
    End Function


    ''' <summary>
    ''' Lee una columna de tipo DateTime en el motor de base de datos.
    ''' </summary>
    Public Shared Function GetDate(Sql As String, Optional Cnx As String = Nothing, Optional WebConfigCnxName As String = Nothing) As DateTime
        If Cnx Is Nothing And WebConfigCnxName Is Nothing Then
            Throw New Exception("No hay conexiones con bases de datos")
        End If

        Dim Dato As DateTime = Nothing

        Try
            If Cnx Is Nothing Then
                Open(GetConnectionFromWebConfig(WebConfigCnxName))
            Else
                Open(Cnx)
            End If

            _Cmd = New SqlCommand(Sql, _Connection)
            _Reader = _Cmd.ExecuteReader()

            If _Reader.Read Then
                Dim objecto As Object = _Reader.GetValue(0)
                Dim tipo As Type = _Reader.GetProviderSpecificFieldType(0)

                Dato = ParserValue(objecto, tipo)
            Else
                Dato = Nothing
            End If

        Catch ex As Exception
            Dato = Nothing
        Finally
            Close()
        End Try

        Return Dato
    End Function


    ''' <summary>
    ''' Lee una columna de tipo texto en el motor de base de datos.
    ''' </summary>
    Public Shared Function GetText(Sql As String, Optional Cnx As String = Nothing, Optional WebConfigCnxName As String = Nothing) As String
        If Cnx Is Nothing And WebConfigCnxName Is Nothing Then
            Throw New Exception("No hay conexiones con bases de datos")
        End If

        Dim Dato As String = Nothing

        Try
            If Cnx Is Nothing Then
                Open(GetConnectionFromWebConfig(WebConfigCnxName))
            Else
                Open(Cnx)
            End If

            _Cmd = New SqlCommand(Sql, _Connection)
            _Reader = _Cmd.ExecuteReader()

            If _Reader.Read Then
                Dim objecto As Object = _Reader.GetValue(0)
                Dim tipo As Type = _Reader.GetProviderSpecificFieldType(0)

                Dato = ParserValue(objecto, tipo)
            Else
                Dato = -1
            End If

        Catch ex As Exception
            Dato = Nothing
        Finally
            Close()
        End Try

        Return Dato
    End Function


    Public Shared Function GetImage(Sql As String, Optional Cnx As String = Nothing, Optional WebConfigCnxName As String = Nothing) As Byte()
        If Cnx Is Nothing And WebConfigCnxName Is Nothing Then
            Throw New Exception("No hay conexiones con bases de datos")
        End If

        Dim Dato As Byte() = Nothing

        Try
            If Cnx Is Nothing Then
                Open(GetConnectionFromWebConfig(WebConfigCnxName))
            Else
                Open(Cnx)
            End If

            _Cmd = New SqlCommand(Sql, _Connection)
            _Reader = _Cmd.ExecuteReader()

            If _Reader.Read Then
                Dim objecto As Object = _Reader.GetValue(0)
                Dim tipo As Type = _Reader.GetProviderSpecificFieldType(0)

                Dato = ParserValue(objecto, tipo)

            End If

        Catch ex As Exception
            Dato = Nothing
        Finally
            Close()
        End Try

        Return Dato
    End Function


    Public Shared Function GetSecureQuery(ByVal query As String) As String
        Dim keyName As String = "EnigmaKey"
        Dim certificateName As String = "CertificadoEnigma"

        Dim output As String = Nothing

        output =
            "OPEN SYMMETRIC KEY " & keyName & " DECRYPTION  " &
            "BY CERTIFICATE " & certificateName & vbNewLine
        output += query & vbNewLine
        output += "CLOSE SYMMETRIC KEY " & keyName & ";"

        Return output
    End Function

    Public Shared Function GetConnectionFromWebConfig(ByVal Name As String) As String
        Try
            Return Nothing

            'No es posible la llamada a WebConfigurationManager en un proyecto de biblioteca de clases
            'Return WebConfigurationManager.ConnectionStrings(Name).ConnectionString
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#Region "Private functions"

    Private Shared Sub Open(CnxType As String)
        Try
            If _Connection Is Nothing Then
                _Connection = New SqlConnection(GetConnectionFromWebConfig(CnxType))
            End If

            If _Connection.State <> ConnectionState.Open Then
                _Connection.Open()
            End If
        Catch
            Throw New Exception("Error conexión bd.")
        End Try
    End Sub


    Private Shared Sub Close()
        Try
            If _Connection Is Nothing Then
                Return
            End If

            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If

            While _Connection.State <> ConnectionState.Closed
                '...
            End While

            _Connection = Nothing
        Catch
            Throw New Exception("Error conexión bd.")
        End Try
    End Sub


    ''' <summary>Get and analyzes the value of an object sql</summary>
    ''' <param name="input">Value object of sql</param>
    ''' <param name="type">Type for cast</param>
    ''' <returns>Returns an object with the value</returns>
    Private Shared Function ParserValue(ByVal input As Object, ByVal type As Type) As Object
        Dim output As Object = Nothing

        If input Is Nothing Then Throw New ArgumentNullException("Input argument is null")
        If type Is Nothing Then Throw New ArgumentNullException("Type argument is null")

        Try
            Select Case type
                Case GetType(SqlTypes.SqlString)
                    output = input.ToString
                Case GetType(SqlTypes.SqlInt16)
                    output = Int16.Parse(input)
                Case GetType(SqlTypes.SqlInt32)
                    output = Int32.Parse(input)
                Case GetType(SqlTypes.SqlInt64)
                    output = Int64.Parse(input)
                Case GetType(SqlTypes.SqlDecimal)
                    output = Decimal.Parse(input)
                Case GetType(SqlTypes.SqlMoney)
                    output = Double.Parse(input)
                Case GetType(SqlTypes.SqlDateTime)
                    output = DateTime.Parse(input)
                Case GetType(SqlTypes.SqlBoolean)
                    output = Boolean.Parse(input)
                Case GetType(SqlTypes.SqlBinary)
                    'output = input
            End Select
        Catch ex As Exception
            Throw New Exception("Error attempted to convert object")
        End Try

        Return output
    End Function

#End Region

End Class
