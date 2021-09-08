Imports System.Data.SqlClient

Public Class frmKOTReport
    Dim a As Decimal
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReport.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantBillingKOT 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Restaurant_BillingInfoKOT.Id,Operator, Restaurant_BillingInfoKOT.BillNo, Restaurant_BillingInfoKOT.BillDate, Restaurant_BillingInfoKOT.GrandTotal, Restaurant_BillingInfoKOT.Cash, Restaurant_BillingInfoKOT.Change,Restaurant_OrderedProductBillKOT.OP_ID, Restaurant_OrderedProductBillKOT.BillID, Restaurant_OrderedProductBillKOT.Dish_Liquor, Restaurant_OrderedProductBillKOT.Volumn,Restaurant_OrderedProductBillKOT.Rate, Restaurant_OrderedProductBillKOT.Quantity, Restaurant_OrderedProductBillKOT.Amount, Restaurant_OrderedProductBillKOT.TakenFrom,Restaurant_OrderedProductBillKOT.VATPer, Restaurant_OrderedProductBillKOT.VATAmount, Restaurant_OrderedProductBillKOT.STPer, Restaurant_OrderedProductBillKOT.STAmount,Restaurant_OrderedProductBillKOT.DiscountPer, Restaurant_OrderedProductBillKOT.DiscountAmount, Restaurant_OrderedProductBillKOT.TotalAmount, Restaurant_OrderedProductBillKOT.TableNo FROM Restaurant_BillingInfoKOT INNER JOIN Restaurant_OrderedProductBillKOT ON Restaurant_BillingInfoKOT.Id = Restaurant_OrderedProductBillKOT.BillID where BillDate between @d1 and @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Restaurant_BillingInfoKOT")
            myDA.Fill(myDS, "Restaurant_OrderedProductBillKOT")
            myDA1.Fill(myDS, "Hotel")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select IsNull(Sum(GrandTotal),0) from Restaurant_BillingInfoKOT where BillDate between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            con.Close()
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            'frmReport.CrystalReportViewer1.ReportSource = rpt
            '  frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
