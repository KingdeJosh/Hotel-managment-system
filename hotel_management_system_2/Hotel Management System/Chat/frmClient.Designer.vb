<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClient
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClient))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUrdu = New System.Windows.Forms.TextBox()
        Me.lblWelcome = New CloudToolkitN6.CloudLabel()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.btnSend = New CloudToolkitN6.CloudButton()
        Me.txtEnglish = New System.Windows.Forms.TextBox()
        Me.msgListBox = New System.Windows.Forms.ListBox()
        Me.btnOptions = New CloudToolkitN6.CloudButton()
        Me.btnConnectServer = New CloudToolkitN6.CloudButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnNotepad = New CloudToolkitN6.CloudDesktopButton()
        Me.btnPaint = New CloudToolkitN6.CloudDesktopButton()
        Me.btnCalc = New CloudToolkitN6.CloudDesktopButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CloudLabel5 = New CloudToolkitN6.CloudLabel()
        Me.btnSendFile = New CloudToolkitN6.CloudButton()
        Me.btnBrowse = New CloudToolkitN6.CloudButton()
        Me.sendFileText = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnClose = New CloudToolkitN6.CloudDesktopButton()
        Me.btnOpen = New CloudToolkitN6.CloudDesktopButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnConfirm = New CloudToolkitN6.CloudButton()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtUrdu)
        Me.GroupBox1.Controls.Add(Me.lblWelcome)
        Me.GroupBox1.Controls.Add(Me.btnColor)
        Me.GroupBox1.Controls.Add(Me.btnFont)
        Me.GroupBox1.Controls.Add(Me.btnSend)
        Me.GroupBox1.Controls.Add(Me.txtEnglish)
        Me.GroupBox1.Controls.Add(Me.msgListBox)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox1.Location = New System.Drawing.Point(5, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 347)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtUrdu
        '
        Me.txtUrdu.Location = New System.Drawing.Point(4, 244)
        Me.txtUrdu.Multiline = True
        Me.txtUrdu.Name = "txtUrdu"
        Me.txtUrdu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUrdu.Size = New System.Drawing.Size(280, 97)
        Me.txtUrdu.TabIndex = 75
        '
        'lblWelcome
        '
        Me.lblWelcome.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.BackColor = System.Drawing.Color.Transparent
        Me.lblWelcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.ForeColor = System.Drawing.Color.Transparent
        Me.lblWelcome.Location = New System.Drawing.Point(28, -28)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(85, 16)
        Me.lblWelcome.TabIndex = 74
        Me.lblWelcome.Text = "Welcome , "
        '
        'btnColor
        '
        Me.btnColor.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.ColorTheoryMixture
        Me.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnColor.Location = New System.Drawing.Point(37, 215)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(23, 23)
        Me.btnColor.TabIndex = 4
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'btnFont
        '
        Me.btnFont.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.ALetter
        Me.btnFont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFont.Location = New System.Drawing.Point(8, 215)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(23, 23)
        Me.btnFont.TabIndex = 3
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.Transparent
        Me.btnSend.ButtonText = "Send"
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.DisabledColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))}
        Me.btnSend.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.btnSend.Icon = Nothing
        Me.btnSend.IconAlign = CloudToolkitN6.CloudButton.IconBitmapAlign.Left
        Me.btnSend.IconSpacingX = 5
        Me.btnSend.IconSpacingY = 5
        Me.btnSend.IconTransparency = 0.0!
        Me.btnSend.Location = New System.Drawing.Point(290, 290)
        Me.btnSend.MouseDown_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(135, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(171, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(167, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(112, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(132, Byte), Integer))}
        Me.btnSend.MouseOn_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(113, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(182, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(217, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(133, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(151, Byte), Integer))}
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Normal_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(221, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))}
        Me.btnSend.Size = New System.Drawing.Size(65, 26)
        Me.btnSend.TabIndex = 2
        Me.btnSend.TextImageRelation = CloudToolkitN6.CloudButton.ButtonTextImageRelation.TextAboveImage
        Me.btnSend.TextSpacingX = 5
        Me.btnSend.TextSpacingY = 5
        '
        'txtEnglish
        '
        Me.txtEnglish.Location = New System.Drawing.Point(8, 244)
        Me.txtEnglish.Multiline = True
        Me.txtEnglish.Name = "txtEnglish"
        Me.txtEnglish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEnglish.Size = New System.Drawing.Size(258, 97)
        Me.txtEnglish.TabIndex = 1
        '
        'msgListBox
        '
        Me.msgListBox.BackColor = System.Drawing.Color.BurlyWood
        Me.msgListBox.FormattingEnabled = True
        Me.msgListBox.Location = New System.Drawing.Point(1, 10)
        Me.msgListBox.Name = "msgListBox"
        Me.msgListBox.ScrollAlwaysVisible = True
        Me.msgListBox.Size = New System.Drawing.Size(371, 199)
        Me.msgListBox.TabIndex = 0
        '
        'btnOptions
        '
        Me.btnOptions.BackColor = System.Drawing.Color.Transparent
        Me.btnOptions.ButtonText = "Show Options>>"
        Me.btnOptions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOptions.DisabledColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))}
        Me.btnOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.btnOptions.Icon = Nothing
        Me.btnOptions.IconAlign = CloudToolkitN6.CloudButton.IconBitmapAlign.Left
        Me.btnOptions.IconSpacingX = 5
        Me.btnOptions.IconSpacingY = 5
        Me.btnOptions.IconTransparency = 0.0!
        Me.btnOptions.Location = New System.Drawing.Point(4, 405)
        Me.btnOptions.MouseDown_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(135, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(171, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(167, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(112, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(132, Byte), Integer))}
        Me.btnOptions.MouseOn_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(113, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(182, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(217, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(133, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(151, Byte), Integer))}
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Normal_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(221, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))}
        Me.btnOptions.Size = New System.Drawing.Size(165, 33)
        Me.btnOptions.TabIndex = 2
        Me.btnOptions.TextImageRelation = CloudToolkitN6.CloudButton.ButtonTextImageRelation.TextAboveImage
        Me.btnOptions.TextSpacingX = 5
        Me.btnOptions.TextSpacingY = 5
        '
        'btnConnectServer
        '
        Me.btnConnectServer.BackColor = System.Drawing.Color.Transparent
        Me.btnConnectServer.ButtonText = "Connect To Main Server"
        Me.btnConnectServer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnectServer.DisabledColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))}
        Me.btnConnectServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.btnConnectServer.Icon = Nothing
        Me.btnConnectServer.IconAlign = CloudToolkitN6.CloudButton.IconBitmapAlign.Left
        Me.btnConnectServer.IconSpacingX = 5
        Me.btnConnectServer.IconSpacingY = 5
        Me.btnConnectServer.IconTransparency = 0.0!
        Me.btnConnectServer.Location = New System.Drawing.Point(181, 404)
        Me.btnConnectServer.MouseDown_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(135, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(171, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(167, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(112, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(132, Byte), Integer))}
        Me.btnConnectServer.MouseOn_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(113, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(182, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(217, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(133, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(151, Byte), Integer))}
        Me.btnConnectServer.Name = "btnConnectServer"
        Me.btnConnectServer.Normal_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(221, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))}
        Me.btnConnectServer.Size = New System.Drawing.Size(165, 33)
        Me.btnConnectServer.TabIndex = 3
        Me.btnConnectServer.TextImageRelation = CloudToolkitN6.CloudButton.ButtonTextImageRelation.TextAboveImage
        Me.btnConnectServer.TextSpacingX = 5
        Me.btnConnectServer.TextSpacingY = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TabControl1.Location = New System.Drawing.Point(4, 451)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(330, 119)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.videos_4_background
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.btnNotepad)
        Me.TabPage1.Controls.Add(Me.btnPaint)
        Me.TabPage1.Controls.Add(Me.btnCalc)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(322, 93)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tools"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnNotepad
        '
        Me.btnNotepad.AnimationSpeed = 5
        Me.btnNotepad.BackColor = System.Drawing.Color.Transparent
        Me.btnNotepad.BackgroundOpacity = 100
        Me.btnNotepad.BackgroundOpacity_MouseDown = 170
        Me.btnNotepad.BorderColor = System.Drawing.Color.White
        Me.btnNotepad.BorderOpacity = 170
        Me.btnNotepad.BorderWidth = 1
        Me.btnNotepad.ControlText = "Notepad"
        Me.btnNotepad.CornerRadius = 12
        Me.btnNotepad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNotepad.DrawBlackTextBackground = True
        Me.btnNotepad.FillColor = System.Drawing.Color.Azure
        Me.btnNotepad.ForeColor = System.Drawing.Color.White
        Me.btnNotepad.Icon = Global.Hotel_Management_System.My.Resources.Resources.Pencil
        Me.btnNotepad.Location = New System.Drawing.Point(139, 12)
        Me.btnNotepad.Name = "btnNotepad"
        Me.btnNotepad.Size = New System.Drawing.Size(54, 60)
        Me.btnNotepad.TabIndex = 2
        '
        'btnPaint
        '
        Me.btnPaint.AnimationSpeed = 5
        Me.btnPaint.BackColor = System.Drawing.Color.Transparent
        Me.btnPaint.BackgroundOpacity = 100
        Me.btnPaint.BackgroundOpacity_MouseDown = 170
        Me.btnPaint.BorderColor = System.Drawing.Color.White
        Me.btnPaint.BorderOpacity = 170
        Me.btnPaint.BorderWidth = 1
        Me.btnPaint.ControlText = "Paint"
        Me.btnPaint.CornerRadius = 12
        Me.btnPaint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPaint.DrawBlackTextBackground = True
        Me.btnPaint.FillColor = System.Drawing.Color.Azure
        Me.btnPaint.ForeColor = System.Drawing.Color.White
        Me.btnPaint.Icon = Global.Hotel_Management_System.My.Resources.Resources.Designer
        Me.btnPaint.Location = New System.Drawing.Point(66, 12)
        Me.btnPaint.Name = "btnPaint"
        Me.btnPaint.Size = New System.Drawing.Size(54, 60)
        Me.btnPaint.TabIndex = 1
        '
        'btnCalc
        '
        Me.btnCalc.AnimationSpeed = 5
        Me.btnCalc.BackColor = System.Drawing.Color.Transparent
        Me.btnCalc.BackgroundOpacity = 100
        Me.btnCalc.BackgroundOpacity_MouseDown = 170
        Me.btnCalc.BorderColor = System.Drawing.Color.White
        Me.btnCalc.BorderOpacity = 170
        Me.btnCalc.BorderWidth = 1
        Me.btnCalc.ControlText = "Calculator"
        Me.btnCalc.CornerRadius = 12
        Me.btnCalc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalc.DrawBlackTextBackground = True
        Me.btnCalc.FillColor = System.Drawing.Color.Azure
        Me.btnCalc.ForeColor = System.Drawing.Color.White
        Me.btnCalc.Icon = Global.Hotel_Management_System.My.Resources.Resources.Grid
        Me.btnCalc.Location = New System.Drawing.Point(6, 12)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(54, 60)
        Me.btnCalc.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.videos_4_background
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.CloudLabel5)
        Me.TabPage2.Controls.Add(Me.btnSendFile)
        Me.TabPage2.Controls.Add(Me.btnBrowse)
        Me.TabPage2.Controls.Add(Me.sendFileText)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(322, 93)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "File Transfer"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CloudLabel5
        '
        Me.CloudLabel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloudLabel5.AutoSize = True
        Me.CloudLabel5.BackColor = System.Drawing.Color.Transparent
        Me.CloudLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloudLabel5.ForeColor = System.Drawing.Color.Transparent
        Me.CloudLabel5.Location = New System.Drawing.Point(27, 14)
        Me.CloudLabel5.Name = "CloudLabel5"
        Me.CloudLabel5.Size = New System.Drawing.Size(63, 13)
        Me.CloudLabel5.TabIndex = 62
        Me.CloudLabel5.Text = "File Name"
        '
        'btnSendFile
        '
        Me.btnSendFile.BackColor = System.Drawing.Color.Transparent
        Me.btnSendFile.ButtonText = "Send File"
        Me.btnSendFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSendFile.DisabledColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))}
        Me.btnSendFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.btnSendFile.Icon = Nothing
        Me.btnSendFile.IconAlign = CloudToolkitN6.CloudButton.IconBitmapAlign.Left
        Me.btnSendFile.IconSpacingX = 5
        Me.btnSendFile.IconSpacingY = 5
        Me.btnSendFile.IconTransparency = 0.0!
        Me.btnSendFile.Location = New System.Drawing.Point(30, 56)
        Me.btnSendFile.MouseDown_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(135, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(171, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(167, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(112, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(132, Byte), Integer))}
        Me.btnSendFile.MouseOn_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(113, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(182, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(217, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(133, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(151, Byte), Integer))}
        Me.btnSendFile.Name = "btnSendFile"
        Me.btnSendFile.Normal_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(221, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))}
        Me.btnSendFile.Size = New System.Drawing.Size(74, 25)
        Me.btnSendFile.TabIndex = 4
        Me.btnSendFile.TextImageRelation = CloudToolkitN6.CloudButton.ButtonTextImageRelation.TextAboveImage
        Me.btnSendFile.TextSpacingX = 5
        Me.btnSendFile.TextSpacingY = 5
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.ButtonText = "Browse"
        Me.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowse.DisabledColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))}
        Me.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.btnBrowse.Icon = Nothing
        Me.btnBrowse.IconAlign = CloudToolkitN6.CloudButton.IconBitmapAlign.Left
        Me.btnBrowse.IconSpacingX = 5
        Me.btnBrowse.IconSpacingY = 5
        Me.btnBrowse.IconTransparency = 0.0!
        Me.btnBrowse.Location = New System.Drawing.Point(227, 27)
        Me.btnBrowse.MouseDown_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(135, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(171, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(167, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(112, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(132, Byte), Integer))}
        Me.btnBrowse.MouseOn_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(113, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(182, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(217, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(133, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(151, Byte), Integer))}
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Normal_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(221, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))}
        Me.btnBrowse.Size = New System.Drawing.Size(74, 25)
        Me.btnBrowse.TabIndex = 3
        Me.btnBrowse.TextImageRelation = CloudToolkitN6.CloudButton.ButtonTextImageRelation.TextAboveImage
        Me.btnBrowse.TextSpacingX = 5
        Me.btnBrowse.TextSpacingY = 5
        '
        'sendFileText
        '
        Me.sendFileText.Location = New System.Drawing.Point(30, 30)
        Me.sendFileText.Name = "sendFileText"
        Me.sendFileText.Size = New System.Drawing.Size(191, 20)
        Me.sendFileText.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.videos_4_background
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage3.Controls.Add(Me.btnClose)
        Me.TabPage3.Controls.Add(Me.btnOpen)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(322, 93)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "CD-Rom Options"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.AnimationSpeed = 5
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.BackgroundOpacity = 100
        Me.btnClose.BackgroundOpacity_MouseDown = 170
        Me.btnClose.BorderColor = System.Drawing.Color.White
        Me.btnClose.BorderOpacity = 170
        Me.btnClose.BorderWidth = 1
        Me.btnClose.ControlText = "Close"
        Me.btnClose.CornerRadius = 12
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.DrawBlackTextBackground = True
        Me.btnClose.FillColor = System.Drawing.Color.Azure
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Icon = Global.Hotel_Management_System.My.Resources.Resources.Delete
        Me.btnClose.Location = New System.Drawing.Point(156, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(54, 60)
        Me.btnClose.TabIndex = 3
        '
        'btnOpen
        '
        Me.btnOpen.AnimationSpeed = 5
        Me.btnOpen.BackColor = System.Drawing.Color.Transparent
        Me.btnOpen.BackgroundOpacity = 100
        Me.btnOpen.BackgroundOpacity_MouseDown = 170
        Me.btnOpen.BorderColor = System.Drawing.Color.White
        Me.btnOpen.BorderOpacity = 170
        Me.btnOpen.BorderWidth = 1
        Me.btnOpen.ControlText = "Open"
        Me.btnOpen.CornerRadius = 12
        Me.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpen.DrawBlackTextBackground = True
        Me.btnOpen.FillColor = System.Drawing.Color.Azure
        Me.btnOpen.ForeColor = System.Drawing.Color.White
        Me.btnOpen.Icon = Global.Hotel_Management_System.My.Resources.Resources.Yes
        Me.btnOpen.Location = New System.Drawing.Point(96, 16)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(54, 60)
        Me.btnOpen.TabIndex = 2
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.videos_4_background
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.btnConfirm)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Location = New System.Drawing.Point(7, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 40)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enter Your ChatName"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(6, 14)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(173, 20)
        Me.txtName.TabIndex = 0
        '
        'btnConfirm
        '
        Me.btnConfirm.BackColor = System.Drawing.Color.Transparent
        Me.btnConfirm.ButtonText = "Confirm"
        Me.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfirm.DisabledColors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(236, Byte), Integer))}
        Me.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.btnConfirm.Icon = Nothing
        Me.btnConfirm.IconAlign = CloudToolkitN6.CloudButton.IconBitmapAlign.Left
        Me.btnConfirm.IconSpacingX = 5
        Me.btnConfirm.IconSpacingY = 5
        Me.btnConfirm.IconTransparency = 0.0!
        Me.btnConfirm.Location = New System.Drawing.Point(191, 14)
        Me.btnConfirm.MouseDown_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(135, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(171, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(167, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(205, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(112, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(132, Byte), Integer))}
        Me.btnConfirm.MouseOn_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(113, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(182, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(217, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(133, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(77, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(151, Byte), Integer))}
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Normal_Colors = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(207, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(212, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(188, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(221, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(253, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(249, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(244, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(253, Byte), Integer))}
        Me.btnConfirm.Size = New System.Drawing.Size(118, 20)
        Me.btnConfirm.TabIndex = 64
        Me.btnConfirm.TextImageRelation = CloudToolkitN6.CloudButton.ButtonTextImageRelation.TextAboveImage
        Me.btnConfirm.TextSpacingX = 5
        Me.btnConfirm.TextSpacingY = 5
        '
        'frmClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.videos_4_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(395, 571)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnConnectServer)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents msgListBox As System.Windows.Forms.ListBox
    Friend WithEvents txtEnglish As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As CloudToolkitN6.CloudButton
    Friend WithEvents btnOptions As CloudToolkitN6.CloudButton
    Friend WithEvents btnConnectServer As CloudToolkitN6.CloudButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnCalc As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnPaint As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnNotepad As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents sendFileText As System.Windows.Forms.TextBox
    Friend WithEvents btnSendFile As CloudToolkitN6.CloudButton
    Friend WithEvents btnBrowse As CloudToolkitN6.CloudButton
    Friend WithEvents CloudLabel5 As CloudToolkitN6.CloudLabel
    Friend WithEvents btnClose As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnOpen As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirm As CloudToolkitN6.CloudButton
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents lblWelcome As CloudToolkitN6.CloudLabel
    Friend WithEvents txtUrdu As System.Windows.Forms.TextBox


End Class
