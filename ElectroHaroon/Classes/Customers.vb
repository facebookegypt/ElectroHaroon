Imports System.Data.OleDb
Public Class Customers
    Inherits DataOperations
    Private ConnectionString As String
    Public Property _CustID As Integer
    Public Property _CustNm As String
    Public Property _CustMob As String
    Public Property _CustTel As String
    Public Property _CustAdd As String
    Public Property _CustNote As String
    Public Sub New()
        ConnectionString = GetEncryConStr()
    End Sub
    Public Function SaveNewCust() As Integer
        Dim Saved As Integer = 0
        Dim InsertSql = <sql>
                            INSERT INTO Customers (CustNm,Mob,Tel,Address,Notes) VALUES (?,?,?,?,?);
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                InsertCMD As New OleDbCommand(InsertSql, CN) With {.CommandType = CommandType.Text}
            With InsertCMD.Parameters
                .AddWithValue("?", _CustNm)
                .AddWithValue("?", _CustMob)
                .AddWithValue("?", _CustTel)
                .AddWithValue("?", _CustAdd)
                .AddWithValue("?", _CustNote)
            End With
            Try
                CN.Open()
                Saved = InsertCMD.ExecuteNonQuery
            Catch ex As Exception
                MsgBox("خطأ فى حفظ عميل جديد : " & vbCrLf & ex.Message,
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
    Public Function UpdateCustomer() As Integer
        Dim Updated As Integer = 0
        Dim UpdateSql = <sql>
                            UPDATE Customers SET CustNm=?, Mob=?, Tel=?, Address=?, Notes=? WHERE CustID=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                UpdateCmd As New OleDbCommand(UpdateSql, CN) With {.CommandType = CommandType.Text}
            With UpdateCmd.Parameters
                .AddWithValue("?", _CustNm)
                .AddWithValue("?", _CustMob)
                .AddWithValue("?", _CustTel)
                .AddWithValue("?", _CustAdd)
                .AddWithValue("?", _CustNote)
                .AddWithValue("?", _CustID)
            End With
            Try
                CN.Open()
                Updated = UpdateCmd.ExecuteNonQuery
            Catch ex As Exception
                MsgBox("خطأ فى تعديل عميل : " & vbCrLf & ex.Message,
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
    Public Function DeleteCustomer() As Integer
        Dim Deleted As Integer = 0
        Dim DeleteSql = <sql>
                            DELETE * FROM Customers WHERE CustID=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                DeleteCmd As New OleDbCommand(DeleteSql, CN) With {.CommandType = CommandType.Text}
            With DeleteCmd.Parameters
                .AddWithValue("?", _CustID)
            End With
            Try
                CN.Open()
                Deleted = DeleteCmd.ExecuteNonQuery
            Catch ex As Exception
                MsgBox("خطأ فى حذف عميل : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                DeleteCmd.Parameters.Clear()
                DeleteCmd.Dispose()
                CN.Close()
            Finally
                DeleteCmd.Parameters.Clear()
                DeleteCmd.Dispose()
                CN.Close()
            End Try
        End Using
        Return Deleted
    End Function
    Public Function GetData() As DataTable
        Dim Ntbl As New DataTable
        Dim SelectSql = <sql>
                            SELECT CustID,CustNm,Mob,Tel,Address,Notes FROM Customers;
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
End Class
