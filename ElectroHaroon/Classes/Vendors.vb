Imports System.Data.OleDb
Public Class Vendors
    Inherits DataOperations
    Private ConnectionString As String
    Public Property _VenID As Integer
    Public Property _VendNm As String
    Public Property _VendMob As String
    Public Property _VendTel As String
    Public Property _VendAdd As String
    Public Property _VendNote As String
    Public Sub New()
        ConnectionString = GetEncryConStr()
    End Sub
    Public Function SaveNewVend() As Integer
        Dim Saved As Integer = 0
        Dim InsertSql = <sql>
                            INSERT INTO Vendors (VendNm,Mob,Tel,Address,Notes) VALUES (?,?,?,?,?);
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                InsertCMD As New OleDbCommand(InsertSql, CN) With {.CommandType = CommandType.Text}
            With InsertCMD.Parameters
                .AddWithValue("?", _VendNm)
                .AddWithValue("?", _VendMob)
                .AddWithValue("?", _VendTel)
                .AddWithValue("?", _VendAdd)
                .AddWithValue("?", _VendNote)
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
    Public Function UpdateVendor() As Integer
        Dim Updated As Integer = 0
        Dim UpdateSql = <sql>
                            UPDATE Vendors SET VendNm=?, Mob=?, Tel=?, Address=?, Notes=? WHERE VenID=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                UpdateCmd As New OleDbCommand(UpdateSql, CN) With {.CommandType = CommandType.Text}
            With UpdateCmd.Parameters
                .AddWithValue("?", _VendNm)
                .AddWithValue("?", _VendMob)
                .AddWithValue("?", _VendTel)
                .AddWithValue("?", _VendAdd)
                .AddWithValue("?", _VendNote)
                .AddWithValue("?", _VenID)
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
    Public Function DeleteVendor() As Integer
        Dim Deleted As Integer = 0
        Dim DeleteSql = <sql>
                            DELETE * FROM Vendors WHERE VenID=?;
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                DeleteCmd As New OleDbCommand(DeleteSql, CN) With {.CommandType = CommandType.Text}
            With DeleteCmd.Parameters
                .AddWithValue("?", _VenID)
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
                            SELECT VenID,VendNm,Mob,Tel,Address,Notes FROM Vendors;
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
    Public Sub BindCboVends(ByVal CboVends As ComboBox)
        'Tells the combobox which column in the bound data is the value to save in the database
        'and which column is the value to display to the user.
        With CboVends
            .ValueMember = "VendID"
            .DisplayMember = "VendNm"
            .DataSource = GetData()
        End With
    End Sub
End Class
