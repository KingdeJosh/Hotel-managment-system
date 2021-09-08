Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmGuest
    Dim Photoname As String = ""
    Dim IsImageChanged As Boolean = False
    Public Sub Reset()
        txtGuestID.Text = ""
        cmbReligion.SelectedIndex = -1
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        cmbIDType.SelectedIndex = -1
        cmbGender.SelectedIndex = -1
        cmbCountry.Text = ""
        txtOccupation.Text = ""
        Picture.Image = My.Resources.photo
        PictureBox1.Image = My.Resources.DOC
        PictureBox2.Image = My.Resources.DOC
        txtIDNumber.Text = ""
        txtEmailID.Text = ""
        txtNotes.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnPrint.Enabled = False
        btnRemove.Enabled = False
        dgw.Rows.Clear()
        auto()
        txtGuestName.Focus()
    End Sub
    Private Sub auto()
        Dim Num As Integer = 0
        con = New SqlConnection(cs)
        con.Open()
        Dim sql As String = ("SELECT MAX(ID) FROM Guest")
        cmd = New SqlCommand(sql)
        cmd.Connection = con
        If (IsDBNull(cmd.ExecuteScalar)) Then
            Num = 1
            txtID.Text = Num.ToString
            txtGuestID.Text = "G" + Num.ToString
        Else
            Num = cmd.ExecuteScalar + 1
            txtID.Text = Num.ToString
            txtGuestID.Text = "G" + Num.ToString
        End If
        cmd.Dispose()
        con.Close()
        con.Dispose()
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestName.Text)) = 0 Then
                MessageBox.Show("Please enter guest name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbGender.Text)) = 0 Then
                MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGender.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbReligion.Text)) = 0 Then
                MessageBox.Show("Please select religion", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbReligion.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOccupation.Text)) = 0 Then
                MessageBox.Show("Please enter occupation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOccupation.Focus()
                Exit Sub
            End If

            If Len(Trim(txtGuestAddress.Text)) = 0 Then
                MessageBox.Show("Please enter guest address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestAddress.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestCity.Text)) = 0 Then
                MessageBox.Show("Please enter guest city", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestCity.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCountry.Text)) = 0 Then
                MessageBox.Show("Please select country", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCountry.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestContactNo.Text)) = 0 Then
                MessageBox.Show("Please enter guest contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestContactNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbIDType.Text)) = 0 Then
                MessageBox.Show("Please select id type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbIDType.Focus()
                Exit Sub
            End If
            If Len(Trim(txtIDNumber.Text)) = 0 Then
                MessageBox.Show("Please enter id number", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtIDNumber.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                MessageBox.Show("Please add documents in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Guest(ID,GuestID, GuestName, Address, City, ContactNo, IDType, IDNumber, Notes,Gender,Religion,Occupation,Company,Model,VehicleNo,Color,Pic1,Pic2,Pic3,Country,Email) VALUES (" & txtID.Text & ",'" & txtGuestID.Text & "',@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d14,@d15,@d16,@d17,@d11,@d12,@d13,@d18,@d19)"
            cmd.Parameters.AddWithValue("@d1", txtGuestName.Text)
            cmd.Parameters.AddWithValue("@d2", txtGuestAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtGuestCity.Text)
            cmd.Parameters.AddWithValue("@d4", txtGuestContactNo.Text)
            cmd.Parameters.AddWithValue("@d5", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@d6", txtIDNumber.Text)
            cmd.Parameters.AddWithValue("@d7", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d8", cmbGender.Text)
            cmd.Parameters.AddWithValue("@d9", cmbReligion.Text)
            cmd.Parameters.AddWithValue("@d10", txtOccupation.Text)
            cmd.Parameters.AddWithValue("@d14", cmbCompany.Text)
            cmd.Parameters.AddWithValue("@d15", cmbModel.Text)
            cmd.Parameters.AddWithValue("@d16", txtVehicleNo.Text)
            cmd.Parameters.AddWithValue("@d17", txtColor.Text)
            cmd.Parameters.AddWithValue("@d18", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@d19", txtEmailID.Text)
             con = New SqlConnection(cs)
            con.Open()
            Dim ck As String = "insert into Guest_Docs(GuestID,Image1,Image2,Image3) VALUES (" & txtID.Text & ",@img,@img1,@img2)"
            cmd = New SqlCommand(ck)
            cmd.Connection = con


            ' Prepare command for repeated execution
            cmd.Prepare()

            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    Dim ms, ms1, ms2 As New MemoryStream()
                    Dim img As Image = row.Cells(0).Value
                    Dim img1 As Image = row.Cells(1).Value
                    Dim img2 As Image = row.Cells(2).Value
                    Dim bmpImage As New Bitmap(img)
                    Dim bmpImage1 As New Bitmap(img1)
                    Dim bmpImage2 As New Bitmap(img2)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    bmpImage1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg)
                    bmpImage2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim data1 As Byte() = ms1.GetBuffer()
                    Dim data2 As Byte() = ms2.GetBuffer()
                    Dim p As New SqlParameter("@img", SqlDbType.Image)
                    Dim p1 As New SqlParameter("@img1", SqlDbType.Image)
                    Dim p2 As New SqlParameter("@img2", SqlDbType.Image)
                    p.Value = data
                    p1.Value = data1
                    p2.Value = data2
                    cmd.Parameters.Add(p)
                    cmd.Parameters.Add(p1)
                    cmd.Parameters.Add(p2)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "added the new guest '" & txtGuestName.Text & "' having guest ID '" & txtGuestID.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            fillCombo()
            btnPrint.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtGuestName.Text)) = 0 Then
                MessageBox.Show("Please enter guest name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbGender.Text)) = 0 Then
                MessageBox.Show("Please select gender", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbGender.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbReligion.Text)) = 0 Then
                MessageBox.Show("Please select religion", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbReligion.Focus()
                Exit Sub
            End If
            If Len(Trim(txtOccupation.Text)) = 0 Then
                MessageBox.Show("Please enter occupation", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOccupation.Focus()
                Exit Sub
            End If

            If Len(Trim(txtGuestAddress.Text)) = 0 Then
                MessageBox.Show("Please enter guest address", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestAddress.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestCity.Text)) = 0 Then
                MessageBox.Show("Please enter guest city", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestCity.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCountry.Text)) = 0 Then
                MessageBox.Show("Please select country", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCountry.Focus()
                Exit Sub
            End If
            If Len(Trim(txtGuestContactNo.Text)) = 0 Then
                MessageBox.Show("Please enter guest contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtGuestContactNo.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbIDType.Text)) = 0 Then
                MessageBox.Show("Please select id type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbIDType.Focus()
                Exit Sub
            End If
            If Len(Trim(txtIDNumber.Text)) = 0 Then
                MessageBox.Show("Please enter id number", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtIDNumber.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                MessageBox.Show("Please add documents in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update LedgerBook set [Name]=@d3 where PartyID=@d1 and Name=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtGuestID.Text)
            cmd.Parameters.AddWithValue("@d2", txtG_Name.Text)
            cmd.Parameters.AddWithValue("@d3", txtGuestName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Guest set GuestID='" & txtGuestID.Text & "', GuestName=@d1, Address=@d2, City=@d3, ContactNo=@d4, IDType=@d5, IDNumber=@d6, Notes=@d7,Gender=@d8,Religion=@d9,Occupation=@d10,Pic1=@d11,Pic2=@d12,Pic3=@d13,Company=@d14,Model=@d15,VehicleNo=@d16,Color=@d17,Country=@d18,Email=@d19 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", txtGuestName.Text)
            cmd.Parameters.AddWithValue("@d2", txtGuestAddress.Text)
            cmd.Parameters.AddWithValue("@d3", txtGuestCity.Text)
            cmd.Parameters.AddWithValue("@d4", txtGuestContactNo.Text)
            cmd.Parameters.AddWithValue("@d5", cmbIDType.Text)
            cmd.Parameters.AddWithValue("@d6", txtIDNumber.Text)
            cmd.Parameters.AddWithValue("@d7", txtNotes.Text)
            cmd.Parameters.AddWithValue("@d8", cmbGender.Text)
            cmd.Parameters.AddWithValue("@d9", cmbReligion.Text)
            cmd.Parameters.AddWithValue("@d10", txtOccupation.Text)
            cmd.Parameters.AddWithValue("@d14", cmbCompany.Text)
            cmd.Parameters.AddWithValue("@d15", cmbModel.Text)
            cmd.Parameters.AddWithValue("@d16", txtVehicleNo.Text)
            cmd.Parameters.AddWithValue("@d17", txtColor.Text)
            cmd.Parameters.AddWithValue("@d18", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@d19", txtEmailID.Text)
            cmd.Connection = con
            Dim ms3, ms4, ms5 As New MemoryStream()
            Dim bmpImage3 As New Bitmap(Picture.Image)
            Dim bmpImage4 As New Bitmap(PictureBox1.Image)
            Dim bmpImage5 As New Bitmap(PictureBox2.Image)
            bmpImage3.Save(ms3, System.Drawing.Imaging.ImageFormat.Jpeg)
            bmpImage4.Save(ms4, System.Drawing.Imaging.ImageFormat.Jpeg)
            bmpImage5.Save(ms5, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data3 As Byte() = ms3.GetBuffer()
            Dim data4 As Byte() = ms4.GetBuffer()
            Dim data5 As Byte() = ms5.GetBuffer()
            Dim p3 As New SqlParameter("@d11", SqlDbType.Image)
            Dim p4 As New SqlParameter("@d12", SqlDbType.Image)
            Dim p5 As New SqlParameter("@d13", SqlDbType.Image)
            p3.Value = data3
            p4.Value = data4
            p5.Value = data5
            cmd.Parameters.Add(p3)
            cmd.Parameters.Add(p4)
            cmd.Parameters.Add(p5)
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cbx As String = "delete from Guest_Docs where GuestID=" & txtID.Text & ""
            cmd = New SqlCommand(cbx)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ck As String = "insert into Guest_Docs(GuestID,Image1,Image2,Image3) VALUES (" & txtID.Text & ",@img,@img1,@img2)"
            cmd = New SqlCommand(ck)
            cmd.Connection = con


            ' Prepare command for repeated execution
            cmd.Prepare()

            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    Dim ms, ms1, ms2 As New MemoryStream()
                    Dim img As Image = row.Cells(0).Value
                    Dim img1 As Image = row.Cells(1).Value
                    Dim img2 As Image = row.Cells(2).Value
                    Dim bmpImage As New Bitmap(img)
                    Dim bmpImage1 As New Bitmap(img1)
                    Dim bmpImage2 As New Bitmap(img2)
                    bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    bmpImage1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg)
                    bmpImage2.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg)
                    Dim data As Byte() = ms.GetBuffer()
                    Dim data1 As Byte() = ms1.GetBuffer()
                    Dim data2 As Byte() = ms2.GetBuffer()
                    Dim p As New SqlParameter("@img", SqlDbType.Image)
                    Dim p1 As New SqlParameter("@img1", SqlDbType.Image)
                    Dim p2 As New SqlParameter("@img2", SqlDbType.Image)
                    p.Value = data
                    p1.Value = data1
                    p2.Value = data2
                    cmd.Parameters.Add(p)
                    cmd.Parameters.Add(p1)
                    cmd.Parameters.Add(p2)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            Dim st As String = "updated the guest having Guest ID '" & txtGuestID.Text & "' record"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            fillCombo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Company),RTRIM(Model) FROM Guest", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCompany.Items.Clear()
            cmbModel.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCompany.Items.Add(drow(0).ToString())
                cmbModel.Items.Add(drow(1).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Browse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Picture.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub BRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRemove.Click
        Picture.Image = My.Resources.photo
    End Sub

    Private Sub BStartCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStartCapture.Click
        Dim k As New frmWeb
        k.ShowDialog()
        If TempFileNames2.Length > 0 Then

            Picture.Image = Image.FromFile(TempFileNames2)
            Photoname = TempFileNames2
            IsImageChanged = True
        End If
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select Guest.ID from Guest,Checkin_Room where Guest.ID=Checkin_Room.GuestID and Guest.ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Check in and Check Out", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "select Guest.ID from Guest,Reservation where Guest.ID=Reservation.Guest_ID and Guest.ID=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Room Reservation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
          
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        btnRemove.Enabled = True
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dgw.Rows.Add(Picture.Image, PictureBox1.Image, PictureBox2.Image)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        frmGuestRecord.Reset()
        frmGuestRecord.ShowDialog()
    End Sub
    Sub fillIDType()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Type) FROM IDType", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbIDType.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbIDType.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillIDType()
        fillCombo()
    End Sub
    Sub Print()
        Try
            Cursor = Cursors.WaitCursor
            Timer2.Enabled = True
            'Dim rpt As New rptGuest 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT Guest.GuestName, Guest.Address, Guest.City, Guest.ContactNo, Guest.Gender, Guest.Occupation,Guest.Country, Guest.Religion, Guest.IDType, Guest.IDNumber, Guest.Notes, Guest_Docs.Id,Guest_Docs.Image1, Guest_Docs.Image2, Guest_Docs.Image3 FROM Guest INNER JOIN Guest_Docs ON Guest.ID = Guest_Docs.GuestID where Guest.GuestID='" & txtGuestID.Text & "'"
            MyCommand1.CommandText = "SELECT * from Hotel"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "Guest")
            myDA.Fill(myDS, "Guest_Docs")
            myDA1.Fill(myDS, "Hotel")
            
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Print()
    End Sub



    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In dgw.SelectedRows
                dgw.Rows.Remove(row)
            Next
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub btnAddCategory_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCategory.Click
        frmIDType.lblSet.Text = "Auto Refresh"
        frmIDType.Reset()
        frmIDType.lblUser.Text = lblUser.Text
        frmIDType.ShowDialog()
    End Sub

    Private Sub txtEmail_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailID.KeyPress
        Dim ac As String = "@"
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 95 Then
                    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                        If ac.IndexOf(e.KeyChar) = -1 Then
                            e.Handled = True

                        Else

                            If txtemailid.Text.Contains("@") And e.KeyChar = "@" Then
                                e.Handled = True
                            End If

                        End If


                    End If
                End If
            End If

        End If
    End Sub

    Private Sub txtEmail_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmailID.Validating
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As System.Text.RegularExpressions.Match = Regex.Match(txtemailid.Text.Trim(), pattern, RegexOptions.IgnoreCase)
        If (match.Success) Then
        Else
            MessageBox.Show("Please enter a valid email id", "Checking")
            txtemailid.Clear()
        End If
    End Sub
End Class
