﻿Imports MySql.Data.MySqlClient
Public Class orders
    Dim cmd As New MySqlCommand
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        main.Show()
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call Connect_to_DB()
        Dim myadapter As New MySqlDataAdapter
        Dim mytable As New DataTable
        Dim mygrid As New BindingSource


        Try
            Dim myquery As String
            myquery = "select * from orders"
            cmd = New MySqlCommand(myquery, myconn)
            myadapter.SelectCommand = cmd
            myadapter.Fill(mytable)
            mygrid.DataSource = mytable
            DataGridView1.DataSource = mygrid
            myadapter.Update(mytable)

            myconn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            myconn.Dispose()
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call ExportToExcel(Me.DataGridView1, "Orders.xlsx")
    End Sub
End Class