<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckIN_Room
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckIN_Room))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbRoomNo1 = New System.Windows.Forms.ComboBox()
        Me.txtReservationID = New System.Windows.Forms.TextBox()
        Me.txtExtraPersonC = New System.Windows.Forms.TextBox()
        Me.txtExtraBedC = New System.Windows.Forms.TextBox()
        Me.txtRoomType = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnCheckedIN = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnRoomAvailability = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.GroupBoxRateInfo = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLaundryCharges = New System.Windows.Forms.TextBox()
        Me.txtExtraPersonCharges = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.hsExtraBed = New System.Windows.Forms.HScrollBar()
        Me.hsExtraPerson = New System.Windows.Forms.HScrollBar()
        Me.hsKids = New System.Windows.Forms.HScrollBar()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.txtRoomOrderCharges = New System.Windows.Forms.TextBox()
        Me.txtNoOfExtraBed = New System.Windows.Forms.TextBox()
        Me.txtNoOfExtraPerson = New System.Windows.Forms.TextBox()
        Me.txtNoOfKids = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.txtReligion = New System.Windows.Forms.TextBox()
        Me.txtOccupation = New System.Windows.Forms.TextBox()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.txtIDType = New System.Windows.Forms.TextBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.txtGuestContactNo = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtGuestCity = New System.Windows.Forms.TextBox()
        Me.txtGuestAddress = New System.Windows.Forms.TextBox()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.txtGuestID = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtCheckInID = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBoxRateInfo.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBoxGuestInfo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.ForeColor = System.Drawing.Color.Black
        Label8.Location = New System.Drawing.Point(27, 106)
        Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(51, 13)
        Label8.TabIndex = 287
        Label8.Text = "Religion :"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.ForeColor = System.Drawing.Color.Black
        Label9.Location = New System.Drawing.Point(27, 132)
        Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(68, 13)
        Label9.TabIndex = 283
        Label9.Text = "Occupation :"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.ForeColor = System.Drawing.Color.Black
        Label10.Location = New System.Drawing.Point(26, 80)
        Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(48, 13)
        Label10.TabIndex = 282
        Label10.Text = "Gender :"
        '
        'Label46
        '
        Label46.AutoSize = True
        Label46.ForeColor = System.Drawing.Color.Black
        Label46.Location = New System.Drawing.Point(27, 209)
        Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label46.Name = "Label46"
        Label46.Size = New System.Drawing.Size(70, 13)
        Label46.TabIndex = 276
        Label46.Text = "Contact No. :"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.ForeColor = System.Drawing.Color.Black
        Label11.Location = New System.Drawing.Point(27, 183)
        Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(30, 13)
        Label11.TabIndex = 274
        Label11.Text = "City :"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.ForeColor = System.Drawing.Color.Black
        Label12.Location = New System.Drawing.Point(26, 54)
        Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(72, 13)
        Label12.TabIndex = 271
        Label12.Text = "Guest Name :"
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.ForeColor = System.Drawing.Color.Black
        IDNumberLabel.Location = New System.Drawing.Point(26, 261)
        IDNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(64, 13)
        IDNumberLabel.TabIndex = 267
        IDNumberLabel.Text = "ID Number :"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(26, 235)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(51, 13)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "ID Type :"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.ForeColor = System.Drawing.Color.Black
        AddressLabel.Location = New System.Drawing.Point(27, 157)
        AddressLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(51, 13)
        AddressLabel.TabIndex = 263
        AddressLabel.Text = "Address :"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(26, 29)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(55, 13)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "Guest ID :"
        '
        'Label53
        '
        Label53.AutoSize = True
        Label53.ForeColor = System.Drawing.Color.Black
        Label53.Location = New System.Drawing.Point(45, 517)
        Label53.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label53.Name = "Label53"
        Label53.Size = New System.Drawing.Size(52, 13)
        Label53.TabIndex = 301
        Label53.Text = "Balance :"
        '
        'Label52
        '
        Label52.AutoSize = True
        Label52.ForeColor = System.Drawing.Color.Black
        Label52.Location = New System.Drawing.Point(45, 492)
        Label52.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label52.Name = "Label52"
        Label52.Size = New System.Drawing.Size(61, 13)
        Label52.TabIndex = 299
        Label52.Text = "Total Paid :"
        '
        'Label51
        '
        Label51.AutoSize = True
        Label51.ForeColor = System.Drawing.Color.Black
        Label51.Location = New System.Drawing.Point(45, 466)
        Label51.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label51.Name = "Label51"
        Label51.Size = New System.Drawing.Size(69, 13)
        Label51.TabIndex = 297
        Label51.Text = "Grand Total :"
        '
        'Label50
        '
        Label50.AutoSize = True
        Label50.ForeColor = System.Drawing.Color.Black
        Label50.Location = New System.Drawing.Point(45, 389)
        Label50.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label50.Name = "Label50"
        Label50.Size = New System.Drawing.Size(59, 13)
        Label50.TabIndex = 296
        Label50.Text = "Sub Total :"
        '
        'Label49
        '
        Label49.AutoSize = True
        Label49.ForeColor = System.Drawing.Color.Black
        Label49.Location = New System.Drawing.Point(45, 440)
        Label49.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label49.Name = "Label49"
        Label49.Size = New System.Drawing.Size(65, 13)
        Label49.TabIndex = 292
        Label49.Text = "Luxury Tax :"
        '
        'Label48
        '
        Label48.AutoSize = True
        Label48.ForeColor = System.Drawing.Color.Black
        Label48.Location = New System.Drawing.Point(45, 415)
        Label48.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label48.Name = "Label48"
        Label48.Size = New System.Drawing.Size(70, 13)
        Label48.TabIndex = 289
        Label48.Text = "Service Tax :"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(45, 364)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(55, 13)
        Label2.TabIndex = 287
        Label2.Text = "Discount :"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.ForeColor = System.Drawing.Color.Black
        Label3.Location = New System.Drawing.Point(45, 266)
        Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(112, 13)
        Label3.TabIndex = 285
        Label3.Text = "Room Order Charges :"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.ForeColor = System.Drawing.Color.Black
        Label4.Location = New System.Drawing.Point(45, 243)
        Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(110, 13)
        Label4.TabIndex = 283
        Label4.Text = "Total Room Charges :"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.ForeColor = System.Drawing.Color.Black
        Label33.Location = New System.Drawing.Point(45, 145)
        Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(67, 13)
        Label33.TabIndex = 279
        Label33.Text = "No. Of Kids :"
        '
        'Label47
        '
        Label47.AutoSize = True
        Label47.ForeColor = System.Drawing.Color.Black
        Label47.Location = New System.Drawing.Point(45, 120)
        Label47.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label47.Name = "Label47"
        Label47.Size = New System.Drawing.Size(86, 13)
        Label47.TabIndex = 276
        Label47.Text = "No. Of Females :"
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.ForeColor = System.Drawing.Color.Black
        Label22.Location = New System.Drawing.Point(45, 96)
        Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(75, 13)
        Label22.TabIndex = 274
        Label22.Text = "No. Of Males :"
        '
        'DateOutLabel
        '
        DateOutLabel.AutoSize = True
        DateOutLabel.ForeColor = System.Drawing.Color.Black
        DateOutLabel.Location = New System.Drawing.Point(45, 71)
        DateOutLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        DateOutLabel.Name = "DateOutLabel"
        DateOutLabel.Size = New System.Drawing.Size(56, 13)
        DateOutLabel.TabIndex = 249
        DateOutLabel.Text = "Date Out :"
        '
        'DateInLabel
        '
        DateInLabel.AutoSize = True
        DateInLabel.ForeColor = System.Drawing.Color.Black
        DateInLabel.Location = New System.Drawing.Point(45, 44)
        DateInLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        DateInLabel.Name = "DateInLabel"
        DateInLabel.Size = New System.Drawing.Size(48, 13)
        DateInLabel.TabIndex = 247
        DateInLabel.Text = "Date In :"
        '
        'RoomNumberLabel
        '
        RoomNumberLabel.AutoSize = True
        RoomNumberLabel.ForeColor = System.Drawing.Color.Black
        RoomNumberLabel.Location = New System.Drawing.Point(45, 21)
        RoomNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        RoomNumberLabel.Name = "RoomNumberLabel"
        RoomNumberLabel.Size = New System.Drawing.Size(61, 13)
        RoomNumberLabel.TabIndex = 235
        RoomNumberLabel.Text = "Room No. :"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.ForeColor = System.Drawing.Color.Black
        Label5.Location = New System.Drawing.Point(45, 169)
        Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(107, 13)
        Label5.TabIndex = 314
        Label5.Text = "No. Of Extra Person :"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(45, 194)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(93, 13)
        Label6.TabIndex = 315
        Label6.Text = "No. Of Extra Bed :"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.ForeColor = System.Drawing.Color.Black
        Label7.Location = New System.Drawing.Point(45, 219)
        Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(71, 13)
        Label7.TabIndex = 316
        Label7.Text = "No. Of Days :"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.ForeColor = System.Drawing.Color.Black
        Label13.Location = New System.Drawing.Point(45, 339)
        Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(93, 13)
        Label13.TabIndex = 317
        Label13.Text = "Laundry Charges :"
        '
        'Label57
        '
        Label57.AutoSize = True
        Label57.ForeColor = System.Drawing.Color.Black
        Label57.Location = New System.Drawing.Point(36, 417)
        Label57.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label57.Name = "Label57"
        Label57.Size = New System.Drawing.Size(41, 13)
        Label57.TabIndex = 292
        Label57.Text = "Notes :"
        '
        'Label14
        '
        Label14.AutoSize = True
        Label14.ForeColor = System.Drawing.Color.Black
        Label14.Location = New System.Drawing.Point(45, 290)
        Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label14.Name = "Label14"
        Label14.Size = New System.Drawing.Size(101, 13)
        Label14.TabIndex = 323
        Label14.Text = "Extra Bed Charges :"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.ForeColor = System.Drawing.Color.Black
        Label15.Location = New System.Drawing.Point(45, 315)
        Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(115, 13)
        Label15.TabIndex = 324
        Label15.Text = "Extra Person Charges :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbRoomNo1)
        Me.Panel1.Controls.Add(Me.txtReservationID)
        Me.Panel1.Controls.Add(Me.txtExtraPersonC)
        Me.Panel1.Controls.Add(Me.txtExtraBedC)
        Me.Panel1.Controls.Add(Me.txtRoomType)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.txtNotes)
        Me.Panel1.Controls.Add(Me.GroupBoxRateInfo)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Label57)
        Me.Panel1.Controls.Add(Me.GroupBoxGuestInfo)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.txtCheckInID)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(13, 15)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1047, 649)
        Me.Panel1.TabIndex = 2
        '
        'cmbRoomNo1
        '
        Me.cmbRoomNo1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo1.FormattingEnabled = True
        Me.cmbRoomNo1.Location = New System.Drawing.Point(129, 553)
        Me.cmbRoomNo1.Name = "cmbRoomNo1"
        Me.cmbRoomNo1.Size = New System.Drawing.Size(101, 21)
        Me.cmbRoomNo1.TabIndex = 299
        Me.cmbRoomNo1.Visible = False
        '
        'txtReservationID
        '
        Me.txtReservationID.Location = New System.Drawing.Point(245, 554)
        Me.txtReservationID.Name = "txtReservationID"
        Me.txtReservationID.Size = New System.Drawing.Size(111, 20)
        Me.txtReservationID.TabIndex = 298
        Me.txtReservationID.Visible = False
        '
        'txtExtraPersonC
        '
        Me.txtExtraPersonC.Location = New System.Drawing.Point(245, 614)
        Me.txtExtraPersonC.Name = "txtExtraPersonC"
        Me.txtExtraPersonC.Size = New System.Drawing.Size(111, 20)
        Me.txtExtraPersonC.TabIndex = 297
        Me.txtExtraPersonC.Visible = False
        '
        'txtExtraBedC
        '
        Me.txtExtraBedC.Location = New System.Drawing.Point(128, 614)
        Me.txtExtraBedC.Name = "txtExtraBedC"
        Me.txtExtraBedC.Size = New System.Drawing.Size(111, 20)
        Me.txtExtraBedC.TabIndex = 296
        Me.txtExtraBedC.Visible = False
        '
        'txtRoomType
        '
        Me.txtRoomType.Location = New System.Drawing.Point(246, 582)
        Me.txtRoomType.Name = "txtRoomType"
        Me.txtRoomType.Size = New System.Drawing.Size(111, 20)
        Me.txtRoomType.TabIndex = 295
        Me.txtRoomType.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnCheckedIN)
        Me.GroupBox6.Location = New System.Drawing.Point(922, 436)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(109, 93)
        Me.GroupBox6.TabIndex = 294
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Reservation"
        '
        'btnCheckedIN
        '
        Me.btnCheckedIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheckedIN.Enabled = False
        Me.btnCheckedIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCheckedIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckedIN.Location = New System.Drawing.Point(10, 26)
        Me.btnCheckedIN.Name = "btnCheckedIN"
        Me.btnCheckedIN.Size = New System.Drawing.Size(87, 50)
        Me.btnCheckedIN.TabIndex = 5
        Me.btnCheckedIN.Text = "&Check IN"
        Me.btnCheckedIN.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnRoomAvailability)
        Me.GroupBox5.Location = New System.Drawing.Point(922, 337)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(109, 93)
        Me.GroupBox5.TabIndex = 293
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Check"
        '
        'btnRoomAvailability
        '
        Me.btnRoomAvailability.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRoomAvailability.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRoomAvailability.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoomAvailability.Location = New System.Drawing.Point(10, 26)
        Me.btnRoomAvailability.Name = "btnRoomAvailability"
        Me.btnRoomAvailability.Size = New System.Drawing.Size(87, 50)
        Me.btnRoomAvailability.TabIndex = 5
        Me.btnRoomAvailability.Text = "&Room Availability"
        Me.btnRoomAvailability.UseVisualStyleBackColor = True
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Location = New System.Drawing.Point(38, 436)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes.Size = New System.Drawing.Size(272, 102)
        Me.txtNotes.TabIndex = 291
        Me.txtNotes.Text = ""
        '
        'GroupBoxRateInfo
        '
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox3)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox2)
        Me.GroupBoxRateInfo.Controls.Add(Me.TextBox1)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtLaundryCharges)
        Me.GroupBoxRateInfo.Controls.Add(Label15)
        Me.GroupBoxRateInfo.Controls.Add(Label14)
        Me.GroupBoxRateInfo.Controls.Add(Me.txtExtraPersonCharges)
        Me.GroupBoxRateInfo.Controls.Add(Me.CheckBox1)
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
        Me.GroupBoxRateInfo.Controls.Add(Me.Button4)
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
        Me.GroupBoxRateInfo.Location = New System.Drawing.Point(470, 76)
        Me.GroupBoxRateInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRateInfo.Name = "GroupBoxRateInfo"
        Me.GroupBoxRateInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRateInfo.Size = New System.Drawing.Size(436, 549)
        Me.GroupBoxRateInfo.TabIndex = 1
        Me.GroupBoxRateInfo.TabStop = False
        Me.GroupBoxRateInfo.Text = "Rate Information"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(307, 304)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 327
        Me.TextBox3.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(307, 278)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 326
        Me.TextBox2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(307, 252)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 325
        Me.TextBox1.Visible = False
        '
        'txtLaundryCharges
        '
        Me.txtLaundryCharges.Location = New System.Drawing.Point(169, 339)
        Me.txtLaundryCharges.Name = "txtLaundryCharges"
        Me.txtLaundryCharges.ReadOnly = True
        Me.txtLaundryCharges.Size = New System.Drawing.Size(84, 20)
        Me.txtLaundryCharges.TabIndex = 14
        Me.txtLaundryCharges.Text = "0"
        Me.txtLaundryCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtraPersonCharges
        '
        Me.txtExtraPersonCharges.Location = New System.Drawing.Point(169, 315)
        Me.txtExtraPersonCharges.Name = "txtExtraPersonCharges"
        Me.txtExtraPersonCharges.ReadOnly = True
        Me.txtExtraPersonCharges.Size = New System.Drawing.Size(84, 20)
        Me.txtExtraPersonCharges.TabIndex = 13
        Me.txtExtraPersonCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(307, 478)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(94, 17)
        Me.CheckBox1.TabIndex = 321
        Me.CheckBox1.Text = "Tax Paid Rate"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'hsExtraBed
        '
        Me.hsExtraBed.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsExtraBed.LargeChange = 1
        Me.hsExtraBed.Location = New System.Drawing.Point(267, 193)
        Me.hsExtraBed.Maximum = 32767
        Me.hsExtraBed.Name = "hsExtraBed"
        Me.hsExtraBed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsExtraBed.Size = New System.Drawing.Size(23, 24)
        Me.hsExtraBed.TabIndex = 320
        Me.hsExtraBed.TabStop = True
        '
        'hsExtraPerson
        '
        Me.hsExtraPerson.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsExtraPerson.LargeChange = 1
        Me.hsExtraPerson.Location = New System.Drawing.Point(267, 169)
        Me.hsExtraPerson.Maximum = 32767
        Me.hsExtraPerson.Name = "hsExtraPerson"
        Me.hsExtraPerson.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsExtraPerson.Size = New System.Drawing.Size(23, 24)
        Me.hsExtraPerson.TabIndex = 319
        Me.hsExtraPerson.TabStop = True
        '
        'hsKids
        '
        Me.hsKids.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsKids.LargeChange = 1
        Me.hsKids.Location = New System.Drawing.Point(267, 145)
        Me.hsKids.Maximum = 32767
        Me.hsKids.Name = "hsKids"
        Me.hsKids.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsKids.Size = New System.Drawing.Size(23, 24)
        Me.hsKids.TabIndex = 318
        Me.hsKids.TabStop = True
        '
        'txtBalance
        '
        Me.txtBalance.Location = New System.Drawing.Point(169, 517)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(84, 20)
        Me.txtBalance.TabIndex = 21
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRoomOrderCharges
        '
        Me.txtRoomOrderCharges.Location = New System.Drawing.Point(169, 266)
        Me.txtRoomOrderCharges.Name = "txtRoomOrderCharges"
        Me.txtRoomOrderCharges.ReadOnly = True
        Me.txtRoomOrderCharges.Size = New System.Drawing.Size(84, 20)
        Me.txtRoomOrderCharges.TabIndex = 11
        Me.txtRoomOrderCharges.Text = "0"
        Me.txtRoomOrderCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfExtraBed
        '
        Me.txtNoOfExtraBed.Location = New System.Drawing.Point(169, 194)
        Me.txtNoOfExtraBed.Name = "txtNoOfExtraBed"
        Me.txtNoOfExtraBed.ReadOnly = True
        Me.txtNoOfExtraBed.Size = New System.Drawing.Size(84, 20)
        Me.txtNoOfExtraBed.TabIndex = 8
        Me.txtNoOfExtraBed.Text = "0"
        Me.txtNoOfExtraBed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfExtraPerson
        '
        Me.txtNoOfExtraPerson.Location = New System.Drawing.Point(169, 169)
        Me.txtNoOfExtraPerson.Name = "txtNoOfExtraPerson"
        Me.txtNoOfExtraPerson.ReadOnly = True
        Me.txtNoOfExtraPerson.Size = New System.Drawing.Size(84, 20)
        Me.txtNoOfExtraPerson.TabIndex = 7
        Me.txtNoOfExtraPerson.Text = "0"
        Me.txtNoOfExtraPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfKids
        '
        Me.txtNoOfKids.Location = New System.Drawing.Point(169, 145)
        Me.txtNoOfKids.Name = "txtNoOfKids"
        Me.txtNoOfKids.ReadOnly = True
        Me.txtNoOfKids.Size = New System.Drawing.Size(84, 20)
        Me.txtNoOfKids.TabIndex = 6
        Me.txtNoOfKids.Text = "0"
        Me.txtNoOfKids.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(399, 18)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(29, 21)
        Me.Button4.TabIndex = 309
        Me.Button4.Text = "<"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtDiscountAmount
        '
        Me.txtDiscountAmount.Location = New System.Drawing.Point(309, 364)
        Me.txtDiscountAmount.Name = "txtDiscountAmount"
        Me.txtDiscountAmount.ReadOnly = True
        Me.txtDiscountAmount.Size = New System.Drawing.Size(84, 20)
        Me.txtDiscountAmount.TabIndex = 22
        Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(267, 364)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(20, 16)
        Me.Label58.TabIndex = 305
        Me.Label58.Text = "%"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(267, 442)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(20, 16)
        Me.Label56.TabIndex = 304
        Me.Label56.Text = "%"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(267, 415)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(20, 16)
        Me.Label55.TabIndex = 303
        Me.Label55.Text = "%"
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Location = New System.Drawing.Point(169, 492)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalPaid.TabIndex = 20
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Location = New System.Drawing.Point(169, 466)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(84, 20)
        Me.txtGrandTotal.TabIndex = 19
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxPer
        '
        Me.txtServiceTaxPer.Location = New System.Drawing.Point(169, 415)
        Me.txtServiceTaxPer.Name = "txtServiceTaxPer"
        Me.txtServiceTaxPer.Size = New System.Drawing.Size(84, 20)
        Me.txtServiceTaxPer.TabIndex = 17
        Me.txtServiceTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtraBedCharges
        '
        Me.txtExtraBedCharges.Location = New System.Drawing.Point(169, 290)
        Me.txtExtraBedCharges.Name = "txtExtraBedCharges"
        Me.txtExtraBedCharges.ReadOnly = True
        Me.txtExtraBedCharges.Size = New System.Drawing.Size(84, 20)
        Me.txtExtraBedCharges.TabIndex = 12
        Me.txtExtraBedCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxAmount
        '
        Me.txtLuxuryTaxAmount.Location = New System.Drawing.Point(307, 442)
        Me.txtLuxuryTaxAmount.Name = "txtLuxuryTaxAmount"
        Me.txtLuxuryTaxAmount.ReadOnly = True
        Me.txtLuxuryTaxAmount.Size = New System.Drawing.Size(84, 20)
        Me.txtLuxuryTaxAmount.TabIndex = 24
        Me.txtLuxuryTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxPer
        '
        Me.txtLuxuryTaxPer.Location = New System.Drawing.Point(169, 441)
        Me.txtLuxuryTaxPer.Name = "txtLuxuryTaxPer"
        Me.txtLuxuryTaxPer.Size = New System.Drawing.Size(84, 20)
        Me.txtLuxuryTaxPer.TabIndex = 18
        Me.txtLuxuryTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxAmount
        '
        Me.txtServiceTaxAmount.Location = New System.Drawing.Point(307, 415)
        Me.txtServiceTaxAmount.Name = "txtServiceTaxAmount"
        Me.txtServiceTaxAmount.ReadOnly = True
        Me.txtServiceTaxAmount.Size = New System.Drawing.Size(84, 20)
        Me.txtServiceTaxAmount.TabIndex = 23
        Me.txtServiceTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscountPer
        '
        Me.txtDiscountPer.Location = New System.Drawing.Point(169, 364)
        Me.txtDiscountPer.Name = "txtDiscountPer"
        Me.txtDiscountPer.Size = New System.Drawing.Size(84, 20)
        Me.txtDiscountPer.TabIndex = 15
        Me.txtDiscountPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Location = New System.Drawing.Point(169, 389)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(84, 20)
        Me.txtSubTotal.TabIndex = 16
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRoomCharges
        '
        Me.txtTotalRoomCharges.Location = New System.Drawing.Point(169, 242)
        Me.txtTotalRoomCharges.Name = "txtTotalRoomCharges"
        Me.txtTotalRoomCharges.ReadOnly = True
        Me.txtTotalRoomCharges.Size = New System.Drawing.Size(84, 20)
        Me.txtTotalRoomCharges.TabIndex = 10
        Me.txtTotalRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfDays
        '
        Me.txtNoOfDays.Location = New System.Drawing.Point(169, 218)
        Me.txtNoOfDays.Name = "txtNoOfDays"
        Me.txtNoOfDays.ReadOnly = True
        Me.txtNoOfDays.Size = New System.Drawing.Size(84, 20)
        Me.txtNoOfDays.TabIndex = 9
        Me.txtNoOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRoomCharges
        '
        Me.txtRoomCharges.Location = New System.Drawing.Point(305, 18)
        Me.txtRoomCharges.Name = "txtRoomCharges"
        Me.txtRoomCharges.Size = New System.Drawing.Size(86, 20)
        Me.txtRoomCharges.TabIndex = 1
        Me.txtRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hsFemales
        '
        Me.hsFemales.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsFemales.LargeChange = 1
        Me.hsFemales.Location = New System.Drawing.Point(267, 121)
        Me.hsFemales.Maximum = 32767
        Me.hsFemales.Name = "hsFemales"
        Me.hsFemales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsFemales.Size = New System.Drawing.Size(23, 24)
        Me.hsFemales.TabIndex = 278
        Me.hsFemales.TabStop = True
        '
        'txtNoOfFemales
        '
        Me.txtNoOfFemales.Location = New System.Drawing.Point(169, 120)
        Me.txtNoOfFemales.Name = "txtNoOfFemales"
        Me.txtNoOfFemales.ReadOnly = True
        Me.txtNoOfFemales.Size = New System.Drawing.Size(84, 20)
        Me.txtNoOfFemales.TabIndex = 5
        Me.txtNoOfFemales.Text = "0"
        Me.txtNoOfFemales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfMales
        '
        Me.txtNoOfMales.Location = New System.Drawing.Point(169, 96)
        Me.txtNoOfMales.Name = "txtNoOfMales"
        Me.txtNoOfMales.ReadOnly = True
        Me.txtNoOfMales.Size = New System.Drawing.Size(84, 20)
        Me.txtNoOfMales.TabIndex = 4
        Me.txtNoOfMales.Text = "0"
        Me.txtNoOfMales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDateOut
        '
        Me.dtpDateOut.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateOut.Location = New System.Drawing.Point(169, 71)
        Me.dtpDateOut.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateOut.Name = "dtpDateOut"
        Me.dtpDateOut.Size = New System.Drawing.Size(121, 20)
        Me.dtpDateOut.TabIndex = 3
        '
        'cmbRoomNo
        '
        Me.cmbRoomNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo.FormattingEnabled = True
        Me.cmbRoomNo.Location = New System.Drawing.Point(169, 20)
        Me.cmbRoomNo.Name = "cmbRoomNo"
        Me.cmbRoomNo.Size = New System.Drawing.Size(101, 21)
        Me.cmbRoomNo.TabIndex = 0
        '
        'hsMales
        '
        Me.hsMales.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsMales.LargeChange = 1
        Me.hsMales.Location = New System.Drawing.Point(267, 95)
        Me.hsMales.Maximum = 32767
        Me.hsMales.Name = "hsMales"
        Me.hsMales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsMales.Size = New System.Drawing.Size(23, 24)
        Me.hsMales.TabIndex = 253
        Me.hsMales.TabStop = True
        '
        'dtpDateIn
        '
        Me.dtpDateIn.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateIn.Location = New System.Drawing.Point(169, 47)
        Me.dtpDateIn.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateIn.Name = "dtpDateIn"
        Me.dtpDateIn.Size = New System.Drawing.Size(121, 20)
        Me.dtpDateIn.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnGetData)
        Me.Panel4.Controls.Add(Me.btnDelete)
        Me.Panel4.Controls.Add(Me.btnClose)
        Me.Panel4.Controls.Add(Me.btnUpdate)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnNew)
        Me.Panel4.Location = New System.Drawing.Point(920, 80)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(111, 203)
        Me.Panel4.TabIndex = 289
        '
        'btnGetData
        '
        Me.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGetData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.Location = New System.Drawing.Point(13, 133)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(82, 28)
        Me.btnGetData.TabIndex = 6
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(13, 103)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(82, 28)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(13, 163)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(82, 28)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(13, 72)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(82, 28)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(13, 41)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 28)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Check IN"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(13, 10)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(82, 28)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtReligion)
        Me.GroupBoxGuestInfo.Controls.Add(Label8)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtOccupation)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGender)
        Me.GroupBoxGuestInfo.Controls.Add(Label9)
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
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(9, 76)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(456, 295)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        Me.GroupBoxGuestInfo.Text = "Guest Information"
        '
        'txtReligion
        '
        Me.txtReligion.Location = New System.Drawing.Point(119, 106)
        Me.txtReligion.Name = "txtReligion"
        Me.txtReligion.ReadOnly = True
        Me.txtReligion.Size = New System.Drawing.Size(229, 20)
        Me.txtReligion.TabIndex = 3
        '
        'txtOccupation
        '
        Me.txtOccupation.Location = New System.Drawing.Point(119, 132)
        Me.txtOccupation.Name = "txtOccupation"
        Me.txtOccupation.ReadOnly = True
        Me.txtOccupation.Size = New System.Drawing.Size(229, 20)
        Me.txtOccupation.TabIndex = 4
        '
        'txtGender
        '
        Me.txtGender.Location = New System.Drawing.Point(119, 80)
        Me.txtGender.Name = "txtGender"
        Me.txtGender.ReadOnly = True
        Me.txtGender.Size = New System.Drawing.Size(102, 20)
        Me.txtGender.TabIndex = 2
        '
        'txtIDType
        '
        Me.txtIDType.Location = New System.Drawing.Point(119, 235)
        Me.txtIDType.Name = "txtIDType"
        Me.txtIDType.ReadOnly = True
        Me.txtIDType.Size = New System.Drawing.Size(195, 20)
        Me.txtIDType.TabIndex = 8
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(280, 28)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(34, 21)
        Me.Button13.TabIndex = 279
        Me.Button13.Text = "..."
        Me.Button13.UseVisualStyleBackColor = True
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Location = New System.Drawing.Point(119, 261)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.ReadOnly = True
        Me.txtIDNumber.Size = New System.Drawing.Size(256, 20)
        Me.txtIDNumber.TabIndex = 9
        '
        'txtGuestContactNo
        '
        Me.txtGuestContactNo.Location = New System.Drawing.Point(119, 209)
        Me.txtGuestContactNo.Name = "txtGuestContactNo"
        Me.txtGuestContactNo.ReadOnly = True
        Me.txtGuestContactNo.Size = New System.Drawing.Size(149, 20)
        Me.txtGuestContactNo.TabIndex = 7
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(320, 235)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(111, 20)
        Me.txtID.TabIndex = 7
        Me.txtID.Visible = False
        '
        'txtGuestCity
        '
        Me.txtGuestCity.Location = New System.Drawing.Point(119, 183)
        Me.txtGuestCity.Name = "txtGuestCity"
        Me.txtGuestCity.ReadOnly = True
        Me.txtGuestCity.Size = New System.Drawing.Size(319, 20)
        Me.txtGuestCity.TabIndex = 6
        '
        'txtGuestAddress
        '
        Me.txtGuestAddress.Location = New System.Drawing.Point(119, 157)
        Me.txtGuestAddress.Name = "txtGuestAddress"
        Me.txtGuestAddress.ReadOnly = True
        Me.txtGuestAddress.Size = New System.Drawing.Size(319, 20)
        Me.txtGuestAddress.TabIndex = 5
        '
        'txtGuestName
        '
        Me.txtGuestName.Location = New System.Drawing.Point(119, 54)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.ReadOnly = True
        Me.txtGuestName.Size = New System.Drawing.Size(319, 20)
        Me.txtGuestName.TabIndex = 1
        '
        'txtGuestID
        '
        Me.txtGuestID.Location = New System.Drawing.Point(119, 29)
        Me.txtGuestID.Name = "txtGuestID"
        Me.txtGuestID.ReadOnly = True
        Me.txtGuestID.Size = New System.Drawing.Size(149, 20)
        Me.txtGuestID.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(6, 605)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(39, 13)
        Me.lblUser.TabIndex = 5
        Me.lblUser.Text = "Label8"
        Me.lblUser.Visible = False
        '
        'txtCheckInID
        '
        Me.txtCheckInID.Location = New System.Drawing.Point(128, 582)
        Me.txtCheckInID.Name = "txtCheckInID"
        Me.txtCheckInID.Size = New System.Drawing.Size(111, 20)
        Me.txtCheckInID.TabIndex = 4
        Me.txtCheckInID.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(9, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 62)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(444, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Check IN"
        '
        'frmCheckIN_Room
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(1072, 676)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckIN_Room"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBoxRateInfo.ResumeLayout(False)
        Me.GroupBoxRateInfo.PerformLayout()
        Me.Panel4.ResumeLayout(False)
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
    Friend WithEvents Button4 As System.Windows.Forms.Button
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
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Public WithEvents btnCheckedIN As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents btnRoomAvailability As System.Windows.Forms.Button
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Public WithEvents hsExtraBed As System.Windows.Forms.HScrollBar
    Public WithEvents hsExtraPerson As System.Windows.Forms.HScrollBar
    Public WithEvents hsKids As System.Windows.Forms.HScrollBar
    Friend WithEvents txtRoomType As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
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

End Class
