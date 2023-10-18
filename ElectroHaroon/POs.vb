Imports ElectroHaroon.Pur_Sell_Ordrs
Public Class POs
    Private BS2, BSTotal, TempBS As BindingSource
    Private MySrch, TotalTbl As DataTable
    Private TempDT As DataTable
    Private TempDR As DataRow
    Private Function SetUpDataTable() As DataTable
        Dim ColAdd As New DataColumn With
            {.AllowDBNull = True, .ColumnName = "ColAdd", .DataType = GetType(Boolean), .ReadOnly = False, .ColumnMapping = MappingType.Element,
            .DefaultValue = False}
        Dim Units As New DataColumn With
            {.AllowDBNull = True, .ColumnName = "Units", .DataType = GetType(Integer), .ColumnMapping = MappingType.Element, .ReadOnly = False}
        Dim ItmQntyIn As New DataColumn With
            {.AllowDBNull = False, .ColumnName = "ItmQntyIn", .DataType = GetType(Integer), .DefaultValue = "1", .ReadOnly = False}
        Dim ItmPurPrice As New DataColumn With
            {.AllowDBNull = False, .ColumnName = "ItmPurPrice", .DataType = GetType(Double), .DefaultValue = "0.0", .ReadOnly = False}
        Dim ItmTotalPrice As New DataColumn With
            {.AllowDBNull = False, .ColumnName = "ItmTotalPrice", .DataType = GetType(Double), .DefaultValue = "0.0", .ReadOnly = True,
            .Expression = "ItmQntyIn*ItmPurPrice"}
        MySrch = New DataTable
        Dim OItems As New CombinedData
        MySrch = OItems.GetDataItems
        With MySrch
            .Columns("PID").Unique = True
            .PrimaryKey = New DataColumn() {MySrch.Columns("PID")}
            .Columns.AddRange({Units, ColAdd, ItmQntyIn, ItmPurPrice, ItmTotalPrice})
        End With
        Return MySrch
    End Function
    Private Function BindToSrc() As BindingSource
        BS2 = New BindingSource
        BS2.DataSource = SetUpDataTable()
        Return BS2
    End Function
    Private Sub BindToDG(Optional Filter As String = "", Optional Sort As String = "")
        Dim IUnits As New Units
        IUnits.BindDGColumnUnits(DGready)
        Dim Binsrc As New BindingSource
        Binsrc = BindToSrc()
        With DGready
            .StandardTab = True
            .Columns("PID").Visible = False
            .Columns("Pname").ValueType = GetType(String)
            .Columns("Pname").Visible = True
            .Columns("Units").ValueType = GetType(Integer)
            .Columns("Units").Visible = True
            .AutoGenerateColumns = True
            .DataSource = Binsrc
        End With
        Binsrc.Filter = Filter
        Binsrc.Sort = Sort
    End Sub
    Private Sub POs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        TempBS = Nothing
        BS2 = Nothing
        BS2 = Nothing
        BS_SellPrice = Nothing
    End Sub
    Private Sub POs_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        MainF.BringToFront()
    End Sub
    Private Sub POs_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dispose()
        End If
        If e.Control AndAlso e.KeyCode = Keys.F Then
            TextBox1.Select()
        End If
        If e.Control AndAlso e.KeyCode = Keys.P AndAlso Label3.Enabled = True Then
            Label3_Click(sender, e)
        End If
    End Sub
    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        'Vendors
        Dim VendsItms As New CombinedData With {.Key_ID = "VenID", .Val_Nm = "VendNm", .Tbl_Nm = "Vendors"}
        VendsItms.BindVendors(ComboBox2)
    End Sub
    Private Sub POs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Try
        Catch ex As Exception
            LblSts.Text = ("عملية غير صحيحة : ") & ex.Message
            PictureBox1.Image = My.Resources.Cancel
        End Try
        'Invoice Totals
        TotalTbl = New DataTable
        Dim ColInvTotal As New DataColumn With
        {.AllowDBNull = False, .ColumnName = "InvTotal", .ColumnMapping = MappingType.Element,
        .DataType = GetType(Double), .DefaultValue = "0.00", .ReadOnly = False}
        Dim ColInvDscnt As New DataColumn With
        {.AllowDBNull = False, .ColumnName = "InvDscnt", .ColumnMapping = MappingType.Element,
        .DataType = GetType(Double), .DefaultValue = "0.00", .ReadOnly = False}
        Dim ColInvNet As New DataColumn With
        {.AllowDBNull = False, .ColumnName = "InvNet", .ColumnMapping = MappingType.Element,
        .DataType = GetType(Double), .DefaultValue = "0.00", .ReadOnly = True, .Expression = "[InvTotal]-[InvDscnt]"}
        Dim ColInvPaid As New DataColumn With
        {.AllowDBNull = False, .ColumnName = "InvPaid", .ColumnMapping = MappingType.Element,
        .DataType = GetType(Double), .DefaultValue = "0.00", .ReadOnly = False}
        Dim ColInvRest As New DataColumn With
        {.AllowDBNull = False, .ColumnName = "InvRest", .ColumnMapping = MappingType.Element,
        .DataType = GetType(Double), .DefaultValue = "0.00", .ReadOnly = True, .Expression = "[InvNet]-[InvPaid]"}
        TotalTbl.Columns.AddRange({ColInvTotal, ColInvDscnt, ColInvNet, ColInvPaid, ColInvRest})
        Dim row As DataRow
        ' Add one row. Since it has default values, 
        ' no need to set values yet.
        row = TotalTbl.NewRow
        TotalTbl.Rows.Add(row)
        BSTotal = New BindingSource
        BSTotal.DataSource = TotalTbl
        With DataGridView1
            .RowTemplate.Height = 40
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(0).DataPropertyName = "InvTotal"
            .Columns(0).ValueType = Type.GetType("System.Double")
            .Columns(0).ReadOnly = True
            .Columns(1).DataPropertyName = "InvDscnt"
            .Columns(1).ValueType = Type.GetType("System.Double")
            .Columns(2).DataPropertyName = "InvNet"
            .Columns(2).ValueType = Type.GetType("System.Double")
            .Columns(3).DataPropertyName = "InvPaid"
            .Columns(3).ValueType = Type.GetType("System.Double")
            .Columns(4).DataPropertyName = "InvRest"
            .Columns(4).ValueType = Type.GetType("System.Double")
            .AutoGenerateColumns = False
            .DataSource = BSTotal
            .DefaultCellStyle.Format = "C2"
        End With
    End Sub
    Private Sub MnuNew_Click(sender As Object, e As EventArgs) Handles MnuNew.Click
        MnuSave.Enabled = False
        MnuEdit.Enabled = False
        Pno1.Text = Module1.GenerateRandomString
        LblSts.Text = String.Empty
        PictureBox1.Image = Nothing
        'preview
        TempDT = New DataTable
        TempBS = New BindingSource
        If Not IsNothing(DGPerv) Then
            DGPerv.DataSource = Nothing
            DGPerv.Visible = False
        End If
        'All Selected Items to store
        BS2 = New BindingSource
        If DGready.Visible = False Then DGready.Visible = True
        Label3.Text = "معاينة أمر الشراء"
        Label3.Enabled = False

        BSTotal = New BindingSource
        BS_SellPrice = New BindingSource
        TextBox1.Text = String.Empty
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        Pno1.Text = String.Empty
        TextBox7.Text = String.Empty
    End Sub
#Region "Sell Prices Panel"
    Private StartUpHeight As Integer = 279
    Private DGSellPrices As DataGridView
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If Panel1.Size.Height = StartUpHeight Then
            Timer1.Enabled = True
            Timer1.Interval = 10
            Timer1.Start()
            Panel1.Controls.Remove(DGSellPrices)
        Else
            Timer2.Enabled = True
            Timer2.Interval = 10
            Timer2.Start()
            DGSellPrices = New DataGridView With
           {.Name = "DGSellPrices", .ColumnCount = 2}
            Panel1.Controls.Add(DGSellPrices)
            With DGSellPrices
                .BorderStyle = BorderStyle.None
                .AllowUserToAddRows = False
                .EnableHeadersVisualStyles = False
                .ColumnHeadersHeight = 30
                .ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.Font = New Font("Traditional Arabic", 13.8, FontStyle.Bold)
                .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
                .DefaultCellStyle.BackColor = Color.FloralWhite
                .DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Regular)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .RightToLeft = RightToLeft.Yes
                .ReadOnly = True
                .Location = New Point(0, 30)
                .Width = Label2.Width
                .Height = Panel1.Height
                .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                .CellBorderStyle = DataGridViewCellBorderStyle.Single
                .GridColor = SystemColors.ActiveBorder
                .RowHeadersVisible = False
                .Columns(0).Name = "KindNm"
                .Columns(0).DataPropertyName = "KindNm"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(0).HeaderText = "النوع"
                .Columns(1).Name = "GsellPrice"
                .Columns(1).DataPropertyName = "GSellPrice"
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns(1).HeaderText = "السعر"
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .BackgroundColor = Color.FloralWhite
            End With
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel1.Height -= 10
        If Panel1.Size.Height <= 30 Then
            Timer1.Stop()
            Timer1.Enabled = False
        End If
    End Sub
    Private BS_SellPrice As BindingSource
    Private SellPrices As DataTable
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Panel1.Height += 10
        If Panel1.Size.Height >= StartUpHeight Then
            Timer2.Stop()
            Timer2.Enabled = False
        End If
    End Sub
#End Region
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PreForm = Me
        Dim Vnds As New Vndrs
        Vndrs.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PreForm = Me
        Dim PayTps As New Basics
        PayTps.TargetForm = "PayTypes"
        PayTps.ShowDialog()
    End Sub
#Region "PREVIEW"
    Dim DGPerv As PO_preview
#End Region
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        RemoveHandler DGready.SelectionChanged, AddressOf DGReady_SelectionChanged
        TempDT.Columns("ItmTotalPrice").Expression = "[ItmQntyIn]*[ItmPurPrice]"
        ActiveControl = Label3
        DGready.Visible = False
        DGPerv = New PO_preview With {.Location = DGready.Location, .Size = DGready.Size, .Visible = True}
        TempBS = New BindingSource
        TempBS.DataSource = TempDT
        DGPerv.DataSource = TempBS
        TempBS.ResetBindings(True)
        Controls.Add(DGPerv)
        MnuSave.Enabled = True
    End Sub
    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Dim PayTypes As New CombinedData With {.Key_ID = "PTID", .Val_Nm = "PTNm", .Tbl_Nm = "PayTypes"}
        PayTypes.BindPayTypes(ComboBox1)
    End Sub

    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
#Region "DGReady"
    Private Sub DGready_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGready.CellFormatting
        If DGready.CurrentCell IsNot Nothing Then
            If e.RowIndex = DGready.CurrentCell.RowIndex And e.ColumnIndex = DGready.CurrentCell.ColumnIndex Then
                e.CellStyle.SelectionBackColor = Color.SteelBlue
            Else
                e.CellStyle.SelectionBackColor = DGready.DefaultCellStyle.SelectionBackColor
            End If
        End If
    End Sub
    'RowEnter : Occurs when a row receives input focus but before it becomes the current row.
    'This event occurs when the DataGridView is initially loaded, as well as when the user selects a row other than the current row.
    'This Event occurs before the CurrentRow Property Is updated. To retrieve the index Of the newly-entered row, 
    'use the DataGridViewCellEventArgs.RowIndex Property within the Event handler.
    Private Sub DGready_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.RowEnter
        If e.RowIndex = -1 OrElse e.ColumnIndex = -1 OrElse IsNothing(DGready.CurrentRow) Then Exit Sub
        Try
            If IsNothing(DGSellPrices) Then
                Label2_Click(sender, e)
            End If
            Dim ThisID = CInt(DGready("PID", e.RowIndex).Value.ToString)
            Dim OCombined As New CombinedData
            SellPrices = OCombined.GetSellPrices(ThisID)
            BS_SellPrice = New BindingSource
            BS_SellPrice.DataSource = SellPrices
            DGSellPrices.DataSource = BS_SellPrice
            SellPrices.Dispose()
        Catch ex As Exception
            LblSts.Text = ex.Message
            PictureBox1.Image = My.Resources.Cancel
        End Try
    End Sub
    Private Sub DGready_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles DGready.DataBindingComplete
        If DGready.Columns.Contains("ColAdd") Then
            With DGready
                .RowTemplate.Height = 35
                .Columns("ColAdd").HeaderText = "اضافة/حذف"
                .Columns("ColAdd").DisplayIndex = 6
                .Columns("ColAdd").ValueType = GetType(Boolean)
                .Columns("ColAdd").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                DirectCast(.Columns("ColAdd"), DataGridViewCheckBoxColumn).TrueValue = True
                DirectCast(.Columns("ColAdd"), DataGridViewCheckBoxColumn).FalseValue = False
                DirectCast(.Columns("ColAdd"), DataGridViewCheckBoxColumn).ThreeState = False
                DirectCast(.Columns("ColAdd"), DataGridViewCheckBoxColumn).DefaultCellStyle.NullValue = False
                .Columns("PID").Visible = False
                .Columns("Pname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Pname").HeaderText = "الصنف"
                .Columns("Units").HeaderText = "الوحدة"
                .Columns("Units").DataPropertyName = "Units"
                .Columns("ItmQntyIn").HeaderText = "الكمية"
                .Columns("ItmQntyIn").HeaderText = "الكمية"
                .Columns("ItmQntyIn").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .Columns("ItmPurPrice").HeaderText = "سعر الوحدة"
                .Columns("ItmPurPrice").DefaultCellStyle.Format = "C2"
                .Columns("ItmTotalPrice").HeaderText = "اجمالي الصنف"
                .Columns("ItmTotalPrice").DefaultCellStyle.Format = "C2"
                .Invalidate()
            End With
        End If
        If IsNothing(TempDT) Then Exit Sub
        If TempDT.Columns.Count = 0 Then
            For Each Col As DataGridViewColumn In DGready.Columns
                TempDT.Columns.Add(Col.Name, Col.ValueType)
            Next
            MnuSave.Enabled = False
        ElseIf TempDT.Rows.Count > 0 Then
            MnuSave.Enabled = True
        End If
    End Sub
    Private Sub DGready_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DGready.RowPostPaint
        Dim grid = TryCast(sender, DataGridView)
        Dim rowIdx As String = Convert.ToString(e.RowIndex + 1)
        Using centerFormat As StringFormat = New StringFormat() With
            {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
            Dim headerBounds =
                New Rectangle(e.RowBounds.Right - 40, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height)
            e.Graphics.DrawString(rowIdx, Font, Brushes.Black, headerBounds, centerFormat)
        End Using
    End Sub
    Private Sub DGready_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DGready.CurrentCellDirtyStateChanged
        If DGready.IsCurrentCellDirty And TypeOf DGready.CurrentCell Is DataGridViewCheckBoxCell Then
            DGready.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DGready_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellContentClick
        If Not TypeOf (DGready.CurrentCell) Is DataGridViewCheckBoxCell Then
            Return
        End If
        If Not DGready.CurrentCell.IsInEditMode Then
            Return
        End If
        If Not DGready.IsCurrentCellDirty Then
            Return
            DGready.EndEdit()
        End If
    End Sub
    Private Sub DGready_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellValueChanged
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Exit Sub
        'Get Changes Added After First AcceptChanges
        Dim Addedrows() As DataRow = TempDT.Select("PID='" & CInt(DGready("PID", e.RowIndex).Value.ToString) & "'")
        If Not DGready.CurrentCell Is DGready("ColAdd", e.RowIndex) Then
            If Addedrows.Length > 0 Then
                Addedrows(0)(e.ColumnIndex) = DGready(e.ColumnIndex, e.RowIndex).Value
                TempDT.AcceptChanges()
                TempBS.ResetBindings(True)
                DGPerv.Refresh()
            End If
        End If
        If DGready.Columns(e.ColumnIndex).Name = "ColAdd" Then
            Dim checkCell As DataGridViewCheckBoxCell = CType(DGready.Rows(e.RowIndex).Cells("ColAdd"), DataGridViewCheckBoxCell)
            If checkCell.Value = True Then
                Dim CellValues As DataGridViewCellCollection = DGready.CurrentRow.Cells
                For Each CelVal As DataGridViewCell In CellValues
                    If IsDBNull(CelVal.Value) OrElse IsNothing(CelVal.Value) OrElse CelVal.Value = 0.ToString Then
                        MsgBox("يجب تعبئة كل بيانات الصنف المختار")
                        DGready.CurrentRow.Cells("ColAdd").Value = False
                        DGready.CancelEdit()
                        Exit Sub
                    End If
                Next
                Try
                    TempDR = TempDT.NewRow
                    TempDR("PID") = CellValues("PID").Value
                    TempDR("Pname") = CellValues("Pname").Value
                    TempDR("ColAdd") = CellValues("ColAdd").Value
                    TempDR("Units") = CellValues("Units").Value
                    TempDR("ItmQntyIn") = CellValues("ItmQntyIn").Value
                    TempDR("ItmPurPrice") = CellValues("ItmPurPrice").Value
                    TempDR("ItmTotalPrice") = CellValues("ItmTotalPrice").Value
                    TempDT.Rows.Add(TempDR)
                    TempDT.AcceptChanges()
                Catch ex As Exception
                    LblSts.Text = ex.Message
                    PictureBox1.Image = My.Resources.Cancel
                    Exit Sub
                End Try
                Try
                    If Label3.Enabled = False Then Label3.Enabled = True
                    Label3.Text = "معاينة أمر الشراء (" & TempDT.Rows.Count.ToString & ")"
                Catch ex As Exception
                    LblSts.Text = ex.Message
                    PictureBox1.Image = My.Resources.Cancel
                End Try
            Else
                Dim rows() As DataRow = TempDT.Select("PID='" & CInt(DGready.CurrentRow.Cells("PID").Value.ToString) & "'")
                If rows.Length = 0 Then
                    MsgBox("صنف خاطئ")
                Else
                    If MsgBox("حذف ?" & rows(0)("Pname"), vbYesNo) = MsgBoxResult.Yes Then
                        TempDT.Rows.Remove(rows(0))
                        TempDT.AcceptChanges()
                        TempBS = New BindingSource
                        TempBS.DataSource = TempDT
                        TempBS.ResetBindings(True)
                        Label3.Text = "معاينة أمر الشراء (" & TempDT.Rows.Count.ToString & ")"
                    End If
                End If
            End If
            DataGridView1.Invalidate()
        End If
    End Sub
#End Region
#Region "Stay in the same Cell After cellEndEdit"
    Private currentRow, currentCell As Integer
    Private resetRow As Boolean = False
    Private Sub DGReady_SelectionChanged(sender As Object, e As EventArgs) Handles DGready.SelectionChanged
        Try
            If IsNothing(DGready.CurrentCell) Then Exit Sub
            If DGready("ColAdd", currentRow).Value = True Then
                resetRow = True
            End If
            If resetRow Then
                resetRow = False
                DGready.CurrentCell = DGready.Rows(currentRow).Cells(currentCell)
                'DGready.CurrentCell.OwningRow.Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGReady_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGready.CellEndEdit
        resetRow = True
        currentRow = e.RowIndex
        currentCell = e.ColumnIndex
#Region "Calculate PO"
        Dim poTotal As Double
        For Each Irow As DataGridViewRow In DGready.Rows
            If Irow.Cells("ColAdd").Value = True Then
                poTotal += CDbl(Irow.Cells("ItmQntyIn").Value * Irow.Cells("ItmPurPrice").Value)
            End If
            'Irow("ItmTotalPrice") = CDbl(Irow("ItmQntyIn").ToString) * CDbl(Irow("ItmPurPrice").ToString)
        Next
        DataGridView1.Rows(0).Cells("InvTotal").Value = poTotal
#End Region
    End Sub
    Private Sub DGready_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGready.RowHeaderMouseClick
        If IsNothing(DGready.CurrentCell) Then
            Exit Sub
        End If
        If e.Button = MouseButtons.Left Then
            resetRow = False
            DGready.CurrentCell = DGready("Pname", e.RowIndex)
            DGready.CurrentCell.OwningRow.Selected = True
        End If
    End Sub
    Private Sub DGready_KeyDown(sender As Object, e As KeyEventArgs) Handles DGready.KeyDown
        If e.KeyCode = Keys.F10 Then
            DGready.Select()
            If DGready.Columns.Count > 0 Then
                DGready.CurrentRow.Cells("ColAdd").Value = Not DGready.CurrentRow.Cells("ColAdd").Value
            End If
        End If
    End Sub
#End Region
#Region "Search"
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If DGready.RowCount > 0 Then
                    DGready.Select()
                    DGready.CurrentCell = DGready.Rows(0).Cells("Units")
                    DGready.BeginEdit(False)
                End If
            End If
        Catch ex As Exception
            LblSts.Text = ("عملية غير صحيحة : ") & ex.Message
            PictureBox1.Image = My.Resources.Cancel
            Exit Sub
        End Try

    End Sub
    Private BGS As New BindingSource
    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        Try
            If DGready.Visible = False Then DGready.Visible = True
            If Not IsNothing(DGPerv) Then DGPerv.Dispose()
            AddHandler DGready.SelectionChanged, AddressOf DGReady_SelectionChanged
            MnuSave.Enabled = False
        Catch ex As Exception
            LblSts.Text = ex.Message
            PictureBox1.Image = My.Resources.Cancel
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If String.IsNullOrEmpty(TextBox1.Text) Then
                DGready.AutoGenerateColumns = False
                DGready.DataSource = Nothing
                Exit Sub
            End If
            If DGready.Visible = False Then DGready.Visible = True
            If Not IsNothing(TempBS) Then TempBS.Dispose()
            Dim Filter = "Pname LIKE '%" & TextBox1.Text & "%'"
            Dim Sort = "Pname ASC"
            BindToDG(Filter, SORT)
        Catch ex As Exception
            LblSts.Text = ("عملية غير صحيحة : ") & ex.Message
            PictureBox1.Image = My.Resources.Cancel
            Exit Sub
        End Try
    End Sub
#End Region
    Private Sub _MPback_Click(sender As Object, e As EventArgs) Handles _MPback.Click
        Dispose()
    End Sub
#Region "Save new PO"
    Private Sub MnuSave_Click(sender As Object, e As EventArgs) Handles MnuSave.Click
        If IsNothing(ComboBox1.SelectedValue) OrElse IsNothing(ComboBox2.SelectedValue) Then
            LblSts.Text = "يجب تحديد المورد و طريقة الدفع"
            PictureBox1.Image = My.Resources.Cancel
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextBox7.Text) Then TextBox7.Text = "لا يوجد"
        If Label3.Enabled = False Then
            MsgBox("يجب تصفية الفاتورة - معاينة أمر الشراء أولا")
            Exit Sub
        End If
        PictureBox1.Image = Nothing
        LblSts.Text = String.Empty
        Dim NewPO As New PO_Details With
            {
        .PMID = CInt(ComboBox1.SelectedValue.ToString),
        .VendID = CInt(ComboBox2.SelectedValue.ToString),
        .PONotes = TextBox7.Text}
        Pno1.Text = NewPO.SaveNewPO(DGPerv).ToString
        LblSts.Text = "تم حفظ أمر الشراء"
        PictureBox1.Image = My.Resources.Apply
    End Sub
#End Region
End Class