Imports System.Windows.Forms

Public Class PO_preview
    Inherits DataGridView
    Public Sub New()
        Visible = True
        Me.AllowUserToAddRows = False
        Me.AllowUserToOrderColumns = True
        Me.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BackgroundColor = System.Drawing.Color.Snow
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.ColumnHeadersHeight = 50
        Me.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.EnableHeadersVisualStyles = False
        Me.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.ColumnHeadersDefaultCellStyle.Font = New Font("Traditional Arabic", 13.8, FontStyle.Bold)
        Me.RowTemplate.Height = 30
        Me.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.GridColor = System.Drawing.Color.DeepSkyBlue
        Me.Location = New System.Drawing.Point(0, 95)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MultiSelect = False
        Me.Name = "PO_Perview"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Size = New System.Drawing.Size(1056, 570)
        Me.ReadOnly = True
        AddHandler Me.DataBindingComplete, AddressOf PO_preview_DataBindingComplete
    End Sub
    Private Sub PO_preview_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
        RemoveHandler Me.DataBindingComplete, AddressOf PO_preview_DataBindingComplete
        RowTemplate.Height = 35
        Columns("PID").Visible = False
        Columns("PID").DataPropertyName = "PID"

        Columns("ColAdd").HeaderText = "اضافة/حذف"
        Columns("ColAdd").DisplayIndex = 6
        Columns("ColAdd").ValueType = GetType(Boolean)
        Columns("ColAdd").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        DirectCast(Columns("ColAdd"), DataGridViewCheckBoxColumn).TrueValue = True
        DirectCast(Columns("ColAdd"), DataGridViewCheckBoxColumn).FalseValue = False
        DirectCast(Columns("ColAdd"), DataGridViewCheckBoxColumn).ThreeState = False
        DirectCast(Columns("ColAdd"), DataGridViewCheckBoxColumn).DefaultCellStyle.NullValue = False
        Columns("Pname").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Columns("Pname").DataPropertyName = "Pname"
        Columns("Pname").HeaderText = "الصنف"
        Columns("Units").DataPropertyName = "Units"
        Columns("Units").HeaderText = "الوحدة"
        Columns("ItmQntyIn").HeaderText = "الكمية"
        Columns("ItmQntyIn").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Columns("ItmPurPrice").HeaderText = "سعر الوحدة"
        Columns("ItmPurPrice").DefaultCellStyle.Format = "C2"
        Columns("ItmTotalPrice").HeaderText = "اجمالي الصنف"
        Columns("ItmTotalPrice").DefaultCellStyle.Format = "C2"
        AddHandler Me.DataBindingComplete, AddressOf PO_preview_DataBindingComplete
    End Sub
End Class
