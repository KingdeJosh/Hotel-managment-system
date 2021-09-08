<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServer))
        Me.lblStatus = New CloudToolkitN6.CloudLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSend = New CloudToolkitN6.Windows.Vista.CloudStartMenuButton()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.btnFont = New System.Windows.Forms.Button()
        Me.txtEnglish = New System.Windows.Forms.TextBox()
        Me.txtUrdu = New System.Windows.Forms.TextBox()
        Me.messagesListBox = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnShutdown = New CloudToolkitN6.CloudDesktopButton()
        Me.btnRestart = New CloudToolkitN6.CloudDesktopButton()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnMsPaint = New CloudToolkitN6.CloudDesktopButton()
        Me.btnNote = New CloudToolkitN6.CloudDesktopButton()
        Me.btnCalculator = New CloudToolkitN6.CloudDesktopButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnClose = New CloudToolkitN6.CloudDesktopButton()
        Me.btnOpen = New CloudToolkitN6.CloudDesktopButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSendFile = New CloudToolkitN6.Windows.Vista.CloudStartMenuButton()
        Me.btnBrowse = New CloudToolkitN6.Windows.Vista.CloudStartMenuButton()
        Me.CloudLabel1 = New CloudToolkitN6.CloudLabel()
        Me.fileTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CloudLabel3 = New CloudToolkitN6.CloudLabel()
        Me.monitorList = New System.Windows.Forms.ListBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.CloudLabel2 = New CloudToolkitN6.CloudLabel()
        Me.btnRun = New CloudToolkitN6.Windows.Vista.CloudStartMenuButton()
        Me.btnOptions = New CloudToolkitN6.Windows.Vista.CloudStartMenuButton()
        Me.btnMonitor = New CloudToolkitN6.Windows.Vista.CloudStartMenuButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Transparent
        Me.lblStatus.Location = New System.Drawing.Point(199, 9)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(119, 20)
        Me.lblStatus.TabIndex = 53
        Me.lblStatus.Text = "Server Status"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnSend)
        Me.GroupBox1.Controls.Add(Me.btnColor)
        Me.GroupBox1.Controls.Add(Me.btnFont)
        Me.GroupBox1.Controls.Add(Me.txtEnglish)
        Me.GroupBox1.Controls.Add(Me.txtUrdu)
        Me.GroupBox1.Controls.Add(Me.messagesListBox)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 365)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'btnSend
        '
        Me.btnSend.AnimationOpacityChange = 0.1R
        Me.btnSend.BackColor = System.Drawing.Color.Transparent
        Me.btnSend.ButtonText = "Send"
        Me.btnSend.ClickedColors_1 = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSend.ClickedColors_2 = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnSend.ClickedColors_3 = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnSend.ClickedColors_4 = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnSend.ControlOpacity = 255
        Me.btnSend.CornerRadius = 18
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.DrawHoverOverIcon = False
        Me.btnSend.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnSend.ForeColor = System.Drawing.Color.White
        Me.btnSend.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSend.Icon = Nothing
        Me.btnSend.IsAnimated = True
        Me.btnSend.Location = New System.Drawing.Point(259, 242)
        Me.btnSend.MaximumGlowOpacity = 0.8R
        Me.btnSend.Name = "btnSend"
        Me.btnSend.NormalColors_1 = System.Drawing.Color.SaddleBrown
        Me.btnSend.NormalColors_2 = System.Drawing.Color.SaddleBrown
        Me.btnSend.NormalColors_3 = System.Drawing.Color.SaddleBrown
        Me.btnSend.NormalColors_4 = System.Drawing.Color.SaddleBrown
        Me.btnSend.Size = New System.Drawing.Size(61, 63)
        Me.btnSend.StartMenuIndex = 0
        Me.btnSend.TabIndex = 65
        Me.btnSend.TextCentered = True
        Me.btnSend.TextDistanceFromBorder = 5
        Me.btnSend.TextIconRelation = CloudToolkitN6.Windows.Vista.CloudStartMenuButton.TextIconRelation_Enum.TextOverIcon
        '
        'btnColor
        '
        Me.btnColor.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.ColorTheoryMixture
        Me.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnColor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnColor.Location = New System.Drawing.Point(28, 219)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(23, 23)
        Me.btnColor.TabIndex = 64
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'btnFont
        '
        Me.btnFont.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.ALetter
        Me.btnFont.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFont.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFont.Location = New System.Drawing.Point(4, 219)
        Me.btnFont.Name = "btnFont"
        Me.btnFont.Size = New System.Drawing.Size(23, 23)
        Me.btnFont.TabIndex = 63
        Me.btnFont.UseVisualStyleBackColor = True
        '
        'txtEnglish
        '
        Me.txtEnglish.Location = New System.Drawing.Point(5, 246)
        Me.txtEnglish.Multiline = True
        Me.txtEnglish.Name = "txtEnglish"
        Me.txtEnglish.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEnglish.Size = New System.Drawing.Size(248, 59)
        Me.txtEnglish.TabIndex = 62
        Me.txtEnglish.Text = "Write Message Here...."
        '
        'txtUrdu
        '
        Me.txtUrdu.Location = New System.Drawing.Point(5, 246)
        Me.txtUrdu.Multiline = True
        Me.txtUrdu.Name = "txtUrdu"
        Me.txtUrdu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtUrdu.Size = New System.Drawing.Size(248, 59)
        Me.txtUrdu.TabIndex = 7
        Me.txtUrdu.Text = "Write Message Here...."
        '
        'messagesListBox
        '
        Me.messagesListBox.BackColor = System.Drawing.Color.LemonChiffon
        Me.messagesListBox.FormattingEnabled = True
        Me.messagesListBox.Location = New System.Drawing.Point(6, 16)
        Me.messagesListBox.Name = "messagesListBox"
        Me.messagesListBox.ScrollAlwaysVisible = True
        Me.messagesListBox.Size = New System.Drawing.Size(315, 199)
        Me.messagesListBox.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox2.Location = New System.Drawing.Point(8, 451)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 174)
        Me.GroupBox2.TabIndex = 57
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(302, 146)
        Me.TabControl1.TabIndex = 63
        '
        'TabPage4
        '
        Me.TabPage4.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.wood_floor_wallpaper1
        Me.TabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage4.Controls.Add(Me.btnShutdown)
        Me.TabPage4.Controls.Add(Me.btnRestart)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(294, 120)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Server Options"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnShutdown
        '
        Me.btnShutdown.AnimationSpeed = 5
        Me.btnShutdown.BackColor = System.Drawing.Color.Transparent
        Me.btnShutdown.BackgroundOpacity = 100
        Me.btnShutdown.BackgroundOpacity_MouseDown = 170
        Me.btnShutdown.BorderColor = System.Drawing.Color.White
        Me.btnShutdown.BorderOpacity = 170
        Me.btnShutdown.BorderWidth = 1
        Me.btnShutdown.ControlText = "Shutdown"
        Me.btnShutdown.CornerRadius = 12
        Me.btnShutdown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnShutdown.DrawBlackTextBackground = True
        Me.btnShutdown.FillColor = System.Drawing.Color.Azure
        Me.btnShutdown.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnShutdown.Icon = Global.Hotel_Management_System.My.Resources.Resources.List_manager
        Me.btnShutdown.Location = New System.Drawing.Point(94, 6)
        Me.btnShutdown.Name = "btnShutdown"
        Me.btnShutdown.Size = New System.Drawing.Size(84, 94)
        Me.btnShutdown.TabIndex = 64
        '
        'btnRestart
        '
        Me.btnRestart.AnimationSpeed = 5
        Me.btnRestart.BackColor = System.Drawing.Color.Transparent
        Me.btnRestart.BackgroundOpacity = 100
        Me.btnRestart.BackgroundOpacity_MouseDown = 170
        Me.btnRestart.BorderColor = System.Drawing.Color.White
        Me.btnRestart.BorderOpacity = 170
        Me.btnRestart.BorderWidth = 1
        Me.btnRestart.ControlText = "Restart"
        Me.btnRestart.CornerRadius = 12
        Me.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestart.DrawBlackTextBackground = True
        Me.btnRestart.FillColor = System.Drawing.Color.Azure
        Me.btnRestart.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRestart.Icon = Global.Hotel_Management_System.My.Resources.Resources.DeleteRed
        Me.btnRestart.Location = New System.Drawing.Point(6, 6)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(84, 94)
        Me.btnRestart.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.wood_floor_wallpaper
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.btnMsPaint)
        Me.TabPage1.Controls.Add(Me.btnNote)
        Me.TabPage1.Controls.Add(Me.btnCalculator)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(294, 120)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tools"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnMsPaint
        '
        Me.btnMsPaint.AnimationSpeed = 5
        Me.btnMsPaint.BackColor = System.Drawing.Color.Transparent
        Me.btnMsPaint.BackgroundOpacity = 100
        Me.btnMsPaint.BackgroundOpacity_MouseDown = 170
        Me.btnMsPaint.BorderColor = System.Drawing.Color.White
        Me.btnMsPaint.BorderOpacity = 170
        Me.btnMsPaint.BorderWidth = 1
        Me.btnMsPaint.ControlText = "Paint"
        Me.btnMsPaint.CornerRadius = 12
        Me.btnMsPaint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMsPaint.DrawBlackTextBackground = True
        Me.btnMsPaint.FillColor = System.Drawing.Color.Azure
        Me.btnMsPaint.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnMsPaint.Icon = Global.Hotel_Management_System.My.Resources.Resources.looknfeel
        Me.btnMsPaint.Location = New System.Drawing.Point(204, 6)
        Me.btnMsPaint.Name = "btnMsPaint"
        Me.btnMsPaint.Size = New System.Drawing.Size(84, 101)
        Me.btnMsPaint.TabIndex = 70
        '
        'btnNote
        '
        Me.btnNote.AnimationSpeed = 5
        Me.btnNote.BackColor = System.Drawing.Color.Transparent
        Me.btnNote.BackgroundOpacity = 100
        Me.btnNote.BackgroundOpacity_MouseDown = 170
        Me.btnNote.BorderColor = System.Drawing.Color.White
        Me.btnNote.BorderOpacity = 170
        Me.btnNote.BorderWidth = 1
        Me.btnNote.ControlText = "Notepad"
        Me.btnNote.CornerRadius = 12
        Me.btnNote.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNote.DrawBlackTextBackground = True
        Me.btnNote.FillColor = System.Drawing.Color.Azure
        Me.btnNote.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNote.Icon = Global.Hotel_Management_System.My.Resources.Resources.kwrite
        Me.btnNote.Location = New System.Drawing.Point(109, 6)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(84, 101)
        Me.btnNote.TabIndex = 69
        '
        'btnCalculator
        '
        Me.btnCalculator.AnimationSpeed = 5
        Me.btnCalculator.BackColor = System.Drawing.Color.Transparent
        Me.btnCalculator.BackgroundOpacity = 100
        Me.btnCalculator.BackgroundOpacity_MouseDown = 170
        Me.btnCalculator.BorderColor = System.Drawing.Color.White
        Me.btnCalculator.BorderOpacity = 170
        Me.btnCalculator.BorderWidth = 1
        Me.btnCalculator.ControlText = "Calculator"
        Me.btnCalculator.CornerRadius = 12
        Me.btnCalculator.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalculator.DrawBlackTextBackground = True
        Me.btnCalculator.FillColor = System.Drawing.Color.Azure
        Me.btnCalculator.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCalculator.Icon = Global.Hotel_Management_System.My.Resources.Resources.lassists
        Me.btnCalculator.Location = New System.Drawing.Point(10, 8)
        Me.btnCalculator.Name = "btnCalculator"
        Me.btnCalculator.Size = New System.Drawing.Size(84, 99)
        Me.btnCalculator.TabIndex = 66
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.wood_floor_wallpaper1
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.btnClose)
        Me.TabPage2.Controls.Add(Me.btnOpen)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(294, 120)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "CD-Rom Options"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Icon = Global.Hotel_Management_System.My.Resources.Resources.kvirc
        Me.btnClose.Location = New System.Drawing.Point(153, 11)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 99)
        Me.btnClose.TabIndex = 68
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
        Me.btnOpen.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnOpen.Icon = Global.Hotel_Management_System.My.Resources.Resources.lassist
        Me.btnOpen.Location = New System.Drawing.Point(45, 11)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(84, 99)
        Me.btnOpen.TabIndex = 67
        '
        'TabPage3
        '
        Me.TabPage3.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.wood_floor_wallpaper1
        Me.TabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage3.Controls.Add(Me.btnSendFile)
        Me.TabPage3.Controls.Add(Me.btnBrowse)
        Me.TabPage3.Controls.Add(Me.CloudLabel1)
        Me.TabPage3.Controls.Add(Me.fileTextBox)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(294, 120)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "File Transfer"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnSendFile
        '
        Me.btnSendFile.AnimationOpacityChange = 0.1R
        Me.btnSendFile.BackColor = System.Drawing.Color.Transparent
        Me.btnSendFile.ButtonText = "Send File"
        Me.btnSendFile.ClickedColors_1 = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnSendFile.ClickedColors_2 = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnSendFile.ClickedColors_3 = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnSendFile.ClickedColors_4 = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnSendFile.ControlOpacity = 255
        Me.btnSendFile.CornerRadius = 18
        Me.btnSendFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSendFile.DrawHoverOverIcon = False
        Me.btnSendFile.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnSendFile.ForeColor = System.Drawing.Color.White
        Me.btnSendFile.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSendFile.Icon = Nothing
        Me.btnSendFile.IsAnimated = True
        Me.btnSendFile.Location = New System.Drawing.Point(20, 53)
        Me.btnSendFile.MaximumGlowOpacity = 0.8R
        Me.btnSendFile.Name = "btnSendFile"
        Me.btnSendFile.NormalColors_1 = System.Drawing.Color.SaddleBrown
        Me.btnSendFile.NormalColors_2 = System.Drawing.Color.SaddleBrown
        Me.btnSendFile.NormalColors_3 = System.Drawing.Color.SaddleBrown
        Me.btnSendFile.NormalColors_4 = System.Drawing.Color.SaddleBrown
        Me.btnSendFile.Size = New System.Drawing.Size(76, 26)
        Me.btnSendFile.StartMenuIndex = 0
        Me.btnSendFile.TabIndex = 69
        Me.btnSendFile.TextCentered = True
        Me.btnSendFile.TextDistanceFromBorder = 5
        Me.btnSendFile.TextIconRelation = CloudToolkitN6.Windows.Vista.CloudStartMenuButton.TextIconRelation_Enum.TextOverIcon
        '
        'btnBrowse
        '
        Me.btnBrowse.AnimationOpacityChange = 0.1R
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.ButtonText = "Browse"
        Me.btnBrowse.ClickedColors_1 = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnBrowse.ClickedColors_2 = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnBrowse.ClickedColors_3 = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnBrowse.ClickedColors_4 = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnBrowse.ControlOpacity = 255
        Me.btnBrowse.CornerRadius = 18
        Me.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBrowse.DrawHoverOverIcon = False
        Me.btnBrowse.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnBrowse.ForeColor = System.Drawing.Color.White
        Me.btnBrowse.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBrowse.Icon = Nothing
        Me.btnBrowse.IsAnimated = True
        Me.btnBrowse.Location = New System.Drawing.Point(190, 25)
        Me.btnBrowse.MaximumGlowOpacity = 0.8R
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.NormalColors_1 = System.Drawing.Color.SaddleBrown
        Me.btnBrowse.NormalColors_2 = System.Drawing.Color.SaddleBrown
        Me.btnBrowse.NormalColors_3 = System.Drawing.Color.SaddleBrown
        Me.btnBrowse.NormalColors_4 = System.Drawing.Color.SaddleBrown
        Me.btnBrowse.Size = New System.Drawing.Size(76, 26)
        Me.btnBrowse.StartMenuIndex = 0
        Me.btnBrowse.TabIndex = 68
        Me.btnBrowse.TextCentered = True
        Me.btnBrowse.TextDistanceFromBorder = 5
        Me.btnBrowse.TextIconRelation = CloudToolkitN6.Windows.Vista.CloudStartMenuButton.TextIconRelation_Enum.TextOverIcon
        '
        'CloudLabel1
        '
        Me.CloudLabel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloudLabel1.AutoSize = True
        Me.CloudLabel1.BackColor = System.Drawing.Color.Transparent
        Me.CloudLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloudLabel1.ForeColor = System.Drawing.Color.Transparent
        Me.CloudLabel1.Location = New System.Drawing.Point(17, 8)
        Me.CloudLabel1.Name = "CloudLabel1"
        Me.CloudLabel1.Size = New System.Drawing.Size(82, 15)
        Me.CloudLabel1.TabIndex = 59
        Me.CloudLabel1.Text = "Browse File"
        '
        'fileTextBox
        '
        Me.fileTextBox.Location = New System.Drawing.Point(20, 27)
        Me.fileTextBox.Name = "fileTextBox"
        Me.fileTextBox.Size = New System.Drawing.Size(164, 20)
        Me.fileTextBox.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.LCD_Room
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox3.Controls.Add(Me.CloudLabel3)
        Me.GroupBox3.Controls.Add(Me.monitorList)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GroupBox3.Location = New System.Drawing.Point(340, 91)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(599, 534)
        Me.GroupBox3.TabIndex = 58
        Me.GroupBox3.TabStop = False
        '
        'CloudLabel3
        '
        Me.CloudLabel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloudLabel3.AutoSize = True
        Me.CloudLabel3.BackColor = System.Drawing.Color.Transparent
        Me.CloudLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloudLabel3.ForeColor = System.Drawing.Color.Black
        Me.CloudLabel3.Location = New System.Drawing.Point(102, 24)
        Me.CloudLabel3.Name = "CloudLabel3"
        Me.CloudLabel3.Size = New System.Drawing.Size(248, 25)
        Me.CloudLabel3.TabIndex = 63
        Me.CloudLabel3.Text = "Messages On Network"
        '
        'monitorList
        '
        Me.monitorList.FormattingEnabled = True
        Me.monitorList.HorizontalScrollbar = True
        Me.monitorList.Location = New System.Drawing.Point(107, 73)
        Me.monitorList.Name = "monitorList"
        Me.monitorList.Size = New System.Drawing.Size(394, 212)
        Me.monitorList.TabIndex = 7
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'CloudLabel2
        '
        Me.CloudLabel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloudLabel2.AutoSize = True
        Me.CloudLabel2.BackColor = System.Drawing.Color.Transparent
        Me.CloudLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CloudLabel2.ForeColor = System.Drawing.Color.Transparent
        Me.CloudLabel2.Location = New System.Drawing.Point(559, 44)
        Me.CloudLabel2.Name = "CloudLabel2"
        Me.CloudLabel2.Size = New System.Drawing.Size(158, 25)
        Me.CloudLabel2.TabIndex = 62
        Me.CloudLabel2.Text = "Monitor Room"
        '
        'btnRun
        '
        Me.btnRun.AnimationOpacityChange = 0.1R
        Me.btnRun.BackColor = System.Drawing.Color.Transparent
        Me.btnRun.ButtonText = "Run"
        Me.btnRun.ClickedColors_1 = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnRun.ClickedColors_2 = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnRun.ClickedColors_3 = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnRun.ClickedColors_4 = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnRun.ControlOpacity = 255
        Me.btnRun.CornerRadius = 18
        Me.btnRun.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRun.DrawHoverOverIcon = False
        Me.btnRun.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnRun.ForeColor = System.Drawing.Color.White
        Me.btnRun.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRun.Icon = Nothing
        Me.btnRun.IsAnimated = True
        Me.btnRun.Location = New System.Drawing.Point(6, 403)
        Me.btnRun.MaximumGlowOpacity = 0.8R
        Me.btnRun.Name = "btnRun"
        Me.btnRun.NormalColors_1 = System.Drawing.Color.SaddleBrown
        Me.btnRun.NormalColors_2 = System.Drawing.Color.SaddleBrown
        Me.btnRun.NormalColors_3 = System.Drawing.Color.SaddleBrown
        Me.btnRun.NormalColors_4 = System.Drawing.Color.SaddleBrown
        Me.btnRun.Size = New System.Drawing.Size(105, 33)
        Me.btnRun.StartMenuIndex = 0
        Me.btnRun.TabIndex = 66
        Me.btnRun.TextCentered = True
        Me.btnRun.TextDistanceFromBorder = 5
        Me.btnRun.TextIconRelation = CloudToolkitN6.Windows.Vista.CloudStartMenuButton.TextIconRelation_Enum.TextOverIcon
        '
        'btnOptions
        '
        Me.btnOptions.AnimationOpacityChange = 0.1R
        Me.btnOptions.BackColor = System.Drawing.Color.Transparent
        Me.btnOptions.ButtonText = "Show Options>>"
        Me.btnOptions.ClickedColors_1 = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnOptions.ClickedColors_2 = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnOptions.ClickedColors_3 = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnOptions.ClickedColors_4 = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnOptions.ControlOpacity = 255
        Me.btnOptions.CornerRadius = 18
        Me.btnOptions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOptions.DrawHoverOverIcon = False
        Me.btnOptions.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnOptions.ForeColor = System.Drawing.Color.White
        Me.btnOptions.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnOptions.Icon = Nothing
        Me.btnOptions.IsAnimated = True
        Me.btnOptions.Location = New System.Drawing.Point(109, 403)
        Me.btnOptions.MaximumGlowOpacity = 0.8R
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.NormalColors_1 = System.Drawing.Color.SaddleBrown
        Me.btnOptions.NormalColors_2 = System.Drawing.Color.SaddleBrown
        Me.btnOptions.NormalColors_3 = System.Drawing.Color.SaddleBrown
        Me.btnOptions.NormalColors_4 = System.Drawing.Color.SaddleBrown
        Me.btnOptions.Size = New System.Drawing.Size(113, 33)
        Me.btnOptions.StartMenuIndex = 0
        Me.btnOptions.TabIndex = 67
        Me.btnOptions.TextCentered = True
        Me.btnOptions.TextDistanceFromBorder = 5
        Me.btnOptions.TextIconRelation = CloudToolkitN6.Windows.Vista.CloudStartMenuButton.TextIconRelation_Enum.TextOverIcon
        '
        'btnMonitor
        '
        Me.btnMonitor.AnimationOpacityChange = 0.1R
        Me.btnMonitor.BackColor = System.Drawing.Color.Transparent
        Me.btnMonitor.ButtonText = "Monitor Room>>"
        Me.btnMonitor.ClickedColors_1 = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.btnMonitor.ClickedColors_2 = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnMonitor.ClickedColors_3 = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.btnMonitor.ClickedColors_4 = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnMonitor.ControlOpacity = 255
        Me.btnMonitor.CornerRadius = 18
        Me.btnMonitor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMonitor.DrawHoverOverIcon = False
        Me.btnMonitor.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.btnMonitor.ForeColor = System.Drawing.Color.White
        Me.btnMonitor.GlowColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnMonitor.Icon = Nothing
        Me.btnMonitor.IsAnimated = True
        Me.btnMonitor.Location = New System.Drawing.Point(220, 403)
        Me.btnMonitor.MaximumGlowOpacity = 0.8R
        Me.btnMonitor.Name = "btnMonitor"
        Me.btnMonitor.NormalColors_1 = System.Drawing.Color.SaddleBrown
        Me.btnMonitor.NormalColors_2 = System.Drawing.Color.SaddleBrown
        Me.btnMonitor.NormalColors_3 = System.Drawing.Color.SaddleBrown
        Me.btnMonitor.NormalColors_4 = System.Drawing.Color.SaddleBrown
        Me.btnMonitor.Size = New System.Drawing.Size(113, 33)
        Me.btnMonitor.StartMenuIndex = 0
        Me.btnMonitor.TabIndex = 68
        Me.btnMonitor.TextCentered = True
        Me.btnMonitor.TextDistanceFromBorder = 5
        Me.btnMonitor.TextIconRelation = CloudToolkitN6.Windows.Vista.CloudStartMenuButton.TextIconRelation_Enum.TextOverIcon
        '
        'frmServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Hotel_Management_System.My.Resources.Resources.wood_floor_wallpaper2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(339, 581)
        Me.Controls.Add(Me.btnMonitor)
        Me.Controls.Add(Me.btnOptions)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.CloudLabel2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "frmServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Server"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.TabControl1.ResumeLayout(false)
        Me.TabPage4.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage3.ResumeLayout(false)
        Me.TabPage3.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents lblStatus As CloudToolkitN6.CloudLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUrdu As System.Windows.Forms.TextBox
    Friend WithEvents messagesListBox As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btnRestart As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnShutdown As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnCalculator As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnNote As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnMsPaint As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents fileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CloudLabel1 As CloudToolkitN6.CloudLabel
    Friend WithEvents btnOpen As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents btnClose As CloudToolkitN6.CloudDesktopButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents monitorList As System.Windows.Forms.ListBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtEnglish As System.Windows.Forms.TextBox
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents btnFont As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents CloudLabel2 As CloudToolkitN6.CloudLabel
    Friend WithEvents btnSend As CloudToolkitN6.Windows.Vista.CloudStartMenuButton
    Friend WithEvents btnRun As CloudToolkitN6.Windows.Vista.CloudStartMenuButton
    Friend WithEvents btnOptions As CloudToolkitN6.Windows.Vista.CloudStartMenuButton
    Friend WithEvents btnMonitor As CloudToolkitN6.Windows.Vista.CloudStartMenuButton
    Friend WithEvents btnBrowse As CloudToolkitN6.Windows.Vista.CloudStartMenuButton
    Friend WithEvents btnSendFile As CloudToolkitN6.Windows.Vista.CloudStartMenuButton
    Friend WithEvents CloudLabel3 As CloudToolkitN6.CloudLabel

End Class
