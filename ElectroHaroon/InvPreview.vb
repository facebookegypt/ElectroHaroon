Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class InvPreview
    Private Ops As New DataOperations
    Private ConnectionString = Ops.GetEncryConStr
    Public TargetForm As String = Nothing
    Private Function GetData(query As String) As DataTable
        Using CN As New OleDbConnection(connectionstring),
            CMD As New OleDbCommand(query, CN),
            Sda As New OleDbDataAdapter(CMD),
            MyTable As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            Sda.Fill(MyTable)
            Return MyTable
        End Using
    End Function
    Private Sub InvPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Dim Cryp As ReportDocument = New ReportDocument
        Select Case TargetForm
            Case Is = "PODetails_Less"
                Label14.Text = "بيان الأصناف الناقصة"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "LessItems.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM Pur_Less;"))
                With CrpSalInv
                    .ReportSource = Cryp
                    Dim Obj As ReportObject
                    Dim Secs As Sections = Cryp.ReportDefinition.Sections
                    Dim Sec As Section = Secs(0)
                    Dim Objs As ReportObjects = Sec.ReportObjects
                    For Each Sec In Secs
                        For Each Obj In Objs
                            If TypeOf Obj Is TextObject Then
                                With Obj
                                    .ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
            Case Is = "PODetails_Prev"
                Label14.Text = "معاينة أمر التوريد"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "PurOrdrPrev_RPT.rpt"))
                Dim ThisDT As New DataTable
                ThisDT = GetData("SELECT * FROM Q_po;")
                Cryp.SetDataSource(ThisDT)
                With CrpSalInv
                    .ReportSource = Cryp
                    Dim Obj As ReportObject
                    Dim Secs As Sections = Cryp.ReportDefinition.Sections
                    Dim Sec As Section = Secs(0)
                    Dim Objs As ReportObjects = Sec.ReportObjects
                    For Each Sec In Secs
                        For Each Obj In Objs
                            If TypeOf Obj Is TextObject Then
                                With Obj
                                    .ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
            Case Is = "Sell_PODetails_Prev"
                Label14.Text = "معاينة فاتورة البيع"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "SalInv.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM Sell_Ordr_Prev;"))
                With CrpSalInv
                    .ReportSource = Cryp
                    Dim Obj As ReportObject
                    Dim Secs As Sections = Cryp.ReportDefinition.Sections
                    Dim Sec As Section = Secs(0)
                    Dim Objs As ReportObjects = Sec.ReportObjects
                    For Each Sec In Secs
                        For Each Obj In Objs
                            If TypeOf Obj Is TextObject Then
                                With Obj
                                    .ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
            Case Is = "All_Pur_O"
                Label14.Text = "بيان جميع أوامر التوريد"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "AllPurOrdrs.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM All_P_Ordrs;"))
                With CrpSalInv
                    .ReportSource = Cryp
                    Dim Obj As ReportObject
                    Dim Secs As Sections = Cryp.ReportDefinition.Sections
                    Dim Sec As Section = Secs(0)
                    Dim Objs As ReportObjects = Sec.ReportObjects
                    For Each Sec In Secs
                        For Each Obj In Objs
                            If TypeOf Obj Is TextObject Then
                                With Obj
                                    .ObjectFormat.HorizontalAlignment = Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
        End Select
    End Sub
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Location = New Point(0, 0)
        If Height = MainF.Height Then
            Height = MainF.Height / 2
            Exit Sub
        End If
        Height = MainF.Height
    End Sub
    Private Sub Label14_MouseDown(sender As Object, e As MouseEventArgs) Handles Label14.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub InvPreview_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
End Class