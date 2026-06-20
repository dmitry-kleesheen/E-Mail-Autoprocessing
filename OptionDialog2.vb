Imports System.Data.SQLite
Imports System.IO
Imports System.Net.Mail
Imports System.Windows.Forms
Imports Microsoft.Office.Interop

Public Class OptionDialog2

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Try


            My.Settings.Login = txtLogin.Text
            My.Settings.Password = txtPassword.Text
            My.Settings.SMTPServer = txtSMTPServer.Text
            My.Settings.PortNumber = txtPortNumber.Text
            My.Settings.SSL = chkSSL.Checked
            My.Settings.From = txtFrom.Text
            My.Settings.Subject1 = txtSubject1.Text
            My.Settings.Save()
            MsgBox("Настройки сохранены!", vbInformation, "Настройки")
        Catch ex As Exception
            MsgBox(ex.Message, vbObjectError, "Ошибка")
        End Try
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtSaveOptions_Click(sender As Object, e As EventArgs) Handles txtSaveOptions.Click
        Try


            My.Settings.Login = txtLogin.Text
            My.Settings.Password = txtPassword.Text
            My.Settings.SMTPServer = txtSMTPServer.Text
            My.Settings.PortNumber = txtPortNumber.Text
            My.Settings.SSL = chkSSL.Checked
            My.Settings.From = txtFrom.Text
            My.Settings.Subject1 = txtSubject1.Text
            My.Settings.Save()
            MsgBox("Настройки сохранены!", vbInformation, "Настройки")
        Catch ex As Exception
            MsgBox(ex.Message, vbObjectError, "Ошибка")
        End Try
    End Sub

    Private Sub butTestEmail_Click(sender As Object, e As EventArgs) Handles butTestEmail.Click
        'Try
        'Dim Smtp_Server As New SmtpClient
        'Dim e_mail As New MailMessage()
        'System.Net.ServicePointManager.SecurityProtocol = DirectCast(3072, System.Net.SecurityProtocolType)

        'Smtp_Server.UseDefaultCredentials = False
        ''Smtp_Server.Credentials = New System.Net.Cache.RequestCachePolicy
        'Smtp_Server.Credentials = New Net.NetworkCredential(txtLogin.Text, txtPassword.Text, "email.volganet.ru")
        'Smtp_Server.Port = txtPortNumber.Text
        'Smtp_Server.EnableSsl = chkSSL.Checked


        'Smtp_Server.Host = txtSMTPServer.Text

        'e_mail = New MailMessage()
        'e_mail.From = New MailAddress(txtFrom.Text)
        'e_mail.To.Add(txtTo.Text)
        'e_mail.Subject = txtSubject.Text '"Email Sending"

        'e_mail.IsBodyHtml = False
        'e_mail.Body = txtMessage.Text
        'e_mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess

        'Smtp_Server.Host = "email.volganet.ru"
        ''Smtp_Server.Timeout = 160
        'Smtp_Server.Send(e_mail)


        'MsgBox("Сообщение отправлено!", vbInformation, "Инормация")

        'Catch error_t As Exception
        '    MsgBox(error_t.ToString)
        'End Try

        Dim AppOutlook As New Outlook.Application
        Try
            Dim OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
            Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
            Recipents.Add(txtTo.Text)
            OutlookMessage.Subject = txtSubject.Text
            OutlookMessage.Body = txtMessage.Text
            OutlookMessage.OriginatorDeliveryReportRequested = True
            OutlookMessage.ReadReceiptRequested = True
            OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatHTML
            OutlookMessage.Send()

            AppOutlook = Nothing
            Recipents = Nothing

            MsgBox("Тестовое сообщение отправлено!", vbInformation, "Успех")
        Catch ex As Exception
            MessageBox.Show("Mail could not be sent") 'if you dont want this message, simply delete this line 
        Finally

            AppOutlook = Nothing
        End Try

    End Sub

    Private Sub butExport_Click(sender As Object, e As EventArgs) Handles butExport.Click
        Dim i As Integer
        Dim file As System.IO.StreamWriter
        Dim f_name As String


        'Dim saveFileDialog1 As New SaveFileDialog()

        SaveFileDialog1.Filter = "csv files (*.csv)|*.csv"
        SaveFileDialog1.FilterIndex = 2
        SaveFileDialog1.RestoreDirectory = True

        Try


            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

                f_name = SaveFileDialog1.FileName
                'file =
                If (file IsNot Nothing) Then

                Else
                    ' Code to write the stream goes here.
                    Dim myStream As New StreamWriter(SaveFileDialog1.FileName, False, System.Text.Encoding.GetEncoding(1251))
                    'file = My.Computer.FileSystem.OpenTextFileWriter(f_name, True)
                    For i = 0 To Form1.DataGridView1.RowCount - 1
                        myStream.WriteLine(Form1.DataGridView1(0, i).Value.ToString() & ";" & Form1.DataGridView1(1, i).Value.ToString() & ";" & Form1.DataGridView1(2, i).Value.ToString() & ";" & Form1.DataGridView1(3, i).Value.ToString())
                    Next
                    myStream.Close()
                    myStream.Dispose()
                    MsgBox("Экспорт в файл завершен," & vbCrLf & "выгружено (" & CInt(i) & ") адреса(ов).", vbInformation, "Финиш")
                End If
            End If
            SaveFileDialog1.Dispose()
        Catch ex As Exception
            'myStream.Dispose()
            SaveFileDialog1.Dispose()
            MsgBox(ex.Message, vbCritical, "Ошибка")
        End Try
    End Sub

    Private Sub butImport_Click(sender As Object, e As EventArgs) Handles butImport.Click
        'Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        'openFileDialog1.ShowDialog()
        openFileDialog1.Filter = "Текстовые файл CSV (*.csv)|*.csv"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                'myStream = openFileDialog1.OpenFile()
                'If (myStream IsNot Nothing) Then

                '    NumFile = Microsoft.VisualBasic.Right(openFileDialog1.FileName.ToString, 3)

                CSVFile = openFileDialog1.FileName.ToString

                IMPORT_File()

                openFileDialog1.Dispose()
            Catch Ex As Exception
                openFileDialog1.Dispose()
                MessageBox.Show("Ошибка чтения файла: " & Ex.Message)
            Finally
                ' 
                'If (myStream IsNot Nothing) Then
                '    myStream.Close()
                'End If
            End Try
        End If
        openFileDialog1.Dispose()
    End Sub

    'Общее количество записей в таблице
    Private Sub Rows_Total()
        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        'Dim sql As String = "SELECT MAX([ID]) FROM [MAIL]"

        'Declare the main SQLite data access objects
        Dim objConn As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            'Create a new database connection
            objConn = New SQLiteConnection(connectionString)

            'Open the connection
            objConn.Open()

            'Create a new SQL command to read all records from the customer table
            objCommand = objConn.CreateCommand()
            objCommand.CommandText = "SELECT COUNT([ID]) FROM [MAIL]"
            'SELECT COUNT(c) FROM t1
            'Execute the command returning a reader object
            objReader = objCommand.ExecuteReader()

            'Iterate through the rows in the reader, adding each name found

            While (objReader.Read())

                mx_count = objReader("COUNT([ID])")

            End While

            'MsgBox(mx_count)
            objConn.Close()
        Catch ex As Exception
            MessageBox.Show("An error has occurred: " & ex.Message)
            ' result = 0
        Finally
            'Cleanup and close the connection
            If Not IsNothing(objConn) Then
                objConn.Close()
                'result = 0
            End If
        End Try
    End Sub

    'Последний номер в таблице
    Private Sub Last_Num()

        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        'Dim sql As String = "SELECT MAX([ID]) FROM [MAIL]"

        'Declare the main SQLite data access objects
        Dim objConn As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            'Create a new database connection
            objConn = New SQLiteConnection(connectionString)

            'Open the connection
            objConn.Open()

            'Create a new SQL command to read all records from the customer table
            objCommand = objConn.CreateCommand()
            objCommand.CommandText = "SELECT MAX([ID]) FROM [MAIL]"

            'Execute the command returning a reader object
            objReader = objCommand.ExecuteReader()

            'Iterate through the rows in the reader, adding each name found
            'to the listbox on the form
            'lstCustomers.Items.Clear()
            While (objReader.Read())

                'If objReader.RecordsAffected - 1 Then
                '    result = 0
                'Else
                result = objReader("MAX([ID])")
                'End If

                'If IsNothing(result) = True Then

                'End If
            End While

            'MsgBox(result)
            objConn.Close()
        Catch ex As Exception
            MessageBox.Show("An error has occurred: " & ex.Message)
            'result = 0
        Finally
            'Cleanup and close the connection
            If Not IsNothing(objConn) Then
                objConn.Close()
                'result = 0
            End If
        End Try


    End Sub

    Dim mx_count As Integer
    Dim result As String
    Dim CSVFile As String

    'Функция импорта данных из файла CSV
    Private Sub IMPORT_File()

        'Dim Rasch_Export As String
        'Dim Passport_Export As String
        Dim PorNum As String = 1
        Dim R As Integer = 0
        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        ''Узнаем последний номер в ID

        Call Rows_Total()

        If mx_count = 0 Then
            result = 0
            PorNum = 1
        Else
            Call Last_Num()
            PorNum = result + 1
        End If

        'Declare the main SQLite data access objects
        Dim objConn As SQLiteConnection
        Dim objCommand As SQLiteCommand

        Try
            'Create a new database connection
            'Note - use New=True to create a new database
            objConn = New SQLiteConnection(connectionString & "New=True;")

            'Open the connection
            objConn.Open()

            'Create a new SQL command
            objCommand = objConn.CreateCommand()

            Dim tfp As New FileIO.TextFieldParser(CSVFile, System.Text.Encoding.GetEncoding(1251))
            tfp.Delimiters = New String() {";"}
            tfp.TextFieldType = FileIO.FieldType.Delimited


            'tfp.ReadLine() ' skip header
            While tfp.EndOfData = False
                Dim fields = tfp.ReadFields()


                objCommand.CommandText = "INSERT INTO MAIL (ID, NAME,EMAIL,FOLDER) VALUES (" & PorNum & ", '" & fields(1) & "','" & fields(2) & "','" & fields(3) & "');"
                objCommand.ExecuteNonQuery()
                PorNum = PorNum + 1
                R = R + 1
            End While



            objConn.Close()

            Form1.BaseConnect()
            MsgBox("Импорт из файла завершен," & vbCrLf & "добавлено: (" & CStr(R) & ") строк.", vbInformation, "Финиш")

        Finally
            'Cleanup and close the connection
            If Not IsNothing(objConn) Then
                objConn.Close()
            End If
        End Try

    End Sub

    Private Sub OptionDialog2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtLogin.Text = My.Settings.Login
        txtPassword.Text = My.Settings.Password
        txtSMTPServer.Text = My.Settings.SMTPServer
        txtPortNumber.Text = My.Settings.PortNumber
        chkSSL.Checked = My.Settings.SSL
        txtFrom.Text = My.Settings.From
        txtSubject1.Text = My.Settings.Subject1
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub
End Class
