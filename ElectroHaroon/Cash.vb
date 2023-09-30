Imports System.Data.OleDb
Public Class Cash
    Private displayWhat As String = "Until Now"
    Private Function GetCash(ByVal TraTyp As Integer) As Decimal
        Dim cv As Decimal
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.POPaid) AS SumOfPOPaid FROM PurOrders GROUP BY PurOrders.TranID HAVING (((PurOrders.TranID)=?));"
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
            CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", TraTyp)
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
    Private Function GetInst(ByVal TrID As Integer) As Decimal
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim cv As Decimal
        Dim SqlStr As String =
            "SELECT Sum(CustPaid.Payamnt) AS SumOfPayamnt FROM CustPaid WHERE TranID=?;"
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                CMD.Parameters.AddWithValue("?", TrID)
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
    Private Sub Label9_MouseDown(sender As Object, e As MouseEventArgs) Handles Label9.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If
    End Sub
    Private Sub DTP1_ValueChanged(sender As Object, e As EventArgs) Handles DTP1.ValueChanged

    End Sub

    Private Sub DTP1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTP1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            displayWhat = "On Date"
            Label13.Text = "حركة النقدية فى تاريخ  " & format(DTP1.Value,"dd, MMMMM, yyyy")
            TextBox1.Text = FormatCurrency(GetCashOnDt(DTP1.Value.ToShortDateString, 2), 2)
            'TextBox6.Text = FormatCurrency(Val(TextBox1.Text + TextBox3.Text + TextBox5.Text), 2)
            TextBox7.Text = FormatCurrency(GetCashOnDt(DTP1.Value.ToShortDateString, 1), 2)

            TextBox4.Text = FormatCurrency(Val(TextBox1.Text - TextBox7.Text), 2)
        End If
    End Sub
    Private Function GetCashOnDt(ByVal OnDt As Date, ByVal TraTyp As Integer) As Decimal
        If OnDt > Now.Date Then
            MsgBox("عملية غير صحيحة - التاريخ بعد تاريخ اليوم",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المشتريات و المبيعات")
            Return 0
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.POPaid) AS SumOfPOPaid FROM PurOrders " &
            "GROUP BY Format([PODt],'Short Date'), PurOrders.TranID HAVING (((Format([PODt],'Short Date'))=#" & OnDt & "#) AND ((PurOrders.TranID)=?));"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Dim cv As Decimal
        Using CN As OleDbConnection = New OleDbConnection(connectionstring),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", TraTyp)
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
    Private Function GetCashTODt(ByVal OnDt As Date, ByVal TraTyp As Integer) As Decimal
        Dim cv As Decimal
        If OnDt > Now.Date Then
            MsgBox("عملية غير صحيحة - التاريخ بعد تاريخ اليوم",
                   MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المشتريات و المبيعات")
            Return 0
            Exit Function
        End If
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.POPaid) AS SumOfPOPaid FROM PurOrders WHERE (((Format([PODt],'Short Date'))<=#" & OnDt & "#)) " &
            "GROUP BY PurOrders.TranID HAVING (((PurOrders.TranID)=?));"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", TraTyp)
            Try
                CN.Open()
                Dim queryResult = CMD.ExecuteScalar()
                If IsDBNull(queryResult) Or IsNothing(queryResult) Then
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
    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged

    End Sub

    Private Sub DateTimePicker3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker3.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            displayWhat = "Until some Date"
            Label13.Text = "حركة النقدية حتي تاريخ  " & Format(DateTimePicker3.Value, "dd, MMMMM, yyyy")
            TextBox1.Text = FormatCurrency(GetCashTODt(DateTimePicker3.Value.ToShortDateString, 2), 2)
            'TextBox6.Text = FormatCurrency(Val(TextBox1.Text + TextBox3.Text + TextBox5.Text), 2)
            TextBox7.Text = FormatCurrency(GetCashTODt(DateTimePicker3.Value.ToShortDateString, 1), 2)

            TextBox4.Text = FormatCurrency(Val(TextBox1.Text - TextBox7.Text), 2)
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
    Private Function GetCashBTWN(ByVal Dt1 As Date, ByVal Dt2 As Date, ByVal TraTyp As Integer) As Decimal
        Dim cv As Decimal
        Dim SqlStr As String =
            "SELECT Sum(PurOrders.POPaid) AS SumOfPOPaid FROM PurOrders WHERE (((Format([PODt],'Short Date')) " &
            "BETWEEN #" & Dt1 & "# AND #" & Dt2 & "#)) GROUP BY PurOrders.TranID HAVING (((PurOrders.TranID)=?));"
        Dim Ops As New DataOperations
        Dim ConnectionString = Ops.GetEncryConStr
        Using CN As OleDbConnection = New OleDbConnection(ConnectionString),
                CMD As OleDbCommand = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
            CMD.Parameters.AddWithValue("?", TraTyp)
            Try
                CN.Open()
                Dim queryResult = CMD.ExecuteScalar()
                If IsDBNull(queryResult) Or IsNothing(queryResult) Then
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
    Private Sub DateTimePicker1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DateTimePicker1.Value > DateTimePicker2.Value Then
                MsgBox("عملية غير صحيحة - التاريخ الأول يجب أن يكون قبل التاريخ الثاني",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المشتريات و المبيعات")
                Exit Sub
            End If
            displayWhat = "Between two dates"
            Label13.Text = "حركة النقدية بين " & Format(DateTimePicker1.Value, "dd, MMMMM, yyyy" & " و " &
                                                               Format(DateTimePicker2.Value, "dd, MMMMM, yyyy"))
            TextBox1.Text = FormatCurrency(GetCashBTWN(DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, 2), 2)
            'TextBox6.Text = FormatCurrency(Val(TextBox1.Text + TextBox3.Text + TextBox5.Text), 2)
            TextBox7.Text = FormatCurrency(GetCashBTWN(DateTimePicker1.Value.ToShortDateString, DateTimePicker2.Value.ToShortDateString, 1), 2)
            TextBox4.Text = FormatCurrency(Val(TextBox1.Text - TextBox7.Text), 2)
        End If
    End Sub
    Private Sub DateTimePicker2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If DateTimePicker2.Value < DateTimePicker1.Value Then
                MsgBox("عملية غير صحيحة - التاريخ الأول يجب أن يكون قبل التاريخ الثاني",
                       MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.Critical, "برنامج المشتريات و المبيعات")
                Exit Sub
            End If
            displayWhat = "Between two dates"
            Label13.Text = "حركة النقدية بين " & Format(DateTimePicker1.Value, "dd, MMMMM, yyyy" & " و " &
                                                               Format(DateTimePicker2.Value, "dd, MMMMM, yyyy"))
            TextBox1.Text = FormatCurrency(GetCashBTWN(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, 2), 2)
            'TextBox6.Text = FormatCurrency(Val(TextBox1.Text + TextBox3.Text + TextBox5.Text), 2)
            TextBox7.Text = FormatCurrency(GetCashBTWN(DateTimePicker1.Value.Date, DateTimePicker2.Value.Date, 1), 2)

            TextBox4.Text = FormatCurrency(Val(TextBox1.Text - TextBox7.Text), 2)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Cash_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            MainF.Activate()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cash_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Close()
        End If
    End Sub

    Private Sub Cash_Load(sender As Object, e As EventArgs) Handles Me.Load
        If displayWhat = "Until Now" Then
            Label13.Text = "حركة النقدية حتي الأن"
            Dim Casha, Cashb, Cashc, Cashd, CashH As Decimal

            Casha = GetCash(2)
            Cashb = GetInst(2)
            CashH = GetInst(1)
            Cashc = Casha + Cashb
            Cashd = GetCash(1)
            TextBox1.Text = FormatCurrency(Casha, 2)
            TextBox3.Text = FormatCurrency(Cashb, 2)
            TextBox6.Text = FormatCurrency(Cashc, 2)
            TextBox7.Text = FormatCurrency(Cashd, 2)
            TextBox2.Text = FormatCurrency(CashH, 2)
            TextBox8.Text = FormatCurrency(Cashd + CashH, 2)
            TextBox4.Text = FormatCurrency(Val(TextBox6.Text - TextBox8.Text), 2)
        End If
    End Sub
End Class