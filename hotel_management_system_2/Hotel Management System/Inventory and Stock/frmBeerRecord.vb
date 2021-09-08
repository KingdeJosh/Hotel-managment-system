Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Public Class frmBeerRecord
    Private Const STR_SELECTStockIDIDBeerNameRateNoOfBottlesFromBeerSt As String = "SELECT StockID,ID,BeerName,Rate,NoOfBottles from Beer,Stock_beer where Beer.ID=stock_Beer.BeerID and NoOfBottles > 0 order by BeerName"
    Private Const STR_SELECTStockIDIDBeerNameRateNoOfBottlesFromBeerSt1 As String = "SELECT StockID,ID,BeerName,Rate,NoOfBottles from Beer,Stock_beer where Beer.ID=stock_Beer.BeerID and NoOfBottles > 0 and BeerName like '"








    Sub GetData()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTStockIDIDBeerNameRateNoOfBottlesFromBeerSt, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
   
    Sub GetData1()
        Try
            con = New OleDbConnection(cs)
            con.Open()
            cmd = New OleDbCommand(STR_SELECTStockIDIDBeerNameRateNoOfBottlesFromBeerSt1 & txtBeer.Text & "%' order by BeerName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        txtBeer.Text = ""
        GetData()
    End Sub

    


    Private Sub txtLiquor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBeer.TextChanged
        GetData1()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            Me.Hide()
            frmOrder.Show()
            frmOrder.txtBeerID.Text = dr.Cells(1).Value.ToString()
            frmOrder.txtLiquorName.Text = dr.Cells(2).Value.ToString()
            frmOrder.txtRate1.Text = dr.Cells(3).Value.ToString()
            frmOrder.txtAvailableQty.Text = dr.Cells(4).Value.ToString()
            frmOrder.txtQty1.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub frmBeerRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
        frmMainMenu.Show()
    End Sub
End Class