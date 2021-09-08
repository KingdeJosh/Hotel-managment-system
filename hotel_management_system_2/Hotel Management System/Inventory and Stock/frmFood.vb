Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmFood
    Private Const STR_SELECTDistinctCategoryFROMDish As String = "SELECT distinct (Category) FROM Dish"
    Private Const STR_PleaseEnterFoodName As String = "Please enter food name"
    Private Const STR_PleaseEnterselectCategory As String = "Please enter/select category"
    Private Const STR_PleaseEnterRate As String = "Please enter rate"
    Private Const STR_SelectDishnameFromDishWhereDishName As String = "select Dishname from dish where DishName='"
    Private Const STR_DishNameAlreadyExists As String = "Dish Name Already Exists"
    Private Const STR_InsertIntoDishDishNameCategoryRateVALUES As String = "insert into Dish(DishName, Category, Rate) VALUES ('"
    Private Const STR_SuccessfullySaved As String = "Successfully saved"
    Private Const STR_SELECTDistinctDishnameFROMDish As String = "SELECT distinct Dishname FROM Dish"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromDishWhereID As String = "delete from Dish where ID="
    Private Const STR_SuccessfullyDeleted As String = "Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_UpdateDishSetDishName As String = "update Dish set DishName='"
    Private Const STR_SuccessfullyUpdated As String = "Successfully updated"
    Private Const STR_SELECTFromDishOrderByDishName As String = "SELECT * from Dish order by DishName"
    Private Const STR_SELECTFromDishWhereDishNameLike As String = "SELECT * from Dish where DishName like '"









    Sub Reset()
        txtDishName.Text = ""
        txtRate.Text = ""
        cmbCategory.Text = ""
        txtDishes.Text = ""
        btnSave.Enabled = True
        btnUpdate_record.Enabled = False
        btnDelete.Enabled = False
        txtDishName.Focus()
    End Sub
    Sub FillCategory()
        Try
            Dim CN As New OleDbConnection(cs)
            CN.Open()
            adp = New OleDbDataAdapter()
            adp.SelectCommand = New OleDbCommand(STR_SELECTDistinctCategoryFROMDish, CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmDish_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        GetData()
        FillCategory()
        Autocomplete()
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim(txtDishName.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterFoodName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDishName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbCategory.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterselectCategory, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cmbCategory.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRate.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterRate, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRate.Focus()
            Exit Sub
        End If
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = STR_SelectDishnameFromDishWhereDishName & txtDishName.Text & "'"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show(STR_DishNameAlreadyExists, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDishName.Text = ""
                txtDishName.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_InsertIntoDishDishNameCategoryRateVALUES & txtDishName.Text & "','" & cmbCategory.Text & "'," & txtRate.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullySaved, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Autocomplete()
            btnSave.Enabled = False
            GetData()
            FillCategory()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Autocomplete()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim cmd As New OleDbCommand(STR_SELECTDistinctDishnameFROMDish, con)
            Dim ds As New DataSet()
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(ds, "Dish")
            Dim col As New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("DishName").ToString())
            Next
            txtDishName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtDishName.AutoCompleteCustomSource = col
            txtDishName.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show(STR_DoYouReallyWantToDeleteThisRecord, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New OleDbConnection(cs)
            con.Open()
            Dim cq As String = STR_DeleteFromDishWhereID & txtID.Text & ""
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show(STR_SuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Autocomplete()
                Reset()
                GetData()
                FillCategory()
            Else
                MessageBox.Show(STR_NoRecordFound, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate_record.Click
        Try
            If Len(Trim(txtDishName.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterFoodName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtDishName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCategory.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterselectCategory, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbCategory.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRate.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterRate, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRate.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_UpdateDishSetDishName & txtDishName.Text & "',Category='" & cmbCategory.Text & "',Rate = " & txtRate.Text & " where ID= " & txtID.Text & ""
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullyUpdated, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate_record.Enabled = False
            Autocomplete()
            GetData()
            FillCategory()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRate_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtRate.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromDishOrderByDishName, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtID.Text = dr.Cells(0).Value.ToString()
            txtDishName.Text = dr.Cells(1).Value.ToString()
            cmbCategory.Text = dr.Cells(2).Value.ToString()
            txtRate.Text = dr.Cells(3).Value.ToString()
            btnDelete.Enabled = True
            btnUpdate_record.Enabled = True
            btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtDishes_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDishes.TextChanged
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromDishWhereDishNameLike & txtDishes.Text & "%' order by DishName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
        frmMainMenu.Show()
    End Sub
End Class