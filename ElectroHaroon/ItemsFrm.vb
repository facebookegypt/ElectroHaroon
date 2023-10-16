Imports System.Data.OleDb
Imports ElectroHaroon.Pur_Sell_Ordrs
Public Class ItemsFrm
    Private SrchTbl As DataTable
    Private BS As BindingSource
    Private Sub ItemsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        formatDG(DGready)
        DGready.MultiSelect = False
        Dim OItems As New Items
        MySrch = New DataTable
        MySrch = OItems.GetData
        BS2 = New BindingSource
        BS2.DataSource = MySrch
        Dim Ikind As New Kinds
        Ikind.BindDGColumnKinds(DGready)
        Dim Istore As New Stores
        Istore.BindDGColumnStores(DGready)
        Istore.BindCombo(CboStores)
        NewItem()
    End Sub
    Private Sub ItemsFrm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles MnuSave.Click
        'Save New Item
        If String.IsNullOrEmpty(CboNm.Text) OrElse
                String.IsNullOrEmpty(TextBox4.Text) Then
            MsgBox("أدخل اسم الصنف و الباركود أولا",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المبيعات و المشتريات")
            Exit Sub
        End If
        Dim OItems As New Items With
            {.ItmNm = CboNm.Text,
            .ItmDesc = IIf(TextBox3.Text = String.Empty, "لا يوجد وصف", TextBox3.Text).ToString,
            .ItmCost = IIf(TextBox6.Text = String.Empty, 0.00.ToString("C2"), TextBox6.Text).ToString,
            .FrstQnty = IIf(TextBox2.Text = String.Empty, "0", TextBox2.Text).ToString,
            .ItmBCode = TextBox4.Text,
            .ItmMinQ = IIf(TextBox5.Text = String.Empty, "0", TextBox5.Text).ToString,
            .StoreID = CboStores.SelectedValue,
            .ItmNotes = IIf(TextBox7.Text = String.Empty, "لا يوجد ملاحظات", TextBox7.Text).ToString}
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
        End With
        TextBox1.Text = ("تم حفظ (" & Onh & ")" & " صنف. لديك الأن (" & SrchTbl.Rows.Count & ") صنف.")
        SrchTbl.Dispose()
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
#End Region
        ShowAll()
    End Sub
    Private Sub NewItem()
        CboNm.Text = String.Empty
        TextBox1.Text = String.Empty
        TextBox2.Text = 0.ToString("N0")
        TextBox3.Text = "لا يوجد"
        TextBox4.Text = GenerateRandomString()
        TextBox5.Text = 1.ToString
        TextBox6.Text = 0.00.ToString("C2")
        TextBox7.Text = "لا يوجد"
        Tsrch.Text = String.Empty
        CboStores.SelectedIndex = -1
        PictureBox1.Image = Nothing
        MnuSave.Enabled = True
        MnuDel.Enabled = False
        MnuEdit.Enabled = False
        CboNm.Select()
    End Sub
    Private Sub ShowAll()
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
        End With
        If DGready.RowCount > 0 Then
            DGready.CurrentCell = DGready.FirstDisplayedCell
        End If
        _MP.Text = ("الأصناف (" & TblItems.Rows.Count & ")")
        TblItems.Dispose()
#End Region
        DGready.ClearSelection()
        DGready.CurrentCell = Nothing
    End Sub
    Private Sub _MPback_Click(sender As Object, e As EventArgs) Handles _MPback.Click
        Close()
    End Sub
    Private Sub MnuNew_Click(sender As Object, e As EventArgs) Handles MnuNew.Click
        NewItem()
    End Sub
    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub MnuPOrdrs_Click(sender As Object, e As EventArgs) Handles MnuPOrdrs.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("POs") Then
                Fo.BringToFront()
                Fo.Activate()
                Me.Close()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim PosFrm As New POs
        'PosFrm.TargetForm = "Units"
        PosFrm.Show(MainF)
        Me.Close()
    End Sub
    Private Sub MnuUnt_Click(sender As Object, e As EventArgs) Handles MnuUnt.Click
        Dim BA As New Basics
        BA.TargetForm = "Units"
        BA.ShowDialog()
    End Sub
    Private Sub MnuStr_Click(sender As Object, e As EventArgs) Handles MnuStr.Click
        Dim BA As New Basics
        BA.TargetForm = "Stores"
        BA.ShowDialog()
    End Sub
    Private Sub MnuKnd_Click(sender As Object, e As EventArgs) Handles MnuKnd.Click
        Dim BA As New Basics
        BA.TargetForm = "Kinds"
        BA.ShowDialog()
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
        ShowAll()
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
            End With
            TblItems.Dispose()
            TextBox1.Text = ("تم حذف (" & Onh & ") صنف و لديك الان (" & TblItems.Rows.Count & ") صنف")
        End If
#End Region
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
        ShowAll()
        MnuSave.Enabled = True
        MnuDel.Enabled = False
        MnuEdit.Enabled = False
    End Sub
    Private Sub MnuEdit_Click(sender As Object, e As EventArgs) Handles MnuEdit.Click
        If MnuEdit.Enabled = False AndAlso IsNothing(DGready.CurrentCell) Then
            TextBox1.Text = "عملية غير صحيحة - يجب اختيار صنف أولا"
            Exit Sub
        End If
#Region "Update"
        Dim ThisID = CInt(DGready.CurrentRow.Cells("PID").Value.ToString)
        Dim OItems As New Items With
            {.ItmID = ThisID,
            .ItmNm = CboNm.Text,
            .ItmDesc = TextBox3.Text,
            .ItmNotes = TextBox7.Text,
            .FrstQnty = TextBox2.Text,
            .ItmBCode = TextBox4.Text,
            .ItmCost = TextBox6.Text,
            .ItmMinQ = TextBox5.Text,
            .StoreID = CboStores.SelectedValue}
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
        End With
        TextBox1.Text = ("تم تعديل بيانات الصنف بنجاح")
        SrchTbl.Dispose()
#End Region
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = New Bitmap(My.Resources.Apply)
        ShowAll()
        MnuSave.Enabled = True
        MnuDel.Enabled = False
        MnuEdit.Enabled = False
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
    Private Sub DGready_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.RowEnter
        If e.RowIndex = -1 OrElse e.ColumnIndex = -1 OrElse IsNothing(DGready.CurrentRow) Then Exit Sub
        Try
            Dim Nstores As New Stores
            Dim N1 As New DataTable
            Dim ThisID = CInt(DGready("PID", e.RowIndex).Value.ToString)
            N1 = Nstores.GetStoresItems(ThisID)
            DGready("Stores", e.RowIndex).Value = CInt(N1(0)("StoreID").ToString)
            CboNm.Text = CStr(DGready("Pname", e.RowIndex).Value)
            TextBox3.Text = CStr(DGready("Pdesc", e.RowIndex).Value)
            TextBox6.Text = CDbl(DGready("Pcost", e.RowIndex).Value).ToString("C2")
            TextBox2.Text = CInt(DGready("FrstQnty", e.RowIndex).Value.ToString)
            TextBox5.Text = CInt(DGready("MinQ", e.RowIndex).Value.ToString)
            TextBox4.Text = CStr(DGready("BarCode", e.RowIndex).Value)
            TextBox7.Text = DGready("Pnotes", e.RowIndex).Value.ToString
            CboStores.SelectedValue = DGready("Stores", e.RowIndex).Value
            MnuSave.Enabled = False
            MnuNew.Enabled = True
            MnuEdit.Enabled = True
            MnuDel.Enabled = True
        Catch ex As Exception
            TextBox1.Text = ex.Message
            PictureBox1.Image = My.Resources.Cancel
        End Try
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
            Dim OItmSellKind As New Items With
                {
                .ItmID = DGready.CurrentRow.Cells("PID").Value.ToString,
                .KID = combo.SelectedValue.ToString
            }
            DGready.CurrentRow.Cells("GsellPrice").Value = OItmSellKind.GetsellPrice.ToString("C2")
            DGready.CurrentRow.Cells("GsellPrice").ReadOnly = False
            DGready.EndEdit()
        End If
    End Sub
    Private Sub DGready_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellEndEdit
        If DGready.CurrentCell.OwningColumn.Name = "GsellPrice" Then
            If Not IsNumeric(DGready.CurrentRow.Cells("GsellPrice").FormattedValue.ToString) Then
                DGready.CurrentRow.Cells("GsellPrice").Value = 0.00.ToString("C2")
                Exit Sub
            End If
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
    Private Sub DGReady_Keydown(sender As Object, e As KeyEventArgs) Handles DGready.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Your code here  
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub ItemsFrm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.Control AndAlso e.KeyCode = Keys.F Then
            Tsrch.Focus()
            Tsrch.SelectAll()
        End If
    End Sub
    Private Sub ItemsFrm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
#Region "Search Items"
    Private MySrch As DataTable, BS2 As BindingSource
    Private Sub Tsrch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Tsrch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DGready.RowCount > 0 Then
                DGready.Select()
                DGready.CurrentCell = DGready.Rows(0).Cells("Pname")
            End If
        End If
    End Sub
    Private Sub Tsrch_TextChanged(sender As Object, e As EventArgs) Handles Tsrch.TextChanged
        Try
            If String.IsNullOrEmpty(Tsrch.Text) Then
                DGready.AutoGenerateColumns = False
                DGready.DataSource = Nothing
                Exit Sub
            End If
            Dim Filter As String =
                "Pname LIKE '%" & Tsrch.Text & "%' OR Pdesc LIKE '%" & Tsrch.Text & "%' OR Pnotes LIKE '%" & Tsrch.Text & "%'"
            With DGready
                .AutoGenerateColumns = False
                .DataSource = BS2
            End With
            BS2.Filter = Filter
            BS2.Sort = "Pname ASC"
        Catch ex As Exception
            TextBox1.Text = ("عملية غير صحيحة : ") & ex.Message
            PictureBox1.Image = My.Resources.Cancel
        End Try
    End Sub
    Private Sub Tsrch_GotFocus(sender As Object, e As EventArgs) Handles Tsrch.GotFocus
        Dim OItems As New Items
        MySrch = New DataTable
        MySrch = OItems.GetData
        BS2 = New BindingSource
        BS2.DataSource = MySrch
    End Sub
    Private Sub Tsrch_Leave(sender As Object, e As EventArgs) Handles Tsrch.Leave
        MySrch = Nothing
    End Sub
    Private Sub DGready_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellContentClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Return
        If DGready.Columns(e.ColumnIndex).Name = "Kinds" Then
            DGready.BeginEdit(True)
            DirectCast(DGready.EditingControl, DataGridViewComboBoxEditingControl).DroppedDown = True
        End If
    End Sub
#End Region
    Private Sub CboNm_Leave(sender As Object, e As EventArgs) Handles CboNm.Leave
        'Check if Item exists
        Dim Oexists As New DataTable
        Dim Oitems As New Items
        Oexists = Oitems.GetData
        Dim DR() As DataRow = Oexists.Select("Pname='" & CboNm.Text & "'")
        If DR.Length > 0 Then
            TextBox1.Text = "هذا الصنف موجود بالفعل"
            PictureBox1.Image = My.Resources.Cancel
            MnuSave.Enabled = False
            CboNm.SelectAll()
        Else
            TextBox1.Text = String.Empty
            PictureBox1.Image = Nothing
            MnuSave.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreForm = Me
        Dim Stor As New Basics
        Stor.TargetForm = "Stores"
        Stor.ShowDialog()
    End Sub

    Private Sub CboStores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboStores.SelectedIndexChanged

    End Sub

    Private Sub TextBox6_Click(sender As Object, e As EventArgs) Handles TextBox6.Click
        TextBox6.SelectAll()
    End Sub

    Private Sub DGready_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DGready.RowPostPaint
        Dim grid = TryCast(sender, DataGridView)
        Dim rowIdx As String = Convert.ToString(e.RowIndex + 1)
        Using centerFormat As StringFormat = New StringFormat() With
            {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
            Dim headerBounds =
                New Rectangle(e.RowBounds.Right - 37, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)
            e.Graphics.DrawString(rowIdx, Font, Brushes.Black, headerBounds, centerFormat)
        End Using
    End Sub

    Private Sub CboStores_DropDown(sender As Object, e As EventArgs) Handles CboStores.DropDown
        Dim Stor As New Stores
        Stor.BindCombo(CboStores)
    End Sub
End Class