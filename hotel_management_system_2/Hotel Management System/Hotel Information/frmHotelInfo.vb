Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmHotelInfo
    Private Const STR_PleaseEnterHotelName As String = "Please enter hotel name"
    Private Const STR_PleaseEnterAddress As String = "Please enter address"
    Private Const STR_PleaseEnterContactNo As String = "Please enter contact no."
    Private Const STR_SelectCountFromHotelInfoHavingCount1 As String = "select count(*) from HotelInfo Having count(*) >= 1"
    Private Const STR_RecordAlreadyExists As String = "Record Already Exists"
    Private Const STR_InsertIntoHotelInfoHotelNameAddressContactNoCont As String = "insert into HotelInfo( HotelName, Address, ContactNo, ContactNo1, Email, TIN, STNo, Logo) VALUES ('"
    Private Const STR_SuccessfullySaved As String = "Hotel Information Successfully saved"
    Private Const STR_DoYouReallyWantToDeleteThisRecord As String = "Do you really want to delete this record?"
    Private Const STR_DeleteFromHotelInfoWhereID As String = "delete from HotelInfo where ID="
    Private Const STR_SuccessfullyDeleted As String = "Record Successfully deleted"
    Private Const STR_NoRecordFound As String = "No record found"
    Private Const STR_UpdateHotelInfoSetHotelName As String = "Update HotelInfo set  HotelName='"
    Private Const STR_SuccessfullyUpdated As String = "Record Successfully updated"
    Private Const STR_SELECTFromHotelInfo As String = "SELECT * from HotelInfo"
    Private Const STR_ImagesPngBmpJpgjpegGifico As String = "Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;*.ico;"









    Sub Reset()
        txtHotelName.Text = ""
        txtAltContactNo.Text = ""
        txtContactNo.Text = ""
        txtAddress.Text = ""
        txtServiceTaxNo.Text = ""
        txtTIN.Text = ""
        txtEmailID.Text = ""
        btnSave.Enabled = True
        PictureBox1.Image = My.Resources.Resources._12
        btnUpdate_record.Enabled = False
        btnDelete.Enabled = False
        txtHotelName.Focus()
    End Sub


    Private Sub btnNewRecord_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Len(Trim(txtHotelName.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterHotelName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHotelName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterAddress, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterContactNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactNo.Focus()
            Exit Sub
        End If
        Try
            con = New OleDbConnection(cs)
            con.Open()
            Dim ct As String = STR_SelectCountFromHotelInfoHavingCount1
            cmd = New OleDbCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show(STR_RecordAlreadyExists & vbCrLf & "please update the Hotel Info", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_InsertIntoHotelInfoHotelNameAddressContactNoCont & txtHotelName.Text & "','" & txtAddress.Text & "','" & txtContactNo.Text & "','" & txtAltContactNo.Text & "','" & txtEmailID.Text & "','" & txtTIN.Text & "','" & txtServiceTaxNo.Text & "',@d1)"
            cmd = New OleDbCommand(cb)
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New OleDbParameter("@d1", OleDbType.VarBinary)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            con.Close()
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
            Dim cq As String = STR_DeleteFromHotelInfoWhereID & txtID.Text & ""
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
        If Len(Trim(txtHotelName.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterHotelName, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtHotelName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtAddress.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterAddress, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Exit Sub
        End If
        If Len(Trim(txtContactNo.Text)) = 0 Then
            MessageBox.Show(STR_PleaseEnterContactNo, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactNo.Focus()
            Exit Sub
        End If
        Try
           
            con = New OleDbConnection(cs)
            con.Open()
            Dim cb As String = STR_UpdateHotelInfoSetHotelName & txtHotelName.Text & "', Address='" & txtAddress.Text & "', ContactNo='" & txtContactNo.Text & "', ContactNo1='" & txtAltContactNo.Text & "', Email='" & txtEmailID.Text & "', TIN='" & txtTIN.Text & "', STNo='" & txtServiceTaxNo.Text & "', Logo=@d1 where ID=" & txtID.Text & ""
            cmd = New OleDbCommand(cb)
            cmd.Connection = con
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New OleDbParameter("@d1", OleDbType.VarBinary)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            con.Close()
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
            cmd = New OleDbCommand(STR_SELECTFromHotelInfo, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
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
            txtHotelName.Text = dr.Cells(1).Value.ToString()
            txtAddress.Text = dr.Cells(2).Value.ToString()
            txtContactNo.Text = dr.Cells(3).Value.ToString()
            txtAltContactNo.Text = dr.Cells(4).Value.ToString()
            txtEmailID.Text = dr.Cells(5).Value.ToString()
            txtTIN.Text = dr.Cells(6).Value.ToString()
            txtServiceTaxNo.Text = dr.Cells(7).Value.ToString()
            Dim data As Byte() = DirectCast(dr.Cells(8).Value, Byte())
            Dim ms As New MemoryStream(data)
            PictureBox1.Image = Image.FromStream(ms)
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

    Private Sub frmHotelInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = (STR_ImagesPngBmpJpgjpegGifico)
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        frmMainMenu.Show()
    End Sub
End Class