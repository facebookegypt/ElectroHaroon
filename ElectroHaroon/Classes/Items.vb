Imports System.Data.OleDb
Public Class Items
    Inherits DataOperations
    Private ConnectionString As String
    Public Property ItmID As Integer
    Public Property ItmNm As String
    Public Property ItmDesc As String
    Public Property ItmMinQ As Integer
    Public Property ItmCost As Double
    Public Property ItmNotes As String
    Public Property ItmBCode As String
    Public Property StoreID As Integer
    Public Property FrstQnty As Integer
    Public Property KID As Integer
    Public Property ItmSellPrice As Double
    Public Sub New()
        ConnectionString = GetEncryConStr()
    End Sub
    Public Function GetsellPrice() As Double
        Dim Ndbl As Double = 0.00
        Dim SelectSql = <sql>
                            SELECT SellPriceGrps.GSellPrice FROM SellPriceGrps 
        WHERE SellPriceGrps.PID=? AND SellPriceGrps.KindID=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                SelectCMD As New OleDbCommand(SelectSql, CN) With {.CommandType = CommandType.Text}
            SelectCMD.Parameters.AddWithValue("?", ItmID)
            SelectCMD.Parameters.AddWithValue("?", KID)
            Try
                CN.Open()
                Using Rdr As OleDbDataReader = SelectCMD.ExecuteReader
                    While Rdr.Read
                        If Rdr.HasRows Then
                            Ndbl = Rdr.GetValue(0)
                        Else
                            Ndbl = 0.00
                        End If
                    End While
                End Using
            Catch ex As Exception
                MsgBox("خطأ 1 : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                SelectCMD.Parameters.Clear()
                SelectCMD.Dispose()
                CN.Close()
            Finally
                SelectCMD.Parameters.Clear()
                SelectCMD.Dispose()
                CN.Close()
            End Try
        End Using
        Return Ndbl
    End Function
    Public Function SellPriceExists() As Boolean
        Dim Exists As Boolean = False
        Dim SelectSql = <sql>
                            SELECT Count([PID]) AS CountPID FROM Kinds 
        INNER JOIN SellPriceGrps ON Kinds.KindID = SellPriceGrps.KindID 
        WHERE (((Kinds.KindID)=?) AND ((SellPriceGrps.PID)=?));
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                SelectCMD As New OleDbCommand(SelectSql, CN) With {.CommandType = CommandType.Text}
            SelectCMD.Parameters.AddWithValue("?", KID)
            SelectCMD.Parameters.AddWithValue("?", ItmID)
            Try
                CN.Open()
                Dim Found = SelectCMD.ExecuteScalar
                If IsNothing(Found) Or CInt(Found) = 0 Then
                    Exists = False
                ElseIf CInt(Found) > 0 Then
                    Exists = True
                End If
            Catch ex As Exception
                MsgBox("خطأ 1 : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                SelectCMD.Parameters.Clear()
                SelectCMD.Dispose()
                CN.Close()
            Finally
                SelectCMD.Parameters.Clear()
                SelectCMD.Dispose()
                CN.Close()
            End Try
        End Using
        Return Exists
    End Function
    Public Sub UpdateInsertSellP(ByVal Exists As Boolean)
        Dim SqlStr As String
        Using CN As New OleDbConnection(ConnectionString)
            Dim CMD As OleDbCommand
            If Exists Then
                'Update
                SqlStr = <SQL>UPDATE SellPriceGrps SET GSellPrice=? WHERE (KindID=?) AND (PID=?);</SQL>
                CMD = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
                With CMD.Parameters
                    .AddWithValue("?", ItmSellPrice)
                    .AddWithValue("?", KID)
                    .AddWithValue("?", ItmID)
                End With
            Else
                'Insert
                SqlStr = <sql>INSERT INTO SellPriceGrps (KindID,PID,GSellPrice) VALUES (?,?,?);</sql>
                CMD = New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
                With CMD.Parameters
                    .AddWithValue("?", KID)
                    .AddWithValue("?", ItmID)
                    .AddWithValue("?", ItmSellPrice)
                End With
            End If
            Try
                CN.Open()
                CMD.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("خطأ فى جدول اسعار الاصناف : " & ex.Message)
                CMD.Parameters.Clear()
                CMD.Dispose()
                CN.Close()
            Finally
                CMD.Parameters.Clear()
                CMD.Dispose()
                CN.Close()
            End Try
        End Using
    End Sub
    Public Function GetData() As DataTable
        Dim Ntbl As New DataTable
        Dim SelectSql = <sql>
                            SELECT PID,Pname,Pdesc,Pcost,FrstQnty,MinQ,BarCode,StoreID,Pnotes FROM Products;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                SelectCMD As New OleDbCommand(SelectSql, CN) With {.CommandType = CommandType.Text}
            Try
                CN.Open()
                Ntbl.Load(SelectCMD.ExecuteReader)
            Catch ex As Exception
                MsgBox("خطأ 1 : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                SelectCMD.Dispose()
                CN.Close()
            Finally
                SelectCMD.Dispose()
                CN.Close()
            End Try
        End Using
        Return Ntbl
    End Function
    Public Function SaveNewItm() As Integer
        If String.IsNullOrEmpty(ItmNotes) Then ItmNotes = "لا يوجد"
        Dim Saved As Integer = 0
        Dim InsertSql = <sql>
                            INSERT INTO Products (Pname,Pdesc,Pcost,FrstQnty,MinQ,BarCode,StoreID,Pnotes) VALUES (?,?,?,?,?,?,?,?);
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                InsertCMD As New OleDbCommand(InsertSql, CN) With {.CommandType = CommandType.Text}
            With InsertCMD.Parameters
                .AddWithValue("?", ItmNm)
                .AddWithValue("?", ItmDesc)
                .AddWithValue("?", ItmCost)
                .AddWithValue("?", FrstQnty)
                .AddWithValue("?", ItmMinQ)
                .AddWithValue("?", ItmBCode)
                .AddWithValue("?", StoreID)
                .AddWithValue("?", ItmNotes)
            End With
            Try
                CN.Open()
                Saved = InsertCMD.ExecuteNonQuery
            Catch ex As Exception
                MsgBox("خطأ فى حفظ صنف جديد : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                InsertCMD.Parameters.Clear()
                InsertCMD.Dispose()
                CN.Close()
            Finally
                InsertCMD.Parameters.Clear()
                InsertCMD.Dispose()
                CN.Close()
            End Try
        End Using
        Return Saved
    End Function
    Public Function UpdateItems() As Integer
        Dim Updated As Integer = 0
        Dim UpdateSql = <sql>
                            UPDATE Products SET Pname=?, Pdesc=?, Pcost=?, FrstQnty=?, MinQ=?, StoreID=?, Pnotes=? WHERE PID=? AND BarCode=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                UpdateCmd As New OleDbCommand(UpdateSql, CN) With {.CommandType = CommandType.Text}
            With UpdateCmd.Parameters
                .AddWithValue("?", ItmNm)
                .AddWithValue("?", ItmDesc)
                .AddWithValue("?", ItmCost)
                .AddWithValue("?", FrstQnty)
                .AddWithValue("?", ItmMinQ)
                .AddWithValue("?", StoreID)
                .AddWithValue("?", ItmNotes)
                .AddWithValue("?", ItmID)
                .AddWithValue("?", ItmBCode)
            End With
            Try
                CN.Open()
                Updated = UpdateCmd.ExecuteNonQuery
            Catch ex As Exception
                MsgBox("خطأ فى تعديل بيانات الصنف : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                UpdateCmd.Parameters.Clear()
                UpdateCmd.Dispose()
                CN.Close()
            Finally
                UpdateCmd.Parameters.Clear()
                UpdateCmd.Dispose()
                CN.Close()
            End Try
        End Using
        Return Updated
    End Function
    Public Function DeleteItem() As Integer
        Dim Deleted As Integer = 0
        Dim DeleteSql = <sql>
                            DELETE * FROM Products WHERE PID=?;
                        </sql>
        Dim DeleteSql1 = <sql>
                            DELETE * FROM SellPriceGrps WHERE PID=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                DeleteCmd As New OleDbCommand(DeleteSql, CN) With {.CommandType = CommandType.Text},
                DeleteCmd1 As New OleDbCommand(DeleteSql1, CN) With {.CommandType = CommandType.Text}
            With DeleteCmd.Parameters
                .AddWithValue("?", ItmID)
            End With
            With DeleteCmd1.Parameters
                .AddWithValue("?", ItmID)
            End With
            Try
                CN.Open()
                Deleted = DeleteCmd.ExecuteNonQuery
                Deleted += DeleteCmd1.ExecuteNonQuery
            Catch ex As Exception
                MsgBox("خطأ فى حذف عميل : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                DeleteCmd.Parameters.Clear()
                DeleteCmd.Dispose()
                DeleteCmd1.Parameters.Clear()
                DeleteCmd1.Dispose()
                CN.Close()
            Finally
                DeleteCmd.Parameters.Clear()
                DeleteCmd.Dispose()
                DeleteCmd1.Parameters.Clear()
                DeleteCmd1.Dispose()
                CN.Close()
            End Try
        End Using
        Return Deleted
    End Function
End Class

