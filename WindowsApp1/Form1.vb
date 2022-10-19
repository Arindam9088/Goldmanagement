Imports System.Diagnostics.Eventing.Reader
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Security.Cryptography

Public Class Form1
#Region "Declares"
    Dim myconnection As New DBconnection
    Dim connadapter As MySqlDataAdapter
    Dim datatable As DataTable

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Application.Exit()

    End Sub

    Public Function GetConnadapter() As MySqlDataAdapter
        Return connadapter
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connadapter = New MySqlDataAdapter("Select * From login where Uname = '" & TextBox1.Text & "' And Password = '" & TextBox2.Text & "' And Type = '" & ComboBox1.Text & "'", myconnection.open)
        datatable = New DataTable
        datatable.Clear()
        connadapter.Fill(datatable)
        If datatable.Rows.Count() <= 0 Then
            MessageBox.Show("No One Found")
        Else
            If ComboBox1.Text = "Admin" Then
                MessageBox.Show("Welcome " & TextBox1.Text & "")
                Me.Hide()
                Form2.Show()
            End If
            If ComboBox1.Text = "User" Then
                MessageBox.Show("Welcome " & TextBox1.Text & "")
                Me.Hide()
                Form3.Show()

            End If
        End If
    End Sub




#End Region
End Class
