Imports System.Data.OleDb
Imports System.Linq

Public Class SalesOrders
    Private Ops As New DataOperations
    Private ConnectionString = Ops.GetEncryConStr
    Private ComboItemsK As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsS As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsU As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsT As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)
    Private ComboItemsC As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

    Private Tempdt2 As DataTable =
        New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
    Private WithEvents DGSells As DataGridView
    Private WithEvents DGReady As DataGridView, Tempdt1 As DataTable =
        New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
    Private POVal As Double = 0.0, TCounter As Integer = 0, CboVal As Integer, CboSelectedText As String,
        CboVal1 As Integer, CboSelectedText1 As String, CboVal2 As Integer, CboSelectedText2 As String, TransType As Integer = 2, SellTyp As Integer
    Private CustID As Integer, PayTyp As Integer

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
    Sub LoadComboS()
        ComboItemsS.Clear()
        Dim SqlStrs As String = "SELECT * FROM Stores;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
               cmdStores As OleDbCommand = New OleDbCommand(SqlStrs, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Using SReadr As OleDbDataReader = cmdStores.ExecuteReader
                    If SReadr.HasRows Then
                        While SReadr.Read
                            ComboItemsS.Add(SReadr.GetInt32(0), SReadr.GetString(1))
                        End While
                    Else
                        ComboItemsS.Add(0, String.Empty)
                        Exit Sub
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub
    Private Sub LoadComboT()
        ComboItemsT.Clear()
        Dim SqlStrT As String = "SELECT * FROM PayTypes;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                CMDTypes As OleDbCommand = New OleDbCommand(SqlStrT, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Using TypReadr As OleDbDataReader = CMDTypes.ExecuteReader
                    If TypReadr.HasRows Then
                        While TypReadr.Read
                            ComboItemsT.Add(TypReadr.GetInt32(0), TypReadr.GetString(1))
                        End While
                    Else
                        ComboItemsT.Add(0, String.Empty)
                        Exit Sub
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub
    Sub LoadComboC()
        ComboItemsC.Clear()
        Dim SqlStrv As String = "SELECT * FROM Customers;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                cmdVendors As OleDbCommand = New OleDbCommand(SqlStrv, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Using VendReadr As OleDbDataReader = cmdVendors.ExecuteReader
                    If VendReadr.HasRows Then
                        While VendReadr.Read
                            ComboItemsC.Add(VendReadr.GetInt32(0), VendReadr.GetString(1))
                        End While
                    Else
                        ComboItemsC.Add(0, String.Empty)
                        Exit Sub
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub
    Sub LoadComboU()
        ComboItemsU.Clear()
        Dim SqlStrU As String = "SELECT * FROM Units;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
               CmdUnits As OleDbCommand = New OleDbCommand(SqlStrU, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Using UReadr As OleDbDataReader = CmdUnits.ExecuteReader
                    If UReadr.HasRows Then
                        While UReadr.Read
                            ComboItemsU.Add(UReadr.GetInt32(0), UReadr.GetString(1))
                        End While
                    Else
                        ComboItemsU.Add(0, String.Empty)
                        Exit Sub
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox(ex.Message)
            End Try
        End Using
    End Sub
    Sub LoadComboK()
        ComboItemsK.Clear()
        Dim SqlStrk As String = "SELECT * FROM Kinds ORDER BY KindID;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                cmdkiNds As OleDbCommand = New OleDbCommand(SqlStrk, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Using KReadr As OleDbDataReader = cmdkiNds.ExecuteReader
                    If KReadr.HasRows Then
                        While KReadr.Read
                            ComboItemsK.Add(KReadr.GetInt32(0), KReadr.GetString(1))
                        End While
                    Else
                        ComboItemsK.Add(0, String.Empty)
                        Exit Sub
                    End If
                End Using
            Catch ex As OleDbException
                MsgBox("Combo Units : " & ex.Message)
                Exit Sub
            End Try
        End Using
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
    Private Sub TextBox8_Click(sender As Object, e As EventArgs) Handles TextBox8.Click
        TextBox8.SelectAll()
    End Sub
    Private Sub SalesOrders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        DoubleBuffered = True
        LoadComboC()
        With ComboBox2
            .BeginUpdate()
            .DisplayMember = "Value"
            .ValueMember = "Key"
            .DataSource = New BindingSource(ComboItemsC, Nothing)
            .SelectedIndex = -1
            .EndUpdate()
        End With
        Application.DoEvents()

        LoadComboT()
        With ComboBox1
            .BeginUpdate()
            .DisplayMember = "Value"
            .ValueMember = "Key"
            .DataSource = New BindingSource(ComboItemsT, Nothing)
            .SelectedIndex = -1
            .EndUpdate()
        End With

        Application.DoEvents()

        LoadComboK()
        With ComboBox3
            .BeginUpdate()
            .DisplayMember = "Value"
            .ValueMember = "Key"
            .DataSource = New BindingSource(ComboItemsK, Nothing)
            .SelectedIndex = -1
            .EndUpdate()
        End With

        DGReady = New DataGridView With {
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
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
            .RowHeadersDefaultCellStyle.BackColor = Color.Aquamarine
            .BackgroundColor = Color.MediumAquamarine
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
        GroupBox1.Controls.Add(DGReady)
        AddHandler DGReady.CellFormatting, AddressOf DGReady_CellFormatting
        AddHandler DGReady.CellEndEdit, AddressOf DGReady_CellEndEdit
        AddHandler DGReady.CellBeginEdit, AddressOf DGReady_CellBeginEdit
        AddHandler DGReady.DataError, AddressOf DGReady_DataError
        AddHandler DGReady.CurrentCellDirtyStateChanged, AddressOf DGready_CurrentCellDirtyStateChanged
        AddHandler DGReady.EditingControlShowing, AddressOf DGReady_EditingControlShowing
        AddHandler DGReady.CellValueChanged, AddressOf DGReady_CellValueChanged
        AddHandler DGReady.CellValidating, AddressOf DGReady_CellValidating
        AddHandler DGReady.CellValidated, AddressOf DGReady_CellValidated
    End Sub
    Private Sub DGReady_CellValidated(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
    End Sub
    Private Sub DGReady_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGReady.Columns.Count < 12 Then Exit Sub
        If DGReady("QntyOut", e.RowIndex) Is DGReady.CurrentCell Then
            If CInt(e.FormattedValue) > DGReady("AvailQ", e.RowIndex).Value Then
                MsgBox("عملية غير صحيحة - الكمية المباعه أكبر من الكمية المتبقية",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub DGReady_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGReady("AddMe", e.RowIndex) Is DGReady.CurrentCell And TypeOf DGReady.CurrentCell Is DataGridViewCheckBoxCell Then
            If DGReady("QntyOut", e.RowIndex).Value <= 0 Or
                DGReady("SellPrice", e.RowIndex).Value <= 0 Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub DGReady_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        'خطأ عند الخروج بعد معاينة أمر الشراء
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        If DGReady("QntyOut", e.RowIndex) Is DGReady.CurrentCell Then
            If DGReady("QntyOut", e.RowIndex).Value > DGReady("AvailQ", e.RowIndex).Value Then
                MsgBox("عملية غير صحيحة - الكمية المباعه أكبر من الكمية المتبقية",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub DGReady_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        If e.RowIndex = -1 Or e.ColumnIndex = -1 Then Exit Sub
        Dim ItmTotal As Double = 0.0
        For Each row As DataGridViewRow In DGReady.SelectedRows
            ItmTotal = Decimal.Parse(row.Cells("SellPrice").Value * row.Cells("QntyOut").Value)
        Next
        If Not DGReady.Columns(e.ColumnIndex).Name = "AddMe" Then Exit Sub
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
            Label15.Enabled = True
            Dim Irow As DataGridViewRow = DGReady.CurrentRow
            Dim rowCollection As DataRowCollection = Tempdt1.Rows
            Dim foundRow() As DataRow = Tempdt1.Select("PID='" & Irow.Cells("PID").Value.ToString & "'")
            rowCollection.Remove(foundRow(0))
            Tempdt1.AcceptChanges()
            POVal -= ItmTotal
            TCounter -= 1
        End If
        TextBox2.Text = FormatCurrency(POVal, 2)
        TextBox1.Text = TCounter.ToString
    End Sub
    Private Sub PreviewCheckedData()
        'Adding the Columns.
        If Tempdt1.Columns.Count = DGReady.Columns.Count Then
            If TypeOf DGReady.CurrentCell Is DataGridViewCheckBoxCell Then
                Dim DR As DataRow
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
                        DR(8) = DR(4) - DR(7)
                        DR(9) = Row.Cells(9).Value.ToString
                        DR(10) = Row.Cells(10).FormattedValue
                        DR(11) = Row.Cells(11).FormattedValue
                        DR("AddMe") = CType(Row.Cells("AddMe").Value, CheckState)
                        Tempdt1.Rows.Add(DR)
                    End If
                Next
                Tempdt1.AcceptChanges()
            End If
        End If
    End Sub
    Private Sub DGReady_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        'REMEMBER TO CHANGE THE COLUMN INDEX NUMBER TO YOUR COMBOBOX INDEX!!
        If TypeOf DGReady.CurrentCell Is DataGridViewComboBoxCell Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)
            If combo IsNot Nothing Then '
                ' Remove an existing event-handler, if present, to avoid adding multiple handlers when the editing control is reused.
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)
                ' Add the event handler. 
                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf ComboBox_SelectionchangeCommitted)
                'End If
            End If
        End If
        'End If
    End Sub
    Private Sub ComboBox_SelectionchangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
        Dim combo As ComboBox = CType(sender, ComboBox)
        If TypeOf DGReady.CurrentCell Is DataGridViewComboBoxCell And DGReady.CurrentCell.IsInEditMode = True Then
            DGReady.CommitEdit(DataGridViewDataErrorContexts.Commit)
            DGReady.EndEdit()
            DGReady.InvalidateCell(DGReady.CurrentCell)
            DGReady.Update()
        End If
    End Sub
    Private Sub DGready_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
        If DGReady.IsCurrentCellDirty And Not TypeOf DGReady.CurrentCell Is DataGridViewTextBoxCell Then
            DGReady.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
            DGReady.EndEdit()
        End If
    End Sub
    Private Sub DGReady_DataError(sender As Object, e As DataGridViewDataErrorEventArgs)
        e.Cancel = True
    End Sub
    Private Sub DGReady_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DGReady.Columns(e.ColumnIndex).Name = "SellPrice" And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
        If DGReady.Columns(e.ColumnIndex).Name = "ItmTotal" And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
    End Sub
    Private Sub NewMnuPO_Click(sender As Object, e As EventArgs) Handles NewMnuPO.Click
        DGReady.Columns.Clear()
        Pno1.ReadOnly = True
        DGReady.DataSource = Nothing
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox1.Text = 0
        ComboBox1.SelectedIndex = 0
        ComboBox1.Visible = True
        ComboBox2.SelectedIndex = 0
        ComboBox2.Visible = True
        ComboBox3.SelectedIndex = 0
        ComboBox3.Visible = True
        Label21.Visible = False
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = "لا يوجد"
        Tempdt1.Clear()
        POVal = 0.0
        TCounter = 0
        Pno1.Text = String.Empty
        TextBox8.Select()
        TextBox8.SelectAll()
        TextBox8.Text = String.Empty
        Label15.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Custms.ShowDialog()
        LoadComboC()
        With ComboBox2
            .BeginUpdate()
            .DisplayMember = "Value"    'VenID
            .ValueMember = "Key"    'VName
            .DataSource = New BindingSource(ComboItemsC, Nothing)
            .SelectedIndex = -1
            .EndUpdate()
        End With
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
        Basics.TargetForm = "PayTypes"
        Basics.ShowDialog()
        LoadComboT()
        With ComboBox1
            .BeginUpdate()
            .DisplayMember = "Value"
            .ValueMember = "Key"
            .DataSource = New BindingSource(ComboItemsT, Nothing)
            .SelectedIndex = -1
            .EndUpdate()
        End With
    End Sub
    Sub DisplayPreviewDG()
        'Checked Values to DataGrid
        Dim PoVal1 As Double
        If Tempdt1.Columns.Count <= 0 Then Exit Sub
        With DGReady
            .DataSource = New BindingSource(Tempdt1, Nothing)
            .Columns("PID").Visible = False
            .Columns("BarCode").HeaderText = "باركود"
            .Columns("BarCode").ReadOnly = True
            .Columns("Pname").HeaderText = "اسم الصنف"
            .Columns("Pname").ReadOnly = True
            .Columns("Pdesc").HeaderText = "وصف الصنف"
            .Columns("Pdesc").ReadOnly = True
            .Columns("SumOfQntyIn").Visible = False
            .Columns("SumOfQntyOut").Visible = False
            .Columns("SellPrice").HeaderText = "اخر سعر بيع"
            .Columns("SellPrice").ReadOnly = True
            .Columns("QntyOut").HeaderText = "الكمية"
            .Columns("QntyOut").ReadOnly = True
            .Columns("AvailQ").HeaderText = "الكمية المتبقية"
            .Columns("AvailQ").ReadOnly = True
            .Columns("ItmTotal").HeaderText = "اجمالي الصنف"
            .Columns("ItmTotal").ReadOnly = True
            .Columns("Units").HeaderText = "الوحدة"
            .Columns("Units").ReadOnly = False
            .Columns("Units").DisplayIndex = 10
            .Columns("Stores").HeaderText = "المخزن"
            .Columns("Stores").ReadOnly = False
            .Columns("Stores").DisplayIndex = 11
            .Columns("AddMe").HeaderText = "اضافة/حذف صنف"
            .Columns("AddMe").ReadOnly = False
            .Columns("AddMe").DisplayIndex = 12
        End With
        Dim ItmTotal As Double = 0.0
        For Each Irow As DataGridViewRow In DGReady.Rows
            ItmTotal += Decimal.Parse(Irow.Cells("ItmTotal").Value.ToString)
        Next
        PoVal1 = ItmTotal
        TextBox2.Text = FormatCurrency(PoVal1, 2)
    End Sub
    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        DGReady.Columns.Clear()
        DGReady.DataSource = Nothing
        DisplayPreviewDG()
        MnuSavePO.Enabled = True
    End Sub
    Private Sub MnuSavePO_Click(sender As Object, e As EventArgs) Handles MnuSavePO.Click
        If Tempdt1.Rows.Count <= 0 Then
            MsgBox("عملية غير صحيحة - من فضلك أضف صنف",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Val(TextBox4.Text) <= 0 Then
            MsgBox("عملية غير صحيحة - من فضلك أدخل قيمة فاتورة البيع",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Val(TextBox6.Text) <= 0 And Val(TextBox5.Text) <= 0 Then
            MsgBox("عملية غير صحيحة - من فضلك أدخل قيمة المدفوع أو المتبقي علي العميل",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim OnhSave As Integer = Nothing, OnhSaveT As Integer = Nothing, OnhSaveZ As Integer = Nothing, Saved As Integer = 0
        'INSERT New record in PirOrders Table, and Return its ID Field Value to use it in Purchase Orders Details.
        Dim SqlStrPO As String = "INSERT INTO PurOrders (PODt, CustID, PTID, PONots, TranID, KindID) VALUES (NOW(),?,?,?,?,?);"
        Dim SqlStrPOID As String = "SELECT Max([POID]) AS Expr1 FROM PurOrders WHERE (([PurOrders].[TranID]=?));"

        Using CN As OleDbConnection = New OleDbConnection(connectionstring)
            Dim tra As OleDbTransaction = Nothing
            CN.Open()
            tra = CN.BeginTransaction
            Try
                Using MyCmdStr As New OleDbCommand(SqlStrPO, CN, tra) With {.CommandType = CommandType.Text}
                    With MyCmdStr.Parameters
                        .AddWithValue("?", CInt(ComboBox2.SelectedValue))
                        .AddWithValue("?", CInt(ComboBox1.SelectedValue))
                        .AddWithValue("?", TextBox7.Text)
                        .AddWithValue("?", TransType)
                        .AddWithValue("?", SellTyp)
                    End With
                    'Insert Into PurOrder
                    If MyCmdStr.ExecuteNonQuery = 0 Then
                        MsgBox("عملية غير صحيحة - فاتورة بيع غير موجود")
                        tra.Rollback()
                        Exit Sub
                    End If
                End Using
                Using MyCmdStr1 As New OleDbCommand(SqlStrPOID, CN, tra) With {.CommandType = CommandType.Text}
                    MyCmdStr1.Parameters.AddWithValue("?", TransType)
                    'Get Last PO Number
                    Dim OnhSave1 = MyCmdStr1.ExecuteScalar
                    If IsDBNull(OnhSave1) Then
                        MsgBox("عملية غير صحيحة - فاتورة بيع غير موجود")
                        tra.Rollback()
                        Exit Sub
                    End If
                    Pno1.Text = OnhSave1.ToString
                End Using
                Dim SqlStrUpdt As String = "INSERT INTO PODetails (POID, PID, QntyOut, UnitID, StoreID, SellPrice, PODTotal, TranID) " &
                "VALUES (?,?,?,?,?,?,?,?);"
                For Each Irow As DataGridViewRow In DGReady.Rows
                    Using MyCmdStr2 As New OleDbCommand(SqlStrUpdt, CN, tra) With {.CommandType = CommandType.Text}
                        With MyCmdStr2.Parameters
                            .AddWithValue("?", CInt(Pno1.Text))
                            .AddWithValue("?", CInt(Irow.Cells("PID").Value))
                            .AddWithValue("?", CInt(Irow.Cells("QntyOut").Value))
                            .AddWithValue("?", GetValDic(ComboItemsU, Irow.Cells("Units").Value.ToString))
                            .AddWithValue("?", GetValDic(ComboItemsS, Irow.Cells("Stores").Value.ToString))
                            .AddWithValue("?", CDbl(Irow.Cells("SellPrice").Value))
                            .AddWithValue("?", CDbl(Irow.Cells("ItmTotal").Value))
                            .AddWithValue("?", TransType)
                        End With
                        If MyCmdStr2.ExecuteNonQuery() = 0 Then
                            MsgBox("عملية غير صحيحة - فاتورة بيع غير موجود")
                            Exit Sub
                        End If
                        Saved += 1
                    End Using
                Next
                tra.Commit()
            Catch ex As OleDbException
                MsgBox(ex.Message)
                tra.Rollback()
                Exit Sub
            End Try
        End Using

        If Saved = 0 Or String.IsNullOrEmpty(Pno1.Text) Then Exit Sub
        Dim POSaved As Integer = 0
        Dim POUpdate As String = "UPDATE PurOrders SET POTotal=?, PODisc=?, PONet=?, POPaid=?, PORest=?, PONots=? WHERE POID=?;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
            MyCmdStr3 As New OleDbCommand(POUpdate, CN) With {.CommandType = CommandType.Text}
            With MyCmdStr3.Parameters
                .AddWithValue("?", Decimal.Parse(TextBox2.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Decimal.Parse(TextBox3.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Decimal.Parse(TextBox4.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Decimal.Parse(TextBox6.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", Decimal.Parse(TextBox5.Text, Globalization.NumberStyles.Currency))
                .AddWithValue("?", TextBox7.Text)
                .AddWithValue("?", CInt(Pno1.Text))
            End With
            Try
                CN.Open()
                If MyCmdStr3.ExecuteNonQuery() = 0 Then
                    MsgBox("عملية غير صحيحة - فاتورة بيع غير موجود")
                    Exit Sub
                End If
            Catch ex As OleDbException
                MsgBox("" & ex.Message)
                Exit Sub
            End Try
        End Using
        MsgBox("  تم انشاء فاتورة بيع جديدة و اضافة " & Saved.ToString & " الأصناف لها   ",
               MsgBoxStyle.MsgBoxRtlReading, MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Information)
        NewMnuPO.Enabled = True
        MnuSavePO.Enabled = False
        Label15.Enabled = False
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
    Private Sub MnuSInv_Click(sender As Object, e As EventArgs) Handles MnuSInv.Click
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
        InvPreview.TargetForm = "Sell_PODetails_Prev"
        Dim Onhr, Onhr1 As Integer
        Dim SalInvDrop As String = "DROP VIEW Sell_Ordr_Prev;"
        Dim SalInvCreate As String =
            "CREATE VIEW Sell_Ordr_Prev AS SELECT PurOrders.POID, PurOrders.PODt, Products.BarCode, Customers.CustNm, Products.Pname, Products.Pdesc, " &
            "PODetails.QntyOut, PODetails.SellPrice, PODetails.PODTotal, Units.UnitNm, Stores.StoreNm, PayTypes.PTNm, PurOrders.POTotal, " &
            "PurOrders.PODisc, PurOrders.PONet, PurOrders.POPaid, PurOrders.PORest, PurOrders.PONots, Kinds.KindNm FROM (Units INNER JOIN " &
            "(TranTypes INNER JOIN (Stores INNER JOIN ((PayTypes INNER JOIN (PurOrders INNER JOIN Customers ON PurOrders.CustID = Customers.CustID) " &
            "ON PayTypes.PTID = PurOrders.PTId) INNER JOIN (Products INNER JOIN PODetails ON Products.PID = PODetails.PID) ON PurOrders.POID = " &
            "PODetails.POID) ON Stores.StoreID = PODetails.StoreID) ON (TranTypes.TranID = PurOrders.TranID) And (TranTypes.TranID = PODetails.TranID)) " &
            "ON Units.UnitID = PODetails.UnitID) INNER JOIN Kinds ON PurOrders.KindID = Kinds.KindID GROUP BY PurOrders.POID, PurOrders.PODt, " &
            "Products.BarCode, Customers.CustNm, Products.Pname, Products.Pdesc, PODetails.QntyOut, PODetails.SellPrice, PODetails.PODTotal, " &
            "Units.UnitNm, Stores.StoreNm, PayTypes.PTNm, PurOrders.POTotal, PurOrders.PODisc, PurOrders.PONet, PurOrders.POPaid, PurOrders.PORest, " &
            "PurOrders.PONots, TranTypes.TranID, Kinds.KindNm HAVING (((PurOrders.POID)=" & Pno1.Text & ") AND ((TranTypes.TranID)=2));"
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
    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Close()
    End Sub
    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Location = New Point(0, 0)
        If Height = MainF.Height Then
            Height = MainF.Height / 2
            Exit Sub
        End If
        Height = MainF.Height
    End Sub
    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If ComboBox2.SelectedValue Is Nothing Or
                ComboBox1.SelectedValue Is Nothing Or
                ComboBox3.SelectedValue Is Nothing Then
                MsgBox("عملية عير صحيحة - أضغط F2 أولا لانشاء فاتورة جديدة",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim MyTableMain As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            Dim SqlStr As String =
                "SELECT PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc, Sum(PODetails.QntyIn) AS SumOfQntyIn, " &
                "Sum(PODetails.QntyOut) AS SumOfQntyOut FROM Products INNER JOIN PODetails ON Products.PID = PODetails.PID GROUP BY " &
                "PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc HAVING (((Products.Pname) Like '%' & ? & '%') " &
                "AND ((Sum([QntyIn]-[QntyOut]))>0));"
            Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                MyCmdStr As New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text},
                Da As OleDbDataAdapter = New OleDbDataAdapter(MyCmdStr)
                Da.SelectCommand.Parameters.AddWithValue("?", TextBox8.Text)
                Try
                    CN.Open()
                    Da.Fill(MyTableMain)
                Catch ex As OleDbException
                    MsgBox("Error - Fetching" & vbCrLf & ex.Message)
                    Exit Sub
                End Try
            End Using
            'Don't duplicate items in sell invoice
            Dim row As DataRow = MyTableMain.Select("PID Is Not Null").FirstOrDefault()
            If IsNothing(row) Then Exit Sub
            If Tempdt1.Columns.Count > 0 Then
                Dim MyRow As Integer = MyTableMain(0)("PID")
                For Each IrowFound As DataRow In Tempdt1.Rows
                    'IrowFound(0) = Tempdt1.Select("PID=" & MyRow)
                    If CInt(IrowFound(0)).Equals(MyRow) Then
                        MyTableMain.Rows.RemoveAt(0)
                        Exit Sub
                    End If
                Next
            End If

            'LoadComboPrices(row("PID"))
            LoadComboU()
            LoadComboS()
            LoadComboK()

            With DGReady
                .DataSource = New BindingSource(MyTableMain, Nothing)
                .Columns("PID").Visible = False
                .Columns("SumOfQntyIn").Visible = False
                .Columns("SumOfQntyOut").Visible = False
                .Columns("BarCode").HeaderText = "باركود"
                .Columns("Pname").HeaderText = "اسم الصنف"
                .Columns("Pdesc").HeaderText = "وصف الصنف"
                AddColsToDataTable(MyTableMain)
                .Columns("SellPrice").HeaderText = "سعر البيع"
                .Columns("QntyOut").HeaderText = "الكمية"
                .Columns("Units").HeaderText = "الوحدة"
                .Columns("Units").DisplayIndex = 10
                .Columns("Stores").HeaderText = "المخزن"
                .Columns("Stores").DisplayIndex = 11
                .Columns("AvailQ").HeaderText = "الكمية المتبقية"
                .Columns("ItmTotal").HeaderText = "اجمالي الصنف"
                .Columns("ItmTotal").DisplayIndex = 9
                .Refresh()
            End With
            If Tempdt1.Columns.Count <> DGReady.Columns.Count Then
                For Each column As DataGridViewColumn In DGReady.Columns
                    Tempdt1.Columns.Add(column.Name, column.ValueType)
                Next
            End If
            'Show Last SellPrice
            SellTyp = CInt(ComboBox3.SelectedValue)
            If IsNothing(SellTyp) Or SellTyp = -1 Then
                MsgBox("اختر نوع البيع", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical,
                   "برنامج المشتريات و المبيعات")
                Exit Sub
            End If
            Label21.Visible = True
            Label21.Text = DirectCast(ComboBox3.SelectedItem, KeyValuePair(Of Integer, String)).Value
            ComboBox3.Visible = False
            If DGReady.Rows.Count <= 0 Or DGReady.CurrentCell Is Nothing Then Exit Sub
            Dim LastBuyPrice As Decimal
            If DGReady.Rows.Count >= 1 Then
                For Each Irow As DataGridViewRow In DGReady.Rows
                    Dim SqlStrSellLastP As String =
                "SELECT Last(SellPriceGrps.GSellPrice) AS LastOfGSellPrice FROM (PurOrders INNER JOIN Kinds ON PurOrders.KindID = Kinds.KindID) " &
                "INNER JOIN (PODetails INNER JOIN SellPriceGrps ON PODetails.PID = SellPriceGrps.PID) ON PurOrders.POID = PODetails.POID GROUP BY " &
                "PODetails.PID, PurOrders.CustID, PurOrders.KindID HAVING (((PODetails.PID)=?) AND ((PurOrders.CustID)=?) AND ((PurOrders.KindID)=?));"
                    Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                MyCmdStr As New OleDbCommand(SqlStrSellLastP, CN) With {.CommandType = CommandType.Text}
                        MyCmdStr.Parameters.AddWithValue("?", CInt(DGReady("PID", Irow.Index).Value.ToString))
                        MyCmdStr.Parameters.AddWithValue("?", CInt(ComboBox2.SelectedValue))
                        MyCmdStr.Parameters.AddWithValue("?", CInt(ComboBox3.SelectedValue))
                        Try
                            CN.Open()
                            Using Readr As OleDbDataReader = MyCmdStr.ExecuteReader
                                If Readr.HasRows Then
                                    While Readr.Read
                                        LastBuyPrice = Readr.GetDecimal(0)
                                    End While
                                Else
                                    LastBuyPrice = 0
                                End If
                            End Using
                            DGReady("SellPrice", Irow.Index).Value = LastBuyPrice
                        Catch ex As OleDbException
                            MsgBox("Error - Fetching Price" & vbCrLf & ex.Message)
                            Exit Sub
                        End Try
                    End Using
                Next
            End If
        End If
    End Sub
    Private Sub AddColsToDataTable(ByVal MyTableMain As DataTable)
        If Not MyTableMain.Columns.Contains("SellPrice") Then
            Dim Icol2 As DataColumn = New DataColumn With {
                .ColumnName = "SellPrice", .DataType = GetType(Decimal), .[ReadOnly] = False, .DefaultValue = 0
            }
            MyTableMain.Columns.Add(Icol2)
        End If
        If Not MyTableMain.Columns.Contains("QntyOut") Then
            Dim Icol1 As DataColumn = New DataColumn With {
                .ColumnName = "QntyOut", .DataType = GetType(Integer), .[ReadOnly] = False, .DefaultValue = 0
            }
            MyTableMain.Columns.Add(Icol1)
        End If
        If Not MyTableMain.Columns.Contains("AvailQ") Then
            Dim Icol As DataColumn = New DataColumn With {
                .ColumnName = "AvailQ", .DataType = GetType(Integer), .[ReadOnly] = False, .DefaultValue = 0,
            .Expression = "SumOfQntyIn-SumOfQntyOut"}
            MyTableMain.Columns.Add(Icol)
        End If
        If Not MyTableMain.Columns.Contains("ItmTotal") Then
            Dim Icol3 As DataColumn = New DataColumn With {
                .ColumnName = "ItmTotal", .DataType = GetType(Decimal), .[ReadOnly] = True, .DefaultValue = 0,
                .Expression = "QntyOut*SellPrice"}
            MyTableMain.Columns.Add(Icol3)
        End If
        If DGReady.Columns.Contains("Units") Then DGReady.Columns.Remove("Units")
        Dim IcolU As New DataGridViewComboBoxColumn With {
                .Name = "Units", .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton, .ValueType = GetType(String),
                .[ReadOnly] = False, .HeaderText = "نوع البيع", .DisplayMember = "Value", .ValueMember = "Key", .DisplayIndex = 11,
                .DataSource = New BindingSource(ComboItemsU, Nothing)
            }
        DGReady.Columns.Add(IcolU)

        If DGReady.Columns.Contains("Stores") Then DGReady.Columns.Remove("Stores")
        Dim IcolS As New DataGridViewComboBoxColumn With {
                .Name = "Stores", .DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton, .ValueType = GetType(String),
                .[ReadOnly] = False, .HeaderText = "نوع البيع", .DisplayMember = "Value", .ValueMember = "Key", .DisplayIndex = 12,
                .DataSource = New BindingSource(ComboItemsS, Nothing)
            }
        DGReady.Columns.Add(IcolS)

        If DGReady.Columns.Contains("AddMe") Then DGReady.Columns.Remove("AddMe")
        Dim Icol4 As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn With {
                .Name = "AddMe", .HeaderText = "أضافة/حذف للفاتورة", .ValueType = GetType(CheckState), .FalseValue = CheckState.Unchecked,
                .TrueValue = CheckState.Checked, .ThreeState = False, .[ReadOnly] = False, .Visible = True, .IndeterminateValue = False,
                .DisplayIndex = 13
            }
        DGReady.Columns.Add(Icol4)
    End Sub
    Private Sub SalesOrders_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Label24.Text = ComboBox2.Text
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Or WindowState = FormWindowState.Normal Then
            Size = New Size(800, 35)
            Exit Sub
        End If
    End Sub
    Private Sub SalesOrders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler DGReady.CellFormatting, AddressOf DGReady_CellFormatting
        RemoveHandler DGReady.DataError, AddressOf DGReady_DataError
        RemoveHandler DGReady.CurrentCellDirtyStateChanged, AddressOf DGready_CurrentCellDirtyStateChanged
        RemoveHandler DGReady.EditingControlShowing, AddressOf DGReady_EditingControlShowing
        RemoveHandler DGReady.CellBeginEdit, AddressOf DGReady_CellBeginEdit
    End Sub
    Private Sub SalesOrders_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Call Label15_Click(sender, e)
        End If
    End Sub
    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        Label21.Visible = False
        ComboBox3.Visible = True
    End Sub
    Private Sub ComboBox3_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox3.SelectionChangeCommitted
        SellTyp = CInt(ComboBox3.SelectedValue)
        If IsNothing(SellTyp) Or SellTyp = -1 Then
            MsgBox("اختر نوع البيع", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical,
                   "برنامج المشتريات و المبيعات")
            Exit Sub
        End If
        Label21.Visible = True
        Label21.Text = DirectCast(ComboBox3.SelectedItem, KeyValuePair(Of Integer, String)).Value
        ComboBox3.Visible = False
        If DGReady.Rows.Count <= 0 Or DGReady.CurrentCell Is Nothing Then Exit Sub
        Dim LastBuyPrice, LastSellPrice As Decimal
        If DGReady.Rows.Count >= 1 Then
            For Each Irow As DataGridViewRow In DGReady.Rows
                Dim SqlStrSellLastP As String =
                "SELECT Last(SellPriceGrps.GSellPrice) AS LastOfGSellPrice, Last(PODetails.SellPrice) AS LastOfSellPrice FROM PODetails INNER JOIN " &
                "SellPriceGrps ON PODetails.PID = SellPriceGrps.PID GROUP BY PODetails.PID, SellPriceGrps.KindID HAVING (((PODetails.PID)=?) AND " &
                "((SellPriceGrps.KindID)=?));"
                Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                MyCmdStr As New OleDbCommand(SqlStrSellLastP, CN) With {.CommandType = CommandType.Text}
                    MyCmdStr.Parameters.AddWithValue("?", CInt(DGReady("PID", Irow.Index).Value.ToString))
                    MyCmdStr.Parameters.AddWithValue("?", ComboBox3.SelectedValue)
                    Try
                        CN.Open()
                        Using Readr As OleDbDataReader = MyCmdStr.ExecuteReader
                            If Readr.HasRows Then
                                While Readr.Read
                                    LastBuyPrice = Readr.GetDecimal(0)
                                    LastSellPrice = Readr.GetDecimal(1)
                                End While
                            Else
                                LastBuyPrice = 0
                                LastSellPrice = 0
                            End If
                        End Using
                        DGReady.CurrentCell = DGReady("SellPrice", Irow.Index)
                        DGReady.BeginEdit(True)
                        If LastSellPrice = 0 Then
                            DGReady("SellPrice", Irow.Index).Value = LastBuyPrice
                            Label23.Text = FormatCurrency(LastSellPrice, 2)
                        Else
                            DGReady("SellPrice", Irow.Index).Value = LastSellPrice
                            Label22.Text = "سعر البيع " + ComboBox3.Text
                            Label23.Text = FormatCurrency(LastBuyPrice, 2)
                        End If
                        DGReady.EndEdit()
                    Catch ex As OleDbException
                        MsgBox("Error - Fetching Price" & vbCrLf & ex.Message)
                        Exit Sub
                    End Try
                End Using
            Next
        End If
    End Sub
    Private Sub ComboBox2_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox2.SelectionChangeCommitted
        If IsNothing(ComboBox2.SelectedValue) Or ComboBox2.Items.Count <= 0 Then
            MsgBox("اختر العميل", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical,
                   "برنامج المشتريات و المبيعات")
            Exit Sub
        End If
        CustID = CInt(ComboBox2.SelectedValue.ToString)
        Label19.Visible = True
        Label19.Text = DirectCast(ComboBox2.SelectedItem, KeyValuePair(Of Integer, String)).Value
        Label24.Text = ComboBox2.Text
        ComboBox2.Visible = False
    End Sub
    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        Label19.Visible = False
        ComboBox2.Visible = True
    End Sub
    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBox1.SelectionChangeCommitted
        If IsNothing(ComboBox1.SelectedValue) Or ComboBox1.Items.Count <= 0 Then
            MsgBox("اختر طريقة الدفع", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical,
                   "برنامج المشتريات و المبيعات")
            Exit Sub
        End If
        PayTyp = CInt(ComboBox1.SelectedValue)
        Label20.Visible = True
        Label20.Text = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of Integer, String)).Value
        ComboBox1.Visible = False
    End Sub
    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click
        Label20.Visible = False
        ComboBox1.Visible = True
    End Sub
    Private Sub Pno1_DoubleClick(sender As Object, e As EventArgs) Handles Pno1.DoubleClick
        Pno1.ReadOnly = False
    End Sub
End Class