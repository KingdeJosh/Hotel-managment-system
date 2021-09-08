Imports System.Data.SqlClient
Public Class frmPlan
    Sub Reset()
        txtPlanName.Text = ""
        txtDescription.Text = ""
        txtPlanCode.Text = ""
        txtPlanCode.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        txtPlanCode.ReadOnly = False
        txtPlanCode.Enabled = True
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtPlanCode.Text)) = 0 Then
            MessageBox.Show("Please enter plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlanCode.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPlanName.Text)) = 0 Then
            MessageBox.Show("Please enter plan name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlanName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtDescription.Text)) = 0 Then
            MessageBox.Show("Please enter description", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select P_Code from [Plan] where P_Code=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Plan Code Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPlanCode.Text = ""
                txtPlanCode.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into [Plan](P_Code,PlanName,Description) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtPlanName.Text)
            cmd.Parameters.AddWithValue("@d3", txtDescription.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Hotel Plan has Plan Code '" & txtPlanCode.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select PlanCode from Room,[Plan] where Room.PlanCode=[Plan].P_Code and PlanCode=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Room Master Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from [Plan] where P_Code=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Hotel Plan has plan code '" & txtPlanCode.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(txtPlanCode.Text)) = 0 Then
            MessageBox.Show("Please enter plan code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlanCode.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPlanName.Text)) = 0 Then
            MessageBox.Show("Please enter plan name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPlanName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtDescription.Text)) = 0 Then
            MessageBox.Show("Please enter description", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update [Plan] Set PlanName=@d2,Description=@d3 where P_Code=@d1"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtPlanCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtPlanName.Text)
            cmd.Parameters.AddWithValue("@d3", txtDescription.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "updated the Hotel Plan has Plan Code '" & txtPlanCode.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(P_Code), RTRIM(PlanName), RTRIM(Description) from [Plan] order by Planname", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
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

    Private Sub frmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtPlanCode.Text = dr.Cells(0).Value.ToString()
                txtPlanName.Text = dr.Cells(1).Value.ToString()
                txtDescription.Text = dr.Cells(2).Value.ToString()
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
                txtPlanCode.ReadOnly = True
                txtPlanCode.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  
End Class
