Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Drawing
Imports System.IO

Public Class frmServer
    Private Const STR_Admin As String = "Admin "
    Dim flag As Integer = 0
    Dim flagM As Integer = 0
    Dim flagRun As Integer = 0
    Dim flagLang As Integer = 0
    Dim checkConnection As Integer = 0
    Dim ipHostEntry As IPHostEntry
    Dim ipAddress As IPAddress
    Dim localEndPoint As IPEndPoint
    Dim socketListener As Socket
    Dim socketHandler As Socket
    Dim threadStart As Thread
    Dim threadServerStart As Thread
    Dim sendMsg() As Byte
    Dim receiveMsg As String
    Dim urduString As String
    Dim englishString As String
    Dim path As String
    Public Shared ipAdd As String
    Delegate Sub SetDisplay(ByVal [Text] As String)

    Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
    (ByVal lpCommandString As String, ByVal lpReturnString As String, _
    ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

    Declare Function BlockInput Lib "User32" (ByVal fBlockIt As Boolean) As Boolean 'for blocking input from any client

    Public Sub createServer()
        Try
            ipHostEntry = Dns.Resolve(Dns.GetHostName())
            ipAddress = ipHostEntry.AddressList(0)
            localEndPoint = New IPEndPoint(ipAddress, 1100)
            socketListener.Bind(localEndPoint)
            socketListener.Listen(10)
            threadStart = New Thread(AddressOf startServer)
            threadStart.Start()
            checkConnection = 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub startServer()
        Try
            socketHandler = socketListener.Accept()
            threadServerStart = New Thread(AddressOf receiveMessage)
            threadServerStart.Start()
            checkConnection = 2
            'MessageBox.Show("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub receiveMessage()
        Dim bytes(1000000) As Byte
        Dim bytesRec As Integer
        bytes = New Byte(1000000) {}
A:      While True
            bytesRec = socketHandler.Receive(bytes)
            If bytesRec > 0 Then
                receiveMsg = Encoding.ASCII.GetString(bytes, 0, bytesRec)
                Exit While
            End If
        End While
        proccessData(receiveMsg)
        GoTo A
    End Sub

    Public Sub proccessData(ByVal str As String)
        If Me.messagesListBox.InvokeRequired Then
            Dim d As New SetDisplay(AddressOf proccessData)
            Me.Invoke(d, New Object() {str})
        Else
            Me.messagesListBox.Items.Add(str)
            Me.monitorList.Items.Add(str)
        End If
    End Sub

   Public Sub changeToUrdu()
        Me.txtUrdu.TextAlign = HorizontalAlignment.Right
        Me.txtUrdu.Visible = True
        Me.txtEnglish.Visible = False
        flagLang = 1
    End Sub

    Public Sub changeToEnglish()
        Me.txtEnglish.TextAlign = HorizontalAlignment.Left
        Me.txtEnglish.Visible = True
        Me.txtUrdu.Visible = False
        flagLang = 0
    End Sub

    Private Sub btnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculator.Click
        Process.Start("calc.exe")
    End Sub

    Private Sub btnNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNote.Click
        Process.Start("notepad.exe") ''''Remember To Open Notepad(My Noteeee)
    End Sub

    Private Sub btnMsPaint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMsPaint.Click
        Process.Start("mspaint.exe")
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        mciSendString("set CDAudio door open", "", 0, 0)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        mciSendString("set CDAudio door closed", "", 0, 0)
    End Sub

    Private Sub frmServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(355, 480)
        txtEnglish.Visible = True
        txtUrdu.Visible = False
        Me.socketListener = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        path = Application.StartupPath.ToString()
        Dim fade As Double
        For fade = 0.0 To 1.1 Step 0.1
            Me.Opacity = fade
            Me.Refresh()
            Thread.Sleep(50)
        Next
        Dim toolTipFont As New ToolTip()
        toolTipFont.SetToolTip(btnFont, "Change Font")
        Dim toolTipColor As New ToolTip()
        toolTipColor.SetToolTip(btnColor, "Change Text Color")
    End Sub

    Private Sub frmServer_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If checkConnection = 1 Then
            threadStart.Abort()
        ElseIf checkConnection = 2 Then
            threadStart.Abort()
            threadServerStart.Abort()
        End If
        If socketHandler IsNot Nothing Then
            socketHandler.Shutdown(SocketShutdown.Both)
            socketHandler.Close()
        End If
        Dim proces As Process = Process.GetCurrentProcess()
        proces.Kill()
    End Sub

    Private Sub frmServer_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim fade As Double
        For fade = 1.1 To 0.0 Step -0.1
            Me.Opacity = fade
            Me.Refresh()
            Thread.Sleep(50)
        Next
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub CalculatorToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("calc.exe")
    End Sub

    Private Sub PaintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("mspaint.exe")
    End Sub

    Private Sub NotepadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start("notepad.exe")
    End Sub

    Private Sub btnFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFont.Click
        With FontDialog1
            .ShowDialog()
            txtEnglish.Font = .Font
            txtUrdu.Font = .Font
        End With
    End Sub

    Private Sub btnColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor.Click
        With ColorDialog1
            .ShowDialog()
            txtEnglish.ForeColor = .Color
            txtUrdu.ForeColor = .Color
        End With
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If flagLang = 0 Then
                Dim nameIp As String = STR_Admin.ToUpper() & " (" & ipAddress.ToString() & ")" & " Says : "
                sendMsg = Encoding.ASCII.GetBytes(nameIp & txtEnglish.Text)
                socketHandler.Send(sendMsg)
                messagesListBox.Items.Add("Me Says : ".ToUpper() & txtEnglish.Text)
                monitorList.Items.Add("Admin Says  : ".ToUpper() & txtEnglish.Text)
                txtEnglish.Text = ""
            ElseIf flagLang = 1 Then
                sendMsg = Nothing
                sendMsg = Encoding.ASCII.GetBytes("Admin Says : ".ToUpper() & txtUrdu.Text)
                socketHandler.Send(sendMsg)
                messagesListBox.Items.Add("Me Says : ".ToUpper() & txtUrdu.Text)
                monitorList.Items.Add("Admin Says : ".ToUpper() & txtUrdu.Text)
                txtUrdu.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMonitor.Click
        If flagM = 0 Then
            If flag = 0 Then
                Me.btnMonitor.ButtonText = "<<Monitor Room"
                Dim Width As Integer = Me.Size.Width
                Width = 963
                Me.Size = New Size(Width, 480)
                flagM = 1
                flag = 1
            ElseIf flag = 1 Then
                Me.btnMonitor.ButtonText = "<<Monitor Room"
                Dim Width As Integer = Me.Size.Width
                Width = 963
                Me.Size = New Size(Width, Me.Size.Height)
                flagM = 1
                flag = 1
            End If
        ElseIf flagM = 1 Then
            If flag = 1 Then
                Me.btnMonitor.ButtonText = "Monitor Room>>"
                Dim Width As Integer = Me.Size.Width
                Width = 354
                Me.Size = New Size(Width, Me.Size.Height)
                flagM = 0
                flag = 0
            ElseIf flag = 0 Then
                Me.btnMonitor.ButtonText = "Monitor Room>>"
                Dim Width As Integer = Me.Size.Width
                Width = 354
                Me.Size = New Size(Width, Me.Size.Height)
                flagM = 0
                flag = 0
            End If
        End If
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        If flag = 0 Then
            Me.btnOptions.ButtonText = "<<Hide Options"
            Dim height As Integer = Me.Size.Height
            height = 672
            Me.Size = New Size(Me.Size.Width, height)
            flag = 1
        ElseIf flag = 1 Then
            Me.btnOptions.ButtonText = "Show Options>>"
            Dim height As Integer = Me.Size.Height
            height = 480
            Me.Size = New Size(Me.Size.Width, height)
            flag = 0
        End If
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        If flagRun = 0 Then
            createServer()
            Me.btnRun.ButtonText = "Stop"
            Me.lblStatus.Text = "Server Running..."
            flagRun = 1
        ElseIf flagRun = 1 Then
            Me.btnRun.ButtonText = "Run"
            Me.lblStatus.Text = "Server Stopped!!!"
            flagRun = 0
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            With OpenFileDialog1
                .Filter = "All files (*.*)|*.*"
                .FileName = ""
                .Multiselect = False
                .Title = "Select A File To Send"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    fileTextBox.Text = .FileName
                Else
                    Return
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestart.Click
        threadStart.Abort()
        threadStart.Start()
    End Sub

    Private Sub btnShutdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShutdown.Click
        If (threadStart.IsAlive) Then
            threadStart.Abort()
        End If
    End Sub

    Public Sub ActionData(ByVal str As String) 'sending commands to any connected client
        Select Case str
            Case "LogOff"
                'MessageBox.Show("logoff")
                Process.Start("shutdown", "-l -f -t 0")
            Case "ShutDown"
                ' MessageBox.Show("ShutDown")
                Process.Start("shutdown", "-s -f -t 0")
            Case "Restart"
                'MessageBox.Show("Restart")
                Process.Start("shutdown", "-r -f -t 0")
            Case "Mlock"
                BlockInput(True)
            Case "MRel"
                BlockInput(False)
        End Select
    End Sub

    
End Class
