Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Public Class DBconnection
    Dim con As New MySqlConnection("Server=localhost; user=root; password=;database=mmj")
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim result As String

    Public Function open() As MySqlConnection
        Try
            con.Open()
        Catch ex As Exception

        End Try
        Return con
    End Function

    Public Function close() As MySqlConnection
        Try
            con.Close()
        Catch ex As Exception

        End Try
        Return con
    End Function

    Public Sub create(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Failed to Save Data")
                End If
            End With
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub
End Class