Imports System.Data.OleDb
Public Class Units
    Inherits DataOperations
    Private ConnectionString As String
    Public Property UnitID As Integer
    Public Property UnitNm As String
    Public Sub New()
        ConnectionString = GetEncryConStr()
    End Sub
    Public Function GetData() As DataTable
        Dim Ntbl As New DataTable
        Dim SelectSql = <sql>
                            SELECT UnitID,UnitNm FROM Units;
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
    Public Sub BindDGColumnUnits(ByVal DG As DataGridView)
        Dim UnitsCboColumn As DataGridViewComboBoxColumn =
            DirectCast(DG.Columns("Units"), DataGridViewComboBoxColumn)
        'Tells the combobox which column in the bound data is the value to save in the database
        'and which column is the value to display to the user.
        With UnitsCboColumn
            .DataPropertyName = "Units"
            .ValueMember = "UnitID"
            .DisplayMember = "UnitNm"
            .DataSource = GetData()
            .DefaultCellStyle.NullValue = "اختر الوحدة"
        End With
    End Sub
End Class