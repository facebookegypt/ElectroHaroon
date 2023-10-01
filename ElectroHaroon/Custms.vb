'Editted on April/2019, Aug 2021
'Sept2023
Imports System.Data.OleDb
Public Class Custms
    Private SrchTbl As DataTable
    Private BS As BindingSource
    Sub Clearall()
        For Each Ctrl1 As Control In Me.Controls
            If TypeOf Ctrl1 Is TextBox Then
                Ctrl1.Text = String.Empty
            End If
        Next
    End Sub
    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub Custms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Clearall()
    End Sub
    Private Sub _Nback_Click(sender As Object, e As EventArgs) Handles _Nback.Click
        Close()
    End Sub
    Private Sub Custms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Escape) Then
                _Nback_Click(sender, e)
            End If

        Catch ex As Exception
            LblSt.Text = ("Exit : ") & ex.Message
        End Try
    End Sub
    Private Sub _CMdel_Click(sender As Object, e As EventArgs) Handles _CMdel.Click
        If Val(Tcredits.Text) > 0 Then
            MsgBox("لا يمكن حذف عميل مستحق عليه مبالغ")
            LblSt.Text = String.Empty
            Exit Sub
        End If
        Dim AreYouSure As String =
            MsgBox("تأكيد حذف عميل ؟",
                   MsgBoxStyle.YesNoCancel + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "حذف")
        If AreYouSure = vbYes Then
            Dim Ocust As New Customers With
        {._CustID = CustDG.CurrentRow.Cells("CustID").Value.ToString}
#Region "Delete"
            Dim Onh = Ocust.DeleteCustomer.ToString
#End Region
#Region "Get All Data into CustDG"
            Dim TblCusts As New DataTable
            TblCusts = Ocust.GetData
            BS = New BindingSource
            BS.DataSource = TblCusts
            With CustDG
                .AutoGenerateColumns = False
                .DataSource = BS
                formatDG(CustDG)
            End With
            LblSt.Text = ("تم حذف (" & Onh & ") عميل و لديك الان (" & TblCusts.Rows.Count & ") عميل")
            TblCusts.Dispose()
            Clearall()
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
            _CustN.Enabled = True
            _CustS.Enabled = False
            _CMdel.Enabled = False  'Del
            _CMedit.Enabled = False
        Else
            Exit Sub
        End If
    End Sub
    Private Sub _CustS_Click(sender As Object, e As EventArgs) Handles _CustS.Click
        'Save New Customer
        If String.IsNullOrEmpty(Tname.Text) Or
            String.IsNullOrWhiteSpace(Tname.Text) Then
            MsgBox("أدخل الاسم أولا", MsgBoxStyle.Critical, "حفظ عميل")
            Exit Sub
        End If
        Dim Ocust As New Customers With
            {._CustAdd = Tadd.Text, ._CustMob = Tmob.Text, ._CustNm = Tname.Text, ._CustNote = Tnotes.Text, ._CustTel = Ttel.Text}
#Region "Save"
        Dim Onh = Ocust.SaveNewCust.ToString
#End Region
#Region "Get All Data into CustDG"
        SrchTbl = New DataTable
        SrchTbl = Ocust.GetData
        BS = New BindingSource
        BS.DataSource = SrchTbl
        With CustDG
            .AutoGenerateColumns = False
            .DataSource = BS
            formatDG(CustDG)
        End With
        LblSt.Text = ("تم حفظ (" & Onh & ")" & " عميل. لديك الأن (" & SrchTbl.Rows.Count & ") عميل.")
        SrchTbl.Dispose()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
        _CustN.Enabled = True
        _CustS.Enabled = False
        _CMdel.Enabled = True
        _CMedit.Enabled = True
    End Sub
    Private Sub _CustN_Click(sender As Object, e As EventArgs) Handles _CustN.Click
        Try
            Clearall()
            _CMdel.Enabled = False
            _CMedit.Enabled = False
            _CustS.Enabled = True
            LblSt.Text = String.Empty
            PictureBox1.Image = Nothing
            Tname.Select()
        Catch ex As Exception
            LblSt.Text = ("عميل جديد : ") & ex.Message
        End Try
    End Sub
    Private Sub _CMedit_Click(sender As Object, e As EventArgs) Handles _CMedit.Click
        'Edit Customer
        If IsNothing(CustDG.CurrentCell) Then
            MsgBox("يجب اختيار عميل أولا")
            Exit Sub
        End If
        Dim ThisCustID = CInt(CustDG.CurrentRow.Cells("CustID").Value.ToString)
        Dim Ocust As New Customers With
            {._CustID = ThisCustID,
            ._CustAdd = Tadd.Text,
            ._CustMob = Tmob.Text,
            ._CustNm = Tname.Text,
            ._CustNote = Tnotes.Text,
            ._CustTel = Ttel.Text}
#Region "Update"
        Dim Onh = Ocust.UpdateCustomer.ToString
#End Region
#Region "Get All Data into CustDG"
        SrchTbl = New DataTable
        SrchTbl = Ocust.GetData
        BS = New BindingSource
        BS.DataSource = SrchTbl
        With CustDG
            .AutoGenerateColumns = False
            .DataSource = BS
            formatDG(CustDG)
        End With
        LblSt.Text = ("تم تعديل بيانات العميل بنجاح")
        SrchTbl.Dispose()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
        _CustN.Enabled = True
        _CustS.Enabled = False
        _CMedit.Enabled = False 'Edit
        _CMdel.Enabled = True 'Del
    End Sub
    Private Sub MnuDisp_Click(sender As Object, e As EventArgs) Handles MnuDisp.Click
        Dim Ocust As New Customers
#Region "Get All Data into CustDG"
        Dim TblCusts As New DataTable
        TblCusts = Ocust.GetData
        BS = New BindingSource
        BS.DataSource = TblCusts
        With CustDG
            .AutoGenerateColumns = False
            .DataSource = BS
            formatDG(CustDG)
        End With
        TblCusts.Dispose()
        LblSt.Text = ("لديك عدد " & TblCusts.Rows.Count & " عميل")
#End Region
        CustDG.ClearSelection()
        CustDG.CurrentCell = Nothing
    End Sub
    Private Sub Tname_Enter(sender As Object, e As System.EventArgs) Handles Tname.Enter
        Tname.SelectAll()
    End Sub
    Private Sub Tmob_Enter(sender As Object, e As System.EventArgs) Handles Tmob.Enter
        Tmob.SelectAll()
    End Sub
    Private Sub Ttel_Enter(sender As Object, e As System.EventArgs) Handles Ttel.Enter
        Ttel.SelectAll()
    End Sub
    Private Function GetallPays(ByVal CustID As Integer) As Decimal
        Dim cv As Decimal, N As Integer
        Dim SqlStr As String =
           "SELECT Sum(CustPaid.Payamnt) AS SumOfPayamnt FROM CustPaid GROUP BY CustPaid.CustID HAVING (((CustPaid.CustID)=?));"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", CustID)
            Try
                CN.Open()
                N = CInt(CMD.ExecuteScalar())
                cv = CDec(N)
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return cv
    End Function
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub MnuPrint_Click(sender As Object, e As EventArgs) Handles MnuPrint.Click
        CustsVends.SrcFrm = "Custms"
        CustsVends.ShowDialog()
    End Sub
    Private Function AllSellInv(CustmrID As Integer) As Integer
        Dim C1 As Integer
        If CustDG.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT COUNT(POID) FROM PurOrders WHERE TranID=2 AND CustID=?;"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", CustmrID)
            Try
                CN.Open()
                C1 = CInt(CMD.ExecuteScalar)
                If C1 <> -1 Or Not IsNothing(C1) Then
                    If C1 > 0 Then
                        Button1.Enabled = True
                    Else
                        Button1.Enabled = False
                    End If
                    Return C1
                Else
                    C1 = 0
                    Return C1
                    Exit Function
                End If
            Catch ex As OleDbException
                MsgBox(ex.Message)
                Return C1
            End Try
        End Using
    End Function
    Private Function CustDebts(CustmrID As Integer) As Decimal()
        Dim MyList As Decimal() = {0}
        If CustDG.Rows.Count <= 0 Then
            Return MyList
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.PORest) AS SumOfPORest, Sum(PurOrders.POTotal) AS SumOfPOTotal FROM Customers INNER JOIN PurOrders ON " &
            "Customers.CustID = PurOrders.CustID GROUP BY PurOrders.TranID, Customers.CustID HAVING (((PurOrders.TranID)=2) AND " &
            "((Customers.CustID)=?));"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", CustmrID)
            Try
                CN.Open()
                Using Readr As OleDbDataReader = CMD.ExecuteReader
                    If Readr.HasRows Then
                        Button2.Enabled = True
                        Button3.Enabled = True
                        While Readr.Read
                            MyList = {Readr.GetDecimal(0), Readr.GetDecimal(1)}
                        End While
                        If MyList.Sum = 0 Then
                            Button2.Enabled = True
                            Button3.Enabled = True
                        End If
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return MyList
    End Function
    Private Sub CustDG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CustDG.CellContentClick

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'بيان أوامر البيع
        If String.IsNullOrEmpty(TextBox3.Text) Then Exit Sub
        CustsVends.SrcFrm = "CustInv"
        Dim Onh1 As Object = Nothing, Onh2 As Object = Nothing
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim SqlDel As String = "DROP VIEW CustInvs;"
        Dim SqlStrCreate As String =
            "CREATE VIEW CustInvs AS SELECT PurOrders.POID, PurOrders.PODt, PayTypes.PTNm, Customers.CustNm, Customers.Mob, Customers.Tel, " &
            "Customers.Address, Customers.Notes, PurOrders.POTotal, PurOrders.PODisc, PurOrders.PONet, PurOrders.POPaid, PurOrders.PORest, " &
            "PurOrders.PONots FROM TranTypes INNER JOIN (PayTypes INNER JOIN (Customers INNER JOIN PurOrders ON Customers.CustID = PurOrders.CustID) " &
            "ON PayTypes.PTID = PurOrders.PTId) ON TranTypes.TranID = PurOrders.TranID GROUP BY PurOrders.POID, PurOrders.PODt, PayTypes.PTNm, " &
            "Customers.CustNm, Customers.Mob, Customers.Tel, Customers.Address, Customers.Notes, PurOrders.POTotal, PurOrders.PODisc, PurOrders.PONet, " &
            "PurOrders.POPaid, PurOrders.PORest, PurOrders.PONots, TranTypes.TranID, Customers.CustID HAVING (((TranTypes.TranID)=2) " &
            "AND ((Customers.CustID)=" & CInt(CustDG("CustID", CustDG.CurrentCell.RowIndex).Value.ToString) & "));"
        Using CN12 As OleDbConnection = New OleDbConnection(ConnectionString),
                CmdVcash As OleDbCommand = New OleDbCommand(SqlDel, CN12) With {.CommandType = CommandType.Text},
                CmdVcash1 As OleDbCommand = New OleDbCommand(SqlStrCreate, CN12) With {.CommandType = CommandType.Text}
            CN12.Open()
            Try
                Onh1 = CmdVcash.ExecuteNonQuery
                Onh2 = CmdVcash1.ExecuteNonQuery
            Catch ex As OleDbException
                Onh2 = CmdVcash1.ExecuteNonQuery
            Finally
                CustsVends.ShowDialog()
            End Try
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'بيان اجمالي المديونية
        Button1_Click(sender, e)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'بيان فواتير البيع
        Button1_Click(sender, e)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'بيان المرتجعات

    End Sub
    Private Function GetallPays1() As Decimal
        Dim cv As Decimal
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim SqlStr As String =
           "SELECT Sum(CustPaid.Payamnt) AS SumOfPayamnt FROM CustPaid GROUP BY CustPaid.TranID HAVING (((CustPaid.TranID)=2));"
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Dim n As Integer = CInt(CMD.ExecuteScalar())
                cv = CDec(n)
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return cv
    End Function
    Private Function AllCustsDebts() As Decimal
        Dim cv As Decimal
        If CustDG.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.PORest) AS SumOfPORest FROM PurOrders GROUP BY PurOrders.TranID HAVING (((PurOrders.TranID)=2));"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Dim queryResult = CMD.ExecuteScalar()
                If queryResult Is DBNull.Value Or IsNothing(queryResult) Then
                    ' No matching records. Do something about it.
                Else
                    cv = DirectCast(queryResult, Decimal)
                End If
                Return Decimal.Parse(cv)
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return cv
    End Function
    Private Sub MnuDebts_Click(sender As Object, e As EventArgs) Handles MnuDebts.Click
        TextBox5.Text = FormatCurrency(AllCustsDebts() - GetallPays1(), 2)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        'بيان أوامر البيع
        If String.IsNullOrEmpty(TextBox5.Text) Then Exit Sub
        CashDetails.TargetForm1 = "AllCustsDebts"
        Dim Onh1 As Object = Nothing, Onh2 As Object = Nothing
        Dim SqlDel As String = "DROP VIEW AllCustsDebtsVals;"
        Dim SqlStrCreate As String =
            "CREATE VIEW AllCustsDebtsVals AS SELECT PurOrders.POID, PurOrders.PODt, Customers.CustNm, PurOrders.PORest, PayTypes.PTNm " &
            "FROM TranTypes INNER JOIN (PayTypes INNER JOIN (Customers INNER JOIN PurOrders ON Customers.CustID = PurOrders.CustID) ON " &
            "PayTypes.PTID = PurOrders.PTId) ON TranTypes.TranID = PurOrders.TranID GROUP BY PurOrders.POID, PurOrders.PODt, " &
            "Customers.CustNm, PurOrders.PORest, PayTypes.PTNm, PurOrders.TranID HAVING (((PurOrders.TranID)=2));"
        Using CN12 As OleDbConnection = New OleDbConnection(ConnectionString),
                CmdVcash As OleDbCommand = New OleDbCommand(SqlDel, CN12) With {.CommandType = CommandType.Text},
                CmdVcash1 As OleDbCommand = New OleDbCommand(SqlStrCreate, CN12) With {.CommandType = CommandType.Text}
            CN12.Open()
            Try
                Onh1 = CmdVcash.ExecuteNonQuery
                Onh2 = CmdVcash1.ExecuteNonQuery
            Catch ex As OleDbException
                Onh2 = CmdVcash1.ExecuteNonQuery
            Finally
                CashDetails.ShowDialog()
            End Try
        End Using
    End Sub
    Private Sub _CstPays_Click(sender As Object, e As EventArgs) Handles _CstPays.Click
        If CustDG.Rows.Count <= 0 Then Exit Sub
        '        CustPays.Label14.Text = "اجمالي المديونية = " & Tcredits.Text
        CustPays.Show(Me)
    End Sub

    Private Sub Custms_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.Control AndAlso e.KeyCode = Keys.F Then
            Tsearch.Focus()
        End If
    End Sub
    Private Sub Tsearch_KeyUp(sender As Object, e As KeyEventArgs) Handles Tsearch.KeyUp
        If e.Control OrElse
            e.Shift OrElse
            e.Alt OrElse
            e.KeyCode = Keys.Escape OrElse
            e.KeyCode = Keys.Delete Then
            e.Handled = True
            Exit Sub
        End If
        Try
            Dim Filter As String = "CustNm LIKE '%" & Tsearch.Text & "%'"
            BS1.Filter = Filter
            With CustDG
                .DataSource = BS1
            End With
            formatDG(CustDG)
        Catch ex As Exception
            LblSt.Text = ("عملية غير صحيحة : ") & ex.Message
        End Try
    End Sub
    Private Mysrch As DataTable, BS1 As BindingSource
    Private Sub Tsearch_GotFocus(sender As Object, e As EventArgs) Handles Tsearch.GotFocus
        Dim Ocust As New Customers
        Mysrch = New DataTable
        Mysrch = Ocust.GetData
        BS1 = New BindingSource
        BS1.DataSource = Mysrch
    End Sub
    Private Sub CustDG_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles CustDG.CellMouseClick
        If e.Button = MouseButtons.Left Then
            'If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            If IsNothing(CustDG.CurrentRow) Then Exit Sub
            Dim ThisID = CInt(CustDG.CurrentRow.Cells("CustID").Value.ToString)
            MnuDebts.Enabled = True
            Tcode.Text = ThisID.ToString    'Current ID
            Tname.Text = CustDG.CurrentRow.Cells("CustNm").Value.ToString
            Tmob.Text = CustDG.CurrentRow.Cells("Mob").Value.ToString
            Ttel.Text = CustDG.CurrentRow.Cells("Tel").Value.ToString
            Tadd.Text = CustDG.CurrentRow.Cells("Address").Value.ToString
            Tnotes.Text = CustDG.CurrentRow.Cells("Notes").Value.ToString
            'UPDATE Vendors
            Cursor = Cursors.WaitCursor
            MnuDisp.Enabled = True
            _CustS.Enabled = False  'Save
            _CMedit.Enabled = True  'Edit
            _CMdel.Enabled = True 'Del
            _CustN.Enabled = True 'New
            'Sell Invoices Count
            Dim AllPaid As Double = GetallPays(ThisID)
            TextBox3.Text = AllSellInv(ThisID).ToString
            Dim numbs As Decimal() = CustDebts(ThisID)
            Dim Debits As Double = numbs.First - AllPaid
            Tcredits.Text = Debits.ToString("C2")
            TextBox4.Text = numbs.Last().ToString("C2")
            CustPays.ThisCust = ThisID
            CustPays.TxtCustNm.Text = CustDG.CurrentRow.Cells("CustNm").Value.ToString
            Cursor = Cursors.Default
        End If
    End Sub
End Class