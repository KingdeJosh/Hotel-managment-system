Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports System.IO

Public Class frmMainMenu




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


    Private Sub main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If lblUserType.Text = "User" Then
            Me.SearchRecordsToolStripMenuItem.Enabled = False
            Me.DataEntryToolStripMenuItem.Enabled = False
            Me.TransactionToolStripMenuItem.Enabled = False
            Me.UsersToolStripMenuItem.Enabled = False
            Me.MasterEntryToolStripMenuItem.Enabled = False
            Me.LogsToolStripMenuItem1.Enabled = False
            Me.ChatToolStripMenuItem1.Enabled = True
            Me.ReservationToolStripMenuItem.Enabled = False
            Me.CheckInToolStripMenuItem.Enabled = False
            Me.GuestToolStripMenuItem1.Enabled = False
            Me.StockToolStripMenuItem1.Enabled = False
            Me.OrderToolStripMenuItem.Enabled = True
            Me.RestaurantBillingToolStripMenuItem.Enabled = True
            Me.CheckOutToolStripMenuItem.Enabled = False
            Me.EmployeeToolStripMenuItem1.Enabled = False
            Me.AdvanceEntryToolStripMenuItem1.Enabled = False
            Me.AttendanceToolStripMenuItem2.Enabled = False
            Me.PaymentToolStripMenuItem1.Enabled = False
            Me.dgw.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.DataGridView2.Enabled = False
            Me.DatabaseToolStripMenuItem.Enabled = False
            Me.btnSearch.Enabled = False
            Me.btnReset.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.GroupBox1.Enabled = False
            Me.ReportsToolStripMenuItem.Enabled = False
        End If
        If (lblUserType.Text = "Admin") Then
            Me.SearchRecordsToolStripMenuItem.Enabled = True
            Me.DataEntryToolStripMenuItem.Enabled = True
            Me.TransactionToolStripMenuItem.Enabled = True
            Me.UsersToolStripMenuItem.Enabled = True
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
            Me.dgw.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.DataGridView2.Enabled = True
            Me.DatabaseToolStripMenuItem.Enabled = True
            Me.btnSearch.Enabled = True
            Me.btnReset.Enabled = True
            Me.ReportsToolStripMenuItem.Enabled = True
            Me.GroupBox2.Enabled = True
            Me.GroupBox1.Enabled = True

        End If
        If lblUserType.Text = "Receptionist" Then
            Me.SearchRecordsToolStripMenuItem.Enabled = False
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
            Me.ReportsToolStripMenuItem.Enabled = True
            Me.OrderToolStripMenuItem.Enabled = True
            Me.RestaurantBillingToolStripMenuItem.Enabled = True
            Me.CheckOutToolStripMenuItem.Enabled = True
            Me.EmployeeToolStripMenuItem1.Enabled = False
            Me.AdvanceEntryToolStripMenuItem1.Enabled = False
            Me.AttendanceToolStripMenuItem2.Enabled = True
            Me.PaymentToolStripMenuItem1.Enabled = False
            Me.dgw.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.DataGridView2.Enabled = True
            Me.DatabaseToolStripMenuItem.Enabled = False
            Me.btnSearch.Enabled = True
            Me.btnReset.Enabled = True
            Me.ReportsToolStripMenuItem.Enabled = False
            Me.GroupBox2.Enabled = True
            Me.GroupBox1.Enabled = True
        End If
        Me.Refresh()
        GetData()
        ToolStripStatusLabel4.Text = Now
        lblUser.Text = frmLogin.UserID.Text
        DataGridView1.ClearSelection()
        DataGridView2.ClearSelection()
    End Sub

    Private Sub SystemInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.Show()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        frmEmployeesRecord.Show()
    End Sub


    Private Sub AttendanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem.Click
        frmAttendance.lblUser.Text = lblUser.Text
        frmAttendance.Reset()
        frmAttendance.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Start()
        ToolStripStatusLabel4.Text = Now
    End Sub

    Private Sub AdvanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceToolStripMenuItem.Click
        frmAdvanceEntry.lblUser.Text = lblUser.Text
        frmAdvanceEntry.Reset()
        frmAdvanceEntry.ShowDialog()
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
        frmEmployeePaymentRecord1.Reset()
        frmEmployeePaymentRecord1.ShowDialog()
    End Sub


    Private Sub AttendanceToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem2.Click
        frmAttendance.lblUser.Text = lblUser.Text
        frmAttendance.Reset()
        frmAttendance.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem1.Click
        frmAdvanceEntry.lblUser.Text = lblUser.Text
        frmAdvanceEntry.Reset()
        frmAdvanceEntry.ShowDialog()
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
        frmServer.Hide()
        frmClient.Hide()
        frmCheckIN_Room.Hide()
        frmCheckOut_Room.Hide()
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
        Me.Hide()
        frmCheckIN_Room.lblUser.Text = lblUser.Text
        frmCheckIN_Room.Reset()
        frmCheckIN_Room.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem.Click
        Me.Hide()
        frmCheckOut_Room.lblUser.Text = lblUser.Text
        frmCheckOut_Room.Reset()
        frmCheckOut_Room.ShowDialog()
    End Sub


    Private Sub CheckInToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem1.Click
        Me.Hide()
        frmCheckIN_Room.lblUser.Text = lblUser.Text
        frmCheckIN_Room.Reset()
        frmCheckIN_Room.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem1.Click
        Me.Hide()
        frmCheckOut_Room.lblUser.Text = lblUser.Text
        frmCheckOut_Room.Reset()
        frmCheckOut_Room.ShowDialog()
    End Sub


    Private Sub RegistrationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem1.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub



    Private Sub OthersTransToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersTransToolStripMenuItem.Click
        frmTransaction.lblUser.Text = lblUser.Text
        frmTransaction.Reset()
        frmTransaction.ShowDialog()
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
        frmTransactionRecord.Reset()
        frmTransactionRecord.ShowDialog()
    End Sub

    Private Sub PurchasedInventoryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasedInventoryToolStripMenuItem1.Click
        frmPurchasedInventoryRecord.Reset()
        frmPurchasedInventoryRecord.ShowDialog()
    End Sub

    Private Sub ExtraToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExtraToolStripMenuItem.Click
        frmExtraBed.lblUser.Text = lblUser.Text
        frmExtraBed.Reset()
        frmExtraBed.ShowDialog()
    End Sub

    Private Sub CheckInToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem2.Click
        frmCheckInRecord.Reset()
        frmCheckInRecord.ShowDialog()
    End Sub


    Private Sub ReservationToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationToolStripMenuItem2.Click
        frmReservationRecord1.Reset()
        frmReservationRecord1.ShowDialog()
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
        frmGarden.lblUser.Text = lblUser.Text
        frmGarden.Reset()
        frmGarden.ShowDialog()
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        frmStock.lblUser.Text = lblUser.Text
        frmStock.Reset()
        frmStock.ShowDialog()
    End Sub


    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_ID),RTRIM(Guest.GuestID), RTRIM(Room.RoomNo),RTRIM(GuestName),DateIN,DateOut from Guest,Room,Checkin_Room where Guest.ID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Status='Check In' Order by DateIN"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToDateTime(r.Cells(5).Value) <= System.DateTime.Now.Date Then
                    r.DefaultCellStyle.BackColor = Color.Red
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "Select RTRIM(Reservation.ID),RTRIM(Guest.GuestID),RTRIM(Room.RoomNo),RTRIM(GuestName),DateIN,DateOut from Guest,Room,Reservation where Guest.ID=Reservation.GuestID and Room.RoomNo=Reservation.RoomNo and Status='Reserved' Order by DateIN"
            cmd = New SqlCommand(sql1, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If Convert.ToDateTime(r.Cells(5).Value) <= System.DateTime.Now.Date Then
                    r.DefaultCellStyle.BackColor = Color.Red
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            con.Close()
            DataGridView1.ClearSelection()
            DataGridView2.ClearSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub OrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdersToolStripMenuItem.Click
        frmOrdersRecord1.Reset()
        frmOrdersRecord1.ShowDialog()
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
        frmRoomType.lblUser.Text = lblUser.Text
        frmRoomType.Reset()
        frmRoomType.ShowDialog()
    End Sub

    Private Sub CategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoryToolStripMenuItem.Click
        frmCategory.lblUser.Text = lblUser.Text
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
        frmLiquorCategory.lblUser.Text = lblUser.Text
        frmLiquorCategory.Reset()
        frmLiquorCategory.ShowDialog()
    End Sub

    Private Sub LiquorQuantityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorQuantityToolStripMenuItem.Click
        frmLiquorQuantity.lblUser.Text = lblUser.Text
        frmLiquorQuantity.Reset()
        frmLiquorQuantity.ShowDialog()
    End Sub

    Private Sub LiquorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorToolStripMenuItem1.Click
        frmLiquor.lblUser.Text = lblUser.Text
        frmLiquor.Reset()
        frmLiquor.ShowDialog()
    End Sub

    Private Sub LiquorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorToolStripMenuItem.Click
        frmLiquorRate.lblUser.Text = lblUser.Text
        frmLiquorRate.Reset()
        frmLiquorRate.ShowDialog()
    End Sub


    Private Sub HallOrGardenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallOrGardenToolStripMenuItem1.Click
        frmReservation_HallorGarden.lblUser.Text = lblUser.Text
        frmReservation_HallorGarden.Reset()
        frmReservation_HallorGarden.ShowDialog()
    End Sub

    Private Sub PurchasedInventoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasedInventoryToolStripMenuItem.Click
        frmPurchasedInventory.lblUser.Text = lblUser.Text
        frmPurchasedInventory.Reset()
        frmPurchasedInventory.ShowDialog()
    End Sub


    Private Sub RoomToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RoomToolStripMenuItem1.Click
        Me.Hide()
        frmReservation.lblUser.Text = lblUser.Text
        frmReservation.Reset()
        frmReservation.Show()
    End Sub

    Private Sub GuestsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestsToolStripMenuItem.Click
        frmGuestRecord1.lblSet.Text = "Reservation_HallorGarden"
        frmGuestRecord1.Reset()
        frmGuestRecord1.ShowDialog()
    End Sub

    Private Sub IDTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IDTypeToolStripMenuItem.Click
        frmIDType.lblUser.Text = lblUser.Text
        frmIDType.Reset()
        frmIDType.ShowDialog()
    End Sub

    Private Sub StockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem1.Click
        frmStock.lblUser.Text = lblUser.Text
        frmStock.Reset()
        frmStock.ShowDialog()
    End Sub

    Private Sub LiquorStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LiquorStockToolStripMenuItem.Click
        frmStockRecord.Reset()
        frmStockRecord.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem2.Click
        frmCheckOutRecord.Reset()
        frmCheckOutRecord.ShowDialog()
    End Sub

    Private Sub HallOrGardenReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HallOrGardenReservationToolStripMenuItem.Click
        frmReservationRecord_HallOrGarden.Reset()
        frmReservationRecord_HallOrGarden.ShowDialog()
    End Sub

    Private Sub RestaurantBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem.Click
        frmRestaurantBilling.lblUser.Text = lblUser.Text
        frmRestaurantBilling.Reset()
        frmRestaurantBilling.ShowDialog()
    End Sub

    Private Sub ReToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReToolStripMenuItem.Click
        frmRestaurantBillingRecord1.Reset()
        frmRestaurantBillingRecord1.ShowDialog()
    End Sub

    Private Sub RoomToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RoomToolStripMenuItem2.Click
        Me.Hide()
        frmReservation.lblUser.Text = lblUser.Text
        frmReservation.Reset()
        frmReservation.ShowDialog()
    End Sub

    Private Sub HallOrGardenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HallOrGardenToolStripMenuItem.Click
        frmReservation_HallorGarden.lblUser.Text = lblUser.Text
        frmReservation_HallorGarden.Reset()
        frmReservation_HallorGarden.ShowDialog()
    End Sub

    Private Sub FoodToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FoodToolStripMenuItem.Click
        frmOthersRecord.Reset()
        frmOthersRecord.ShowDialog()
    End Sub

    Private Sub CheckInToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles CheckInToolStripMenuItem3.Click
        frmCheckInReport.Reset()
        frmCheckInReport.ShowDialog()
    End Sub

    Private Sub CheckOutToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutToolStripMenuItem3.Click
        frmCheckoutReport.Reset()
        frmCheckoutReport.ShowDialog()
    End Sub

    Private Sub ServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServerToolStripMenuItem.Click
        frmServer.Show()
    End Sub

    Private Sub ClientToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientToolStripMenuItem.Click
        frmClient.Show()
    End Sub

    Private Sub ServerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ServerToolStripMenuItem1.Click
        frmServer.Show()
    End Sub

    Private Sub ClientToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClientToolStripMenuItem1.Click
        frmClient.Show()
    End Sub

    Private Sub CheckOutWithIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckOutWithIDToolStripMenuItem.Click
        frmCheckout_IdReport.Reset()
        frmCheckout_IdReport.ShowDialog()
    End Sub

    Private Sub CheckInWithIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInWithIDToolStripMenuItem.Click
        frmCheckInWithIdReport.Reset()
        frmCheckInWithIdReport.ShowDialog()
    End Sub
    Public Sub Reset()
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        txtSearchByGuestName.Text = ""
        TextBox1.Text = ""
        GetData()
    End Sub
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        dtpDateIn.Text = Today
        dtpDateOut.Text = Today
        RadioButton3.Checked = False
        RadioButton4.Checked = False
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try
            dgw.Enabled = True
            If dtpDateIn.Value.Date = dtpDateOut.Value.Date Then
                MessageBox.Show("Date Out can not be same as Date IN", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                dtpDateOut.Text = Today
                Exit Sub
            End If
            If dtpDateOut.Value.Date < dtpDateIn.Value.Date Then
                MessageBox.Show("Selected date out must be greater than date in", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                dtpDateOut.Focus()
                dtpDateOut.Text = Today
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT RTRIM(R.RoomNo),RTRIM(R.RoomType),RTRIM(R.RoomCharges) FROM Room as R Inner Join Room as S on R.RoomNo=S.RoomNo where R.RoomNo not in (Select RoomNo from Temp_Reservation where Status ='Reserved' and Temp_Reservation.DateIn < @d1 AND Temp_Reservation.DateOut > @d2 ) and S.RoomNo not in (SELECT RoomNo FROM Checkin_Room where Status = 'Check In' and Checkin_Room.DateIn < @d1 AND Checkin_Room.DateOut > @d2) "
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", dtpDateOut.Value.Date)
            cmd.Parameters.AddWithValue("@d2", dtpDateIn.Value.Date)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If RadioButton3.Checked = False And RadioButton4.Checked = False Then
                    MessageBox.Show("Please select operation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If RadioButton3.Checked = True Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmCheckIN_Room.Reset()
                    frmCheckIN_Room.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmCheckIN_Room.lblUser.Text = lblUser.Text
                    frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(0).Value.ToString().Trim
                    frmCheckIN_Room.dtpDateIn.Text = dtpDateIn.Value.Date
                    frmCheckIN_Room.dtpDateOut.Text = dtpDateOut.Value.Date
                    dgw.Rows.Clear()
                    dtpDateIn.Text = Today
                    dtpDateOut.Text = Today
                    dgw.Enabled = False
                End If
                If RadioButton4.Checked = True Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmReservation.Reset()
                    frmReservation.Show()
                    frmReservation.lblUser.Text = lblUser.Text
                    frmReservation.auto()
                    frmReservation.cmbRoomNo.Text = dr.Cells(0).Value.ToString().Trim
                    frmReservation.dtpDateIN.Text = dtpDateIn.Value.Date
                    frmReservation.dtpDateOut.Text = dtpDateOut.Value.Date
                    dgw.Rows.Clear()
                    dtpDateIn.Text = Today
                    dtpDateOut.Text = Today
                    dgw.Enabled = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                If RadioButton1.Checked = False And RadioButton2.Checked = False Then
                    MessageBox.Show("Please select operation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If RadioButton1.Checked = True Then
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    frmCheckIN_Room.lblUser.Text = lblUser.Text
                    Me.Hide()
                    frmCheckIN_Room.Reset()
                    frmCheckIN_Room.Show()
                    frmCheckIN_Room.btnSave.Enabled = False
                    frmCheckIN_Room.btnUpdate.Enabled = True
                    frmCheckIN_Room.btnDelete.Enabled = True
                    frmCheckIN_Room.btnRoomAvailability.Enabled = False
                    frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                    frmCheckIN_Room.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql2 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Room_OrderInfo where Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & ""
                    cmd = New SqlCommand(sql2, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtRoomOrderCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtRoomOrderCharges.Text = 0
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql3 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Laundry_BillInfo where Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & ""
                    cmd = New SqlCommand(sql3, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtLaundryCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtLaundryCharges.Text = 0
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "SELECT ID, Address, City, ContactNo, Gender, Occupation, Religion, IDType, IDNumber from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    cmd = New SqlCommand(sql1, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If (rdr.Read() = True) Then
                        frmCheckIN_Room.txtID.Text = rdr.GetValue(0)
                        frmCheckIN_Room.txtGuestAddress.Text = rdr.GetValue(1)
                        frmCheckIN_Room.txtGuestCity.Text = rdr.GetValue(2)
                        frmCheckIN_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                        frmCheckIN_Room.txtGender.Text = rdr.GetValue(4)
                        frmCheckIN_Room.txtOccupation.Text = rdr.GetValue(5)
                        frmCheckIN_Room.txtReligion.Text = rdr.GetString(6)
                        frmCheckIN_Room.txtIDType.Text = rdr.GetValue(7)
                        frmCheckIN_Room.txtIDNumber.Text = rdr.GetValue(8)
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(TaxPaidRate) as [Tax Paid Rate], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.RoomNo=CheckIn_Room.RoomNo and Checkin_Room.Cin_ID=" & dr.Cells(0).Value & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If (rdr.Read() = True) Then
                        frmCheckIN_Room.txtCheckInID.Text = rdr.GetValue(0)
                        frmCheckIN_Room.txtGuestID.Text = rdr.GetValue(1)
                        frmCheckIN_Room.txtGuestName.Text = rdr.GetValue(2)

                        frmCheckIN_Room.txtRoomCharges.Text = rdr.GetValue(4)
                        frmCheckIN_Room.dtpDateIn.Text = rdr.GetValue(5)
                        frmCheckIN_Room.dtpDateOut.Text = rdr.GetValue(6)
                        frmCheckIN_Room.txtNoOfDays.Text = rdr.GetValue(7)
                        frmCheckIN_Room.txtNoOfMales.Text = rdr.GetValue(8)
                        frmCheckIN_Room.txtNoOfFemales.Text = rdr.GetValue(9)
                        frmCheckIN_Room.txtNoOfKids.Text = rdr.GetValue(10)
                        frmCheckIN_Room.txtNoOfExtraBed.Text = rdr.GetValue(11)
                        frmCheckIN_Room.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                        frmCheckIN_Room.txtRoomOrderCharges.Text = rdr.GetValue(13) + Val(txtRoomOrderCharges.Text)
                        frmCheckIN_Room.txtExtraPersonCharges.Text = rdr.GetValue(14)
                        frmCheckIN_Room.txtTotalRoomCharges.Text = rdr.GetValue(15)
                        frmCheckIN_Room.txtExtraBedCharges.Text = rdr.GetValue(16)
                        frmCheckIN_Room.txtLaundryCharges.Text = rdr.GetValue(17) + Val(txtLaundryCharges.Text)
                        frmCheckIN_Room.txtDiscountPer.Text = rdr.GetValue(18)
                        frmCheckIN_Room.txtDiscountAmount.Text = rdr.GetValue(19)
                        frmCheckIN_Room.txtServiceTaxPer.Text = rdr.GetValue(20)
                        frmCheckIN_Room.txtServiceTaxAmount.Text = rdr.GetValue(21)
                        frmCheckIN_Room.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                        frmCheckIN_Room.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                        frmCheckIN_Room.txtSubTotal.Text = rdr.GetValue(24)
                        frmCheckIN_Room.txtGrandTotal.Text = rdr.GetValue(25)
                        frmCheckIN_Room.txtTotalPaid.Text = rdr.GetValue(26)
                        frmCheckIN_Room.txtBalance.Text = rdr.GetValue(27)
                        If rdr.GetValue(28) = "Yes" Then
                            frmCheckIN_Room.CheckBox1.Checked = True
                        End If
                        If rdr.GetValue(28) = "No" Then
                            frmCheckIN_Room.CheckBox1.Checked = False
                        End If
                        frmCheckIN_Room.txtNotes.Text = rdr.GetValue(29)

                    End If
                    If frmCheckIN_Room.CheckBox1.Checked = False Then
                        frmCheckIN_Room.Compute()
                    End If
                    If frmCheckIN_Room.CheckBox1.Checked = True Then
                        frmCheckIN_Room.Compute1()
                    End If
                    con.Close()
                End If
                If RadioButton2.Checked = True Then
                    Me.Hide()
                    frmCheckOut_Room.Reset()
                    frmCheckOut_Room.Show()
                    frmCheckOut_Room.lblUser.Text = lblUser.Text
                    Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql2 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Room_OrderInfo where Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & ""
                    cmd = New SqlCommand(sql2, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtRoomOrderCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtRoomOrderCharges.Text = 0
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql3 As String = "SELECT sum(PaymentDue) FROM CheckIN_Room,Laundry_BillInfo where Laundry_BillInfo.CheckInId=Checkin_Room.Cin_ID and Checkin_Room.Cin_ID= " & dr.Cells(0).Value.ToString() & ""
                    cmd = New SqlCommand(sql3, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If rdr.Read() Then
                        txtLaundryCharges.Text = rdr.GetValue(0).ToString()
                    Else
                        txtLaundryCharges.Text = 0
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "SELECT ID, Address, City, ContactNo, Gender, Occupation, Religion, IDType, IDNumber from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                    cmd = New SqlCommand(sql1, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If (rdr.Read() = True) Then
                        frmCheckOut_Room.txtID.Text = rdr.GetValue(0)
                        frmCheckOut_Room.txtGuestAddress.Text = rdr.GetValue(1)
                        frmCheckOut_Room.txtGuestCity.Text = rdr.GetValue(2)
                        frmCheckOut_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                        frmCheckOut_Room.txtGender.Text = rdr.GetValue(4)
                        frmCheckOut_Room.txtOccupation.Text = rdr.GetValue(5)
                        frmCheckOut_Room.txtReligion.Text = rdr.GetString(6)
                        frmCheckOut_Room.txtIDType.Text = rdr.GetValue(7)
                        frmCheckOut_Room.txtIDNumber.Text = rdr.GetValue(8)
                    End If
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_Id) as [Check In ID], RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(Room. RoomNo) as [Room No.], RTRIM(CheckIN_Room.RoomCharges) as [Room Charges], Convert(DateTime,DateIN,103) as [Date IN], Convert(DateTime,DateOUT,103) as [Date Out], RTRIM(NoOfDays) as [No. Of Days], RTRIM(NoOfMales) as [No. Of Males], RTRIM(NoOfFemales) as [No. Of Females], RTRIM(NoOfKids) as [No. Of Kids], RTRIM(NoOfExtraBed) as [No. Of Extra Bed], RTRIM(NoOfExtraPerson) as [No. Of Extra Person], RTRIM(RoomOrderCharges) as [Room Order Charges], RTRIM(ExtraPersonCharges) as [Extra Person Charges], RTRIM(TotalRoomCharges) as [Total Room Charges],RTRIM(ExtraBedCharges) as [Extra Bed Charges], RTRIM(OtherCharges) as [Laundry Charges], RTRIM(DiscountPer) as [Discount %], RTRIM(DiscountAmount) as [Discount Amount], RTRIM(STPer) as [ST %], RTRIM(STAmount) as [ST Amount], RTRIM(LuxuryTaxPer) as [Luxury Tax Per],RTRIM( LuxuryTaxAmount) as [Luxury Tax Amount], RTRIM(SubTotal) as [Sub Total], RTRIM(GrandTotal) as [Grand Total], RTRIM(TotalPaid) as [Total Paid], RTRIM(Balance) as [Balance], RTRIM(TaxPaidRate) as [Tax Paid Rate], RTRIM(CheckIn_Room.Notes) as [Notes] from Guest,Room,CheckIN_Room where Guest.ID=CheckIN_Room.GuestID and Status='Check In' and Room.RoomNo=CheckIn_Room.RoomNo and Checkin_Room.Cin_ID=" & dr.Cells(0).Value & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If (rdr.Read() = True) Then
                        frmCheckOut_Room.txtCheckInID.Text = rdr.GetValue(0)
                        frmCheckOut_Room.txtGuestID.Text = rdr.GetValue(1)
                        frmCheckOut_Room.txtGuestName.Text = rdr.GetValue(2)
                        frmCheckOut_Room.txtRoomNo.Text = rdr.GetValue(3)
                        frmCheckOut_Room.txtRoomCharges.Text = rdr.GetValue(4)
                        frmCheckOut_Room.dtpDateIn.Text = rdr.GetValue(5)
                        frmCheckOut_Room.dtpDateOut.Text = rdr.GetValue(6)
                        frmCheckOut_Room.txtNoOfDays.Text = rdr.GetValue(7)
                        frmCheckOut_Room.txtNoOfMales.Text = rdr.GetValue(8)
                        frmCheckOut_Room.txtNoOfFemales.Text = rdr.GetValue(9)
                        frmCheckOut_Room.txtNoOfKids.Text = rdr.GetValue(10)
                        frmCheckOut_Room.txtNoOfExtraBed.Text = rdr.GetValue(11)
                        frmCheckOut_Room.txtNoOfExtraPerson.Text = rdr.GetValue(12)
                        frmCheckOut_Room.txtRoomOrderCharges.Text = rdr.GetValue(13) + Val(txtRoomOrderCharges.Text)
                        frmCheckOut_Room.txtExtraPersonCharges.Text = rdr.GetValue(14)
                        frmCheckOut_Room.txtTotalRoomCharges.Text = rdr.GetValue(15)
                        frmCheckOut_Room.txtExtraBedCharges.Text = rdr.GetValue(16)
                        frmCheckOut_Room.txtLaundryCharges.Text = rdr.GetValue(17) + Val(txtLaundryCharges.Text)
                        frmCheckOut_Room.txtDiscountPer.Text = rdr.GetValue(18)
                        frmCheckOut_Room.txtDiscountAmount.Text = rdr.GetValue(19)
                        frmCheckOut_Room.txtServiceTaxPer.Text = rdr.GetValue(20)
                        frmCheckOut_Room.txtServiceTaxAmount.Text = rdr.GetValue(21)
                        frmCheckOut_Room.txtLuxuryTaxPer.Text = rdr.GetValue(22)
                        frmCheckOut_Room.txtLuxuryTaxAmount.Text = rdr.GetValue(23)
                        frmCheckOut_Room.txtSubTotal.Text = rdr.GetValue(24)
                        frmCheckOut_Room.txtGrandTotal.Text = rdr.GetValue(25)
                        frmCheckOut_Room.txtTotalPaid.Text = rdr.GetValue(26)
                        frmCheckOut_Room.txtBalance.Text = rdr.GetValue(27)
                        If rdr.GetValue(28) = "Yes" Then
                            frmCheckOut_Room.CheckBox1.Checked = True
                        End If
                        If rdr.GetValue(28) = "No" Then
                            frmCheckOut_Room.CheckBox1.Checked = False
                        End If
                        frmCheckOut_Room.dtpDateIn.Enabled = False
                        frmCheckOut_Room.dtpDateOut.Enabled = False
                    End If
                    frmCheckOut_Room.Fill()
                    con.Close()
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub DataGridView2_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView2.RowHeaderMouseClick
        Try
            If DataGridView2.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
                Me.Hide()
                frmCheckIN_Room.Reset()
                frmCheckIN_Room.Show()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql1 As String = "SELECT ID, Address, City, ContactNo, Gender, Occupation, Religion, IDType, IDNumber from Guest WHERE GuestId='" & dr.Cells(1).Value & "'"
                cmd = New SqlCommand(sql1, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    frmCheckIN_Room.txtID.Text = rdr.GetValue(0)
                    frmCheckIN_Room.txtGuestAddress.Text = rdr.GetValue(1)
                    frmCheckIN_Room.txtGuestCity.Text = rdr.GetValue(2)
                    frmCheckIN_Room.txtGuestContactNo.Text = rdr.GetValue(3)
                    frmCheckIN_Room.txtGender.Text = rdr.GetValue(4)
                    frmCheckIN_Room.txtOccupation.Text = rdr.GetValue(5)
                    frmCheckIN_Room.txtReligion.Text = rdr.GetString(6)
                    frmCheckIN_Room.txtIDType.Text = rdr.GetValue(7)
                    frmCheckIN_Room.txtIDNumber.Text = rdr.GetValue(8)
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql2 As String = "Select RTRIM(Temp_Reservation.ID),RTRIM(ReservationNo),Convert(DateTime,ReservationDate,131),RTRIM(Guest.ID),RTRIM(Guest.GuestID),RTRIM(GuestName),RTRIM(Room.RoomNo),CONVERT(DateTime,DateIN,103),CONVERT(DateTime,DateOut,103),RTRIM(Temp_Reservation.Notes) from Temp_Reservation,Guest,Room where Temp_Reservation.GuestID=Guest.ID and Temp_Reservation.RoomNo=Room.RoomNo and Temp_Reservation.ID=" & dr.Cells(0).Value & ""
                cmd = New SqlCommand(sql2, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    frmCheckIN_Room.txtReservationID.Text = rdr.GetValue(0)
                    frmCheckIN_Room.dtpDateIn.Text = rdr.GetValue(7)
                    frmCheckIN_Room.dtpDateOut.Text = rdr.GetValue(8)
                End If
                con.Close()
                frmCheckIN_Room.lblUser.Text = lblUser.Text
                frmCheckIN_Room.btnCheckedIN.Enabled = True
                frmCheckIN_Room.btnSave.Enabled = False
                frmCheckIN_Room.dtpDateIn.Enabled = False
                frmCheckIN_Room.dtpDateOut.Enabled = False
                frmCheckIN_Room.cmbRoomNo.Enabled = False
                frmCheckIN_Room.btnRoomAvailability.Enabled = False
                frmCheckIN_Room.cmbRoomNo.Text = dr.Cells(2).Value.ToString
                frmCheckIN_Room.cmbRoomNo1.Text = dr.Cells(2).Value.ToString
                frmCheckIN_Room.txtGuestID.Text = dr.Cells(1).Value.ToString
                frmCheckIN_Room.txtGuestName.Text = dr.Cells(3).Value.ToString
                frmCheckIN_Room.Fill()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub EmployeeToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeToolStripMenuItem1.Click
        frmEmployeeRegistration.lblUser.Text = lblUser.Text
        frmEmployeeRegistration.Reset()
        frmEmployeeRegistration.ShowDialog()
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeesToolStripMenuItem.Click
        frmEmployeesRecord.Reset()
        frmEmployeesRecord.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem.Click
        frmAdvanceEntryRecord.Reset()
        frmAdvanceEntryRecord.ShowDialog()
    End Sub


    Private Sub DeductionEntryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeductionEntryToolStripMenuItem.Click
        frmDeductionRecord.Reset()
        frmDeductionRecord.ShowDialog()
    End Sub

    Private Sub EmployeePayment2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeePayment2ToolStripMenuItem.Click
        frmEmployeePaymentRecord.Reset()
        frmEmployeePaymentRecord.ShowDialog()
    End Sub

    Private Sub EmployeeAttendanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeAttendanceToolStripMenuItem.Click
        frmAttendanceEntryRecord.Reset()
        frmAttendanceEntryRecord.ShowDialog()
    End Sub

    Private Sub EmployeeAttendnace2ToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeAttendnace2ToolStripMenuItem.Click
        frmTotalAttendanceRecord.Reset()
        frmTotalAttendanceRecord.ShowDialog()
    End Sub
    Sub Backup()
        Try
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            If (Not System.IO.Directory.Exists("C:\DBBackup")) Then
                System.IO.Directory.CreateDirectory("C:\DBBackup")
            End If
            Dim destdir As String = "C:\DBBackup\HMS_DB " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".bak"
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database [" & System.Windows.Forms.Application.StartupPath & "\hms_db.mdf] to disk='" & destdir & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Sucessfully performed the backup"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackupToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Backup()
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
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
                Dim cb As String = "USE Master ALTER DATABASE [" & System.Windows.Forms.Application.StartupPath & "\hms_db.mdf] SET Single_User WITH Rollback Immediate Restore database [" & System.Windows.Forms.Application.StartupPath & "\hms_db.mdf] FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE [" & System.Windows.Forms.Application.StartupPath & "\hms_db.mdf] SET Multi_User "
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

    Private Sub RestaurantBillingToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem1.Click
        frmRestaurantBillingReport.Reset()
        frmRestaurantBillingReport.ShowDialog()
    End Sub

    Private Sub RoomOrdersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoomOrdersToolStripMenuItem.Click
        frmRoomOrdersReport.Reset()
        frmRoomOrdersReport.ShowDialog()
    End Sub

    Private Sub GardenReservationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GardenReservationToolStripMenuItem.Click
        frmGardenReservationReport.Reset()
        frmGardenReservationReport.ShowDialog()
    End Sub

    Private Sub RoomReservationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoomReservationToolStripMenuItem.Click
        frmRoomReservationReport.Reset()
        frmRoomReservationReport.ShowDialog()
    End Sub

    Private Sub SalarySlipsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalarySlipsToolStripMenuItem.Click
        frmSalarySlipsReport.Reset()
        frmSalarySlipsReport.ShowDialog()
    End Sub

    Private Sub EmployeePaymentToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles EmployeePaymentToolStripMenuItem1.Click
        frmEmployeePaymentReport.Reset()
        frmEmployeePaymentReport.ShowDialog()
    End Sub

    Private Sub HallReservationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HallReservationToolStripMenuItem.Click
        frmHallReservationReport.Reset()
        frmHallReservationReport.ShowDialog()
    End Sub

    Private Sub RoomInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoomInvoiceToolStripMenuItem.Click
        frmRoomBill.Reset()
        frmRoomBill.ShowDialog()
    End Sub

    Private Sub HallReservationInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HallReservationInvoiceToolStripMenuItem.Click
        frmHallReservationInvoice.Reset()
        frmHallReservationInvoice.ShowDialog()
    End Sub

    Private Sub GardenReservationInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GardenReservationInvoiceToolStripMenuItem.Click
        frmGardenReservationInvoice.Reset()
        frmGardenReservationInvoice.ShowDialog()
    End Sub

    Private Sub RestaurantInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantInvoiceToolStripMenuItem.Click
        frmRestaurantBill.Reset()
        frmRestaurantBill.ShowDialog()
    End Sub

    Private Sub RoomOrderInvoiceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RoomOrderInvoiceToolStripMenuItem.Click
        frmFoodOrderBill.Reset()
        frmFoodOrderBill.ShowDialog()
    End Sub

    Private Sub GuestToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles GuestToolStripMenuItem2.Click
        frmGuestReport.Reset()
        frmGuestReport.ShowDialog()
    End Sub

    Private Sub SalarySlipToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalarySlipToolStripMenuItem.Click
        frmSalaryslip.Reset()
        frmSalaryslip.ShowDialog()
    End Sub

    Private Sub AdvanceEntryToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles AdvanceEntryToolStripMenuItem2.Click
        frmAdvanceEntryReport.Reset()
        frmAdvanceEntryReport.ShowDialog()
    End Sub

    Private Sub DeductionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeductionToolStripMenuItem.Click
        frmDeductionReport.Reset()
        frmDeductionReport.ShowDialog()
    End Sub


    Private Sub frmMainMenu_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
    End Sub

  
    Private Sub LaundryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LaundryToolStripMenuItem.Click
        frmLaundry_master.lblUser.Text = lblUser.Text
        frmLaundry_master.Reset()
        frmLaundry_master.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LaundryBillingToolStripMenuItem1.Click
        frmLaundryBilling.lblUser.Text = lblUser.Text
        frmLaundryBilling.Reset()
        frmLaundryBilling.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles LaundryBillingToolStripMenuItem2.Click
        frmLaundryBillingRecord.Reset()
        frmLaundryBillingRecord.ShowDialog()
    End Sub

    Private Sub LaundaryBillToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LaundaryBillToolStripMenuItem.Click
        frmLaundryBill.Reset()
        frmLaundryBill.ShowDialog()
    End Sub

    Private Sub WordpadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles WordpadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Wordpad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSWordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MSWordToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("WinWord.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TaskManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaskManagerToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("TaskMgr.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MSPaintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MSPaintToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("MSPaint.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TableToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TableToolStripMenuItem.Click
        frmTable.lblUser.Text = lblUser.Text
        frmTable.Reset()
        frmTable.ShowDialog()
    End Sub

    Private Sub RestaurantBillingKOTToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantBillingKOTToolStripMenuItem.Click
        frmRestaurantBillingKOT.lblUser.Text = lblUser.Text
        frmRestaurantBillingKOT.Reset()
        frmRestaurantBillingKOT.Reset1()
        frmRestaurantBillingKOT.ShowDialog()
    End Sub

    Private Sub OrderToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles OrderToolStripMenuItem3.Click
        frmOrder.lblUser.Text = lblUser.Text
        frmOrder.Reset()
        frmOrder.ShowDialog()
    End Sub

    Private Sub LaundryBillingToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles LaundryBillingToolStripMenuItem3.Click
        frmLaundryBilling.lblUser.Text = lblUser.Text
        frmLaundryBilling.Reset()
        frmLaundryBilling.ShowDialog()
    End Sub


    Private Sub RestaurantBillingToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantBillingToolStripMenuItem3.Click
        frmRestaurantBilling.lblUser.Text = lblUser.Text
        frmRestaurantBilling.Reset()
        frmRestaurantBilling.ShowDialog()
    End Sub

 
    Private Sub RestaurantBillingKOTToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RestaurantBillingKOTToolStripMenuItem1.Click
        frmRestaurantBillingKOT.lblUser.Text = lblUser.Text
        frmRestaurantBillingKOT.Reset()
        frmRestaurantBillingKOT.Reset1()
        frmRestaurantBillingKOT.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView1.RowCount
            colsTotal = DataGridView1.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView1.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView1.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = DataGridView2.RowCount
            colsTotal = DataGridView2.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = DataGridView2.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = DataGridView2.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub txtSearchByGuestName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(CheckIn_Room.Cin_ID),RTRIM(Guest.GuestID), RTRIM(Room.RoomNo),RTRIM(GuestName),Convert(varchar(10),DateIN,103),Convert(varchar(10),DateOut,103) from Guest,Room,Checkin_Room where Guest.ID=Checkin_room.GuestID and Room.RoomNo=Checkin_Room.RoomNo and Status='Check In' and GuestName like '" & txtSearchByGuestName.Text & "%' Order by DateIN"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If Convert.ToDateTime(r.Cells(5).Value) <= System.DateTime.Now.Date Then
                    r.DefaultCellStyle.BackColor = Color.Red
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            DataGridView1.ClearSelection()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "Select RTRIM(Reservation.ID),RTRIM(Guest.GuestID),RTRIM(Room.RoomNo),RTRIM(GuestName),Convert(varchar(10),DateIN,103),Convert(varchar(10),DateOut,103) from Guest,Room,Reservation where Guest.ID=Reservation.GuestID and Room.RoomNo=Reservation.RoomNo and Status='Reserved' and GuestName like '" & TextBox1.Text & "%' Order by DateIN"
            cmd = New SqlCommand(sql1, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView2.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If Convert.ToDateTime(r.Cells(5).Value) <= System.DateTime.Now.Date Then
                    r.DefaultCellStyle.BackColor = Color.Red
                Else
                    r.DefaultCellStyle.BackColor = Color.LightGreen
                End If
            Next
            DataGridView2.ClearSelection()
            con.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtSearchByGuestName.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        DataGridView1.ClearSelection()
        GetData()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        GetData()
    End Sub
End Class