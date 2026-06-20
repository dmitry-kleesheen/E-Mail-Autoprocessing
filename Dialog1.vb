Imports System.Net.Mail
Imports System.Windows.Forms
Imports System.Net.Mail.SmtpStatusCode

Public Class Dialog1
    Dim Send_Value As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim proc As Process = New Process
        proc.StartInfo.FileName = "C:\Python38\python.exe" 'Default Python Installation
        proc.StartInfo.Arguments = My.Application.Info.DirectoryPath & "\SMTP.py """ & TextBox2.Text & ""
        TextBox1.Text = ""
        proc.StartInfo.UseShellExecute = False 'required for redirect.
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden 'don't show commandprompt.
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
        proc.Start()
        AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived
        proc.BeginOutputReadLine()
        proc.WaitForExit()
        'MsgBox("OK!!!")
        TextBox1.Text = Send_Value
    End Sub

    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If e.Data = "" Then
        Else
            Send_Value = e.Data
        End If
    End Sub

End Class
