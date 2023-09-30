<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Custms
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Custms))
        Me.CustDG = New System.Windows.Forms.DataGridView()
        Me.CustID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustNm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me._Cmenu = New System.Windows.Forms.ToolStripMenuItem()
        Me._CustN = New System.Windows.Forms.ToolStripMenuItem()
        Me._CustS = New System.Windows.Forms.ToolStripMenuItem()
        Me._CMedit = New System.Windows.Forms.ToolStripMenuItem()
        Me._CMdel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuDisp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me._CstPays = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDebts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me._Nback = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tsearch = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Tcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tmob = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ttel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tadd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Tnotes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblSt = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Tcredits = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.CustDG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CustDG
        '
        Me.CustDG.AllowUserToAddRows = False
        Me.CustDG.AllowUserToOrderColumns = True
        Me.CustDG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CustDG.BackgroundColor = System.Drawing.Color.Silver
        Me.CustDG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Traditional Arabic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CustDG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.CustDG.ColumnHeadersHeight = 50
        Me.CustDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.CustDG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CustID, Me.CustNm, Me.Mob, Me.Tel, Me.Address, Me.Notes})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.MediumSlateBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CustDG.DefaultCellStyle = DataGridViewCellStyle2
        Me.CustDG.EnableHeadersVisualStyles = False
        Me.CustDG.GridColor = System.Drawing.Color.DeepSkyBlue
        Me.CustDG.Location = New System.Drawing.Point(16, 114)
        Me.CustDG.Margin = New System.Windows.Forms.Padding(4)
        Me.CustDG.MultiSelect = False
        Me.CustDG.Name = "CustDG"
        Me.CustDG.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CustDG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CustDG.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.CustDG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.CustDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CustDG.Size = New System.Drawing.Size(885, 265)
        Me.CustDG.TabIndex = 53
        '
        'CustID
        '
        Me.CustID.DataPropertyName = "CustID"
        Me.CustID.HeaderText = "كود المورد"
        Me.CustID.Name = "CustID"
        Me.CustID.ReadOnly = True
        Me.CustID.Visible = False
        '
        'CustNm
        '
        Me.CustNm.DataPropertyName = "CustNm"
        Me.CustNm.HeaderText = "اسم العميل"
        Me.CustNm.Name = "CustNm"
        Me.CustNm.ReadOnly = True
        '
        'Mob
        '
        Me.Mob.DataPropertyName = "Mob"
        Me.Mob.HeaderText = "الموبيل"
        Me.Mob.Name = "Mob"
        Me.Mob.ReadOnly = True
        '
        'Tel
        '
        Me.Tel.DataPropertyName = "Tel"
        Me.Tel.HeaderText = "التليفون"
        Me.Tel.Name = "Tel"
        Me.Tel.ReadOnly = True
        '
        'Address
        '
        Me.Address.DataPropertyName = "Address"
        Me.Address.HeaderText = "العنوان"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'Notes
        '
        Me.Notes.DataPropertyName = "Notes"
        Me.Notes.HeaderText = "ملاحظات"
        Me.Notes.Name = "Notes"
        Me.Notes.ReadOnly = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DimGray
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.25!, System.Drawing.FontStyle.Bold)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Cmenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(1377, 51)
        Me.MenuStrip1.TabIndex = 57
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '_Cmenu
        '
        Me._Cmenu.BackColor = System.Drawing.Color.Transparent
        Me._Cmenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._CustN, Me._CustS, Me._CMedit, Me._CMdel, Me.ToolStripMenuItem3, Me.MnuDisp, Me.MnuPrint, Me.ToolStripMenuItem1, Me._CstPays, Me.MnuDebts, Me.ToolStripMenuItem2, Me._Nback})
        Me._Cmenu.Font = New System.Drawing.Font("Traditional Arabic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._Cmenu.Name = "_Cmenu"
        Me._Cmenu.Size = New System.Drawing.Size(84, 47)
        Me._Cmenu.Text = "العملاء"
        '
        '_CustN
        '
        Me._CustN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._CustN.AutoToolTip = True
        Me._CustN.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._CustN.Name = "_CustN"
        Me._CustN.ShortcutKeyDisplayString = "Ctrl+N"
        Me._CustN.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me._CustN.Size = New System.Drawing.Size(228, 26)
        Me._CustN.Text = "جديد"
        Me._CustN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_CustS
        '
        Me._CustS.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._CustS.Enabled = False
        Me._CustS.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._CustS.Name = "_CustS"
        Me._CustS.ShortcutKeyDisplayString = "Ctrl+S"
        Me._CustS.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me._CustS.Size = New System.Drawing.Size(228, 26)
        Me._CustS.Text = "حفظ"
        Me._CustS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_CMedit
        '
        Me._CMedit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._CMedit.Enabled = False
        Me._CMedit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._CMedit.Name = "_CMedit"
        Me._CMedit.ShortcutKeyDisplayString = "Ctrl+E"
        Me._CMedit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me._CMedit.Size = New System.Drawing.Size(228, 26)
        Me._CMedit.Text = "تعديل"
        Me._CMedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_CMdel
        '
        Me._CMdel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._CMdel.Enabled = False
        Me._CMdel.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._CMdel.Name = "_CMdel"
        Me._CMdel.ShortcutKeyDisplayString = "Del"
        Me._CMdel.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me._CMdel.Size = New System.Drawing.Size(228, 26)
        Me._CMdel.Text = "حذف"
        Me._CMdel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(225, 6)
        '
        'MnuDisp
        '
        Me.MnuDisp.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuDisp.Name = "MnuDisp"
        Me.MnuDisp.ShortcutKeyDisplayString = "F4"
        Me.MnuDisp.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.MnuDisp.Size = New System.Drawing.Size(228, 26)
        Me.MnuDisp.Text = "عرض الكل"
        '
        'MnuPrint
        '
        Me.MnuPrint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuPrint.Name = "MnuPrint"
        Me.MnuPrint.ShortcutKeyDisplayString = "Ctrl+P"
        Me.MnuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuPrint.Size = New System.Drawing.Size(228, 26)
        Me.MnuPrint.Text = "طباعة"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(225, 6)
        '
        '_CstPays
        '
        Me._CstPays.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._CstPays.Name = "_CstPays"
        Me._CstPays.ShortcutKeyDisplayString = ""
        Me._CstPays.Size = New System.Drawing.Size(228, 26)
        Me._CstPays.Text = "سداد العملاء"
        '
        'MnuDebts
        '
        Me.MnuDebts.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuDebts.Name = "MnuDebts"
        Me.MnuDebts.ShortcutKeyDisplayString = "F5"
        Me.MnuDebts.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MnuDebts.Size = New System.Drawing.Size(228, 26)
        Me.MnuDebts.Text = "اجمالي المديونية"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(225, 6)
        '
        '_Nback
        '
        Me._Nback.AutoToolTip = True
        Me._Nback.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._Nback.Name = "_Nback"
        Me._Nback.ShortcutKeyDisplayString = "Esc"
        Me._Nback.Size = New System.Drawing.Size(228, 26)
        Me._Nback.Text = "رجوع"
        Me._Nback.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Tsearch
        '
        Me.Tsearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tsearch.BackColor = System.Drawing.Color.Silver
        Me.Tsearch.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tsearch.Location = New System.Drawing.Point(445, 80)
        Me.Tsearch.Margin = New System.Windows.Forms.Padding(4)
        Me.Tsearch.Name = "Tsearch"
        Me.Tsearch.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Tsearch.Size = New System.Drawing.Size(316, 30)
        Me.Tsearch.TabIndex = 254
        Me.Tsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(769, 78)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label15.Size = New System.Drawing.Size(131, 32)
        Me.Label15.TabIndex = 255
        Me.Label15.Text = "بحث اسم العميل"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tcode
        '
        Me.Tcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tcode.BackColor = System.Drawing.Color.Silver
        Me.Tcode.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tcode.Location = New System.Drawing.Point(1152, 116)
        Me.Tcode.Margin = New System.Windows.Forms.Padding(4)
        Me.Tcode.Name = "Tcode"
        Me.Tcode.ReadOnly = True
        Me.Tcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tcode.Size = New System.Drawing.Size(73, 30)
        Me.Tcode.TabIndex = 257
        Me.Tcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1235, 116)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(131, 32)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "كود العميل"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tname
        '
        Me.Tname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tname.BackColor = System.Drawing.Color.Silver
        Me.Tname.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tname.Location = New System.Drawing.Point(909, 150)
        Me.Tname.Margin = New System.Windows.Forms.Padding(4)
        Me.Tname.Name = "Tname"
        Me.Tname.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tname.Size = New System.Drawing.Size(316, 30)
        Me.Tname.TabIndex = 259
        Me.Tname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1235, 150)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(131, 32)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "الاسم"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tmob
        '
        Me.Tmob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tmob.BackColor = System.Drawing.Color.Silver
        Me.Tmob.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tmob.Location = New System.Drawing.Point(1037, 185)
        Me.Tmob.Margin = New System.Windows.Forms.Padding(4)
        Me.Tmob.Name = "Tmob"
        Me.Tmob.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tmob.Size = New System.Drawing.Size(188, 30)
        Me.Tmob.TabIndex = 261
        Me.Tmob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1235, 185)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(131, 32)
        Me.Label3.TabIndex = 262
        Me.Label3.Text = "الموبيل"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Ttel
        '
        Me.Ttel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ttel.BackColor = System.Drawing.Color.Silver
        Me.Ttel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Ttel.Location = New System.Drawing.Point(1037, 219)
        Me.Ttel.Margin = New System.Windows.Forms.Padding(4)
        Me.Ttel.Name = "Ttel"
        Me.Ttel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Ttel.Size = New System.Drawing.Size(188, 30)
        Me.Ttel.TabIndex = 263
        Me.Ttel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1235, 219)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(131, 32)
        Me.Label4.TabIndex = 264
        Me.Label4.Text = "التليفون"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tadd
        '
        Me.Tadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tadd.BackColor = System.Drawing.Color.Silver
        Me.Tadd.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tadd.Location = New System.Drawing.Point(909, 254)
        Me.Tadd.Margin = New System.Windows.Forms.Padding(4)
        Me.Tadd.Multiline = True
        Me.Tadd.Name = "Tadd"
        Me.Tadd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tadd.Size = New System.Drawing.Size(316, 61)
        Me.Tadd.TabIndex = 267
        Me.Tadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1235, 254)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(131, 32)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "العنوان"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tnotes
        '
        Me.Tnotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tnotes.BackColor = System.Drawing.Color.Silver
        Me.Tnotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tnotes.Location = New System.Drawing.Point(909, 318)
        Me.Tnotes.Margin = New System.Windows.Forms.Padding(4)
        Me.Tnotes.Multiline = True
        Me.Tnotes.Name = "Tnotes"
        Me.Tnotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tnotes.Size = New System.Drawing.Size(316, 61)
        Me.Tnotes.TabIndex = 269
        Me.Tnotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1235, 316)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(131, 32)
        Me.Label7.TabIndex = 270
        Me.Label7.Text = "ملاحظات"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblSt
        '
        Me.LblSt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblSt.BackColor = System.Drawing.Color.DimGray
        Me.LblSt.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSt.ForeColor = System.Drawing.Color.White
        Me.LblSt.Location = New System.Drawing.Point(16, 383)
        Me.LblSt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSt.Name = "LblSt"
        Me.LblSt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LblSt.Size = New System.Drawing.Size(1349, 36)
        Me.LblSt.TabIndex = 373
        Me.LblSt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblSt.UseCompatibleTextRendering = True
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.Silver
        Me.TextBox4.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox4.Location = New System.Drawing.Point(1037, 548)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox4.Size = New System.Drawing.Size(188, 30)
        Me.TextBox4.TabIndex = 380
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1235, 548)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(131, 32)
        Me.Label10.TabIndex = 381
        Me.Label10.Text = "حجم التعامل"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.UseCompatibleTextRendering = True
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Silver
        Me.TextBox3.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox3.Location = New System.Drawing.Point(1037, 479)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox3.Size = New System.Drawing.Size(188, 30)
        Me.TextBox3.TabIndex = 378
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1235, 479)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(131, 32)
        Me.Label9.TabIndex = 379
        Me.Label9.Text = "عدد أوامر البيع"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.UseCompatibleTextRendering = True
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.Silver
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox2.Location = New System.Drawing.Point(1037, 444)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox2.Size = New System.Drawing.Size(188, 30)
        Me.TextBox2.TabIndex = 376
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(1235, 444)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(131, 32)
        Me.Label11.TabIndex = 377
        Me.Label11.Text = "مرتجعات المبيعات"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.UseCompatibleTextRendering = True
        '
        'Tcredits
        '
        Me.Tcredits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tcredits.BackColor = System.Drawing.Color.Silver
        Me.Tcredits.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tcredits.Location = New System.Drawing.Point(1037, 513)
        Me.Tcredits.Margin = New System.Windows.Forms.Padding(4)
        Me.Tcredits.Name = "Tcredits"
        Me.Tcredits.ReadOnly = True
        Me.Tcredits.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tcredits.Size = New System.Drawing.Size(188, 30)
        Me.Tcredits.TabIndex = 374
        Me.Tcredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(1235, 513)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(131, 32)
        Me.Label13.TabIndex = 375
        Me.Label13.Text = "اجمالي المديونية"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.UseCompatibleTextRendering = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Silver
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DimGray
        Me.Label17.Location = New System.Drawing.Point(65, 0)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 52)
        Me.Label17.TabIndex = 412
        Me.Label17.Text = "█"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label17.UseCompatibleTextRendering = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(1000, 514)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 31)
        Me.Button2.TabIndex = 382
        Me.Button2.Tag = "بحث الاصناف"
        Me.Button2.UseCompatibleTextRendering = True
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1000, 480)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(37, 31)
        Me.Button1.TabIndex = 413
        Me.Button1.Tag = "بحث الاصناف"
        Me.Button1.UseCompatibleTextRendering = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1000, 549)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(37, 31)
        Me.Button3.TabIndex = 414
        Me.Button3.Tag = "بحث الاصناف"
        Me.Button3.UseCompatibleTextRendering = True
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.Enabled = False
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button4.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(1000, 445)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(37, 29)
        Me.Button4.TabIndex = 415
        Me.Button4.Tag = "بحث الاصناف"
        Me.Button4.UseCompatibleTextRendering = True
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.Enabled = False
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button5.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Times New Roman", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(16, 545)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(37, 31)
        Me.Button5.TabIndex = 421
        Me.Button5.Tag = "بحث الاصناف"
        Me.Button5.UseCompatibleTextRendering = True
        Me.Button5.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.BackColor = System.Drawing.Color.Silver
        Me.TextBox5.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox5.Location = New System.Drawing.Point(53, 544)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox5.Size = New System.Drawing.Size(188, 30)
        Me.TextBox5.TabIndex = 419
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(251, 544)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(211, 32)
        Me.Label5.TabIndex = 420
        Me.Label5.Text = "اجمالي المستحق علي العملاء"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.UseCompatibleTextRendering = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(65, 383)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 36)
        Me.PictureBox1.TabIndex = 422
        Me.PictureBox1.TabStop = False
        '
        'Custms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1377, 591)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Tcredits)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LblSt)
        Me.Controls.Add(Me.Tnotes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Tadd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Ttel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Tmob)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Tname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Tcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tsearch)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CustDG)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Custms"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "بيانات العملاء"
        CType(Me.CustDG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CustDG As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents _Cmenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _Nback As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _CstPays As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tsearch As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents _CustN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _CustS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tmob As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Ttel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tadd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Tnotes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents _CMedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _CMdel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LblSt As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Tcredits As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents MnuDisp As ToolStripMenuItem
    Friend WithEvents Label17 As Label
    Friend WithEvents MnuPrint As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents MnuDebts As ToolStripMenuItem
    Friend WithEvents CustID As DataGridViewTextBoxColumn
    Friend WithEvents CustNm As DataGridViewTextBoxColumn
    Friend WithEvents Mob As DataGridViewTextBoxColumn
    Friend WithEvents Tel As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents Notes As DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As PictureBox
End Class
