Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class frmOrder
    Dim num1, num2, num3, num4, num5, num6 As Double
    Dim st2, GID As String
    Dim a As Decimal
    Dim s1, s2, s3 As String
    Sub Compute()
        Try

            num1 = CDbl(Val(txtRate_Food.Text) * Val(txtQty_Food.Text))
            num1 = Math.Round(num1, 2)
            txtAmt_Food.Text = num1
            num2 = CDbl((Val(txtAmt_Food.Text) * Val(txtDiscountPer_Food.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount_Food.Text = num2
            num3 = CDbl(Val(txtAmt_Food.Text) - Val(txtDiscountAmount_Food.Text))
            num3 = Math.Round(num3, 2)
            txtSubTotal_Food.Text = num3
            num4 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtServiceTaxPer_Food.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount_Food.Text = num4
            num5 = CDbl((Val(txtSubTotal_Food.Text) * Val(txtVATPer_Food.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtVATAmt_Food.Text = num5
            num6 = CDbl(Val(txtSubTotal_Food.Text) + Val(txtServiceTaxAmount_Food.Text) + Val(txtVATAmt_Food.Text))
            num6 = Math.Round(num6, 2)
            txtTotalAmt_Food.Text = num6
            Compute3()
            auto()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute1()
        Try

            num1 = CDbl(Val(txtRate_Liquor.Text) * Val(txtQty_Liquor.Text))
            num1 = Math.Round(num1, 2)
            txtAmt_Liquor.Text = num1
            num2 = CDbl((Val(txtAmt_Liquor.Text) * Val(txtDiscountPer_Liquor.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount_Liquor.Text = num2
            num3 = CDbl(Val(txtAmt_Liquor.Text) - Val(txtDiscountAmount_Liquor.Text))
            num3 = Math.Round(num3, 2)
            txtSubTotal_Liquor.Text = num3
            num4 = CDbl((Val(txtSubTotal_Liquor.Text) * Val(txtServiceTaxPer_Liquor.Text)) / 100)
            num4 = Math.Round(num4, 2)
            txtServiceTaxAmount_Liquor.Text = num4
            num5 = CDbl((Val(txtSubTotal_Liquor.Text) * Val(txtVATPer_Liquor.Text)) / 100)
            num5 = Math.Round(num5, 2)
            txtVATAmt_Liquor.Text = num5
            num6 = CDbl(Val(txtSubTotal_Liquor.Text) + Val(txtServiceTaxAmount_Liquor.Text) + Val(txtVATAmt_Liquor.Text))
            num6 = Math.Round(num6, 2)
            txtTotalAmt_Liquor.Text = num6
            Compute3()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Compute3()
        Try
            Dim number As Double
            number = CDbl(Val(txtGrandTotal.Text) - Val(txtTotalPayment.Text))
            number = Math.Round(number, 2)
            txtPaymentDue.Text = number
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillFoodName()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(DishName) FROM Dish", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbFoodName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbFoodName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
  
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbLiquorName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLiquorName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT distinct RTRIM(Quantity) FROM Liquor_Rate where LiquorName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            rdr = cmd.ExecuteReader()
            cmbVolumn.Enabled = True
            cmbVolumn.Items.Clear()
            cmbVolumn.Focus()
            While rdr.Read
                cmbVolumn.Items.Add(rdr(0))
            End While
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Category,Discount FROM Liquor WHERE LiquorName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCategory_Liquor.Text = rdr.GetString(0)
                txtDiscountPer_Liquor.Text = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST FROM Category_Liquor WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Liquor.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Liquor.Text = rdr.GetValue(0)
                txtServiceTaxPer_Liquor.Text = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub cmbVolumn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVolumn.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate FROM Liquor_Rate WHERE LiquorName=@d1 and Quantity=" & cmbVolumn.Text & ""
            cmd.Parameters.AddWithValue("@d1", cmbLiquorName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Liquor.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Reset()
        txtAmt_Liquor.Text = ""
        txtAmt_Food.Text = ""
        txtBillID.Text = ""
        txtBillNo.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountAmount_Liquor.Text = ""
        txtDiscountPer_Food.Text = ""
        txtDiscountPer_Liquor.Text = ""
        txtGuestID.Text = ""
        txtGuestName.Text = ""
        txtSubTotal_Food.Text = ""
        txtPaymentDue.Text = "0.00"
        txtQty_Food.Text = ""
        txtQty_Liquor.Text = ""
        txtRate_Food.Text = ""
        txtRate_Liquor.Text = ""
        txtGrandTotal.Text = "0.00"
        txtTotalPayment.Text = "0.00"
        txtRoomNo.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtServiceTaxAmount_Liquor.Text = ""
        txtServiceTaxPer_Liquor.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATAmt_Liquor.Text = ""
        txtVATPer_Food.Text = ""
        txtVATPer_Liquor.Text = ""
        cmbFoodName.Text = ""
        cmbLiquorName.Text = ""
        cmbTakenOut.SelectedIndex = -1
        cmbVolumn.Text = ""
        dtpBillDate.Text = Now
        dtpBillDate.Enabled = True
        cmbVolumn.Enabled = False
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        btnPrint.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnAdd_Food.Enabled = True
        btnAdd_Liquor.Enabled = True
        btnRemove.Enabled = False
        btnRemove1.Enabled = False
        txtRestrict.Text = ""
        txtContactNo.Text = ""
        cmbPaymentMode.Enabled = True
        cmbPaymentMode.SelectedIndex = 1
        txtTotalPayment.ReadOnly = True
        txtTotalPayment.Enabled = False
        btnListOfGuest.Enabled = True
        lblUser.Text = frmMainMenu.lblUser.Text
        auto()
    End Sub

    Private Sub cmbFoodName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFoodName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Rate,Category,Discount FROM Dish WHERE DishName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbFoodName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtRate_Food.Text = rdr.GetValue(0)
                txtCategory_Food.Text = rdr.GetString(1)
                txtDiscountPer_Food.Text = rdr.GetValue(2)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT VAT,ST FROM Category WHERE CategoryName=@d1"
            cmd.Parameters.AddWithValue("@d1", txtCategory_Food.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtVATPer_Food.Text = rdr.GetValue(0)
                txtServiceTaxPer_Food.Text = rdr.GetValue(1)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            txtQty_Food.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub auto1()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM GuestLedger")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtGuestLedgerID.Text = Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtGuestLedgerID.Text = Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub frmOrder1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd_Food.Click
        Try
            If txtRate_Food.Text = "" Then
                MessageBox.Show("Please enter rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRate_Food.Focus()
                Exit Sub
            End If
            If txtQty_Food.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty_Food.Focus()
                Exit Sub
            End If
            If txtQty_Food.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty_Food.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(cmbFoodName.Text, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtTotalAmt_Food.Text))
                Dim k As Double = 0
                k = GrandTotal_Food() + GrandTotal_Liquor()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = cmbFoodName.Text And r.Cells(1).Value = Val(txtRate_Food.Text) Then
                    r.Cells(0).Value = cmbFoodName.Text
                    r.Cells(1).Value = txtRate_Food.Text
                    r.Cells(2).Value = Val(r.Cells(2).Value) + Val(txtQty_Food.Text)
                    r.Cells(3).Value = Val(r.Cells(3).Value) + Val(txtAmt_Food.Text)
                    r.Cells(4).Value = Val(txtDiscountPer_Food.Text)
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtDiscountAmount_Food.Text)
                    r.Cells(6).Value = Val(txtServiceTaxPer_Food.Text)
                    r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtServiceTaxAmount_Food.Text)
                    r.Cells(8).Value = Val(txtVATPer_Food.Text)
                    r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtVATAmt_Food.Text)
                    r.Cells(10).Value = Val(r.Cells(10).Value) + Val(txtTotalAmt_Food.Text)
                    Dim i As Double = 0
                    i = GrandTotal_Food() + GrandTotal_Liquor()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    Clear()
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(cmbFoodName.Text, Val(txtRate_Food.Text), Val(txtQty_Food.Text), Val(txtAmt_Food.Text), Val(txtDiscountPer_Food.Text), Val(txtDiscountAmount_Food.Text), Val(txtServiceTaxPer_Food.Text), Val(txtServiceTaxAmount_Food.Text), Val(txtVATPer_Food.Text), Val(txtVATAmt_Food.Text), Val(txtTotalAmt_Food.Text))
           Dim j As Double = 0
            j = GrandTotal_Food() + GrandTotal_Liquor()
            j = Math.Round(j, 2)
            txtGrandTotal.Text = j
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Clear()
        cmbFoodName.Text = ""
        txtRate_Food.Text = ""
        txtQty_Food.Text = ""
        txtAmt_Food.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountPer_Food.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATPer_Food.Text = ""
        txtTotalAmt_Food.Text = ""
        cmbFoodName.Focus()
    End Sub
    Sub Clear1()
        cmbLiquorName.Text = ""
        cmbVolumn.Text = ""
        cmbTakenOut.SelectedIndex = -1
        cmbVolumn.Enabled = False
        txtRate_Liquor.Text = ""
        txtAmt_Liquor.Text = ""
        txtServiceTaxAmount_Liquor.Text = ""
        txtServiceTaxPer_Liquor.Text = ""
        txtDiscountAmount_Liquor.Text = ""
        txtDiscountPer_Liquor.Text = ""
        txtVATAmt_Liquor.Text = ""
        txtVATPer_Liquor.Text = ""
        txtTotalAmt_Liquor.Text = ""
        txtQty_Liquor.Text = ""
        cmbTakenOut.Enabled = False
    End Sub
    Public Function GrandTotal_Food() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(10).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Liquor() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + r.Cells(12).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
        Reset()
    End Sub

    Private Sub txtQty_Food_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty_Food.TextChanged
        Compute()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd_Liquor.Click
        Try
            If txtRate_Liquor.Text = "" Then
                MessageBox.Show("Please enter rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRate_Liquor.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbVolumn.Text)) = 0 Then
                MessageBox.Show("Please select volumn", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbVolumn.Focus()
                Exit Sub
            End If
            If txtQty_Liquor.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty_Liquor.Focus()
                Exit Sub
            End If
            If txtQty_Liquor.Text = 0 Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty_Liquor.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbTakenOut.Text)) = 0 Then
                MessageBox.Show("Please select taken out from ML bottle", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbTakenOut.Focus()
                Exit Sub
            End If
            If DataGridView2.Rows.Count = 0 Then
                DataGridView2.Rows.Add(cmbLiquorName.Text, Val(cmbVolumn.Text), Val(txtRate_Liquor.Text), Val(cmbTakenOut.Text), Val(txtQty_Liquor.Text), Val(txtAmt_Liquor.Text), Val(txtDiscountPer_Liquor.Text), Val(txtDiscountAmount_Liquor.Text), Val(txtServiceTaxPer_Liquor.Text), Val(txtServiceTaxAmount_Liquor.Text), Val(txtVATPer_Liquor.Text), Val(txtVATAmt_Liquor.Text), Val(txtTotalAmt_Liquor.Text))
                Dim k As Double = 0
                k = GrandTotal_Liquor() + GrandTotal_Food()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                Clear1()
                Clear1()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells(0).Value = cmbLiquorName.Text And r.Cells(1).Value = Val(cmbVolumn.Text) And r.Cells(2).Value = Val(txtRate_Liquor.Text) Then
                    r.Cells(0).Value = cmbLiquorName.Text
                    r.Cells(1).Value = cmbVolumn.Text
                    r.Cells(2).Value = txtRate_Liquor.Text
                    r.Cells(3).Value = cmbTakenOut.Text
                    r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty_Liquor.Text)
                    r.Cells(5).Value = Val(r.Cells(5).Value) + Val(txtAmt_Liquor.Text)
                    r.Cells(6).Value = Val(txtDiscountPer_Liquor.Text)
                    r.Cells(7).Value = Val(r.Cells(7).Value) + Val(txtDiscountAmount_Liquor.Text)
                    r.Cells(8).Value = Val(txtServiceTaxPer_Liquor.Text)
                    r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtServiceTaxAmount_Liquor.Text)
                    r.Cells(10).Value = Val(txtVATPer_Liquor.Text)
                    r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtVATAmt_Liquor.Text)
                    r.Cells(12).Value = Val(r.Cells(12).Value) + Val(txtTotalAmt_Liquor.Text)
                    Dim i As Double = 0
                    i = GrandTotal_Liquor() + GrandTotal_Food()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    Clear1()
                    Clear1()
                    Exit Sub
                End If
            Next
            DataGridView2.Rows.Add(cmbLiquorName.Text, Val(cmbVolumn.Text), Val(txtRate_Liquor.Text), Val(cmbTakenOut.Text), Val(txtQty_Liquor.Text), Val(txtAmt_Liquor.Text), Val(txtDiscountPer_Liquor.Text), Val(txtDiscountAmount_Liquor.Text), Val(txtServiceTaxPer_Liquor.Text), Val(txtServiceTaxAmount_Liquor.Text), Val(txtVATPer_Liquor.Text), Val(txtVATAmt_Liquor.Text), Val(txtTotalAmt_Liquor.Text))
             Dim j As Double = 0
            j = GrandTotal_Liquor() + GrandTotal_Food()
            j = Math.Round(j, 2)
            txtGrandTotal.Text = j
            Clear1()
            Clear1()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Room_OrderInfo")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "R" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "R" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListOfGuest.Click
        frmCheckInRecord.Reset()
        frmCheckInRecord.lblSet.Text = "Room Order"
        frmCheckInRecord.ShowDialog()
    End Sub
    Sub Print()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            ' Dim rpt As New rptRoomOrderInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT  Room_OrderedProduct.Op_Id,Room_OrderInfo.BillNo,Room_OrderInfo.Operator,PaymentMode, Room_OrderInfo.BillDate, Room_OrderInfo.CheckInId, Room_OrderInfo.GrandTotal, Room_OrderInfo.TotalPayment, Room_OrderInfo.PaymentDue, Room_OrderedProduct.BillID, Room_OrderedProduct.Dish_Liquor, Room_OrderedProduct.Volumn, Room_OrderedProduct.TakenFrom, Room_OrderedProduct.VATPer,Room_OrderedProduct.VATAmount, Room_OrderedProduct.STPer, Room_OrderedProduct.STAmount, Room_OrderedProduct.DiscountPer, Room_OrderedProduct.DiscountAmount, Room_OrderedProduct.Rate,Room_OrderedProduct.Quantity, Room_OrderedProduct.Amount, Room_OrderedProduct.TotalAmount, Checkin_Room.Cin_ID AS Expr2, CheckIN_Room.GuestID, CheckIN_Room.RoomID,CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids,CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation,Guest.Religion, Guest.IDType, Guest.IDNumber FROM Room_OrderInfo INNER JOIN Room_OrderedProduct ON Room_OrderInfo.Id = Room_OrderedProduct.BillID INNER JOIN CheckIN_Room ON Room_OrderInfo.CheckInId = Checkin_Room.Cin_ID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID where Room_OrderInfo.BillNo='" & txtBillNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Room")
            myDA.Fill(myDS, "Room_OrderInfo")
            myDA.Fill(myDS, "CheckIn_Room")
            myDA.Fill(myDS, "Room_OrderedProduct")
            myDA1.Fill(myDS, "Hotel")
           
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PrinterName from POSPrinterSetting where PrinterType='Kitchen Printer' and IsEnabled='Yes'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s1 = rdr.GetValue(0)
                
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PrinterName from POSPrinterSetting where PrinterType='Invoice Printer' and IsEnabled='Yes'"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s3 = rdr.GetValue(0)
               
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestID.Text)) = 0 Then
                MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnListOfGuest.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 And DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Len(Trim(txtTotalPayment.Text)) = 0 Then
                MessageBox.Show("Please enter total payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTotalPayment.Focus()
                Exit Sub
            End If
            If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
                MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtTotalPayment.Focus()
                Exit Sub
            End If
            If cmbPaymentMode.SelectedIndex = 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select ISNULL(sum(Amount)-Sum(Deduction),0) from GuestLedger,Guest where Guest.ID=GuestLedger.GuestID and GuestLedger.GuestID=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", Val(txtG_ID.Text))
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    a = rdr.GetValue(0)
                Else
                    a = 0
                End If
                con.Close()
                If a >= Val(txtTotalPayment.Text) Then
                    auto1()
                    Dim string1 As String = "Paid for room services"
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cbx As String = "insert into GuestLedger( Id,GuestID,Amount,Deduction,Date,Details) Values (" & txtGuestLedgerID.Text & "," & txtG_ID.Text & ",0," & txtTotalPayment.Text & ",@d1,@d2)"
                    cmd = New SqlCommand(cbx)
                    cmd.Parameters.AddWithValue("@d1", Now)
                    cmd.Parameters.AddWithValue("@d2", string1)
                    cmd.Connection = con
                    cmd.ExecuteReader()
                    con.Close()
                Else
                    MessageBox.Show("Insufficient fund available in guest's account...try other payment mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If
            For Each row As DataGridViewRow In DataGridView2.Rows
                Dim con As New SqlConnection(cs)
                con.Open()
                Dim cmd As New SqlCommand("SELECT TotalVolumn from Temp_Stock where LiquorName=@d1 and Volumn=" & row.Cells(3).Value & "", con)
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txtTotalVolumn.Text = ds.Tables(0).Rows(0)("TotalVolumn")
                    If CInt(Val(row.Cells(1).Value) * Val(row.Cells(4).Value)) > Val(txtTotalVolumn.Text) Then
                        MessageBox.Show("added qty. to cart are more than" & vbCrLf & "available qty. of liquor name '" & row.Cells(0).Value & "' and taken out from bottle (in ML) " & row.Cells(3).Value & "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                con.Close()
            Next
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Room_OrderInfo( Id, BillNo, BillDate, CheckInId, GrandTotal, TotalPayment, PaymentDue,PaymentMode,Operator,RO_Status) Values (" & txtBillID.Text & ",'" & txtBillNo.Text & "',@d1," & txtCheckedInID.Text & "," & txtGrandTotal.Text & "," & txtTotalPayment.Text & "," & txtPaymentDue.Text & ",@d2,@d3,'Unpaid')"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", dtpBillDate.Value)
            cmd.Parameters.AddWithValue("@d2", cmbPaymentMode.Text)
            cmd.Parameters.AddWithValue("@d3", lblUser.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Room_OrderedProduct(BillID,Volumn, TakenFrom,Dish_Liquor,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtBillID.Text & ",0,0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Room_OrderedProduct(BillID,Dish_Liquor,Volumn,Rate,TakenFrom,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(3).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb4 As String = "update Temp_stock set TotalVolumn = TotalVolumn - (" & row.Cells(1).Value & " *  " & row.Cells(4).Value & ")  where LiquorName= @d1 and Volumn=@d2"
                    cmd = New SqlCommand(cb4)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(3).Value))
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            con.Close()
            LedgerSave(dtpBillDate.Value.Date, txtGuestName.Text, txtBillNo.Text, "Room Services", Val(txtGrandTotal.Text), 0, txtGuestID.Text)
            If Val(txtTotalPayment.Text) > 0 Then
                If cmbPaymentMode.Text = "By Cash" Or cmbPaymentMode.Text = "From Guest's Account" Then
                    LedgerSave(Convert.ToDateTime(dtpBillDate.Value), "Cash Account", txtBillNo.Text, "Payment", 0, Val(txtTotalPayment.Text), txtGuestID.Text)
                End If
                If cmbPaymentMode.Text = "From Guest's Account" Then
                    LedgerSave(Convert.ToDateTime(dtpBillDate.Value), txtGuestName.Text, txtBillNo.Text, "Guest's Account", Val(txtTotalPayment.Text), 0, txtGuestID.Text)
                End If
                If cmbPaymentMode.Text = "By Credit Card" Or cmbPaymentMode.Text = "By Debit Card" Then
                    LedgerSave(Convert.ToDateTime(dtpBillDate.Value), "Bank Account", txtBillNo.Text, "Payment", 0, Val(txtTotalPayment.Text), txtGuestID.Text)
                End If
            End If
            Dim st As String = "added the new record having bill no. '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(APIURL) from SMSSetting where IsDefault='Yes' and IsEnabled='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    st2 = rdr.GetValue(0)
                    Dim st3 As String = "Hello, " & txtGuestName.Text & " you have successfully placed the order having order no. " & txtBillNo.Text & ""
                    SMSFunc(txtContactNo.Text.Trim, st3, st2)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                End If
            End If
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim str As String = "select IsNull(Email,0) from Guest where Guest.GuestID='" & txtGuestID.Text & "'"
                cmd = New SqlCommand(str)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    GID = rdr.GetValue(0).ToString.Trim()
                End If
                If GID <> "0" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                    cmd = New SqlCommand(ctn)
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                            System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                        End If
                        Dim pdfFile As String = Application.StartupPath & "\PDF Reports\RoomServicesInvoice " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
                        '    Dim rpt As New rptRoomOrderInvoice 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1 As New SqlCommand()
                        Dim myDA, myDA1 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand.CommandText = "SELECT  Room_OrderedProduct.Op_Id,Room_OrderInfo.BillNo,PaymentMode,Room_OrderInfo.Operator, Room_OrderInfo.BillDate, Room_OrderInfo.CheckInId, Room_OrderInfo.GrandTotal, Room_OrderInfo.TotalPayment, Room_OrderInfo.PaymentDue, Room_OrderedProduct.BillID, Room_OrderedProduct.Dish_Liquor, Room_OrderedProduct.Volumn, Room_OrderedProduct.TakenFrom, Room_OrderedProduct.VATPer,Room_OrderedProduct.VATAmount, Room_OrderedProduct.STPer, Room_OrderedProduct.STAmount, Room_OrderedProduct.DiscountPer, Room_OrderedProduct.DiscountAmount, Room_OrderedProduct.Rate,Room_OrderedProduct.Quantity, Room_OrderedProduct.Amount, Room_OrderedProduct.TotalAmount, Checkin_Room.Cin_ID AS Expr2, CheckIN_Room.GuestID, CheckIN_Room.RoomID,CheckIN_Room.RoomCharges, CheckIN_Room.DateIN, CheckIN_Room.DateOUT, CheckIN_Room.NoOfDays, CheckIN_Room.NoOfMales, CheckIN_Room.NoOfFemales, CheckIN_Room.NoOfKids,CheckIN_Room.NoOfExtraBed, CheckIN_Room.NoOfExtraPerson, CheckIN_Room.RoomOrderCharges, CheckIN_Room.ExtraPersonCharges, CheckIN_Room.TotalRoomCharges, CheckIN_Room.ExtraBedCharges, CheckIN_Room.OtherCharges, CheckIN_Room.LuxuryTaxPer, CheckIN_Room.LuxuryTaxAmount, CheckIN_Room.SubTotal, CheckIN_Room.TotalPaid, CheckIN_Room.Balance, CheckIN_Room.Status, CheckIN_Room.Notes, Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation,Guest.Religion, Guest.IDType, Guest.IDNumber FROM Room_OrderInfo INNER JOIN Room_OrderedProduct ON Room_OrderInfo.Id = Room_OrderedProduct.BillID INNER JOIN CheckIN_Room ON Room_OrderInfo.CheckInId = Checkin_Room.Cin_ID INNER JOIN Guest ON CheckIN_Room.GuestID = Guest.ID INNER JOIN Room ON CheckIN_Room.RoomID = Room.R_ID where Room_OrderInfo.BillNo='" & txtBillNo.Text & "'"
                        MyCommand1.CommandText = "SELECT * from Hotel"
                        MyCommand.CommandType = CommandType.Text
                        MyCommand1.CommandType = CommandType.Text
                        myDA.SelectCommand = MyCommand
                        myDA1.SelectCommand = MyCommand1
                        myDA.Fill(myDS, "Guest")
                        myDA.Fill(myDS, "Room")
                        myDA.Fill(myDS, "Room_OrderInfo")
                        myDA.Fill(myDS, "CheckIn_Room")
                        myDA.Fill(myDS, "Room_OrderedProduct")
                        myDA1.Fill(myDS, "Hotel")
                       
                        SendMail(rdr.GetValue(0), GID, "Please find the attachment below", pdfFile, "Room Services Invoice", rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(0), Decrypt(rdr.GetValue(1)))
                        If (rdr IsNot Nothing) Then
                            rdr.Close()
                        End If
                    End If
                End If
            End If
            btnSave.Enabled = False
            MessageBox.Show("Successfully Placed", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from Room_OrderInfo where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                LedgerDelete(txtBillNo.Text, "Room Services")
                LedgerDelete(txtBillNo.Text, "Payment")
                Dim st As String = "deleted the record having bill no '" & txtBillNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtQty_Liquor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty_Liquor.TextChanged
        Compute1()
    End Sub

    Private Sub txtTotalPayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalPayment.TextChanged
        Compute3()
    End Sub

    Private Sub txtTotalPayment_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTotalPayment.Validating
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtGuestID.Text)) = 0 Then
            MessageBox.Show("Please retrieve guest info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnListOfGuest.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 And DataGridView2.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtTotalPayment.Text)) = 0 Then
            MessageBox.Show("Please enter total payment", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalPayment.Focus()
            Exit Sub
        End If
        If Val(txtTotalPayment.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total payment can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtTotalPayment.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select Status from CheckIn_Room where Checkin_Room.Cin_ID=" & txtCheckedInID.Text & " and Status='Checked out'"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Updating record is not possible" & vbCrLf & "Guest is already checked out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Room_OrderInfo set CheckinID=" & txtCheckedInID.Text & ",GrandTotal=" & txtGrandTotal.Text & ",TotalPayment=" & txtTotalPayment.Text & ",PaymentDue=" & txtPaymentDue.Text & " where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            LedgerUpdate(dtpBillDate.Value.Date, "Cash Account", 0, Val(txtTotalPayment.Text), txtGuestID.Text, txtBillNo.Text, "Payment")
            Dim st As String = "updated the record having bill no '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmOrdersList.lblSet.Text = "Order"
        frmOrdersList.Reset()
        frmOrdersList.ShowDialog()
    End Sub

    Private Sub txtQty_Liquor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty_Liquor.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtQty_Food_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty_Food.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If txtRestrict.Text = "Not Allowed" Then
            btnRemove.Enabled = False
        Else
            btnRemove.Enabled = True
        End If

    End Sub

    Private Sub DataGridView2_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        If txtRestrict.Text = "Not Allowed" Then
            btnRemove1.Enabled = False
        Else
            btnRemove1.Enabled = True
        End If
    End Sub


    Sub Remove()
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food() + GrandTotal_Liquor()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute3()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food() + GrandTotal_Liquor()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute3()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRemove1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove1.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = GrandTotal_Food() + GrandTotal_Liquor()
            k = Math.Round(k, 2)
            txtGrandTotal.Text = k
            Compute3()
            btnRemove1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Print()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub cmbPaymentMode_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPaymentMode.SelectedIndexChanged
        If cmbPaymentMode.Text = "Credit Order" Then
            txtTotalPayment.Text = "0.00"
            txtTotalPayment.ReadOnly = True
            txtTotalPayment.Enabled = False
        Else
            txtTotalPayment.Text = "0.00"
            txtTotalPayment.ReadOnly = False
            txtTotalPayment.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm tt")
    End Sub

    Private Sub txtRate_Food_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate_Food.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRate_Food.Text
            Dim selectionStart = Me.txtRate_Food.SelectionStart
            Dim selectionLength = Me.txtRate_Food.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtRate_Liquor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate_Liquor.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtRate_Liquor.Text
            Dim selectionStart = Me.txtRate_Liquor.SelectionStart
            Dim selectionLength = Me.txtRate_Liquor.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtTotalPayment_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPayment.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTotalPayment.Text
            Dim selectionStart = Me.txtTotalPayment.SelectionStart
            Dim selectionLength = Me.txtTotalPayment.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub
End Class
