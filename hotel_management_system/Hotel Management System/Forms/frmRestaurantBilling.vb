Imports System.Data.SqlClient
Public Class frmRestaurantBilling
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
            number = CDbl(Val(txtCash.Text) - Val(txtGrandTotal.Text))
            number = Math.Round(number, 2)
            txtChange.Text = number
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
        txtBillID.Text = ""
        txtBillNo.Text = ""
        txtDiscountAmount_Food.Text = ""
        txtDiscountAmount_Liquor.Text = ""
        txtDiscountPer_Food.Text = ""
        txtDiscountPer_Liquor.Text = ""
        txtSubTotal_Food.Text = ""
        txtChange.Text = ""
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
        txtCash.Text = ""
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
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Restaurant_OrderInfo")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "C" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtBillID.Text = Num.ToString
            txtBillNo.Text = "C" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If DataGridView1.Rows.Count = 0 And DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If txtCash.Text = "" Then
                MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtCash.Focus()
                Exit Sub
            End If
            If Val(txtCash.Text) < Val(txtGrandTotal.Text) Then
                MessageBox.Show("Cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCash.Focus()
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
            Dim cb As String = "insert into Restaurant_OrderInfo( Id, BillNo, BillDate, GrandTotal, Cash, Change) Values (" & txtBillID.Text & ",'" & txtBillNo.Text & "',@d1," & txtGrandTotal.Text & "," & txtCash.Text & "," & txtChange.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", dtpBillDate.Value)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Restaurant_OrderedProduct(BillID,Volumn, TakenFrom,Dish_Liquor,Rate,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtBillID.Text & ",0,0,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
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
            Dim cb2 As String = "insert into Restaurant_OrderedProduct(BillID,Dish_Liquor,Volumn,Rate,TakenFrom,Quantity,Amount,DiscountPer, DiscountAmount, STPer, STAmount, VATPer, VATAmount,TotalAmount ) VALUES (" & txtBillID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
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
            Dim st As String = "added the new record having bill no. '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnSave.Enabled = False
            MessageBox.Show("Successfully done", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Print()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con.Open()
            Dim ct As String = "delete from Restaurant_OrderInfo where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            If RowsAffected > 0 Then
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

    Private Sub txtTotalPayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged
        Compute3()
    End Sub

    Private Sub txtTotalPayment_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCash.Validating
        If Val(txtCash.Text) < Val(txtGrandTotal.Text) Then
            MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If DataGridView1.Rows.Count = 0 And DataGridView2.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtCash.Text = "" Then
            MessageBox.Show("Please enter cash", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCash.Focus()
            Exit Sub
        End If
        If Val(txtCash.Text) < Val(txtGrandTotal.Text) Then
            MessageBox.Show("Cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCash.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update Restaurant_OrderInfo set GrandTotal=" & txtGrandTotal.Text & ",Cash=" & txtCash.Text & ",Change=" & txtChange.Text & " where ID=" & txtBillID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            con.Close()
            Dim st As String = "updated the record having bill no '" & txtBillNo.Text & "'"
            LogFunc(lblUser.Text, st)
            btnUpdate.Enabled = False
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmRestaurantBillingRecord.GetData()
        frmRestaurantBillingRecord.ShowDialog()
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
    Sub Print()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptRestaurantBillingInvoice 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Restaurant_OrderedProduct.OP_ID, Restaurant_OrderedProduct.BillID, Restaurant_OrderedProduct.Dish_Liquor, Restaurant_OrderedProduct.Volumn, Restaurant_OrderedProduct.VATPer,Restaurant_OrderedProduct.VATAmount, Restaurant_OrderedProduct.STPer, Restaurant_OrderedProduct.STAmount, Restaurant_OrderedProduct.DiscountPer, Restaurant_OrderedProduct.DiscountAmount,Restaurant_OrderedProduct.Rate, Restaurant_OrderedProduct.Quantity, Restaurant_OrderedProduct.Amount, Restaurant_OrderedProduct.TakenFrom, Restaurant_OrderedProduct.TotalAmount,Restaurant_OrderInfo.ID, Restaurant_OrderInfo.BillNo, Restaurant_OrderInfo.BillDate, Restaurant_OrderInfo.GrandTotal, Restaurant_OrderInfo.Cash, Restaurant_OrderInfo.Change FROM Restaurant_OrderedProduct INNER JOIN  Restaurant_OrderInfo ON Restaurant_OrderedProduct.BillID = Restaurant_OrderInfo.ID where Restaurant_OrderInfo.BillNo='" & txtBillNo.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Restaurant_OrderInfo")
            myDA.Fill(myDS, "Restaurant_OrderedProduct")
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

End Class
