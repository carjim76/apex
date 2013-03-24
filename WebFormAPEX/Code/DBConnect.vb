Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DBConnect
    Friend strConnection As String
    Friend connection As SqlConnection
    Friend command As SqlCommand
    Friend parameter As SqlParameter
    Friend adapter As SqlDataAdapter
    'Constructor that sets the parameters for the connection to the database
    Sub New()
        strConnection = ConfigurationManager.ConnectionStrings("StrConn").ConnectionString
        connection = New SqlConnection(strConnection)
        command = New SqlCommand
        adapter = New SqlDataAdapter(command)
    End Sub
End Class
