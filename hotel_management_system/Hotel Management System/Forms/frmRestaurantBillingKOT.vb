Imports System.Data.SqlClient
Public Class frmRestaurantBillingKOT
    Dim num1, num2, num3, num4, num5, num6 As Double
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillTableNo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TableNo) FROM R_Table where R_Table.TableNo in (Select TableNo from TempRestaurant_OrderInfoKOT) and R_Table.Status='Activate'", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbTableNo1.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTableNo1.Items.Add(drow(0).ToString())
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillTableNo1()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TableNo) FROM R_Table where R_Table.TableNo not in (Select TableNo from TempRestaurant_OrderInfoKOT) and R_Table.Status='Activate'", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbTableNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTableNo.Items.Add(drow(0).ToString())
            Next

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
    Sub fillTakenFrom()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Volumn) FROM Stock", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbTakenOut.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTakenOut.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillLiquorName()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(LiquorName) FROM Liquor_Rate", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbLiquorName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbLiquorName.Items.Add(drow(0).ToString())
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
        txtTicketID.Text = ""
        txtTicketNo.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountAmount_Liquor.Text = ""
        txtDiscountPer_Food.Text = ""
        txtDiscountPer_Liquor.Text = ""
        txtSubTotal_Food.Text = ""
        txtQty_Food.Text = ""
        txtQty_Liquor.Text = ""
        txtRate_Food.Text = ""
        txtRate_Liquor.Text = ""
        txtServiceTaxAmount_Food.Text = ""
        txtServiceTaxPer_Food.Text = ""
        txtServiceTaxAmount_Liquor.Text = ""
        txtServiceTaxPer_Liquor.Text = ""
        txtVATAmt_Food.Text = ""
        txtVATAmt_Liquor.Text = ""
        txtVATPer_Food.Text = ""
        txtVATPer_Liquor.Text = ""
        cmbFoodName.Text = ""
        txtGrandTotal.Text = ""
        cmbLiquorName.Text = ""
        cmbTakenOut.SelectedIndex = -1
        cmbVolumn.Text = ""
        dtpTicketGenDate.Text = Now
        dtpTicketGenDate.Enabled = True
        cmbVolumn.Enabled = False
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        btnPrint.Enabled = False
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnAdd_Food.Enabled = True
        btnAdd_Liquor.Enabled = True
        btnRemove.Enabled = False
        btnRemove1.Enabled = False
        txtRestrict.Text = ""
        cmbTableNo.Text = ""
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub frmOrder1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillFoodName()
        fillLiquorName()
        fillTakenFrom()
        fillTableNo1()
        fillTableNo()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd_Food.Click
        Try
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
                DataGridView1.Rows.Add(cmbFoodName.Text, txtRate_Food.Text, txtQty_Food.Text, txtAmt_Food.Text, txtDiscountPer_Food.Text, txtDiscountAmount_Food.Text, txtServiceTaxPer_Food.Text, txtServiceTaxAmount_Food.Text, txtVATPer_Food.Text, txtVATAmt_Food.Text, txtTotalAmt_Food.Text)
                Dim k As Double = 0
                k = GrandTotal_Food() + GrandTotal_Liquor()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                Clear()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If r.Cells(0).Value = cmbFoodName.Text Then
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
            DataGridView1.Rows.Add(cmbFoodName.Text, txtRate_Food.Text, txtQty_Food.Text, txtAmt_Food.Text, txtDiscountPer_Food.Text, txtDiscountAmount_Food.Text, txtServiceTaxPer_Food.Text, txtServiceTaxAmount_Food.Text, txtVATPer_Food.Text, txtVATAmt_Food.Text, txtTotalAmt_Food.Text)
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
    Public Function GrandTotal_Food1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView3.Rows
                sum = sum + r.Cells(11).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function GrandTotal_Liquor1() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView4.Rows
                sum = sum + r.Cells(13).Value
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
                DataGridView2.Rows.Add(cmbLiquorName.Text, cmbVolumn.Text, txtRate_Liquor.Text, cmbTakenOut.Text, txtQty_Liquor.Text, txtAmt_Liquor.Text, txtDiscountPer_Liquor.Text, txtDiscountAmount_Liquor.Text, txtServiceTaxPer_Liquor.Text, txtServiceTaxAmount_Liquor.Text, txtVATPer_Liquor.Text, txtVATAmt_Liquor.Text, txtTotalAmt_Liquor.Text)
                Dim k As Double = 0
                k = GrandTotal_Liquor() + GrandTotal_Food()
                k = Math.Round(k, 2)
                txtGrandTotal.Text = k
                Clear1()
                Clear1()
                Exit Sub
            End If
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells(0).Value = cmbLiquorName.Text And r.Cells(1).Value = cmbVolumn.Text Then
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
            DataGridView2.Rows.Add(cmbLiquorName.Text, cmbVolumn.Text, txtRate_Liquor.Text, cmbTakenOut.Text, txtQty_Liquor.Text, txtAmt_Liquor.Text, txtDiscountPer_Liquor.Text, txtDiscountAmount_Liquor.Text, txtServiceTaxPer_Liquor.Text, txtServiceTaxAmount_Liquor.Text, txtVATPer_Liquor.Text, txtVATAmt_Liquor.Text, txtTotalAmt_Liquor.Text)
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
    Private Sub auto1()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Restaurant_BillingInfoKOT")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            txtBillno.Text = "RB-" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            txtBillno.Text = "RB-" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Restaurant_OrderInfoKOT")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtTicketID.Text = Num.ToString
            txtTicketNo.Text = "KOT-" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtTicketID.Text = Num.ToString
            txtTicketNo.Text = "KOT-" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If cmbTableNo.Text = "" Then
                MessageBox.Show("Please select table", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbTableNo.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 And DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
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
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Restaurant_OrderInfoKOT( Id,TicketNo, BillDate, GrandTotal,tableNo) Values (" & txtTicketID.Text & ",'" & txtTicketNo.Text & "',@d2," & txtGrandTotal.Text & ",@d1)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", cmbTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpTicketGenDate.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "insert into TempRestaurant_OrderInfoKOT( Id, TicketNo, BillDate, GrandTotal,tableNo) Values (" & txtTicketID.Text & ",'" & txtTicketNo.Text & "',@d2," & txtGrandTotal.Text & ",@d1)"
            cmd = New SqlCommand(cl)
            cmd.Parameters.AddWithValue("@d1", cmbTableNo.Text)
            cmd.Parameters.AddWithValue("@d2", dtpTicketGenDate.Text)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Restaurant_OrderedProductKOT(TicketID,Volumn, TakenFrom,Dish_Liquor,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtTicketID.Text & ",0,0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "insert into TempRestaurant_OrderedProductKOT(TicketID,Volumn, TakenFrom,Dish_Liquor,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtTicketID.Text & ",0,0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Restaurant_OrderedProductKOT(TicketID,Dish_Liquor,Volumn,Rate,TakenFrom,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtTicketID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    cmd.Parameters.AddWithValue("@d13", row.Cells(12).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "insert into TempRestaurant_OrderedProductKOT(TicketID,Dish_Liquor,Volumn,Rate,TakenFrom,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtTicketID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    cmd.Parameters.AddWithValue("@d13", row.Cells(12).Value)
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
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant billing record having ticket no. '" & txtTicketNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnSave.Enabled = False
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            fillTableNo()
            fillTableNo1()
            Print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from Restaurant_OrderInfo where ID=" & txtTicketID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Open()
            Dim ct1 As String = "delete from TempRestaurant_OrderInfo where ID=" & txtTicketID.Text & ""
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                Dim st As String = "deleted the restaurant billing record having ticket no. '" & txtTicketNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                fillTableNo()
                fillTableNo1()
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

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmRestaurantBillingKOTRecord.GetData()
        frmRestaurantBillingKOTRecord.ShowDialog()
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
            btnRemove1.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantBillingKOTInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Restaurant_OrderedProductKOT.OP_ID, Restaurant_OrderedProductKOT.TicketID, Restaurant_OrderedProductKOT.Dish_Liquor, Restaurant_OrderedProductKOT.Volumn, Restaurant_OrderedProductKOT.VATPer,Restaurant_OrderedProductKOT.VATAmount, Restaurant_OrderedProductKOT.STPer, Restaurant_OrderedProductKOT.STAmount, Restaurant_OrderedProductKOT.DiscountPer, Restaurant_OrderedProductKOT.DiscountAmount,Restaurant_OrderedProductKOT.Rate, Restaurant_OrderedProductKOT.Quantity, Restaurant_OrderedProductKOT.Amount, Restaurant_OrderedProductKOT.TakenFrom, Restaurant_OrderedProductKOT.TotalAmount,Restaurant_OrderInfoKOT.ID, Restaurant_OrderInfoKOT.TicketNo,Restaurant_OrderInfoKOT.TableNo, Restaurant_OrderInfoKOT.BillDate, Restaurant_OrderInfoKOT.GrandTotal FROM Restaurant_OrderedProductKOT INNER JOIN  Restaurant_OrderInfoKOT ON Restaurant_OrderedProductKOT.TicketID = Restaurant_OrderInfoKOT.ID where Restaurant_OrderInfoKOT.TicketNo='" & txtTicketNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Restaurant_OrderInfoKOT")
            myDA.Fill(myDS, "Restaurant_OrderedProductKOT")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print1()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantFinalBillKOTInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Restaurant_OrderedProductBillKOT.OP_ID, Restaurant_OrderedProductBillKOT.BillID, Restaurant_OrderedProductBillKOT.Dish_Liquor, Restaurant_OrderedProductBillKOT.Volumn, Restaurant_OrderedProductBillKOT.VATPer,Restaurant_OrderedProductBillKOT.VATAmount, Restaurant_OrderedProductBillKOT.STPer, Restaurant_OrderedProductBillKOT.STAmount, Restaurant_OrderedProductBillKOT.DiscountPer, Restaurant_OrderedProductBillKOT.DiscountAmount,Restaurant_OrderedProductBillKOT.Rate, Restaurant_OrderedProductBillKOT.Quantity, Restaurant_OrderedProductBillKOT.Amount, Restaurant_OrderedProductBillKOT.TakenFrom, Restaurant_OrderedProductBillKOT.TotalAmount,Restaurant_BillingInfoKOT.ID, Restaurant_BillingInfoKOT.BillNo,Restaurant_OrderedProductBillKOT.TableNo, Restaurant_BillingInfoKOT.BillDate, Restaurant_BillingInfoKOT.GrandTotal FROM Restaurant_OrderedProductBillKOT INNER JOIN  Restaurant_BillingInfoKOT ON Restaurant_OrderedProductBillKOT.BillID = Restaurant_BillingInfoKOT.ID where Restaurant_BillingInfoKOT.BillNo='" & txtBillno.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Restaurant_BillingInfoKOT")
            myDA.Fill(myDS, "Restaurant_OrderedProductBillKOT")
            myDA1.Fill(myDS, "Hotel")
            rpt.SetDataSource(myDS)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
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

    Private Sub TabControl1_Click(sender As System.Object, e As System.EventArgs) Handles TabControl1.Click
        fillTableNo1()
        fillTableNo()
    End Sub

    Private Sub btnClose1_Click(sender As System.Object, e As System.EventArgs) Handles btnClose1.Click
        Me.Close()
    End Sub
    Sub Reset1()
        txtBillno.Text = ""
        dtpBillDate.Text = Now
        txtGrandTotal1.Text = ""
        txtCash.Text = ""
        txtChange.Text = ""
        cmbTableNo1.SelectedIndex = -1
        DataGridView3.Rows.Clear()
        DataGridView4.Rows.Clear()
        btnPrint1.Enabled = False
        btnSave1.Enabled = True
        btnDelete1.Enabled = False
        dtpBillDate.Enabled = True
        cmbTableNo1.Enabled = True
        txtRestrict.Text = ""
        auto1()
    End Sub
    Private Sub btnNew1_Click(sender As System.Object, e As System.EventArgs) Handles btnNew1.Click
        Reset1()
    End Sub

    Private Sub btnSave1_Click(sender As System.Object, e As System.EventArgs) Handles btnSave1.Click
        Try
            If DataGridView3.Rows.Count = 0 And DataGridView4.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtCash.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Restaurant_BillingInfoKOT( Id,BillNo, BillDate, GrandTotal,Cash,Change) Values (" & txtBillID.Text & ",'" & txtBillno.Text & "',@d1," & txtGrandTotal1.Text & "," & txtCash.Text & "," & txtChange.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", dtpBillDate.Value)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Restaurant_OrderedProductBillKOT(BillID,Volumn, TakenFrom,TableNo,Dish_Liquor,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount) VALUES (" & txtBillID.Text & ",0,0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView3.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Restaurant_OrderedProductBillKOT(BillID,Tableno,Dish_Liquor,Volumn,Rate,TakenFrom,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView4.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    cmd.Parameters.AddWithValue("@d13", row.Cells(12).Value)
                    cmd.Parameters.AddWithValue("@d14", row.Cells(13).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new restaurant billing record having bill no. '" & txtBillno.Text & "'"
            LogFunc(lblUser.Text, st)
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "Delete from TempRestaurant_OrderInfoKOT where TableNo=@d1"
            cmd = New SqlCommand(cb4)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView3.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb5 As String = "Delete from TempRestaurant_OrderInfoKOT where TableNo=@d1"
            cmd = New SqlCommand(cb5)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView4.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            fillTableNo()
            fillTableNo1()
            btnSave1.Enabled = False
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print1()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbTableNo1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTableNo1.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select RTRIM(TableNo),RTRIM(Dish_Liquor),RTRIM(Rate),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from TempRestaurant_OrderedProductKOT,TempRestaurant_OrderInfoKOT where TempRestaurant_OrderedProductKOT.TicketID=TempRestaurant_OrderInfoKOT.ID and TableNo=@d1 order by TableNo"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbTableNo1.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView3.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView3.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
            End While
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "Select RTRIM(TableNo),RTRIM(Dish_Liquor),RTRIM(Volumn),RTRIM(Rate),RTRIM(TakenFrom),RTRIM(Quantity),RTRIM(Amount),RTRIM(DiscountPer), RTRIM(DiscountAmount), RTRIM(STPer), RTRIM(STAmount), RTRIM(VATPer), RTRIM(VATAmount),RTRIM(TotalAmount) from TempRestaurant_OrderedProductKOT,TempRestaurant_OrderInfoKOT where TempRestaurant_OrderedProductKOT.TicketID=TempRestaurant_OrderInfoKOT.ID and TableNo=@d1 and Volumn > 0 order by TableNo"
            cmd = New SqlCommand(sql1, con)
            cmd.Parameters.AddWithValue("@d1", cmbTableNo1.Text)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView4.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView4.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))

            End While
            con.Close()
            txtGrandTotal1.Text = GrandTotal_Food1() + GrandTotal_Liquor1()
            Cal()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Cal()
        txtChange.Text = Val(txtCash.Text) - Val(txtGrandTotal1.Text)
    End Sub

    Private Sub txtCash_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCash.TextChanged
        Cal()
    End Sub

    Private Sub btnDelete1_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete1.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord1()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from Restaurant_BillingInfoKOT where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
                Dim st As String = "deleted the restaurant billing record having bill no. '" & txtBillno.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset1()
                Reset1()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset1()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData1_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData1.Click
        frmRestaurantKOTBillRecord.Reset()
        frmRestaurantKOTBillRecord.ShowDialog()
    End Sub

    Private Sub btnPrint1_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint1.Click
        Print1()
    End Sub
End Class
