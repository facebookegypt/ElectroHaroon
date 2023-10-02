﻿Imports System.Data.OleDb
Public Class ItemsFrm
    Private SrchTbl As DataTable
    Private BS As BindingSource
    Private Sub ItemsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
    End Sub
    Private Sub ItemsFrm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles MnuSave.Click
        'Save New Item
        If CboNm.Text.Length <= 0 Or
                TextBox4.Text.Length <= 0 Then
            MsgBox("أدخل اسم الصنف و الباركود أولا",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المبيعات و المشتريات")
            Exit Sub
        End If
        Dim OItems As New Items With
            {.ItmNm = CboNm.Text, .ItmDesc = TextBox3.Text, .ItmCost = TextBox6.Text, .ItmBCode = TextBox4.Text,
            .ItmMinQ = Convert.ToInt32(TextBox5.Text), .ItmNotes = TextBox7.Text}
#Region "Save"
        Dim Onh = OItems.SaveNewItm.ToString
#End Region
#Region "Get All Data into DGReady"
        SrchTbl = New DataTable
        SrchTbl = OItems.GetData
        BS = New BindingSource
        BS.DataSource = SrchTbl
        With DGready
            .AutoGenerateColumns = False
            .DataSource = BS
            Dim Ikind As New Kinds
            Ikind.BindDGColumnKinds(DGready)
            formatDG(DGready)
        End With
        TextBox1.Text = ("تم حفظ (" & Onh & ")" & " صنف. لديك الأن (" & SrchTbl.Rows.Count & ") صنف.")
        SrchTbl.Dispose()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
        NewItem()
        MnuDisp_Click(sender, e)
    End Sub
    Private Sub NewItem()
        CboNm.Text = String.Empty
        TextBox5.Text = 1
        TextBox6.Text = 0.00.ToString("C2")
        TextBox3.Text = "لا يوجد"
        TextBox4.Text = RandomString()
        CboNm.Focus()
        CboNm.Select()
    End Sub
    Private Sub _MPback_Click(sender As Object, e As EventArgs) Handles _MPback.Click
        Close()
    End Sub
    Private Sub MnuNew_Click(sender As Object, e As EventArgs) Handles MnuNew.Click
        MnuSave.Enabled = True
        TextBox4.Text = GenerateRandomString()
        NewItem()
    End Sub
    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub MnuPOrdrs_Click(sender As Object, e As EventArgs) Handles MnuPOrdrs.Click
        Dim PurOrdrsFrm As New PurOrdrs
        PurOrdrsFrm.Show()
        Me.Close()
    End Sub
    Private Sub MnuUnt_Click(sender As Object, e As EventArgs) Handles MnuUnt.Click
        Basics.TargetForm = "Units"
        Basics.ShowDialog()
    End Sub
    Private Sub MnuStr_Click(sender As Object, e As EventArgs) Handles MnuStr.Click
        Basics.TargetForm = "Stores"
        Basics.ShowDialog()
    End Sub
    Private Sub MnuKnd_Click(sender As Object, e As EventArgs) Handles MnuKnd.Click
        Basics.TargetForm = "Kinds"
        Basics.ShowDialog()
    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Location = New Point(0, 0)
        If Height = MainF.Height Then
            Height = MainF.Height / 2
            Exit Sub
        End If
        Height = MainF.Height
    End Sub
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or (e.KeyChar) = ChrW(Keys.Back))
    End Sub
    Private Sub MnuDisp_Click(sender As Object, e As EventArgs) Handles MnuDisp.Click
        Dim OItems As New Items
#Region "Get All Data into DGReady"
        Dim TblItems As New DataTable
        TblItems = OItems.GetData
        BS = New BindingSource
        BS.DataSource = TblItems
        With DGready
            .AutoGenerateColumns = False
            .DataSource = BS
            Dim Ikind As New Kinds
            Ikind.BindDGColumnKinds(DGready)
            formatDG(DGready)
        End With
        TblItems.Dispose()
        TextBox1.Text = ("لديك عدد " & TblItems.Rows.Count & " صنف")
#End Region
        DGready.ClearSelection()
        DGready.CurrentCell = Nothing
        RemoveHandler DGready.RowEnter, AddressOf DGready_RowEnter
    End Sub
    Private Sub MnuDel_Click(sender As Object, e As EventArgs) Handles MnuDel.Click
        If MnuEdit.Enabled = False AndAlso IsNothing(DGready.CurrentCell) Then
            TextBox1.Text = "عملية غير صحيحة - يجب اختيار صنف أولا"
            Exit Sub
        End If
        Dim NewTble As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
        NewTble = GetData("SELECT * FROM PODetails WHERE PID=" & CInt(DGready.CurrentRow.Cells("PID").Value.ToString) & ";")
        If NewTble.Rows.Count > 0 Then
            MsgBox("لا يمكن حذف هذا الصنف", MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical)
            NewTble.Dispose()
            Exit Sub
        End If
        Dim AreYouSure As String =
            MsgBox("تأكيد حذف صنف ؟",
                   MsgBoxStyle.YesNoCancel + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "حذف")
        If AreYouSure = vbYes Then
            Dim OItems As New Items With
        {.ItmID = DGready.CurrentRow.Cells("PID").Value.ToString}
#Region "Delete"
            Dim Onh = OItems.DeleteItem.ToString
#End Region
#Region "Get All Data into DGReady"
            Dim TblItems As New DataTable
            TblItems = OItems.GetData
            BS = New BindingSource
            BS.DataSource = TblItems
            With DGready
                .AutoGenerateColumns = False
                .DataSource = BS
                Dim Ikind As New Kinds
                Ikind.BindDGColumnKinds(DGready)
                formatDG(DGready)
            End With
            TblItems.Dispose()
            TextBox1.Text = ("تم حذف (" & Onh & ") صنف و لديك الان (" & TblItems.Rows.Count & ") صنف")
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = New Bitmap(My.Resources.Apply)
            NewItem()
            MnuDisp_Click(sender, e)
        End If
#End Region
    End Sub
    Private Sub MnuEdit_Click(sender As Object, e As EventArgs) Handles MnuEdit.Click
        If MnuEdit.Enabled = False AndAlso IsNothing(DGready.CurrentCell) Then
            TextBox1.Text = "عملية غير صحيحة - يجب اختيار صنف أولا"
            Exit Sub
        End If
        Dim NewTble As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
        NewTble = GetData("SELECT * FROM PODetails WHERE PID=" & CInt(DGready.CurrentRow.Cells("PID").Value.ToString) & ";")
        If NewTble.Rows.Count > 0 Then
            MsgBox("لا يمكن تعديل هذا الصنف", MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical)
            NewTble.Dispose()
            Exit Sub
        End If
        Dim ThisID = CInt(DGready.CurrentRow.Cells("PID").Value.ToString)
        Dim OItems As New Items With
            {.ItmID = ThisID,
            .ItmNm = CboNm.Text,
            .ItmDesc = TextBox3.Text,
            .ItmNotes = TextBox7.Text,
            .ItmBCode = TextBox4.Text,
            .ItmCost = TextBox6.Text,
            .ItmMinQ = TextBox5.Text}
#Region "Update"
        Dim Onh = OItems.UpdateItems.ToString
#End Region
#Region "Get All Data into DGReady"
        SrchTbl = New DataTable
        SrchTbl = OItems.GetData
        BS = New BindingSource
        BS.DataSource = SrchTbl
        With DGready
            .AutoGenerateColumns = False
            .DataSource = BS
            Dim Ikind As New Kinds
            Ikind.BindDGColumnKinds(DGready)
            formatDG(DGready)
        End With
        TextBox1.Text = ("تم تعديل بيانات الصنف بنجاح")
        SrchTbl.Dispose()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
        NewItem()
        MnuDisp_Click(sender, e)
#End Region
    End Sub
    Private Function GetData(query As String) As DataTable
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As New OleDbConnection(ConnectionString),
            CMD As New OleDbCommand(query, CN),
            Sda As New OleDbDataAdapter(CMD),
            MyTable As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            CN.Open()
            Sda.Fill(MyTable)
            Return MyTable
        End Using
    End Function
    Private Sub DGready_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellClick
        AddHandler DGready.RowEnter, AddressOf DGready_RowEnter
        DGready_RowEnter(sender, e)
    End Sub
    Private Sub DGready_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.RowEnter
        If e.RowIndex = -1 OrElse e.ColumnIndex = -1 OrElse IsNothing(DGready.CurrentRow) Then Exit Sub
        Dim ThisID = CInt(DGready.CurrentRow.Cells("PID").Value.ToString)
        CboNm.Text = DGready("Pname", e.RowIndex).Value.ToString
        TextBox3.Text = DGready("Pdesc", e.RowIndex).Value.ToString
        TextBox6.Text = CDbl(DGready("Pcost", e.RowIndex).Value.ToString).ToString("C2")
        TextBox7.Text = DGready("Pnotes", e.RowIndex).Value.ToString
        TextBox5.Text = CInt(DGready("MinQ", e.RowIndex).Value.ToString).ToString
        TextBox4.Text = DGready("BarCode", e.RowIndex).Value.ToString
        MnuSave.Enabled = False
        MnuNew.Enabled = True
        MnuEdit.Enabled = True
        MnuDel.Enabled = True
    End Sub
    Private Sub TextBox6_Leave(sender As Object, e As EventArgs) Handles TextBox6.Leave
        Try
            TextBox6.Text = CDbl(TextBox6.Text).ToString("C2")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ItemsFrm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            MnuDisp_Click(sender, e)
        End If
    End Sub
    Private MySrch As DataTable, BS2 As BindingSource
    Private Sub CboNm_GotFocus(sender As Object, e As EventArgs) Handles CboNm.GotFocus
        Dim OItems As New Items
        MySrch = New DataTable
        MySrch = OItems.GetData
        BS2 = New BindingSource
        BS2.DataSource = MySrch
    End Sub
    Private Sub CboNm_KeyUp(sender As Object, e As KeyEventArgs) Handles CboNm.KeyUp
        If e.Control OrElse
            e.Shift OrElse
            e.Alt OrElse
            e.KeyCode = Keys.Escape OrElse
            e.KeyCode = Keys.Delete Then
            e.Handled = True
            Exit Sub
        End If
        Try
            Dim Filter As String = "Pname LIKE '%" & CboNm.Text & "%'"
            BS2.Filter = Filter
            With DGready
                .DataSource = BS2
                Dim Ikind As New Kinds
                Ikind.BindDGColumnKinds(DGready)
                formatDG(DGready)
            End With
        Catch ex As Exception
            TextBox1.Text = ("عملية غير صحيحة : ") & ex.Message
        End Try
    End Sub

    Private Sub DGready_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGready.EditingControlShowing
        If (TypeOf (e.Control) Is ComboBox) Then
            Dim combo = CType(e.Control, ComboBox)
            RemoveHandler combo.SelectionChangeCommitted, AddressOf CboKind_SelectionChangeCommitted
            AddHandler combo.SelectionChangeCommitted, AddressOf CboKind_SelectionChangeCommitted
        End If
    End Sub
    Private KindsPrice As DataTable, BS1 As BindingSource
    Private Sub CboKind_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If (DGready.Columns(DGready.CurrentCell.ColumnIndex).Name = "Kinds") Then
            Dim combo = CType(sender, ComboBox)
            'Do something with combo
            'Get SellPrice according to Item Kind
            DGready.CurrentRow.Cells("GsellPrice").Value = 0.00.ToString("C2")
            Dim OItmSellKind As New Items With {.ItmID = DGready.CurrentRow.Cells("PID").Value.ToString,
                .KID = combo.SelectedValue.ToString}
            DGready.CurrentRow.Cells("GsellPrice").Value = OItmSellKind.GetsellPrice.ToString("C2")
            DGready.CurrentRow.Cells("GsellPrice").ReadOnly = False
        End If
    End Sub
    Private Sub DGready_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellEndEdit
        If DGready.CurrentCell.OwningColumn.Name = "GsellPrice" Then
            'Check for SellGrps Exists
            Dim OItmSellKind As New Items With
                    {.ItmID = DGready.CurrentRow.Cells("PID").Value.ToString,
                    .KID = DGready.CurrentRow.Cells("Kinds").Value.ToString,
                    .ItmSellPrice = DGready.CurrentRow.Cells("GsellPrice").Value.ToString}
            Dim CurSellPricefound = OItmSellKind.SellPriceExists
            Try
                Select Case CurSellPricefound
                    Case Is = True
                        'Update
                        OItmSellKind.UpdateInsertSellP(True)
                        TextBox1.Text = "تم تحديث السعر"
                        PictureBox1.Image = My.Resources.Apply
                    Case Is = False
                        'Insert Into SellPriceGrps
                        OItmSellKind.UpdateInsertSellP(False)
                        TextBox1.Text = "تم تحديث السعر"
                        PictureBox1.Image = My.Resources.Apply
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub DGready_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGready.DataError
        e.Cancel = True
    End Sub
End Class