Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Public Class CashDetails
    Public TargetForm1 As String = Nothing
    Private Function GetData(query As String) As DataTable
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As New OleDbConnection(connectionstring),
            CMD As New OleDbCommand(query, CN),
            Sda As New OleDbDataAdapter(CMD),
            MyTable As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            Sda.Fill(MyTable)
            Return MyTable
        End Using
    End Function
    Private Sub CashDetails_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            Custms.Activate()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub CashDetails_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then
            Close()
        End If
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
    Private Sub CashDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Dim Cryp As ReportDocument = New ReportDocument
        Select Case TargetForm1
            Case Is = "AllCustsDebts"
                Label14.Text = "اجمالي المستحق علي العملاء"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "AllCustsDebtsRP.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM AllCustsDebtsVals;"))
                With CRP1
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
            Case Is = "AllVendsDebts"
                Label14.Text = "اجمالي المستحق للموردين"
                Cryp.Load(IO.Path.Combine(Application.StartupPath, "Reports", "AllVendsDebtsRP.rpt"))
                Cryp.SetDataSource(GetData("SELECT * FROM AllVendsDebtsVals;"))
                With CRP1
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
            Case Is = "AllCustPaid"
                Label14.Text = "بيان المتحصلات من العميل"
                Dim RepPath As String = IO.Path.Combine(Application.StartupPath, "Reports", "CustInstalls.rpt")
                Cryp.Load(RepPath)
                Cryp.SetDataSource(GetData("SELECT * FROM CustInsts;"))
                With CRP1
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
            Case Is = "AllVendPaid"
                Dim RepPath As String = IO.Path.Combine(Application.StartupPath, "Reports", "VendInstalls.rpt")
                Label14.Text = "بيان المدفوعات للمورد"
                Cryp.Load(RepPath)
                Cryp.SetDataSource(GetData("SELECT * FROM VendPays;"))
                With CRP1
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
End Class