Imports System.Data.OleDb

Module ModProcedure
    Public Const cnString As String = cs

    Public Sub FillListView(ByRef lvList As ListView, ByRef myData As OleDbDataReader)
        Dim itmListItem As ListViewItem

        Dim strValue As String

        Do While myData.Read
            itmListItem = New ListViewItem()
            strValue = IIf(myData.IsDBNull(0), "", myData.GetValue(0))
            itmListItem.Text = strValue

            For shtCntr = 1 To myData.FieldCount() - 1
                If myData.IsDBNull(shtCntr) Then
                    itmListItem.SubItems.Add("")
                Else
                    itmListItem.SubItems.Add(myData.GetValue(shtCntr))
                End If
            Next shtCntr

            lvList.Items.Add(itmListItem)
        Loop
    End Sub
    Public Function GetData(ByVal sSQL As String)
        Dim CN As OleDbConnection
        Dim sqlCmd As OleDbCommand = New OleDbCommand(sSQL)
        Dim myData As OleDbDataReader

        CN = New OleDbConnection(cnString)

        Try
            CN.Open()

            sqlCmd.Connection = CN

            myData = sqlCmd.ExecuteReader

            Return myData
        Catch ex As Exception
            Return ex
        End Try
    End Function
    Public Function ExecNonQuery(ByVal strSQL As String)
        Dim cnHotel As OleDbConnection
        cnHotel = New OleDbConnection

        Try
            With cnHotel
                If .State = ConnectionState.Open Then .Close()

                .ConnectionString = cnString
                .Open()
            End With

            Dim cmd As OleDbCommand = New OleDbCommand(strSQL, cnHotel)

            cmd.ExecuteNonQuery()

            Return True
        Catch ex As OleDbException
            Return ex
        Finally
            cnHotel.Close()
        End Try
    End Function
End Module
