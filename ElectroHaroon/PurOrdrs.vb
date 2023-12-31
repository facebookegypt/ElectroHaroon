﻿Imports System.Data.OleDb
Imports ElectroHaroon.Pur_Sell_Ordrs

Public Class PurOrdrs
    Private Ops As New DataOperations
    Private ConnectionString = Ops.GetEncryConStr
    Private ComboItemsK As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsS As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsU As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsV As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsT As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private WithEvents DGReady As DataGridView, Tempdt1 As DataTable =
        New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}, Tempdt2 As DataTable =
        New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
    Private WithEvents DGSells As DataGridView
    Private POVal As Double = 0.0, TCounter As Integer = 0, CboVal As Integer, CboSelectedText As String,
        CboVal1 As Integer, CboSelectedText1 As String, CboVal2 As Integer, CboSelectedText2 As String, TransType As Integer = 1

    Function GetAvailQOfItem(ByVal ItmPID As Integer) As Integer
        Dim Onh As Object = Nothing, SumOfQ As Integer = 0
        Dim SqlStrU As String = "SELECT Sum([qntyin]-[qntyout]) AS AvailQ FROM PurOrders INNER JOIN (Products INNER JOIN PODetails ON " &
            "Products.PID = PODetails.PID) ON PurOrders.POID = PODetails.POID GROUP BY PODetails.PID HAVING (((PODetails.PID)=?));"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
               CmdAvailQ As OleDbCommand = New OleDbCommand(SqlStrU, CN) With {.CommandType = CommandType.Text}
            CmdAvailQ.Parameters.AddWithValue("?", ItmPID)
            Try
                CN.Open()
                Onh = CmdAvailQ.ExecuteScalar
                If Onh Is DBNull.Value Or Onh Is Nothing Then
                    SumOfQ = 0
                    Return SumOfQ
                    Exit Function
                End If
            Catch ex As OleDbException
                MsgBox("عملية غير صحيحه")
                SumOfQ = 0
            End Try
        End Using
        SumOfQ = Convert.ToInt32(Onh)
        Return SumOfQ
    End Function
    Sub DisplayPreviewDG()
        'Checked Values to DataGrid
        Dim PoVal1 As Double
        If Tempdt1.Columns.Count <= 0 Then Exit Sub
        With DGReady
            .DataSource = New BindingSource(Tempdt1, Nothing)
            .Columns("PID").Visible = False
            .Columns("Pname").HeaderText = "اسم الصنف"
            .Columns("Pname").ReadOnly = True
            .Columns("Pdesc").HeaderText = "وصف الصنف"
            .Columns("Pdesc").ReadOnly = True
            .Columns("Pcost").HeaderText = "ت شراء الوحدة"
            .Columns("Pcost").ReadOnly = True
            .Columns("MinQ").HeaderText = "أقل كمية"
            .Columns("MinQ").ReadOnly = True
            .Columns("BarCode").HeaderText = "باركود"
            .Columns("BarCode").ReadOnly = True
            .Columns("Units").ReadOnly = True
            .Columns("Units").HeaderText = "الوحدة"
            .Columns("Stores").ReadOnly = True
            .Columns("Stores").HeaderText = "المخزن"
            .Columns("Qnty").HeaderText = "كمية مشتراه"
            .Columns("Qnty").ReadOnly = True
            .Columns("ItmTotal").HeaderText = "اجمالي الصنف"
            .Columns("ItmTotal").ReadOnly = True
            .Columns("AddMe").HeaderText = "اضافة/حذف صنف"
            .Columns("AddMe").ReadOnly = False
        End With
        Dim ItmTotal As Double = 0.0
        For Each Irow As DataGridViewRow In DGReady.Rows
            ItmTotal += Decimal.Parse(Irow.Cells("ItmTotal").Value.ToString)
        Next
        PoVal1 = ItmTotal
        TextBox2.Text = FormatCurrency(PoVal1, 2)

        With DGSells
            .DataSource = New BindingSource(Tempdt2, Nothing)
            .Columns("IcolP").Visible = False
            .Columns("IcolK").ReadOnly = True
            .Columns("IcolK").HeaderText = "سعر البيع"
            .Columns("KindNm").HeaderText = "الوحده"
            .Columns("KindID").Visible = False
        End With
    End Sub
    Private Sub AddColumnsToDG(MyTable As DataTable)
        If DGReady.DataSource Is MyTable Then Exit Sub
        If ComboItemsS.Count <= 0 Or ComboItemsU.Count <= 0 Then
            MsgBox("أضف (وحدات / مخازن / أنواع) أولا",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Basics.TargetForm = "Units"
            Basics.ShowDialog()
            Exit Sub
        End If
        'LoadComboU()
        Dim Icol0 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn With {
                    .Name = "Units", .HeaderText = "الوحدة", .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .ValueType = GetType(String), .[ReadOnly] = False, .Visible = True, .FlatStyle = FlatStyle.Standard, .ValueMember = "Key",
            .DisplayMember = "Value", .DataSource = New BindingSource(ComboItemsU, Nothing)}
        'LoadComboS()
        Dim Icol4 As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn With {
            .Name = "Stores", .HeaderText = "المخزن", .AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
            .ValueType = GetType(String), .[ReadOnly] = False, .Visible = True, .FlatStyle = FlatStyle.Standard, .ValueMember = "Key",
            .DisplayMember = "Value", .DataSource = New BindingSource(ComboItemsS, Nothing)
            }
        Dim Icol1 As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn With {
            .Name = "AddMe", .HeaderText = "أضافة/حذف لأمر الشراء", .ValueType = GetType(CheckState), .FalseValue = CheckState.Unchecked,
            .TrueValue = CheckState.Checked, .ThreeState = False, .[ReadOnly] = False, .Visible = True
            }
        With DGReady
            MyTable.Columns.AddRange(New DataColumn(1) _
                                     {New DataColumn("Qnty", GetType(Integer)) With {.DefaultValue = 0, .AllowDBNull = False},
                                     New DataColumn("ItmTotal", GetType(Decimal), "Qnty*Pcost")})
            With MyTable
                .Columns()("Qnty").ReadOnly = False
                .Columns()("ItmTotal").ReadOnly = True
            End With
            .DataSource = New BindingSource(MyTable, Nothing)
            .Columns("PID").Visible = False
            .Columns("Pname").HeaderText = "اسم الصنف"
            .Columns("Pname").ReadOnly = True
            .Columns("Pdesc").HeaderText = "وصف الصنف"
            .Columns("Pdesc").ReadOnly = True
            .Columns("Pcost").HeaderText = "ت شراء الوحدة"
            .Columns("Pcost").ReadOnly = False
            .Columns("MinQ").HeaderText = "أقل كمية"
            .Columns("MinQ").ReadOnly = True
            .Columns("BarCode").HeaderText = "باركود"
            .Columns("BarCode").ReadOnly = True
            .Columns("Qnty").HeaderText = "كمية مشتراه"
            .Columns("ItmTotal").HeaderText = "اجمالي الصنف"
            .Columns.AddRange({Icol0, Icol4, Icol1})
        End With
    End Sub
    Private Sub PurOrdrs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        'LoadComboV()
        'With ComboBox2
        ' .BeginUpdate()
        ' .DisplayMember = "Value"
        ' .ValueMember = "Key"
        ' .DataSource = New BindingSource(ComboItemsV, Nothing)
        ' .SelectedIndex = -1
        '.EndUpdate()
        'End With
        'Application.DoEvents()
        'LoadComboT()
        'With ComboBox1
        ' .BeginUpdate()
        ' .DisplayMember = "Value"
        ' .ValueMember = "Key"
        ' .DataSource = New BindingSource(ComboItemsT, Nothing)
        ' .SelectedIndex = -1
        ' .EndUpdate()
        ' End With
        DTP1.Value = Now
        DGReady = New DataGridView With
            {
        .EnableHeadersVisualStyles = False,
        .Dock = DockStyle.Fill,
        .EditMode = DataGridViewEditMode.EditOnEnter,
            .RightToLeft = RightToLeft.Yes,
            .Name = "DGReady",
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .ReadOnly = False,
            .ScrollBars = ScrollBars.Both,
            .RowHeadersWidth = 30
        }
        With DGReady
            .RowHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray
            .RowsDefaultCellStyle.ForeColor = Color.Black
            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowsDefaultCellStyle.Font = New Font("Arial Black", 9.25, FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Silver
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 13.25, FontStyle.Bold)
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        End With
        'GroupBox1.Controls.Add(DGReady)
        AddHandler DGReady.CellFormatting, AddressOf DGReady_CellFormatting
        AddHandler DGReady.DataError, AddressOf DGReady_DataError
        AddHandler DGReady.CurrentCellDirtyStateChanged, AddressOf DGready_CurrentCellDirtyStateChanged
        AddHandler DGReady.EditingControlShowing, AddressOf DGReady_EditingControlShowing
        AddHandler DGReady.CellValueChanged, AddressOf DGReady_CellValueChanged
        AddHandler DGReady.CellBeginEdit, AddressOf DGReady_CellBeginEdit
        AddHandler DGReady.RowEnter, AddressOf DGReady_RowEnter
        AddHandler DGReady.CellEndEdit, AddressOf DGReady_CellEndEdit
        DGSells = New DataGridView With
     {
 .EnableHeadersVisualStyles = False,
 .Dock = DockStyle.Fill,
 .EditMode = DataGridViewEditMode.EditOnEnter,
     .RightToLeft = RightToLeft.Yes,
     .Name = "DGSells",
     .Size = New Size(Width - 200, Height - MenuStrip2.Height * 7.1),
     .AllowUserToAddRows = False,
     .AllowUserToDeleteRows = False,
     .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
     .ReadOnly = False,
     .ScrollBars = ScrollBars.Both,
     .RowHeadersWidth = 30
 }
        With DGSells
            .RowHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray
            .RowsDefaultCellStyle.ForeColor = Color.Black
            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowsDefaultCellStyle.Font = New Font("Arial Black", 9.25, FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Silver
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 13.25, FontStyle.Bold)
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        End With
        'GroupBox2.Controls.Add(DGSells)
        AddHandler DGSells.CellFormatting, AddressOf DGSells_CellFormatting
        AddHandler DGSells.DataError, AddressOf DGSells_DataError
        AddHandler DGSells.CellEndEdit, AddressOf DGSells_CellEndEdit
        AddHandler DGSells.CellValueChanged, AddressOf DGSells_CellValueChanged
    End Sub
    Private Sub DGReady_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGSells.Rows.Count <= 0 Then Exit Sub
        If DGSells(0, 0).Value > 0 Then
            If DGReady.Columns.Contains("AddMe") Then
                If CType(DGReady("AddMe", e.RowIndex).Value, CheckState) = CheckState.Checked Then
                    For Each Irow As DataGridViewRow In DGSells.Rows
                        Irow.Cells("Icolk").Value = 0
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub DGReady_RowEnter(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub

    End Sub
    Private Sub PreviewCheckedData()
        'Adding the Columns.
        If Tempdt1.Columns.Count = DGReady.Columns.Count Then
            If TypeOf DGReady.CurrentCell Is DataGridViewCheckBoxCell Then
                Dim DR As DataRow
                Dim DR1 As DataRow
                For Each Row As DataGridViewRow In DGReady.SelectedRows
                    If Row.Cells("Units").Value Is Nothing Or
                        Row.Cells("Stores").Value Is Nothing Then
                        MsgBox("عملية غير صحيحة - أختر الوحده - النوع - المخزن")
                        Exit Sub
                    End If
                    If CType(Row.Cells("AddMe").Value, CheckState) = CheckState.Checked Then
                        DR = Tempdt1.NewRow
                        DR(0) = Row.Cells(0).Value.ToString
                        DR(1) = Row.Cells(1).Value.ToString
                        DR(2) = Row.Cells(2).Value.ToString
                        DR(3) = Row.Cells(3).Value.ToString
                        DR(4) = Row.Cells(4).Value.ToString
                        DR(5) = Row.Cells(5).Value.ToString
                        DR(6) = Row.Cells(6).Value.ToString
                        DR(7) = Row.Cells(7).Value.ToString
                        DR(8) = CboSelectedText
                        DR(9) = CboSelectedText1
                        DR(10) = CType(Row.Cells(10).Value, CheckState)
                        If Tempdt2.Columns.Count = DGSells.Columns.Count Then
                            For Each Irow As DataGridViewRow In DGSells.Rows
                                DR1 = Tempdt2.NewRow
                                DR1(0) = Irow.Cells(0).Value.ToString
                                DR1(1) = DR(0)
                                DR1(2) = Irow.Cells(2).Value.ToString
                                DR1(3) = Irow.Cells(3).Value.ToString
                                Tempdt2.Rows.Add(DR1)
                            Next
                            Tempdt1.Rows.Add(DR)
                        End If
                        Tempdt2.AcceptChanges()
                    End If
                Next
                Tempdt1.AcceptChanges()
            End If
        End If
    End Sub
    Private Sub DGReady_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGReady("Qnty", e.RowIndex) Is DGReady.CurrentCell Then
            TextBox9.Text = 0
            TextBox9.Text = GetAvailQOfItem(DGReady("PID", e.RowIndex).Value)
        End If
        If TypeOf DGReady.CurrentCell Is DataGridViewCheckBoxCell And CType(DGReady.CurrentCell.Value, CheckState) = CheckState.Unchecked Then
            Dim TotalSellP As Double
            For Each Irow As DataGridViewRow In DGSells.Rows
                TotalSellP += Val(Irow.Cells("IcolK").Value)
            Next
            If DGReady("Qnty", e.RowIndex).Value <= 0 Or
                DGReady("Units", e.RowIndex).Value Is Nothing Or
                DGReady("Stores", e.RowIndex).Value Is Nothing OrElse
                TotalSellP <= 0 Then
                MsgBox("عملية غير صحيحة - كمية = صفر" & vbCrLf & "أختر الوحده و السعر / النوع / المخزن",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub
    Private Sub DGSells_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        'خطأ عند الخروج بعد معاينة أمر الشراء
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGReady.CurrentRow Is Nothing Then Exit Sub
        If DGReady("Pcost", DGReady.CurrentRow.Index).Value >= DGSells("IcolK", e.RowIndex).Value And
            DGSells("IcolK", e.RowIndex).Value > 0 Then
            DGSells("IcolK", DGSells.CurrentCell.RowIndex).Value = 0
            MsgBox("عملية غير صحيحة - سعر البيع أقل من أو يساوي سعر الشراء",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If

    End Sub
    Private Sub DGSells_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
    End Sub
    Private Sub DGReady_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        Dim ItmTotal As Double = 0.0
        For Each row As DataGridViewRow In DGReady.SelectedRows
            ItmTotal = Decimal.Parse(row.Cells("PCost").Value * row.Cells("Qnty").Value)
        Next
        If Not DGReady.Columns(e.ColumnIndex).Name = "AddMe" Then Exit Sub
        'Add to preview DataTable
        PreviewCheckedData()
        DGReady.Invalidate()
        DGReady.Update()
        If DGReady.Columns(e.ColumnIndex).Name = "AddMe" AndAlso
            DGReady("AddMe", e.RowIndex).Value = CheckState.Checked Then
            POVal += ItmTotal
            TCounter += 1
        ElseIf DGReady.Columns(e.ColumnIndex).Name = "AddMe" AndAlso
            DGReady("AddMe", e.RowIndex).Value = CheckState.Unchecked Or
            DGReady("AddMe", e.RowIndex).Value = CheckState.Indeterminate Then
            Dim Irow As DataGridViewRow = DGReady.CurrentRow
            Dim rowCollection As DataRowCollection = Tempdt1.Rows
            Dim rowCollection1 As DataRowCollection = Tempdt2.Rows
            Dim foundRow() As DataRow = Tempdt1.Select("PID='" & Irow.Cells("PID").Value.ToString & "'")
            Dim foundRow1() As DataRow = Tempdt2.Select("IcolP='" & Irow.Cells("PID").Value.ToString & "'")
            rowCollection.Remove(foundRow(0))
            rowCollection1.Remove(foundRow1(0))
            rowCollection1.Remove(foundRow1(1))
            rowCollection1.Remove(foundRow1(2))
            Tempdt1.AcceptChanges()
            Tempdt2.AcceptChanges()
            POVal -= ItmTotal
            TCounter -= 1
        End If
        TextBox2.Text = FormatCurrency(POVal, 2)
        TextBox1.Text = TCounter.ToString
    End Sub
    Private Sub DGReady_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        'REMEMBER TO CHANGE THE COLUMN INDEX NUMBER TO YOUR COMBOBOX INDEX!!
        If TypeOf DGReady.CurrentCell Is DataGridViewComboBoxCell Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If combo IsNot Nothing Then
                If DGReady.CurrentCell.ColumnIndex = 8 Then
                    combo.DataSource = New BindingSource(ComboItemsU, Nothing)
                ElseIf DGReady.CurrentCell.ColumnIndex = 9 Then
                    combo.DataSource = New BindingSource(ComboItemsS, Nothing)
                ElseIf DGReady.CurrentCell.ColumnIndex = 10 Then
                    combo.DataSource = New BindingSource(ComboItemsK, Nothing)
                End If
                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)
                ' Add the event handler. 
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)
            End If
        End If
    End Sub
    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        If TypeOf DGReady.CurrentCell Is DataGridViewComboBoxCell Then
            If DGReady.Columns(DGReady.CurrentCell.ColumnIndex).Name = "Units" Then
                CboVal = DirectCast(combo.SelectedItem, KeyValuePair(Of Integer, String)).Key
                CboSelectedText = DirectCast(combo.SelectedItem, KeyValuePair(Of Integer, String)).Value
            ElseIf DGReady.Columns(DGReady.CurrentCell.ColumnIndex).Name = "Stores" Then
                CboVal1 = DirectCast(combo.SelectedItem, KeyValuePair(Of Integer, String)).Key
                CboSelectedText1 = DirectCast(combo.SelectedItem, KeyValuePair(Of Integer, String)).Value
            ElseIf DGReady.Columns(DGReady.CurrentCell.ColumnIndex).Name = "Kinds" Then
                CboVal2 = DirectCast(combo.SelectedItem, KeyValuePair(Of Integer, String)).Key
                CboSelectedText2 = DirectCast(combo.SelectedItem, KeyValuePair(Of Integer, String)).Value
            End If
            'DGReady.CurrentCell = DGReady.Item("Qnty", DGReady.Rows.GetLastRow(DataGridViewElementStates.None))
            'DGReady.BeginEdit(True)
            DGReady.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DGReady.EndEdit()
            DGReady.InvalidateCell(DGReady.CurrentCell)
            DGReady.Update()
        End If
    End Sub
    Private Sub DGready_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If DGReady.IsCurrentCellDirty And Not TypeOf DGReady.CurrentCell Is DataGridViewTextBoxCell Then
            DGReady.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DGReady.EndEdit()
        End If
    End Sub
    Private Sub DGSells_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub
    Private Sub DGReady_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub
    Private Sub MnuItems_Click(sender As Object, e As EventArgs) Handles MnuItems.Click
        InvPreview.TargetForm = "All_Pur_O"
        Dim Onhr, Onhr1 As Integer
        Dim SqlDrop As String =
            "DROP VIEW All_P_Ordrs;"
        Dim SqlStrCreate As String =
            "CREATE VIEW All_P_Ordrs AS SELECT PurOrders.POID, PurOrders.PODt, Vendors.VendNm, PurOrders.POTotal, PurOrders.PODisc, " &
            "PurOrders.PONet, PurOrders.POPaid, PurOrders.PORest, PurOrders.PTId, PurOrders.PONots, PayTypes.PTNm FROM PayTypes INNER " &
            "JOIN (PurOrders INNER JOIN Vendors ON PurOrders.VenID = Vendors.VenID) ON PayTypes.PTID = PurOrders.PTId GROUP BY " &
            "PurOrders.POID, PurOrders.PODt, PurOrders.TranID, Vendors.VendNm, PurOrders.POTotal, PurOrders.PODisc, PurOrders.PONet, " &
            "PurOrders.POPaid, PurOrders.PORest, PurOrders.PTId, PurOrders.PONots, PayTypes.PTNm HAVING (((PurOrders.TranID)=1));"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                CmdLPur As OleDbCommand = New OleDbCommand(SqlDrop, CN) With {.CommandType = CommandType.Text},
                CmdLPur1 As OleDbCommand = New OleDbCommand(SqlStrCreate, CN) With {.CommandType = CommandType.Text}
            CN.Open()
            Try
                Onhr = CmdLPur.ExecuteNonQuery
                Onhr1 = CmdLPur1.ExecuteNonQuery
            Catch ex As OleDbException
                Onhr1 = CmdLPur1.ExecuteNonQuery
            Finally
                InvPreview.ShowDialog()
            End Try
        End Using
    End Sub
    Private Sub DGReady_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 3 And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
        If e.ColumnIndex = 7 And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
    End Sub
    Private Sub DGSells_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.ColumnIndex = 0 And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
    End Sub
    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        DGReady.Columns.Clear()
        DGReady.DataSource = Nothing
        DGSells.Columns.Clear()
        DGSells.DataSource = Nothing
        DisplayPreviewDG()
        MnuSavePO.Enabled = True
    End Sub
    Private Sub NewMnuPO_Click(sender As Object, e As EventArgs) Handles NewMnuPO.Click
        'LOAD Datatable
        Dim Iunits As New Units
        Iunits.BindDGColumnUnits(DG1)
        Dim Istores As New Stores
        Istores.BindDGColumnStores(DG1)
        Dim OItems As New CombinedData()
        MySrch = New DataTable
        MySrch = OItems.GetDataItems()
        Dim DTcQin As DataColumn, DTCbuyPr As DataColumn, DTCtotal As DataColumn
        DTcQin = New DataColumn With
            {.ColumnName = "QntyIn", .DataType = GetType(Integer), .DefaultValue = 1}
        DTCbuyPr = New DataColumn With
            {.ColumnName = "PBuyPrice", .DataType = GetType(Double), .DefaultValue = 1.0}
        DTCtotal = New DataColumn With
            {.ColumnName = "Total", .DataType = GetType(Double), .DefaultValue = 1.0, .Expression = "QntyIn*PBuyPrice", .ReadOnly = True}
        MySrch.Columns.AddRange({DTcQin, DTCbuyPr, DTCtotal})
        BS2 = New BindingSource
        BS2.DataSource = MySrch

        Pno1.ReadOnly = False
        Pno1.Text = String.Empty
        ComboBox2.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        Button1.Enabled = True

        TextBox2.Text = 0.00.ToString("C2")
        TextBox3.Text = 0.00.ToString("C2")
        TextBox4.Text = 0.00.ToString("C2")
        TextBox5.Text = 0.00.ToString("C2")
        TextBox6.Text = 0.00.ToString("C2")

        TextBox1.Text = 0.ToString
        TextBox9.Text = 0.ToString
        TextBox7.Text = "لا يوجد"
        TextBox8.Text = String.Empty

        'Tempdt1.Clear()
        'Tempdt2.Clear()
        POVal = 0.00
        TCounter = 0
    End Sub
    Private Sub MnuSavePO_Click(sender As Object, e As EventArgs) Handles MnuSavePO.Click
        If DGReady.RowCount <= 0 Then
            MsgBox("عملية غير صحيحة - من فضلك أضف صنف",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Val(TextBox4.Text) <= 0 Then
            MsgBox("عملية غير صحيحة - من فضلك أدخل قيمة أمر الشراء",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Val(TextBox6.Text) <= 0 And Val(TextBox5.Text) <= 0 Then
            MsgBox("عملية غير صحيحة - من فضلك أدخل قيمة المدفوع أو المتبقي للمورد",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim OnhSave As Integer = Nothing, OnhSaveT As Integer = Nothing, OnhSaveZ As Integer = Nothing, OnhSave1 As Object = Nothing
        'INSERT New record in PirOrders Table, and Return its ID Field Value to use it in Purchase Orders Details.
        Dim SqlStrPO As String = "INSERT INTO PurOrders (PODt, VenID, PTID, PONots, TranID) VALUES (NOW(),?,?,?,?);"
        Dim SqlStrPOID As String = "SELECT Max([POID]) AS Expr1 FROM PurOrders WHERE (([PurOrders].[TranID]=?));"

        Using CN As OleDbConnection = New OleDbConnection(connectionstring)
            Dim tra As OleDbTransaction = Nothing
            CN.Open()
            tra = CN.BeginTransaction
            Using MyCmdStr As New OleDbCommand(SqlStrPO, CN, tra) With {.CommandType = CommandType.Text}
                With MyCmdStr.Parameters
                    .AddWithValue("?", CInt(ComboBox2.SelectedValue))
                    .AddWithValue("?", CInt(ComboBox1.SelectedValue))
                    .AddWithValue("?", TextBox7.Text)
                    .AddWithValue("?", TransType)
                End With
                OnhSave1 = MyCmdStr.ExecuteNonQuery()
            End Using
            Using MyCmdStr1 As New OleDbCommand(SqlStrPOID, CN, tra) With {.CommandType = CommandType.Text}
                With MyCmdStr1.Parameters
                    .AddWithValue("?", TransType)
                End With
                Try
                    Dim queryResult = MyCmdStr1.ExecuteScalar()
                    If queryResult Is DBNull.Value Or IsNothing(queryResult) Then
                        tra.Rollback()
                        Exit Sub
                    Else
                        OnhSave = DirectCast(queryResult, Integer)
                    End If
                    tra.Commit()
                Catch ex As OleDbException
                    MsgBox(ex.Message)
                    tra.Rollback()
                    Exit Sub
                End Try
            End Using
        End Using
        Pno1.Text = OnhSave.ToString
        Dim Saved As Integer = 0
        Dim SqlStrUpdt As String = "INSERT INTO PODetails (POID, PID, QntyIn, UnitID, StoreID, PBuyPrice, PODTotal, TranID) " &
                "VALUES (?,?,?,?,?,?,?,?);"

        For Each Irow As DataGridViewRow In DGReady.Rows
            Using CN As OleDbConnection = New OleDbConnection(connectionstring),
            MyCmdStr2 As New OleDbCommand(SqlStrUpdt, CN) With {.CommandType = CommandType.Text}
                With MyCmdStr2.Parameters
                    .AddWithValue("?", CInt(Pno1.Text))
                    .AddWithValue("?", CInt(Irow.Cells("PID").Value))
                    .AddWithValue("?", CInt(Irow.Cells("Qnty").Value))
                    .AddWithValue("?", GetValDic(ComboItemsU, Irow.Cells("Units").Value.ToString))
                    .AddWithValue("?", GetValDic(ComboItemsS, Irow.Cells("Stores").Value.ToString))
                    .AddWithValue("?", CDbl(Irow.Cells("PCost").Value))
                    .AddWithValue("?", CDbl(Irow.Cells("ItmTotal").Value))
                    .AddWithValue("?", TransType)
                End With
                CN.Open()
                Try
                    Saved += MyCmdStr2.ExecuteNonQuery()
                    If IsNothing(Saved) Or Saved <= 0 Then
                        MsgBox("عملية غير صحيحة")
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            End Using
        Next
        If Saved = 0 Then Exit Sub
        Dim SqlStrUpdt1 As String = "INSERT INTO SellPriceGrps (PID, KindID, GSellPrice, POID) VALUES (?,?,?,?);"
        For Each DT As DataRow In Tempdt2.Rows
            Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                     MyCmdStr3 As New OleDbCommand(SqlStrUpdt1, CN) With {.CommandType = CommandType.Text}
                With MyCmdStr3.Parameters
                    .AddWithValue("?", CInt(DT("IcolP")))
                    .AddWithValue("?", CInt(DT("KindID")))
                    .AddWithValue("?", CDbl(DT("IcolK")))
                    .AddWithValue("?", OnhSave)
                End With
                CN.Open()
                Try
                    OnhSaveT += MyCmdStr3.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
            End Using
        Next
        Dim POSaved As Integer = 0
        Dim POUpdate As String = "UPDATE PurOrders SET POTotal=?, PODisc=?, PONet=?, POPaid=?, PORest=?, PONots=? WHERE POID=?;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
            MyCmdStr3 As New OleDbCommand(POUpdate, CN) With {.CommandType = CommandType.Text}
            With MyCmdStr3.Parameters
                .AddWithValue("?", Double.Parse(TextBox2.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Double.Parse(TextBox3.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Double.Parse(TextBox4.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Double.Parse(TextBox6.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Double.Parse(TextBox5.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", TextBox7.Text)
                .AddWithValue("?", OnhSave)
            End With
            Try
                CN.Open()
                If MyCmdStr3.ExecuteNonQuery = 0 Then
                    MsgBox("عملية غير صحيحة")
                    Exit Sub
                End If
            Catch ex As OleDbException
                MsgBox("" & ex.Message)
                Exit Sub
            End Try
        End Using
        MsgBox("  تم انشاء أمر شراء جديد و اضافة " & Saved.ToString & " الأصناف له   ",
               MsgBoxStyle.MsgBoxRtlReading, MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Information)
        NewMnuPO.Enabled = True
        MnuSavePO.Enabled = False
        Pno1.ReadOnly = True
    End Sub
    Function GetValDic(Dic As Dictionary(Of Integer, String), Kv As String) As Integer
        ' Create and return a KeyValuePair instance.
        Dim listID As List(Of Integer) = New List(Of Integer)
        For Each pair As KeyValuePair(Of Integer, String) In Dic
            If pair.Value = Kv Then
                listID.Add(pair.Key)
            End If
        Next
        Return listID(0)
    End Function
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Open Vendors Form
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
        Vndrs.ShowDialog()
        'LoadComboV()
        'With ComboBox2
        ' .BeginUpdate()
        ' .DisplayMember = "Value"    'VenID
        ''.ValueMember = "Key"    'VName
        ' .DataSource = New BindingSource(ComboItemsV, Nothing)
        ' .SelectedIndex = -1
        ' .EndUpdate()
        ' End With
    End Sub
    Private Sub PurOrdrs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Close()
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or (e.KeyChar) = ChrW(Keys.Back))
        If e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(TextBox3.Text) Then TextBox3.Text = Val(0)
            Dim DisPO = TextBox3.Text
            TextBox4.Text = FormatCurrency((TextBox2.Text - DisPO).ToString, 2)
            TextBox3.Text = FormatCurrency(DisPO, 2)
            TextBox6.Focus()
        End If
    End Sub
    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        TextBox3.SelectAll()
    End Sub
    Private Sub MenuStrip2_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub MnuPayTypes_Click(sender As Object, e As EventArgs) Handles MnuPayTypes.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Basics") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim UnitFrm As New Basics
        UnitFrm.TargetForm = "PayTypes"
        UnitFrm.Show(Me)
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
    Private Sub MnuLesItms_Click(sender As Object, e As EventArgs) Handles MnuLesItms.Click
        InvPreview.TargetForm = "PODetails_Less"
        Dim Onhr, Onhr1 As Integer
        Dim SalInvDrop As String = "DROP VIEW Pur_Less;"
        Dim SalInvCreate As String =
            "CREATE VIEW Pur_Less AS SELECT PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc, " &
            "Last(PODetails.PBuyPrice) AS LastOfPBuyPrice, Units.UnitNm, Stores.StoreNm FROM Units INNER JOIN (Stores INNER JOIN " &
            "(PurOrders INNER JOIN (Products INNER JOIN PODetails ON Products.PID = PODetails.PID) ON PurOrders.POID = PODetails.POID) " &
            "ON Stores.StoreID = PODetails.StoreID) ON Units.UnitID = PODetails.UnitID GROUP BY PODetails.PID, Products.BarCode, Products.Pname, " &
            "Products.Pdesc, Units.UnitNm, Stores.StoreNm HAVING (((Sum([QntyIn]-[QntyOut]))=0));"
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
                InvPreview.ShowDialog()
            End Try
        End Using
    End Sub
    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Basics") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim UnitFrm As New Basics
        UnitFrm.TargetForm = "Units"
        UnitFrm.ShowDialog()
    End Sub
    Private Sub MnuPrint_Click(sender As Object, e As EventArgs) Handles MnuPrint.Click
        If Pno1.Text = String.Empty Then Exit Sub
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                Cmd As OleDbCommand = New OleDbCommand("SELECT COUNT(POID) FROM PurOrders WHERE POID=?;", CN) With
                {.CommandType = CommandType.Text}
            Cmd.Parameters.AddWithValue("?", CInt(Pno1.Text))
            Try
                CN.Open()
                Dim PoCount As Integer = Convert.ToInt32(Cmd.ExecuteScalar)
                If PoCount <= 0 Then
                    MsgBox("عملية غير صحيحة - أمر شراء غير موجود",
                           MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
                End If
            Catch ex As OleDbException
                MsgBox("عملية غير صحيحة - أمر شراء غير موجود" & vbCrLf &
                       ex.Message, MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Finally
                CN.Close()
            End Try
        End Using
        InvPreview.TargetForm = "PODetails_Prev"
        Dim Onhr, Onhr1 As Integer
        Dim SalInvDrop As String = "DROP VIEW Pur_Ordr_Prev;"
        Dim SalInvCreate As String =
            "CREATE VIEW Pur_Ordr_Prev AS SELECT PurOrders.POID, PurOrders.PODt, Vendors.VendNm, Products.BarCode, Products.Pname, " &
            "Products.Pdesc, PODetails.QntyIn, PODetails.PBuyPrice, PODetails.PODTotal, Units.UnitNm, Stores.StoreNm, PayTypes.PTNm, " &
            "PurOrders.POTotal, PurOrders.PODisc, PurOrders.PONet, PurOrders.POPaid, PurOrders.PORest, PurOrders.PONots, " &
            "SellPriceGrps.GSellPrice, Kinds.KindNm, SellPriceGrps.GSellPrice FROM Units INNER JOIN (TranTypes INNER JOIN " &
            "(Stores INNER JOIN ((PayTypes INNER JOIN (Vendors INNER JOIN PurOrders ON Vendors.VenID = PurOrders.VenID) " &
            "ON PayTypes.PTID = PurOrders.PTId) INNER JOIN (Products INNER JOIN (Kinds INNER JOIN (SellPriceGrps INNER JOIN PODetails " &
            "ON SellPriceGrps.PID = PODetails.PID) ON Kinds.KindID = SellPriceGrps.KindID) ON Products.PID = PODetails.PID) " &
            "ON PurOrders.POID = PODetails.POID) ON Stores.StoreID = PODetails.StoreID) ON (TranTypes.TranID = PurOrders.TranID) And " &
            "(TranTypes.TranID = PODetails.TranID)) ON Units.UnitID = PODetails.UnitID WHERE (((SellPriceGrps.POID)=[PurOrders].[POID])) " &
            "GROUP BY PurOrders.POID, PurOrders.PODt, Vendors.VendNm, Products.BarCode, Products.Pname, Products.Pdesc, PODetails.QntyIn, " &
            "PODetails.PBuyPrice, PODetails.PODTotal, Units.UnitNm, Stores.StoreNm, PayTypes.PTNm, PurOrders.POTotal, PurOrders.PODisc, " &
            "PurOrders.PONet, PurOrders.POPaid, PurOrders.PORest, PurOrders.PONots, Kinds.KindNm, SellPriceGrps.GSellPrice, TranTypes.TranID " &
            "HAVING (((PurOrders.POID)=" & CInt(Pno1.Text) & ") And ((TranTypes.TranID)=1));"
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
                InvPreview.ShowDialog()
            End Try
        End Using
    End Sub
    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Basics") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim UnitFrm As New Basics
        UnitFrm.TargetForm = "Stores"
        UnitFrm.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Dim FOs = My.Application.OpenForms
        For Each Fo As Form In FOs
            If Fo.Name.Equals("Basics") Then
                Fo.BringToFront()
                Fo.Activate()
                Exit Sub
            End If
        Next
        PreForm = Me
        Dim UnitFrm As New Basics
        UnitFrm.TargetForm = "Kinds"
        UnitFrm.ShowDialog()
    End Sub
    Private Sub TextBox6_Click(sender As Object, e As EventArgs) Handles TextBox6.Click
        TextBox6.SelectAll()
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or (e.KeyChar) = ChrW(Keys.Back))
        If e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(TextBox6.Text) Then TextBox6.Text = Val(0)
            Dim DisPaid = TextBox6.Text
            TextBox5.Text = FormatCurrency((TextBox4.Text - DisPaid).ToString, 2)
            TextBox6.Text = FormatCurrency(DisPaid, 2)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles TextBox8.Click
        TextBox8.SelectAll()
    End Sub
    Private Sub PurOrdrs_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler DGReady.CellFormatting, AddressOf DGReady_CellFormatting
        RemoveHandler DGReady.DataError, AddressOf DGReady_DataError
        RemoveHandler DGReady.CurrentCellDirtyStateChanged, AddressOf DGready_CurrentCellDirtyStateChanged
        RemoveHandler DGReady.EditingControlShowing, AddressOf DGReady_EditingControlShowing
        RemoveHandler DGReady.CellValueChanged, AddressOf DGReady_CellValueChanged
        RemoveHandler DGReady.CellBeginEdit, AddressOf DGReady_CellBeginEdit
    End Sub
    Private Sub PurOrdrs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ItemsFrm.Activate()
    End Sub
    Private Sub Pno1_DoubleClick(sender As Object, e As EventArgs) Handles Pno1.DoubleClick
        Pno1.ReadOnly = False
    End Sub
#Region "Search Items"
    Private MySrch As DataTable, BS2 As BindingSource
    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        'Activated the datagridview on Enter
        If e.KeyCode = Keys.Enter Then
            DG1.Select()
            DG1.CurrentCell = DG1.FirstDisplayedCell
        End If
    End Sub
    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
    Private Sub TextBox8_GotFocus(sender As Object, e As EventArgs) Handles TextBox8.GotFocus

    End Sub
    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        Try
            If String.IsNullOrEmpty(TextBox8.Text) Then
                DG1.AutoGenerateColumns = True
                DG1.DataSource = Nothing
                Exit Sub
            End If
            Dim Filter As String =
                "Pname LIKE '%" & TextBox8.Text & "%'"
            BS2.Filter = Filter
            With DG1
                .AutoGenerateColumns = True
                .DataSource = BS2

                .Columns("PID").Visible = False

                .Columns("QntyIn").HeaderText = "الكمية"
                .Columns("QntyIn").ReadOnly = True
                .Columns("QntyIn").DisplayIndex = 3

                .Columns("PBuyPrice").HeaderText = "سعر الشراء"
                .Columns("PBuyPrice").DefaultCellStyle.NullValue = 0.00.ToString("C2")
                .Columns("PBuyPrice").DefaultCellStyle.Format = "C2"
                .Columns("PBuyPrice").ReadOnly = True
                .Columns("PBuyPrice").DisplayIndex = 4

                .Columns("Total").HeaderText = "الاجمالي"
                .Columns("Total").DefaultCellStyle.Format = "C2"
                .Columns("Total").ReadOnly = True
                .Columns("Total").DisplayIndex = 5

            End With
        Catch ex As Exception
            TextBox7.Text = ("عملية غير صحيحة : ") & ex.Message
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNothing(ComboBox2.SelectedItem) OrElse
                IsNothing(ComboBox1.SelectedItem) Then
            MsgBox("اسم المورد و طريقة الدفع")
            Exit Sub
        End If
        Dim NewPO As New PO_Details With
        {
        .PMID = CInt(ComboBox1.SelectedValue.ToString),
        .PO_Date = DTP1.Value,
        .VendID = CInt(ComboBox2.SelectedValue.ToString),
        .PONotes = TextBox7.Text
        }
        Try
            Dim SavedPO = NewPO.SaveNewPO(DGReady)
            Pno1.Text = SavedPO
            Pno1.ReadOnly = True
            Button1.Enabled = False
            TextBox8.ReadOnly = False
            TextBox8.Focus()
            Label12.Text = "اضافة اصناف لأمر الشراء رقم " & Pno1.Text
        Catch ex As Exception
            Label12.Text = "مشكلة في انشاء أمر شراء جديد"
            Pno1.ReadOnly = False
            Button1.Enabled = True
            TextBox8.ReadOnly = True
        End Try

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click

    End Sub

    Private Sub PurOrdrs_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call Label15_Click(sender, e)
        End If
        If e.Control AndAlso e.KeyCode = Keys.F Then
            TextBox8.Focus()
            TextBox8.SelectAll()
        End If
    End Sub

#End Region
    Private Sub ComboBox2_DropDown(sender As Object, e As EventArgs) Handles ComboBox2.DropDown
        'Load Vendors
        Dim CC As New CombinedData() With {.Key_ID = "VenID", .Val_Nm = "VendNm", .Tbl_Nm = "Vendors"}
        Dim Btbl As DataTable = CC.GetData()
        With ComboBox2
            .DataSource = Btbl
            .DisplayMember = "VendNm"
            .ValueMember = "VenID"
        End With
    End Sub
    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        'Load PayTypes
        Dim CC As New CombinedData() With {.Key_ID = "PTID", .Val_Nm = "PTNm", .Tbl_Nm = "PayTypes"}
        Dim Btbl As DataTable = CC.GetData()
        With ComboBox1
            .DataSource = Btbl
            .DisplayMember = "PTNm"
            .ValueMember = "PTID"
        End With
    End Sub
    Private Sub PurOrdrs_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Format DataGridView
        TextBox8.ReadOnly = True
        formatDG(DG1)
        DG1.Columns("Units").ValueType = GetType(Integer)
        DG1.Columns("Stores").ValueType = GetType(Integer)
        DG1.MultiSelect = False
        DG1.StandardTab = True
    End Sub

    Private Sub DG1_KeyDown(sender As Object, e As KeyEventArgs) Handles DG1.KeyDown
        ' If e.KeyCode = Keys.F1 Then
        'CType(DG1.CurrentRow.Cells("Units"), DataGridViewComboBoxCell).Value = 1
        'End If
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{LEFT}")
        End If
    End Sub
    Private Sub DG1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DG1.CurrentCellDirtyStateChanged
        RemoveHandler DG1.CurrentCellDirtyStateChanged, AddressOf DG1_CurrentCellDirtyStateChanged
        If TypeOf DG1.CurrentCell Is DataGridViewCheckBoxCell Then
            DG1.EndEdit()
            Dim Currentrow As DataGridViewRow = DG1.CurrentRow
            Dim Checked As Boolean = CType(DG1.CurrentCell.Value, Boolean)
            'If Checked Then
            For Each Cell As DataGridViewCell In Currentrow.Cells
                Try
                    If Not TypeOf Cell Is DataGridViewCheckBoxCell Then
                        With Currentrow
                            .Cells("QntyIn").ReadOnly = Not Checked
                            .Cells("PBuyPrice").ReadOnly = Not Checked
                            .Cells("Units").ReadOnly = Not Checked
                            .Cells("Stores").ReadOnly = Not Checked
                        End With
                    End If
                Catch ex As Exception
                    Exit For
                    MsgBox(ex.Message)
                End Try
            Next
            DG1.InvalidateCell(DG1.CurrentCell)
        End If
        AddHandler DG1.CurrentCellDirtyStateChanged, AddressOf DG1_CurrentCellDirtyStateChanged
    End Sub
#Region "Manage DatagridviewComboboxcell click"
    Private Sub DG1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DG1.EditingControlShowing
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            Dim cmb As ComboBox = CType(e.Control, ComboBox)
            If cmb.Items.Count <= 1 Then
                cmb.SelectedValue = 0
                cmb.EndUpdate()
                Exit Sub
            End If
            RemoveHandler cmb.SelectionChangeCommitted, AddressOf cmb_SelectionChangeCommitted
            AddHandler cmb.SelectionChangeCommitted, AddressOf cmb_SelectionChangeCommitted
        End If
    End Sub
    Private Sub cmb_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        DG1.CurrentCell.Value = CType(sender, DataGridViewComboBoxEditingControl).EditingControlFormattedValue
    End Sub
#End Region
#Region "to disable Enter key after edit use events CellEndEdit and SelectionChanged"
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Dim dt As DataTable = New DataTable()
        DG1.Columns("Chk").ValueType = Type.GetType("System.Boolean")
        For Each column As DataGridViewColumn In DG1.Columns
            dt.Columns.Add(column.Name, column.ValueType)
        Next
        For i As Integer = 0 To DG1.RowCount - 1
            If DG1.Rows(i).Cells("Chk").Value = True Then
                dt.Rows.Add()
                For j As Integer = 1 To DG1.ColumnCount - 1
                    dt.Rows(i)("d") = True

                    dt.Rows(i)(j) = DG1.Rows(i).Cells(j).Value.ToString
                Next
            End If
        Next
    End Sub
#End Region
End Class