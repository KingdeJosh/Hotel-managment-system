Imports System.Data.SqlClient

Imports System.IO

Public Class frmGuestRecord

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest order by GuestName", con)
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
        txtCity.Text = ""
        txtContactNo.Text = ""
        GetData()
    End Sub

    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
            frmGuest.txtG_Name.Text = dr.Cells(2).Value.ToString()
            frmGuest.cmbGender.Text = dr.Cells(3).Value.ToString()
            frmGuest.cmbReligion.Text = dr.Cells(4).Value.ToString()
            frmGuest.txtOccupation.Text = dr.Cells(5).Value.ToString()
            frmGuest.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
            frmGuest.txtGuestCity.Text = dr.Cells(7).Value.ToString()
            frmGuest.cmbCountry.Text = dr.Cells(8).Value.ToString()
            frmGuest.txtGuestContactNo.Text = dr.Cells(9).Value.ToString()
            frmGuest.txtEmailID.Text = dr.Cells(10).Value.ToString()
            frmGuest.cmbIDType.Text = dr.Cells(11).Value.ToString()
            frmGuest.txtIDNumber.Text = dr.Cells(12).Value.ToString()
            frmGuest.cmbCompany.Text = dr.Cells(13).Value.ToString()
            frmGuest.cmbModel.Text = dr.Cells(14).Value.ToString()
            frmGuest.txtVehicleNo.Text = dr.Cells(15).Value.ToString()
            frmGuest.txtColor.Text = dr.Cells(16).Value.ToString()
            frmGuest.txtNotes.Text = dr.Cells(17).Value.ToString()

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
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Pic1,Pic2,Pic3 from Guest where Guest.ID=" & dr.Cells(0).Value & "", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                Dim data As Byte() = DirectCast(rdr.GetValue(0), Byte())
                Dim ms As New MemoryStream(data)
                frmGuest.Picture.Image = Image.FromStream(ms)
                Dim data1 As Byte() = DirectCast(rdr.GetValue(1), Byte())
                Dim ms1 As New MemoryStream(data1)
                frmGuest.PictureBox1.Image = Image.FromStream(ms1)
                Dim data2 As Byte() = DirectCast(rdr.GetValue(2), Byte())
                Dim ms2 As New MemoryStream(data2)
                frmGuest.PictureBox2.Image = Image.FromStream(ms2)
            End If
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
        Dim b As Brush = SystemBrushes.ControlLightLight
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest where GuestName like '%" & txtGuestName.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCity_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCity.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest where City like '%" & txtCity.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(Country) as [Country],RTRIM(ContactNo) as [Contact No],RTRIM(Email) as [Email],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Company) as [Company],RTRIM(Model) as [Model],RTRIM(VehicleNo) as [Vehicle No.],RTRIM(Color) as [Color],RTRIM(Notes) as [Notes] from Guest where ContactNo like '%" & txtContactNo.Text & "%' order by GuestName", con)
            Dim myDA As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim myDataSet As DataSet = New DataSet()
            myDA.Fill(myDataSet, "Guest")
            dgw.DataSource = myDataSet.Tables("Guest").DefaultView
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Reset()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class
