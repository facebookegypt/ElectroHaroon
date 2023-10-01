'Editted on April/2019, Aug 2021
'30Sept2023
Imports System.Data.OleDb
Public Class Vndrs
    Private SrchTbl As DataTable
    Private BS As BindingSource
    Sub Clearall()
        Try
            For Each Ctrl1 As Control In Me.Controls
                If TypeOf Ctrl1 Is TextBox Then
                    Ctrl1.Text = String.Empty
                End If
            Next
        Catch ex As Exception
            lblSt.Text = ("Clear All : ") & ex.Message
        End Try
    End Sub
    Private Sub _Vadd_Click(sender As System.Object, e As System.EventArgs) Handles _Vadd.Click
        Try
            Clearall()
            _Vdel.Enabled = False
            _Vedit.Enabled = False
            _Vsave.Enabled = True
            lblSt.Text = String.Empty
            PictureBox1.Image = Nothing
            Tname.Select()
        Catch ex As Exception
            lblSt.Text = ("مورد جديد : ") & ex.Message
        End Try
    End Sub
    Private Sub _Vsave_Click(sender As System.Object, e As System.EventArgs) Handles _Vsave.Click
        Dim Onhe As Integer = Nothing
        If String.IsNullOrEmpty(Tname.Text) Or
            String.IsNullOrWhiteSpace(Tname.Text) Then
            MsgBox("أدخل الاسم أولا", MsgBoxStyle.Critical, "حفظ مورد")
            Exit Sub
        End If
        Dim Ocust As New Vendors With
            {._VendAdd = Tadd.Text, ._VendMob = Tmob.Text, ._VendNm = Tname.Text, ._VendNote = Tnotes.Text, ._VendTel = Ttel.Text}
#Region "Save"
        Dim Onh = Ocust.SaveNewVend.ToString
#End Region
#Region "Get All Data into CustDG"
        SrchTbl = New DataTable
        SrchTbl = Ocust.GetData
        BS = New BindingSource
        BS.DataSource = SrchTbl
        With VendG
            .AutoGenerateColumns = False
            .DataSource = BS
            formatDG(VendG)
        End With
        lblSt.Text = ("تم حفظ (" & Onh & ")" & " مورد. لديك الأن (" & SrchTbl.Rows.Count & ") مورد.")
        SrchTbl.Dispose()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
        _Vadd.Enabled = True
        _Vsave.Enabled = False
        _Vdel.Enabled = True
        _Vedit.Enabled = True
    End Sub
    Private Sub _nmExit_Click(sender As System.Object, e As System.EventArgs) Handles _nmExit.Click
        Try
            Close()
        Catch ex As Exception
            lblSt.Text = ("Exit : ") & ex.Message
        End Try
    End Sub
    Private Sub _Vedit_Click(sender As System.Object, e As System.EventArgs) Handles _Vedit.Click
        'Edit Customer
        If IsNothing(VendG.CurrentCell) Then
            MsgBox("يجب اختيار مورد أولا")
            Exit Sub
        End If
        Dim ThisVID = CInt(VendG.CurrentRow.Cells("VenID").Value.ToString)
        Dim Ocust As New Vendors With
            {._VenID = ThisVID,
            ._VendAdd = Tadd.Text,
            ._VendMob = Tmob.Text,
            ._VendNm = Tname.Text,
            ._VendNote = Tnotes.Text,
            ._VendTel = Ttel.Text}
#Region "Update"
        Dim Onh = Ocust.UpdateVendor.ToString
#End Region
#Region "Get All Data into CustDG"
        SrchTbl = New DataTable
        SrchTbl = Ocust.GetData
        BS = New BindingSource
        BS.DataSource = SrchTbl
        With VendG
            .AutoGenerateColumns = False
            .DataSource = BS
            formatDG(VendG)
        End With
        SrchTbl.Dispose()
        lblSt.Text = ("تم تعديل بيانات المورد بنجاح")
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
        _Vadd.Enabled = True
        _Vsave.Enabled = False
        _Vedit.Enabled = False
        _Vdel.Enabled = True
    End Sub
    Private Sub _Vdel_Click(sender As System.Object, e As System.EventArgs) Handles _Vdel.Click
        If Val(TextBox1.Text) > 0.00 Then
            MsgBox("لا يمكن حذف مورد مستحق له مبالغ")
            lblSt.Text = String.Empty
            Exit Sub
        End If
        Dim AreYouSure As String =
            MsgBox("تأكيد حذف مورد ؟",
                   MsgBoxStyle.YesNoCancel + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "حذف")
        If AreYouSure = vbYes Then
            Dim Ocust As New Vendors With
        {._VenID = VendG.CurrentRow.Cells("VenID").Value.ToString}
#Region "Delete"
            Dim Onh = Ocust.DeleteVendor.ToString
#End Region
#Region "Get All Data into VendG"
            Dim TblCusts As New DataTable
            TblCusts = Ocust.GetData
            BS = New BindingSource
            BS.DataSource = TblCusts
            With VendG
                .AutoGenerateColumns = False
                .DataSource = BS
                formatDG(VendG)
            End With
            lblSt.Text = ("تم حذف (" & Onh & ") مورد و لديك الان (" & TblCusts.Rows.Count & ") مورد")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(My.Resources.Apply)
            TblCusts.Dispose()
            Clearall()
#End Region
            _Vadd.Enabled = True
            _Vsave.Enabled = False
            _Vdel.Enabled = False  'Del
            _Vedit.Enabled = False
        Else
            Exit Sub
        End If
    End Sub
    Private Sub Vndrs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Escape) Then
                _nmExit_Click(sender, e)
            End If
        Catch ex As Exception
            lblSt.Text = ("Exit : ") & ex.Message
        End Try
    End Sub
    Private Sub Vndrs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        Clearall()
    End Sub
    Private Function AllVendsDebts() As Decimal
        Dim C1 As Decimal
        If VendG.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        Dim Ops As New Vendors
        Dim SqlStr As String =
            "SELECT SUM(PORest) FROM PurOrders WHERE TranID=1;"
        Using CN As OleDbConnection = New OleDbConnection(Ops.GetEncryConStr),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Dim N As Integer = CInt(CMD.ExecuteScalar())
                If Not IsDBNull(N) Then
                    Button5.Enabled = True
                    C1 = CDec(N)
                Else
                    Button5.Enabled = False
                    Return 0
                End If
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return C1
    End Function
    Private Sub _Disp_Click(sender As System.Object, e As System.EventArgs) Handles _Disp.Click
        If VendG.Rows.Count <= 0 Then Exit Sub
        VendPays.Show(Me)
    End Sub
    Private Function AllVendsPays() As Decimal
        Dim cv As Decimal
        If VendG.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT Sum(CustPaid.Payamnt) AS SumOfPayamnt FROM CustPaid GROUP BY CustPaid.TranID HAVING (((CustPaid.TranID)=1));"
        Dim Ops As New Vendors
        Using CN As OleDbConnection = New OleDbConnection(Ops.GetEncryConStr),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Dim N = CInt(CMD.ExecuteScalar())
                cv = CDec(N)
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return cv
    End Function
    Private Sub _DispUp_Click(sender As System.Object, e As System.EventArgs) Handles _DispUp.Click
        TextBox5.Text = FormatCurrency(AllVendsDebts() - AllVendsPays(), 2)
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
    Private Sub _MV_MouseDown(sender As Object, e As MouseEventArgs) Handles _MV.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub MnuShow_Click(sender As Object, e As EventArgs) Handles MnuShow.Click
        Dim Ocust As New Vendors
#Region "Get All Data into vendg"
        Dim TblCusts As New DataTable
        TblCusts = Ocust.GetData
        BS = New BindingSource
        BS.DataSource = TblCusts
        With VendG
            .AutoGenerateColumns = False
            .DataSource = BS
            formatDG(VendG)
        End With
        lblSt.Text = ("لديك عدد " & TblCusts.Rows.Count & " مورد")
        TblCusts.Dispose()
#End Region
        VendG.ClearSelection()
        VendG.CurrentCell = Nothing
    End Sub
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub MnuPrint_Click(sender As Object, e As EventArgs) Handles MnuPrint.Click
        CustsVends.SrcFrm = "Vndrs"
        CustsVends.ShowDialog()
    End Sub
    Private Function AllPOInv(VndrID As Integer) As Integer
        Dim C1 As Integer
        If VendG.Rows.Count <= 0 Then
            Return 0
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT COUNT(POID) FROM PurOrders WHERE TranID=1 AND VenID=?;"
        Dim Ops As New Vendors
        Using CN As OleDbConnection = New OleDbConnection(Ops.GetEncryConStr),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", VndrID)
            Try
                CN.Open()
                C1 = CInt(CMD.ExecuteScalar)
                If C1 <> -1 Or Not IsNothing(C1) Then
                    If C1 > 0 Then
                        Button3.Enabled = True
                    Else
                        Button3.Enabled = False
                    End If
                Else
                    C1 = 0
                End If
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return C1
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'بيان أوامر الشراء
        If String.IsNullOrEmpty(TextBox3.Text) Then Exit Sub
        CustsVends.SrcFrm = "VendInv"
        Dim Onh1 As Object = Nothing, Onh2 As Object = Nothing
        Dim SqlDel As String = "DROP VIEW VendInvs;"
        Dim SqlStrCreate As String =
            "CREATE VIEW VendInvs AS SELECT PurOrders.POID, PurOrders.PODt, PayTypes.PTNm, Vendors.VendNm, Vendors.Tel, Vendors.Mob, " &
            "Vendors.Address, Vendors.Notes, Sum(PurOrders.POTotal) AS SumOfPOTotal, Sum(PurOrders.PODisc) AS SumOfPODisc, " &
            "Sum(PurOrders.PONet) AS SumOfPONet, Sum(PurOrders.POPaid) AS SumOfPOPaid, Sum(PurOrders.PORest) AS SumOfPORest, " &
            "PurOrders.PONots FROM Vendors INNER JOIN (PayTypes INNER JOIN (TranTypes INNER JOIN PurOrders ON TranTypes.TranID = " &
            "PurOrders.TranID) ON PayTypes.PTID = PurOrders.PTId) ON Vendors.VenID=PurOrders.[VenID] GROUP BY PurOrders.POID, " &
            "PurOrders.PODt, PayTypes.PTNm, Vendors.VendNm, Vendors.Tel, Vendors.Mob, Vendors.Address, Vendors.Notes, PurOrders.PONots, " &
            "PurOrders.[VenID], TranTypes.TranID " &
            "HAVING (((PurOrders.[VenID])=" & CInt(VendG("VenID", VendG.CurrentCell.RowIndex).Value.ToString) & ") " &
            "And ((TranTypes.TranID)=1));"
        Dim Ops As New Vendors
        Using CN12 As OleDbConnection = New OleDbConnection(Ops.GetEncryConStr),
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
    Private Function VenDebts(VenID As Integer) As Decimal()
        Dim MyList As Decimal() = {0}
        If VendG.Rows.Count <= 0 Then
            Return MyList
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.PORest) AS SumOfPORest, Sum(PurOrders.POTotal) AS SumOfPOTotal FROM Vendors INNER JOIN PurOrders ON " &
            "Vendors.VenID = PurOrders.VenID GROUP BY PurOrders.TranID, Vendors.VenID HAVING (((PurOrders.TranID)=1) AND " &
            "((Vendors.VenID)=?));"
        Dim Ops As New Vendors
        Using CN As OleDbConnection = New OleDbConnection(Ops.GetEncryConStr),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", VenID)
            Try
                CN.Open()
                Using Readr As OleDbDataReader = CMD.ExecuteReader
                    If Readr.HasRows Then
                        Button1.Enabled = True
                        Button2.Enabled = True
                        While Readr.Read
                            MyList = {Readr.GetDecimal(0), Readr.GetDecimal(1)}
                        End While
                        If MyList.Sum = 0 Then
                            Button1.Enabled = True
                            Button2.Enabled = True
                        End If
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
        Return MyList
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button3_Click(sender, e)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button3_Click(sender, e)
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'بيان أوامر الشراء
        If String.IsNullOrEmpty(TextBox5.Text) Then Exit Sub
        CashDetails.TargetForm1 = "AllVendsDebts"
        Dim Onh1 As Object = Nothing, Onh2 As Object = Nothing
        Dim SqlDel As String = "DROP VIEW AllVendsDebtsVals;"
        Dim SqlStrCreate As String =
            "CREATE VIEW AllVendsDebtsVals AS SELECT PurOrders.POID, PurOrders.PODt, PurOrders.PORest, PayTypes.PTNm, Vendors.VendNm " &
            "FROM (TranTypes INNER JOIN (PayTypes INNER JOIN PurOrders ON PayTypes.PTID = PurOrders.PTId) ON TranTypes.TranID = " &
            "PurOrders.TranID) INNER JOIN Vendors ON PurOrders.VenID = Vendors.VenID GROUP BY PurOrders.POID, PurOrders.PODt, " &
            "PurOrders.PORest, PayTypes.PTNm, PurOrders.TranID, Vendors.VendNm HAVING (((PurOrders.TranID)=1));"
        Dim Ops As New Vendors
        Using CN12 As OleDbConnection = New OleDbConnection(Ops.GetEncryConStr),
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
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Val(TextBox1.Text) > 0 Then
            _Disp.Enabled = True
        Else
            _Disp.Enabled = False
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
            Dim Filter As String = "VendNm LIKE '%" & Tsearch.Text & "%'"
            BS1.Filter = Filter
            With VendG
                .DataSource = BS1
            End With
            formatDG(VendG)
        Catch ex As Exception
            lblSt.Text = ("عملية غير صحيحة : ") & ex.Message
        End Try
    End Sub
    Private Mysrch As DataTable, BS1 As BindingSource

    Private Sub VendG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles VendG.CellContentClick

    End Sub

    Private Sub Tsearch_GotFocus(sender As Object, e As EventArgs) Handles Tsearch.GotFocus
        Dim Ocust As New Vendors
        Mysrch = New DataTable
        Mysrch = Ocust.GetData
        BS1 = New BindingSource
        BS1.DataSource = Mysrch
    End Sub

    Private Sub VendG_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles VendG.CellMouseClick
        If e.Button = MouseButtons.Left Then
            'If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
            If IsNothing(VendG.CurrentRow) Then Exit Sub
            Dim ThisID = CInt(VendG.CurrentRow.Cells("VenID").Value.ToString)
            _DispUp.Enabled = True
            Tcode.Text = ThisID.ToString    'Current ID
            Tname.Text = VendG.CurrentRow.Cells("VendNm").Value.ToString
            Tmob.Text = VendG.CurrentRow.Cells("Mob").Value.ToString
            Ttel.Text = VendG.CurrentRow.Cells("Tel").Value.ToString
            Tadd.Text = VendG.CurrentRow.Cells("Address").Value.ToString
            Tnotes.Text = VendG.CurrentRow.Cells("Notes").Value.ToString

            Cursor = Cursors.WaitCursor
            MnuShow.Enabled = True
            _Vsave.Enabled = False  'Save
            _Vedit.Enabled = True  'Edit
            _Vdel.Enabled = True 'Del
            _Vadd.Enabled = True 'New

            If e.RowIndex = -1 OrElse e.ColumnIndex = -1 Then Cursor = Cursors.Default : Exit Sub
            TextBox3.Text = AllPOInv(VendG("VenID", e.RowIndex).Value).ToString
            Dim numbs As Decimal() = VenDebts(VendG("VenID", e.RowIndex).Value)
            TextBox1.Text = FormatCurrency(numbs.First().ToString, 2)
            TextBox4.Text = FormatCurrency(numbs.Last().ToString, 2)
            VendPays.ThisCust = CInt(VendG("VenID", VendG.CurrentCell.RowIndex).Value)
            VendPays.TxtCustNm.Text = VendG("VendNm", VendG.CurrentCell.RowIndex).Value.ToString
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Vndrs_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.Control AndAlso e.KeyCode = Keys.F Then
            Tsearch.Focus()
        End If
    End Sub
End Class