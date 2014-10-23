Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class DataServices
    Private Shared connectionString As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\{0};Integrated Security=True"

    Public Shared Function GetTable(filename As String, selectStatement As String, tableName As String) As DataTable

        'Create connection, passing connectionstring w/ filename included
        Dim cn As SqlConnection = New SqlConnection(String.Format(connectionString, filename))

        'Create data adapter, passing select statement and connection
        Dim da As SqlDataAdapter = New SqlDataAdapter(selectStatement, cn)

        'Create Datatable
        Dim dt As DataTable = New DataTable(tableName)
        Try
            'Fill datatable using adapter
            da.Fill(dt)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Return dt
    End Function

    Public Shared Function SaveTable(filename As String, selectStatement As String, data As DataTable) As Integer

        'Create connection, passing connectionstring w/ filename included
        Dim cn As SqlConnection = New SqlConnection(String.Format(connectionString, filename))

        'Create data adapter, passing select statement and connection
        Dim da As SqlDataAdapter = New SqlDataAdapter(selectStatement, cn)

        'Create Datatable
        Dim rowsSaved As Integer = -1
        Try
            'Fill datatable using adapter
            rowsSaved = da.Update(data)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Return rowsSaved
    End Function

    Public Shared Function SaveRows(filename As String, selectStatement As String, dr() As DataRow) As Integer

        'Create connection, passing connectionstring w/ filename included
        Dim cn As SqlConnection = New SqlConnection(String.Format(connectionString, filename))

        'Create data adapter, passing select statement and connection
        Dim da As SqlDataAdapter = New SqlDataAdapter(selectStatement, cn)

        'Create command builder to add insert, update, and delete statements
        Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)

        'SqlCommandBuilder constructor does not add commands automatically in VB implementation
        da.UpdateCommand = cb.GetUpdateCommand
        da.DeleteCommand = cb.GetDeleteCommand
        da.InsertCommand = cb.GetInsertCommand

        'Create Datatable
        Dim rowsSaved As Integer = -1
        Try
            'Fill datatable using adapter
            rowsSaved = da.Update(dr)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        Return rowsSaved
    End Function

End Class
