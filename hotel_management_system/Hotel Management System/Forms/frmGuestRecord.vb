Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmGuestRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(ContactNo) as [Contact No],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Notes) as [Notes],Pic1,pic2,pic3 from Guest order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub
    Sub Reset()
        txtGuestName.Text = ""
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            Dim dr As DataGridViewRow = dgw.SelectedRows(0)
            Me.Hide()
            frmGuest.Show()
            ' or simply use column name instead of index
            'dr.Cells["id"].Value.ToString();
            frmGuest.txtID.Text = dr.Cells(0).Value.ToString()
            frmGuest.txtGuestID.Text = dr.Cells(1).Value.ToString()
            frmGuest.txtGuestName.Text = dr.Cells(2).Value.ToString()
            frmGuest.cmbGender.Text = dr.Cells(3).Value.ToString()
            frmGuest.cmbReligion.Text = dr.Cells(4).Value.ToString()
            frmGuest.txtOccupation.Text = dr.Cells(5).Value.ToString()
            frmGuest.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
            frmGuest.txtGuestCity.Text = dr.Cells(7).Value.ToString()
            frmGuest.txtGuestContactNo.Text = dr.Cells(8).Value.ToString()
            frmGuest.cmbIDType.Text = dr.Cells(9).Value.ToString()
            frmGuest.txtIDNumber.Text = dr.Cells(10).Value.ToString()
            frmGuest.txtNotes.Text = dr.Cells(11).Value.ToString()
            Dim data3 As Byte() = DirectCast(dr.Cells(12).Value, Byte())
            Dim ms3 As New MemoryStream(data3)
            frmGuest.Picture.Image = Image.FromStream(ms3)
            Dim data4 As Byte() = DirectCast(dr.Cells(13).Value, Byte())
            Dim ms4 As New MemoryStream(data4)
            frmGuest.PictureBox2.Image = Image.FromStream(ms4)
            Dim data5 As Byte() = DirectCast(dr.Cells(14).Value, Byte())
            Dim ms5 As New MemoryStream(data5)
            frmGuest.PictureBox1.Image = Image.FromStream(ms5)
            frmGuest.btnUpdate.Enabled = True
            frmGuest.btnDelete.Enabled = True
            frmGuest.btnSave.Enabled = False
            frmGuest.btnPrint.Enabled = True
            frmGuest.txtGuestName.Focus()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Image1,Image2,Image3 from Guest,Guest_Docs where Guest.ID=Guest_Docs.GuestID and Guest.GuestID='" & dr.Cells(1).Value & "'", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            frmGuest.dgw.Rows.Clear()
            While (rdr.Read() = True)
                Dim img4, img5, img6 As Image
                Dim data As Byte() = DirectCast(rdr(0), Byte())
                Dim ms As New MemoryStream(data)
                img4 = Image.FromStream(ms)
                Dim data1 As Byte() = DirectCast(rdr(1), Byte())
                Dim ms1 As New MemoryStream(data1)
                img5 = Image.FromStream(ms1)
                Dim data2 As Byte() = DirectCast(rdr(2), Byte())
                Dim ms2 As New MemoryStream(data2)
                img6 = Image.FromStream(ms2)
                frmGuest.dgw.Rows.Add(img4, img5, img6)
            End While
            con.Close()
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
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(ContactNo) as [Contact No],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Notes) as [Notes],Pic1,pic2,pic3 from Guest where GuestName like '" & txtGuestName.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
