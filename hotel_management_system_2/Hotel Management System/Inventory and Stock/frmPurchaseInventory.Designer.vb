<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchaseInventory))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbPartyName = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTransType = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.dtpPurchaseDate = New System.Windows.Forms.DateTimePicker()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.cmbProductName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUpdate_record = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtPurchaseID = New System.Windows.Forms.TextBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.purchaset = New System.Windows.Forms.DataGridView()
        Me.selectpurchase = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.TransactionT = New System.Windows.Forms.ComboBox()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.partyname1 = New System.Windows.Forms.ComboBox()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.categorys = New System.Windows.Forms.ComboBox()
        Me.GroupControl7 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl8 = New DevExpress.XtraEditors.GroupControl()
        Me.panel1.SuspendLayout
        CType(Me.GroupControl1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl1.SuspendLayout
        CType(Me.GroupControl2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl2.SuspendLayout
        CType(Me.GroupControl3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl3.SuspendLayout
        CType(Me.purchaset,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GroupControl4,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl4.SuspendLayout
        CType(Me.GroupControl5,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl5.SuspendLayout
        CType(Me.GroupControl6,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl6.SuspendLayout
        CType(Me.GroupControl7,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl7.SuspendLayout
        CType(Me.GroupControl8,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupControl8.SuspendLayout
        Me.SuspendLayout
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(130, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(23, 10)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = false
        '
        'cmbPartyName
        '
        Me.cmbPartyName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPartyName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPartyName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbPartyName.FormattingEnabled = true
        Me.cmbPartyName.Location = New System.Drawing.Point(129, 143)
        Me.cmbPartyName.Name = "cmbPartyName"
        Me.cmbPartyName.Size = New System.Drawing.Size(211, 21)
        Me.cmbPartyName.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(8, 153)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Party Name"
        '
        'cmbTransType
        '
        Me.cmbTransType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTransType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTransType.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbTransType.FormattingEnabled = true
        Me.cmbTransType.Items.AddRange(New Object() {"Cash", "Credit"})
        Me.cmbTransType.Location = New System.Drawing.Point(129, 115)
        Me.cmbTransType.Name = "cmbTransType"
        Me.cmbTransType.Size = New System.Drawing.Size(78, 21)
        Me.cmbTransType.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Transaction Mode"
        '
        'cmbCategory
        '
        Me.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategory.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbCategory.FormattingEnabled = true
        Me.cmbCategory.Location = New System.Drawing.Point(129, 58)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(211, 21)
        Me.cmbCategory.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(8, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Category"
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.Location = New System.Drawing.Point(129, 234)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = true
        Me.txtTotalPrice.Size = New System.Drawing.Size(136, 24)
        Me.txtTotalPrice.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 240)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Total Price"
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(129, 172)
        Me.txtQuantity.Multiline = true
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(78, 24)
        Me.txtQuantity.TabIndex = 5
        '
        'dtpPurchaseDate
        '
        Me.dtpPurchaseDate.CustomFormat = "dd/MMM/yyyy"
        Me.dtpPurchaseDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPurchaseDate.Location = New System.Drawing.Point(129, 87)
        Me.dtpPurchaseDate.Name = "dtpPurchaseDate"
        Me.dtpPurchaseDate.Size = New System.Drawing.Size(115, 21)
        Me.dtpPurchaseDate.TabIndex = 2
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Location = New System.Drawing.Point(129, 204)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(78, 24)
        Me.txtUnitPrice.TabIndex = 7
        '
        'cmbUnit
        '
        Me.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnit.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbUnit.FormattingEnabled = true
        Me.cmbUnit.Items.AddRange(New Object() {"gm", "kg", "litre", "ml", "unit"})
        Me.cmbUnit.Location = New System.Drawing.Point(216, 172)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(69, 21)
        Me.cmbUnit.TabIndex = 6
        '
        'cmbProductName
        '
        Me.cmbProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProductName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.cmbProductName.FormattingEnabled = true
        Me.cmbProductName.Location = New System.Drawing.Point(130, 28)
        Me.cmbProductName.Name = "cmbProductName"
        Me.cmbProductName.Size = New System.Drawing.Size(211, 21)
        Me.cmbProductName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Purchase Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Unit Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 184)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Quantity"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Product Name"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.Transparent
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.Label1)
        Me.panel1.Location = New System.Drawing.Point(771, 214)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(10, 14)
        Me.panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(334, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "."
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Button1.Location = New System.Drawing.Point(522, 489)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 31)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Load"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'btnUpdate_record
        '
        Me.btnUpdate_record.Enabled = false
        Me.btnUpdate_record.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnUpdate_record.Location = New System.Drawing.Point(12, 150)
        Me.btnUpdate_record.Name = "btnUpdate_record"
        Me.btnUpdate_record.Size = New System.Drawing.Size(71, 31)
        Me.btnUpdate_record.TabIndex = 3
        Me.btnUpdate_record.Text = "Update"
        Me.btnUpdate_record.UseVisualStyleBackColor = true
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnSave.Location = New System.Drawing.Point(12, 66)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(71, 31)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'btnNewRecord
        '
        Me.btnNewRecord.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnNewRecord.Location = New System.Drawing.Point(12, 26)
        Me.btnNewRecord.Name = "btnNewRecord"
        Me.btnNewRecord.Size = New System.Drawing.Size(71, 31)
        Me.btnNewRecord.TabIndex = 0
        Me.btnNewRecord.Text = "Clear"
        Me.btnNewRecord.UseVisualStyleBackColor = true
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = false
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnDelete.Location = New System.Drawing.Point(12, 107)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(71, 31)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'txtPurchaseID
        '
        Me.txtPurchaseID.Location = New System.Drawing.Point(185, 196)
        Me.txtPurchaseID.Name = "txtPurchaseID"
        Me.txtPurchaseID.Size = New System.Drawing.Size(100, 24)
        Me.txtPurchaseID.TabIndex = 22
        Me.txtPurchaseID.Visible = false
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.cmbPartyName)
        Me.GroupControl1.Controls.Add(Me.cmbTransType)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.Label2)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.cmbCategory)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.cmbProductName)
        Me.GroupControl1.Controls.Add(Me.txtTotalPrice)
        Me.GroupControl1.Controls.Add(Me.cmbUnit)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.txtUnitPrice)
        Me.GroupControl1.Controls.Add(Me.txtQuantity)
        Me.GroupControl1.Controls.Add(Me.dtpPurchaseDate)
        Me.GroupControl1.Location = New System.Drawing.Point(0, -1)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(363, 274)
        Me.GroupControl1.TabIndex = 23
        Me.GroupControl1.Text = "Product Inventory Information  Details"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl2.Controls.Add(Me.SimpleButton1)
        Me.GroupControl2.Controls.Add(Me.btnNewRecord)
        Me.GroupControl2.Controls.Add(Me.btnUpdate_record)
        Me.GroupControl2.Controls.Add(Me.btnSave)
        Me.GroupControl2.Controls.Add(Me.btnDelete)
        Me.GroupControl2.Location = New System.Drawing.Point(364, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(118, 273)
        Me.GroupControl2.TabIndex = 24
        Me.GroupControl2.Text = "Action Button"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(11, 197)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Close"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.purchaset)
        Me.GroupControl3.Location = New System.Drawing.Point(483, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(789, 348)
        Me.GroupControl3.TabIndex = 25
        Me.GroupControl3.Text = "Purchased Inventory Record"
        '
        'purchaset
        '
        Me.purchaset.AllowUserToAddRows = false
        Me.purchaset.AllowUserToDeleteRows = false
        Me.purchaset.BackgroundColor = System.Drawing.Color.DarkKhaki
        Me.purchaset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.purchaset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.purchaset.Location = New System.Drawing.Point(2, 21)
        Me.purchaset.MultiSelect = false
        Me.purchaset.Name = "purchaset"
        Me.purchaset.ReadOnly = true
        Me.purchaset.Size = New System.Drawing.Size(785, 325)
        Me.purchaset.TabIndex = 1
        '
        'selectpurchase
        '
        Me.selectpurchase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.selectpurchase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.selectpurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.selectpurchase.FormattingEnabled = true
        Me.selectpurchase.Location = New System.Drawing.Point(25, 30)
        Me.selectpurchase.Name = "selectpurchase"
        Me.selectpurchase.Size = New System.Drawing.Size(191, 23)
        Me.selectpurchase.TabIndex = 26
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.DimGray
        Me.TextBox1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(13, 27)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(235, 21)
        Me.TextBox1.TabIndex = 0
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.selectpurchase)
        Me.GroupControl4.Location = New System.Drawing.Point(0, 276)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(229, 69)
        Me.GroupControl4.TabIndex = 28
        Me.GroupControl4.Text = "Select by Product Name"
        '
        'TransactionT
        '
        Me.TransactionT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.TransactionT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TransactionT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TransactionT.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TransactionT.FormattingEnabled = true
        Me.TransactionT.Items.AddRange(New Object() {"Cash", "Credit"})
        Me.TransactionT.Location = New System.Drawing.Point(6, 27)
        Me.TransactionT.Name = "TransactionT"
        Me.TransactionT.Size = New System.Drawing.Size(146, 21)
        Me.TransactionT.TabIndex = 29
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.SimpleButton2)
        Me.GroupControl5.Controls.Add(Me.TransactionT)
        Me.GroupControl5.Location = New System.Drawing.Point(236, 278)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(242, 66)
        Me.GroupControl5.TabIndex = 30
        Me.GroupControl5.Text = "Transaction Mode"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(160, 29)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(74, 23)
        Me.SimpleButton2.TabIndex = 31
        Me.SimpleButton2.Text = "Load"
        '
        'partyname1
        '
        Me.partyname1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.partyname1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.partyname1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.partyname1.FormattingEnabled = true
        Me.partyname1.Location = New System.Drawing.Point(21, 31)
        Me.partyname1.Name = "partyname1"
        Me.partyname1.Size = New System.Drawing.Size(196, 23)
        Me.partyname1.TabIndex = 31
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.partyname1)
        Me.GroupControl6.Location = New System.Drawing.Point(0, 349)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(229, 70)
        Me.GroupControl6.TabIndex = 32
        Me.GroupControl6.Text = "Select By Party Name"
        '
        'categorys
        '
        Me.categorys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.categorys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.categorys.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!)
        Me.categorys.FormattingEnabled = true
        Me.categorys.Location = New System.Drawing.Point(14, 30)
        Me.categorys.Name = "categorys"
        Me.categorys.Size = New System.Drawing.Size(220, 23)
        Me.categorys.TabIndex = 33
        '
        'GroupControl7
        '
        Me.GroupControl7.Controls.Add(Me.categorys)
        Me.GroupControl7.Location = New System.Drawing.Point(235, 351)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.Size = New System.Drawing.Size(242, 69)
        Me.GroupControl7.TabIndex = 34
        Me.GroupControl7.Text = "Select Transaction Category"
        '
        'GroupControl8
        '
        Me.GroupControl8.Controls.Add(Me.TextBox1)
        Me.GroupControl8.Location = New System.Drawing.Point(486, 353)
        Me.GroupControl8.Name = "GroupControl8"
        Me.GroupControl8.Size = New System.Drawing.Size(264, 67)
        Me.GroupControl8.TabIndex = 35
        Me.GroupControl8.Text = "Grand Total"
        '
        'frmPurchaseInventory
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 17!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1274, 421)
        Me.Controls.Add(Me.GroupControl8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupControl7)
        Me.Controls.Add(Me.GroupControl6)
        Me.Controls.Add(Me.GroupControl5)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.txtPurchaseID)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = false
        Me.Name = "frmPurchaseInventory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchased Inventory"
        Me.panel1.ResumeLayout(false)
        Me.panel1.PerformLayout
        CType(Me.GroupControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl1.ResumeLayout(false)
        Me.GroupControl1.PerformLayout
        CType(Me.GroupControl2,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl2.ResumeLayout(false)
        CType(Me.GroupControl3,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl3.ResumeLayout(false)
        CType(Me.purchaset,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GroupControl4,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl4.ResumeLayout(false)
        CType(Me.GroupControl5,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl5.ResumeLayout(false)
        CType(Me.GroupControl6,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl6.ResumeLayout(false)
        CType(Me.GroupControl7,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl7.ResumeLayout(false)
        CType(Me.GroupControl8,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl8.ResumeLayout(false)
        Me.GroupControl8.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpPurchaseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents cmbUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProductName As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents panel1 As System.Windows.Forms.Panel
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents btnUpdate_record As System.Windows.Forms.Button
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnNewRecord As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchaseID As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbPartyName As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTransType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents purchaset As System.Windows.Forms.DataGridView
    Friend WithEvents selectpurchase As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TransactionT As System.Windows.Forms.ComboBox
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents partyname1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents categorys As System.Windows.Forms.ComboBox
    Friend WithEvents GroupControl7 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl8 As DevExpress.XtraEditors.GroupControl
End Class
