Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmCurrency
    Private Const STR_PleaseEnterCurrency As String = "Please enter currency"
    Private Const STR_SelectCS_CurrencyFromCurrencySetWhereCS_Currency As String = "select CS_Currency from CurrencySet where CS_Currency='"
    Private Const STR_CurrencyNameAlreadyExists As String = "Currency Name Already Exists"
    Private Const STR_InsertIntoCurrencySetCS_CurrencyVALUES As String = "insert into CurrencySet(CS_Currency) VALUES ('"
    Private Const STR_SuccessfullySaved As String = "Currency Successfully saved"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromCurrencySetWhereID As String = "delete from CurrencySet where ID="
    Private Const STR_SuccessfullyDeleted As String = " Record Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_PleaseEnterCurrency1 As String = "Please enter Currency"
    Private Const STR_UpdateCurrencySetSetCS_Currency As String = "update CurrencySet set CS_Currency = '"
    Private Const STR_SuccessfullyUpdated As String = "Record Successfully updated"
    Private Const STR_SELECTFromCurrencySetOrderByCS_Currency As String = "SELECT * from CurrencySet order by CS_Currency "









    Sub Reset()
        txtCurrency.Text = ""
        btnSave.Enabled = True
        btnUpdate_record.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub frmLiquor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        GetData()

    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim(txtCurrency.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterCurrency, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtCurrency.Focus()
            Exit Sub
        End If
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = STR_SelectCS_CurrencyFromCurrencySetWhereCS_Currency & txtCurrency.Text & "'"
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show(STR_CurrencyNameAlreadyExists, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCurrency.Text = ""
                txtCurrency.Focus()
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_InsertIntoCurrencySetCS_CurrencyVALUES & txtCurrency.Text & "')"
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullySaved, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
            Dim cq As String = STR_DeleteFromCurrencySetWhereID & txtID.Text & ""
            cmd = New OleDbCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                MessageBox.Show(STR_SuccessfullyDeleted, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub btnUpdate_record_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate_record.Click
        Try

            If Len(Trim(txtCurrency.Text)) = 0 Then
                MessageBox.Show(STR_PleaseEnterCurrency1, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCurrency.Focus()
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_UpdateCurrencySetSetCS_Currency & txtCurrency.Text & "' where ID= " & txtID.Text & ""
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            MessageBox.Show(STR_SuccessfullyUpdated, "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate_record.Enabled = False

            GetData()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTFromCurrencySetOrderByCS_Currency, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1))
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
            txtCurrency.Text = dr.Cells(1).Value.ToString()
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

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Close()
        frmMainMenu.Show()
    End Sub
End Class