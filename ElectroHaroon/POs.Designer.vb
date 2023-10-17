<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class POs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POs))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me._MP = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me._MPback = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGready = New System.Windows.Forms.DataGridView()
        Me.PID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Units = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.InvTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvDscnt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvNet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvRest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Pno1 = New System.Windows.Forms.TextBox()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblSts = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Button()
        Me.MnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuLesItms = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGready, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Snow
        Me.MenuStrip1.BackgroundImage = Global.ElectroHaroon.My.Resources.Resources.Header_PNG_Transparent_Image
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._MP})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuStrip1.Size = New System.Drawing.Size(1379, 55)
        Me.MenuStrip1.TabIndex = 307
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '_MP
        '
        Me._MP.AutoToolTip = True
        Me._MP.BackColor = System.Drawing.Color.Transparent
        Me._MP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me._MP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDel, Me.MnuPrint, Me.ToolStripMenuItem2, Me.MnuLesItms, Me.MnuItems, Me.ToolStripMenuItem1, Me._MPback})
        Me._MP.Font = New System.Drawing.Font("Traditional Arabic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._MP.ForeColor = System.Drawing.Color.Brown
        Me._MP.Name = "_MP"
        Me._MP.Padding = New System.Windows.Forms.Padding(40, 0, 4, 0)
        Me._MP.Size = New System.Drawing.Size(172, 51)
        Me._MP.Text = "فواتير الشراء"
        '
        'MnuNew
        '
        Me.MnuNew.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuNew.Name = "MnuNew"
        Me.MnuNew.ShortcutKeyDisplayString = "Ctrl+N"
        Me.MnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MnuNew.Size = New System.Drawing.Size(243, 26)
        Me.MnuNew.Text = "جديد"
        '
        'MnuSave
        '
        Me.MnuSave.Enabled = False
        Me.MnuSave.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuSave.Name = "MnuSave"
        Me.MnuSave.ShortcutKeyDisplayString = "Ctrl+S"
        Me.MnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.MnuSave.Size = New System.Drawing.Size(270, 26)
        Me.MnuSave.Text = "حفظ أمر توريد"
        '
        'MnuEdit
        '
        Me.MnuEdit.Enabled = False
        Me.MnuEdit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuEdit.Name = "MnuEdit"
        Me.MnuEdit.ShortcutKeyDisplayString = "Ctrl+E"
        Me.MnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MnuEdit.Size = New System.Drawing.Size(243, 26)
        Me.MnuEdit.Text = "تعديل"
        '
        'MnuDel
        '
        Me.MnuDel.Enabled = False
        Me.MnuDel.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuDel.Name = "MnuDel"
        Me.MnuDel.ShortcutKeyDisplayString = "Del"
        Me.MnuDel.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.MnuDel.Size = New System.Drawing.Size(243, 26)
        Me.MnuDel.Text = "حذف"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(240, 6)
        '
        '_MPback
        '
        Me._MPback.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._MPback.Name = "_MPback"
        Me._MPback.ShortcutKeyDisplayString = "Esc"
        Me._MPback.Size = New System.Drawing.Size(243, 26)
        Me._MPback.Text = "رجوع"
        '
        'DGready
        '
        Me.DGready.AllowUserToAddRows = False
        Me.DGready.AllowUserToOrderColumns = True
        Me.DGready.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGready.BackgroundColor = System.Drawing.Color.Snow
        Me.DGready.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGready.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGready.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.DGready.ColumnHeadersHeight = 50
        Me.DGready.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGready.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID, Me.Pname, Me.Units})
        Me.DGready.EnableHeadersVisualStyles = False
        Me.DGready.GridColor = System.Drawing.Color.DeepSkyBlue
        Me.DGready.Location = New System.Drawing.Point(0, 95)
        Me.DGready.Margin = New System.Windows.Forms.Padding(4)
        Me.DGready.MultiSelect = False
        Me.DGready.Name = "DGready"
        Me.DGready.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGready.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGready.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.DGready.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGready.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGready.Size = New System.Drawing.Size(1056, 570)
        Me.DGready.TabIndex = 426
        '
        'PID
        '
        Me.PID.DataPropertyName = "PID"
        Me.PID.HeaderText = "كود الصنف"
        Me.PID.Name = "PID"
        Me.PID.ReadOnly = True
        Me.PID.Visible = False
        '
        'Pname
        '
        Me.Pname.DataPropertyName = "Pname"
        Me.Pname.HeaderText = "اسم الصنف"
        Me.Pname.Name = "Pname"
        Me.Pname.ReadOnly = True
        '
        'Units
        '
        Me.Units.DataPropertyName = "Units"
        Me.Units.HeaderText = "الوحده"
        Me.Units.Name = "Units"
        Me.Units.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Units.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Snow
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.DataGridView1.ColumnHeadersHeight = 50
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvTotal, Me.InvDscnt, Me.InvNet, Me.InvPaid, Me.InvRest})
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.DeepSkyBlue
        Me.DataGridView1.Location = New System.Drawing.Point(0, 673)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1056, 114)
        Me.DataGridView1.TabIndex = 427
        '
        'InvTotal
        '
        DataGridViewCellStyle25.Format = "C2"
        DataGridViewCellStyle25.NullValue = "0.00"
        Me.InvTotal.DefaultCellStyle = DataGridViewCellStyle25
        Me.InvTotal.HeaderText = "اجمالي الفاتورة"
        Me.InvTotal.Name = "InvTotal"
        '
        'InvDscnt
        '
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.Snow
        Me.InvDscnt.DefaultCellStyle = DataGridViewCellStyle26
        Me.InvDscnt.HeaderText = "الخصم"
        Me.InvDscnt.Name = "InvDscnt"
        '
        'InvNet
        '
        Me.InvNet.HeaderText = "صافي الفاتورة"
        Me.InvNet.Name = "InvNet"
        '
        'InvPaid
        '
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.Snow
        Me.InvPaid.DefaultCellStyle = DataGridViewCellStyle27
        Me.InvPaid.HeaderText = "المدفوع للمورد"
        Me.InvPaid.Name = "InvPaid"
        '
        'InvRest
        '
        Me.InvRest.HeaderText = "المتبقي للمورد"
        Me.InvRest.Name = "InvRest"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.AliceBlue
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(419, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(106, 31)
        Me.Label1.TabIndex = 428
        Me.Label1.Text = "الصنف"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.UseCompatibleTextRendering = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.TextBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(0, 59)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(411, 30)
        Me.TextBox1.TabIndex = 429
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.AliceBlue
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(1260, 64)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 31)
        Me.Label4.TabIndex = 430
        Me.Label4.Text = "رقم أمر شراء"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label4.UseCompatibleTextRendering = True
        '
        'Pno1
        '
        Me.Pno1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pno1.BackColor = System.Drawing.Color.AliceBlue
        Me.Pno1.Font = New System.Drawing.Font("Times New Roman", 12.0!)
        Me.Pno1.ForeColor = System.Drawing.Color.Black
        Me.Pno1.Location = New System.Drawing.Point(1064, 65)
        Me.Pno1.Margin = New System.Windows.Forms.Padding(4)
        Me.Pno1.MaxLength = 20
        Me.Pno1.Name = "Pno1"
        Me.Pno1.ReadOnly = True
        Me.Pno1.Size = New System.Drawing.Size(188, 30)
        Me.Pno1.TabIndex = 431
        Me.Pno1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DTP1
        '
        Me.DTP1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTP1.CalendarMonthBackground = System.Drawing.Color.AliceBlue
        Me.DTP1.CustomFormat = "dd/MMMM/yyyy"
        Me.DTP1.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP1.Location = New System.Drawing.Point(1064, 107)
        Me.DTP1.Margin = New System.Windows.Forms.Padding(4)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DTP1.RightToLeftLayout = True
        Me.DTP1.Size = New System.Drawing.Size(188, 30)
        Me.DTP1.TabIndex = 432
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.AliceBlue
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(1260, 106)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 31)
        Me.Label11.TabIndex = 433
        Me.Label11.Text = "التاريخ"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label11.UseCompatibleTextRendering = True
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.BackColor = System.Drawing.Color.AliceBlue
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button7.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button7.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.Black
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(1064, 148)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(35, 29)
        Me.Button7.TabIndex = 436
        Me.Button7.UseCompatibleTextRendering = True
        Me.Button7.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ComboBox2.ForeColor = System.Drawing.Color.Black
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(1107, 149)
        Me.ComboBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox2.Size = New System.Drawing.Size(145, 29)
        Me.ComboBox2.TabIndex = 434
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.AliceBlue
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(1260, 147)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 31)
        Me.Label9.TabIndex = 435
        Me.Label9.Text = "اسم المورد"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label9.UseCompatibleTextRendering = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold)
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"نقدي", "فيزا"})
        Me.ComboBox1.Location = New System.Drawing.Point(1107, 188)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(145, 29)
        Me.ComboBox1.TabIndex = 437
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.AliceBlue
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1260, 187)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 31)
        Me.Label8.TabIndex = 438
        Me.Label8.Text = "طريقة الدفع"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label8.UseCompatibleTextRendering = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.AliceBlue
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1064, 188)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 29)
        Me.Button1.TabIndex = 439
        Me.Button1.UseCompatibleTextRendering = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.BackColor = System.Drawing.Color.AliceBlue
        Me.TextBox7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.ForeColor = System.Drawing.Color.Black
        Me.TextBox7.Location = New System.Drawing.Point(1064, 225)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox7.MaxLength = 20
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox7.Size = New System.Drawing.Size(188, 79)
        Me.TextBox7.TabIndex = 441
        Me.TextBox7.Text = "لا يوجد"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.AliceBlue
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(1260, 225)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 31)
        Me.Label10.TabIndex = 440
        Me.Label10.Text = "ملاحظات"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label10.UseCompatibleTextRendering = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(1066, 746)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 45)
        Me.PictureBox1.TabIndex = 443
        Me.PictureBox1.TabStop = False
        '
        'LblSts
        '
        Me.LblSts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSts.BackColor = System.Drawing.Color.White
        Me.LblSts.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSts.ForeColor = System.Drawing.Color.Black
        Me.LblSts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblSts.Location = New System.Drawing.Point(1064, 673)
        Me.LblSts.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSts.Name = "LblSts"
        Me.LblSts.Size = New System.Drawing.Size(302, 118)
        Me.LblSts.TabIndex = 442
        Me.LblSts.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LblSts.UseCompatibleTextRendering = True
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.FloralWhite
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(1064, 321)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(301, 36)
        Me.Panel1.TabIndex = 444
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Snow
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Brown
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(301, 36)
        Me.Label2.TabIndex = 431
        Me.Label2.Text = "أسعار البيع"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.AliceBlue
        Me.Label3.Enabled = False
        Me.Label3.FlatAppearance.BorderColor = System.Drawing.Color.Blue
        Me.Label3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Traditional Arabic", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Brown
        Me.Label3.Location = New System.Drawing.Point(628, 59)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(344, 32)
        Me.Label3.TabIndex = 445
        Me.Label3.Tag = "Ctrl+P"
        Me.Label3.Text = "معاينة أمر الشراء"
        Me.Label3.UseCompatibleTextRendering = True
        Me.Label3.UseVisualStyleBackColor = False
        '
        'MnuPrint
        '
        Me.MnuPrint.Enabled = False
        Me.MnuPrint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuPrint.Name = "MnuPrint"
        Me.MnuPrint.ShortcutKeyDisplayString = "Ctrl+W"
        Me.MnuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.MnuPrint.Size = New System.Drawing.Size(278, 26)
        Me.MnuPrint.Text = "طباعة أمر التوريد"
        '
        'MnuLesItms
        '
        Me.MnuLesItms.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuLesItms.Name = "MnuLesItms"
        Me.MnuLesItms.Size = New System.Drawing.Size(270, 26)
        Me.MnuLesItms.Text = "كشف أصناف ناقصه"
        '
        'MnuItems
        '
        Me.MnuItems.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuItems.Name = "MnuItems"
        Me.MnuItems.ShortcutKeyDisplayString = ""
        Me.MnuItems.Size = New System.Drawing.Size(270, 26)
        Me.MnuItems.Text = "بيان أوامر التوريد"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(267, 6)
        '
        'POs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1379, 800)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblSts)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DTP1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Pno1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DGready)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "POs"
        Me.Text = "POs"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGready, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents _MP As ToolStripMenuItem
    Friend WithEvents MnuNew As ToolStripMenuItem
    Friend WithEvents MnuSave As ToolStripMenuItem
    Friend WithEvents MnuEdit As ToolStripMenuItem
    Friend WithEvents MnuDel As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents _MPback As ToolStripMenuItem
    Friend WithEvents DGready As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Pno1 As TextBox
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblSts As Label
    Friend WithEvents InvTotal As DataGridViewTextBoxColumn
    Friend WithEvents InvDscnt As DataGridViewTextBoxColumn
    Friend WithEvents InvNet As DataGridViewTextBoxColumn
    Friend WithEvents InvPaid As DataGridViewTextBoxColumn
    Friend WithEvents InvRest As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents PID As DataGridViewTextBoxColumn
    Friend WithEvents Pname As DataGridViewTextBoxColumn
    Friend WithEvents Units As DataGridViewComboBoxColumn
    Friend WithEvents Label3 As Button
    Friend WithEvents MnuPrint As ToolStripMenuItem
    Friend WithEvents MnuLesItms As ToolStripMenuItem
    Friend WithEvents MnuItems As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
End Class
