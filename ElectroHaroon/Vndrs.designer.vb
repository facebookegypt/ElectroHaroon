<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Vndrs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Vndrs))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me._MV = New System.Windows.Forms.MenuStrip()
        Me._VenDisp = New System.Windows.Forms.ToolStripMenuItem()
        Me._Vadd = New System.Windows.Forms.ToolStripMenuItem()
        Me._Vsave = New System.Windows.Forms.ToolStripMenuItem()
        Me._Vedit = New System.Windows.Forms.ToolStripMenuItem()
        Me._Vdel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me._Disp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me._DispUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me._nmExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tnotes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Tadd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Ttel = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Tmob = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Tname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblSt = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.VendG = New System.Windows.Forms.DataGridView()
        Me.VenID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VendNm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tsearch = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me._MV.SuspendLayout()
        CType(Me.VendG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_MV
        '
        Me._MV.BackColor = System.Drawing.Color.DimGray
        Me._MV.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me._MV.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._VenDisp})
        Me._MV.Location = New System.Drawing.Point(0, 0)
        Me._MV.Name = "_MV"
        Me._MV.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me._MV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me._MV.ShowItemToolTips = True
        Me._MV.Size = New System.Drawing.Size(1377, 51)
        Me._MV.TabIndex = 58
        Me._MV.Text = "MenuStrip1"
        '
        '_VenDisp
        '
        Me._VenDisp.BackColor = System.Drawing.Color.Transparent
        Me._VenDisp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._Vadd, Me._Vsave, Me._Vedit, Me._Vdel, Me.ToolStripMenuItem1, Me._Disp, Me.ToolStripMenuItem3, Me._DispUp, Me.ToolStripMenuItem2, Me.MnuShow, Me.MnuPrint, Me.ToolStripMenuItem4, Me._nmExit})
        Me._VenDisp.Font = New System.Drawing.Font("Traditional Arabic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me._VenDisp.Name = "_VenDisp"
        Me._VenDisp.Size = New System.Drawing.Size(89, 47)
        Me._VenDisp.Text = "الموردين"
        '
        '_Vadd
        '
        Me._Vadd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._Vadd.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._Vadd.Name = "_Vadd"
        Me._Vadd.RightToLeftAutoMirrorImage = True
        Me._Vadd.ShortcutKeyDisplayString = "Ctrl+N"
        Me._Vadd.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me._Vadd.Size = New System.Drawing.Size(228, 26)
        Me._Vadd.Text = "جديد"
        '
        '_Vsave
        '
        Me._Vsave.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._Vsave.AutoToolTip = True
        Me._Vsave.Enabled = False
        Me._Vsave.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._Vsave.Name = "_Vsave"
        Me._Vsave.RightToLeftAutoMirrorImage = True
        Me._Vsave.ShortcutKeyDisplayString = "Ctrl+S"
        Me._Vsave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me._Vsave.Size = New System.Drawing.Size(228, 26)
        Me._Vsave.Text = "حفظ"
        '
        '_Vedit
        '
        Me._Vedit.AutoToolTip = True
        Me._Vedit.Enabled = False
        Me._Vedit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._Vedit.Name = "_Vedit"
        Me._Vedit.RightToLeftAutoMirrorImage = True
        Me._Vedit.ShortcutKeyDisplayString = "Ctrl+E"
        Me._Vedit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me._Vedit.Size = New System.Drawing.Size(228, 26)
        Me._Vedit.Text = "تعديل"
        '
        '_Vdel
        '
        Me._Vdel.AutoToolTip = True
        Me._Vdel.Enabled = False
        Me._Vdel.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._Vdel.Name = "_Vdel"
        Me._Vdel.RightToLeftAutoMirrorImage = True
        Me._Vdel.ShortcutKeyDisplayString = "Del"
        Me._Vdel.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me._Vdel.Size = New System.Drawing.Size(228, 26)
        Me._Vdel.Text = "حذف"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(225, 6)
        '
        '_Disp
        '
        Me._Disp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._Disp.AutoToolTip = True
        Me._Disp.Enabled = False
        Me._Disp.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._Disp.Name = "_Disp"
        Me._Disp.RightToLeftAutoMirrorImage = True
        Me._Disp.ShortcutKeyDisplayString = ""
        Me._Disp.Size = New System.Drawing.Size(228, 26)
        Me._Disp.Text = "مدفوعات للموردين"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(225, 6)
        '
        '_DispUp
        '
        Me._DispUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me._DispUp.AutoToolTip = True
        Me._DispUp.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._DispUp.Name = "_DispUp"
        Me._DispUp.RightToLeftAutoMirrorImage = True
        Me._DispUp.ShortcutKeyDisplayString = "F5"
        Me._DispUp.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me._DispUp.Size = New System.Drawing.Size(228, 26)
        Me._DispUp.Text = "اجمالي المديونيه"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(225, 6)
        '
        'MnuShow
        '
        Me.MnuShow.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuShow.Name = "MnuShow"
        Me.MnuShow.ShortcutKeyDisplayString = "F4"
        Me.MnuShow.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.MnuShow.Size = New System.Drawing.Size(228, 26)
        Me.MnuShow.Text = "عرض الكل"
        '
        'MnuPrint
        '
        Me.MnuPrint.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.MnuPrint.Name = "MnuPrint"
        Me.MnuPrint.ShortcutKeyDisplayString = "Ctrl+P"
        Me.MnuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.MnuPrint.Size = New System.Drawing.Size(228, 26)
        Me.MnuPrint.Text = "طباعه"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(225, 6)
        '
        '_nmExit
        '
        Me._nmExit.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me._nmExit.Name = "_nmExit"
        Me._nmExit.ShortcutKeyDisplayString = "Esc"
        Me._nmExit.Size = New System.Drawing.Size(228, 26)
        Me._nmExit.Text = "خروج"
        '
        'Tnotes
        '
        Me.Tnotes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tnotes.BackColor = System.Drawing.Color.Silver
        Me.Tnotes.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tnotes.Location = New System.Drawing.Point(908, 310)
        Me.Tnotes.Margin = New System.Windows.Forms.Padding(4)
        Me.Tnotes.Multiline = True
        Me.Tnotes.Name = "Tnotes"
        Me.Tnotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tnotes.Size = New System.Drawing.Size(313, 61)
        Me.Tnotes.TabIndex = 285
        Me.Tnotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.Color.DimGray
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1231, 310)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(131, 32)
        Me.Label7.TabIndex = 286
        Me.Label7.Text = "ملاحظات"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.UseCompatibleTextRendering = True
        '
        'Tadd
        '
        Me.Tadd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tadd.BackColor = System.Drawing.Color.Silver
        Me.Tadd.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tadd.Location = New System.Drawing.Point(908, 245)
        Me.Tadd.Margin = New System.Windows.Forms.Padding(4)
        Me.Tadd.Multiline = True
        Me.Tadd.Name = "Tadd"
        Me.Tadd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tadd.Size = New System.Drawing.Size(313, 61)
        Me.Tadd.TabIndex = 283
        Me.Tadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.Color.DimGray
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1231, 245)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(131, 32)
        Me.Label6.TabIndex = 284
        Me.Label6.Text = "العنوان"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.UseCompatibleTextRendering = True
        '
        'Ttel
        '
        Me.Ttel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ttel.BackColor = System.Drawing.Color.Silver
        Me.Ttel.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Ttel.Location = New System.Drawing.Point(1033, 210)
        Me.Ttel.Margin = New System.Windows.Forms.Padding(4)
        Me.Ttel.Name = "Ttel"
        Me.Ttel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Ttel.Size = New System.Drawing.Size(188, 30)
        Me.Ttel.TabIndex = 279
        Me.Ttel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.DimGray
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1231, 210)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(131, 32)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "التليفون"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label4.UseCompatibleTextRendering = True
        '
        'Tmob
        '
        Me.Tmob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tmob.BackColor = System.Drawing.Color.Silver
        Me.Tmob.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tmob.Location = New System.Drawing.Point(1033, 176)
        Me.Tmob.Margin = New System.Windows.Forms.Padding(4)
        Me.Tmob.Name = "Tmob"
        Me.Tmob.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tmob.Size = New System.Drawing.Size(188, 30)
        Me.Tmob.TabIndex = 277
        Me.Tmob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.DimGray
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1231, 176)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(131, 32)
        Me.Label3.TabIndex = 278
        Me.Label3.Text = "الموبيل"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.UseCompatibleTextRendering = True
        '
        'Tname
        '
        Me.Tname.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tname.BackColor = System.Drawing.Color.Silver
        Me.Tname.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tname.Location = New System.Drawing.Point(908, 142)
        Me.Tname.Margin = New System.Windows.Forms.Padding(4)
        Me.Tname.Name = "Tname"
        Me.Tname.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tname.Size = New System.Drawing.Size(313, 30)
        Me.Tname.TabIndex = 275
        Me.Tname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1231, 142)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(131, 32)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "الاسم"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Tcode
        '
        Me.Tcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tcode.BackColor = System.Drawing.Color.Silver
        Me.Tcode.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tcode.Location = New System.Drawing.Point(1148, 107)
        Me.Tcode.Margin = New System.Windows.Forms.Padding(4)
        Me.Tcode.Name = "Tcode"
        Me.Tcode.ReadOnly = True
        Me.Tcode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tcode.Size = New System.Drawing.Size(73, 30)
        Me.Tcode.TabIndex = 273
        Me.Tcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1231, 107)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(131, 32)
        Me.Label1.TabIndex = 274
        Me.Label1.Text = "كود المورد"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.UseCompatibleTextRendering = True
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.DimGray
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(769, 71)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(131, 32)
        Me.Label15.TabIndex = 290
        Me.Label15.Text = "بحث اسم المورد"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.UseCompatibleTextRendering = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.Silver
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox1.Location = New System.Drawing.Point(1033, 510)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox1.Size = New System.Drawing.Size(188, 30)
        Me.TextBox1.TabIndex = 291
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.DimGray
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1231, 510)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(131, 32)
        Me.Label5.TabIndex = 292
        Me.Label5.Text = "اجمالي مستحق له"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.UseCompatibleTextRendering = True
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.BackColor = System.Drawing.Color.Silver
        Me.TextBox2.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox2.Location = New System.Drawing.Point(1033, 441)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox2.Size = New System.Drawing.Size(188, 30)
        Me.TextBox2.TabIndex = 293
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.DimGray
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(1231, 441)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(131, 32)
        Me.Label8.TabIndex = 294
        Me.Label8.Text = "مردودات مشتريات"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.UseCompatibleTextRendering = True
        '
        'lblSt
        '
        Me.lblSt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSt.BackColor = System.Drawing.Color.DimGray
        Me.lblSt.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSt.ForeColor = System.Drawing.Color.White
        Me.lblSt.Location = New System.Drawing.Point(16, 375)
        Me.lblSt.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSt.Name = "lblSt"
        Me.lblSt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblSt.Size = New System.Drawing.Size(1345, 36)
        Me.lblSt.TabIndex = 295
        Me.lblSt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblSt.UseCompatibleTextRendering = True
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.BackColor = System.Drawing.Color.Silver
        Me.TextBox3.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox3.Location = New System.Drawing.Point(1033, 475)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox3.Size = New System.Drawing.Size(188, 30)
        Me.TextBox3.TabIndex = 296
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.Color.DimGray
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1231, 475)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(131, 32)
        Me.Label9.TabIndex = 297
        Me.Label9.Text = "عدد أوامر الشراء"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.UseCompatibleTextRendering = True
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.BackColor = System.Drawing.Color.Silver
        Me.TextBox4.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox4.Location = New System.Drawing.Point(1033, 544)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox4.Size = New System.Drawing.Size(188, 30)
        Me.TextBox4.TabIndex = 298
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.BackColor = System.Drawing.Color.DimGray
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1231, 544)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(131, 32)
        Me.Label10.TabIndex = 299
        Me.Label10.Text = "حجم التعامل"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label10.UseCompatibleTextRendering = True
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
        Me.Button2.Location = New System.Drawing.Point(996, 511)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 31)
        Me.Button2.TabIndex = 300
        Me.Button2.Tag = "بحث الاصناف"
        Me.Button2.UseCompatibleTextRendering = True
        Me.Button2.UseVisualStyleBackColor = False
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
        Me.Button1.Location = New System.Drawing.Point(996, 545)
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
        Me.Button3.Location = New System.Drawing.Point(996, 476)
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
        Me.Button4.Location = New System.Drawing.Point(996, 442)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(37, 31)
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
        Me.Button5.Location = New System.Drawing.Point(16, 539)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(37, 31)
        Me.Button5.TabIndex = 418
        Me.Button5.Tag = "بحث الاصناف"
        Me.Button5.UseCompatibleTextRendering = True
        Me.Button5.UseVisualStyleBackColor = False
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.BackColor = System.Drawing.Color.Silver
        Me.TextBox5.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.TextBox5.Location = New System.Drawing.Point(53, 540)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox5.Size = New System.Drawing.Size(188, 30)
        Me.TextBox5.TabIndex = 416
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.DimGray
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(251, 540)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(196, 32)
        Me.Label11.TabIndex = 417
        Me.Label11.Text = "اجمالي المستحق للموردين"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.UseCompatibleTextRendering = True
        '
        'VendG
        '
        Me.VendG.AllowUserToAddRows = False
        Me.VendG.AllowUserToOrderColumns = True
        Me.VendG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VendG.BackgroundColor = System.Drawing.Color.Silver
        Me.VendG.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Traditional Arabic", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VendG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.VendG.ColumnHeadersHeight = 50
        Me.VendG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.VendG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VenID, Me.VendNm, Me.Mob, Me.Tel, Me.Address, Me.Notes})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.MediumSlateBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.VendG.DefaultCellStyle = DataGridViewCellStyle2
        Me.VendG.EnableHeadersVisualStyles = False
        Me.VendG.GridColor = System.Drawing.Color.DeepSkyBlue
        Me.VendG.Location = New System.Drawing.Point(16, 107)
        Me.VendG.Margin = New System.Windows.Forms.Padding(4)
        Me.VendG.MultiSelect = False
        Me.VendG.Name = "VendG"
        Me.VendG.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.VendG.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MintCream
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VendG.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.VendG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.VendG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.VendG.Size = New System.Drawing.Size(884, 265)
        Me.VendG.TabIndex = 419
        '
        'VenID
        '
        Me.VenID.DataPropertyName = "VenID"
        Me.VenID.HeaderText = "كود المورد"
        Me.VenID.Name = "VenID"
        Me.VenID.ReadOnly = True
        Me.VenID.Visible = False
        '
        'VendNm
        '
        Me.VendNm.DataPropertyName = "VendNm"
        Me.VendNm.HeaderText = "اسم المورد"
        Me.VendNm.Name = "VendNm"
        Me.VendNm.ReadOnly = True
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
        'Tsearch
        '
        Me.Tsearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tsearch.BackColor = System.Drawing.Color.Silver
        Me.Tsearch.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.Tsearch.Location = New System.Drawing.Point(445, 73)
        Me.Tsearch.Margin = New System.Windows.Forms.Padding(4)
        Me.Tsearch.Name = "Tsearch"
        Me.Tsearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Tsearch.Size = New System.Drawing.Size(316, 30)
        Me.Tsearch.TabIndex = 420
        Me.Tsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Location = New System.Drawing.Point(65, 375)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 36)
        Me.PictureBox1.TabIndex = 423
        Me.PictureBox1.TabStop = False
        '
        'Vndrs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1377, 587)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Tsearch)
        Me.Controls.Add(Me.VendG)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblSt)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label15)
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
        Me.Controls.Add(Me._MV)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me._MV
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Vndrs"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بيانات الموردين"
        Me._MV.ResumeLayout(False)
        Me._MV.PerformLayout()
        CType(Me.VendG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents _MV As System.Windows.Forms.MenuStrip
    Friend WithEvents _VenDisp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _Disp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _DispUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents _nmExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tnotes As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Tadd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Ttel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Tmob As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Tname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Tcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents _Vadd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _Vsave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _Vedit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents _Vdel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSt As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents MnuShow As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents Label17 As Label
    Friend WithEvents MnuPrint As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents VendG As DataGridView
    Friend WithEvents Tsearch As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents VenID As DataGridViewTextBoxColumn
    Friend WithEvents VendNm As DataGridViewTextBoxColumn
    Friend WithEvents Mob As DataGridViewTextBoxColumn
    Friend WithEvents Tel As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents Notes As DataGridViewTextBoxColumn
End Class
