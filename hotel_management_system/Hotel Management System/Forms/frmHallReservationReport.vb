Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmHallReservationReport
    Sub fillHall()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Reservation_Hall", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbHallName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbHallName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillHall()
    End Sub
    Sub Reset()
        cmbHallName.SelectedIndex = -1
        DateTimePicker1.Text = Now
        DateTimePicker2.Text = Today
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        fillHall()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbHallName.Text)) = 0 Then
                MessageBox.Show("Please select Hall name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbHallName.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptHallReservation1 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Reservation_Hall.BillNo, Reservation_Hall.BillDate, Reservation_Hall.GuestID, Reservation_Hall.Type, Reservation_Hall.Name, Reservation_Hall.DateFrom,Reservation_Hall.DateTo, Reservation_Hall.Days, Reservation_Hall.Rate, Reservation_Hall.TotalCharges, Reservation_Hall.DiscountPer, Reservation_Hall.DiscountAmount,Reservation_Hall.OtherCharges, Reservation_Hall.SubTotal, Reservation_Hall.STPer, Reservation_Hall.STAmount, Reservation_Hall.LuxuryTaxPer, Reservation_Hall.LuxuryTaxAmount,Reservation_Hall.GrandTotal, Reservation_Hall.TotalPaid, Reservation_Hall.Balance, Reservation_Hall.Status, Reservation_Hall.Notes, Guest.ID,Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3,Hall.HallName, Hall.Charges FROM Reservation_Hall INNER JOIN Guest ON Reservation_Hall.GuestID = Guest.ID INNER JOIN Hall ON Reservation_Hall.Name = Hall.HallName where BillDate between @d1 and @d2 and Name=@d3 and Status='Confirmed' order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            MyCommand.Parameters.Add("@d3", SqlDbType.NChar, 200, "Name").Value = cmbHallName.Text
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Reservation_Hall")
            myDA.Fill(myDS, "Hall")
            myDA.Fill(myDS, "Guest")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("v2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptHallReservation 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT  Reservation_Hall.BillNo, Reservation_Hall.BillDate, Reservation_Hall.GuestID, Reservation_Hall.Type, Reservation_Hall.Name, Reservation_Hall.DateFrom,Reservation_Hall.DateTo, Reservation_Hall.Days, Reservation_Hall.Rate, Reservation_Hall.TotalCharges, Reservation_Hall.DiscountPer, Reservation_Hall.DiscountAmount,Reservation_Hall.OtherCharges, Reservation_Hall.SubTotal, Reservation_Hall.STPer, Reservation_Hall.STAmount, Reservation_Hall.LuxuryTaxPer, Reservation_Hall.LuxuryTaxAmount,Reservation_Hall.GrandTotal, Reservation_Hall.TotalPaid, Reservation_Hall.Balance, Reservation_Hall.Status, Reservation_Hall.Notes, Guest.ID,Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3,Hall.HallName, Hall.Charges FROM Reservation_Hall INNER JOIN Guest ON Reservation_Hall.GuestID = Guest.ID INNER JOIN Hall ON Reservation_Hall.Name = Hall.HallName where BillDate between @d1 and @d2 and Status='Confirmed' order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker2.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker1.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Reservation_Hall")
            myDA.Fill(myDS, "Hall")
            myDA.Fill(myDS, "Guest")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("v2", DateTimePicker1.Value.Date)
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
