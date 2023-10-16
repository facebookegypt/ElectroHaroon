<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItemsFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemsFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me._MP = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuPOrdrs = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuDisp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuUnt = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuStr = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuKnd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me._MPback = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CboStores = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tsrch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CboNm = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DGready = New System.Windows.Forms.DataGridView()
        Me.PID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pdesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pcost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FrstQnty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinQ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pnotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kinds = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.GsellPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stores = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGready, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1257, 55)
        Me.MenuStrip1.TabIndex = 306
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '_MP
        '
        Me._MP.BackColor = System.Drawing.Color.Transparent
        Me._MP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuNew, Me.MnuSave, Me.MnuEdit, Me.MnuDel, Me.ToolStripMenuItem1, Me.MnuPOrdrs, Me.MnuDisp, Me.ToolStripMenuItem2, Me.MnuUnt, Me.MnuStr, Me.MnuKnd, Me.ToolStripMenuItem3, Me._MPback})
        Me._MP.Font = New System.Drawing.Font("Traditional Arabic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._MP.ForeColor = System.Drawing.Color.Brown
        Me._MP.Name = "_MP"
        Me._MP.Padding = New System.Windows.Forms.Padding(40, 0, 4, 0)
        Me._MP.Size = New System.Drawing.Size(140, 51)
        Me._MP.Text = "الأصناف"
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
        Me.MnuSave.Size = New System.Drawing.Size(243, 26)
        Me.MnuSave.Text = "حفظ أصناف"
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
        'MnuPOrdrs
        '
        Me.MnuPOrdrs.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuPOrdrs.Name = "MnuPOrdrs"
        Me.MnuPOrdrs.Size = New System.Drawing.Size(243, 26)
        Me.MnuPOrdrs.Text = "أوامر الشراء"
        '
        'MnuDisp
        '
        Me.MnuDisp.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuDisp.Name = "MnuDisp"
        Me.MnuDisp.ShortcutKeyDisplayString = "F5"
        Me.MnuDisp.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MnuDisp.Size = New System.Drawing.Size(243, 26)
        Me.MnuDisp.Text = "عرض كل الأصناف"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(240, 6)
        '
        'MnuUnt
        '
        Me.MnuUnt.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuUnt.Name = "MnuUnt"
        Me.MnuUnt.Size = New System.Drawing.Size(243, 26)
        Me.MnuUnt.Text = "اضافة وحدة"
        '
        'MnuStr
        '
        Me.MnuStr.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuStr.Name = "MnuStr"
        Me.MnuStr.Size = New System.Drawing.Size(243, 26)
        Me.MnuStr.Text = "اضافة مخزن"
        '
        'MnuKnd
        '
        Me.MnuKnd.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuKnd.Name = "MnuKnd"
        Me.MnuKnd.Size = New System.Drawing.Size(243, 26)
        Me.MnuKnd.Text = "اضافة نوع"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(240, 6)
        '
        '_MPback
        '
        Me._MPback.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._MPback.Name = "_MPback"
        Me._MPback.ShortcutKeyDisplayString = "Esc"
        Me._MPback.Size = New System.Drawing.Size(243, 26)
        Me._MPback.Text = "رجوع"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CboStores)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Tsrch)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBox7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.CboNm)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 59)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(1231, 156)
        Me.GroupBox1.TabIndex = 371
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات أساسية"
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
        Me.Button1.Location = New System.Drawing.Point(516, 117)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 29)
        Me.Button1.TabIndex = 442
        Me.Button1.UseCompatibleTextRendering = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CboStores
        '
        Me.CboStores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboStores.BackColor = System.Drawing.Color.AliceBlue
        Me.CboStores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboStores.Font = New System.Drawing.Font("Tahoma", 10.5!, System.Drawing.FontStyle.Bold)
        Me.CboStores.ForeColor = System.Drawing.Color.Black
        Me.CboStores.FormattingEnabled = True
        Me.CboStores.Items.AddRange(New Object() {"نقدي", "فيزا"})
        Me.CboStores.Location = New System.Drawing.Point(559, 117)
        Me.CboStores.Margin = New System.Windows.Forms.Padding(4)
        Me.CboStores.Name = "CboStores"
        Me.CboStores.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CboStores.Size = New System.Drawing.Size(145, 29)
        Me.CboStores.TabIndex = 440
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.AliceBlue
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(712, 116)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 31)
        Me.Label9.TabIndex = 441
        Me.Label9.Text = "المخزن"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label9.UseCompatibleTextRendering = True
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox2.Font = New System.Drawing.Font("Traditional Arabic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(846, 67)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(108, 37)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "0"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoEllipsis = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.Location = New System.Drawing.Point(846, 34)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 29)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "رصيد أول المدة"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tsrch
        '
        Me.Tsrch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tsrch.BackColor = System.Drawing.Color.Gainsboro
        Me.Tsrch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Tsrch.Font = New System.Drawing.Font("Traditional Arabic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Tsrch.Location = New System.Drawing.Point(911, 121)
        Me.Tsrch.Margin = New System.Windows.Forms.Padding(4)
        Me.Tsrch.Name = "Tsrch"
        Me.Tsrch.Size = New System.Drawing.Size(262, 30)
        Me.Tsrch.TabIndex = 7
        Me.Tsrch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoEllipsis = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(1181, 121)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 31)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "بحث"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox7.Font = New System.Drawing.Font("Traditional Arabic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(71, 69)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(169, 77)
        Me.TextBox7.TabIndex = 6
        Me.TextBox7.Text = "لا يوجد"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoEllipsis = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.Location = New System.Drawing.Point(71, 34)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(169, 29)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "ملاحظات"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboNm
        '
        Me.CboNm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CboNm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboNm.Font = New System.Drawing.Font("Traditional Arabic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CboNm.Location = New System.Drawing.Point(962, 67)
        Me.CboNm.Margin = New System.Windows.Forms.Padding(4)
        Me.CboNm.Name = "CboNm"
        Me.CboNm.Size = New System.Drawing.Size(262, 37)
        Me.CboNm.TabIndex = 1
        Me.CboNm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox6.Font = New System.Drawing.Font("Traditional Arabic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(559, 67)
        Me.TextBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(165, 37)
        Me.TextBox6.TabIndex = 4
        Me.TextBox6.Text = "0.00 جنية"
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoEllipsis = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(559, 34)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 29)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "تكلفة الوحدة"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox5.Font = New System.Drawing.Font("Traditional Arabic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(732, 67)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(106, 37)
        Me.TextBox5.TabIndex = 3
        Me.TextBox5.Text = "1"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoEllipsis = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.Location = New System.Drawing.Point(732, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 29)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "أقل كمية"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox4.Font = New System.Drawing.Font("Traditional Arabic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(425, 67)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(126, 37)
        Me.TextBox4.TabIndex = 33
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoEllipsis = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(425, 32)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 32)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "رقم باركود"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBox3.Font = New System.Drawing.Font("Traditional Arabic", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(248, 69)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(169, 77)
        Me.TextBox3.TabIndex = 5
        Me.TextBox3.Text = "لا يوجد"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoEllipsis = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(248, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 29)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "وصف الصنف"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoEllipsis = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(962, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "اسم الصنف"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.DimGray
        Me.Label17.Location = New System.Drawing.Point(63, 0)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 56)
        Me.Label17.TabIndex = 410
        Me.Label17.Text = "█"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label17.UseCompatibleTextRendering = True
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(13, 0)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 56)
        Me.Label18.TabIndex = 409
        Me.Label18.Text = "▄"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label18.UseCompatibleTextRendering = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.Snow
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Brown
        Me.TextBox1.Location = New System.Drawing.Point(155, 670)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.MaxLength = 20
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(1089, 35)
        Me.TextBox1.TabIndex = 413
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.WordWrap = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(267, 665)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(47, 45)
        Me.PictureBox1.TabIndex = 423
        Me.PictureBox1.TabStop = False
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Azure
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGready.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGready.ColumnHeadersHeight = 50
        Me.DGready.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGready.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PID, Me.Pname, Me.Pdesc, Me.Pcost, Me.FrstQnty, Me.MinQ, Me.BarCode, Me.Pnotes, Me.Kinds, Me.GsellPrice, Me.Stores})
        Me.DGready.EnableHeadersVisualStyles = False
        Me.DGready.GridColor = System.Drawing.Color.DeepSkyBlue
        Me.DGready.Location = New System.Drawing.Point(13, 218)
        Me.DGready.Margin = New System.Windows.Forms.Padding(4)
        Me.DGready.MultiSelect = False
        Me.DGready.Name = "DGready"
        Me.DGready.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGready.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Traditional Arabic", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGready.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGready.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGready.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGready.Size = New System.Drawing.Size(1231, 444)
        Me.DGready.TabIndex = 425
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
        'Pdesc
        '
        Me.Pdesc.DataPropertyName = "Pdesc"
        Me.Pdesc.HeaderText = "وصف الصنف"
        Me.Pdesc.Name = "Pdesc"
        Me.Pdesc.ReadOnly = True
        '
        'Pcost
        '
        Me.Pcost.DataPropertyName = "Pcost"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0.00"
        Me.Pcost.DefaultCellStyle = DataGridViewCellStyle2
        Me.Pcost.HeaderText = "تكلفة الوحدة"
        Me.Pcost.Name = "Pcost"
        Me.Pcost.ReadOnly = True
        '
        'FrstQnty
        '
        Me.FrstQnty.DataPropertyName = "FrstQnty"
        Me.FrstQnty.HeaderText = "رصيد أول المدة"
        Me.FrstQnty.Name = "FrstQnty"
        Me.FrstQnty.ReadOnly = True
        '
        'MinQ
        '
        Me.MinQ.DataPropertyName = "MinQ"
        Me.MinQ.HeaderText = "حد الطلب"
        Me.MinQ.Name = "MinQ"
        Me.MinQ.ReadOnly = True
        '
        'BarCode
        '
        Me.BarCode.DataPropertyName = "BarCode"
        Me.BarCode.HeaderText = "باركود"
        Me.BarCode.Name = "BarCode"
        Me.BarCode.ReadOnly = True
        '
        'Pnotes
        '
        Me.Pnotes.DataPropertyName = "Pnotes"
        Me.Pnotes.HeaderText = "ملاحظات"
        Me.Pnotes.Name = "Pnotes"
        Me.Pnotes.ReadOnly = True
        '
        'Kinds
        '
        Me.Kinds.DataPropertyName = "KindID"
        Me.Kinds.HeaderText = "أسعار البيع"
        Me.Kinds.Name = "Kinds"
        '
        'GsellPrice
        '
        Me.GsellPrice.DataPropertyName = "GsellPrice"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.GsellPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.GsellPrice.HeaderText = "السعر"
        Me.GsellPrice.Name = "GsellPrice"
        Me.GsellPrice.ReadOnly = True
        '
        'Stores
        '
        Me.Stores.DataPropertyName = "Stores"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.NullValue = "اختر المخزن"
        Me.Stores.DefaultCellStyle = DataGridViewCellStyle4
        Me.Stores.HeaderText = "المخزن"
        Me.Stores.Name = "Stores"
        Me.Stores.ReadOnly = True
        '
        'ItemsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1257, 718)
        Me.Controls.Add(Me.DGready)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ItemsFrm"
        Me.Text = "الأصناف"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGready, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents _MP As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents _MPback As ToolStripMenuItem
    Friend WithEvents MnuSave As ToolStripMenuItem
    Friend WithEvents MnuNew As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents MnuUnt As ToolStripMenuItem
    Friend WithEvents MnuStr As ToolStripMenuItem
    Friend WithEvents MnuKnd As ToolStripMenuItem
    Friend WithEvents MnuPOrdrs As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents MnuDisp As ToolStripMenuItem
    Friend WithEvents MnuDel As ToolStripMenuItem
    Friend WithEvents MnuEdit As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CboNm As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents DGready As DataGridView
    Friend WithEvents Tsrch As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CboStores As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents PID As DataGridViewTextBoxColumn
    Friend WithEvents Pname As DataGridViewTextBoxColumn
    Friend WithEvents Pdesc As DataGridViewTextBoxColumn
    Friend WithEvents Pcost As DataGridViewTextBoxColumn
    Friend WithEvents FrstQnty As DataGridViewTextBoxColumn
    Friend WithEvents MinQ As DataGridViewTextBoxColumn
    Friend WithEvents BarCode As DataGridViewTextBoxColumn
    Friend WithEvents Pnotes As DataGridViewTextBoxColumn
    Friend WithEvents Kinds As DataGridViewComboBoxColumn
    Friend WithEvents GsellPrice As DataGridViewTextBoxColumn
    Friend WithEvents Stores As DataGridViewComboBoxColumn
End Class
