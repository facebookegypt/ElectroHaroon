Imports System.IO
Public Class Appsettings
    Sub Write2File()
        IO.File.Create(Application.StartupPath & "\Log.txt")
    End Sub
    Private Sub Appsettings_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Close()
    End Sub
    Private Sub Appsettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            T1.Text = Application.StartupPath
            T2.Text = GetSetting("Maktaba", "BackUp", "Database")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click
        Try
            SaveSetting("Maktaba", "BackUp", "Database", T2.Text)
            ThisBackPath = T2.Text
            MsgBox("تم الحفظ")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ToPath As String = Nothing
        Using OFD1 As New FolderBrowserDialog
            With OFD1
                .ShowNewFolderButton = True
                .ShowDialog()
            End With
            ToPath = OFD1.SelectedPath
        End Using
        Try
            If ToPath.EndsWith("\") Then
                T2.Text = ToPath.Remove(ToPath.Length - 1)
            Else
                T2.Text = ToPath
            End If
            ThisBackPath = T2.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(T2.Text) Then Exit Sub
        Dim OriginalDB As String = Path.Combine(Application.StartupPath, My.Settings.DBName)
        CompRepair(OriginalDB, Path.Combine(T2.Text, "BACKUP.accdb"))
        MsgBox("تم اصلاح قاعدة البيانات")
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Using OFD As OpenFileDialog = New OpenFileDialog
            With OFD
                .Filter = ("All Image files |*.JPG;*.JPEG;*.PNG;*.GIF")
                .ShowDialog()
                TextBox1.Text = .FileName
            End With
        End Using
    End Sub
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If Len(TextBox1.Text) <= 0 Then
            Exit Sub
        Else
            Try
                File.WriteAllText(Application.StartupPath & "\log.txt", TextBox1.Text)
                File.Encrypt(Application.StartupPath & "\log.txt")
                MsgBox("Saved")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class