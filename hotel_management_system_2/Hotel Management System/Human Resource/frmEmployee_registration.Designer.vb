<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmployee_registration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployee_registration))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.EmployeeID = New System.Windows.Forms.TextBox()
        Me.BasicWorkingTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EmployeeName = New System.Windows.Forms.TextBox()
        Me.Designation = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DateOfJoining = New System.Windows.Forms.DateTimePicker()
        Me.Salary = New System.Windows.Forms.TextBox()
        Me.Department = New System.Windows.Forms.ComboBox()
        Me.BloodGroup = New System.Windows.Forms.ComboBox()
        Me.Email = New System.Windows.Forms.TextBox()
        Me.MobileNo = New System.Windows.Forms.MaskedTextBox()
        Me.Address = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtEmployee = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.Delete = New System.Windows.Forms.Button()
        Me.Update_Record = New System.Windows.Forms.Button()
        Me.NewRecord = New System.Windows.Forms.Button()
        Me.Save = New System.Windows.Forms.Button()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(40, 10)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1189, 177)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = ">"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EmployeeID
        '
        Me.EmployeeID.Location = New System.Drawing.Point(145, 29)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.ReadOnly = True
        Me.EmployeeID.Size = New System.Drawing.Size(163, 20)
        Me.EmployeeID.TabIndex = 29
        '
        'BasicWorkingTime
        '
        Me.BasicWorkingTime.Location = New System.Drawing.Point(145, 316)
        Me.BasicWorkingTime.Mask = "00:00:00"
        Me.BasicWorkingTime.Name = "BasicWorkingTime"
        Me.BasicWorkingTime.Size = New System.Drawing.Size(81, 20)
        Me.BasicWorkingTime.TabIndex = 10
        Me.BasicWorkingTime.ValidatingType = GetType(Date)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(4, 319)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 15)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "* Basic Working Time"
        '
        'EmployeeName
        '
        Me.EmployeeName.Location = New System.Drawing.Point(145, 55)
        Me.EmployeeName.Name = "EmployeeName"
        Me.EmployeeName.Size = New System.Drawing.Size(185, 20)
        Me.EmployeeName.TabIndex = 1
        '
        'Designation
        '
        Me.Designation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Designation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Designation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Designation.FormattingEnabled = True
        Me.Designation.Location = New System.Drawing.Point(145, 228)
        Me.Designation.Name = "Designation"
        Me.Designation.Size = New System.Drawing.Size(185, 23)
        Me.Designation.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(4, 229)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 15)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "*Designation"
        '
        'DateOfJoining
        '
        Me.DateOfJoining.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateOfJoining.CustomFormat = "dd/MMM/yyyy"
        Me.DateOfJoining.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DateOfJoining.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateOfJoining.Location = New System.Drawing.Point(145, 257)
        Me.DateOfJoining.Name = "DateOfJoining"
        Me.DateOfJoining.Size = New System.Drawing.Size(137, 21)
        Me.DateOfJoining.TabIndex = 8
        '
        'Salary
        '
        Me.Salary.Location = New System.Drawing.Point(145, 287)
        Me.Salary.Multiline = True
        Me.Salary.Name = "Salary"
        Me.Salary.Size = New System.Drawing.Size(81, 23)
        Me.Salary.TabIndex = 9
        '
        'Department
        '
        Me.Department.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Department.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Department.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Department.FormattingEnabled = True
        Me.Department.Items.AddRange(New Object() {"Finance", "Accounting", "Manager", "Reception"})
        Me.Department.Location = New System.Drawing.Point(145, 199)
        Me.Department.Name = "Department"
        Me.Department.Size = New System.Drawing.Size(185, 23)
        Me.Department.TabIndex = 6
        '
        'BloodGroup
        '
        Me.BloodGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.BloodGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.BloodGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BloodGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.BloodGroup.FormattingEnabled = True
        Me.BloodGroup.Items.AddRange(New Object() {"", "Male", "Female", "Others"})
        Me.BloodGroup.Location = New System.Drawing.Point(145, 171)
        Me.BloodGroup.Name = "BloodGroup"
        Me.BloodGroup.Size = New System.Drawing.Size(71, 23)
        Me.BloodGroup.TabIndex = 5
        '
        'Email
        '
        Me.Email.Location = New System.Drawing.Point(145, 142)
        Me.Email.Multiline = True
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(197, 23)
        Me.Email.TabIndex = 4
        '
        'MobileNo
        '
        Me.MobileNo.Location = New System.Drawing.Point(145, 116)
        Me.MobileNo.Mask = "0000000000"
        Me.MobileNo.Name = "MobileNo"
        Me.MobileNo.Size = New System.Drawing.Size(137, 20)
        Me.MobileNo.TabIndex = 3
        '
        'Address
        '
        Me.Address.Location = New System.Drawing.Point(145, 81)
        Me.Address.Multiline = True
        Me.Address.Name = "Address"
        Me.Address.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Address.Size = New System.Drawing.Size(245, 29)
        Me.Address.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(4, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = " *E-Mail"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(4, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "*Employee ID"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(4, 292)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "* Basic Salary"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(4, 260)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "*Date of Joining"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(4, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "*Department"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(6, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "*Gender"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(4, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "*Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(4, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "*Contact No."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "*Employee Full Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Location = New System.Drawing.Point(708, 165)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(10, 10)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(645, 431)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 15)
        Me.Panel2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(163, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(220, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Employee Registration"
        '
        'GroupBox7
        '
        Me.GroupBox7.Location = New System.Drawing.Point(569, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(10, 18)
        Me.GroupBox7.TabIndex = 8
        Me.GroupBox7.TabStop = False
        '
        'txtEmployee
        '
        Me.txtEmployee.BackColor = System.Drawing.Color.DimGray
        Me.txtEmployee.ForeColor = System.Drawing.Color.White
        Me.txtEmployee.Location = New System.Drawing.Point(409, 0)
        Me.txtEmployee.Multiline = True
        Me.txtEmployee.Name = "txtEmployee"
        Me.txtEmployee.Size = New System.Drawing.Size(256, 22)
        Me.txtEmployee.TabIndex = 7
        Me.txtEmployee.Text = "Search Employee by name"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.PaleGoldenrod
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(2, 21)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(513, 296)
        Me.DataGridView1.TabIndex = 7
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(831, 81)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(10, 11)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker3.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(50, 51)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(137, 21)
        Me.DateTimePicker3.TabIndex = 12
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker4.CustomFormat = "dd/MMM/yyyy"
        Me.DateTimePicker4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(49, 26)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(137, 21)
        Me.DateTimePicker4.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(7, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 15)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "From"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(13, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(21, 15)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "To"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.Email)
        Me.GroupControl1.Controls.Add(Me.EmployeeID)
        Me.GroupControl1.Controls.Add(Me.Label1)
        Me.GroupControl1.Controls.Add(Me.BasicWorkingTime)
        Me.GroupControl1.Controls.Add(Me.Label3)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.Label4)
        Me.GroupControl1.Controls.Add(Me.EmployeeName)
        Me.GroupControl1.Controls.Add(Me.Label5)
        Me.GroupControl1.Controls.Add(Me.Designation)
        Me.GroupControl1.Controls.Add(Me.Label6)
        Me.GroupControl1.Controls.Add(Me.Label11)
        Me.GroupControl1.Controls.Add(Me.Label7)
        Me.GroupControl1.Controls.Add(Me.DateOfJoining)
        Me.GroupControl1.Controls.Add(Me.Label8)
        Me.GroupControl1.Controls.Add(Me.Salary)
        Me.GroupControl1.Controls.Add(Me.Label9)
        Me.GroupControl1.Controls.Add(Me.Department)
        Me.GroupControl1.Controls.Add(Me.Label10)
        Me.GroupControl1.Controls.Add(Me.BloodGroup)
        Me.GroupControl1.Controls.Add(Me.Address)
        Me.GroupControl1.Controls.Add(Me.MobileNo)
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(402, 345)
        Me.GroupControl1.TabIndex = 11
        Me.GroupControl1.Text = "Employee Information Details"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.Label14)
        Me.GroupControl2.Controls.Add(Me.DateTimePicker3)
        Me.GroupControl2.Controls.Add(Me.Label17)
        Me.GroupControl2.Controls.Add(Me.DateTimePicker4)
        Me.GroupControl2.Location = New System.Drawing.Point(930, 1)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(224, 82)
        Me.GroupControl2.TabIndex = 12
        Me.GroupControl2.Text = "Calender"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.Delete)
        Me.GroupControl3.Controls.Add(Me.Update_Record)
        Me.GroupControl3.Controls.Add(Me.NewRecord)
        Me.GroupControl3.Controls.Add(Me.Save)
        Me.GroupControl3.Location = New System.Drawing.Point(932, 84)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(222, 132)
        Me.GroupControl3.TabIndex = 12
        Me.GroupControl3.Text = "Action Button"
        '
        'Delete
        '
        Me.Delete.Enabled = False
        Me.Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Delete.Image = Global.Hotel_Management_System.My.Resources.Resources.Close_32x321
        Me.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Delete.Location = New System.Drawing.Point(116, 78)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(81, 37)
        Me.Delete.TabIndex = 3
        Me.Delete.Text = "Delete"
        Me.Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Delete.UseVisualStyleBackColor = True
        '
        'Update_Record
        '
        Me.Update_Record.Enabled = False
        Me.Update_Record.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Update_Record.Image = Global.Hotel_Management_System.My.Resources.Resources.Edit_32x32
        Me.Update_Record.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Update_Record.Location = New System.Drawing.Point(11, 78)
        Me.Update_Record.Name = "Update_Record"
        Me.Update_Record.Size = New System.Drawing.Size(81, 37)
        Me.Update_Record.TabIndex = 2
        Me.Update_Record.Text = "Update"
        Me.Update_Record.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Update_Record.UseVisualStyleBackColor = True
        '
        'NewRecord
        '
        Me.NewRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.NewRecord.Image = Global.Hotel_Management_System.My.Resources.Resources.Grid
        Me.NewRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NewRecord.Location = New System.Drawing.Point(12, 24)
        Me.NewRecord.Name = "NewRecord"
        Me.NewRecord.Size = New System.Drawing.Size(81, 37)
        Me.NewRecord.TabIndex = 0
        Me.NewRecord.Text = "Clear"
        Me.NewRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.NewRecord.UseVisualStyleBackColor = True
        '
        'Save
        '
        Me.Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Save.Image = Global.Hotel_Management_System.My.Resources.Resources.SaveAll_32x32
        Me.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Save.Location = New System.Drawing.Point(116, 24)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(81, 37)
        Me.Save.TabIndex = 1
        Me.Save.Text = "Save"
        Me.Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Save.UseVisualStyleBackColor = True
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.DataGridView1)
        Me.GroupControl5.Location = New System.Drawing.Point(409, 26)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(517, 319)
        Me.GroupControl5.TabIndex = 14
        Me.GroupControl5.Text = "Employee Registration Record"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.SimpleButton2)
        Me.GroupControl4.Controls.Add(Me.Button10)
        Me.GroupControl4.Controls.Add(Me.Button6)
        Me.GroupControl4.Location = New System.Drawing.Point(932, 219)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(224, 124)
        Me.GroupControl4.TabIndex = 16
        Me.GroupControl4.Text = "Action Button"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(64, 75)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 17
        Me.SimpleButton2.Text = "Close"
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Button10.Image = Global.Hotel_Management_System.My.Resources.Resources.Grid
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(5, 38)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(94, 27)
        Me.Button10.TabIndex = 1
        Me.Button10.Text = "Clear"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Button6.Image = Global.Hotel_Management_System.My.Resources.Resources.Export_32x32
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(104, 34)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(109, 35)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Export Excel"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = Global.Hotel_Management_System.My.Resources.Resources.Find_32x32
        Me.SimpleButton1.Location = New System.Drawing.Point(671, 1)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 15
        Me.SimpleButton1.Text = "Search"
        '
        'frmEmployee_registration
        '
        Me.AcceptButton = Me.Save
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1157, 346)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txtEmployee)
        Me.Controls.Add(Me.GroupControl5)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmEmployee_registration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Registration"
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GroupControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl1.ResumeLayout(false)
        Me.GroupControl1.PerformLayout
        CType(Me.GroupControl2,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl2.ResumeLayout(false)
        Me.GroupControl2.PerformLayout
        CType(Me.GroupControl3,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl3.ResumeLayout(false)
        CType(Me.GroupControl5,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl5.ResumeLayout(false)
        CType(Me.GroupControl4,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupControl4.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Delete As System.Windows.Forms.Button
    Friend WithEvents Update_Record As System.Windows.Forms.Button
    Friend WithEvents Save As System.Windows.Forms.Button
    Friend WithEvents NewRecord As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Salary As System.Windows.Forms.TextBox
    Friend WithEvents Department As System.Windows.Forms.ComboBox
    Friend WithEvents BloodGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Email As System.Windows.Forms.TextBox
    Friend WithEvents MobileNo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Address As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DateOfJoining As System.Windows.Forms.DateTimePicker
    Friend WithEvents Designation As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents BasicWorkingTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents EmployeeID As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEmployee As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
