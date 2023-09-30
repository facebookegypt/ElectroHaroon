Imports System.Data.OleDb
Public Class VendPays
    Private Ops As New DataOperations
    Private ConnectionString = Ops.GetEncryConStr
    Private WithEvents DGPays As DataGridView, MyTable As DataTable =
        New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
    Public ThisCust As Integer, AllCredits() As Decimal, AllInst As Decimal = 0
    Private Sub VendPays_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        DoubleBuffered = True
        If IsNothing(ThisCust) Or ThisCust = 0 Then
            MsgBox("عملية غير صحيحة - مشكلة فى كود المورد - استخدم البحث التالي",
                    MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical)
            Close()
        End If
        DGPays = New DataGridView With {
            .EnableHeadersVisualStyles = False,
            .Dock = DockStyle.Fill,
            .EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2,
            .RightToLeft = RightToLeft.Yes,
            .Name = "DGPays",
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .ReadOnly = False,
            .ScrollBars = ScrollBars.Both,
            .RowHeadersWidth = 30
        }
        With DGPays
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
            .RowHeadersDefaultCellStyle.BackColor = Color.Aquamarine
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Cyan
            .BackgroundColor = Color.AliceBlue
            .RowsDefaultCellStyle.ForeColor = Color.Black
            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowsDefaultCellStyle.Font = New Font("Arial Black", 9.25, FontStyle.Regular)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 13.25, FontStyle.Bold)
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        End With
        GroupBox1.Controls.Add(DGPays)
        AddHandler DGPays.CellFormatting, AddressOf DGPays_CellFormatting
        AddHandler DGPays.CellValueChanged, AddressOf DGPays_CellValueChanged
        AddHandler DGPays.CellEndEdit, AddressOf DGPays_CellEndEdit
        AddHandler DGPays.CellBeginEdit, AddressOf DGPays_CellBeginEdit
        AddHandler DGPays.KeyDown, AddressOf DGPays_RemoveRow
        AllCredits = GetAllPays(ThisCust, 2)
        AllInst = GetAllInsts(ThisCust)
        Dim AllRest As Decimal = AllCredits(2) - AllInst
        Label14.Text = "اجمالي المديونية = " & FormatCurrency(AllCredits(2), 2)
        Label3.Text = "اجمالي المسدد = " & FormatCurrency(AllInst, 2)
        Label1.Text = "اجمالي المتبقي =  = " & FormatCurrency(AllRest, 2)
    End Sub
    Private Sub DGPays_RemoveRow(sender As Object, e As KeyEventArgs)
        If DGPays.Rows.Count > 0 And Not DGPays.CurrentRow Is Nothing Then
            If e.KeyCode = Keys.Delete Then
                Dim Irow As DataGridViewRow = DGPays.CurrentRow
                Dim Dsql As String = "DELETE * FROM CustPaid WHERE PAYID=?;"
                Using newCn As OleDbConnection = New OleDbConnection(connectionstring),
                    NewCmd As OleDbCommand = New OleDbCommand(Dsql, newCn) With {.CommandType = CommandType.Text}
                    With NewCmd.Parameters
                        .AddWithValue("?", CInt(Irow.Cells(0).Value))
                    End With
                    Try
                        newCn.Open()
                        NewCmd.ExecuteNonQuery()
                        DGPays.Rows.Remove(Irow)
                    Catch ex As OleDbException
                        MsgBox(ex.Message)
                    End Try
                End Using
                Dim RecentVals As Double
                For Each Irow1 As DataGridViewRow In DGPays.Rows
                    RecentVals += CDbl(Irow1.Cells(2).FormattedValue.ToString)
                Next
                Label4.Text = FormatCurrency(RecentVals, 2)
            End If
        End If
    End Sub
    Private Sub DGPays_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGPays.Columns(e.ColumnIndex).Name = "المدفوعات" Then
            Dim RecentVals As Double
            For Each Irow As DataGridViewRow In DGPays.Rows
                RecentVals += CDbl(Irow.Cells("المدفوعات").FormattedValue.ToString)
            Next
            If AllCredits(2) <= RecentVals Then
                e.Cancel = True
                MsgBox("تم سداد المديونية بالكامل أو القيمة المسدده أكبر من المديونية")
                DGPays.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub
    Private Sub DGPays_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DGPays.Columns(e.ColumnIndex).Name = "المدفوعات" And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
    End Sub
    Private Sub DGPays_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGPays.Columns(e.ColumnIndex).Name = "المدفوعات" Then
            Dim RecentVals As Double
            For Each Irow As DataGridViewRow In DGPays.Rows
                RecentVals += CDbl(Irow.Cells("المدفوعات").FormattedValue.ToString)
            Next
            Label4.Text = FormatCurrency(RecentVals, 2)
        End If
    End Sub
    Private Sub DGPays_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGPays.Columns(e.ColumnIndex).Name = "المدفوعات" Then
            Dim RecentVals As Double
            For Each Irow As DataGridViewRow In DGPays.Rows
                RecentVals += CDbl(Irow.Cells("المدفوعات").FormattedValue.ToString)
            Next
            If AllCredits(2) < RecentVals Then
                DGPays.CurrentCell.Value = 0
                MsgBox("تم سداد المديونية بالكامل أو القيمة المسدده أكبر من المديونية")
            End If
        End If
    End Sub
    Private Sub _Nback_Click(sender As Object, e As EventArgs) Handles _Nback.Click
        Close()
    End Sub
    Private Sub CustPays_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Location = New Point(0, 0)
        If Height = MainF.Height Then
            Height = MainF.Height / 2
            Exit Sub
        End If
        Height = MainF.Height
    End Sub
    Private Sub MnuDisp_Click(sender As Object, e As EventArgs) Handles MnuDisp.Click
        DisplayAll()
    End Sub
    Private Sub DisplayAll()
        Dim MyTableMain As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
        Dim SqlStr As String =
            "SELECT CustPaid.PAYID, CustPaid.PayDt, CustPaid.Payamnt, CustPaid.PayNotes FROM CustPaid GROUP BY CustPaid.PAYID, CustPaid.PayDt, " &
            "CustPaid.Payamnt, CustPaid.PayNotes, CustPaid.CustID, CustPaid.TranID HAVING (((CustPaid.CustID)=?) AND ((CustPaid.TranID)=1));"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
            MyCmdStr As New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text},
            Da As OleDbDataAdapter = New OleDbDataAdapter(MyCmdStr)
            Da.SelectCommand.Parameters.AddWithValue("?", ThisCust)
            Try
                CN.Open()
                Da.Fill(MyTableMain)
            Catch ex As OleDbException
                MsgBox("Error - Fetching" & vbCrLf & ex.Message)
                Exit Sub
            End Try
        End Using
        With DGPays
            .DataSource = New BindingSource(MyTableMain, Nothing)
            .Columns("PAYID").Visible = False
            .Columns("PayDt").HeaderText = "التاريخ"
            .Columns("Payamnt").HeaderText = "المدفوعات"
            .Columns("Payamnt").ValueType = GetType(Decimal)
            .Columns("Payamnt").DefaultCellStyle.Format = "C2"
            .Columns("PayNotes").HeaderText = "ملاحظات"
            .Refresh()
        End With
        Dim TotalPaid As Double
        If DGPays.Rows.Count > 0 Then
            For Each Irow As DataGridViewRow In DGPays.Rows
                TotalPaid += Val(Irow.Cells("Payamnt").Value.ToString)
            Next
        End If
        Label4.Text = FormatCurrency(TotalPaid, 2)
        _CustS.Enabled = False
        _CustN.Enabled = True
    End Sub
    Private Sub _CustS_Click(sender As Object, e As EventArgs) Handles _CustS.Click
        Dim SqlStrINS As String = "INSERT INTO CustPaid (CustID, PayDt, Payamnt, PayNotes, TranID) VALUES (?,?,?,?,1);"
        For Each Irow As DataGridViewRow In DGPays.Rows
            If Irow.IsNewRow = True Then
                MsgBox("عملية غير صحيحه, القيمة أكبر من المديونية",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المشتريات و المبيعات")
                Exit Sub
            End If
            Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                MyCmdStr As New OleDbCommand(SqlStrINS, CN) With {.CommandType = CommandType.Text}
                CN.Open()
                With MyCmdStr.Parameters
                    .AddWithValue("?", ThisCust)
                    .AddWithValue("?", CDate(Irow.Cells("التاريخ").Value))
                    .AddWithValue("?", Decimal.Parse(Irow.Cells("المدفوعات").Value.ToString))
                    .AddWithValue("?", Irow.Cells("ملاحظات").Value.ToString)
                End With
                'Insert Into CustPays
                If MyCmdStr.ExecuteNonQuery = 0 Then
                    MsgBox("عملية غير صحيحة")
                    Exit Sub
                End If
            End Using
        Next
        MsgBox("تم حفظ المدفوعات " & DGPays.Rows.Count - 1 & " بنجاح.")
        MnuDisp_Click(sender, e)
        Dim AllRest As Decimal = AllCredits(2) - AllInst
        Label14.Text = "اجمالي المديونية = " & FormatCurrency(AllCredits(2), 2)
        Label3.Text = "اجمالي المسدد =  = " & FormatCurrency(AllInst, 2)
        Label1.Text = "اجمالي المتبقي =  = " & FormatCurrency(AllRest, 2)
    End Sub
    Private Sub _CustN_Click(sender As Object, e As EventArgs) Handles _CustN.Click
        Dim R As DataRow = MyTable.NewRow
        If MyTable.Columns.Count > 0 Then
            R(1) = Now.Date
            R(2) = 0
            MyTable.Rows.Add(R)
        Else
            Dim IDCol, DTCol, AmntCol, NotesCol As DataColumn
            IDCol = New DataColumn With {.ColumnName = "م.", .AllowDBNull = True, .DataType = GetType(Integer), .[ReadOnly] = True, .Unique = True,
                .AutoIncrementSeed = 1, .AutoIncrementStep = 1, .AutoIncrement = True}
            DTCol = New DataColumn With {.ColumnName = "التاريخ", .AllowDBNull = False, .DataType = GetType(Date), .[ReadOnly] = False,
                .DefaultValue = Now.Date, .DateTimeMode = DataSetDateTime.Local}
            AmntCol = New DataColumn With {.ColumnName = "المدفوعات", .AllowDBNull = False, .DataType = GetType(Decimal), .DefaultValue = 0,
                .[ReadOnly] = False}
            NotesCol = New DataColumn With {.ColumnName = "ملاحظات", .AllowDBNull = True, .DataType = GetType(String), .[ReadOnly] = False,
                .DefaultValue = String.Empty}
            MyTable.Columns.AddRange({IDCol, DTCol, AmntCol, NotesCol})
            R(IDCol) = 1
            R(AmntCol) = 0
            R(DTCol) = Now.Date
            MyTable.Rows.Add(R)
        End If
        With DGPays
            .DataSource = New BindingSource(MyTable, Nothing)
            .Refresh()
        End With
        DGPays.CurrentCell = DGPays("المدفوعات", DGPays.CurrentCell.RowIndex)
        Dim TotalPaid As Double
        If DGPays.Rows.Count > 0 Then
            For Each Irow As DataGridViewRow In DGPays.Rows
                TotalPaid += Val(Irow.Cells("المدفوعات").Value.ToString)
            Next
        End If

        DGPays.BeginEdit(True)
        _CustS.Enabled = True
    End Sub

    Private Sub MnuPrint_Click(sender As Object, e As EventArgs) Handles MnuPrint.Click
        CashDetails.TargetForm1 = "AllVendPaid"
        Dim Onhr, Onhr1 As Integer
        Dim SalInvDrop As String = "DROP VIEW VendPays;"
        Dim SalInvCreate As String =
            "CREATE VIEW VendPays AS SELECT Vendors.VendNm, PurOrders.PORest, CustPaid.Payamnt, CustPaid.PayNotes, CustPaid.PayDt, CustPaid.PAYID, " &
            "PurOrders.POID FROM CustPaid INNER JOIN (PurOrders INNER JOIN Vendors ON PurOrders.VenID = Vendors.VenID) ON " &
            "CustPaid.CustID = PurOrders.VenID GROUP BY Vendors.VendNm, PurOrders.PORest, CustPaid.Payamnt, CustPaid.PayNotes, CustPaid.PayDt, " &
            "CustPaid.PAYID, Vendors.VenID, PurOrders.POID HAVING (((Vendors.VenID)=" & ThisCust & ") AND ((Sum(PurOrders.TranID))=1));"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                CmdLPur As OleDbCommand = New OleDbCommand(SalInvDrop, CN) With {.CommandType = CommandType.Text},
                CmdLPur1 As OleDbCommand = New OleDbCommand(SalInvCreate, CN) With {.CommandType = CommandType.Text}
            CN.Open()
            Try
                Onhr = CmdLPur.ExecuteNonQuery
                Onhr1 = CmdLPur1.ExecuteNonQuery
            Catch ex As OleDbException
                Onhr1 = CmdLPur1.ExecuteNonQuery
            Finally
                CashDetails.ShowDialog()
            End Try
        End Using
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Private Function GetAllPays(ByVal CustmrID As Integer, ByVal TRID As Integer) As Decimal()
        Dim MyList As Decimal() = Nothing
        'Total, Paid, Rest, INSTALLMENTS, RestOFInstallments
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.POTotal) AS SumOfPOTotal, Sum(PurOrders.POPaid) AS SumOfPOPaid, Sum(PurOrders.PORest) AS SumOfPORest FROM " &
            "PurOrders GROUP BY PurOrders.TranID, PurOrders.VenID HAVING (((PurOrders.TranID)=?) AND ((PurOrders.VenID)=?));"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", 1)
            CMD.Parameters.AddWithValue("?", CustmrID)
            Try
                CN.Open()
                Using Readr As OleDbDataReader = CMD.ExecuteReader
                    If Readr.HasRows Then
                        While Readr.Read
                            MyList = {Readr.GetDecimal(0), Readr.GetDecimal(1), Readr.GetDecimal(2)}
                        End While
                    Else
                        If IsNothing(MyList) Then
                            Return {0, 0, 0}
                            Exit Function
                        End If
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return MyList
    End Function
    Private Function GetAllInsts(ByVal CustID1 As Integer) As Decimal
        Dim cv As Decimal
        Dim SqlStr As String =
            "SELECT Sum(CustPaid.Payamnt) AS SumOfPayamnt FROM CustPaid GROUP BY CustPaid.CustID, CustPaid.TranID HAVING (((CustPaid.CustID)=?) " &
            "AND ((CustPaid.TranID)=1));"
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            Try
                CMD.Parameters.AddWithValue("?", CustID1)
                CN.Open()
                Dim n = CInt(CMD.ExecuteScalar())
                cv = CDec(n)
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return cv
    End Function
End Class