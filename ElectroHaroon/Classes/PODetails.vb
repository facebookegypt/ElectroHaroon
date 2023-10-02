Imports System.Data.OleDb
Public Class PODetails
    Inherits DataOperations
    Private ConnectionString As String

    Public Sub New()
        ConnectionString = GetEncryConStr()
    End Sub
    Public Function GetData() As DataTable
        Dim Ntbl As New DataTable
        Dim SelectSql = <sql>
                            SELECT KindID,KindNm FROM Kinds;
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