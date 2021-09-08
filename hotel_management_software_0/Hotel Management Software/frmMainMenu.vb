
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo

Public Class frmMainMenu

    Dim Filename As String

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAboutBox1.ShowDialog()
    End Sub


    Private Sub NotePadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotePadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function HandleRegistry() As Boolean
            Dim firstRunDate As Date
            Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\HMSSoft", "Set", Nothing)
            firstRunDate = st
            If firstRunDate = Nothing Then
                firstRunDate = System.DateTime.Today.Date
                My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\HMSSoft", "Set", firstRunDate)
            ElseIf (Now - firstRunDate).Days > 15 Then
                Return False
            End If
            Return True
    End Function
    Private Sub main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim result As Boolean = HandleRegistry()
            'If result = False Then 'something went wrong
            '    MessageBox.Show("Trial expired" & vbCrLf & "for purchasing the full version of software contact us at +919827858191", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End
            'End If
            
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True

            If (lblUserType.Text = "Store Manager") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = True
                POSToolStripMenuItem.Enabled = True
                Me.DataEntryToolStripMenuItem.Enabled = True
                Me.TransactionToolStripMenuItem.Enabled = True
                Me.UsersToolStripMenuItem.Enabled = True
                SmsToolStripMenuItem1.Enabled = True
                Me.MasterEntryToolStripMenuItem.Enabled = True
                Me.LogsToolStripMenuItem1.Enabled = True
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = True
                Me.CheckInToolStripMenuItem.Enabled = True
                Me.GuestToolStripMenuItem1.Enabled = True
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = True
                Me.RestaurantBillingToolStripMenuItem.Enabled = True
                Me.CheckOutToolStripMenuItem.Enabled = True
                Me.EmployeeToolStripMenuItem1.Enabled = True
                Me.AdvanceEntryToolStripMenuItem1.Enabled = True
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = True
              
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True
            End If
            If (lblUserType.Text = "Finance Manager") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = True
                POSToolStripMenuItem.Enabled = False
                Me.DataEntryToolStripMenuItem.Enabled = True
                Me.TransactionToolStripMenuItem.Enabled = True
                Me.UsersToolStripMenuItem.Enabled = False
                SmsToolStripMenuItem1.Enabled = True
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = False
                Me.CheckInToolStripMenuItem.Enabled = False
                Me.GuestToolStripMenuItem1.Enabled = False
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = False
                Me.RestaurantBillingToolStripMenuItem.Enabled = False
                Me.CheckOutToolStripMenuItem.Enabled = False
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = True
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = True
               
                Me.ReportsToolStripMenuItem.Enabled = True
              
                RestaurantBillingToolStripMenuItem.Enabled = False
                LaundryBillingToolStripMenuItem1.Enabled = False
            End If
            If lblUserType.Text = "Receptionist" Then
                Me.SearchRecordsToolStripMenuItem.Enabled = False
                POSToolStripMenuItem.Enabled = True
                Me.DataEntryToolStripMenuItem.Enabled = False
                Me.TransactionToolStripMenuItem.Enabled = False
                Me.UsersToolStripMenuItem.Enabled = False
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = True
                Me.CheckInToolStripMenuItem.Enabled = True
                Me.GuestToolStripMenuItem1.Enabled = True
                Me.StockToolStripMenuItem1.Enabled = True
                SmsToolStripMenuItem1.Enabled = True
                Me.ReportsToolStripMenuItem.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = True
                Me.RestaurantBillingToolStripMenuItem.Enabled = True
                Me.CheckOutToolStripMenuItem.Enabled = True
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = False
                Me.AttendanceToolStripMenuItem2.Enabled = True
                Me.PaymentToolStripMenuItem1.Enabled = False
               
                Me.DatabaseToolStripMenuItem.Enabled = False
               
                Me.ReportsToolStripMenuItem.Enabled = True
               
                RestaurantBillingToolStripMenuItem.Enabled = True
                LaundryBillingToolStripMenuItem1.Enabled = True
            End If
            If (lblUserType.Text = "Store Keeper") Then
                Me.SearchRecordsToolStripMenuItem.Enabled = False
                POSToolStripMenuItem.Enabled = False
                Me.DataEntryToolStripMenuItem.Enabled = False
                Me.TransactionToolStripMenuItem.Enabled = False
                Me.UsersToolStripMenuItem.Enabled = False
                SmsToolStripMenuItem1.Enabled = False
                Me.MasterEntryToolStripMenuItem.Enabled = False
                Me.LogsToolStripMenuItem1.Enabled = False
                Me.ChatToolStripMenuItem1.Enabled = True
                Me.ReservationToolStripMenuItem.Enabled = False
                Me.CheckInToolStripMenuItem.Enabled = False
                Me.GuestToolStripMenuItem1.Enabled = False
                Me.StockToolStripMenuItem1.Enabled = True
                Me.OrderToolStripMenuItem.Enabled = False
                Me.RestaurantBillingToolStripMenuItem.Enabled = False
                Me.CheckOutToolStripMenuItem.Enabled = False
                Me.EmployeeToolStripMenuItem1.Enabled = False
                Me.AdvanceEntryToolStripMenuItem1.Enabled = False
                Me.AttendanceToolStripMenuItem2.Enabled = False
                Me.PaymentToolStripMenuItem1.Enabled = False
              
                RestaurantBillingToolStripMenuItem.Enabled = False
                LaundryBillingToolStripMenuItem1.Enabled = False
            End If
            Me.Refresh()
            GetData()
            lblDateTime.Text = Now
            lblUser.Text = frmLogin.UserID.Text
          
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SystemInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click

    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub AttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem.Click
        frmAttendance.lblUser.Text = lblUser.Text
        frmAttendance.Reset()
        frmAttendance.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Start()
        lblDateTime.Text = Now.ToString("dd/MM/yyyy hh:mm:ss tt")
    End Sub

    Private Sub AdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceToolStripMenuItem.Click
        
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        frmEmployeePayment.lblUser.Text = lblUser.Text
        frmEmployeePayment.Reset()
        frmEmployeePayment.ShowDialog()
    End Sub

    Private Sub RegistrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem.Click
        frmEmployeeRegistration.lblUser.Text = lblUser.Text
        frmEmployeeRegistration.Reset()
        frmEmployeeRegistration.ShowDialog()
    End Sub

    Private Sub EmployeePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem.Click
       
    End Sub


    Private Sub AttendanceToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem2.Click
        frmAttendance.lblUser.Text = lblUser.Text
        frmAttendance.Reset()
        frmAttendance.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem1.Click
       
    End Sub

    Private Sub PaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem1.Click
        frmEmployeePayment.lblUser.Text = lblUser.Text
        frmEmployeePayment.Reset()
        frmEmployeePayment.ShowDialog()
    End Sub
    Sub LogOut()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmCheckIN.Hide()
        frmCheckOut.Hide()
        frmReservation.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            If MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Backup()
                    LogOut()
                Else
                    LogOut()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub RoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomToolStripMenuItem.Click
        frmRoom.lblUser.Text = lblUser.Text
        frmRoom.Reset()
        frmRoom.ShowDialog()
    End Sub


    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click

        frmCheckIN.lblUser.Text = lblUser.Text
        frmCheckIN.Reset()
        frmCheckIN.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        frmCheckOut.lblUser.Text = lblUser.Text
        frmCheckOut.Reset()
        frmCheckOut.ShowDialog()
    End Sub


    Private Sub CheckInToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem1.Click
        frmCheckIN.lblUser.Text = lblUser.Text
        frmCheckIN.Reset()
        frmCheckIN.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem1.Click
        frmCheckOut.lblUser.Text = lblUser.Text
        frmCheckOut.Reset()
        frmCheckOut.ShowDialog()
    End Sub


    Private Sub RegistrationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem1.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub



    Private Sub OthersTransToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersTransToolStripMenuItem.Click
       
    End Sub

    Private Sub DishToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DishToolStripMenuItem.Click
        frmDish.lblUser.Text = lblUser.Text
        frmDish.Reset()
        frmDish.ShowDialog()
    End Sub

    Private Sub GuestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem.Click
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.Reset()
        frmGuest.ShowDialog()
    End Sub

    Private Sub OthersTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersTransactionToolStripMenuItem.Click

    End Sub

    Private Sub PurchasedInventoryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasedInventoryToolStripMenuItem1.Click
        
    End Sub

    Private Sub ExtraToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExtraToolStripMenuItem.Click
        frmChargeBed.lblUser.Text = lblUser.Text
        frmChargeBed.Reset()
        frmChargeBed.ShowDialog()
    End Sub

    Private Sub CheckInToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem2.Click
        frmCheckInRecord.Reset()
        frmCheckInRecord.ShowDialog()
    End Sub


    Private Sub ReservationToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationToolStripMenuItem2.Click
       
    End Sub

    Private Sub OrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem.Click
        frmOrder.lblUser.Text = lblUser.Text
        frmOrder.Reset()
        frmOrder.ShowDialog()
    End Sub

    Private Sub HallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallToolStripMenuItem.Click
        frmHall.lblUser.Text = lblUser.Text
        frmHall.Reset()
        frmHall.ShowDialog()
    End Sub

    Private Sub GardenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GardenToolStripMenuItem.Click
      
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
       
    End Sub


    Public Sub GetData()
       
    End Sub


    Private Sub OrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdersToolStripMenuItem.Click
        
    End Sub

    Private Sub GuestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem1.Click
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.Reset()
        frmGuest.ShowDialog()
    End Sub


    Private Sub RoomsAvailabilityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogsToolStripMenuItem1.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub LogsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogsToolStripMenuItem.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub HotelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HotelToolStripMenuItem.Click
        frmHotel.lblUser.Text = lblUser.Text
        frmHotel.Reset()
        frmHotel.ShowDialog()
    End Sub

    Private Sub RoomTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomTypeToolStripMenuItem.Click
     
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.lblSet.Text = ""
        frmCategory.Reset()
        frmCategory.ShowDialog()
    End Sub

    Private Sub TaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxToolStripMenuItem.Click
        frmTax.lblUser.Text = lblUser.Text
        frmTax.Reset()
        frmTax.ShowDialog()
    End Sub

    Private Sub ExtraPersonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraPersonToolStripMenuItem.Click
        frmExtraPerson.lblUser.Text = lblUser.Text
        frmExtraPerson.Reset()
        frmExtraPerson.ShowDialog()
    End Sub

    Private Sub LiquorCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorCategoryToolStripMenuItem.Click
       
    End Sub

    Private Sub LiquorQuantityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub LiquorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorToolStripMenuItem1.Click
        frmLiquidEntry.lblUser.Text = lblUser.Text
        frmLiquidEntry.Reset()
        frmLiquidEntry.ShowDialog()
    End Sub

    Private Sub LiquorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
     
    End Sub


    Private Sub HallOrGardenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallOrGardenToolStripMenuItem1.Click
        frmReservation_HallorGarden.lblUser.Text = lblUser.Text
        frmReservation_HallorGarden.Reset()
        frmReservation_HallorGarden.ShowDialog()
    End Sub

    Private Sub PurchasedInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasedInventoryToolStripMenuItem.Click
        frmPurchase.lblUser.Text = lblUser.Text
        frmPurchase.Reset()
        frmPurchase.ShowDialog()
    End Sub


    Private Sub RoomToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomToolStripMenuItem1.Click
        frmReservation.lblUser.Text = lblUser.Text
        frmReservation.Reset()
        frmReservation.Show()
    End Sub

    Private Sub GuestsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestsToolStripMenuItem.Click
      
    End Sub

    Private Sub IDTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDTypeToolStripMenuItem.Click
        frmIDType.lblUser.Text = lblUser.Text
        frmIDType.lblSet.Text = ""
        frmIDType.Reset()
        frmIDType.ShowDialog()
    End Sub

    Private Sub StockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem1.Click
      
    End Sub

    Private Sub LiquorStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorStockToolStripMenuItem.Click
       
    End Sub

    Private Sub CheckOutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem2.Click
        
    End Sub

    Private Sub HallOrGardenReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallOrGardenReservationToolStripMenuItem.Click
       
    End Sub

    Private Sub RestaurantBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem.Click
      
    End Sub

    Private Sub ReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReToolStripMenuItem.Click
       
    End Sub

    Private Sub RoomToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RoomToolStripMenuItem2.Click
        frmReservation.lblUser.Text = lblUser.Text
        frmReservation.Reset()
        frmReservation.ShowDialog()
    End Sub

    Private Sub HallOrGardenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HallOrGardenToolStripMenuItem.Click
        frmReservation_HallorGarden.lblUser.Text = lblUser.Text
        frmReservation_HallorGarden.Reset()
        frmReservation_HallorGarden.ShowDialog()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FoodToolStripMenuItem.Click
       
    End Sub

    Private Sub CheckInToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CheckInToolStripMenuItem3.Click
        frmCheckInReport.Reset()
        frmCheckInReport.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem3.Click
      
    End Sub

  

    Private Sub CheckOutWithIDToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CheckOutWithIDToolStripMenuItem.Click
        frmIdReport.Reset()
        frmIdReport.ShowDialog()
    End Sub

    Private Sub CheckInWithIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInWithIDToolStripMenuItem.Click
        
    End Sub
    Public Sub Reset()
       
        GetData()
    End Sub

    Private Sub EmployeeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeToolStripMenuItem1.Click
        frmEmployeeRegistration.lblUser.Text = lblUser.Text
        frmEmployeeRegistration.Reset()
        frmEmployeeRegistration.ShowDialog()
    End Sub

  

    Private Sub EmployeePayment2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeePayment2ToolStripMenuItem.Click
        frmEmployeePaymentRecord.Reset()
        frmEmployeePaymentRecord.ShowDialog()
    End Sub

    Private Sub EmployeeAttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAttendanceToolStripMenuItem.Click
        frmAttendanceEntryRecord.Reset()
        frmAttendanceEntryRecord.ShowDialog()
    End Sub

    Private Sub EmployeeAttendnace2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeeAttendnace2ToolStripMenuItem.Click
       
    End Sub
    Sub Backup()
        Try

            Dim destdir As String = "HMS_DB " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database HMS_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Backup()
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer2.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE hms_db SET Single_User WITH Rollback Immediate Restore database hms_db FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE hms_db SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
                GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RestaurantBillingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem1.Click
        frmRestaurantBillingReport.Reset()
        frmRestaurantBillingReport.ShowDialog()
    End Sub

    Private Sub RoomOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomOrdersToolStripMenuItem.Click
        frmRoomOrdersReport.Reset()
        frmRoomOrdersReport.ShowDialog()
    End Sub

    Private Sub GardenReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GardenReservationToolStripMenuItem.Click
        frmGardenReservationReport.Reset()
        frmGardenReservationReport.ShowDialog()
    End Sub

    Private Sub RoomReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomReservationToolStripMenuItem.Click
        frmRoomReservationReport.Reset()
        frmRoomReservationReport.ShowDialog()
    End Sub

   
  

    Private Sub HallReservationInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallReservationInvoiceToolStripMenuItem.Click
        frmHallReservationInvoice.Reset()
        frmHallReservationInvoice.ShowDialog()
    End Sub

   

    Private Sub RestaurantInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantInvoiceToolStripMenuItem.Click
        frmRestaurantBill.Reset()
        frmRestaurantBill.ShowDialog()
    End Sub

    Private Sub RoomOrderInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomOrderInvoiceToolStripMenuItem.Click
       
    End Sub

    Private Sub GuestToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem2.Click
        frmGuestReport.Reset()
        frmGuestReport.ShowDialog()
    End Sub

    Private Sub SalarySlipToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalarySlipToolStripMenuItem.Click
        frmSalaryslip.Reset()
        frmSalaryslip.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem2.Click
      
    End Sub

    Private Sub DeductionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeductionToolStripMenuItem.Click
       
    End Sub


    Private Sub frmMainMenu_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub


    Private Sub LaundryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       
    End Sub

    Private Sub LaundryBillingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundryBillingToolStripMenuItem1.Click
        frmLaundryBilling.lblUser.Text = lblUser.Text
        frmLaundryBilling.Reset()
        frmLaundryBilling.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LaundryBillingToolStripMenuItem2.Click
       
    End Sub

    Private Sub LaundaryBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundaryBillToolStripMenuItem.Click
        frmLaundryBill.Reset()
        frmLaundryBill.ShowDialog()
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("WinWord.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSPaintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSPaintToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("MSPaint.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableToolStripMenuItem.Click
      
    End Sub

    Private Sub OrderToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderToolStripMenuItem3.Click
        frmOrder.lblUser.Text = lblUser.Text
        frmOrder.Reset()
        frmOrder.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaundryBillingToolStripMenuItem3.Click
        frmLaundryBilling.lblUser.Text = lblUser.Text
        frmLaundryBilling.Reset()
        frmLaundryBilling.ShowDialog()
    End Sub


  

   

    Private Sub txtSearchByGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub




    Private Sub CurrentAdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrentAdvanceToolStripMenuItem.Click
        frmCurrentAdvanceList.Reset()
        frmCurrentAdvanceList.ShowDialog()
    End Sub

   

    Private Sub ExpensesMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpensesMasterToolStripMenuItem.Click
        Dim frm As New frmExpense
        frm.Reset()
        frm.lblUser.Text = lblUser.Text
        frm.ShowDialog()
    End Sub

    Private Sub ExpenseTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseTypeToolStripMenuItem.Click

      
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub ChangePasswordToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem1.Click
        '  frmChangePassword1.ShowDialog()
    End Sub

    Private Sub UserRightsManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserRightsManagementToolStripMenuItem.Click


    End Sub

    Private Sub BankMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankMasterToolStripMenuItem.Click
       
    End Sub

    Private Sub BranchMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchMasterToolStripMenuItem.Click
        
    End Sub

    Private Sub BankAccountsRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankAccountsRegisterToolStripMenuItem.Click
       
    End Sub

    Private Sub CurrencyMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CurrencyMasterToolStripMenuItem.Click
        Dim frm As New frmCurrency
        frm.lblUser.Text = lblUser.Text
        frm.Reset()
        frm.ShowDialog()
    End Sub

    Private Sub RoomToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles RoomToolStripMenuItem3.Click

    End Sub

    Private Sub DebtorsListToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles DebtorsListToolStripMenuItem1.Click

    End Sub

  

    Private Sub ToolStripMenuItem4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem4.Click
        frmLaundryBillingReport.Reset()
        frmLaundryBillingReport.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem5.Click
        frmKOTReport.Reset()
        frmKOTReport.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem6.Click

    End Sub

  

    Private Sub EducationTaxMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EducationTaxMasterToolStripMenuItem.Click
      
    End Sub

    Private Sub HotelPlanMasterToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HotelPlanMasterToolStripMenuItem.Click
        Dim frm As New frmPlan
        frm.lblUser.Text = lblUser.Text
        frm.Reset()
        frm.ShowDialog()
    End Sub

    Private Sub EmailSettingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmailSettingToolStripMenuItem.Click
       
    End Sub

    Private Sub DaybookToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DaybookToolStripMenuItem.Click
        frmGeneralDayBook.Reset()
        frmGeneralDayBook.ShowDialog()
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
       
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        frmTrialBalance.Reset()
        frmTrialBalance.ShowDialog()
    End Sub

    
    Private Sub ToolStripMenuItem9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem9.Click
        frmGuest.lblUser.Text = lblUser.Text
        frmGuest.Reset()
        frmGuest.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem7_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem10.Click
        frmContactMe.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem8.Click
        frmContactMe.ShowDialog()
    End Sub
End Class