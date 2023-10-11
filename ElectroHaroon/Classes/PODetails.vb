Imports System.Data.OleDb
Namespace Pur_Sell_Ordrs
    Public Class CombinedData
        Inherits DataOperations
        Private ConnectionString As String
        Public Key_ID As String
        Public Val_Nm As String
        Public Tbl_Nm As String
        Public Sub New()
            ConnectionString = GetEncryConStr()
        End Sub
        Public Function GetData() As DataTable
            Dim Ntbl As New DataTable
            Dim SelectSql = "SELECT " & Key_ID & "," & Val_Nm & " FROM " & Tbl_Nm & ";"
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
        Public Function GetDataItems() As DataTable
            Dim Ntbl As New DataTable
            Dim SelectSql = "SELECT PID, Pname FROM Products;"
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
    Public Class SO_Details
        Inherits DataOperations
        Private ConnectionString As String
        Private Const TranID As Integer = 2  'Po or SO (1 - 2)
        Public Property SOID As Integer
        Public Property SODate As Date
        Public Property PID As Integer
        Public Property CustID As Integer
        Public Property PMID As Integer
        Public Property UnitID As Integer
        Public Property StoreID As Integer
        Public Property SONotes As String
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
    Public Class PO_Details
        Inherits DataOperations
        Private ConnectionString As String
        Private Const TranID As Integer = 1 'Po or SO (1 - 2)
        Public Property POID As Integer
        Public Property PODate As Date
        Public Property PID As Integer
        Public Property VendID As Integer
        Public Property PMID As Integer
        Public Property UnitID As Integer
        Public Property StoreID As Integer
        Public Property PONotes As String
        Public Sub New()
            ConnectionString = GetEncryConStr()
        End Sub
        Public Function SaveNewPO() As Integer
            If String.IsNullOrEmpty(PONotes) Then PONotes = "لا يوجد"
            Dim Saved As Integer = 0, PMKey As Integer = 0
            Dim InsertSql = <sql>
                            INSERT INTO PurOrders (PODt,TranID,VenID,PTId,PONots) VALUES (NOW(),?,?,?,?);
                        </sql>
            Dim SelectSql = <sql>
                                SELECT @@IDENTITY;
                            </sql>
            Using CN As New OleDbConnection(ConnectionString),
                InsertCMD As New OleDbCommand(InsertSql, CN) With {.CommandType = CommandType.Text},
                SelectCMD As New OleDbCommand(SelectSql, CN) With {.CommandType = CommandType.Text}
                With InsertCMD.Parameters
                    .AddWithValue("?", TranID)
                    .AddWithValue("?", VendID)
                    .AddWithValue("?", PMID)
                    .AddWithValue("?", PONotes)
                End With
                Try
                    CN.Open()
                    Saved = InsertCMD.ExecuteNonQuery
                    PMKey = CInt(SelectCMD.ExecuteScalar.ToString)
                Catch ex As Exception
                    MsgBox("خطأ فى حفظ أمر شراء جديد : " & vbCrLf & ex.Message,
                       MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.Critical,
                       "خطأ")
                    InsertCMD.Parameters.Clear()
                    InsertCMD.Dispose()
                    CN.Close()
                Finally
                    InsertCMD.Parameters.Clear()
                    InsertCMD.Dispose()
                    SelectCMD.Dispose()
                    CN.Close()
                End Try
            End Using
            Return PMKey
        End Function
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
End Namespace