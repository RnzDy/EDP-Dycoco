Imports MySql.Data.MySqlClient

Public Class login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Connect_to_DB()
        Dim username = TBusername.Text
        Dim password = TBpassword.Text

        strSQL = $"SELECT * FROM dycoco_act2db.users where username = '{username}' and password = '{password}' limit 1;"


        Dim cmd As New MySqlCommand
        cmd.Connection = myconn
        cmd.CommandText = strSQL

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            MessageBox.Show("Success Login", "Welcome")
            main.Show()
            Hide()

        Else
            MessageBox.Show("Invalid Email or Password", "Login Error")
        End If

        Call Disconnect_to_DB()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class