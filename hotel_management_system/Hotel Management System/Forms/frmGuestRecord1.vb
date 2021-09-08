Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmGuestRecord1

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(ContactNo) as [Contact No],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Notes) as [Notes] from Guest order by GuestName", con)
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

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Dim rowsTotal, colsTotal As Short
        Dim I, j, iC As Short
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim xlApp As New Excel.Application
        Try
            Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
            Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
            xlApp.Visible = True

            rowsTotal = dgw.RowCount
            colsTotal = dgw.Columns.Count - 1
            With excelWorksheet
                .Cells.Select()
                .Cells.Delete()
                For iC = 0 To colsTotal
                    .Cells(1, iC + 1).Value = dgw.Columns(iC).HeaderText
                Next
                For I = 0 To rowsTotal - 1
                    For j = 0 To colsTotal
                        .Cells(I + 2, j + 1).value = dgw.Rows(I).Cells(j).Value
                    Next j
                Next I
                .Rows("1:1").Font.FontStyle = "Bold"
                .Rows("1:1").Font.Size = 12

                .Cells.Columns.AutoFit()
                .Cells.Select()
                .Cells.EntireColumn.AutoFit()
                .Cells(1, 1).Select()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            'RELEASE ALLOACTED RESOURCES
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            xlApp = Nothing
        End Try
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Reservation_HallOrGarden" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmReservation_HallorGarden.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmReservation_HallorGarden.txtID.Text = dr.Cells(0).Value.ToString()
                frmReservation_HallorGarden.txtGuestID.Text = dr.Cells(1).Value.ToString()
                frmReservation_HallorGarden.txtGuestName.Text = dr.Cells(2).Value.ToString()
                frmReservation_HallorGarden.txtGender.Text = dr.Cells(3).Value.ToString()
                frmReservation_HallorGarden.txtReligion.Text = dr.Cells(4).Value.ToString()
                frmReservation_HallorGarden.txtOccupation.Text = dr.Cells(5).Value.ToString()
                frmReservation_HallorGarden.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
                frmReservation_HallorGarden.txtGuestCity.Text = dr.Cells(7).Value.ToString()
                frmReservation_HallorGarden.txtGuestContactNo.Text = dr.Cells(8).Value.ToString()
                frmReservation_HallorGarden.txtIDType.Text = dr.Cells(9).Value.ToString()
                frmReservation_HallorGarden.txtIDNumber.Text = dr.Cells(10).Value.ToString()
                lblSet.Text = ""
            End If
            If lblSet.Text = "Check In" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmCheckIN_Room.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmCheckIN_Room.txtID.Text = dr.Cells(0).Value.ToString()
                frmCheckIN_Room.txtGuestID.Text = dr.Cells(1).Value.ToString()
                frmCheckIN_Room.txtGuestName.Text = dr.Cells(2).Value.ToString()
                frmCheckIN_Room.txtGender.Text = dr.Cells(3).Value.ToString()
                frmCheckIN_Room.txtReligion.Text = dr.Cells(4).Value.ToString()
                frmCheckIN_Room.txtOccupation.Text = dr.Cells(5).Value.ToString()
                frmCheckIN_Room.txtGuestAddress.Text = dr.Cells(6).Value.ToString()
                frmCheckIN_Room.txtGuestCity.Text = dr.Cells(7).Value.ToString()
                frmCheckIN_Room.txtGuestContactNo.Text = dr.Cells(8).Value.ToString()
                frmCheckIN_Room.txtIDType.Text = dr.Cells(9).Value.ToString()
                frmCheckIN_Room.txtIDNumber.Text = dr.Cells(10).Value.ToString()
                lblSet.Text = ""
            End If
            If lblSet.Text = "Reservation" Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmReservation.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmReservation.txtID.Text = dr.Cells(0).Value.ToString()
                frmReservation.txtGuestID.Text = dr.Cells(1).Value.ToString()
                frmReservation.txtGuestName.Text = dr.Cells(2).Value.ToString()
                lblSet.Text = ""
            End If
            End if
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
            cmd = New SqlCommand("SELECT RTRIM(ID) as [ID],RTRIM(GuestID)as [Guest ID],RTRIM(Guestname) as [Guest Name],RTRIM(Gender) as [Gender],RTRIM(Religion) as [Religion],RTRIM(Occupation) as [Occupation],RTRIM(address) as [Address],RTRIM(city) as [City],RTRIM(ContactNo) as [Contact No],RTRIM(IDType) as [ID Type],RTRIM(IDNumber) as [ID Number],RTRIM(Notes) as [Notes] from Guest where GuestName like '" & txtGuestName.Text & "%' order by GuestName", con)
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
