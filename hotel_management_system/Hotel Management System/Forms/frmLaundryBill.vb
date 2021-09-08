Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmLaundryBill
    Sub fillBilllNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM Laundry_BillInfo", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbBillNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbBillNo.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillBilllNo()
    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        fillBilllNo()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            If Len(Trim(cmbBillNo.Text)) = 0 Then
                MessageBox.Show("Please select bill no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbBillNo.Focus()
                Exit Sub
            End If
            Try
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim rpt As New rptLaundryBillingInvoice 'The report you created.
                Dim myConnection As SqlConnection
                Dim MyCommand, MyCommand1 As New SqlCommand()
                Dim myDA, myDA1 As New SqlDataAdapter()
                Dim myDS As New DataSet 'The DataSet you created.
                myConnection = New SqlConnection(cs)
                MyCommand.Connection = myConnection
                MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Laundry_BillInfo.BillNo, Laundry_BillInfo.BillDate, Laundry_BillInfo.CheckInID, Laundry_BillInfo.GrandTotal, Laundry_BillInfo.TotalPayment, Laundry_BillInfo.PaymentDue, LaundryServices.LS_Id, LaundryServices.BillID, LaundryServices.Service, LaundryServices.Rate, LaundryServices.Qty, LaundryServices.TotalAmount, Laundry_Master.ServiceName,Laundry_Master.ChargesPerUnit, CheckIN_Room.Cin_Id, CheckIN_Room.GuestID, CheckIN_Room.RoomNo, CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids, CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson,CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.DiscountPer, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.TaxPaidRate, CheckIN_Room.Notes, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr4,Room.RoomNo AS Expr5, Room.RoomType, Room.RoomCharges AS Expr6 FROM Laundry_BillInfo INNER JOIN LaundryServices ON Laundry_BillInfo.Id = LaundryServices.BillID INNER JOIN Laundry_Master ON LaundryServices.Service = Laundry_Master.ServiceName INNER JOIN CheckIN_Room ON Laundry_BillInfo.CheckInID = CheckIN_Room.Cin_Id INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomNo = Room.RoomNo where Laundry_BillInfo.BillNo='" & cmbBillNo.Text & "'"
                MyCommand1.CommandText = "SELECT * from Hotel"
                MyCommand.CommandType = CommandType.Text
                MyCommand1.CommandType = CommandType.Text
                myDA.SelectCommand = MyCommand
                myDA1.SelectCommand = MyCommand1
                myDA.Fill(myDS, "Guest")
                myDA.Fill(myDS, "Room")
                myDA.Fill(myDS, "Laundry_BillInfo")
                myDA.Fill(myDS, "CheckIn_Room")
                myDA.Fill(myDS, "LaundryServices")
                myDA1.Fill(myDS, "Hotel")
                rpt.SetDataSource(myDS)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
