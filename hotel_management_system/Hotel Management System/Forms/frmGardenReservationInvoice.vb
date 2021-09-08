Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmGardenReservationInvoice
    Sub fillBilllNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(BillNo) FROM Reservation_Garden", CN)
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
        Try
            If Len(Trim(cmbBillNo.Text)) = 0 Then
                MessageBox.Show("Please select bill no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbBillNo.Focus()
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptGardenInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Reservation_Garden.BillNo, Reservation_Garden.BillDate, Reservation_Garden.GuestID, Reservation_Garden.Type, Reservation_Garden.Name, Reservation_Garden.DateFrom, Reservation_Garden.DateTo,Reservation_Garden.Days, Reservation_Garden.Rate, Reservation_Garden.TotalCharges, Reservation_Garden.DiscountPer, Reservation_Garden.DiscountAmount, Reservation_Garden.OtherCharges, Reservation_Garden.SubTotal,Reservation_Garden.STPer, Reservation_Garden.STAmount, Reservation_Garden.LuxuryTaxPer, Reservation_Garden.LuxuryTaxAmount, Reservation_Garden.GrandTotal, Reservation_Garden.TotalPaid, Reservation_Garden.Balance,Reservation_Garden.Notes, Guest.GuestID AS Expr2, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation, Guest.Religion, Guest.IDType,Guest.IDNumber FROM Reservation_Garden INNER JOIN Guest ON Reservation_Garden.GuestID = Guest.ID where Reservation_Garden.BillNo='" & cmbBillNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Reservation_Garden")
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
