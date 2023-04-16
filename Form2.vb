Imports MySql.Data.MySqlClient
Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form5.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
        Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form6.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim backup As New SaveFileDialog
        backup.InitialDirectory = "C:\"
        backup.Title = "Database Backup"
        backup.CheckFileExists = False
        backup.CheckPathExists = False
        backup.DefaultExt = "sql"
        backup.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*"
        backup.RestoreDirectory = True

        If backup.ShowDialog = Windows.Forms.DialogResult.OK Then
            Call Connect_to_DB()
            Dim cmd As MySqlCommand = New MySqlCommand
            cmd.Connection = myconn
            Dim mb As MySqlBackup = New MySqlBackup(cmd)
            mb.ExportToFile(backup.FileName)
            myconn.Close()
            MessageBox.Show("Database Successfully Backup!", "BACKUP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf backup.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Return
        End If
    End Sub
End Class