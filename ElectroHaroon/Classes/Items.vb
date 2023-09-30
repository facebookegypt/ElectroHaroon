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
    Public Property KID As Integer
    Public Property ItmSellPrice As Double
    Public Sub New()
        ConnectionString = GetEncryConStr()
    End Sub
    Public Function GetData() As DataTable
        Dim Ntbl As New DataTable
        Dim SelectSql = <sql>
                            SELECT PID,Pname,Pdesc,Pcost,MinQ,BarCode,Pnotes FROM Products;
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
                            INSERT INTO Products (Pname,Pdesc,Pcost,MinQ,BarCode,Pnotes) VALUES (?,?,?,?,?,?);
                        </sql>
        Using CN As New OleDbConnection(ConnectionString),
                InsertCMD As New OleDbCommand(InsertSql, CN) With {.CommandType = CommandType.Text}
            With InsertCMD.Parameters
                .AddWithValue("?", ItmNm)
                .AddWithValue("?", ItmDesc)
                .AddWithValue("?", ItmCost)
                .AddWithValue("?", ItmMinQ)
                .AddWithValue("?", ItmBCode)
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
End Class
