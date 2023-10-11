Imports Tulpep.NotificationWindow

Public Class MainF
    Private popupNotifier1 As PopupNotifier
    Public N As Byte = 0
    Public R As Byte = 255
    Public G As Byte = 0
    Public B As Byte = 255
    '14 Nov, 2018
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim Cryp As New Simple3Des(My.Settings.K)
            '---------------------------------------------------------------------------------
            ThisBackPath = GetSetting("Maktaba", "BackUp", "Database")
            If String.IsNullOrEmpty(ThisBackPath) Then ThisBackPath = Application.StartupPath
            If Not ThisBackPath.EndsWith("\") Then ThisBackPath += ("\")
            '---------------------------------------------------------------------------------
            Dim xEXIT As MsgBoxResult =
                MsgBox("هل تريد الخروج من التطبيق؟", MsgBoxStyle.YesNo + MsgBoxStyle.MsgBoxRight +
                MsgBoxStyle.Critical, "Evry1falls - Purchases And Sales Desktop Apps.")
            If xEXIT = MsgBoxResult.Yes Then
                Enabled = False
                Dim OriginalDB As String = IO.Path.Combine(Application.StartupPath, "DB", My.Settings.DBName)
                'This will Compact & Repair MSAccess2007 Database to the same location with the same name.
                Cursor.Current = Cursors.WaitCursor
                'Compact & Repair needs the Database File (*.accdb) to be closed.
                Dim MyAccDB As New Microsoft.Office.Interop.Access.Dao.DBEngine
                Try
                    MyAccDB.CompactDatabase(OriginalDB,
                                    ThisBackPath & "backup" & GenerateRandomString() & ".accdb.bak", , ,
                                    ";pwd=" & Cryp.DecryptData(My.Settings.DataBasePass))
                Catch ex As Exception
                    MsgBox("Error : " & ex.Message)
                End Try
                Enabled = True
                Application.DoEvents()
                Application.Exit()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Enabled = True
            Application.Exit()
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("ItemsFrm") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim CustFrm As New ItemsFrm
        CustFrm.Show(Me)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Cash") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim CustFrm As New Cash
        CustFrm.Show(Me)
    End Sub
    Private Sub MainF_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        Try
            If IO.File.Exists(Application.StartupPath & "\log.txt") Then
                'Me.BackgroundImage = Image.FromFile((IO.File.ReadAllText(Application.StartupPath & "\log.txt")))
            Else
                'Me.BackgroundImage = My.Resources._3d_hd_wallpapers_cool_for_windows_8
            End If
        Catch ex As Exception
            'Me.BackgroundImage = My.Resources._3d_hd_wallpapers_cool_for_windows_8
        End Try
    End Sub
    Private Sub MainF_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Escape) Then
                Button6_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox(Me.Name & " - closing app. Error: " & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub MainF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        Timer1.Enabled = True
    End Sub
    Private Sub popupNotifier1_Click(sender As Object, e As EventArgs)
        MyStore.Show()
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("SalesOrders") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim CustFrm As New SalesOrders
        CustFrm.Show(Me)
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Vndrs") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim Vnds As New Vndrs
        Vndrs.Show(Me)
    End Sub
    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Custms") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim CustFrm As New Custms
        CustFrm.Show(Me)
    End Sub
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("MyStore") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim CustFrm As New MyStore
        CustFrm.Show(Me)
    End Sub
    Private Sub B10_Click(sender As System.Object, e As System.EventArgs) Handles B10.Click
        Dim ThisPass As String = UCase("OIOO285I54O")
        Dim ThisMsg As String = InputBox("Admin Password")
        If ThisMsg <> ThisPass Then
            MsgBox("اعددات البرنامج - 01002851540")
            Exit Sub
        End If
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("AppSettings") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim CustFrm As New Appsettings
        CustFrm.Show(Me)
    End Sub
    Sub Enableall()
        Try
            Button1.Enabled = True
            Button2.Enabled = True
            Button5.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            'Create a green color using the FromRgb static method.
            N += 1
            lblSt.ForeColor = Color.FromArgb(255 - N, R - N, G + N, B / N)
            lblSt.Text = Format(Now, "dddd, dd/MMMM/yyyy" & vbCrLf & " hh:mm:ss tt")
            If N >= 253 Then
                N = 0
            End If
        Catch ex As Exception
            N = 0
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MainF_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim Notif As String = "ليس لديك تنبيهات"
        Dim List1 As List(Of Integer) = New List(Of Integer)
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim SQLSTR As String =
            "SELECT PODetails.PID FROM Products INNER JOIN PODetails ON Products.PID = PODetails.PID GROUP BY PODetails.PID, Products.MinQ, " &
            "Products.MinQ HAVING (((Sum([PODETAILS].[QNTYIN]-[PODETAILS].[QNTYOUT]))<=[PRODUCTS].[MINQ]));"
        Using CN As OleDb.OleDbConnection = New OleDb.OleDbConnection(ConnectionString),
                CMD As OleDb.OleDbCommand = New OleDb.OleDbCommand(SQLSTR, CN)
            Try
                CN.Open()
                Using Readr As OleDb.OleDbDataReader = CMD.ExecuteReader
                    If Readr.HasRows Then
                        While Readr.Read
                            List1.Add(Readr.GetInt32(0))
                        End While
                        Notif = "لديك عدد " & List1.Count.ToString & " أصناف وصلت لأقل كمية أو أصبحت تساوي صفر"
                    Else
                        Notif = "ليس لديك تنبيهات"
                    End If
                End Using
            Catch ex As OleDb.OleDbException
            Finally
                CN.Close()
            End Try
        End Using
        popupNotifier1 = New PopupNotifier With {
            .ContentText = Notif & vbCrLf & Now.Date.ToString("dd - MMMMM - yyyy"),
            .ContentFont = New Font("Times New Roman", 11.25),
            .IsRightToLeft = True,
            .TitleText = "تنبيه",
            .TitleColor = Color.Red,
            .TitleFont = New Font("Arial", 13, FontStyle.Bold),
            .BodyColor = Color.DeepSkyBlue,
            .ContentPadding = New Padding(12),
            .Delay = 4000,
            .BorderColor = Color.Red,
            .HeaderColor = Color.Red,
            .GradientPower = 10
        }
        popupNotifier1.Popup()
        AddHandler popupNotifier1.Click, AddressOf popupNotifier1_Click
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class