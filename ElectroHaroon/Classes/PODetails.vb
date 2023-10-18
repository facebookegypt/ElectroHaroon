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
        Public Function GetAvailQ() As Double
            Dim AvailQ As Double = 0.0

            Return AvailQ
        End Function
        Public Function GetSellPrices(ByVal ItmId As Integer) As DataTable
            Dim Ntble As New DataTable
            Dim SqlStr As String =
                "SELECT Kinds.KindNm, SellPriceGrps.GSellPrice
FROM Kinds INNER JOIN (Products INNER JOIN SellPriceGrps ON Products.PID = SellPriceGrps.PID) ON Kinds.KindID = SellPriceGrps.KindID
WHERE (((Products.PID)=?))
ORDER BY Products.PID, SellPriceGrps.KindID;"
            Using CN As New OleDbConnection(ConnectionString),
                    SelectCMD As New OleDbCommand(SqlStr, CN) With {.CommandType = CommandType.Text}
                Try
                    SelectCMD.Parameters.AddWithValue("?", ItmId)
                    CN.Open()
                    Ntble.Load(SelectCMD.ExecuteReader)
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
            Return Ntble
        End Function
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
        Public Sub BindPayTypes(ByVal cbo As ComboBox)
            'Tells the combobox which column in the bound data is the value to save in the database
            'and which column is the value to display to the user.
            With cbo
                .ValueMember = "PTID"
                .DisplayMember = "PTNm"
                .DataSource = GetData()
            End With
        End Sub
        Public Sub BindVendors(ByVal cbo As ComboBox)
            'Tells the combobox which column in the bound data is the value to save in the database
            'and which column is the value to display to the user.
            With cbo
                .ValueMember = "VenID"
                .DisplayMember = "VendNm"
                .DataSource = GetData()
            End With
        End Sub
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
    End Class
    Public Class PO_Details
        Inherits DataOperations
        Private ConnectionString As String
        Private Const TranID As Integer = 1 'Po or SO (1 - 2)
        Public Property InvID As Integer
        Public Property PID As Integer
        Public Property VendID As Integer
        Public Property PMID As Integer
        Public Property UnitID As Integer
        Public Property QntyIn As Integer
        Public Property ItmPrice As Double
        Public Property ItmTotal As Double
        Public Property PONotes As String
        Public Property PO_num As String
        Public Property PO_Date As Date
        Public Sub New()
            ConnectionString = GetEncryConStr()
        End Sub
        Public Function SaveNewPO(ByVal DG As DataGridView) As Integer
            If String.IsNullOrEmpty(PONotes) Then PONotes = "لا يوجد"
            Dim Saved As Integer = 0, PMKey As Integer = 0
            Dim InsertSql = <sql>
                            INSERT INTO PurInv (PO_Date,VenID,PTID,InvNotes) 
            VALUES (NOW(),?,?,?);
                        </sql>
            Dim InsertSqlDetails = <sql>
                            INSERT INTO InvDetails (PID,UnitID,QntyIn,PurUnitPrice,InvID) 
            VALUES (?,?,?,?,?);
                        </sql>
            Dim SelectSql = <sql>
                                SELECT @@IDENTITY;
                            </sql>

            Using CN As New OleDbConnection(ConnectionString),
                InsertCMD As New OleDbCommand(InsertSql, CN) With {.CommandType = CommandType.Text},
                SelectCMD As New OleDbCommand(SelectSql, CN) With {.CommandType = CommandType.Text},
                InsertDetails As New OleDbCommand(InsertSqlDetails, CN) With {.CommandType = CommandType.Text}
                Try
                    With InsertCMD.Parameters
                        .AddWithValue("?", VendID)
                        .AddWithValue("?", PMID)
                        .AddWithValue("?", PONotes)
                    End With
                    CN.Open()
                    InsertCMD.ExecuteNonQuery()
                    PMKey = CInt(SelectCMD.ExecuteScalar.ToString)
                    For Each Irow As DataGridViewRow In DG.Rows
                        With InsertDetails.Parameters
                            .AddWithValue("?", CInt(Irow.Cells("PID").Value))
                            .AddWithValue("?", CInt(Irow.Cells("Units").Value))
                            .AddWithValue("?", CInt(Irow.Cells("ItmQntyIn").Value))
                            .AddWithValue("?", CInt(Irow.Cells("ItmPurPrice").Value))
                            .AddWithValue("?", PMKey)
                        End With
                        Saved = InsertDetails.ExecuteNonQuery
                        Saved += 1
                        InsertDetails.Parameters.Clear()
                    Next
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