<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckIN
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
        Me.components = New System.ComponentModel.Container()
        Dim Label8 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label46 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim IDNumberLabel As System.Windows.Forms.Label
        Dim IDTypeIDLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim Label53 As System.Windows.Forms.Label
        Dim Label52 As System.Windows.Forms.Label
        Dim Label51 As System.Windows.Forms.Label
        Dim Label50 As System.Windows.Forms.Label
        Dim Label49 As System.Windows.Forms.Label
        Dim Label48 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label47 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim DateOutLabel As System.Windows.Forms.Label
        Dim DateInLabel As System.Windows.Forms.Label
        Dim RoomNumberLabel As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim Label57 As System.Windows.Forms.Label
        Dim Label14 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label19 As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckIN))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnListReset1 = New System.Windows.Forms.Button()
        Me.btnListUpdate1 = New System.Windows.Forms.Button()
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPayment = New System.Windows.Forms.TextBox()
        Me.cmbPaymentMode = New System.Windows.Forms.ComboBox()
        Me.btnRemove1 = New System.Windows.Forms.Button()
        Me.btnAdd1 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBoxRateInfo = New System.Windows.Forms.GroupBox()
        Me.txtRoomID = New System.Windows.Forms.TextBox()
        Me.txtReservationNo = New System.Windows.Forms.TextBox()
        Me.txtPlanName = New System.Windows.Forms.TextBox()
        Me.cmbPlanCode = New System.Windows.Forms.ComboBox()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.txtGuestLedgerID = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLaundryCharges = New System.Windows.Forms.TextBox()
        Me.txtExtraPersonCharges = New System.Windows.Forms.TextBox()
        Me.hsExtraBed = New System.Windows.Forms.HScrollBar()
        Me.hsExtraPerson = New System.Windows.Forms.HScrollBar()
        Me.hsKids = New System.Windows.Forms.HScrollBar()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.txtRoomOrderCharges = New System.Windows.Forms.TextBox()
        Me.txtNoOfExtraBed = New System.Windows.Forms.TextBox()
        Me.txtNoOfExtraPerson = New System.Windows.Forms.TextBox()
        Me.txtNoOfKids = New System.Windows.Forms.TextBox()
        Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtTotalPaid = New System.Windows.Forms.TextBox()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxPer = New System.Windows.Forms.TextBox()
        Me.txtExtraBedCharges = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxAmount = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxPer = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxAmount = New System.Windows.Forms.TextBox()
        Me.txtDiscountPer = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalRoomCharges = New System.Windows.Forms.TextBox()
        Me.txtNoOfDays = New System.Windows.Forms.TextBox()
        Me.txtRoomCharges = New System.Windows.Forms.TextBox()
        Me.hsFemales = New System.Windows.Forms.HScrollBar()
        Me.txtNoOfFemales = New System.Windows.Forms.TextBox()
        Me.txtNoOfMales = New System.Windows.Forms.TextBox()
        Me.dtpDateOut = New System.Windows.Forms.DateTimePicker()
        Me.cmbRoomNo = New System.Windows.Forms.ComboBox()
        Me.hsMales = New System.Windows.Forms.HScrollBar()
        Me.dtpDateIn = New System.Windows.Forms.DateTimePicker()
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.txti2 = New System.Windows.Forms.TextBox()
        Me.txti1 = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtExtraBedC = New System.Windows.Forms.TextBox()
        Me.txtExtraPersonC = New System.Windows.Forms.TextBox()
        Me.txtRoomType = New System.Windows.Forms.TextBox()
        Me.txtReservationID = New System.Windows.Forms.TextBox()
        Me.txtReligion = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtOccupation = New System.Windows.Forms.TextBox()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.txtCheckInID = New System.Windows.Forms.TextBox()
        Me.txtIDType = New System.Windows.Forms.TextBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.txtGuestContactNo = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtGuestCity = New System.Windows.Forms.TextBox()
        Me.txtGuestAddress = New System.Windows.Forms.TextBox()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.txtGuestID = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbRoomNo1 = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Label8 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label46 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        IDNumberLabel = New System.Windows.Forms.Label()
        IDTypeIDLabel = New System.Windows.Forms.Label()
        AddressLabel = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Label53 = New System.Windows.Forms.Label()
        Label52 = New System.Windows.Forms.Label()
        Label51 = New System.Windows.Forms.Label()
        Label50 = New System.Windows.Forms.Label()
        Label49 = New System.Windows.Forms.Label()
        Label48 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label47 = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        DateOutLabel = New System.Windows.Forms.Label()
        DateInLabel = New System.Windows.Forms.Label()
        RoomNumberLabel = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Label57 = New System.Windows.Forms.Label()
        Label14 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label19 = New System.Windows.Forms.Label()
        Label20 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBoxRateInfo.SuspendLayout()
        Me.GroupBoxGuestInfo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.ForeColor = System.Drawing.Color.Black
        Label8.Location = New System.Drawing.Point(7, 102)
        Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(59, 17)
        Label8.TabIndex = 287
        Label8.Text = "Religion :"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label9.ForeColor = System.Drawing.Color.Black
        Label9.Location = New System.Drawing.Point(7, 126)
        Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(75, 17)
        Label9.TabIndex = 283
        Label9.Text = "Occupation :"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.ForeColor = System.Drawing.Color.Black
        Label10.Location = New System.Drawing.Point(7, 76)
        Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(55, 17)
        Label10.TabIndex = 282
        Label10.Text = "Gender :"
        '
        'Label46
        '
        Label46.AutoSize = True
        Label46.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label46.ForeColor = System.Drawing.Color.Black
        Label46.Location = New System.Drawing.Point(7, 231)
        Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label46.Name = "Label46"
        Label46.Size = New System.Drawing.Size(79, 17)
        Label46.TabIndex = 276
        Label46.Text = "Contact No. :"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label11.ForeColor = System.Drawing.Color.Black
        Label11.Location = New System.Drawing.Point(7, 178)
        Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(37, 17)
        Label11.TabIndex = 274
        Label11.Text = "City :"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label12.ForeColor = System.Drawing.Color.Black
        Label12.Location = New System.Drawing.Point(7, 50)
        Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(82, 17)
        Label12.TabIndex = 271
        Label12.Text = "Guest Name :"
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDNumberLabel.ForeColor = System.Drawing.Color.Black
        IDNumberLabel.Location = New System.Drawing.Point(7, 287)
        IDNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(78, 17)
        IDNumberLabel.TabIndex = 267
        IDNumberLabel.Text = "ID Number :"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(7, 261)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(61, 17)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "ID Type :"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        AddressLabel.ForeColor = System.Drawing.Color.Black
        AddressLabel.Location = New System.Drawing.Point(7, 150)
        AddressLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(58, 17)
        AddressLabel.TabIndex = 263
        AddressLabel.Text = "Address :"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(7, 24)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(64, 17)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "Guest ID :"
        '
        'Label53
        '
        Label53.AutoSize = True
        Label53.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label53.ForeColor = System.Drawing.Color.Black
        Label53.Location = New System.Drawing.Point(9, 616)
        Label53.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label53.Name = "Label53"
        Label53.Size = New System.Drawing.Size(55, 17)
        Label53.TabIndex = 301
        Label53.Text = "Balance :"
        '
        'Label52
        '
        Label52.AutoSize = True
        Label52.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label52.ForeColor = System.Drawing.Color.Black
        Label52.Location = New System.Drawing.Point(9, 589)
        Label52.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label52.Name = "Label52"
        Label52.Size = New System.Drawing.Size(70, 17)
        Label52.TabIndex = 299
        Label52.Text = "Total Paid :"
        '
        'Label51
        '
        Label51.AutoSize = True
        Label51.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label51.ForeColor = System.Drawing.Color.Black
        Label51.Location = New System.Drawing.Point(7, 564)
        Label51.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label51.Name = "Label51"
        Label51.Size = New System.Drawing.Size(81, 17)
        Label51.TabIndex = 297
        Label51.Text = "Grand Total :"
        '
        'Label50
        '
        Label50.AutoSize = True
        Label50.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label50.ForeColor = System.Drawing.Color.Black
        Label50.Location = New System.Drawing.Point(7, 477)
        Label50.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label50.Name = "Label50"
        Label50.Size = New System.Drawing.Size(67, 17)
        Label50.TabIndex = 296
        Label50.Text = "Sub Total :"
        '
        'Label49
        '
        Label49.AutoSize = True
        Label49.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label49.ForeColor = System.Drawing.Color.Black
        Label49.Location = New System.Drawing.Point(7, 535)
        Label49.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label49.Name = "Label49"
        Label49.Size = New System.Drawing.Size(75, 17)
        Label49.TabIndex = 292
        Label49.Text = "Luxury Tax :"
        '
        'Label48
        '
        Label48.AutoSize = True
        Label48.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label48.ForeColor = System.Drawing.Color.Black
        Label48.Location = New System.Drawing.Point(7, 506)
        Label48.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label48.Name = "Label48"
        Label48.Size = New System.Drawing.Size(75, 17)
        Label48.TabIndex = 289
        Label48.Text = "Service Tax :"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(7, 448)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(62, 17)
        Label2.TabIndex = 287
        Label2.Text = "Discount :"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.ForeColor = System.Drawing.Color.Black
        Label3.Location = New System.Drawing.Point(7, 332)
        Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(132, 17)
        Label3.TabIndex = 285
        Label3.Text = "Room Order Charges :"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.ForeColor = System.Drawing.Color.Black
        Label4.Location = New System.Drawing.Point(7, 303)
        Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(128, 17)
        Label4.TabIndex = 283
        Label4.Text = "Total Room Charges :"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label33.ForeColor = System.Drawing.Color.Black
        Label33.Location = New System.Drawing.Point(7, 187)
        Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(79, 17)
        Label33.TabIndex = 279
        Label33.Text = "No. Of Kids :"
        '
        'Label47
        '
        Label47.AutoSize = True
        Label47.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label47.ForeColor = System.Drawing.Color.Black
        Label47.Location = New System.Drawing.Point(7, 158)
        Label47.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label47.Name = "Label47"
        Label47.Size = New System.Drawing.Size(99, 17)
        Label47.TabIndex = 276
        Label47.Text = "No. Of Females :"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label22.ForeColor = System.Drawing.Color.Black
        Label22.Location = New System.Drawing.Point(7, 129)
        Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(87, 17)
        Label22.TabIndex = 274
        Label22.Text = "No. Of Males :"
        '
        'DateOutLabel
        '
        DateOutLabel.AutoSize = True
        DateOutLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateOutLabel.ForeColor = System.Drawing.Color.Black
        DateOutLabel.Location = New System.Drawing.Point(7, 103)
        DateOutLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        DateOutLabel.Name = "DateOutLabel"
        DateOutLabel.Size = New System.Drawing.Size(64, 17)
        DateOutLabel.TabIndex = 249
        DateOutLabel.Text = "Date Out :"
        '
        'DateInLabel
        '
        DateInLabel.AutoSize = True
        DateInLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DateInLabel.ForeColor = System.Drawing.Color.Black
        DateInLabel.Location = New System.Drawing.Point(7, 74)
        DateInLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        DateInLabel.Name = "DateInLabel"
        DateInLabel.Size = New System.Drawing.Size(55, 17)
        DateInLabel.TabIndex = 247
        DateInLabel.Text = "Date In :"
        '
        'RoomNumberLabel
        '
        RoomNumberLabel.AutoSize = True
        RoomNumberLabel.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RoomNumberLabel.ForeColor = System.Drawing.Color.Black
        RoomNumberLabel.Location = New System.Drawing.Point(7, 19)
        RoomNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        RoomNumberLabel.Name = "RoomNumberLabel"
        RoomNumberLabel.Size = New System.Drawing.Size(71, 17)
        RoomNumberLabel.TabIndex = 235
        RoomNumberLabel.Text = "Room No. :"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.ForeColor = System.Drawing.Color.Black
        Label5.Location = New System.Drawing.Point(7, 216)
        Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(123, 17)
        Label5.TabIndex = 314
        Label5.Text = "No. Of Extra Person :"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(7, 245)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(106, 17)
        Label6.TabIndex = 315
        Label6.Text = "No. Of Extra Bed :"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.ForeColor = System.Drawing.Color.Black
        Label7.Location = New System.Drawing.Point(7, 274)
        Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(83, 17)
        Label7.TabIndex = 316
        Label7.Text = "No. Of Days :"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label13.ForeColor = System.Drawing.Color.Black
        Label13.Location = New System.Drawing.Point(7, 419)
        Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(109, 17)
        Label13.TabIndex = 317
        Label13.Text = "Laundry Charges :"
        '
        'Label57
        '
        Label57.AutoSize = True
        Label57.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label57.ForeColor = System.Drawing.Color.Black
        Label57.Location = New System.Drawing.Point(238, 299)
        Label57.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label57.Name = "Label57"
        Label57.Size = New System.Drawing.Size(44, 16)
        Label57.TabIndex = 4
        Label57.Text = "Notes :"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label14.ForeColor = System.Drawing.Color.Black
        Label14.Location = New System.Drawing.Point(7, 361)
        Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(113, 17)
        Label14.TabIndex = 323
        Label14.Text = "Extra Bed Charges :"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label15.ForeColor = System.Drawing.Color.Black
        Label15.Location = New System.Drawing.Point(7, 390)
        Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(130, 17)
        Label15.TabIndex = 324
        Label15.Text = "Extra Person Charges :"
        '
        'Label19
        '
        Label19.AutoSize = True
        Label19.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label19.ForeColor = System.Drawing.Color.Black
        Label19.Location = New System.Drawing.Point(7, 204)
        Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label19.Name = "Label19"
        Label19.Size = New System.Drawing.Size(60, 17)
        Label19.TabIndex = 303
        Label19.Text = "Country :"
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label20.ForeColor = System.Drawing.Color.Black
        Label20.Location = New System.Drawing.Point(7, 47)
        Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(70, 17)
        Label20.TabIndex = 328
        Label20.Text = "Plan Code :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.GroupBoxRateInfo)
        Me.Panel1.Controls.Add(Me.GroupBoxGuestInfo)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 684)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Location = New System.Drawing.Point(743, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 562)
        Me.GroupBox1.TabIndex = 295
        Me.GroupBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnPrint)
        Me.Panel4.Controls.Add(Me.btnGetData)
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnUpdate)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnNew)
        Me.Panel4.Location = New System.Drawing.Point(10, 17)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(106, 291)
        Me.Panel4.TabIndex = 289
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(6, 236)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(95, 42)
        Me.btnPrint.TabIndex = 9
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnGetData
        '
        Me.btnGetData.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetData.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.Image = Global.Hotel_Management_System.My.Resources.Resources.Serching
        Me.btnGetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGetData.Location = New System.Drawing.Point(5, 191)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(96, 42)
        Me.btnGetData.TabIndex = 6
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGetData.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = Global.Hotel_Management_System.My.Resources.Resources.images__4__1
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(5, 145)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 42)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = Global.Hotel_Management_System.My.Resources.Resources.images__3_
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(5, 99)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(96, 42)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(5, 53)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 42)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Check IN"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = Global.Hotel_Management_System.My.Resources.Resources.download__1__3
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(5, 7)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(96, 42)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Indigo
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Indigo
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeight = 24
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column15, Me.Column16, Me.Column1})
        Me.DataGridView2.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.EnableHeadersVisualStyles = False
        Me.DataGridView2.GridColor = System.Drawing.Color.White
        Me.DataGridView2.Location = New System.Drawing.Point(5, 533)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Orange
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView2.RowHeadersWidth = 25
        Me.DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView2.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.RowTemplate.Height = 27
        Me.DataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(375, 146)
        Me.DataGridView2.TabIndex = 3
        '
        'Column8
        '
        Me.Column8.HeaderText = "Payment Mode"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 120
        '
        'Column15
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Column15.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column15.HeaderText = "Payment"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        DataGridViewCellStyle4.Format = "dd/MM/yyyy"
        Me.Column16.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column16.HeaderText = "Payment Date"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 125
        '
        'Column1
        '
        Me.Column1.HeaderText = "Status"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnListReset1)
        Me.GroupBox2.Controls.Add(Me.btnListUpdate1)
        Me.GroupBox2.Controls.Add(Me.dtpPaymentDate)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtPayment)
        Me.GroupBox2.Controls.Add(Me.cmbPaymentMode)
        Me.GroupBox2.Controls.Add(Me.btnRemove1)
        Me.GroupBox2.Controls.Add(Me.btnAdd1)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 372)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(375, 155)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment Info"
        '
        'btnListReset1
        '
        Me.btnListReset1.BackColor = System.Drawing.Color.Indigo
        Me.btnListReset1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListReset1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListReset1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnListReset1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListReset1.Location = New System.Drawing.Point(266, 13)
        Me.btnListReset1.Name = "btnListReset1"
        Me.btnListReset1.Size = New System.Drawing.Size(90, 30)
        Me.btnListReset1.TabIndex = 3
        Me.btnListReset1.Text = "Reset"
        Me.btnListReset1.UseVisualStyleBackColor = False
        '
        'btnListUpdate1
        '
        Me.btnListUpdate1.BackColor = System.Drawing.Color.Crimson
        Me.btnListUpdate1.Enabled = False
        Me.btnListUpdate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListUpdate1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListUpdate1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnListUpdate1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnListUpdate1.Location = New System.Drawing.Point(266, 118)
        Me.btnListUpdate1.Name = "btnListUpdate1"
        Me.btnListUpdate1.Size = New System.Drawing.Size(90, 30)
        Me.btnListUpdate1.TabIndex = 6
        Me.btnListUpdate1.Text = "Update"
        Me.btnListUpdate1.UseVisualStyleBackColor = False
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPaymentDate.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDate.Location = New System.Drawing.Point(119, 105)
        Me.dtpPaymentDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.Size = New System.Drawing.Size(105, 24)
        Me.dtpPaymentDate.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 105)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 17)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Payment Date :"
        '
        'txtPayment
        '
        Me.txtPayment.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPayment.Location = New System.Drawing.Point(119, 62)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.Size = New System.Drawing.Size(105, 24)
        Me.txtPayment.TabIndex = 1
        Me.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbPaymentMode
        '
        Me.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMode.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPaymentMode.FormattingEnabled = True
        Me.cmbPaymentMode.Items.AddRange(New Object() {"From Guest's Account", "By Cash", "By Credit Card", "By Debit Card"})
        Me.cmbPaymentMode.Location = New System.Drawing.Point(119, 24)
        Me.cmbPaymentMode.Name = "cmbPaymentMode"
        Me.cmbPaymentMode.Size = New System.Drawing.Size(105, 25)
        Me.cmbPaymentMode.TabIndex = 0
        '
        'btnRemove1
        '
        Me.btnRemove1.BackColor = System.Drawing.Color.Indigo
        Me.btnRemove1.Enabled = False
        Me.btnRemove1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRemove1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove1.Location = New System.Drawing.Point(266, 83)
        Me.btnRemove1.Name = "btnRemove1"
        Me.btnRemove1.Size = New System.Drawing.Size(90, 30)
        Me.btnRemove1.TabIndex = 5
        Me.btnRemove1.Text = "Remove"
        Me.btnRemove1.UseVisualStyleBackColor = False
        '
        'btnAdd1
        '
        Me.btnAdd1.BackColor = System.Drawing.Color.OrangeRed
        Me.btnAdd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAdd1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd1.Location = New System.Drawing.Point(266, 48)
        Me.btnAdd1.Name = "btnAdd1"
        Me.btnAdd1.Size = New System.Drawing.Size(90, 30)
        Me.btnAdd1.TabIndex = 4
        Me.btnAdd1.Text = "Add"
        Me.btnAdd1.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(98, 17)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Payment Mode :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 17)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Payment :"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.Hotel_Management_System.My.Resources.Resources.images__4__1
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(795, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 35)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'GroupBoxRateInfo
        '
        Me.GroupBoxRateInfo.Controls.Add(Me.txtRoomID)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtReservationNo)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtPlanName)
        Me.GroupBoxRateInfo.Controls.Add(Me.cmbPlanCode)
        Me.GroupBoxRateInfo.Controls.Add(Label20)
        Me.GroupBoxRateInfo.Controls.Add(Label57)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNotes)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtGuestLedgerID)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox3)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox2)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox1)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtLaundryCharges)
        Me.GroupBoxRateInfo.Controls.Add(Label15)
        Me.GroupBoxRateInfo.Controls.Add(Label14)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtExtraPersonCharges)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsExtraBed)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsExtraPerson)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsKids)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtBalance)
        Me.GroupBoxRateInfo.Controls.Add(Label13)
        Me.GroupBoxRateInfo.Controls.Add(Label7)
        Me.GroupBoxRateInfo.Controls.Add(Label6)
        Me.GroupBoxRateInfo.Controls.Add(Label5)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtRoomOrderCharges)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfExtraBed)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfExtraPerson)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfKids)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtDiscountAmount)
        Me.GroupBoxRateInfo.Controls.Add(Me.Label58)
        Me.GroupBoxRateInfo.Controls.Add(Me.Label56)
        Me.GroupBoxRateInfo.Controls.Add(Me.Label55)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtTotalPaid)
        Me.GroupBoxRateInfo.Controls.Add(Label53)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtGrandTotal)
        Me.GroupBoxRateInfo.Controls.Add(Label52)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtServiceTaxPer)
        Me.GroupBoxRateInfo.Controls.Add(Label51)
        Me.GroupBoxRateInfo.Controls.Add(Label50)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtExtraBedCharges)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtLuxuryTaxAmount)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtLuxuryTaxPer)
        Me.GroupBoxRateInfo.Controls.Add(Label49)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtServiceTaxAmount)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtDiscountPer)
        Me.GroupBoxRateInfo.Controls.Add(Label48)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtSubTotal)
        Me.GroupBoxRateInfo.Controls.Add(Label2)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtTotalRoomCharges)
        Me.GroupBoxRateInfo.Controls.Add(Label3)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfDays)
        Me.GroupBoxRateInfo.Controls.Add(Label4)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtRoomCharges)
        Me.GroupBoxRateInfo.Controls.Add(Label33)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsFemales)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfFemales)
        Me.GroupBoxRateInfo.Controls.Add(Label47)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtNoOfMales)
        Me.GroupBoxRateInfo.Controls.Add(Label22)
        Me.GroupBoxRateInfo.Controls.Add(Me.dtpDateOut)
        Me.GroupBoxRateInfo.Controls.Add(Me.cmbRoomNo)
        Me.GroupBoxRateInfo.Controls.Add(Me.hsMales)
        Me.GroupBoxRateInfo.Controls.Add(DateOutLabel)
        Me.GroupBoxRateInfo.Controls.Add(Me.dtpDateIn)
        Me.GroupBoxRateInfo.Controls.Add(DateInLabel)
        Me.GroupBoxRateInfo.Controls.Add(RoomNumberLabel)
        Me.GroupBoxRateInfo.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxRateInfo.Location = New System.Drawing.Point(385, 37)
        Me.GroupBoxRateInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRateInfo.Name = "GroupBoxRateInfo"
        Me.GroupBoxRateInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRateInfo.Size = New System.Drawing.Size(353, 642)
        Me.GroupBoxRateInfo.TabIndex = 1
        Me.GroupBoxRateInfo.TabStop = False
        Me.GroupBoxRateInfo.Text = "Rate Information"
        '
        'txtRoomID
        '
        Me.txtRoomID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRoomID.Location = New System.Drawing.Point(110, 130)
        Me.txtRoomID.Name = "txtRoomID"
        Me.txtRoomID.Size = New System.Drawing.Size(65, 17)
        Me.txtRoomID.TabIndex = 302
        Me.txtRoomID.Visible = False
        '
        'txtReservationNo
        '
        Me.txtReservationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReservationNo.Location = New System.Drawing.Point(286, 222)
        Me.txtReservationNo.Name = "txtReservationNo"
        Me.txtReservationNo.ReadOnly = True
        Me.txtReservationNo.Size = New System.Drawing.Size(30, 20)
        Me.txtReservationNo.TabIndex = 329
        Me.txtReservationNo.Visible = False
        '
        'txtPlanName
        '
        Me.txtPlanName.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanName.Location = New System.Drawing.Point(222, 47)
        Me.txtPlanName.Name = "txtPlanName"
        Me.txtPlanName.ReadOnly = True
        Me.txtPlanName.Size = New System.Drawing.Size(123, 22)
        Me.txtPlanName.TabIndex = 4
        '
        'cmbPlanCode
        '
        Me.cmbPlanCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPlanCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlanCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanCode.Enabled = False
        Me.cmbPlanCode.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanCode.FormattingEnabled = True
        Me.cmbPlanCode.Location = New System.Drawing.Point(146, 44)
        Me.cmbPlanCode.Name = "cmbPlanCode"
        Me.cmbPlanCode.Size = New System.Drawing.Size(70, 24)
        Me.cmbPlanCode.TabIndex = 3
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotes.Location = New System.Drawing.Point(237, 316)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.txtNotes.Size = New System.Drawing.Size(106, 116)
        Me.txtNotes.TabIndex = 291
        Me.txtNotes.Text = ""
        '
        'txtGuestLedgerID
        '
        Me.txtGuestLedgerID.Location = New System.Drawing.Point(286, 94)
        Me.txtGuestLedgerID.Name = "txtGuestLedgerID"
        Me.txtGuestLedgerID.Size = New System.Drawing.Size(35, 24)
        Me.txtGuestLedgerID.TabIndex = 319
        Me.txtGuestLedgerID.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(288, 172)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(33, 24)
        Me.TextBox3.TabIndex = 327
        Me.TextBox3.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(288, 146)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(33, 24)
        Me.TextBox2.TabIndex = 326
        Me.TextBox2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(288, 120)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(33, 24)
        Me.TextBox1.TabIndex = 325
        Me.TextBox1.Visible = False
        '
        'txtLaundryCharges
        '
        Me.txtLaundryCharges.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaundryCharges.Location = New System.Drawing.Point(146, 415)
        Me.txtLaundryCharges.Name = "txtLaundryCharges"
        Me.txtLaundryCharges.ReadOnly = True
        Me.txtLaundryCharges.Size = New System.Drawing.Size(84, 22)
        Me.txtLaundryCharges.TabIndex = 22
        Me.txtLaundryCharges.Text = "0"
        Me.txtLaundryCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtraPersonCharges
        '
        Me.txtExtraPersonCharges.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtraPersonCharges.Location = New System.Drawing.Point(146, 386)
        Me.txtExtraPersonCharges.Name = "txtExtraPersonCharges"
        Me.txtExtraPersonCharges.ReadOnly = True
        Me.txtExtraPersonCharges.Size = New System.Drawing.Size(84, 22)
        Me.txtExtraPersonCharges.TabIndex = 21
        Me.txtExtraPersonCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hsExtraBed
        '
        Me.hsExtraBed.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsExtraBed.LargeChange = 1
        Me.hsExtraBed.Location = New System.Drawing.Point(237, 239)
        Me.hsExtraBed.Maximum = 32767
        Me.hsExtraBed.Name = "hsExtraBed"
        Me.hsExtraBed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsExtraBed.Size = New System.Drawing.Size(23, 24)
        Me.hsExtraBed.TabIndex = 16
        Me.hsExtraBed.TabStop = True
        '
        'hsExtraPerson
        '
        Me.hsExtraPerson.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsExtraPerson.LargeChange = 1
        Me.hsExtraPerson.Location = New System.Drawing.Point(237, 210)
        Me.hsExtraPerson.Maximum = 32767
        Me.hsExtraPerson.Name = "hsExtraPerson"
        Me.hsExtraPerson.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsExtraPerson.Size = New System.Drawing.Size(23, 24)
        Me.hsExtraPerson.TabIndex = 14
        Me.hsExtraPerson.TabStop = True
        '
        'hsKids
        '
        Me.hsKids.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsKids.LargeChange = 1
        Me.hsKids.Location = New System.Drawing.Point(237, 181)
        Me.hsKids.Maximum = 32767
        Me.hsKids.Name = "hsKids"
        Me.hsKids.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsKids.Size = New System.Drawing.Size(23, 24)
        Me.hsKids.TabIndex = 12
        Me.hsKids.TabStop = True
        '
        'txtBalance
        '
        Me.txtBalance.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(146, 616)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(84, 22)
        Me.txtBalance.TabIndex = 32
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRoomOrderCharges
        '
        Me.txtRoomOrderCharges.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoomOrderCharges.Location = New System.Drawing.Point(146, 328)
        Me.txtRoomOrderCharges.Name = "txtRoomOrderCharges"
        Me.txtRoomOrderCharges.ReadOnly = True
        Me.txtRoomOrderCharges.Size = New System.Drawing.Size(84, 22)
        Me.txtRoomOrderCharges.TabIndex = 19
        Me.txtRoomOrderCharges.Text = "0"
        Me.txtRoomOrderCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfExtraBed
        '
        Me.txtNoOfExtraBed.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfExtraBed.Location = New System.Drawing.Point(196, 241)
        Me.txtNoOfExtraBed.Name = "txtNoOfExtraBed"
        Me.txtNoOfExtraBed.ReadOnly = True
        Me.txtNoOfExtraBed.Size = New System.Drawing.Size(34, 22)
        Me.txtNoOfExtraBed.TabIndex = 15
        Me.txtNoOfExtraBed.Text = "0"
        Me.txtNoOfExtraBed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfExtraPerson
        '
        Me.txtNoOfExtraPerson.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfExtraPerson.Location = New System.Drawing.Point(196, 212)
        Me.txtNoOfExtraPerson.Name = "txtNoOfExtraPerson"
        Me.txtNoOfExtraPerson.ReadOnly = True
        Me.txtNoOfExtraPerson.Size = New System.Drawing.Size(34, 22)
        Me.txtNoOfExtraPerson.TabIndex = 13
        Me.txtNoOfExtraPerson.Text = "0"
        Me.txtNoOfExtraPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfKids
        '
        Me.txtNoOfKids.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfKids.Location = New System.Drawing.Point(196, 183)
        Me.txtNoOfKids.Name = "txtNoOfKids"
        Me.txtNoOfKids.ReadOnly = True
        Me.txtNoOfKids.Size = New System.Drawing.Size(34, 22)
        Me.txtNoOfKids.TabIndex = 11
        Me.txtNoOfKids.Text = "0"
        Me.txtNoOfKids.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscountAmount.Location = New System.Drawing.Point(261, 444)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.ReadOnly = True
        Me.txtDiscountAmount.Size = New System.Drawing.Size(84, 22)
        Me.txtDiscountAmount.TabIndex = 24
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(238, 446)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(18, 16)
        Me.Label58.TabIndex = 305
        Me.Label58.Text = "%"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(238, 533)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(18, 16)
        Me.Label56.TabIndex = 304
        Me.Label56.Text = "%"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(238, 504)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(18, 16)
        Me.Label55.TabIndex = 303
        Me.Label55.Text = "%"
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPaid.Location = New System.Drawing.Point(146, 589)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.ReadOnly = True
        Me.txtTotalPaid.Size = New System.Drawing.Size(84, 22)
        Me.txtTotalPaid.TabIndex = 31
        Me.txtTotalPaid.Text = "0"
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(146, 560)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(84, 22)
        Me.txtGrandTotal.TabIndex = 30
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxPer
        '
        Me.txtServiceTaxPer.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceTaxPer.Location = New System.Drawing.Point(187, 502)
        Me.txtServiceTaxPer.Name = "txtServiceTaxPer"
        Me.txtServiceTaxPer.Size = New System.Drawing.Size(43, 22)
        Me.txtServiceTaxPer.TabIndex = 26
        Me.txtServiceTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtraBedCharges
        '
        Me.txtExtraBedCharges.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtraBedCharges.Location = New System.Drawing.Point(146, 357)
        Me.txtExtraBedCharges.Name = "txtExtraBedCharges"
        Me.txtExtraBedCharges.ReadOnly = True
        Me.txtExtraBedCharges.Size = New System.Drawing.Size(84, 22)
        Me.txtExtraBedCharges.TabIndex = 20
        Me.txtExtraBedCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxAmount
        '
        Me.txtLuxuryTaxAmount.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLuxuryTaxAmount.Location = New System.Drawing.Point(259, 531)
        Me.txtLuxuryTaxAmount.Name = "txtLuxuryTaxAmount"
        Me.txtLuxuryTaxAmount.ReadOnly = True
        Me.txtLuxuryTaxAmount.Size = New System.Drawing.Size(84, 22)
        Me.txtLuxuryTaxAmount.TabIndex = 29
        Me.txtLuxuryTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxPer
        '
        Me.txtLuxuryTaxPer.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLuxuryTaxPer.Location = New System.Drawing.Point(187, 531)
        Me.txtLuxuryTaxPer.Name = "txtLuxuryTaxPer"
        Me.txtLuxuryTaxPer.Size = New System.Drawing.Size(43, 22)
        Me.txtLuxuryTaxPer.TabIndex = 28
        Me.txtLuxuryTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxAmount
        '
        Me.txtServiceTaxAmount.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceTaxAmount.Location = New System.Drawing.Point(259, 502)
        Me.txtServiceTaxAmount.Name = "txtServiceTaxAmount"
        Me.txtServiceTaxAmount.ReadOnly = True
        Me.txtServiceTaxAmount.Size = New System.Drawing.Size(84, 22)
        Me.txtServiceTaxAmount.TabIndex = 27
        Me.txtServiceTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountPer
        '
        Me.txtDiscountPer.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscountPer.Location = New System.Drawing.Point(187, 444)
        Me.txtDiscountPer.Name = "txtDiscountPer"
        Me.txtDiscountPer.Size = New System.Drawing.Size(43, 22)
        Me.txtDiscountPer.TabIndex = 23
        Me.txtDiscountPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(146, 473)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(84, 22)
        Me.txtSubTotal.TabIndex = 25
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRoomCharges
        '
        Me.txtTotalRoomCharges.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRoomCharges.Location = New System.Drawing.Point(146, 299)
        Me.txtTotalRoomCharges.Name = "txtTotalRoomCharges"
        Me.txtTotalRoomCharges.ReadOnly = True
        Me.txtTotalRoomCharges.Size = New System.Drawing.Size(84, 22)
        Me.txtTotalRoomCharges.TabIndex = 18
        Me.txtTotalRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfDays
        '
        Me.txtNoOfDays.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfDays.Location = New System.Drawing.Point(196, 270)
        Me.txtNoOfDays.Name = "txtNoOfDays"
        Me.txtNoOfDays.ReadOnly = True
        Me.txtNoOfDays.Size = New System.Drawing.Size(34, 22)
        Me.txtNoOfDays.TabIndex = 17
        Me.txtNoOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRoomCharges
        '
        Me.txtRoomCharges.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoomCharges.Location = New System.Drawing.Point(222, 19)
        Me.txtRoomCharges.Name = "txtRoomCharges"
        Me.txtRoomCharges.Size = New System.Drawing.Size(82, 22)
        Me.txtRoomCharges.TabIndex = 1
        Me.txtRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hsFemales
        '
        Me.hsFemales.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsFemales.LargeChange = 1
        Me.hsFemales.Location = New System.Drawing.Point(237, 152)
        Me.hsFemales.Maximum = 32767
        Me.hsFemales.Name = "hsFemales"
        Me.hsFemales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsFemales.Size = New System.Drawing.Size(23, 24)
        Me.hsFemales.TabIndex = 10
        Me.hsFemales.TabStop = True
        '
        'txtNoOfFemales
        '
        Me.txtNoOfFemales.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfFemales.Location = New System.Drawing.Point(196, 154)
        Me.txtNoOfFemales.Name = "txtNoOfFemales"
        Me.txtNoOfFemales.ReadOnly = True
        Me.txtNoOfFemales.Size = New System.Drawing.Size(34, 22)
        Me.txtNoOfFemales.TabIndex = 9
        Me.txtNoOfFemales.Text = "0"
        Me.txtNoOfFemales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfMales
        '
        Me.txtNoOfMales.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoOfMales.Location = New System.Drawing.Point(196, 125)
        Me.txtNoOfMales.Name = "txtNoOfMales"
        Me.txtNoOfMales.ReadOnly = True
        Me.txtNoOfMales.Size = New System.Drawing.Size(34, 22)
        Me.txtNoOfMales.TabIndex = 7
        Me.txtNoOfMales.Text = "0"
        Me.txtNoOfMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDateOut
        '
        Me.dtpDateOut.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateOut.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateOut.Location = New System.Drawing.Point(146, 99)
        Me.dtpDateOut.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateOut.Name = "dtpDateOut"
        Me.dtpDateOut.Size = New System.Drawing.Size(95, 22)
        Me.dtpDateOut.TabIndex = 6
        '
        'cmbRoomNo
        '
        Me.cmbRoomNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoomNo.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRoomNo.FormattingEnabled = True
        Me.cmbRoomNo.Location = New System.Drawing.Point(146, 15)
        Me.cmbRoomNo.Name = "cmbRoomNo"
        Me.cmbRoomNo.Size = New System.Drawing.Size(70, 24)
        Me.cmbRoomNo.TabIndex = 0
        '
        'hsMales
        '
        Me.hsMales.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsMales.LargeChange = 1
        Me.hsMales.Location = New System.Drawing.Point(237, 123)
        Me.hsMales.Maximum = 32767
        Me.hsMales.Name = "hsMales"
        Me.hsMales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsMales.Size = New System.Drawing.Size(23, 24)
        Me.hsMales.TabIndex = 8
        Me.hsMales.TabStop = True
        '
        'dtpDateIn
        '
        Me.dtpDateIn.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateIn.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateIn.Location = New System.Drawing.Point(146, 72)
        Me.dtpDateIn.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateIn.Name = "dtpDateIn"
        Me.dtpDateIn.Size = New System.Drawing.Size(95, 22)
        Me.dtpDateIn.TabIndex = 5
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.Controls.Add(Me.txti2)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txti1)
        Me.GroupBoxGuestInfo.Controls.Add(Me.lblStatus)
        Me.GroupBoxGuestInfo.Controls.Add(Label19)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtCountry)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Button1)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtExtraBedC)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtExtraPersonC)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtRoomType)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtReservationID)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtReligion)
        Me.GroupBoxGuestInfo.Controls.Add(Label8)
        Me.GroupBoxGuestInfo.Controls.Add(Me.lblUser)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtOccupation)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGender)
        Me.GroupBoxGuestInfo.Controls.Add(Label9)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtCheckInID)
        Me.GroupBoxGuestInfo.Controls.Add(Label10)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtIDType)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Button13)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtIDNumber)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestContactNo)
        Me.GroupBoxGuestInfo.Controls.Add(Label46)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtID)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestCity)
        Me.GroupBoxGuestInfo.Controls.Add(Label11)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestAddress)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestName)
        Me.GroupBoxGuestInfo.Controls.Add(Label12)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestID)
        Me.GroupBoxGuestInfo.Controls.Add(IDNumberLabel)
        Me.GroupBoxGuestInfo.Controls.Add(IDTypeIDLabel)
        Me.GroupBoxGuestInfo.Controls.Add(AddressLabel)
        Me.GroupBoxGuestInfo.Controls.Add(FolioNumberLabel)
        Me.GroupBoxGuestInfo.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(5, 38)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(375, 328)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        Me.GroupBoxGuestInfo.Text = "Guest Information"
        '
        'txti2
        '
        Me.txti2.Location = New System.Drawing.Point(292, 288)
        Me.txti2.Name = "txti2"
        Me.txti2.Size = New System.Drawing.Size(36, 24)
        Me.txti2.TabIndex = 305
        Me.txti2.Visible = False
        '
        'txti1
        '
        Me.txti1.Location = New System.Drawing.Point(292, 263)
        Me.txti1.Name = "txti1"
        Me.txti1.Size = New System.Drawing.Size(36, 24)
        Me.txti1.TabIndex = 304
        Me.txti1.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(325, 295)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(41, 17)
        Me.lblStatus.TabIndex = 295
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'txtCountry
        '
        Me.txtCountry.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Location = New System.Drawing.Point(108, 208)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.ReadOnly = True
        Me.txtCountry.Size = New System.Drawing.Size(229, 22)
        Me.txtCountry.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.Hotel_Management_System.My.Resources.Resources.plus_circle1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(266, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 21)
        Me.Button1.TabIndex = 301
        Me.Button1.Text = "Add New Guest"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtExtraBedC
        '
        Me.txtExtraBedC.Location = New System.Drawing.Point(280, 217)
        Me.txtExtraBedC.Name = "txtExtraBedC"
        Me.txtExtraBedC.Size = New System.Drawing.Size(28, 24)
        Me.txtExtraBedC.TabIndex = 296
        Me.txtExtraBedC.Visible = False
        '
        'txtExtraPersonC
        '
        Me.txtExtraPersonC.Location = New System.Drawing.Point(314, 217)
        Me.txtExtraPersonC.Name = "txtExtraPersonC"
        Me.txtExtraPersonC.Size = New System.Drawing.Size(28, 24)
        Me.txtExtraPersonC.TabIndex = 297
        Me.txtExtraPersonC.Visible = False
        '
        'txtRoomType
        '
        Me.txtRoomType.Location = New System.Drawing.Point(239, 210)
        Me.txtRoomType.Name = "txtRoomType"
        Me.txtRoomType.Size = New System.Drawing.Size(28, 24)
        Me.txtRoomType.TabIndex = 295
        Me.txtRoomType.Visible = False
        '
        'txtReservationID
        '
        Me.txtReservationID.Location = New System.Drawing.Point(314, 217)
        Me.txtReservationID.Name = "txtReservationID"
        Me.txtReservationID.Size = New System.Drawing.Size(28, 24)
        Me.txtReservationID.TabIndex = 298
        Me.txtReservationID.Visible = False
        '
        'txtReligion
        '
        Me.txtReligion.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReligion.Location = New System.Drawing.Point(108, 102)
        Me.txtReligion.Name = "txtReligion"
        Me.txtReligion.ReadOnly = True
        Me.txtReligion.Size = New System.Drawing.Size(229, 22)
        Me.txtReligion.TabIndex = 3
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(289, 240)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(44, 17)
        Me.lblUser.TabIndex = 5
        Me.lblUser.Text = "Label8"
        Me.lblUser.Visible = False
        '
        'txtOccupation
        '
        Me.txtOccupation.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOccupation.Location = New System.Drawing.Point(108, 128)
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.ReadOnly = True
        Me.txtOccupation.Size = New System.Drawing.Size(229, 22)
        Me.txtOccupation.TabIndex = 4
        '
        'txtGender
        '
        Me.txtGender.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGender.Location = New System.Drawing.Point(108, 76)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.ReadOnly = True
        Me.txtGender.Size = New System.Drawing.Size(74, 22)
        Me.txtGender.TabIndex = 2
        '
        'txtCheckInID
        '
        Me.txtCheckInID.Location = New System.Drawing.Point(341, 172)
        Me.txtCheckInID.Name = "txtCheckInID"
        Me.txtCheckInID.Size = New System.Drawing.Size(28, 24)
        Me.txtCheckInID.TabIndex = 4
        Me.txtCheckInID.Visible = False
        '
        'txtIDType
        '
        Me.txtIDType.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDType.Location = New System.Drawing.Point(108, 261)
        Me.txtIDType.Name = "txtIDType"
        Me.txtIDType.ReadOnly = True
        Me.txtIDType.Size = New System.Drawing.Size(149, 22)
        Me.txtIDType.TabIndex = 9
        '
        'Button13
        '
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button13.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button13.Location = New System.Drawing.Point(158, 23)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(109, 21)
        Me.Button13.TabIndex = 279
        Me.Button13.Text = "List Of Guests"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button13.UseVisualStyleBackColor = True
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDNumber.Location = New System.Drawing.Point(108, 287)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.ReadOnly = True
        Me.txtIDNumber.Size = New System.Drawing.Size(149, 22)
        Me.txtIDNumber.TabIndex = 10
        '
        'txtGuestContactNo
        '
        Me.txtGuestContactNo.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuestContactNo.Location = New System.Drawing.Point(108, 235)
        Me.txtGuestContactNo.Name = "txtGuestContactNo"
        Me.txtGuestContactNo.Size = New System.Drawing.Size(149, 22)
        Me.txtGuestContactNo.TabIndex = 8
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(334, 221)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(28, 24)
        Me.txtID.TabIndex = 7
        Me.txtID.Visible = False
        '
        'txtGuestCity
        '
        Me.txtGuestCity.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuestCity.Location = New System.Drawing.Point(108, 182)
        Me.txtGuestCity.Name = "txtGuestCity"
        Me.txtGuestCity.ReadOnly = True
        Me.txtGuestCity.Size = New System.Drawing.Size(229, 22)
        Me.txtGuestCity.TabIndex = 6
        '
        'txtGuestAddress
        '
        Me.txtGuestAddress.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuestAddress.Location = New System.Drawing.Point(108, 154)
        Me.txtGuestAddress.Name = "txtGuestAddress"
        Me.txtGuestAddress.ReadOnly = True
        Me.txtGuestAddress.Size = New System.Drawing.Size(229, 22)
        Me.txtGuestAddress.TabIndex = 5
        '
        'txtGuestName
        '
        Me.txtGuestName.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuestName.Location = New System.Drawing.Point(108, 50)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.ReadOnly = True
        Me.txtGuestName.Size = New System.Drawing.Size(229, 22)
        Me.txtGuestName.TabIndex = 1
        '
        'txtGuestID
        '
        Me.txtGuestID.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGuestID.Location = New System.Drawing.Point(108, 24)
        Me.txtGuestID.Name = "txtGuestID"
        Me.txtGuestID.ReadOnly = True
        Me.txtGuestID.Size = New System.Drawing.Size(44, 22)
        Me.txtGuestID.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Indigo
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbRoomNo1)
        Me.Panel2.Location = New System.Drawing.Point(4, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(785, 31)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(365, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Guest Check IN"
        '
        'cmbRoomNo1
        '
        Me.cmbRoomNo1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo1.FormattingEnabled = True
        Me.cmbRoomNo1.Location = New System.Drawing.Point(89, 0)
        Me.cmbRoomNo1.Name = "cmbRoomNo1"
        Me.cmbRoomNo1.Size = New System.Drawing.Size(18, 21)
        Me.cmbRoomNo1.TabIndex = 299
        Me.cmbRoomNo1.Visible = False
        '
        'Timer1
        '
        '
        'frmCheckIN_Room
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkMagenta
        Me.ClientSize = New System.Drawing.Size(885, 690)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckIN_Room"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBoxRateInfo.ResumeLayout(False)
        Me.GroupBoxRateInfo.PerformLayout()
        Me.GroupBoxGuestInfo.ResumeLayout(False)
        Me.GroupBoxGuestInfo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCheckInID As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents GroupBoxGuestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtReligion As System.Windows.Forms.TextBox
    Friend WithEvents txtOccupation As System.Windows.Forms.TextBox
    Friend WithEvents txtGender As System.Windows.Forms.TextBox
    Friend WithEvents txtIDType As System.Windows.Forms.TextBox
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestContactNo As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestCity As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestName As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestID As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents GroupBoxRateInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtRoomOrderCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfExtraBed As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfExtraPerson As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfKids As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents txtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxPer As System.Windows.Forms.TextBox
    Friend WithEvents txtExtraBedCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxPer As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountPer As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalRoomCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfDays As System.Windows.Forms.TextBox
    Friend WithEvents txtRoomCharges As System.Windows.Forms.TextBox
    Public WithEvents hsFemales As System.Windows.Forms.HScrollBar
    Friend WithEvents txtNoOfFemales As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfMales As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbRoomNo As System.Windows.Forms.ComboBox
    Public WithEvents hsMales As System.Windows.Forms.HScrollBar
    Friend WithEvents dtpDateIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Public WithEvents hsExtraBed As System.Windows.Forms.HScrollBar
    Public WithEvents hsExtraPerson As System.Windows.Forms.HScrollBar
    Public WithEvents hsKids As System.Windows.Forms.HScrollBar
    Friend WithEvents txtRoomType As System.Windows.Forms.TextBox
    Friend WithEvents txtLaundryCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtExtraPersonCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtExtraPersonC As System.Windows.Forms.TextBox
    Friend WithEvents txtExtraBedC As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtReservationID As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents cmbRoomNo1 As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnListReset1 As System.Windows.Forms.Button
    Friend WithEvents btnListUpdate1 As System.Windows.Forms.Button
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPayment As System.Windows.Forms.TextBox
    Friend WithEvents cmbPaymentMode As System.Windows.Forms.ComboBox
    Friend WithEvents btnRemove1 As System.Windows.Forms.Button
    Friend WithEvents btnAdd1 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtGuestLedgerID As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txti2 As System.Windows.Forms.TextBox
    Friend WithEvents txti1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPlanName As System.Windows.Forms.TextBox
    Friend WithEvents cmbPlanCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtRoomID As System.Windows.Forms.TextBox
    Friend WithEvents txtReservationNo As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class
