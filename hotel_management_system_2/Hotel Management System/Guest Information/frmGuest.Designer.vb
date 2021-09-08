<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuest
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
        Dim Label46 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim IDNumberLabel As System.Windows.Forms.Label
        Dim IDTypeIDLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuest))
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.cmbIDType = New System.Windows.Forms.ComboBox()
        Me.txtGuestContactNo = New System.Windows.Forms.TextBox()
        Me.txtGuestCity = New System.Windows.Forms.TextBox()
        Me.txtGuestAddress = New System.Windows.Forms.TextBox()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.txtGuestID = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnUpdate_record = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.guestsearch = New System.Windows.Forms.TextBox()
        Label46 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        IDNumberLabel = New System.Windows.Forms.Label()
        IDTypeIDLabel = New System.Windows.Forms.Label()
        AddressLabel = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label46
        '
        Label46.AutoSize = True
        Label46.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label46.ForeColor = System.Drawing.Color.Black
        Label46.Location = New System.Drawing.Point(6, 141)
        Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label46.Name = "Label46"
        Label46.Size = New System.Drawing.Size(74, 13)
        Label46.TabIndex = 276
        Label46.Text = "* Contact No."
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(6, 111)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(35, 13)
        Label2.TabIndex = 274
        Label2.Text = "* City"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(6, 58)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(93, 13)
        Label6.TabIndex = 271
        Label6.Text = "* Guest Full Name"
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        IDNumberLabel.ForeColor = System.Drawing.Color.Black
        IDNumberLabel.Location = New System.Drawing.Point(6, 200)
        IDNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(67, 13)
        IDNumberLabel.TabIndex = 267
        IDNumberLabel.Text = "* ID Number"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(6, 169)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(51, 13)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "* IDType"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        AddressLabel.ForeColor = System.Drawing.Color.Black
        AddressLabel.Location = New System.Drawing.Point(6, 85)
        AddressLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(55, 13)
        AddressLabel.TabIndex = 263
        AddressLabel.Text = "* Address"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(6, 29)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(49, 13)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "Guest ID"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label1.ForeColor = System.Drawing.Color.Black
        Label1.Location = New System.Drawing.Point(6, 236)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(52, 13)
        Label1.TabIndex = 277
        Label1.Text = "* Remark"
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(17, 13)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(38, 42)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1143, 309)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 21)
        Me.Button2.TabIndex = 278
        Me.Button2.Text = "<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Location = New System.Drawing.Point(105, 226)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes.Size = New System.Drawing.Size(256, 88)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Text = ""
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Location = New System.Drawing.Point(105, 196)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(256, 24)
        Me.txtIDNumber.TabIndex = 5
        '
        'cmbIDType
        '
        Me.cmbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIDType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmbIDType.FormattingEnabled = True
        Me.cmbIDType.Items.AddRange(New Object() {"Keble  ID", "College ID/University ID", "Office ID", "Passport", "Driver Licence", "Any Other"})
        Me.cmbIDType.Location = New System.Drawing.Point(105, 164)
        Me.cmbIDType.Name = "cmbIDType"
        Me.cmbIDType.Size = New System.Drawing.Size(149, 23)
        Me.cmbIDType.TabIndex = 4
        '
        'txtGuestContactNo
        '
        Me.txtGuestContactNo.Location = New System.Drawing.Point(105, 135)
        Me.txtGuestContactNo.Name = "txtGuestContactNo"
        Me.txtGuestContactNo.Size = New System.Drawing.Size(149, 24)
        Me.txtGuestContactNo.TabIndex = 3
        '
        'txtGuestCity
        '
        Me.txtGuestCity.Location = New System.Drawing.Point(105, 108)
        Me.txtGuestCity.Name = "txtGuestCity"
        Me.txtGuestCity.Size = New System.Drawing.Size(256, 24)
        Me.txtGuestCity.TabIndex = 2
        '
        'txtGuestAddress
        '
        Me.txtGuestAddress.Location = New System.Drawing.Point(105, 79)
        Me.txtGuestAddress.Name = "txtGuestAddress"
        Me.txtGuestAddress.Size = New System.Drawing.Size(285, 24)
        Me.txtGuestAddress.TabIndex = 1
        '
        'txtGuestName
        '
        Me.txtGuestName.Location = New System.Drawing.Point(105, 52)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.Size = New System.Drawing.Size(256, 24)
        Me.txtGuestName.TabIndex = 0
        '
        'txtGuestID
        '
        Me.txtGuestID.Location = New System.Drawing.Point(105, 24)
        Me.txtGuestID.Name = "txtGuestID"
        Me.txtGuestID.ReadOnly = True
        Me.txtGuestID.Size = New System.Drawing.Size(149, 24)
        Me.txtGuestID.TabIndex = 7
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.Transparent
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Location = New System.Drawing.Point(1072, 332)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(22, 20)
        Me.panel1.TabIndex = 1
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(334, 31)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(11, 17)
        Me.label4.TabIndex = 19
        Me.label4.Text = "."
        '
        'btnUpdate_record
        '
        Me.btnUpdate_record.Enabled = False
        Me.btnUpdate_record.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnUpdate_record.Image = Global.Hotel_Management_System.My.Resources.Resources.Edit_32x32
        Me.btnUpdate_record.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate_record.Location = New System.Drawing.Point(147, 22)
        Me.btnUpdate_record.Name = "btnUpdate_record"
        Me.btnUpdate_record.Size = New System.Drawing.Size(87, 33)
        Me.btnUpdate_record.TabIndex = 3
        Me.btnUpdate_record.Text = "Update"
        Me.btnUpdate_record.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate_record.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnSave.Image = Global.Hotel_Management_System.My.Resources.Resources.SaveAll_32x32
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(240, 22)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 33)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNewRecord
        '
        Me.btnNewRecord.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnNewRecord.Image = Global.Hotel_Management_System.My.Resources.Resources.Clear_32x32
        Me.btnNewRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewRecord.Location = New System.Drawing.Point(54, 22)
        Me.btnNewRecord.Name = "btnNewRecord"
        Me.btnNewRecord.Size = New System.Drawing.Size(87, 33)
        Me.btnNewRecord.TabIndex = 0
        Me.btnNewRecord.Text = "Clear"
        Me.btnNewRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewRecord.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnDelete.Image = Global.Hotel_Management_System.My.Resources.Resources.Close_32x32
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(330, 22)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 33)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.dataGridView1)
        Me.GroupControl1.Location = New System.Drawing.Point(407, 29)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(506, 220)
        Me.GroupControl1.TabIndex = 279
        Me.GroupControl1.Text = "Guest Record"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.BackgroundColor = System.Drawing.Color.PeachPuff
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(2, 21)
        Me.dataGridView1.MultiSelect = False
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = True
        Me.dataGridView1.Size = New System.Drawing.Size(502, 197)
        Me.dataGridView1.TabIndex = 21
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl2.Controls.Add(Me.btnDelete)
        Me.GroupControl2.Controls.Add(Me.btnUpdate_record)
        Me.GroupControl2.Controls.Add(Me.btnNewRecord)
        Me.GroupControl2.Controls.Add(Me.btnSave)
        Me.GroupControl2.Location = New System.Drawing.Point(409, 253)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(496, 76)
        Me.GroupControl2.TabIndex = 280
        Me.GroupControl2.Text = "Action Button"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Label2)
        Me.GroupControl3.Controls.Add(Me.txtGuestContactNo)
        Me.GroupControl3.Controls.Add(Me.txtNotes)
        Me.GroupControl3.Controls.Add(FolioNumberLabel)
        Me.GroupControl3.Controls.Add(Label1)
        Me.GroupControl3.Controls.Add(AddressLabel)
        Me.GroupControl3.Controls.Add(Me.txtIDNumber)
        Me.GroupControl3.Controls.Add(IDTypeIDLabel)
        Me.GroupControl3.Controls.Add(Me.cmbIDType)
        Me.GroupControl3.Controls.Add(IDNumberLabel)
        Me.GroupControl3.Controls.Add(Me.txtGuestID)
        Me.GroupControl3.Controls.Add(Label46)
        Me.GroupControl3.Controls.Add(Label6)
        Me.GroupControl3.Controls.Add(Me.txtGuestCity)
        Me.GroupControl3.Controls.Add(Me.txtGuestName)
        Me.GroupControl3.Controls.Add(Me.txtGuestAddress)
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(401, 331)
        Me.GroupControl3.TabIndex = 280
        Me.GroupControl3.Text = "Guest Profile Detiale"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(839, 1)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 289
        Me.SimpleButton1.Text = "Close"
        '
        'guestsearch
        '
        Me.guestsearch.BackColor = System.Drawing.Color.DimGray
        Me.guestsearch.ForeColor = System.Drawing.Color.White
        Me.guestsearch.Location = New System.Drawing.Point(407, 0)
        Me.guestsearch.Name = "guestsearch"
        Me.guestsearch.Size = New System.Drawing.Size(284, 24)
        Me.guestsearch.TabIndex = 292
        Me.guestsearch.Text = "Search By Guest Name"
        '
        'frmGuest
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(914, 335)
        Me.Controls.Add(Me.guestsearch)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBoxGuestInfo)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmGuest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guest"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxGuestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmbIDType As System.Windows.Forms.ComboBox
    Friend WithEvents txtGuestContactNo As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestCity As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestName As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestID As System.Windows.Forms.TextBox
    Public WithEvents panel1 As System.Windows.Forms.Panel
    Public WithEvents btnUpdate_record As System.Windows.Forms.Button
    Public WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnNewRecord As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents guestsearch As System.Windows.Forms.TextBox
End Class
