Imports System.Data.SqlClient

Public Class frmRestaurantBillingReport
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
            Dim rpt As New rptRestaurantBilling 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Restaurant_OrderedProduct.OP_ID,Operator, Restaurant_OrderedProduct.BillID, Restaurant_OrderedProduct.Dish_Liquor, Restaurant_OrderedProduct.Volumn, Restaurant_OrderedProduct.VATPer,Restaurant_OrderedProduct.VATAmount, Restaurant_OrderedProduct.STPer, Restaurant_OrderedProduct.STAmount, Restaurant_OrderedProduct.DiscountPer, Restaurant_OrderedProduct.DiscountAmount,Restaurant_OrderedProduct.Rate, Restaurant_OrderedProduct.Quantity, Restaurant_OrderedProduct.Amount, Restaurant_OrderedProduct.TakenFrom, Restaurant_OrderedProduct.TotalAmount,Restaurant_OrderInfo.ID, Restaurant_OrderInfo.BillNo, Restaurant_OrderInfo.BillDate, Restaurant_OrderInfo.GrandTotal, Restaurant_OrderInfo.Cash, Restaurant_OrderInfo.Change FROM Restaurant_OrderedProduct INNER JOIN  Restaurant_OrderInfo ON Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID where BillDate between @d1 and @d2 order by BillDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Restaurant_OrderInfo")
            myDA.Fill(myDS, "Restaurant_OrderedProduct")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("v1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("v2", dtpDateTo.Value.Date)

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
