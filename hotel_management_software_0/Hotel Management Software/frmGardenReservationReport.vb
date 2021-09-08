Imports System.Data.SqlClient

Public Class frmGardenReservationReport
    Sub fillGarden()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Name) FROM Reservation_Garden", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbGardenName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbGardenName.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillGarden()
    End Sub
    Sub Reset()
        cmbGardenName.SelectedIndex = -1
        DateTimePicker1.Text = Now
        DateTimePicker2.Text = Today
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        fillGarden()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Len(Trim(cmbGardenName.Text)) = 0 Then
                MessageBox.Show("Please select garden name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGardenName.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT Reservation_Garden.BillNo, Reservation_Garden.BillDate, Reservation_Garden.GuestID, Reservation_Garden.Type, Reservation_Garden.Name, Reservation_Garden.DateFrom,Reservation_Garden.DateTo, Reservation_Garden.Days, Reservation_Garden.Rate, Reservation_Garden.TotalCharges, Reservation_Garden.DiscountPer, Reservation_Garden.DiscountAmount,Reservation_Garden.OtherCharges, Reservation_Garden.SubTotal, Reservation_Garden.STPer, Reservation_Garden.STAmount, Reservation_Garden.LuxuryTaxPer, Reservation_Garden.LuxuryTaxAmount,Reservation_Garden.GrandTotal, Reservation_Garden.TotalPaid, Reservation_Garden.Balance, Reservation_Garden.Status, Reservation_Garden.Notes, Guest.ID,Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3,Garden.GardenName, Garden.Charges FROM Reservation_Garden INNER JOIN Guest ON Reservation_Garden.GuestID = Guest.ID INNER JOIN Garden ON Reservation_Garden.Name = Garden.GardenName where BillDate between @d1 and @d2 and Name=@d3 and Status='Confirmed' order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            MyCommand.Parameters.Add("@d3", SqlDbType.NChar, 200, "Name").Value = cmbGardenName.Text
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Reservation_Garden")
            myDA.Fill(myDS, "Garden")
            myDA.Fill(myDS, "Guest")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            'Dim rpt As New rptGardenReseravation 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1, MyCommand2 As New SqlCommand()
            Dim myDA, myDA1, myDA2 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand2.Connection = myConnection
            MyCommand.CommandText = "SELECT  Reservation_Garden.BillNo, Reservation_Garden.BillDate, Reservation_Garden.GuestID, Reservation_Garden.Type, Reservation_Garden.Name, Reservation_Garden.DateFrom,Reservation_Garden.DateTo, Reservation_Garden.Days, Reservation_Garden.Rate, Reservation_Garden.TotalCharges, Reservation_Garden.DiscountPer, Reservation_Garden.DiscountAmount,Reservation_Garden.OtherCharges, Reservation_Garden.SubTotal, Reservation_Garden.STPer, Reservation_Garden.STAmount, Reservation_Garden.LuxuryTaxPer, Reservation_Garden.LuxuryTaxAmount,Reservation_Garden.GrandTotal, Reservation_Garden.TotalPaid, Reservation_Garden.Balance, Reservation_Garden.Status, Reservation_Garden.Notes, Guest.ID,Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Pic1, Guest.Pic2, Guest.pic3, Guest.Notes AS Expr3,Garden.GardenName, Garden.Charges FROM Reservation_Garden INNER JOIN Guest ON Reservation_Garden.GuestID = Guest.ID INNER JOIN Garden ON Reservation_Garden.Name = Garden.GardenName where BillDate between @d1 and @d2 and Status='Confirmed' order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker2.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = DateTimePicker1.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand2.CommandText = "SELECT * from Currency"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            MyCommand2.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA2.SelectCommand = MyCommand2
            myDA.Fill(myDS, "Reservation_Garden")
            myDA.Fill(myDS, "Garden")
            myDA.Fill(myDS, "Guest")
            myDA1.Fill(myDS, "Hotel")
            myDA2.Fill(myDS, "Currency")
           
            'frmReport.CrystalReportViewer1.ReportSource = rpt
            'frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
