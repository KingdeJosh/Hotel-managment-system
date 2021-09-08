Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Security.Cryptography
Imports System.Text
Public Class frmBeer
    Private Const STR_PleaseEnterBeerName As String = "Please enter beer name"
    Private Const STR_PleaseEnterRate As String = "Please enter rate"
    Private Const STR_SelectBeernameFromBeerWhereBeerName As String = "select beername from beer where BeerName='"
    Private Const STR_BearNameAlreadyExists As String = "Bear name already exists"
    Private Const STR_InsertIntoBeerIDBeerNameRateVALUES As String = "insert into Beer(ID,BeerName, Rate) VALUES ('"
    Private Const STR_SuccessfullySaved As String = "Record Successfully saved"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromBeerWhereID As String = "delete from Beer where ID='"
    Private Const STR_SuccessfullyDeleted As String = "Record Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_SELECTDistinctBeernameFROMBeer As String = "SELECT distinct Beername FROM Beer"
    Private Const STR_UpdateBeerSetBeerName As String = "update Beer set BeerName='"
    Private Const STR_SuccessfullyUpdated As String = "The Record is Successfully updated"
    Private Const STR_SELECTFromBeerOrderByBeerName As String = "SELECT * from Beer order by BeerName"
    Private Const STR_SELECTFromBeerWhereBeerNameLike As String = "SELECT * from Beer where BeerName like '"








    Private Sub auto()
        txtID.Text = "B-" & GetUniqueKey(3)

    End Sub
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function
    Sub Reset()
        txtBeerName.Text = ""
        txtRate.Text = ""
        txtBeer.Text = ""
        btnSave.Enabled = True
        btnUpdate_record.Enabled = False
        btnDelete.Enabled = False
        txtBeerName.Focus()
    End Sub

    Private Sub frmBeer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        GetData()
        Autocomplete()
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim(txtBeerName.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterBeerName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtBeerName.Focus()
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
            Dim ct As String = STR_SelectBeernameFromBeerWhereBeerName & txtBeerName.Text & "'"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show(STR_BearNameAlreadyExists, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBeerName.Text = ""
                txtBeerName.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            auto()
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_InsertIntoBeerIDBeerNameRateVALUES & txtID.Text & "','" & txtBeerName.Text & "'," & txtRate.Text & ")"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullySaved, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Autocomplete()
            btnSave.Enabled = False
            GetData()
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
            Dim cq As String = STR_DeleteFromBeerWhereID & txtID.Text & "'"
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show(STR_SuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Autocomplete()
                Reset()
                GetData()
            Else
                MessageBox.Show(STR_NoRecordFound, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Autocomplete()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim cmd As New OleDbCommand(STR_SELECTDistinctBeernameFROMBeer, con)
            Dim ds As New DataSet()
            Dim da As New OleDbDataAdapter(cmd)
            da.Fill(ds, "Beer")
            Dim col As New AutoCompleteStringCollection()
            Dim i As Integer = 0
            For i = 0 To ds.Tables(0).Rows.Count - 1
                col.Add(ds.Tables(0).Rows(i)("BeerName").ToString())
            Next
            txtBeerName.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtBeerName.AutoCompleteCustomSource = col
            txtBeerName.AutoCompleteMode = AutoCompleteMode.Suggest
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUpdate_record_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate_record.Click
        Try
            If Len(Trim(txtBeerName.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterBeerName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtBeerName.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRate.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterRate, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtRate.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_UpdateBeerSetBeerName & txtBeerName.Text & "',Rate = " & txtRate.Text & " where ID= '" & txtID.Text & "'"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullyUpdated, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate_record.Enabled = False
            Autocomplete()
            GetData()
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
            cmd = New OleDbCommand(STR_SELECTFromBeerOrderByBeerName, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2))
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
            txtBeerName.Text = dr.Cells(1).Value.ToString()
            txtRate.Text = dr.Cells(2).Value.ToString()
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


    

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub
    Sub GetData1()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromBeerWhereBeerNameLike & txtBeer.Text & "%' order by BeerName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtBeer_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtBeer.TextChanged
        GetData1()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        frmMainMenu.Show()
    End Sub
End Class