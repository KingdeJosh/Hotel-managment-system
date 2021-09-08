<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckIn
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
        Dim DateOutLabel As System.Windows.Forms.Label
        Dim DateInLabel As System.Windows.Forms.Label
        Dim RoomNumberLabel As System.Windows.Forms.Label
        Dim IDNumberLabel As System.Windows.Forms.Label
        Dim IDTypeIDLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label46 As System.Windows.Forms.Label
        Dim Label22 As System.Windows.Forms.Label
        Dim Label47 As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label9 As System.Windows.Forms.Label
        Dim Label48 As System.Windows.Forms.Label
        Dim Label49 As System.Windows.Forms.Label
        Dim Label50 As System.Windows.Forms.Label
        Dim Label51 As System.Windows.Forms.Label
        Dim Label52 As System.Windows.Forms.Label
        Dim Label53 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label59 As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label25 As System.Windows.Forms.Label
        Dim Label60 As System.Windows.Forms.Label
        Dim Label61 As System.Windows.Forms.Label
        Dim Label62 As System.Windows.Forms.Label
        Dim Label63 As System.Windows.Forms.Label
        Dim Label40 As System.Windows.Forms.Label
        Dim Label41 As System.Windows.Forms.Label
        Dim Label42 As System.Windows.Forms.Label
        Dim Label43 As System.Windows.Forms.Label
        Dim Label44 As System.Windows.Forms.Label
        Dim Label45 As System.Windows.Forms.Label
        Dim Label67 As System.Windows.Forms.Label
        Dim Label31 As System.Windows.Forms.Label
        Dim Label32 As System.Windows.Forms.Label
        Dim Label34 As System.Windows.Forms.Label
        Dim Label35 As System.Windows.Forms.Label
        Dim Label36 As System.Windows.Forms.Label
        Dim Label37 As System.Windows.Forms.Label
        Dim Label38 As System.Windows.Forms.Label
        Dim Label39 As System.Windows.Forms.Label
        Dim Label65 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckIn))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Searchreserved = New System.Windows.Forms.TextBox()
        Me.GroupControl8 = New DevExpress.XtraEditors.GroupControl()
        Me.reservationGR = New System.Windows.Forms.DataGridView()
        Me.Search = New DevExpress.XtraEditors.SimpleButton()
        Me.guestyonisearch = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupControl7 = New DevExpress.XtraEditors.GroupControl()
        Me.guestRecordG = New System.Windows.Forms.DataGridView()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtTotalPaid = New System.Windows.Forms.TextBox()
        Me.txtOtherCharges = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.txtTotalRoomCharges = New System.Windows.Forms.TextBox()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.txtLuxuryTaxPer = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxPer = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxAmount = New System.Windows.Forms.TextBox()
        Me.txtDiscount = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtLuxuryTaxAmount = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtDiscountPer = New System.Windows.Forms.TextBox()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.dtpDateIn = New System.Windows.Forms.DateTimePicker()
        Me.cmbCurrency2 = New System.Windows.Forms.ComboBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.hsAdults = New System.Windows.Forms.HScrollBar()
        Me.cmbRoomNo = New System.Windows.Forms.ComboBox()
        Me.dtpDateOut = New System.Windows.Forms.DateTimePicker()
        Me.txtNoOfAdults = New System.Windows.Forms.TextBox()
        Me.txtNoOfKids = New System.Windows.Forms.TextBox()
        Me.hsKids = New System.Windows.Forms.HScrollBar()
        Me.txtRoomCharges = New System.Windows.Forms.TextBox()
        Me.txtNoOfDays = New System.Windows.Forms.TextBox()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCheckedIN = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate_record = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtIDType = New System.Windows.Forms.TextBox()
        Me.txtGuestAddress = New System.Windows.Forms.TextBox()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.txtGuestContactNo = New System.Windows.Forms.TextBox()
        Me.txtGuestCity = New System.Windows.Forms.TextBox()
        Me.txtGuestID = New System.Windows.Forms.TextBox()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.txtCurrencyID = New System.Windows.Forms.TextBox()
        Me.txtHotelID = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtReservationNo = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cmbRoomNo1 = New System.Windows.Forms.ComboBox()
        Me.txtID1 = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.GroupBoxRateInfo = New System.Windows.Forms.GroupBox()
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.hallsearch = New System.Windows.Forms.TextBox()
        Me.GroupControl22 = New DevExpress.XtraEditors.GroupControl()
        Me.hallandgarden = New System.Windows.Forms.DataGridView()
        Me.btnGetData1 = New System.Windows.Forms.Button()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.guestnameyoni = New System.Windows.Forms.TextBox()
        Me.GroupControl16 = New DevExpress.XtraEditors.GroupControl()
        Me.guestR = New System.Windows.Forms.DataGridView()
        Me.GroupControl15 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnNew1 = New System.Windows.Forms.Button()
        Me.btnSave1 = New System.Windows.Forms.Button()
        Me.btnUpdate1 = New System.Windows.Forms.Button()
        Me.btnDelete1 = New System.Windows.Forms.Button()
        Me.GroupControl14 = New DevExpress.XtraEditors.GroupControl()
        Me.txtNotes1 = New System.Windows.Forms.RichTextBox()
        Me.GroupControl13 = New DevExpress.XtraEditors.GroupControl()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.dtpDateFrom_Garden = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateTo_Garden = New System.Windows.Forms.DateTimePicker()
        Me.txtDaysGarden = New System.Windows.Forms.TextBox()
        Me.txtRateGarden = New System.Windows.Forms.TextBox()
        Me.txtTotalGarden = New System.Windows.Forms.TextBox()
        Me.GroupControl11 = New DevExpress.XtraEditors.GroupControl()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.txtTotalPaid1 = New System.Windows.Forms.TextBox()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.txtGrandTotal1 = New System.Windows.Forms.TextBox()
        Me.txtBalance1 = New System.Windows.Forms.TextBox()
        Me.txtOtherCharges1 = New System.Windows.Forms.TextBox()
        Me.txtSubTotal1 = New System.Windows.Forms.TextBox()
        Me.GroupControl12 = New DevExpress.XtraEditors.GroupControl()
        Me.dtpDateFrom_Hall = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpDateTo_Hall = New System.Windows.Forms.DateTimePicker()
        Me.txtDaysHall = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRateHall = New System.Windows.Forms.TextBox()
        Me.txtTotalHall = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupControl10 = New DevExpress.XtraEditors.GroupControl()
        Me.txtServiceTaxPer1 = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxAmount1 = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxPer1 = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxAmount1 = New System.Windows.Forms.TextBox()
        Me.txtDiscount1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDiscountPer1 = New System.Windows.Forms.TextBox()
        Me.GroupControl9 = New DevExpress.XtraEditors.GroupControl()
        Me.txtIDType1 = New System.Windows.Forms.TextBox()
        Me.txtGuestAddress1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtIDNumber1 = New System.Windows.Forms.TextBox()
        Me.txtContactNo1 = New System.Windows.Forms.TextBox()
        Me.txtCity1 = New System.Windows.Forms.TextBox()
        Me.txtGuestID1 = New System.Windows.Forms.TextBox()
        Me.txtGuestName1 = New System.Windows.Forms.TextBox()
        Me.txtEducessTaxAmount = New System.Windows.Forms.TextBox()
        Me.txtHEducessTaxAmount = New System.Windows.Forms.TextBox()
        Me.txtEducessTax = New System.Windows.Forms.TextBox()
        Me.txtHEduCessTax = New System.Windows.Forms.TextBox()
        Me.DateTimePicker6 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker5 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.txtID2 = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.SimpleButton8 = New DevExpress.XtraEditors.SimpleButton()
        Me.searchallorgarden = New System.Windows.Forms.TextBox()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGetData2 = New System.Windows.Forms.Button()
        Me.guests = New System.Windows.Forms.TextBox()
        Me.GroupControl24 = New DevExpress.XtraEditors.GroupControl()
        Me.hallorgarden = New System.Windows.Forms.DataGridView()
        Me.GroupControl23 = New DevExpress.XtraEditors.GroupControl()
        Me.guestrr = New System.Windows.Forms.DataGridView()
        Me.GroupControl21 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPrint1 = New System.Windows.Forms.Button()
        Me.btnSave2 = New System.Windows.Forms.Button()
        Me.btnUpdate2 = New System.Windows.Forms.Button()
        Me.btnDelete2 = New System.Windows.Forms.Button()
        Me.btnNew2 = New System.Windows.Forms.Button()
        Me.GroupControl20 = New DevExpress.XtraEditors.GroupControl()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.DateTo = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtNoOfDays1 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.txtTotalCharges = New System.Windows.Forms.TextBox()
        Me.GroupControl19 = New DevExpress.XtraEditors.GroupControl()
        Me.cmbCurrency1 = New System.Windows.Forms.ComboBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.txtGrandTotal2 = New System.Windows.Forms.TextBox()
        Me.txtTotalPaid2 = New System.Windows.Forms.TextBox()
        Me.txtOtherCharges2 = New System.Windows.Forms.TextBox()
        Me.txtSubTotal2 = New System.Windows.Forms.TextBox()
        Me.txtBalance2 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupControl18 = New DevExpress.XtraEditors.GroupControl()
        Me.txtServiceTaxPer2 = New System.Windows.Forms.TextBox()
        Me.txtServiceTaxAmount2 = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxPer2 = New System.Windows.Forms.TextBox()
        Me.txtDiscount2 = New System.Windows.Forms.TextBox()
        Me.txtLuxuryTaxAmount2 = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtDiscountPer2 = New System.Windows.Forms.TextBox()
        Me.GroupControl17 = New DevExpress.XtraEditors.GroupControl()
        Me.txtGuestAddress2 = New System.Windows.Forms.TextBox()
        Me.txtIDType2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtIDNumber2 = New System.Windows.Forms.TextBox()
        Me.txtGuestContactNo2 = New System.Windows.Forms.TextBox()
        Me.txtGuestID2 = New System.Windows.Forms.TextBox()
        Me.txtGuestCity2 = New System.Windows.Forms.TextBox()
        Me.txtGuestName2 = New System.Windows.Forms.TextBox()
        Me.txteducessTaxAmount1 = New System.Windows.Forms.TextBox()
        Me.txtHeducessTaxAmount1 = New System.Windows.Forms.TextBox()
        Me.txteducessTax1 = New System.Windows.Forms.TextBox()
        Me.txtHeducessTax1 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtID3 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtNotes2 = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        DateOutLabel = New System.Windows.Forms.Label()
        DateInLabel = New System.Windows.Forms.Label()
        RoomNumberLabel = New System.Windows.Forms.Label()
        IDNumberLabel = New System.Windows.Forms.Label()
        IDTypeIDLabel = New System.Windows.Forms.Label()
        AddressLabel = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label46 = New System.Windows.Forms.Label()
        Label22 = New System.Windows.Forms.Label()
        Label47 = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label9 = New System.Windows.Forms.Label()
        Label48 = New System.Windows.Forms.Label()
        Label49 = New System.Windows.Forms.Label()
        Label50 = New System.Windows.Forms.Label()
        Label51 = New System.Windows.Forms.Label()
        Label52 = New System.Windows.Forms.Label()
        Label53 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label59 = New System.Windows.Forms.Label()
        Label21 = New System.Windows.Forms.Label()
        Label23 = New System.Windows.Forms.Label()
        Label24 = New System.Windows.Forms.Label()
        Label25 = New System.Windows.Forms.Label()
        Label60 = New System.Windows.Forms.Label()
        Label61 = New System.Windows.Forms.Label()
        Label62 = New System.Windows.Forms.Label()
        Label63 = New System.Windows.Forms.Label()
        Label40 = New System.Windows.Forms.Label()
        Label41 = New System.Windows.Forms.Label()
        Label42 = New System.Windows.Forms.Label()
        Label43 = New System.Windows.Forms.Label()
        Label44 = New System.Windows.Forms.Label()
        Label45 = New System.Windows.Forms.Label()
        Label67 = New System.Windows.Forms.Label()
        Label31 = New System.Windows.Forms.Label()
        Label32 = New System.Windows.Forms.Label()
        Label34 = New System.Windows.Forms.Label()
        Label35 = New System.Windows.Forms.Label()
        Label36 = New System.Windows.Forms.Label()
        Label37 = New System.Windows.Forms.Label()
        Label38 = New System.Windows.Forms.Label()
        Label39 = New System.Windows.Forms.Label()
        Label65 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl8.SuspendLayout()
        CType(Me.reservationGR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl7.SuspendLayout()
        CType(Me.guestRecordG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.GroupControl22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl22.SuspendLayout()
        CType(Me.hallandgarden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl16.SuspendLayout()
        CType(Me.guestR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl15.SuspendLayout()
        CType(Me.GroupControl14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl14.SuspendLayout()
        CType(Me.GroupControl13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl13.SuspendLayout()
        CType(Me.GroupControl11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl11.SuspendLayout()
        CType(Me.GroupControl12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl12.SuspendLayout()
        CType(Me.GroupControl10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl10.SuspendLayout()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl9.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.GroupControl24, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl24.SuspendLayout()
        CType(Me.hallorgarden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl23, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl23.SuspendLayout()
        CType(Me.guestrr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl21, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl21.SuspendLayout()
        CType(Me.GroupControl20, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl20.SuspendLayout()
        CType(Me.GroupControl19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl19.SuspendLayout()
        CType(Me.GroupControl18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl18.SuspendLayout()
        CType(Me.GroupControl17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl17.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DateOutLabel
        '
        DateOutLabel.AutoSize = True
        DateOutLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DateOutLabel.ForeColor = System.Drawing.Color.Black
        DateOutLabel.Location = New System.Drawing.Point(216, 43)
        DateOutLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        DateOutLabel.Name = "DateOutLabel"
        DateOutLabel.Size = New System.Drawing.Size(55, 15)
        DateOutLabel.TabIndex = 249
        DateOutLabel.Text = "Date Out"
        '
        'DateInLabel
        '
        DateInLabel.AutoSize = True
        DateInLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DateInLabel.ForeColor = System.Drawing.Color.Black
        DateInLabel.Location = New System.Drawing.Point(9, 40)
        DateInLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        DateInLabel.Name = "DateInLabel"
        DateInLabel.Size = New System.Drawing.Size(46, 15)
        DateInLabel.TabIndex = 247
        DateInLabel.Text = "Date In"
        '
        'RoomNumberLabel
        '
        RoomNumberLabel.AutoSize = True
        RoomNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        RoomNumberLabel.ForeColor = System.Drawing.Color.Black
        RoomNumberLabel.Location = New System.Drawing.Point(9, 7)
        RoomNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        RoomNumberLabel.Name = "RoomNumberLabel"
        RoomNumberLabel.Size = New System.Drawing.Size(63, 15)
        RoomNumberLabel.TabIndex = 235
        RoomNumberLabel.Text = "Room No."
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        IDNumberLabel.ForeColor = System.Drawing.Color.Black
        IDNumberLabel.Location = New System.Drawing.Point(30, 161)
        IDNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(58, 13)
        IDNumberLabel.TabIndex = 267
        IDNumberLabel.Text = "ID Number"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(30, 137)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(42, 13)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "IDType"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        AddressLabel.ForeColor = System.Drawing.Color.Black
        AddressLabel.Location = New System.Drawing.Point(30, 56)
        AddressLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(46, 13)
        AddressLabel.TabIndex = 263
        AddressLabel.Text = "Address"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.Font = New System.Drawing.Font("Tahoma", 8.25!)
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(30, 4)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(49, 13)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "Guest ID"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(29, 30)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(65, 13)
        Label6.TabIndex = 271
        Label6.Text = "Guest Name"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(30, 85)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(26, 13)
        Label2.TabIndex = 274
        Label2.Text = "City"
        '
        'Label46
        '
        Label46.AutoSize = True
        Label46.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Label46.ForeColor = System.Drawing.Color.Black
        Label46.Location = New System.Drawing.Point(29, 111)
        Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label46.Name = "Label46"
        Label46.Size = New System.Drawing.Size(65, 13)
        Label46.TabIndex = 276
        Label46.Text = "Contact No."
        '
        'Label22
        '
        Label22.AutoSize = True
        Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label22.ForeColor = System.Drawing.Color.Black
        Label22.Location = New System.Drawing.Point(8, 70)
        Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label22.Name = "Label22"
        Label22.Size = New System.Drawing.Size(77, 15)
        Label22.TabIndex = 274
        Label22.Text = "No. Of Adults"
        '
        'Label47
        '
        Label47.AutoSize = True
        Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label47.ForeColor = System.Drawing.Color.Black
        Label47.Location = New System.Drawing.Point(188, 71)
        Label47.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label47.Name = "Label47"
        Label47.Size = New System.Drawing.Size(68, 15)
        Label47.TabIndex = 276
        Label47.Text = "No. Of Kids"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label33.ForeColor = System.Drawing.Color.Black
        Label33.Location = New System.Drawing.Point(9, 100)
        Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(69, 15)
        Label33.TabIndex = 279
        Label33.Text = "No. Of days"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label1.ForeColor = System.Drawing.Color.Black
        Label1.Location = New System.Drawing.Point(194, 20)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(98, 15)
        Label1.TabIndex = 283
        Label1.Text = "Total Room Cost"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label3.ForeColor = System.Drawing.Color.Black
        Label3.Location = New System.Drawing.Point(194, 46)
        Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(86, 15)
        Label3.TabIndex = 285
        Label3.Text = "Other Charges"
        '
        'Label9
        '
        Label9.AutoSize = True
        Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label9.ForeColor = System.Drawing.Color.Black
        Label9.Location = New System.Drawing.Point(30, 69)
        Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label9.Name = "Label9"
        Label9.Size = New System.Drawing.Size(59, 15)
        Label9.TabIndex = 287
        Label9.Text = "Sub Total"
        '
        'Label48
        '
        Label48.AutoSize = True
        Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label48.ForeColor = System.Drawing.Color.Black
        Label48.Location = New System.Drawing.Point(9, 24)
        Label48.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label48.Name = "Label48"
        Label48.Size = New System.Drawing.Size(90, 15)
        Label48.TabIndex = 289
        Label48.Text = "Service Charge"
        '
        'Label49
        '
        Label49.AutoSize = True
        Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label49.ForeColor = System.Drawing.Color.Black
        Label49.Location = New System.Drawing.Point(10, 49)
        Label49.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label49.Name = "Label49"
        Label49.Size = New System.Drawing.Size(28, 15)
        Label49.TabIndex = 292
        Label49.Text = "VAT"
        '
        'Label50
        '
        Label50.AutoSize = True
        Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label50.ForeColor = System.Drawing.Color.Black
        Label50.Location = New System.Drawing.Point(10, 78)
        Label50.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label50.Name = "Label50"
        Label50.Size = New System.Drawing.Size(55, 15)
        Label50.TabIndex = 296
        Label50.Text = "Discount"
        '
        'Label51
        '
        Label51.AutoSize = True
        Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label51.ForeColor = System.Drawing.Color.Black
        Label51.Location = New System.Drawing.Point(29, 17)
        Label51.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label51.Name = "Label51"
        Label51.Size = New System.Drawing.Size(71, 15)
        Label51.TabIndex = 297
        Label51.Text = "Grand Total"
        '
        'Label52
        '
        Label52.AutoSize = True
        Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label52.ForeColor = System.Drawing.Color.Black
        Label52.Location = New System.Drawing.Point(194, 71)
        Label52.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label52.Name = "Label52"
        Label52.Size = New System.Drawing.Size(62, 15)
        Label52.TabIndex = 299
        Label52.Text = "Total Paid"
        '
        'Label53
        '
        Label53.AutoSize = True
        Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label53.ForeColor = System.Drawing.Color.Black
        Label53.Location = New System.Drawing.Point(29, 43)
        Label53.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label53.Name = "Label53"
        Label53.Size = New System.Drawing.Size(52, 15)
        Label53.TabIndex = 301
        Label53.Text = "Balance"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.ForeColor = System.Drawing.Color.Black
        Label4.Location = New System.Drawing.Point(8, 131)
        Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(70, 15)
        Label4.TabIndex = 276
        Label4.Text = "Contact No."
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.ForeColor = System.Drawing.Color.Black
        Label5.Location = New System.Drawing.Point(8, 101)
        Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(26, 15)
        Label5.TabIndex = 274
        Label5.Text = "City"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.ForeColor = System.Drawing.Color.Black
        Label7.Location = New System.Drawing.Point(8, 53)
        Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(102, 15)
        Label7.TabIndex = 271
        Label7.Text = "Guest Full  Name"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.ForeColor = System.Drawing.Color.Black
        Label8.Location = New System.Drawing.Point(8, 183)
        Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(67, 15)
        Label8.TabIndex = 267
        Label8.Text = "ID Number"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.ForeColor = System.Drawing.Color.Black
        Label10.Location = New System.Drawing.Point(8, 158)
        Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(45, 15)
        Label10.TabIndex = 266
        Label10.Text = "IDType"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.ForeColor = System.Drawing.Color.Black
        Label11.Location = New System.Drawing.Point(8, 77)
        Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(51, 15)
        Label11.TabIndex = 263
        Label11.Text = "Address"
        '
        'Label59
        '
        Label59.AutoSize = True
        Label59.ForeColor = System.Drawing.Color.Black
        Label59.Location = New System.Drawing.Point(8, 27)
        Label59.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label59.Name = "Label59"
        Label59.Size = New System.Drawing.Size(54, 15)
        Label59.TabIndex = 261
        Label59.Text = "Guest ID"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.ForeColor = System.Drawing.Color.Black
        Label21.Location = New System.Drawing.Point(4, 159)
        Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(52, 15)
        Label21.TabIndex = 324
        Label21.Text = "Balance"
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.ForeColor = System.Drawing.Color.Black
        Label23.Location = New System.Drawing.Point(4, 132)
        Label23.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(62, 15)
        Label23.TabIndex = 323
        Label23.Text = "Total Paid"
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.ForeColor = System.Drawing.Color.Black
        Label24.Location = New System.Drawing.Point(4, 106)
        Label24.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(71, 15)
        Label24.TabIndex = 322
        Label24.Text = "Grand Total"
        '
        'Label25
        '
        Label25.AutoSize = True
        Label25.ForeColor = System.Drawing.Color.Black
        Label25.Location = New System.Drawing.Point(4, 29)
        Label25.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label25.Name = "Label25"
        Label25.Size = New System.Drawing.Size(55, 15)
        Label25.TabIndex = 321
        Label25.Text = "Discount"
        '
        'Label60
        '
        Label60.AutoSize = True
        Label60.ForeColor = System.Drawing.Color.Black
        Label60.Location = New System.Drawing.Point(4, 84)
        Label60.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label60.Name = "Label60"
        Label60.Size = New System.Drawing.Size(28, 15)
        Label60.TabIndex = 319
        Label60.Text = "VAT"
        '
        'Label61
        '
        Label61.AutoSize = True
        Label61.ForeColor = System.Drawing.Color.Black
        Label61.Location = New System.Drawing.Point(4, 55)
        Label61.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label61.Name = "Label61"
        Label61.Size = New System.Drawing.Size(74, 15)
        Label61.TabIndex = 317
        Label61.Text = "Serv Charge"
        '
        'Label62
        '
        Label62.AutoSize = True
        Label62.ForeColor = System.Drawing.Color.Black
        Label62.Location = New System.Drawing.Point(4, 79)
        Label62.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label62.Name = "Label62"
        Label62.Size = New System.Drawing.Size(59, 15)
        Label62.TabIndex = 316
        Label62.Text = "Sub Total"
        '
        'Label63
        '
        Label63.AutoSize = True
        Label63.ForeColor = System.Drawing.Color.Black
        Label63.Location = New System.Drawing.Point(4, 54)
        Label63.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label63.Name = "Label63"
        Label63.Size = New System.Drawing.Size(86, 15)
        Label63.TabIndex = 315
        Label63.Text = "Other Charges"
        '
        'Label40
        '
        Label40.AutoSize = True
        Label40.ForeColor = System.Drawing.Color.Black
        Label40.Location = New System.Drawing.Point(13, 132)
        Label40.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label40.Name = "Label40"
        Label40.Size = New System.Drawing.Size(70, 15)
        Label40.TabIndex = 276
        Label40.Text = "Contact No."
        '
        'Label41
        '
        Label41.AutoSize = True
        Label41.ForeColor = System.Drawing.Color.Black
        Label41.Location = New System.Drawing.Point(13, 105)
        Label41.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label41.Name = "Label41"
        Label41.Size = New System.Drawing.Size(26, 15)
        Label41.TabIndex = 274
        Label41.Text = "City"
        '
        'Label42
        '
        Label42.AutoSize = True
        Label42.ForeColor = System.Drawing.Color.Black
        Label42.Location = New System.Drawing.Point(13, 56)
        Label42.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label42.Name = "Label42"
        Label42.Size = New System.Drawing.Size(76, 15)
        Label42.TabIndex = 271
        Label42.Text = "Guest Name"
        '
        'Label43
        '
        Label43.AutoSize = True
        Label43.ForeColor = System.Drawing.Color.Black
        Label43.Location = New System.Drawing.Point(13, 183)
        Label43.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label43.Name = "Label43"
        Label43.Size = New System.Drawing.Size(67, 15)
        Label43.TabIndex = 267
        Label43.Text = "ID Number"
        '
        'Label44
        '
        Label44.AutoSize = True
        Label44.ForeColor = System.Drawing.Color.Black
        Label44.Location = New System.Drawing.Point(13, 158)
        Label44.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label44.Name = "Label44"
        Label44.Size = New System.Drawing.Size(45, 15)
        Label44.TabIndex = 266
        Label44.Text = "IDType"
        '
        'Label45
        '
        Label45.AutoSize = True
        Label45.ForeColor = System.Drawing.Color.Black
        Label45.Location = New System.Drawing.Point(13, 81)
        Label45.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label45.Name = "Label45"
        Label45.Size = New System.Drawing.Size(51, 15)
        Label45.TabIndex = 263
        Label45.Text = "Address"
        '
        'Label67
        '
        Label67.AutoSize = True
        Label67.ForeColor = System.Drawing.Color.Black
        Label67.Location = New System.Drawing.Point(13, 28)
        Label67.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label67.Name = "Label67"
        Label67.Size = New System.Drawing.Size(54, 15)
        Label67.TabIndex = 261
        Label67.Text = "Guest ID"
        '
        'Label31
        '
        Label31.AutoSize = True
        Label31.ForeColor = System.Drawing.Color.Black
        Label31.Location = New System.Drawing.Point(415, 56)
        Label31.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label31.Name = "Label31"
        Label31.Size = New System.Drawing.Size(52, 15)
        Label31.TabIndex = 324
        Label31.Text = "Balance"
        '
        'Label32
        '
        Label32.AutoSize = True
        Label32.ForeColor = System.Drawing.Color.Black
        Label32.Location = New System.Drawing.Point(188, 56)
        Label32.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label32.Name = "Label32"
        Label32.Size = New System.Drawing.Size(62, 15)
        Label32.TabIndex = 323
        Label32.Text = "Total Paid"
        '
        'Label34
        '
        Label34.AutoSize = True
        Label34.ForeColor = System.Drawing.Color.Black
        Label34.Location = New System.Drawing.Point(9, 58)
        Label34.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label34.Name = "Label34"
        Label34.Size = New System.Drawing.Size(71, 15)
        Label34.TabIndex = 322
        Label34.Text = "Grand Total"
        '
        'Label35
        '
        Label35.AutoSize = True
        Label35.ForeColor = System.Drawing.Color.Black
        Label35.Location = New System.Drawing.Point(11, 76)
        Label35.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label35.Name = "Label35"
        Label35.Size = New System.Drawing.Size(55, 15)
        Label35.TabIndex = 321
        Label35.Text = "Discount"
        '
        'Label36
        '
        Label36.AutoSize = True
        Label36.ForeColor = System.Drawing.Color.Black
        Label36.Location = New System.Drawing.Point(11, 47)
        Label36.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label36.Name = "Label36"
        Label36.Size = New System.Drawing.Size(28, 15)
        Label36.TabIndex = 319
        Label36.Text = "VAT"
        '
        'Label37
        '
        Label37.AutoSize = True
        Label37.ForeColor = System.Drawing.Color.Black
        Label37.Location = New System.Drawing.Point(11, 24)
        Label37.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label37.Name = "Label37"
        Label37.Size = New System.Drawing.Size(90, 15)
        Label37.TabIndex = 317
        Label37.Text = "Service Charge"
        '
        'Label38
        '
        Label38.AutoSize = True
        Label38.ForeColor = System.Drawing.Color.Black
        Label38.Location = New System.Drawing.Point(9, 31)
        Label38.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label38.Name = "Label38"
        Label38.Size = New System.Drawing.Size(59, 15)
        Label38.TabIndex = 316
        Label38.Text = "Sub Total"
        '
        'Label39
        '
        Label39.AutoSize = True
        Label39.ForeColor = System.Drawing.Color.Black
        Label39.Location = New System.Drawing.Point(188, 32)
        Label39.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label39.Name = "Label39"
        Label39.Size = New System.Drawing.Size(86, 15)
        Label39.TabIndex = 9
        Label39.Text = "Other Charges"
        '
        'Label65
        '
        Label65.AutoSize = True
        Label65.ForeColor = System.Drawing.Color.Black
        Label65.Location = New System.Drawing.Point(328, 27)
        Label65.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label65.Name = "Label65"
        Label65.Size = New System.Drawing.Size(39, 15)
        Label65.TabIndex = 334
        Label65.Text = "Notes"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Label13.ForeColor = System.Drawing.Color.Black
        Label13.Location = New System.Drawing.Point(209, 11)
        Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(82, 15)
        Label13.TabIndex = 339
        Label13.Text = "Room charge"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(1, 2)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1213, 627)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SimpleButton2)
        Me.TabPage1.Controls.Add(Me.Searchreserved)
        Me.TabPage1.Controls.Add(Me.GroupControl8)
        Me.TabPage1.Controls.Add(Me.Search)
        Me.TabPage1.Controls.Add(Me.guestyonisearch)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.GroupControl7)
        Me.TabPage1.Controls.Add(Me.GroupControl4)
        Me.TabPage1.Controls.Add(Me.GroupControl6)
        Me.TabPage1.Controls.Add(Me.GroupControl5)
        Me.TabPage1.Controls.Add(Me.GroupControl3)
        Me.TabPage1.Controls.Add(Me.GroupControl2)
        Me.TabPage1.Controls.Add(Me.GroupControl1)
        Me.TabPage1.Controls.Add(Me.txtCurrencyID)
        Me.TabPage1.Controls.Add(Me.txtHotelID)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.txtReservationNo)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.cmbRoomNo1)
        Me.TabPage1.Controls.Add(Me.txtID1)
        Me.TabPage1.Controls.Add(Me.panel1)
        Me.TabPage1.Controls.Add(Me.GroupBoxRateInfo)
        Me.TabPage1.Controls.Add(Me.GroupBoxGuestInfo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage1.Size = New System.Drawing.Size(1205, 599)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Rooms"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(676, 259)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 327
        Me.SimpleButton2.Text = "Search"
        '
        'Searchreserved
        '
        Me.Searchreserved.BackColor = System.Drawing.Color.DimGray
        Me.Searchreserved.ForeColor = System.Drawing.Color.White
        Me.Searchreserved.Location = New System.Drawing.Point(431, 259)
        Me.Searchreserved.Multiline = True
        Me.Searchreserved.Name = "Searchreserved"
        Me.Searchreserved.Size = New System.Drawing.Size(238, 24)
        Me.Searchreserved.TabIndex = 326
        Me.Searchreserved.Text = "Search by Name"
        '
        'GroupControl8
        '
        Me.GroupControl8.Controls.Add(Me.reservationGR)
        Me.GroupControl8.Location = New System.Drawing.Point(427, 286)
        Me.GroupControl8.Name = "GroupControl8"
        Me.GroupControl8.Size = New System.Drawing.Size(775, 288)
        Me.GroupControl8.TabIndex = 325
        Me.GroupControl8.Text = "Reservation Record"
        '
        'reservationGR
        '
        Me.reservationGR.AllowUserToAddRows = False
        Me.reservationGR.AllowUserToDeleteRows = False
        Me.reservationGR.BackgroundColor = System.Drawing.Color.SandyBrown
        Me.reservationGR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.reservationGR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reservationGR.Location = New System.Drawing.Point(2, 21)
        Me.reservationGR.MultiSelect = False
        Me.reservationGR.Name = "reservationGR"
        Me.reservationGR.ReadOnly = True
        Me.reservationGR.Size = New System.Drawing.Size(771, 265)
        Me.reservationGR.TabIndex = 30
        '
        'Search
        '
        Me.Search.Location = New System.Drawing.Point(665, 4)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(75, 23)
        Me.Search.TabIndex = 324
        Me.Search.Text = "Search"
        '
        'guestyonisearch
        '
        Me.guestyonisearch.BackColor = System.Drawing.Color.DimGray
        Me.guestyonisearch.ForeColor = System.Drawing.Color.White
        Me.guestyonisearch.Location = New System.Drawing.Point(369, 3)
        Me.guestyonisearch.Multiline = True
        Me.guestyonisearch.Name = "guestyonisearch"
        Me.guestyonisearch.Size = New System.Drawing.Size(287, 24)
        Me.guestyonisearch.TabIndex = 323
        Me.guestyonisearch.Text = "Search Guest Record"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(392, 262)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(10, 10)
        Me.Button4.TabIndex = 309
        Me.Button4.Text = "<"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupControl7
        '
        Me.GroupControl7.Controls.Add(Me.guestRecordG)
        Me.GroupControl7.Location = New System.Drawing.Point(368, 30)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.Size = New System.Drawing.Size(545, 227)
        Me.GroupControl7.TabIndex = 322
        Me.GroupControl7.Text = "Guest Record"
        '
        'guestRecordG
        '
        Me.guestRecordG.AllowUserToAddRows = False
        Me.guestRecordG.AllowUserToDeleteRows = False
        Me.guestRecordG.BackgroundColor = System.Drawing.Color.Wheat
        Me.guestRecordG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.guestRecordG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.guestRecordG.Location = New System.Drawing.Point(2, 21)
        Me.guestRecordG.MultiSelect = False
        Me.guestRecordG.Name = "guestRecordG"
        Me.guestRecordG.ReadOnly = True
        Me.guestRecordG.Size = New System.Drawing.Size(541, 204)
        Me.guestRecordG.TabIndex = 21
        '
        'GroupControl4
        '
        Me.GroupControl4.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl4.Controls.Add(Me.txtGrandTotal)
        Me.GroupControl4.Controls.Add(Label51)
        Me.GroupControl4.Controls.Add(Label52)
        Me.GroupControl4.Controls.Add(Me.txtTotalPaid)
        Me.GroupControl4.Controls.Add(Label53)
        Me.GroupControl4.Controls.Add(Me.txtOtherCharges)
        Me.GroupControl4.Controls.Add(Label3)
        Me.GroupControl4.Controls.Add(Me.txtSubTotal)
        Me.GroupControl4.Controls.Add(Label9)
        Me.GroupControl4.Controls.Add(Me.txtBalance)
        Me.GroupControl4.Controls.Add(Me.txtTotalRoomCharges)
        Me.GroupControl4.Controls.Add(Label1)
        Me.GroupControl4.Location = New System.Drawing.Point(3, 461)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(418, 111)
        Me.GroupControl4.TabIndex = 321
        Me.GroupControl4.Text = "Total Room Cost"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.PeachPuff
        Me.txtGrandTotal.Location = New System.Drawing.Point(102, 17)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(84, 21)
        Me.txtGrandTotal.TabIndex = 17
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Location = New System.Drawing.Point(297, 66)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.Size = New System.Drawing.Size(84, 21)
        Me.txtTotalPaid.TabIndex = 18
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtherCharges
        '
        Me.txtOtherCharges.Location = New System.Drawing.Point(297, 41)
        Me.txtOtherCharges.Name = "txtOtherCharges"
        Me.txtOtherCharges.Size = New System.Drawing.Size(84, 21)
        Me.txtOtherCharges.TabIndex = 8
        Me.txtOtherCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.BackColor = System.Drawing.Color.PeachPuff
        Me.txtSubTotal.Location = New System.Drawing.Point(102, 68)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(84, 21)
        Me.txtSubTotal.TabIndex = 12
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.Color.PeachPuff
        Me.txtBalance.Location = New System.Drawing.Point(102, 42)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(84, 21)
        Me.txtBalance.TabIndex = 19
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRoomCharges
        '
        Me.txtTotalRoomCharges.BackColor = System.Drawing.Color.PeachPuff
        Me.txtTotalRoomCharges.Location = New System.Drawing.Point(297, 17)
        Me.txtTotalRoomCharges.Name = "txtTotalRoomCharges"
        Me.txtTotalRoomCharges.ReadOnly = True
        Me.txtTotalRoomCharges.Size = New System.Drawing.Size(84, 21)
        Me.txtTotalRoomCharges.TabIndex = 6
        Me.txtTotalRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.txtLuxuryTaxPer)
        Me.GroupControl6.Controls.Add(Label48)
        Me.GroupControl6.Controls.Add(Me.txtServiceTaxPer)
        Me.GroupControl6.Controls.Add(Me.txtServiceTaxAmount)
        Me.GroupControl6.Controls.Add(Me.txtDiscount)
        Me.GroupControl6.Controls.Add(Label49)
        Me.GroupControl6.Controls.Add(Me.Label58)
        Me.GroupControl6.Controls.Add(Me.txtLuxuryTaxAmount)
        Me.GroupControl6.Controls.Add(Me.Label56)
        Me.GroupControl6.Controls.Add(Me.Label55)
        Me.GroupControl6.Controls.Add(Me.txtDiscountPer)
        Me.GroupControl6.Controls.Add(Label50)
        Me.GroupControl6.Location = New System.Drawing.Point(917, 3)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(285, 107)
        Me.GroupControl6.TabIndex = 321
        Me.GroupControl6.Text = "Tax Information"
        '
        'txtLuxuryTaxPer
        '
        Me.txtLuxuryTaxPer.BackColor = System.Drawing.Color.BurlyWood
        Me.txtLuxuryTaxPer.ForeColor = System.Drawing.Color.Red
        Me.txtLuxuryTaxPer.Location = New System.Drawing.Point(103, 50)
        Me.txtLuxuryTaxPer.Name = "txtLuxuryTaxPer"
        Me.txtLuxuryTaxPer.Size = New System.Drawing.Size(63, 21)
        Me.txtLuxuryTaxPer.TabIndex = 15
        Me.txtLuxuryTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxPer
        '
        Me.txtServiceTaxPer.BackColor = System.Drawing.Color.BurlyWood
        Me.txtServiceTaxPer.ForeColor = System.Drawing.Color.Red
        Me.txtServiceTaxPer.Location = New System.Drawing.Point(103, 26)
        Me.txtServiceTaxPer.Name = "txtServiceTaxPer"
        Me.txtServiceTaxPer.Size = New System.Drawing.Size(63, 21)
        Me.txtServiceTaxPer.TabIndex = 13
        Me.txtServiceTaxPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxAmount
        '
        Me.txtServiceTaxAmount.BackColor = System.Drawing.Color.Chartreuse
        Me.txtServiceTaxAmount.Location = New System.Drawing.Point(203, 26)
        Me.txtServiceTaxAmount.Name = "txtServiceTaxAmount"
        Me.txtServiceTaxAmount.ReadOnly = True
        Me.txtServiceTaxAmount.Size = New System.Drawing.Size(75, 21)
        Me.txtServiceTaxAmount.TabIndex = 14
        Me.txtServiceTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscount
        '
        Me.txtDiscount.BackColor = System.Drawing.Color.Chartreuse
        Me.txtDiscount.Location = New System.Drawing.Point(204, 76)
        Me.txtDiscount.Name = "txtDiscount"
        Me.txtDiscount.ReadOnly = True
        Me.txtDiscount.Size = New System.Drawing.Size(75, 21)
        Me.txtDiscount.TabIndex = 11
        Me.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label58.Location = New System.Drawing.Point(175, 81)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(18, 15)
        Me.Label58.TabIndex = 305
        Me.Label58.Text = "%"
        '
        'txtLuxuryTaxAmount
        '
        Me.txtLuxuryTaxAmount.BackColor = System.Drawing.Color.Chartreuse
        Me.txtLuxuryTaxAmount.Location = New System.Drawing.Point(203, 51)
        Me.txtLuxuryTaxAmount.Name = "txtLuxuryTaxAmount"
        Me.txtLuxuryTaxAmount.ReadOnly = True
        Me.txtLuxuryTaxAmount.Size = New System.Drawing.Size(75, 21)
        Me.txtLuxuryTaxAmount.TabIndex = 16
        Me.txtLuxuryTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label56.Location = New System.Drawing.Point(173, 50)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(18, 15)
        Me.Label56.TabIndex = 304
        Me.Label56.Text = "%"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label55.Location = New System.Drawing.Point(174, 27)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(18, 15)
        Me.Label55.TabIndex = 303
        Me.Label55.Text = "%"
        '
        'txtDiscountPer
        '
        Me.txtDiscountPer.BackColor = System.Drawing.Color.BurlyWood
        Me.txtDiscountPer.ForeColor = System.Drawing.Color.Red
        Me.txtDiscountPer.Location = New System.Drawing.Point(103, 75)
        Me.txtDiscountPer.Name = "txtDiscountPer"
        Me.txtDiscountPer.Size = New System.Drawing.Size(63, 21)
        Me.txtDiscountPer.TabIndex = 10
        Me.txtDiscountPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl5
        '
        Me.GroupControl5.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl5.Controls.Add(Label13)
        Me.GroupControl5.Controls.Add(Me.dtpDateIn)
        Me.GroupControl5.Controls.Add(RoomNumberLabel)
        Me.GroupControl5.Controls.Add(Me.cmbCurrency2)
        Me.GroupControl5.Controls.Add(Me.Label75)
        Me.GroupControl5.Controls.Add(DateInLabel)
        Me.GroupControl5.Controls.Add(DateOutLabel)
        Me.GroupControl5.Controls.Add(Me.CheckBox1)
        Me.GroupControl5.Controls.Add(Me.hsAdults)
        Me.GroupControl5.Controls.Add(Me.cmbRoomNo)
        Me.GroupControl5.Controls.Add(Me.dtpDateOut)
        Me.GroupControl5.Controls.Add(Label22)
        Me.GroupControl5.Controls.Add(Me.txtNoOfAdults)
        Me.GroupControl5.Controls.Add(Label47)
        Me.GroupControl5.Controls.Add(Me.txtNoOfKids)
        Me.GroupControl5.Controls.Add(Me.hsKids)
        Me.GroupControl5.Controls.Add(Me.txtRoomCharges)
        Me.GroupControl5.Controls.Add(Me.txtNoOfDays)
        Me.GroupControl5.Controls.Add(Label33)
        Me.GroupControl5.Location = New System.Drawing.Point(3, 314)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(418, 145)
        Me.GroupControl5.TabIndex = 321
        Me.GroupControl5.Text = "Room Rate Information"
        '
        'dtpDateIn
        '
        Me.dtpDateIn.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtpDateIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateIn.Location = New System.Drawing.Point(88, 39)
        Me.dtpDateIn.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateIn.Name = "dtpDateIn"
        Me.dtpDateIn.Size = New System.Drawing.Size(121, 21)
        Me.dtpDateIn.TabIndex = 1
        '
        'cmbCurrency2
        '
        Me.cmbCurrency2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCurrency2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrency2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmbCurrency2.FormattingEnabled = True
        Me.cmbCurrency2.Location = New System.Drawing.Point(295, 98)
        Me.cmbCurrency2.Name = "cmbCurrency2"
        Me.cmbCurrency2.Size = New System.Drawing.Size(81, 23)
        Me.cmbCurrency2.TabIndex = 7
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label75.Location = New System.Drawing.Point(217, 99)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(55, 15)
        Me.Label75.TabIndex = 338
        Me.Label75.Text = "Currency"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.CheckBox1.Location = New System.Drawing.Point(88, 122)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(79, 19)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Extra Bed"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'hsAdults
        '
        Me.hsAdults.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsAdults.LargeChange = 1
        Me.hsAdults.Location = New System.Drawing.Point(151, 70)
        Me.hsAdults.Maximum = 32767
        Me.hsAdults.Minimum = 1
        Me.hsAdults.Name = "hsAdults"
        Me.hsAdults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsAdults.Size = New System.Drawing.Size(23, 24)
        Me.hsAdults.TabIndex = 253
        Me.hsAdults.TabStop = True
        Me.hsAdults.Value = 1
        '
        'cmbRoomNo
        '
        Me.cmbRoomNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmbRoomNo.FormattingEnabled = True
        Me.cmbRoomNo.Location = New System.Drawing.Point(88, 7)
        Me.cmbRoomNo.Name = "cmbRoomNo"
        Me.cmbRoomNo.Size = New System.Drawing.Size(112, 23)
        Me.cmbRoomNo.TabIndex = 0
        '
        'dtpDateOut
        '
        Me.dtpDateOut.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtpDateOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateOut.Location = New System.Drawing.Point(293, 42)
        Me.dtpDateOut.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateOut.Name = "dtpDateOut"
        Me.dtpDateOut.Size = New System.Drawing.Size(98, 21)
        Me.dtpDateOut.TabIndex = 2
        '
        'txtNoOfAdults
        '
        Me.txtNoOfAdults.Location = New System.Drawing.Point(88, 67)
        Me.txtNoOfAdults.Name = "txtNoOfAdults"
        Me.txtNoOfAdults.Size = New System.Drawing.Size(53, 21)
        Me.txtNoOfAdults.TabIndex = 3
        Me.txtNoOfAdults.Text = "1"
        Me.txtNoOfAdults.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfKids
        '
        Me.txtNoOfKids.Location = New System.Drawing.Point(259, 70)
        Me.txtNoOfKids.Name = "txtNoOfKids"
        Me.txtNoOfKids.Size = New System.Drawing.Size(47, 21)
        Me.txtNoOfKids.TabIndex = 4
        Me.txtNoOfKids.Text = "0"
        Me.txtNoOfKids.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hsKids
        '
        Me.hsKids.Cursor = System.Windows.Forms.Cursors.Default
        Me.hsKids.LargeChange = 1
        Me.hsKids.Location = New System.Drawing.Point(318, 68)
        Me.hsKids.Maximum = 32767
        Me.hsKids.Name = "hsKids"
        Me.hsKids.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.hsKids.Size = New System.Drawing.Size(23, 24)
        Me.hsKids.TabIndex = 278
        Me.hsKids.TabStop = True
        '
        'txtRoomCharges
        '
        Me.txtRoomCharges.Location = New System.Drawing.Point(293, 9)
        Me.txtRoomCharges.Name = "txtRoomCharges"
        Me.txtRoomCharges.ReadOnly = True
        Me.txtRoomCharges.Size = New System.Drawing.Size(98, 21)
        Me.txtRoomCharges.TabIndex = 282
        Me.txtRoomCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfDays
        '
        Me.txtNoOfDays.Location = New System.Drawing.Point(88, 97)
        Me.txtNoOfDays.Name = "txtNoOfDays"
        Me.txtNoOfDays.ReadOnly = True
        Me.txtNoOfDays.Size = New System.Drawing.Size(112, 21)
        Me.txtNoOfDays.TabIndex = 5
        Me.txtNoOfDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.SimpleButton1)
        Me.GroupControl3.Controls.Add(Me.btnCheckedIN)
        Me.GroupControl3.Controls.Add(Me.Button3)
        Me.GroupControl3.Controls.Add(Me.Button14)
        Me.GroupControl3.Controls.Add(Me.btnDelete)
        Me.GroupControl3.Controls.Add(Me.btnUpdate_record)
        Me.GroupControl3.Controls.Add(Me.btnNewRecord)
        Me.GroupControl3.Controls.Add(Me.btnSave)
        Me.GroupControl3.Location = New System.Drawing.Point(919, 113)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(286, 170)
        Me.GroupControl3.TabIndex = 320
        Me.GroupControl3.Text = "Action Button"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(185, 102)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Close"
        '
        'btnCheckedIN
        '
        Me.btnCheckedIN.Enabled = False
        Me.btnCheckedIN.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnCheckedIN.Location = New System.Drawing.Point(203, 3)
        Me.btnCheckedIN.Name = "btnCheckedIN"
        Me.btnCheckedIN.Size = New System.Drawing.Size(78, 36)
        Me.btnCheckedIN.TabIndex = 5
        Me.btnCheckedIN.Text = "Check IN"
        Me.btnCheckedIN.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Button3.Location = New System.Drawing.Point(23, 75)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 50)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Room Availability"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Button14.Location = New System.Drawing.Point(23, 131)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(128, 31)
        Me.Button14.TabIndex = 4
        Me.Button14.Text = "Checkedin Record"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnDelete.Image = Global.Hotel_Management_System.My.Resources.Resources.Close_32x32
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(114, 39)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 31)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate_record
        '
        Me.btnUpdate_record.Enabled = False
        Me.btnUpdate_record.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnUpdate_record.Image = Global.Hotel_Management_System.My.Resources.Resources.Edit_32x32
        Me.btnUpdate_record.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate_record.Location = New System.Drawing.Point(114, 5)
        Me.btnUpdate_record.Name = "btnUpdate_record"
        Me.btnUpdate_record.Size = New System.Drawing.Size(85, 31)
        Me.btnUpdate_record.TabIndex = 3
        Me.btnUpdate_record.Text = "Update"
        Me.btnUpdate_record.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate_record.UseVisualStyleBackColor = True
        '
        'btnNewRecord
        '
        Me.btnNewRecord.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnNewRecord.Image = Global.Hotel_Management_System.My.Resources.Resources.Clear_32x32
        Me.btnNewRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewRecord.Location = New System.Drawing.Point(23, 4)
        Me.btnNewRecord.Name = "btnNewRecord"
        Me.btnNewRecord.Size = New System.Drawing.Size(87, 31)
        Me.btnNewRecord.TabIndex = 0
        Me.btnNewRecord.Text = "Clear"
        Me.btnNewRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewRecord.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnSave.Image = Global.Hotel_Management_System.My.Resources.Resources.SaveAll_32x32
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(23, 39)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 31)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.txtNotes)
        Me.GroupControl2.Location = New System.Drawing.Point(3, 190)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(360, 118)
        Me.GroupControl2.TabIndex = 319
        Me.GroupControl2.Text = "Remark"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes.Location = New System.Drawing.Point(2, 21)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes.Size = New System.Drawing.Size(356, 95)
        Me.txtNotes.TabIndex = 278
        Me.txtNotes.Text = ""
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.txtIDType)
        Me.GroupControl1.Controls.Add(Me.txtGuestAddress)
        Me.GroupControl1.Controls.Add(FolioNumberLabel)
        Me.GroupControl1.Controls.Add(Me.txtIDNumber)
        Me.GroupControl1.Controls.Add(AddressLabel)
        Me.GroupControl1.Controls.Add(Me.txtGuestContactNo)
        Me.GroupControl1.Controls.Add(IDTypeIDLabel)
        Me.GroupControl1.Controls.Add(Label46)
        Me.GroupControl1.Controls.Add(IDNumberLabel)
        Me.GroupControl1.Controls.Add(Me.txtGuestCity)
        Me.GroupControl1.Controls.Add(Me.txtGuestID)
        Me.GroupControl1.Controls.Add(Label2)
        Me.GroupControl1.Controls.Add(Label6)
        Me.GroupControl1.Controls.Add(Me.txtGuestName)
        Me.GroupControl1.Location = New System.Drawing.Point(3, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(360, 186)
        Me.GroupControl1.TabIndex = 281
        Me.GroupControl1.Text = "Guest Profile Information"
        '
        'txtIDType
        '
        Me.txtIDType.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtIDType.Location = New System.Drawing.Point(106, 132)
        Me.txtIDType.Name = "txtIDType"
        Me.txtIDType.ReadOnly = True
        Me.txtIDType.Size = New System.Drawing.Size(195, 21)
        Me.txtIDType.TabIndex = 280
        '
        'txtGuestAddress
        '
        Me.txtGuestAddress.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtGuestAddress.Location = New System.Drawing.Point(106, 54)
        Me.txtGuestAddress.Name = "txtGuestAddress"
        Me.txtGuestAddress.ReadOnly = True
        Me.txtGuestAddress.Size = New System.Drawing.Size(244, 21)
        Me.txtGuestAddress.TabIndex = 2
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtIDNumber.Location = New System.Drawing.Point(106, 158)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.ReadOnly = True
        Me.txtIDNumber.Size = New System.Drawing.Size(204, 21)
        Me.txtIDNumber.TabIndex = 6
        '
        'txtGuestContactNo
        '
        Me.txtGuestContactNo.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtGuestContactNo.Location = New System.Drawing.Point(106, 107)
        Me.txtGuestContactNo.Name = "txtGuestContactNo"
        Me.txtGuestContactNo.ReadOnly = True
        Me.txtGuestContactNo.Size = New System.Drawing.Size(149, 21)
        Me.txtGuestContactNo.TabIndex = 4
        '
        'txtGuestCity
        '
        Me.txtGuestCity.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtGuestCity.Location = New System.Drawing.Point(106, 80)
        Me.txtGuestCity.Name = "txtGuestCity"
        Me.txtGuestCity.ReadOnly = True
        Me.txtGuestCity.Size = New System.Drawing.Size(204, 21)
        Me.txtGuestCity.TabIndex = 3
        '
        'txtGuestID
        '
        Me.txtGuestID.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtGuestID.Location = New System.Drawing.Point(106, 5)
        Me.txtGuestID.Name = "txtGuestID"
        Me.txtGuestID.ReadOnly = True
        Me.txtGuestID.Size = New System.Drawing.Size(149, 21)
        Me.txtGuestID.TabIndex = 0
        '
        'txtGuestName
        '
        Me.txtGuestName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtGuestName.Location = New System.Drawing.Point(106, 29)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.ReadOnly = True
        Me.txtGuestName.Size = New System.Drawing.Size(204, 21)
        Me.txtGuestName.TabIndex = 1
        '
        'txtCurrencyID
        '
        Me.txtCurrencyID.Location = New System.Drawing.Point(717, 370)
        Me.txtCurrencyID.Name = "txtCurrencyID"
        Me.txtCurrencyID.Size = New System.Drawing.Size(100, 21)
        Me.txtCurrencyID.TabIndex = 318
        Me.txtCurrencyID.Visible = False
        '
        'txtHotelID
        '
        Me.txtHotelID.Location = New System.Drawing.Point(782, 440)
        Me.txtHotelID.Name = "txtHotelID"
        Me.txtHotelID.Size = New System.Drawing.Size(100, 21)
        Me.txtHotelID.TabIndex = 316
        Me.txtHotelID.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Location = New System.Drawing.Point(572, 304)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(10, 10)
        Me.GroupBox6.TabIndex = 285
        Me.GroupBox6.TabStop = False
        '
        'txtReservationNo
        '
        Me.txtReservationNo.Location = New System.Drawing.Point(568, 405)
        Me.txtReservationNo.Name = "txtReservationNo"
        Me.txtReservationNo.Size = New System.Drawing.Size(102, 21)
        Me.txtReservationNo.TabIndex = 284
        Me.txtReservationNo.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Location = New System.Drawing.Point(542, 294)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(10, 14)
        Me.GroupBox5.TabIndex = 282
        Me.GroupBox5.TabStop = False
        '
        'cmbRoomNo1
        '
        Me.cmbRoomNo1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRoomNo1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRoomNo1.FormattingEnabled = True
        Me.cmbRoomNo1.Location = New System.Drawing.Point(486, 304)
        Me.cmbRoomNo1.Name = "cmbRoomNo1"
        Me.cmbRoomNo1.Size = New System.Drawing.Size(101, 23)
        Me.cmbRoomNo1.TabIndex = 281
        Me.cmbRoomNo1.Visible = False
        '
        'txtID1
        '
        Me.txtID1.Location = New System.Drawing.Point(623, 490)
        Me.txtID1.Name = "txtID1"
        Me.txtID1.Size = New System.Drawing.Size(102, 21)
        Me.txtID1.TabIndex = 280
        Me.txtID1.Visible = False
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.Transparent
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.Label54)
        Me.panel1.Location = New System.Drawing.Point(1076, 211)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(10, 10)
        Me.panel1.TabIndex = 2
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(334, 31)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(10, 15)
        Me.Label54.TabIndex = 19
        Me.Label54.Text = "."
        '
        'GroupBoxRateInfo
        '
        Me.GroupBoxRateInfo.Location = New System.Drawing.Point(527, 79)
        Me.GroupBoxRateInfo.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRateInfo.Name = "GroupBoxRateInfo"
        Me.GroupBoxRateInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRateInfo.Size = New System.Drawing.Size(25, 27)
        Me.GroupBoxRateInfo.TabIndex = 1
        Me.GroupBoxRateInfo.TabStop = False
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(12, 8)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(15, 10)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SimpleButton6)
        Me.TabPage2.Controls.Add(Me.hallsearch)
        Me.TabPage2.Controls.Add(Me.GroupControl22)
        Me.TabPage2.Controls.Add(Me.btnGetData1)
        Me.TabPage2.Controls.Add(Me.SimpleButton3)
        Me.TabPage2.Controls.Add(Me.guestnameyoni)
        Me.TabPage2.Controls.Add(Me.GroupControl16)
        Me.TabPage2.Controls.Add(Me.GroupControl15)
        Me.TabPage2.Controls.Add(Me.GroupControl14)
        Me.TabPage2.Controls.Add(Me.GroupControl13)
        Me.TabPage2.Controls.Add(Me.GroupControl11)
        Me.TabPage2.Controls.Add(Me.GroupControl12)
        Me.TabPage2.Controls.Add(Me.GroupControl10)
        Me.TabPage2.Controls.Add(Me.GroupControl9)
        Me.TabPage2.Controls.Add(Me.txtEducessTaxAmount)
        Me.TabPage2.Controls.Add(Me.txtHEducessTaxAmount)
        Me.TabPage2.Controls.Add(Me.txtEducessTax)
        Me.TabPage2.Controls.Add(Me.txtHEduCessTax)
        Me.TabPage2.Controls.Add(Me.DateTimePicker6)
        Me.TabPage2.Controls.Add(Me.DateTimePicker5)
        Me.TabPage2.Controls.Add(Me.DateTimePicker4)
        Me.TabPage2.Controls.Add(Me.DateTimePicker3)
        Me.TabPage2.Controls.Add(Me.txtID2)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Size = New System.Drawing.Size(1205, 599)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Hall and Garden"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Location = New System.Drawing.Point(649, 229)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton6.TabIndex = 346
        Me.SimpleButton6.Text = "Search"
        '
        'hallsearch
        '
        Me.hallsearch.BackColor = System.Drawing.Color.DimGray
        Me.hallsearch.ForeColor = System.Drawing.Color.White
        Me.hallsearch.Location = New System.Drawing.Point(426, 228)
        Me.hallsearch.Multiline = True
        Me.hallsearch.Name = "hallsearch"
        Me.hallsearch.Size = New System.Drawing.Size(218, 24)
        Me.hallsearch.TabIndex = 1
        '
        'GroupControl22
        '
        Me.GroupControl22.Controls.Add(Me.hallandgarden)
        Me.GroupControl22.Location = New System.Drawing.Point(415, 258)
        Me.GroupControl22.Name = "GroupControl22"
        Me.GroupControl22.Size = New System.Drawing.Size(785, 319)
        Me.GroupControl22.TabIndex = 345
        Me.GroupControl22.Text = "Reservation Record [Hall and Garden]"
        '
        'hallandgarden
        '
        Me.hallandgarden.AllowUserToAddRows = False
        Me.hallandgarden.AllowUserToDeleteRows = False
        Me.hallandgarden.BackgroundColor = System.Drawing.Color.Olive
        Me.hallandgarden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.hallandgarden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hallandgarden.Location = New System.Drawing.Point(2, 21)
        Me.hallandgarden.MultiSelect = False
        Me.hallandgarden.Name = "hallandgarden"
        Me.hallandgarden.ReadOnly = True
        Me.hallandgarden.Size = New System.Drawing.Size(781, 296)
        Me.hallandgarden.TabIndex = 31
        '
        'btnGetData1
        '
        Me.btnGetData1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnGetData1.Location = New System.Drawing.Point(250, 343)
        Me.btnGetData1.Name = "btnGetData1"
        Me.btnGetData1.Size = New System.Drawing.Size(10, 10)
        Me.btnGetData1.TabIndex = 4
        Me.btnGetData1.UseVisualStyleBackColor = True
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(649, 3)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton3.TabIndex = 344
        Me.SimpleButton3.Text = "Search"
        '
        'guestnameyoni
        '
        Me.guestnameyoni.BackColor = System.Drawing.Color.DimGray
        Me.guestnameyoni.ForeColor = System.Drawing.Color.White
        Me.guestnameyoni.Location = New System.Drawing.Point(426, 3)
        Me.guestnameyoni.Multiline = True
        Me.guestnameyoni.Name = "guestnameyoni"
        Me.guestnameyoni.Size = New System.Drawing.Size(218, 24)
        Me.guestnameyoni.TabIndex = 343
        '
        'GroupControl16
        '
        Me.GroupControl16.Controls.Add(Me.guestR)
        Me.GroupControl16.Location = New System.Drawing.Point(424, 29)
        Me.GroupControl16.Name = "GroupControl16"
        Me.GroupControl16.Size = New System.Drawing.Size(437, 193)
        Me.GroupControl16.TabIndex = 342
        Me.GroupControl16.Text = "Guest Record"
        '
        'guestR
        '
        Me.guestR.AllowUserToAddRows = False
        Me.guestR.AllowUserToDeleteRows = False
        Me.guestR.BackgroundColor = System.Drawing.Color.DarkKhaki
        Me.guestR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.guestR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.guestR.Location = New System.Drawing.Point(2, 21)
        Me.guestR.MultiSelect = False
        Me.guestR.Name = "guestR"
        Me.guestR.ReadOnly = True
        Me.guestR.Size = New System.Drawing.Size(433, 170)
        Me.guestR.TabIndex = 21
        '
        'GroupControl15
        '
        Me.GroupControl15.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl15.Controls.Add(Me.SimpleButton4)
        Me.GroupControl15.Controls.Add(Me.btnPrint)
        Me.GroupControl15.Controls.Add(Me.btnNew1)
        Me.GroupControl15.Controls.Add(Me.btnSave1)
        Me.GroupControl15.Controls.Add(Me.btnUpdate1)
        Me.GroupControl15.Controls.Add(Me.btnDelete1)
        Me.GroupControl15.Location = New System.Drawing.Point(274, 291)
        Me.GroupControl15.Name = "GroupControl15"
        Me.GroupControl15.Size = New System.Drawing.Size(137, 273)
        Me.GroupControl15.TabIndex = 341
        Me.GroupControl15.Text = "Action Button"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Location = New System.Drawing.Point(20, 215)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton4.TabIndex = 345
        Me.SimpleButton4.Text = "Close"
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnPrint.Image = Global.Hotel_Management_System.My.Resources.Resources.Report_32x321
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(14, 178)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(87, 31)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnNew1
        '
        Me.btnNew1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnNew1.Image = Global.Hotel_Management_System.My.Resources.Resources.Clear_32x32
        Me.btnNew1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew1.Location = New System.Drawing.Point(15, 34)
        Me.btnNew1.Name = "btnNew1"
        Me.btnNew1.Size = New System.Drawing.Size(87, 31)
        Me.btnNew1.TabIndex = 0
        Me.btnNew1.Text = "Clear"
        Me.btnNew1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew1.UseVisualStyleBackColor = True
        '
        'btnSave1
        '
        Me.btnSave1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnSave1.Image = Global.Hotel_Management_System.My.Resources.Resources.SaveAll_32x32
        Me.btnSave1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave1.Location = New System.Drawing.Point(15, 69)
        Me.btnSave1.Name = "btnSave1"
        Me.btnSave1.Size = New System.Drawing.Size(87, 31)
        Me.btnSave1.TabIndex = 1
        Me.btnSave1.Text = "Reserve"
        Me.btnSave1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave1.UseVisualStyleBackColor = True
        '
        'btnUpdate1
        '
        Me.btnUpdate1.Enabled = False
        Me.btnUpdate1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnUpdate1.Image = Global.Hotel_Management_System.My.Resources.Resources.Edit_32x32
        Me.btnUpdate1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate1.Location = New System.Drawing.Point(15, 139)
        Me.btnUpdate1.Name = "btnUpdate1"
        Me.btnUpdate1.Size = New System.Drawing.Size(87, 31)
        Me.btnUpdate1.TabIndex = 3
        Me.btnUpdate1.Text = "Update"
        Me.btnUpdate1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdate1.UseVisualStyleBackColor = True
        '
        'btnDelete1
        '
        Me.btnDelete1.Enabled = False
        Me.btnDelete1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnDelete1.Image = Global.Hotel_Management_System.My.Resources.Resources.Cancel_32x32
        Me.btnDelete1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete1.Location = New System.Drawing.Point(15, 101)
        Me.btnDelete1.Name = "btnDelete1"
        Me.btnDelete1.Size = New System.Drawing.Size(87, 31)
        Me.btnDelete1.TabIndex = 2
        Me.btnDelete1.Text = "Delete"
        Me.btnDelete1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete1.UseVisualStyleBackColor = True
        '
        'GroupControl14
        '
        Me.GroupControl14.Controls.Add(Me.txtNotes1)
        Me.GroupControl14.Location = New System.Drawing.Point(2, 353)
        Me.GroupControl14.Name = "GroupControl14"
        Me.GroupControl14.Size = New System.Drawing.Size(266, 224)
        Me.GroupControl14.TabIndex = 333
        Me.GroupControl14.Text = "Remark"
        '
        'txtNotes1
        '
        Me.txtNotes1.BackColor = System.Drawing.Color.Moccasin
        Me.txtNotes1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNotes1.Location = New System.Drawing.Point(2, 21)
        Me.txtNotes1.Name = "txtNotes1"
        Me.txtNotes1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes1.Size = New System.Drawing.Size(262, 201)
        Me.txtNotes1.TabIndex = 331
        Me.txtNotes1.Text = ""
        '
        'GroupControl13
        '
        Me.GroupControl13.Controls.Add(Me.Label77)
        Me.GroupControl13.Controls.Add(Me.Label78)
        Me.GroupControl13.Controls.Add(Me.Label79)
        Me.GroupControl13.Controls.Add(Me.Label57)
        Me.GroupControl13.Controls.Add(Me.Label76)
        Me.GroupControl13.Controls.Add(Me.dtpDateFrom_Garden)
        Me.GroupControl13.Controls.Add(Me.dtpDateTo_Garden)
        Me.GroupControl13.Controls.Add(Me.txtDaysGarden)
        Me.GroupControl13.Controls.Add(Me.txtRateGarden)
        Me.GroupControl13.Controls.Add(Me.txtTotalGarden)
        Me.GroupControl13.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl13.Name = "GroupControl13"
        Me.GroupControl13.Size = New System.Drawing.Size(200, 165)
        Me.GroupControl13.TabIndex = 334
        Me.GroupControl13.Text = "Garden Information"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(9, 83)
        Me.Label77.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(71, 15)
        Me.Label77.TabIndex = 289
        Me.Label77.Text = "No. Of Days"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(9, 108)
        Me.Label78.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(33, 15)
        Me.Label78.TabIndex = 291
        Me.Label78.Text = "Rate"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(9, 138)
        Me.Label79.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(34, 15)
        Me.Label79.TabIndex = 290
        Me.Label79.Text = "Total"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(9, 26)
        Me.Label57.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(65, 15)
        Me.Label57.TabIndex = 11
        Me.Label57.Text = "Date From"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(9, 54)
        Me.Label76.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(50, 15)
        Me.Label76.TabIndex = 12
        Me.Label76.Text = "Date To"
        '
        'dtpDateFrom_Garden
        '
        Me.dtpDateFrom_Garden.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateFrom_Garden.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom_Garden.Location = New System.Drawing.Point(88, 26)
        Me.dtpDateFrom_Garden.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateFrom_Garden.Name = "dtpDateFrom_Garden"
        Me.dtpDateFrom_Garden.Size = New System.Drawing.Size(108, 21)
        Me.dtpDateFrom_Garden.TabIndex = 5
        '
        'dtpDateTo_Garden
        '
        Me.dtpDateTo_Garden.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateTo_Garden.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo_Garden.Location = New System.Drawing.Point(88, 52)
        Me.dtpDateTo_Garden.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateTo_Garden.Name = "dtpDateTo_Garden"
        Me.dtpDateTo_Garden.Size = New System.Drawing.Size(108, 21)
        Me.dtpDateTo_Garden.TabIndex = 6
        '
        'txtDaysGarden
        '
        Me.txtDaysGarden.Location = New System.Drawing.Point(88, 78)
        Me.txtDaysGarden.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDaysGarden.Name = "txtDaysGarden"
        Me.txtDaysGarden.ReadOnly = True
        Me.txtDaysGarden.Size = New System.Drawing.Size(79, 21)
        Me.txtDaysGarden.TabIndex = 7
        Me.txtDaysGarden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRateGarden
        '
        Me.txtRateGarden.Location = New System.Drawing.Point(88, 103)
        Me.txtRateGarden.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRateGarden.Name = "txtRateGarden"
        Me.txtRateGarden.ReadOnly = True
        Me.txtRateGarden.Size = New System.Drawing.Size(79, 21)
        Me.txtRateGarden.TabIndex = 8
        Me.txtRateGarden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalGarden
        '
        Me.txtTotalGarden.Location = New System.Drawing.Point(89, 128)
        Me.txtTotalGarden.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTotalGarden.Name = "txtTotalGarden"
        Me.txtTotalGarden.ReadOnly = True
        Me.txtTotalGarden.Size = New System.Drawing.Size(79, 21)
        Me.txtTotalGarden.TabIndex = 9
        Me.txtTotalGarden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl11
        '
        Me.GroupControl11.Controls.Add(Me.Label66)
        Me.GroupControl11.Controls.Add(Me.txtTotalPaid1)
        Me.GroupControl11.Controls.Add(Me.cmbCurrency)
        Me.GroupControl11.Controls.Add(Label24)
        Me.GroupControl11.Controls.Add(Me.txtGrandTotal1)
        Me.GroupControl11.Controls.Add(Label23)
        Me.GroupControl11.Controls.Add(Label21)
        Me.GroupControl11.Controls.Add(Me.txtBalance1)
        Me.GroupControl11.Controls.Add(Me.txtOtherCharges1)
        Me.GroupControl11.Controls.Add(Label63)
        Me.GroupControl11.Controls.Add(Me.txtSubTotal1)
        Me.GroupControl11.Controls.Add(Label62)
        Me.GroupControl11.Location = New System.Drawing.Point(3, 169)
        Me.GroupControl11.Name = "GroupControl11"
        Me.GroupControl11.Size = New System.Drawing.Size(179, 184)
        Me.GroupControl11.TabIndex = 340
        Me.GroupControl11.Text = "Total Cost Information "
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label66.Location = New System.Drawing.Point(4, 27)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(51, 13)
        Me.Label66.TabIndex = 334
        Me.Label66.Text = "Currency"
        '
        'txtTotalPaid1
        '
        Me.txtTotalPaid1.Location = New System.Drawing.Point(92, 132)
        Me.txtTotalPaid1.Name = "txtTotalPaid1"
        Me.txtTotalPaid1.Size = New System.Drawing.Size(84, 21)
        Me.txtTotalPaid1.TabIndex = 20
        Me.txtTotalPaid1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbCurrency
        '
        Me.cmbCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(92, 22)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(87, 23)
        Me.cmbCurrency.TabIndex = 11
        '
        'txtGrandTotal1
        '
        Me.txtGrandTotal1.Location = New System.Drawing.Point(92, 105)
        Me.txtGrandTotal1.Name = "txtGrandTotal1"
        Me.txtGrandTotal1.ReadOnly = True
        Me.txtGrandTotal1.Size = New System.Drawing.Size(84, 21)
        Me.txtGrandTotal1.TabIndex = 19
        Me.txtGrandTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBalance1
        '
        Me.txtBalance1.Location = New System.Drawing.Point(92, 157)
        Me.txtBalance1.Name = "txtBalance1"
        Me.txtBalance1.ReadOnly = True
        Me.txtBalance1.Size = New System.Drawing.Size(84, 21)
        Me.txtBalance1.TabIndex = 21
        Me.txtBalance1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtherCharges1
        '
        Me.txtOtherCharges1.Location = New System.Drawing.Point(93, 51)
        Me.txtOtherCharges1.Name = "txtOtherCharges1"
        Me.txtOtherCharges1.Size = New System.Drawing.Size(84, 21)
        Me.txtOtherCharges1.TabIndex = 10
        Me.txtOtherCharges1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal1
        '
        Me.txtSubTotal1.Location = New System.Drawing.Point(92, 78)
        Me.txtSubTotal1.Name = "txtSubTotal1"
        Me.txtSubTotal1.ReadOnly = True
        Me.txtSubTotal1.Size = New System.Drawing.Size(84, 21)
        Me.txtSubTotal1.TabIndex = 14
        Me.txtSubTotal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl12
        '
        Me.GroupControl12.Controls.Add(Me.dtpDateFrom_Hall)
        Me.GroupControl12.Controls.Add(Me.Label14)
        Me.GroupControl12.Controls.Add(Me.Label19)
        Me.GroupControl12.Controls.Add(Me.dtpDateTo_Hall)
        Me.GroupControl12.Controls.Add(Me.txtDaysHall)
        Me.GroupControl12.Controls.Add(Me.Label15)
        Me.GroupControl12.Controls.Add(Me.Label12)
        Me.GroupControl12.Controls.Add(Me.txtRateHall)
        Me.GroupControl12.Controls.Add(Me.txtTotalHall)
        Me.GroupControl12.Controls.Add(Me.Label16)
        Me.GroupControl12.Location = New System.Drawing.Point(205, 2)
        Me.GroupControl12.Name = "GroupControl12"
        Me.GroupControl12.Size = New System.Drawing.Size(213, 164)
        Me.GroupControl12.TabIndex = 333
        Me.GroupControl12.Text = "Hall Information"
        '
        'dtpDateFrom_Hall
        '
        Me.dtpDateFrom_Hall.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateFrom_Hall.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom_Hall.Location = New System.Drawing.Point(84, 28)
        Me.dtpDateFrom_Hall.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateFrom_Hall.Name = "dtpDateFrom_Hall"
        Me.dtpDateFrom_Hall.Size = New System.Drawing.Size(120, 21)
        Me.dtpDateFrom_Hall.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 31)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 15)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Date From"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(5, 57)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 15)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "Date To"
        '
        'dtpDateTo_Hall
        '
        Me.dtpDateTo_Hall.CustomFormat = "dd/MMM/yyyy"
        Me.dtpDateTo_Hall.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo_Hall.Location = New System.Drawing.Point(84, 54)
        Me.dtpDateTo_Hall.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDateTo_Hall.Name = "dtpDateTo_Hall"
        Me.dtpDateTo_Hall.Size = New System.Drawing.Size(120, 21)
        Me.dtpDateTo_Hall.TabIndex = 1
        '
        'txtDaysHall
        '
        Me.txtDaysHall.Location = New System.Drawing.Point(87, 83)
        Me.txtDaysHall.Margin = New System.Windows.Forms.Padding(2)
        Me.txtDaysHall.Name = "txtDaysHall"
        Me.txtDaysHall.ReadOnly = True
        Me.txtDaysHall.Size = New System.Drawing.Size(81, 21)
        Me.txtDaysHall.TabIndex = 2
        Me.txtDaysHall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(5, 85)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 15)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "No. Of Days"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 109)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 15)
        Me.Label12.TabIndex = 288
        Me.Label12.Text = "Rate"
        '
        'txtRateHall
        '
        Me.txtRateHall.Location = New System.Drawing.Point(86, 109)
        Me.txtRateHall.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRateHall.Name = "txtRateHall"
        Me.txtRateHall.ReadOnly = True
        Me.txtRateHall.Size = New System.Drawing.Size(82, 21)
        Me.txtRateHall.TabIndex = 3
        Me.txtRateHall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalHall
        '
        Me.txtTotalHall.Location = New System.Drawing.Point(86, 136)
        Me.txtTotalHall.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTotalHall.Name = "txtTotalHall"
        Me.txtTotalHall.ReadOnly = True
        Me.txtTotalHall.Size = New System.Drawing.Size(82, 21)
        Me.txtTotalHall.TabIndex = 4
        Me.txtTotalHall.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 139)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 15)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Total"
        '
        'GroupControl10
        '
        Me.GroupControl10.Controls.Add(Label61)
        Me.GroupControl10.Controls.Add(Me.txtServiceTaxPer1)
        Me.GroupControl10.Controls.Add(Me.txtServiceTaxAmount1)
        Me.GroupControl10.Controls.Add(Label60)
        Me.GroupControl10.Controls.Add(Me.txtLuxuryTaxPer1)
        Me.GroupControl10.Controls.Add(Me.txtLuxuryTaxAmount1)
        Me.GroupControl10.Controls.Add(Me.txtDiscount1)
        Me.GroupControl10.Controls.Add(Me.Label20)
        Me.GroupControl10.Controls.Add(Me.Label17)
        Me.GroupControl10.Controls.Add(Me.Label18)
        Me.GroupControl10.Controls.Add(Me.txtDiscountPer1)
        Me.GroupControl10.Controls.Add(Label25)
        Me.GroupControl10.Location = New System.Drawing.Point(186, 169)
        Me.GroupControl10.Name = "GroupControl10"
        Me.GroupControl10.Size = New System.Drawing.Size(230, 116)
        Me.GroupControl10.TabIndex = 339
        Me.GroupControl10.Text = "Tax Information System"
        '
        'txtServiceTaxPer1
        '
        Me.txtServiceTaxPer1.BackColor = System.Drawing.Color.Peru
        Me.txtServiceTaxPer1.ForeColor = System.Drawing.Color.Red
        Me.txtServiceTaxPer1.Location = New System.Drawing.Point(81, 55)
        Me.txtServiceTaxPer1.Name = "txtServiceTaxPer1"
        Me.txtServiceTaxPer1.Size = New System.Drawing.Size(55, 21)
        Me.txtServiceTaxPer1.TabIndex = 15
        Me.txtServiceTaxPer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxAmount1
        '
        Me.txtServiceTaxAmount1.BackColor = System.Drawing.Color.PeachPuff
        Me.txtServiceTaxAmount1.Location = New System.Drawing.Point(167, 55)
        Me.txtServiceTaxAmount1.Name = "txtServiceTaxAmount1"
        Me.txtServiceTaxAmount1.ReadOnly = True
        Me.txtServiceTaxAmount1.Size = New System.Drawing.Size(54, 21)
        Me.txtServiceTaxAmount1.TabIndex = 16
        Me.txtServiceTaxAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxPer1
        '
        Me.txtLuxuryTaxPer1.BackColor = System.Drawing.Color.Peru
        Me.txtLuxuryTaxPer1.ForeColor = System.Drawing.Color.Red
        Me.txtLuxuryTaxPer1.Location = New System.Drawing.Point(81, 84)
        Me.txtLuxuryTaxPer1.Name = "txtLuxuryTaxPer1"
        Me.txtLuxuryTaxPer1.Size = New System.Drawing.Size(55, 21)
        Me.txtLuxuryTaxPer1.TabIndex = 17
        Me.txtLuxuryTaxPer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxAmount1
        '
        Me.txtLuxuryTaxAmount1.BackColor = System.Drawing.Color.PeachPuff
        Me.txtLuxuryTaxAmount1.Location = New System.Drawing.Point(167, 83)
        Me.txtLuxuryTaxAmount1.Name = "txtLuxuryTaxAmount1"
        Me.txtLuxuryTaxAmount1.ReadOnly = True
        Me.txtLuxuryTaxAmount1.Size = New System.Drawing.Size(54, 21)
        Me.txtLuxuryTaxAmount1.TabIndex = 18
        Me.txtLuxuryTaxAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscount1
        '
        Me.txtDiscount1.BackColor = System.Drawing.Color.PeachPuff
        Me.txtDiscount1.Location = New System.Drawing.Point(167, 28)
        Me.txtDiscount1.Name = "txtDiscount1"
        Me.txtDiscount1.ReadOnly = True
        Me.txtDiscount1.Size = New System.Drawing.Size(54, 21)
        Me.txtDiscount1.TabIndex = 13
        Me.txtDiscount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(138, 54)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 21)
        Me.Label20.TabIndex = 325
        Me.Label20.Text = "%"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(138, 28)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 21)
        Me.Label17.TabIndex = 327
        Me.Label17.Text = "%"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(138, 84)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(23, 21)
        Me.Label18.TabIndex = 326
        Me.Label18.Text = "%"
        '
        'txtDiscountPer1
        '
        Me.txtDiscountPer1.BackColor = System.Drawing.Color.Peru
        Me.txtDiscountPer1.ForeColor = System.Drawing.Color.Red
        Me.txtDiscountPer1.Location = New System.Drawing.Point(81, 28)
        Me.txtDiscountPer1.Name = "txtDiscountPer1"
        Me.txtDiscountPer1.Size = New System.Drawing.Size(55, 21)
        Me.txtDiscountPer1.TabIndex = 12
        Me.txtDiscountPer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl9
        '
        Me.GroupControl9.Controls.Add(Me.txtIDType1)
        Me.GroupControl9.Controls.Add(Me.txtGuestAddress1)
        Me.GroupControl9.Controls.Add(Me.Button1)
        Me.GroupControl9.Controls.Add(Label59)
        Me.GroupControl9.Controls.Add(Me.txtIDNumber1)
        Me.GroupControl9.Controls.Add(Label11)
        Me.GroupControl9.Controls.Add(Me.txtContactNo1)
        Me.GroupControl9.Controls.Add(Label10)
        Me.GroupControl9.Controls.Add(Label4)
        Me.GroupControl9.Controls.Add(Label8)
        Me.GroupControl9.Controls.Add(Me.txtCity1)
        Me.GroupControl9.Controls.Add(Me.txtGuestID1)
        Me.GroupControl9.Controls.Add(Label5)
        Me.GroupControl9.Controls.Add(Label7)
        Me.GroupControl9.Controls.Add(Me.txtGuestName1)
        Me.GroupControl9.Location = New System.Drawing.Point(867, 2)
        Me.GroupControl9.Name = "GroupControl9"
        Me.GroupControl9.Size = New System.Drawing.Size(338, 220)
        Me.GroupControl9.TabIndex = 282
        Me.GroupControl9.Text = "Guest Profile"
        '
        'txtIDType1
        '
        Me.txtIDType1.Location = New System.Drawing.Point(112, 153)
        Me.txtIDType1.Name = "txtIDType1"
        Me.txtIDType1.ReadOnly = True
        Me.txtIDType1.Size = New System.Drawing.Size(187, 21)
        Me.txtIDType1.TabIndex = 281
        '
        'txtGuestAddress1
        '
        Me.txtGuestAddress1.Location = New System.Drawing.Point(112, 76)
        Me.txtGuestAddress1.Name = "txtGuestAddress1"
        Me.txtGuestAddress1.ReadOnly = True
        Me.txtGuestAddress1.Size = New System.Drawing.Size(218, 21)
        Me.txtGuestAddress1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(317, 204)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(10, 11)
        Me.Button1.TabIndex = 279
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtIDNumber1
        '
        Me.txtIDNumber1.Location = New System.Drawing.Point(112, 178)
        Me.txtIDNumber1.Name = "txtIDNumber1"
        Me.txtIDNumber1.ReadOnly = True
        Me.txtIDNumber1.Size = New System.Drawing.Size(218, 21)
        Me.txtIDNumber1.TabIndex = 6
        '
        'txtContactNo1
        '
        Me.txtContactNo1.Location = New System.Drawing.Point(112, 127)
        Me.txtContactNo1.Name = "txtContactNo1"
        Me.txtContactNo1.ReadOnly = True
        Me.txtContactNo1.Size = New System.Drawing.Size(141, 21)
        Me.txtContactNo1.TabIndex = 4
        '
        'txtCity1
        '
        Me.txtCity1.Location = New System.Drawing.Point(112, 101)
        Me.txtCity1.Name = "txtCity1"
        Me.txtCity1.ReadOnly = True
        Me.txtCity1.Size = New System.Drawing.Size(198, 21)
        Me.txtCity1.TabIndex = 3
        '
        'txtGuestID1
        '
        Me.txtGuestID1.Location = New System.Drawing.Point(112, 27)
        Me.txtGuestID1.Name = "txtGuestID1"
        Me.txtGuestID1.ReadOnly = True
        Me.txtGuestID1.Size = New System.Drawing.Size(141, 21)
        Me.txtGuestID1.TabIndex = 0
        '
        'txtGuestName1
        '
        Me.txtGuestName1.Location = New System.Drawing.Point(112, 52)
        Me.txtGuestName1.Name = "txtGuestName1"
        Me.txtGuestName1.ReadOnly = True
        Me.txtGuestName1.Size = New System.Drawing.Size(218, 21)
        Me.txtGuestName1.TabIndex = 1
        '
        'txtEducessTaxAmount
        '
        Me.txtEducessTaxAmount.Location = New System.Drawing.Point(139, 436)
        Me.txtEducessTaxAmount.Name = "txtEducessTaxAmount"
        Me.txtEducessTaxAmount.Size = New System.Drawing.Size(100, 21)
        Me.txtEducessTaxAmount.TabIndex = 338
        Me.txtEducessTaxAmount.Visible = False
        '
        'txtHEducessTaxAmount
        '
        Me.txtHEducessTaxAmount.Location = New System.Drawing.Point(139, 410)
        Me.txtHEducessTaxAmount.Name = "txtHEducessTaxAmount"
        Me.txtHEducessTaxAmount.Size = New System.Drawing.Size(100, 21)
        Me.txtHEducessTaxAmount.TabIndex = 337
        Me.txtHEducessTaxAmount.Visible = False
        '
        'txtEducessTax
        '
        Me.txtEducessTax.Location = New System.Drawing.Point(139, 374)
        Me.txtEducessTax.Name = "txtEducessTax"
        Me.txtEducessTax.Size = New System.Drawing.Size(100, 21)
        Me.txtEducessTax.TabIndex = 336
        Me.txtEducessTax.Visible = False
        '
        'txtHEduCessTax
        '
        Me.txtHEduCessTax.Location = New System.Drawing.Point(13, 462)
        Me.txtHEduCessTax.Name = "txtHEduCessTax"
        Me.txtHEduCessTax.Size = New System.Drawing.Size(100, 21)
        Me.txtHEduCessTax.TabIndex = 335
        Me.txtHEduCessTax.Visible = False
        '
        'DateTimePicker6
        '
        Me.DateTimePicker6.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker6.Location = New System.Drawing.Point(11, 435)
        Me.DateTimePicker6.Name = "DateTimePicker6"
        Me.DateTimePicker6.Size = New System.Drawing.Size(122, 21)
        Me.DateTimePicker6.TabIndex = 334
        Me.DateTimePicker6.Visible = False
        '
        'DateTimePicker5
        '
        Me.DateTimePicker5.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker5.Location = New System.Drawing.Point(11, 405)
        Me.DateTimePicker5.Name = "DateTimePicker5"
        Me.DateTimePicker5.Size = New System.Drawing.Size(122, 21)
        Me.DateTimePicker5.TabIndex = 333
        Me.DateTimePicker5.Visible = False
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(11, 375)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(122, 21)
        Me.DateTimePicker4.TabIndex = 332
        Me.DateTimePicker4.Visible = False
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(123, 463)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(122, 21)
        Me.DateTimePicker3.TabIndex = 331
        Me.DateTimePicker3.Visible = False
        '
        'txtID2
        '
        Me.txtID2.Location = New System.Drawing.Point(13, 313)
        Me.txtID2.Name = "txtID2"
        Me.txtID2.Size = New System.Drawing.Size(100, 21)
        Me.txtID2.TabIndex = 330
        Me.txtID2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label64)
        Me.Panel2.Location = New System.Drawing.Point(529, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 10)
        Me.Panel2.TabIndex = 1
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(334, 31)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(10, 15)
        Me.Label64.TabIndex = 19
        Me.Label64.Text = "."
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(11, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(15, 14)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(585, 34)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(19, 14)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SimpleButton8)
        Me.TabPage3.Controls.Add(Me.searchallorgarden)
        Me.TabPage3.Controls.Add(Me.SimpleButton7)
        Me.TabPage3.Controls.Add(Me.btnGetData2)
        Me.TabPage3.Controls.Add(Me.guests)
        Me.TabPage3.Controls.Add(Me.GroupControl24)
        Me.TabPage3.Controls.Add(Me.GroupControl23)
        Me.TabPage3.Controls.Add(Me.GroupControl21)
        Me.TabPage3.Controls.Add(Me.GroupControl20)
        Me.TabPage3.Controls.Add(Me.GroupControl19)
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Controls.Add(Me.GroupControl18)
        Me.TabPage3.Controls.Add(Me.GroupControl17)
        Me.TabPage3.Controls.Add(Me.txteducessTaxAmount1)
        Me.TabPage3.Controls.Add(Me.txtHeducessTaxAmount1)
        Me.TabPage3.Controls.Add(Me.txteducessTax1)
        Me.TabPage3.Controls.Add(Me.txtHeducessTax1)
        Me.TabPage3.Controls.Add(Me.DateTimePicker2)
        Me.TabPage3.Controls.Add(Me.DateTimePicker1)
        Me.TabPage3.Controls.Add(Me.Panel4)
        Me.TabPage3.Controls.Add(Me.txtID3)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1205, 599)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Hall or Garden"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SimpleButton8
        '
        Me.SimpleButton8.Location = New System.Drawing.Point(617, 209)
        Me.SimpleButton8.Name = "SimpleButton8"
        Me.SimpleButton8.Size = New System.Drawing.Size(82, 23)
        Me.SimpleButton8.TabIndex = 351
        Me.SimpleButton8.Text = "Search"
        '
        'searchallorgarden
        '
        Me.searchallorgarden.BackColor = System.Drawing.Color.DimGray
        Me.searchallorgarden.ForeColor = System.Drawing.Color.White
        Me.searchallorgarden.Location = New System.Drawing.Point(351, 209)
        Me.searchallorgarden.Multiline = True
        Me.searchallorgarden.Name = "searchallorgarden"
        Me.searchallorgarden.Size = New System.Drawing.Size(244, 24)
        Me.searchallorgarden.TabIndex = 350
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Location = New System.Drawing.Point(263, 220)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(82, 23)
        Me.SimpleButton7.TabIndex = 348
        Me.SimpleButton7.Text = "Search"
        '
        'btnGetData2
        '
        Me.btnGetData2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnGetData2.Location = New System.Drawing.Point(1181, 223)
        Me.btnGetData2.Name = "btnGetData2"
        Me.btnGetData2.Size = New System.Drawing.Size(10, 10)
        Me.btnGetData2.TabIndex = 4
        Me.btnGetData2.UseVisualStyleBackColor = True
        '
        'guests
        '
        Me.guests.BackColor = System.Drawing.Color.DimGray
        Me.guests.ForeColor = System.Drawing.Color.White
        Me.guests.Location = New System.Drawing.Point(5, 221)
        Me.guests.Multiline = True
        Me.guests.Name = "guests"
        Me.guests.Size = New System.Drawing.Size(234, 24)
        Me.guests.TabIndex = 349
        '
        'GroupControl24
        '
        Me.GroupControl24.Controls.Add(Me.hallorgarden)
        Me.GroupControl24.Location = New System.Drawing.Point(349, 235)
        Me.GroupControl24.Name = "GroupControl24"
        Me.GroupControl24.Size = New System.Drawing.Size(856, 341)
        Me.GroupControl24.TabIndex = 348
        Me.GroupControl24.Text = "Reservation Hall or Garden"
        '
        'hallorgarden
        '
        Me.hallorgarden.AllowUserToAddRows = False
        Me.hallorgarden.AllowUserToDeleteRows = False
        Me.hallorgarden.BackgroundColor = System.Drawing.Color.Moccasin
        Me.hallorgarden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.hallorgarden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hallorgarden.Location = New System.Drawing.Point(2, 21)
        Me.hallorgarden.MultiSelect = False
        Me.hallorgarden.Name = "hallorgarden"
        Me.hallorgarden.ReadOnly = True
        Me.hallorgarden.Size = New System.Drawing.Size(852, 318)
        Me.hallorgarden.TabIndex = 35
        '
        'GroupControl23
        '
        Me.GroupControl23.Controls.Add(Me.guestrr)
        Me.GroupControl23.Location = New System.Drawing.Point(3, 249)
        Me.GroupControl23.Name = "GroupControl23"
        Me.GroupControl23.Size = New System.Drawing.Size(342, 327)
        Me.GroupControl23.TabIndex = 347
        Me.GroupControl23.Text = "Guest Record"
        '
        'guestrr
        '
        Me.guestrr.AllowUserToAddRows = False
        Me.guestrr.AllowUserToDeleteRows = False
        Me.guestrr.BackgroundColor = System.Drawing.Color.DarkKhaki
        Me.guestrr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.guestrr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.guestrr.Location = New System.Drawing.Point(2, 21)
        Me.guestrr.MultiSelect = False
        Me.guestrr.Name = "guestrr"
        Me.guestrr.ReadOnly = True
        Me.guestrr.Size = New System.Drawing.Size(338, 304)
        Me.guestrr.TabIndex = 21
        '
        'GroupControl21
        '
        Me.GroupControl21.Controls.Add(Me.SimpleButton5)
        Me.GroupControl21.Controls.Add(Me.btnPrint1)
        Me.GroupControl21.Controls.Add(Me.btnSave2)
        Me.GroupControl21.Controls.Add(Me.btnUpdate2)
        Me.GroupControl21.Controls.Add(Me.btnDelete2)
        Me.GroupControl21.Controls.Add(Me.btnNew2)
        Me.GroupControl21.Location = New System.Drawing.Point(984, 3)
        Me.GroupControl21.Name = "GroupControl21"
        Me.GroupControl21.Size = New System.Drawing.Size(211, 204)
        Me.GroupControl21.TabIndex = 346
        Me.GroupControl21.Text = "Action Button "
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(115, 128)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton5.TabIndex = 347
        Me.SimpleButton5.Text = "Close"
        '
        'btnPrint1
        '
        Me.btnPrint1.Enabled = False
        Me.btnPrint1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnPrint1.Location = New System.Drawing.Point(110, 87)
        Me.btnPrint1.Name = "btnPrint1"
        Me.btnPrint1.Size = New System.Drawing.Size(87, 31)
        Me.btnPrint1.TabIndex = 5
        Me.btnPrint1.Text = "Print"
        Me.btnPrint1.UseVisualStyleBackColor = True
        '
        'btnSave2
        '
        Me.btnSave2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnSave2.Location = New System.Drawing.Point(9, 83)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.Size = New System.Drawing.Size(87, 31)
        Me.btnSave2.TabIndex = 1
        Me.btnSave2.Text = "Reserve"
        Me.btnSave2.UseVisualStyleBackColor = True
        '
        'btnUpdate2
        '
        Me.btnUpdate2.Enabled = False
        Me.btnUpdate2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnUpdate2.Location = New System.Drawing.Point(110, 47)
        Me.btnUpdate2.Name = "btnUpdate2"
        Me.btnUpdate2.Size = New System.Drawing.Size(87, 31)
        Me.btnUpdate2.TabIndex = 3
        Me.btnUpdate2.Text = "Update"
        Me.btnUpdate2.UseVisualStyleBackColor = True
        '
        'btnDelete2
        '
        Me.btnDelete2.Enabled = False
        Me.btnDelete2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnDelete2.Location = New System.Drawing.Point(9, 120)
        Me.btnDelete2.Name = "btnDelete2"
        Me.btnDelete2.Size = New System.Drawing.Size(87, 31)
        Me.btnDelete2.TabIndex = 2
        Me.btnDelete2.Text = "Delete"
        Me.btnDelete2.UseVisualStyleBackColor = True
        '
        'btnNew2
        '
        Me.btnNew2.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.btnNew2.Location = New System.Drawing.Point(9, 46)
        Me.btnNew2.Name = "btnNew2"
        Me.btnNew2.Size = New System.Drawing.Size(87, 31)
        Me.btnNew2.TabIndex = 0
        Me.btnNew2.Text = "Clear"
        Me.btnNew2.UseVisualStyleBackColor = True
        '
        'GroupControl20
        '
        Me.GroupControl20.CaptionLocation = DevExpress.Utils.Locations.Right
        Me.GroupControl20.Controls.Add(Me.RadioButton2)
        Me.GroupControl20.Controls.Add(Me.DateTo)
        Me.GroupControl20.Controls.Add(Me.RadioButton1)
        Me.GroupControl20.Controls.Add(Me.Label72)
        Me.GroupControl20.Controls.Add(Me.txtNoOfDays1)
        Me.GroupControl20.Controls.Add(Me.Label71)
        Me.GroupControl20.Controls.Add(Me.Label68)
        Me.GroupControl20.Controls.Add(Me.Label70)
        Me.GroupControl20.Controls.Add(Me.DateFrom)
        Me.GroupControl20.Controls.Add(Me.Label69)
        Me.GroupControl20.Controls.Add(Me.txtRate)
        Me.GroupControl20.Controls.Add(Me.txtTotalCharges)
        Me.GroupControl20.Location = New System.Drawing.Point(647, 0)
        Me.GroupControl20.Name = "GroupControl20"
        Me.GroupControl20.Size = New System.Drawing.Size(326, 108)
        Me.GroupControl20.TabIndex = 345
        Me.GroupControl20.Text = "Hall and Garden Information "
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(225, 27)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(66, 19)
        Me.RadioButton2.TabIndex = 349
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Garden"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'DateTo
        '
        Me.DateTo.CustomFormat = "dd/MMM/yyyy"
        Me.DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTo.Location = New System.Drawing.Point(83, 29)
        Me.DateTo.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTo.Name = "DateTo"
        Me.DateTo.Size = New System.Drawing.Size(123, 21)
        Me.DateTo.TabIndex = 2
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(225, 4)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(47, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Hall"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(5, 7)
        Me.Label72.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(65, 15)
        Me.Label72.TabIndex = 334
        Me.Label72.Text = "From Date"
        '
        'txtNoOfDays1
        '
        Me.txtNoOfDays1.Location = New System.Drawing.Point(83, 53)
        Me.txtNoOfDays1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNoOfDays1.Name = "txtNoOfDays1"
        Me.txtNoOfDays1.ReadOnly = True
        Me.txtNoOfDays1.Size = New System.Drawing.Size(79, 21)
        Me.txtNoOfDays1.TabIndex = 3
        Me.txtNoOfDays1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(5, 54)
        Me.Label71.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(71, 15)
        Me.Label71.TabIndex = 335
        Me.Label71.Text = "No. Of Days"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(173, 54)
        Me.Label68.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(33, 15)
        Me.Label68.TabIndex = 346
        Me.Label68.Text = "Rate"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(4, 78)
        Me.Label70.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(34, 15)
        Me.Label70.TabIndex = 336
        Me.Label70.Text = "Total"
        '
        'DateFrom
        '
        Me.DateFrom.CustomFormat = "dd/MMM/yyyy"
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFrom.Location = New System.Drawing.Point(83, 6)
        Me.DateFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.Size = New System.Drawing.Size(123, 21)
        Me.DateFrom.TabIndex = 1
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(5, 29)
        Me.Label69.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(50, 15)
        Me.Label69.TabIndex = 337
        Me.Label69.Text = "To Date"
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(222, 53)
        Me.txtRate.Margin = New System.Windows.Forms.Padding(2)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.ReadOnly = True
        Me.txtRate.Size = New System.Drawing.Size(79, 21)
        Me.txtRate.TabIndex = 4
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalCharges
        '
        Me.txtTotalCharges.Location = New System.Drawing.Point(83, 79)
        Me.txtTotalCharges.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTotalCharges.Name = "txtTotalCharges"
        Me.txtTotalCharges.ReadOnly = True
        Me.txtTotalCharges.Size = New System.Drawing.Size(79, 21)
        Me.txtTotalCharges.TabIndex = 5
        Me.txtTotalCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl19
        '
        Me.GroupControl19.Controls.Add(Me.cmbCurrency1)
        Me.GroupControl19.Controls.Add(Me.Label74)
        Me.GroupControl19.Controls.Add(Me.txtGrandTotal2)
        Me.GroupControl19.Controls.Add(Label34)
        Me.GroupControl19.Controls.Add(Label32)
        Me.GroupControl19.Controls.Add(Me.txtTotalPaid2)
        Me.GroupControl19.Controls.Add(Label31)
        Me.GroupControl19.Controls.Add(Me.txtOtherCharges2)
        Me.GroupControl19.Controls.Add(Label39)
        Me.GroupControl19.Controls.Add(Me.txtSubTotal2)
        Me.GroupControl19.Controls.Add(Label38)
        Me.GroupControl19.Controls.Add(Me.txtBalance2)
        Me.GroupControl19.Location = New System.Drawing.Point(348, 110)
        Me.GroupControl19.Name = "GroupControl19"
        Me.GroupControl19.Size = New System.Drawing.Size(625, 97)
        Me.GroupControl19.TabIndex = 344
        '
        'cmbCurrency1
        '
        Me.cmbCurrency1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCurrency1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrency1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmbCurrency1.FormattingEnabled = True
        Me.cmbCurrency1.Location = New System.Drawing.Point(511, 31)
        Me.cmbCurrency1.Name = "cmbCurrency1"
        Me.cmbCurrency1.Size = New System.Drawing.Size(98, 23)
        Me.cmbCurrency1.TabIndex = 2
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label74.Location = New System.Drawing.Point(416, 33)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(55, 15)
        Me.Label74.TabIndex = 336
        Me.Label74.Text = "Currency"
        '
        'txtGrandTotal2
        '
        Me.txtGrandTotal2.Location = New System.Drawing.Point(87, 56)
        Me.txtGrandTotal2.Name = "txtGrandTotal2"
        Me.txtGrandTotal2.ReadOnly = True
        Me.txtGrandTotal2.Size = New System.Drawing.Size(84, 21)
        Me.txtGrandTotal2.TabIndex = 10
        Me.txtGrandTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPaid2
        '
        Me.txtTotalPaid2.Location = New System.Drawing.Point(284, 55)
        Me.txtTotalPaid2.Name = "txtTotalPaid2"
        Me.txtTotalPaid2.Size = New System.Drawing.Size(98, 21)
        Me.txtTotalPaid2.TabIndex = 11
        Me.txtTotalPaid2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtherCharges2
        '
        Me.txtOtherCharges2.Location = New System.Drawing.Point(284, 31)
        Me.txtOtherCharges2.Name = "txtOtherCharges2"
        Me.txtOtherCharges2.Size = New System.Drawing.Size(98, 21)
        Me.txtOtherCharges2.TabIndex = 1
        Me.txtOtherCharges2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal2
        '
        Me.txtSubTotal2.Location = New System.Drawing.Point(87, 32)
        Me.txtSubTotal2.Name = "txtSubTotal2"
        Me.txtSubTotal2.ReadOnly = True
        Me.txtSubTotal2.Size = New System.Drawing.Size(84, 21)
        Me.txtSubTotal2.TabIndex = 5
        Me.txtSubTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBalance2
        '
        Me.txtBalance2.Location = New System.Drawing.Point(511, 56)
        Me.txtBalance2.Name = "txtBalance2"
        Me.txtBalance2.ReadOnly = True
        Me.txtBalance2.Size = New System.Drawing.Size(98, 21)
        Me.txtBalance2.TabIndex = 12
        Me.txtBalance2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Location = New System.Drawing.Point(814, 140)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(27, 13)
        Me.Panel3.TabIndex = 0
        '
        'GroupControl18
        '
        Me.GroupControl18.Controls.Add(Me.txtServiceTaxPer2)
        Me.GroupControl18.Controls.Add(Label37)
        Me.GroupControl18.Controls.Add(Me.txtServiceTaxAmount2)
        Me.GroupControl18.Controls.Add(Label36)
        Me.GroupControl18.Controls.Add(Me.txtLuxuryTaxPer2)
        Me.GroupControl18.Controls.Add(Me.txtDiscount2)
        Me.GroupControl18.Controls.Add(Me.txtLuxuryTaxAmount2)
        Me.GroupControl18.Controls.Add(Me.Label28)
        Me.GroupControl18.Controls.Add(Me.Label29)
        Me.GroupControl18.Controls.Add(Me.Label30)
        Me.GroupControl18.Controls.Add(Me.txtDiscountPer2)
        Me.GroupControl18.Controls.Add(Label35)
        Me.GroupControl18.Location = New System.Drawing.Point(346, 2)
        Me.GroupControl18.Name = "GroupControl18"
        Me.GroupControl18.Size = New System.Drawing.Size(298, 106)
        Me.GroupControl18.TabIndex = 343
        Me.GroupControl18.Text = "tax Information"
        '
        'txtServiceTaxPer2
        '
        Me.txtServiceTaxPer2.Location = New System.Drawing.Point(106, 24)
        Me.txtServiceTaxPer2.Name = "txtServiceTaxPer2"
        Me.txtServiceTaxPer2.Size = New System.Drawing.Size(62, 21)
        Me.txtServiceTaxPer2.TabIndex = 6
        Me.txtServiceTaxPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtServiceTaxAmount2
        '
        Me.txtServiceTaxAmount2.Location = New System.Drawing.Point(203, 24)
        Me.txtServiceTaxAmount2.Name = "txtServiceTaxAmount2"
        Me.txtServiceTaxAmount2.ReadOnly = True
        Me.txtServiceTaxAmount2.Size = New System.Drawing.Size(84, 21)
        Me.txtServiceTaxAmount2.TabIndex = 7
        Me.txtServiceTaxAmount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxPer2
        '
        Me.txtLuxuryTaxPer2.Location = New System.Drawing.Point(106, 47)
        Me.txtLuxuryTaxPer2.Name = "txtLuxuryTaxPer2"
        Me.txtLuxuryTaxPer2.Size = New System.Drawing.Size(62, 21)
        Me.txtLuxuryTaxPer2.TabIndex = 8
        Me.txtLuxuryTaxPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiscount2
        '
        Me.txtDiscount2.Location = New System.Drawing.Point(203, 76)
        Me.txtDiscount2.Name = "txtDiscount2"
        Me.txtDiscount2.ReadOnly = True
        Me.txtDiscount2.Size = New System.Drawing.Size(84, 21)
        Me.txtDiscount2.TabIndex = 4
        Me.txtDiscount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLuxuryTaxAmount2
        '
        Me.txtLuxuryTaxAmount2.Location = New System.Drawing.Point(203, 49)
        Me.txtLuxuryTaxAmount2.Name = "txtLuxuryTaxAmount2"
        Me.txtLuxuryTaxAmount2.ReadOnly = True
        Me.txtLuxuryTaxAmount2.Size = New System.Drawing.Size(84, 21)
        Me.txtLuxuryTaxAmount2.TabIndex = 9
        Me.txtLuxuryTaxAmount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(174, 76)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(23, 21)
        Me.Label28.TabIndex = 327
        Me.Label28.Text = "%"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(174, 47)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(23, 21)
        Me.Label29.TabIndex = 24
        Me.Label29.Text = "%"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Palatino Linotype", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(174, 24)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(23, 21)
        Me.Label30.TabIndex = 325
        Me.Label30.Text = "%"
        '
        'txtDiscountPer2
        '
        Me.txtDiscountPer2.Location = New System.Drawing.Point(106, 73)
        Me.txtDiscountPer2.Name = "txtDiscountPer2"
        Me.txtDiscountPer2.Size = New System.Drawing.Size(62, 21)
        Me.txtDiscountPer2.TabIndex = 3
        Me.txtDiscountPer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupControl17
        '
        Me.GroupControl17.Controls.Add(Me.txtGuestAddress2)
        Me.GroupControl17.Controls.Add(Me.txtIDType2)
        Me.GroupControl17.Controls.Add(Label67)
        Me.GroupControl17.Controls.Add(Me.Button2)
        Me.GroupControl17.Controls.Add(Label45)
        Me.GroupControl17.Controls.Add(Me.txtIDNumber2)
        Me.GroupControl17.Controls.Add(Label44)
        Me.GroupControl17.Controls.Add(Me.txtGuestContactNo2)
        Me.GroupControl17.Controls.Add(Label43)
        Me.GroupControl17.Controls.Add(Label40)
        Me.GroupControl17.Controls.Add(Me.txtGuestID2)
        Me.GroupControl17.Controls.Add(Me.txtGuestCity2)
        Me.GroupControl17.Controls.Add(Label42)
        Me.GroupControl17.Controls.Add(Label41)
        Me.GroupControl17.Controls.Add(Me.txtGuestName2)
        Me.GroupControl17.Location = New System.Drawing.Point(1, 2)
        Me.GroupControl17.Name = "GroupControl17"
        Me.GroupControl17.Size = New System.Drawing.Size(344, 214)
        Me.GroupControl17.TabIndex = 280
        Me.GroupControl17.Text = "Guest Profile"
        '
        'txtGuestAddress2
        '
        Me.txtGuestAddress2.Location = New System.Drawing.Point(106, 78)
        Me.txtGuestAddress2.Name = "txtGuestAddress2"
        Me.txtGuestAddress2.ReadOnly = True
        Me.txtGuestAddress2.Size = New System.Drawing.Size(231, 21)
        Me.txtGuestAddress2.TabIndex = 2
        '
        'txtIDType2
        '
        Me.txtIDType2.Location = New System.Drawing.Point(106, 153)
        Me.txtIDType2.Name = "txtIDType2"
        Me.txtIDType2.ReadOnly = True
        Me.txtIDType2.Size = New System.Drawing.Size(195, 21)
        Me.txtIDType2.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(327, 202)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(10, 10)
        Me.Button2.TabIndex = 279
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtIDNumber2
        '
        Me.txtIDNumber2.Location = New System.Drawing.Point(106, 179)
        Me.txtIDNumber2.Name = "txtIDNumber2"
        Me.txtIDNumber2.ReadOnly = True
        Me.txtIDNumber2.Size = New System.Drawing.Size(163, 21)
        Me.txtIDNumber2.TabIndex = 6
        '
        'txtGuestContactNo2
        '
        Me.txtGuestContactNo2.Location = New System.Drawing.Point(106, 128)
        Me.txtGuestContactNo2.Name = "txtGuestContactNo2"
        Me.txtGuestContactNo2.ReadOnly = True
        Me.txtGuestContactNo2.Size = New System.Drawing.Size(149, 21)
        Me.txtGuestContactNo2.TabIndex = 4
        '
        'txtGuestID2
        '
        Me.txtGuestID2.Location = New System.Drawing.Point(106, 28)
        Me.txtGuestID2.Name = "txtGuestID2"
        Me.txtGuestID2.ReadOnly = True
        Me.txtGuestID2.Size = New System.Drawing.Size(149, 21)
        Me.txtGuestID2.TabIndex = 0
        '
        'txtGuestCity2
        '
        Me.txtGuestCity2.Location = New System.Drawing.Point(106, 104)
        Me.txtGuestCity2.Name = "txtGuestCity2"
        Me.txtGuestCity2.ReadOnly = True
        Me.txtGuestCity2.Size = New System.Drawing.Size(182, 21)
        Me.txtGuestCity2.TabIndex = 3
        '
        'txtGuestName2
        '
        Me.txtGuestName2.Location = New System.Drawing.Point(106, 53)
        Me.txtGuestName2.Name = "txtGuestName2"
        Me.txtGuestName2.ReadOnly = True
        Me.txtGuestName2.Size = New System.Drawing.Size(163, 21)
        Me.txtGuestName2.TabIndex = 1
        '
        'txteducessTaxAmount1
        '
        Me.txteducessTaxAmount1.Location = New System.Drawing.Point(413, 338)
        Me.txteducessTaxAmount1.Name = "txteducessTaxAmount1"
        Me.txteducessTaxAmount1.Size = New System.Drawing.Size(100, 21)
        Me.txteducessTaxAmount1.TabIndex = 342
        Me.txteducessTaxAmount1.Visible = False
        '
        'txtHeducessTaxAmount1
        '
        Me.txtHeducessTaxAmount1.Location = New System.Drawing.Point(413, 312)
        Me.txtHeducessTaxAmount1.Name = "txtHeducessTaxAmount1"
        Me.txtHeducessTaxAmount1.Size = New System.Drawing.Size(100, 21)
        Me.txtHeducessTaxAmount1.TabIndex = 341
        Me.txtHeducessTaxAmount1.Visible = False
        '
        'txteducessTax1
        '
        Me.txteducessTax1.Location = New System.Drawing.Point(296, 339)
        Me.txteducessTax1.Name = "txteducessTax1"
        Me.txteducessTax1.Size = New System.Drawing.Size(100, 21)
        Me.txteducessTax1.TabIndex = 340
        Me.txteducessTax1.Visible = False
        '
        'txtHeducessTax1
        '
        Me.txtHeducessTax1.Location = New System.Drawing.Point(296, 312)
        Me.txtHeducessTax1.Name = "txtHeducessTax1"
        Me.txtHeducessTax1.Size = New System.Drawing.Size(100, 21)
        Me.txtHeducessTax1.TabIndex = 339
        Me.txtHeducessTax1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(131, 336)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(120, 21)
        Me.DateTimePicker2.TabIndex = 333
        Me.DateTimePicker2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(9, 336)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker1.TabIndex = 332
        Me.DateTimePicker1.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label26)
        Me.Panel4.Location = New System.Drawing.Point(1181, 243)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(11, 10)
        Me.Panel4.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(334, 31)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 15)
        Me.Label26.TabIndex = 19
        Me.Label26.Text = "."
        '
        'txtID3
        '
        Me.txtID3.Location = New System.Drawing.Point(11, 303)
        Me.txtID3.Name = "txtID3"
        Me.txtID3.Size = New System.Drawing.Size(100, 21)
        Me.txtID3.TabIndex = 331
        Me.txtID3.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Label65)
        Me.GroupBox4.Controls.Add(Me.txtNotes2)
        Me.GroupBox4.Location = New System.Drawing.Point(831, 243)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(10, 10)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'txtNotes2
        '
        Me.txtNotes2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes2.Location = New System.Drawing.Point(331, 52)
        Me.txtNotes2.Name = "txtNotes2"
        Me.txtNotes2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes2.Size = New System.Drawing.Size(126, 138)
        Me.txtNotes2.TabIndex = 333
        Me.txtNotes2.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(57, 87)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(13, 15)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Timer1
        '
        '
        'frmCheckIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 602)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmCheckIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check In & Reservation"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl8.ResumeLayout(False)
        CType(Me.reservationGR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl7.ResumeLayout(False)
        CType(Me.guestRecordG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        Me.GroupControl6.PerformLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.GroupControl22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl22.ResumeLayout(False)
        CType(Me.hallandgarden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl16.ResumeLayout(False)
        CType(Me.guestR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl15.ResumeLayout(False)
        CType(Me.GroupControl14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl14.ResumeLayout(False)
        CType(Me.GroupControl13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl13.ResumeLayout(False)
        Me.GroupControl13.PerformLayout()
        CType(Me.GroupControl11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl11.ResumeLayout(False)
        Me.GroupControl11.PerformLayout()
        CType(Me.GroupControl12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl12.ResumeLayout(False)
        Me.GroupControl12.PerformLayout()
        CType(Me.GroupControl10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl10.ResumeLayout(False)
        Me.GroupControl10.PerformLayout()
        CType(Me.GroupControl9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl9.ResumeLayout(False)
        Me.GroupControl9.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.GroupControl24, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl24.ResumeLayout(False)
        CType(Me.hallorgarden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl23, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl23.ResumeLayout(False)
        CType(Me.guestrr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl21, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl21.ResumeLayout(False)
        CType(Me.GroupControl20, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl20.ResumeLayout(False)
        Me.GroupControl20.PerformLayout()
        CType(Me.GroupControl19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl19.ResumeLayout(False)
        Me.GroupControl19.PerformLayout()
        CType(Me.GroupControl18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl18.ResumeLayout(False)
        Me.GroupControl18.PerformLayout()
        CType(Me.GroupControl17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl17.ResumeLayout(False)
        Me.GroupControl17.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxRateInfo As System.Windows.Forms.GroupBox
    Public WithEvents hsAdults As System.Windows.Forms.HScrollBar
    Friend WithEvents dtpDateIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBoxGuestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents txtTotalGarden As System.Windows.Forms.TextBox
    Friend WithEvents txtRateGarden As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalHall As System.Windows.Forms.TextBox
    Friend WithEvents txtRateHall As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestContactNo As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestCity As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestName As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestID As System.Windows.Forms.TextBox
    Public WithEvents hsKids As System.Windows.Forms.HScrollBar
    Friend WithEvents txtNoOfKids As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfAdults As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateOut As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbRoomNo As System.Windows.Forms.ComboBox
    Friend WithEvents txtOtherCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalRoomCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtRoomCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOfDays As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents txtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountPer As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxPer As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxPer As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Public WithEvents panel1 As System.Windows.Forms.Panel
    Public WithEvents Button14 As System.Windows.Forms.Button
    Public WithEvents btnUpdate_record As System.Windows.Forms.Button
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnNewRecord As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents txtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtIDNumber1 As System.Windows.Forms.TextBox
    Friend WithEvents txtContactNo1 As System.Windows.Forms.TextBox
    Friend WithEvents txtCity1 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestName1 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestID1 As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateTo_Garden As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateTo_Hall As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFrom_Hall As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFrom_Garden As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDaysGarden As System.Windows.Forms.TextBox
    Friend WithEvents txtDaysHall As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents btnGetData1 As System.Windows.Forms.Button
    Public WithEvents btnUpdate1 As System.Windows.Forms.Button
    Public WithEvents Label64 As System.Windows.Forms.Label
    Public WithEvents btnSave1 As System.Windows.Forms.Button
    Public WithEvents btnNew1 As System.Windows.Forms.Button
    Public WithEvents btnDelete1 As System.Windows.Forms.Button
    Friend WithEvents txtDiscount1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtBalance1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPaid1 As System.Windows.Forms.TextBox
    Friend WithEvents txtGrandTotal1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountPer1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxAmount1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxPer1 As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxAmount1 As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxPer1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherCharges1 As System.Windows.Forms.TextBox
    Public WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents Panel4 As System.Windows.Forms.Panel
    Public WithEvents btnPrint1 As System.Windows.Forms.Button
    Public WithEvents btnGetData2 As System.Windows.Forms.Button
    Public WithEvents btnUpdate2 As System.Windows.Forms.Button
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents btnSave2 As System.Windows.Forms.Button
    Public WithEvents btnNew2 As System.Windows.Forms.Button
    Public WithEvents btnDelete2 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNoOfDays1 As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotalCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents txtDiscount2 As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtBalance2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPaid2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGrandTotal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountPer2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxAmount2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLuxuryTaxPer2 As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxAmount2 As System.Windows.Forms.TextBox
    Friend WithEvents txtServiceTaxPer2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSubTotal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherCharges2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtIDNumber2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestContactNo2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestCity2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestName2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestID2 As System.Windows.Forms.TextBox
    Friend WithEvents txtID1 As System.Windows.Forms.TextBox
    Friend WithEvents txtID2 As System.Windows.Forms.TextBox
    Friend WithEvents txtID3 As System.Windows.Forms.TextBox
    Friend WithEvents cmbRoomNo1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtNotes1 As System.Windows.Forms.RichTextBox
    Friend WithEvents txtIDType As System.Windows.Forms.TextBox
    Friend WithEvents txtIDType1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIDType2 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtNotes2 As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Public WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtReservationNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Public WithEvents btnCheckedIN As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker6 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker5 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEducessTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtHEducessTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtEducessTax As System.Windows.Forms.TextBox
    Friend WithEvents txtHEduCessTax As System.Windows.Forms.TextBox
    Friend WithEvents txteducessTaxAmount1 As System.Windows.Forms.TextBox
    Friend WithEvents txtHeducessTaxAmount1 As System.Windows.Forms.TextBox
    Friend WithEvents txteducessTax1 As System.Windows.Forms.TextBox
    Friend WithEvents txtHeducessTax1 As System.Windows.Forms.TextBox
    Friend WithEvents txtHotelID As System.Windows.Forms.TextBox
    Friend WithEvents cmbCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents cmbCurrency2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents cmbCurrency1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txtCurrencyID As System.Windows.Forms.TextBox
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl7 As DevExpress.XtraEditors.GroupControl
    Private WithEvents guestRecordG As System.Windows.Forms.DataGridView
    Friend WithEvents Search As DevExpress.XtraEditors.SimpleButton
    Private WithEvents guestyonisearch As System.Windows.Forms.TextBox
    Friend WithEvents GroupControl8 As DevExpress.XtraEditors.GroupControl
    Private WithEvents reservationGR As System.Windows.Forms.DataGridView
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Searchreserved As System.Windows.Forms.TextBox
    Friend WithEvents GroupControl9 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl11 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl10 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl16 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl15 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl14 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl13 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents GroupControl12 As DevExpress.XtraEditors.GroupControl
    Private WithEvents guestR As System.Windows.Forms.DataGridView
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents guestnameyoni As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl21 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl20 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl19 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl18 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl17 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl22 As DevExpress.XtraEditors.GroupControl
    Private WithEvents hallandgarden As System.Windows.Forms.DataGridView
    Friend WithEvents hallsearch As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl24 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl23 As DevExpress.XtraEditors.GroupControl
    Private WithEvents guestrr As System.Windows.Forms.DataGridView
    Private WithEvents guests As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents hallorgarden As System.Windows.Forms.DataGridView
    Friend WithEvents searchallorgarden As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton8 As DevExpress.XtraEditors.SimpleButton

End Class
