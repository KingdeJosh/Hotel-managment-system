Imports System.Data.SqlClient

Public Class frmOrdersList

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Room_OrderInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due],RTRIM(Operator) as [Operator] from Room,Guest,CheckIN_Room,Room_OrderInfo where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()

    End Sub
    Sub Reset()
        cmbBillNo.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Now
        txtGuestName.Text = ""
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Order" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmOrder.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmOrder.txtBillID.Text = dr.Cells(0).Value.ToString()
                    frmOrder.txtBillNo.Text = dr.Cells(1).Value.ToString()
                    frmOrder.dtpBillDate.Text = dr.Cells(2).Value.ToString()
                    frmOrder.cmbPaymentMode.Text = dr.Cells(3).Value.ToString()
                    frmOrder.txtCheckedInID.Text = dr.Cells(4).Value.ToString()
                    frmOrder.txtGuestID.Text = dr.Cells(5).Value.ToString()
                    frmOrder.txtGuestName.Text = dr.Cells(6).Value.ToString()
                    frmOrder.txtRoomNo.Text = dr.Cells(7).Value.ToString()
                    frmOrder.txtGrandTotal.Text = dr.Cells(8).Value.ToString()
                    frmOrder.txtTotalPayment.Text = dr.Cells(9).Value.ToString()
                    frmOrder.txtPaymentDue.Text = dr.Cells(10).Value.ToString()
                    frmOrder.btnSave.Enabled = False
                    frmOrder.btnDelete.Enabled = True
                    frmOrder.btnUpdate.Enabled = True
                    frmOrder.btnPrint.Enabled = True
                    frmOrder.btnAdd_Food.Enabled = False
                    frmOrder.btnAdd_Liquor.Enabled = False
                    frmOrder.btnRemove.Enabled = False
                    frmOrder.btnRemove1.Enabled = False
                    frmOrder.dtpBillDate.Enabled = False
                    frmOrder.btnListOfGuest.Enabled = False
                    frmOrder.txtRestrict.Text = "Not Allowed"
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "Select RTRIM(Dish_Liquor),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from Room_OrderInfo,Room_OrderedProduct where Room_OrderInfo.Id=Room_OrderedProduct.BillID and Room_OrderInfo.ID=" & dr.Cells(0).Value & " and Volumn= 0"
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmOrder.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmOrder.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                    End While
                    con.Close()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql1 As String = "Select RTRIM(Dish_Liquor),RTRIM(Volumn),RTRIM(Rate),RTRIM(TakenFrom),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from Room_OrderInfo,Room_OrderedProduct where Room_OrderInfo.Id=Room_OrderedProduct.BillID and Room_OrderInfo.ID=" & dr.Cells(0).Value & " and Volumn > 0"
                    cmd = New SqlCommand(sql1, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmOrder.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmOrder.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
                    End While
                    con.Close()
                    lblSet.Text = ""
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlLightLight
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Room_OrderInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due],RTRIM(Operator) as [Operator] from Room,Guest,CheckIN_Room,Room_OrderInfo where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID and GuestName like '%" & txtGuestName.Text & "%' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub cmbBillNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBillNo.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(Room_OrderInfo.Id) as [Bill ID], RTRIM(BillNo) as [Bill No.],Convert(DateTime,BillDate,131) as [Bill Date],RTRIM(PaymentMode) as [Payment Mode], RTRIM(CheckInId) as [Check In ID],RTRIM(Guest.GuestID) as [Guest ID],RTRIM(GuestName) as [Guest Name],RTRIM(RoomNo) as [Room No.],RTRIM(Room_OrderInfo.GrandTotal) as [Grand Total], RTRIM(TotalPayment) as [Total Payment], RTRIM(PaymentDue) as [Payment Due],RTRIM(Operator) as [Operator] from Room,Guest,CheckIN_Room,Room_OrderInfo where Guest.ID=CheckIn_Room.GuestID and Room_Orderinfo.CheckInId=Checkin_Room.Cin_ID and Room.R_ID=CheckIN_Room.RoomID and BillNo='" & cmbBillNo.Text & "' order by BillDate", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Room_OrderInfo")
            dgw.DataSource = myDataSet.Tables("Room_OrderInfo").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbBillNo_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbBillNo.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub
End Class
