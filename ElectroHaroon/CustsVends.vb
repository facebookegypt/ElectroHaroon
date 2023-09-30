Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class CustsVends
    Public SrcFrm As String = Nothing
    Private Ops As New DataOperations
    Private ConnectionString = Ops.GetEncryConStr
    Private Function GetData(query As String) As DataTable
        Using CN As New OleDbConnection(connectionstring),
            CMD As New OleDbCommand(query, CN),
            Sda As New OleDbDataAdapter(CMD),
            MyTable As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            Sda.Fill(MyTable)
            Return MyTable
        End Using
    End Function
    Private Sub CustsVends_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Dim Cryp As ReportDocument = New ReportDocument
        Select Case SrcFrm
            Case Is = "Custms"
                Label14.Text = "بيان العملاء"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports","AllCusts.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM Customers;"))
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
                                    .ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
            Case Is = "Vndrs"
                Dim RP_Path = IO.Path.Combine(Application.StartupPath, "Reports", "AllVends.rpt")
                Cryp.Load(RP_Path)
                Label14.Text = "بيان الموردين" & RP_Path
                Cryp.SetDataSource(GetData("SELECT * FROM Vendors;"))
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
                                    .ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
            Case Is = "CustInv"
                Label14.Text = "بيان معاملات العملاء"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "CustCashIns.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM CustInvs;"))
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
                                    .ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
            Case Is = "VendInv"

                Dim RepPath As String = IO.Path.Combine(Application.StartupPath, "Reports", "VendCash.rpt")
                Label14.Text = "بيان معاملات الموردين"
                Cryp.Load(RepPath)
                Cryp.SetDataSource(GetData("SELECT * FROM VendInvs;"))
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
                                    .ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign
                                End With
                            End If
                        Next
                    Next
                    .RefreshReport()
                    .Refresh()
                End With
        End Select
    End Sub
    Private Sub CustsVends_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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
End Class