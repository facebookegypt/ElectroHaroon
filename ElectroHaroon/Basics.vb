Imports System.Data.OleDb
Public Class Basics
    Public TargetForm As String = Nothing
    Sub GetData(ByVal SqlStr As String, ByVal DG As DataGridView)
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        With DG
            .EnableHeadersVisualStyles = False
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .ReadOnly = True
            .RightToLeft = RightToLeft.Inherit
            .RowsDefaultCellStyle.ForeColor = Color.Black
            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowsDefaultCellStyle.Font = New Font("Arial Black", 8.25, FontStyle.Regular)
            .RowHeadersWidth = 30
            .RowHeadersDefaultCellStyle.BackColor = Color.DarkSlateGray
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Silver
            .ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True
            .ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 13.25, FontStyle.Bold)
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        End With
        Try
            Dim NewDtbl As DataTable = New DataTable With {.Locale = Globalization.CultureInfo.InvariantCulture}
            Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                MyCmdStr As New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
                CN.Open()
                Using Da As OleDbDataAdapter = New OleDbDataAdapter(MyCmdStr)
                    Da.Fill(NewDtbl)
                End Using
            End Using
            With DG
                .DataSource = NewDtbl
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Basics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KeyPreview = True
        Select Case TargetForm
            Case Is = "Units"
                Label2.Text = "اعدادات الوحدات"
                Label1.Text = "اسم الوحدة"
                GetData("SELECT * FROM Units ORDER BY UnitNm ASC;", DataGridView1)
            Case Is = "Stores"
                Label2.Text = "اعدادات المخازن"
                Label1.Text = "اسم المخزن"
                GetData("SELECT * FROM Stores ORDER BY StoreNm ASC;", DataGridView1)
            Case Is = "Kinds"
                Label2.Text = "اعدادات الأنواع"
                Label1.Text = "اسم النوع"
                GetData("SELECT * FROM Kinds ORDER BY KindNm ASC;", DataGridView1)
            Case Is = "PayTypes"
                Label2.Text = "اعدادات طرق الدفع"
                Label1.Text = "اسم الطريقة"
                GetData("SELECT * FROM PayTypes ORDER BY PTNm ASC;", DataGridView1)
        End Select
        With DataGridView1
            .Columns(0).HeaderText = "كود"
            .Columns(1).HeaderText = Label1.Text
        End With
        NewRun()
    End Sub
    Private Sub Basics_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then Close()
    End Sub
    Private Sub Basics_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Control Then
            e.Handled = True
            Button1.PerformClick()
        ElseIf e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control Then
            e.Handled = True
            Button2.PerformClick()
        ElseIf e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control Then
            e.Handled = True
            Button3.PerformClick()
        ElseIf e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Control Then
            e.Handled = True
            Button4.PerformClick()
        ElseIf e.KeyCode = Keys.Delete Then
            e.Handled = True
            Button5.PerformClick()
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
        TextBox1.Focus()
    End Sub
    Sub NewRun()
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
        TextBox1.Focus()
    End Sub
    Private Sub Label2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Save
        If String.IsNullOrEmpty(TextBox1.Text) Or
                String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MsgBox("عملية غير صحيحة - الاسم مطلوب", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim Nm As String = TextBox1.Text, Onh As Integer = Nothing, SqlStr As String = Nothing, SqlStrDisp As String = Nothing
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString)
            Dim CmdSave As OleDbCommand
            Select Case Label1.Text
                Case Is = "اسم الوحدة"
                    SqlStr = "INSERT INTO Units (UnitNm) VALUES (?);"
                    SqlStrDisp = "SELECT * FROM Units ORDER BY UnitID DESC;"
                Case Is = "اسم النوع"
                    SqlStr = "INSERT INTO Kinds (KindNm) VALUES (?);"
                    SqlStrDisp = "SELECT * FROM Kinds ORDER BY KindID DESC;"
                    If DataGridView1.Rows.Count >= 3 Then Exit Select : Exit Sub
                Case Is = "اسم المخزن"
                    SqlStr = "INSERT INTO Stores (StoreNm) VALUES (?);"
                    SqlStrDisp = "SELECT * FROM Stores ORDER BY StoreID DESC;"
                Case Is = "اسم الطريقة"
                    SqlStr = "INSERT INTO PayTypes (PTNm) VALUES (?);"
                    SqlStrDisp = "SELECT * FROM PayTypes ORDER BY PTID DESC;"
            End Select
            CmdSave = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            With CmdSave.Parameters
                .AddWithValue("?", Nm)
            End With
            Try
                CN.Open()
                Onh = CmdSave.ExecuteNonQuery
                If IsNothing(Onh) Or Onh = 0 Then
                    MsgBox("مشكلة فى حفظ " & Label1.Text)
                    Exit Sub
                End If
            Catch ex As OleDbException
                MsgBox("مشكلة فى حفظ " & Label1.Text & ex.Message)
                Exit Sub
            End Try
        End Using
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
        MsgBox("عملية ناجحه", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Information)
        GetData(SqlStrDisp, DataGridView1)
        With DataGridView1
            .Columns(0).HeaderText = "كود"
            .Columns(1).HeaderText = Label1.Text
        End With
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Search
        If String.IsNullOrEmpty(TextBox1.Text) Or
                String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MsgBox("أدخل اسم الصنف فى خانه الاسم و اضغط 'بحث' أو Ctrl+F", MsgBoxStyle.MsgBoxRtlReading +
                   MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim Nm As String = TextBox1.Text, SqlStr As String = Nothing
        Select Case Label1.Text
            Case Is = "اسم الوحدة"
                SqlStr = "SELECT * FROM Units WHERE Units.UnitNm LIKE '%" & Nm & "%';"
            Case Is = "اسم النوع"
                SqlStr = "SELECT * FROM Kinds WHERE Kinds.KindNm LIKE '%" & Nm & "%';"
            Case Is = "اسم المخزن"
                SqlStr = "SELECT * FROM Stores WHERE Stores.StoreNm LIKE '%" & Nm & "%';"
            Case Is = "اسم الطريقه"
                SqlStr = "SELECT * FROM PayTypes WHERE PayTypes.PTNm LIKE '%" & Nm & "%';"
        End Select
        GetData(SqlStr, DataGridView1)
        With DataGridView1
            .Columns(0).HeaderText = "كود"
            .Columns(1).HeaderText = Label1.Text
        End With
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Edit
        If String.IsNullOrEmpty(TextBox1.Text) Or
                String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
                IsNothing(DataGridView1.CurrentCell) Then
            MsgBox("اضغط علي الصنف المراد تعديله - قم بتعديله - اضغط 'تعديل'", MsgBoxStyle.MsgBoxRtlReading +
                   MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim Nm As String = TextBox1.Text, Onh As Integer = Nothing,
            SqlStr As String = Nothing, SqlStrDisp As String = Nothing, ThisID As Integer =
            DataGridView1(0, DataGridView1.CurrentCell.RowIndex).Value
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(connectionstring)
            Dim CmdEdit As OleDbCommand
            Select Case Label1.Text
                Case Is = "اسم الوحدة"
                    SqlStr = "UPDATE Units SET UnitNm=? WHERE UnitID=?;"
                    SqlStrDisp = "SELECT * FROM Units ORDER BY UnitID DESC;"
                Case Is = "اسم النوع"
                    SqlStr = "UPDATE Kinds SET KindNm=? WHERE KindID=?;"
                    SqlStrDisp = "SELECT * FROM Kinds ORDER BY KindID DESC;"
                Case Is = "اسم المخزن"
                    SqlStr = "UPDATE Stores SET StoreNm=? WHERE StoreID=?;"
                    SqlStrDisp = "SELECT * FROM Stores ORDER BY StoreID DESC;"
                Case Is = "اسم الطريقة"
                    SqlStr = "UPDATE PayTypes SET PTNm=? WHERE PTID=?;"
                    SqlStrDisp = "SELECT * FROM PayTypes ORDER BY PTID DESC;"
            End Select
            CmdEdit = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            With CmdEdit.Parameters
                .AddWithValue("?", Nm)
                .AddWithValue("?", ThisID)
            End With
            Try
                CN.Open()
                Onh = CmdEdit.ExecuteNonQuery
                If IsNothing(Onh) Or Onh = 0 Then
                    MsgBox("مشكلة فى التعديل " & Label1.Text)
                    Exit Sub
                End If
            Catch ex As OleDbException
                MsgBox("مشكلة فى التعديل " & Label1.Text & ex.Message)
                Exit Sub
            End Try
        End Using
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
        MsgBox("عملية ناجحه", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Information)
        GetData(SqlStrDisp, DataGridView1)
        With DataGridView1
            .Columns(0).HeaderText = "كود"
            .Columns(1).HeaderText = Label1.Text
        End With
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Delete
        If DataGridView1.Rows.Count < 0 Or IsNothing(DataGridView1.CurrentCell) Then
            MsgBox("يجب اختيار كود أولا", MsgBoxStyle.MsgBoxRtlReading +
                   MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical)
            TextBox1.Focus()
            Exit Sub
        End If
        Dim Nm As String = TextBox1.Text, Onh As Integer = Nothing, SqlCheck As String = Nothing,
        SqlStr As String = Nothing, SqlStrDisp As String = Nothing, ThisID As Integer =
            DataGridView1(0, DataGridView1.CurrentCell.RowIndex).Value, Onh1 As Object = Nothing
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(connectionstring)
            Dim CmdDel As OleDbCommand, CmdCheck As OleDbCommand
            Select Case Label1.Text
                Case Is = "اسم الوحدة"
                    SqlStr = "DELETE * FROM Units WHERE UnitID=?;"
                    SqlCheck = "SELECT COUNT(PODID) FROM PODetails WHERE UnitID=?;"
                    SqlStrDisp = "SELECT * FROM Units ORDER BY UnitID DESC;"
                Case Is = "اسم النوع"
                    Exit Select : Exit Sub
                Case Is = "اسم المخزن"
                    SqlStr = "DELETE * FROM Stores WHERE StoreID=?;"
                    SqlCheck = "SELECT COUNT(PODID) FROM PODetails WHERE StoreID=?;"
                    SqlStrDisp = "SELECT * FROM Stores ORDER BY StoreID DESC;"
                Case Is = "اسم الطريقة"
                    SqlStr = "DELETE * FROM PayTypes WHERE PTID=?;"
                    SqlCheck = "SELECT COUNT(PTID) FROM PurOrders WHERE PTID=?;"
                    SqlStrDisp = "SELECT * FROM PayTypes ORDER BY PTID DESC;"
            End Select
            CmdDel = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CmdCheck = New OleDbCommand(SqlCheck, CN) With {.CommandType = CommandType.Text}
            With CmdDel.Parameters
                .AddWithValue("?", ThisID)
            End With
            With CmdCheck.Parameters
                .AddWithValue("?", ThisID)
            End With
            Try
                CN.Open()
                Dim queryResult = CmdCheck.ExecuteScalar()
                If IsDBNull(queryResult) Or IsNothing(queryResult) Then
                    Onh = CmdDel.ExecuteNonQuery
                Else
                    MsgBox("لا يمكن حذف بند له أمر شراء " & Label1.Text)
                    Exit Sub
                End If
            Catch ex As OleDbException
                MsgBox("مشكلة فى الحذف " & Label1.Text & ex.Message)
                Exit Sub
            End Try
        End Using
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False
        MsgBox("عملية ناجحه", MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Information)
        GetData(SqlStrDisp, DataGridView1)
        With DataGridView1
            .Columns(0).HeaderText = "كود"
            .Columns(1).HeaderText = Label1.Text
        End With
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Close()
    End Sub
    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        TextBox1.SelectAll()
    End Sub
    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.SelectAll()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
        If DataGridView1.Rows.Count < 0 Then Exit Sub
        DataGridView1_RowEnter(sender, e)
    End Sub
    Private Sub DataGridView1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        If e.ColumnIndex = -1 Or e.RowIndex = -1 Then Exit Sub
        If DataGridView1.Rows.Count < 0 Then Exit Sub
        TextBox2.Text = DataGridView1(0, e.RowIndex).Value.ToString
        TextBox1.Text = DataGridView1(1, e.RowIndex).Value.ToString
        Button4.Enabled = True
        Button5.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub
    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click
        Location = New Point(0, 0)
        If Height <> MainF.Height / 2 Then
            Height = MainF.Height
            Exit Sub
        End If
        Height = MainF.Height / 2
        Width = MainF.Width / 2
    End Sub
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click
        Location = New Point(0, 0)
        If WindowState = FormWindowState.Maximized Then
            WindowState = FormWindowState.Normal
            Exit Sub
        End If
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
