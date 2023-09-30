Imports System.Data.OleDb
Public Class MyStore
    Private Ops As New DataOperations
    Private ConnectionString = Ops.GetEncryConStr
    Private WithEvents DGStores As DataGridView
    Private Function GetData(ByVal query As String) As DataTable
        Dim NewDtbl As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
        Try
            Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                MyCmdStr As New OleDbCommand(query, CN) With {.CommandType = CommandType.Text}
                CN.Open()
                Using Da As OleDbDataAdapter = New OleDbDataAdapter(MyCmdStr)
                    Da.Fill(NewDtbl)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return NewDtbl
    End Function
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Location = New Point(0, 0)
        If Height <> MainF.Height / 2 Then
            WindowState = FormWindowState.Normal
            Height = MainF.Height / 2
            Width = MainF.Width
        End If
    End Sub
    Private Sub MyStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Dim Onh3 As Object
        Dim SqlStr4 As String =
            "SELECT Sum(PurOrders.POTotal) AS SumOfPOTotal FROM PurOrders GROUP BY PurOrders.TranID HAVING (((PurOrders.TranID)=1));"
        Using CN12 As OleDbConnection = New OleDbConnection(connectionstring),
                        CMDTotal As OleDbCommand = New OleDbCommand(SqlStr4, CN12) With {.CommandType = CommandType.Text}
            CN12.Open()
            Try
                Onh3 = CInt(CMDTotal.ExecuteScalar)
            Catch ex As OleDbException
                Onh3 = 0
            End Try
        End Using
        TextBox2.Text = FormatCurrency(Onh3.ToString, 2)
        Application.DoEvents()
        DGStores = New DataGridView With
        {
        .Name = "DGStores",
        .AllowUserToAddRows = False,
        .EnableHeadersVisualStyles = False,
        .AllowUserToDeleteRows = False,
        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        .Dock = DockStyle.Fill,
        .[ReadOnly] = True,
        .RowHeadersWidth = 20
            }
        AddHandler DGStores.CellContentClick, AddressOf DGStores_CellContentClick
        AddHandler DGStores.CellFormatting, AddressOf DGStores_CellFormatting
    End Sub
    Private Sub DGStores_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If DGStores.Columns(e.ColumnIndex).Name = "LastOfPBuyPrice" Or
            DGStores.Columns(e.ColumnIndex).Name = "LastOfSellPrice" And IsNumeric(e.Value) Then
            e.Value = FormatCurrency(e.Value, 2)
        End If
    End Sub
    Private Sub DGStores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            Dim ItmID As Integer = DGStores("PID", e.RowIndex).Value
            StoresRPT.StoreItm = "ItmCard"
            Dim Onh1, Onh2 As Object
            Dim SqlStr1 As String =
            "CREATE VIEW AllItmSell AS SELECT Products.Pname, Products.Pdesc, PayTypes.PTNm, Customers.CustNm, PODetails.QntyOut, " &
            "PODetails.SellPrice, PODetails.PODTotal, Stores.StoreNm, Units.UnitNm, PODetails.PID, PurOrders.TranID, PODetails.POID, " &
            "PurOrders.PODt FROM Units INNER JOIN (TranTypes INNER JOIN (Stores INNER JOIN ((PayTypes INNER JOIN (Customers INNER " &
            "JOIN PurOrders ON Customers.CustID = PurOrders.CustID) ON PayTypes.PTID = PurOrders.PTId) INNER JOIN ((Kinds INNER JOIN " &
            "(SellPriceGrps INNER JOIN Products ON SellPriceGrps.PID = Products.PID) ON Kinds.KindID = SellPriceGrps.KindID) INNER " &
            "JOIN PODetails ON Products.PID = PODetails.PID) ON PurOrders.POID = PODetails.POID) ON Stores.StoreID = PODetails.StoreID) " &
            "ON TranTypes.TranID = PODetails.TranID) ON Units.UnitID = PODetails.UnitID GROUP BY Products.Pname, Products.Pdesc, " &
            "PayTypes.PTNm, Customers.CustNm, PODetails.QntyOut, PODetails.SellPrice, PODetails.PODTotal, Stores.StoreNm, Units.UnitNm, " &
            "PODetails.PID, PurOrders.TranID, PODetails.POID, PurOrders.PODt HAVING (((PODetails.PID)=" & ItmID & ") AND " &
            "((PurOrders.TranID)=2));"
            Using CN12 As OleDbConnection = New OleDbConnection(connectionstring),
            CMDStrStore As OleDbCommand = New OleDbCommand("DROP VIEW AllItmSell;", CN12) With {.CommandType = CommandType.Text},
            CMDStrStore1 As OleDbCommand = New OleDbCommand(SqlStr1, CN12) With {.CommandType = CommandType.Text}
                Try
                    ' CN12.Open()
                    '  Onh1 = CMDStrStore.ExecuteNonQuery
                    '  Onh2 = CMDStrStore1.ExecuteNonQuery
                Catch ex As OleDbException
                    '  Onh2 = CMDStrStore1.ExecuteNonQuery
                Finally
                    'CN12.Close()
                End Try
            End Using

            Dim SqlStr2 As String =
            "CREATE VIEW AllItmBuy AS SELECT Products.Pname, Products.Pdesc, PayTypes.PTNm, PODetails.QntyIn, PODetails.PBuyPrice, " &
            "PODetails.PODTotal, Stores.StoreNm, Units.UnitNm, Vendors.VendNm, PODetails.PID, PurOrders.TranID, PODetails.POID, " &
            "PurOrders.PODt FROM Units INNER JOIN (TranTypes INNER JOIN (Stores INNER JOIN ((PayTypes INNER JOIN (PurOrders INNER " &
            "JOIN Vendors ON PurOrders.VenID = Vendors.VenID) ON PayTypes.PTID = PurOrders.PTId) INNER JOIN (Products INNER JOIN " &
            "PODetails ON Products.PID = PODetails.PID) ON PurOrders.POID = PODetails.POID) ON Stores.StoreID = PODetails.StoreID) " &
            "ON TranTypes.TranID = PODetails.TranID) ON Units.UnitID = PODetails.UnitID GROUP BY Products.Pname, Products.Pdesc, " &
            "PayTypes.PTNm, PODetails.QntyIn, PODetails.PBuyPrice, PODetails.PODTotal, Stores.StoreNm, Units.UnitNm, Vendors.VendNm, " &
            "PODetails.PID, PurOrders.TranID, PODetails.POID, PurOrders.PODt HAVING (((PODetails.PID)=" & ItmID & ") AND " &
            "((PurOrders.TranID)=1));"
            Using CN12 As OleDbConnection = New OleDbConnection(connectionstring),
            CMDStrStore3 As OleDbCommand = New OleDbCommand("DROP VIEW AllItmBuy;", CN12) With {.CommandType = CommandType.Text},
            CMDStrStore4 As OleDbCommand = New OleDbCommand(SqlStr2, CN12) With {.CommandType = CommandType.Text}
                Try
                    ' CN12.Open()
                    ' Onh1 = CMDStrStore3.ExecuteNonQuery
                    'Onh2 = CMDStrStore4.ExecuteNonQuery
                Catch ex As OleDbException
                    'Onh2 = CMDStrStore4.ExecuteNonQuery
                Finally
                    ' CN12.Close()
                End Try
            End Using
            'Application.DoEvents()
            Dim SqlStr3 As String =
            "CREATE VIEW ThisItemCard AS SELECT PurOrders.POID, PurOrders.PODt, PODetails.PODID, Products.BarCode, Products.Pname, Products.Pdesc, " &
            "TranTypes.TranNm, Kinds.KindNm, PayTypes.PTNm, Stores.StoreNm, Units.UnitNm, PODetails.PBuyPrice, PODetails.SellPrice, PODetails.QntyIn, " &
            "PODetails.QntyOut, [QntyIn]-[QntyoUT] AS AvailQ, [PBuyPrice]*[QntyIn] AS BuyTotal, [SellPrice]*[QntyOut] AS SellTotal, Customers.CustNm, " &
            "Vendors.VendNm FROM Units INNER JOIN (TranTypes INNER JOIN (Stores INNER JOIN ((PayTypes INNER JOIN (((PurOrders LEFT JOIN Kinds ON " &
            "PurOrders.KindID = Kinds.KindID) LEFT JOIN Customers ON PurOrders.CustID = Customers.CustID) LEFT JOIN Vendors ON PurOrders.VenID = " &
            "Vendors.VenID) ON PayTypes.PTID = PurOrders.PTId) INNER JOIN (Products INNER JOIN PODetails ON Products.PID = PODetails.PID) ON " &
            "PurOrders.POID = PODetails.POID) ON Stores.StoreID = PODetails.StoreID) ON TranTypes.TranID = PODetails.TranID) ON Units.UnitID = " &
            "PODetails.UnitID GROUP BY PurOrders.POID, PurOrders.PODt, PODetails.PODID, Products.BarCode, Products.Pname, Products.Pdesc, " &
            "TranTypes.TranNm, Kinds.KindNm, PayTypes.PTNm, Stores.StoreNm, Units.UnitNm, PODetails.PBuyPrice, PODetails.SellPrice, PODetails.QntyIn, " &
            "PODetails.QntyOut, [QntyIn]-[QntyoUT], [PBuyPrice]*[QntyIn], [SellPrice]*[QntyOut], Customers.CustNm, Vendors.VendNm, Products.PID " &
            "HAVING (((Products.PID)=" & ItmID & "));"
            Using CN12 As OleDbConnection = New OleDbConnection(connectionstring),
            CMDStrStore5 As OleDbCommand = New OleDbCommand("DROP VIEW ThisItemCard;", CN12) With {.CommandType = CommandType.Text},
            CMDStrStore6 As OleDbCommand = New OleDbCommand(SqlStr3, CN12) With {.CommandType = CommandType.Text}
                Try
                    CN12.Open()
                    Onh1 = CMDStrStore5.ExecuteNonQuery
                    Onh2 = CMDStrStore6.ExecuteNonQuery
                Catch ex As OleDbException
                    Onh2 = CMDStrStore6.ExecuteNonQuery
                Finally
                    CN12.Close()
                End Try
            End Using
            StoresRPT.ShowDialog()
        End If
    End Sub
    Private Sub MyStore_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Close()
    End Sub
    Private Sub MnuUpdt_Click(sender As Object, e As EventArgs) Handles MnuUpdt.Click
        Dim Onh1, Onh2 As Object
        Dim SqlStr3 As String =
            "CREATE VIEW StrStore AS SELECT PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc, Sum(PODetails.QntyIn) " &
            "AS SumOfQntyIn, Sum(PODetails.QntyOut) AS SumOfQntyOut, Last(PODetails.PBuyPrice) AS LastOfPBuyPrice, Last(Products.MinQ) " &
            "AS LastOfMinQ, Last(Units.UnitNm) AS LastOfUnitNm, Last(Stores.StoreNm) AS LastOfStoreNm, Last(PurOrders.PODt) AS LastOfPODt " &
            "FROM Units INNER JOIN (Stores INNER JOIN (PurOrders INNER JOIN (Products INNER JOIN PODetails ON Products.PID = PODetails.PID) " &
            "ON PurOrders.POID = PODetails.POID) ON Stores.StoreID = PODetails.StoreID) ON Units.UnitID = PODetails.UnitID GROUP BY " &
            "PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc;"
        Using CN12 As OleDbConnection = New OleDbConnection(connectionstring),
            CMDStrStore As OleDbCommand = New OleDbCommand("DROP VIEW StrStore;", CN12) With {.CommandType = CommandType.Text},
            CMDStrStore1 As OleDbCommand = New OleDbCommand(SqlStr3, CN12) With {.CommandType = CommandType.Text}
            Try
                CN12.Open()
                Onh1 = CMDStrStore.ExecuteNonQuery
                Onh2 = CMDStrStore1.ExecuteNonQuery
            Catch ex As OleDbException
                Onh2 = CMDStrStore1.ExecuteNonQuery
            End Try
        End Using
        Dim NewDataTbl As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
        NewDataTbl = GetData("SELECT * FROM StrStore;")
        Dim Icol As DataColumn = New DataColumn With {
            .AllowDBNull = False, .ColumnName = "الكمية المتاحة", .DataType = GetType(Integer), .DefaultValue = 0
        }
        If NewDataTbl.Columns.Contains(Icol.ToString) Then
            NewDataTbl.Columns.Remove(Icol)
        End If
        Icol.Expression = ("SumOfQntyIn-SumOfQntyOut")
        Icol.ReadOnly = True

        If NewDataTbl.Columns.Contains(Icol.ToString) Then
            NewDataTbl.Columns.Remove(Icol)
        End If
        Icol.Expression = ("SumOfQntyIn-SumOfQntyOut")
        Icol.ReadOnly = True

        NewDataTbl.Columns.Add(Icol)
        With DGStores
            .BackgroundColor = Color.Moccasin
            .ColumnHeadersDefaultCellStyle.BackColor = Color.OrangeRed
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .RowsDefaultCellStyle.Font = New Font("Times New Roman", 10.25)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
            .DataSource = New BindingSource(NewDataTbl, Nothing)
            For Each Ctrl As Control In GroupBox1.Controls
                If TypeOf Ctrl Is DataGridView Then
                    GroupBox1.Controls.Remove(Ctrl)
                End If
            Next
            GroupBox1.Controls.Add(DGStores)
            .Columns("PID").Visible = False
            .Columns("BarCode").HeaderText = "باركود"
            .Columns("Pname").HeaderText = "الصنف"
            .Columns("Pdesc").HeaderText = "الوصف"
            .Columns("SumOfQntyIn").HeaderText = "اجمالي الشراء"
            .Columns("SumOfQntyOut").HeaderText = "اجمالي البيع"
            .Columns("LastOfPBuyPrice").HeaderText = "اخر سعر شراء"
            .Columns("LastOfMinQ").HeaderText = "أقل كمية مسموح بها"
            .Columns("LastOfUnitNm").HeaderText = "الوحده"
            .Columns("LastOfStoreNm").HeaderText = "المخزن"
            .Columns("LastOfPODt").HeaderText = "اخر عملية اضافة"
            If .Columns.Contains("Btn1") Then .Columns.Remove("Btn1")
            .Columns.Add(New DataGridViewButtonColumn With {.DisplayIndex = NewDataTbl.Columns.Count,
                         .HeaderText = "بطاقة الصنف", .Name = "Btn1", .[ReadOnly] = False,
                         .Text = "عرض", .UseColumnTextForButtonValue = True})
            .Refresh()
        End With
        TextBox1.Text = DGStores.Rows.Count.ToString
    End Sub
    Private Sub MenuStrip2_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub ItmSrch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ItmSrch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(ItmSrch.Text) Or String.IsNullOrWhiteSpace(ItmSrch.Text) Then Exit Sub
            Dim SqlStr3 As String =
                "SELECT PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc, Sum(PODetails.QntyIn) " &
                "AS SumOfQntyIn, Sum(PODetails.QntyOut) AS SumOfQntyOut, Last(PODetails.PBuyPrice) AS LastOfPBuyPrice, Last(Products.MinQ) " &
                "AS LastOfMinQ, Last(Units.UnitNm) AS LastOfUnitNm, Last(Stores.StoreNm) AS LastOfStoreNm, Last(PurOrders.PODt) AS LastOfPODt " &
                "FROM Units INNER JOIN (Stores INNER JOIN (PurOrders INNER JOIN (Products INNER JOIN PODetails ON Products.PID = PODetails.PID) " &
                "ON PurOrders.POID = PODetails.POID) ON Stores.StoreID = PODetails.StoreID) ON Units.UnitID = PODetails.UnitID GROUP BY " &
                "PODetails.PID, Products.BarCode, Products.Pname, Products.Pdesc HAVING " &
                "Pname Like '%" & ItmSrch.Text & "%' OR Pdesc LIKE '%" & ItmSrch.Text & "%';"
            Dim NewDataTbl As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            NewDataTbl = GetData(SqlStr3)
            Dim Icol As DataColumn = New DataColumn With {
                .AllowDBNull = False, .ColumnName = "الكمية المتاحة", .DataType = GetType(Integer), .DefaultValue = 0
            }
            If NewDataTbl.Columns.Contains(Icol.ToString) Then
                NewDataTbl.Columns.Remove(Icol)
            End If
            Icol.Expression = ("SumOfQntyIn-SumOfQntyOut")
            Icol.ReadOnly = True

            If NewDataTbl.Columns.Contains(Icol.ToString) Then
                NewDataTbl.Columns.Remove(Icol)
            End If
            Icol.Expression = ("SumOfQntyIn-SumOfQntyOut")
            Icol.ReadOnly = True

            NewDataTbl.Columns.Add(Icol)
            With DGStores
                .BackgroundColor = Color.Moccasin
                .ColumnHeadersDefaultCellStyle.BackColor = Color.OrangeRed
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                .RowsDefaultCellStyle.Font = New Font("Times New Roman", 10.25)
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque
                .DataSource = New BindingSource(NewDataTbl, Nothing)
                For Each Ctrl As Control In GroupBox1.Controls
                    If TypeOf Ctrl Is DataGridView Then
                        GroupBox1.Controls.Remove(Ctrl)
                    End If
                Next
                GroupBox1.Controls.Add(DGStores)
                .Columns("PID").Visible = False
                .Columns("BarCode").HeaderText = "باركود"
                .Columns("Pname").HeaderText = "الصنف"
                .Columns("Pdesc").HeaderText = "الوصف"
                .Columns("SumOfQntyIn").HeaderText = "اجمالي الشراء"
                .Columns("SumOfQntyOut").HeaderText = "اجمالي البيع"
                .Columns("LastOfPBuyPrice").HeaderText = "اخر سعر شراء"
                .Columns("LastOfMinQ").HeaderText = "أقل كمية مسموح بها"
                .Columns("LastOfUnitNm").HeaderText = "الوحده"
                .Columns("LastOfStoreNm").HeaderText = "المخزن"
                .Columns("LastOfPODt").HeaderText = "اخر عملية اضافة"
                If .Columns.Contains("Btn1") Then .Columns.Remove("Btn1")
                .Columns.Add(New DataGridViewButtonColumn With {.DisplayIndex = NewDataTbl.Columns.Count,
                             .HeaderText = "بطاقة الصنف", .Name = "Btn1", .[ReadOnly] = False,
                             .Text = "عرض", .UseColumnTextForButtonValue = True})
                .Refresh()
            End With
        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class