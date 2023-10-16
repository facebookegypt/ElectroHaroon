Public Class frmSearch
    Inherits DataGridView
    Private DTSearch As DataTable
    Sub New()
        Name = "DGSearch"
        Dock = DockStyle.Fill
        DTSearch = New DataTable
        DTSearch.Columns.Add(New DataColumn("Col1", GetType(String)))
        DTSearch.NewRow()
        DTSearch.Rows.Add({"Ahmed"})
        DTSearch.AcceptChanges()
        AutoGenerateColumns = False
        DataSource = DTSearch
    End Sub
    Public Overloads Sub load()
        Show()
        Me.Controls.Add(New Control("DGSearch"))
    End Sub
End Class
