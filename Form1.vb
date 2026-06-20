
Imports System.Data.SQLite
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
Imports System.Management.Automation
Imports System.Management.Automation.Runspaces
Imports System.Collections.ObjectModel
Imports System.Text
Imports System.Net.Mail.SmtpStatusCode
Imports Microsoft.Office.Interop


'Imports Microsoft.Win32.SystemEvents

Public Class Form1
    Dim Send_Value As String
    Public Sub Handler_SessionEnding(ByVal sender As Object,
               ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
            Select Case RUNNING
                Case True
                    Call butRun.PerformClick()
            End Select
            'MessageBox.Show("User is logging off")
        ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
            Select Case RUNNING
                Case True
                    Call butRun.PerformClick()
                    Me.Close()
            End Select
            'MessageBox.Show("System is shutting down")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Microsoft.Win32.SystemEvents.SessionEnding,
               AddressOf Handler_SessionEnding

        BaseConnect()

        BaseConnect1()

        RUNNING = False

        Total_Emails()
        Total_EmailsToday()
        Total_EmailsTodayErrors()
        Statistic_Emails()
        Total_Days()

        For Each arg As String In My.Application.CommandLineArgs
            Select Case arg
                Case "-autos"
                    Call butRun.PerformClick()
                    Me.Visible = False
                    Me.ShowInTaskbar = False
                    NotifyIcon1.Visible = True
            End Select

        Next

    End Sub

    'Количество отправленных писем сегодня
    Private Sub Total_EmailsTodayErrors()
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
            objCommand.CommandText = "SELECT COUNT([ADRESSATE]) FROM [LOGS] where  Data = '" & Now.Date.ToString("yyyy-MM-dd") & "' AND STATUS='Ошибка'"
            'SELECT COUNT(c) FROM t1
            'Execute the command returning a reader object
            objReader = objCommand.ExecuteReader()

            'Iterate through the rows in the reader, adding each name found

            While (objReader.Read())

                mx_count_today = objReader("COUNT([ADRESSATE])")

            End While

            ToolStripLabel4.Text = "Не отправлено за сегодня: " & CStr(mx_count_today)
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

    'Количество отправленных писем сегодня
    Private Sub Total_EmailsToday()
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
            objCommand.CommandText = "SELECT COUNT([ADRESSATE]) FROM [LOGS] where  Data = '" & Now.Date.ToString("yyyy-MM-dd") & "' AND STATUS='Отправлено'"
            'SELECT COUNT(c) FROM t1
            'Execute the command returning a reader object
            objReader = objCommand.ExecuteReader()

            'Iterate through the rows in the reader, adding each name found

            While (objReader.Read())

                mx_count_today = objReader("COUNT([ADRESSATE])")

            End While

            ToolStripLabel3.Text = "Из них за сегодня: " & CStr(mx_count_today)
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


    'Статистика отправленных писем общая
    Private Sub Statistic_Emails()
        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        Dim sql As String = "SELECT ID,NAME, Adressate, Count([Adressate]) FROM LOGS, MAIL WHERE EMAIL=Adressate  GROUP BY Adressate ORDER BY Count([Adressate]) DESC"

        Dim dt As DataTable = Nothing
        Dim ds As New DataSet


        Try
            Using cons As New SQLiteConnection(connectionString)


                Using cmd As New SQLiteCommand(sql, cons)


                    cons.Open()

                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)


                    End Using
                End Using
                DataGridView3.DataSource = dt.DefaultView
                DataGridView3.Columns(0).DataPropertyName = "ID"
                DataGridView3.Columns(1).DataPropertyName = "NAME"
                DataGridView3.Columns(2).DataPropertyName = "ADRESSATE"
                DataGridView3.Columns(3).DataPropertyName = "Count([Adressate])"


                DataGridView3.DataSource = dt.DefaultView
                DataGridView3.Columns(0).HeaderText = "В/Н"
                DataGridView3.Columns(0).Width = 40
                DataGridView3.Columns(1).HeaderText = "Имя получателя"
                DataGridView3.Columns(1).Width = 140
                DataGridView3.Columns(2).HeaderText = "E-mail адрес"
                DataGridView3.Columns(2).Width = 240
                DataGridView3.Columns(3).HeaderText = "Кол-во писем (Всего)"
                DataGridView3.Columns(3).Width = 150
                DataGridView3.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DataGridView3.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DataGridView3.Columns(3).DefaultCellStyle.Font.Bold = True
                cons.Close()
            End Using

        Catch ex As Exception
            'cons.Close()
            MsgBox(ex.Message, vbExclamation, "ERROR#")
        End Try

    End Sub

    'Количество отправленных писем
    Private Sub Total_Emails()
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
            objCommand.CommandText = "SELECT COUNT([ADRESSATE]) FROM [LOGS] WHERE STATUS='Отправлено'"
            'SELECT COUNT(c) FROM t1
            'Execute the command returning a reader object
            objReader = objCommand.ExecuteReader()

            'Iterate through the rows in the reader, adding each name found

            While (objReader.Read())

                mx_count = objReader("COUNT([ADRESSATE])")

            End While

            ToolStripLabel2.Text = "Отправленных писем всего: " & CStr(mx_count)
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

    Public Sub BaseConnect1()
        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        Dim sql As String = "SELECT DATA,TIME,ADRESSATE,FILES,OWNER,STATUS FROM LOGS"
        'LOGS(Data, TIME, ADRESSATE, FILES, STATUS
        'Dim connection As New SqlClient.SqlConnection(connectionString)
        'Dim dataadapter As New SqlDataAdapter(sql, connection)

        Dim dt As DataTable = Nothing
        Dim ds As New DataSet
        Dim str As String

        Try
            Using cons As New SQLiteConnection(connectionString)


                Using cmd As New SQLiteCommand(sql, cons)


                    cons.Open()

                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)

                        For i = 0 To dt.Rows.Count - 1
                            'str = String.Format(dt.Rows(i).Item(0).ToString, "dd.MM.yyyy")
                            dt.Rows(i).Item(0) = Mid(dt.Rows(i).Item(0).ToString, 9, 2) & "." & Mid(dt.Rows(i).Item(0).ToString, 6, 2) & "." & Mid(dt.Rows(i).Item(0).ToString, 1, 4)
                        Next i

                    End Using
                End Using
                DataGridView2.DataSource = dt.DefaultView
                DataGridView2.Columns(0).DataPropertyName = "DATA"
                DataGridView2.Columns(1).DataPropertyName = "TIME"
                DataGridView2.Columns(2).DataPropertyName = "ADRESSATE"
                DataGridView2.Columns(3).DataPropertyName = "FILES"
                DataGridView2.Columns(4).DataPropertyName = "OWNER"
                DataGridView2.Columns(5).DataPropertyName = "STATUS"

                DataGridView2.DataSource = dt.DefaultView
                DataGridView2.Columns(0).HeaderText = "Дата"
                DataGridView2.Columns(1).HeaderText = "Время"
                DataGridView2.Columns(2).HeaderText = "Получатель"
                DataGridView2.Columns(3).HeaderText = "Файлы"
                DataGridView2.Columns(4).HeaderText = "ПК/USER"
                DataGridView2.Columns(5).HeaderText = "Статус"

                For i = 0 To DataGridView2.ColumnCount - 1
                    DataGridView2.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                Next

                'DataGridView1.Columns(4).Visible = False
                'DataGridView1.Columns(5).Visible = False
                'DataGridView1.Columns(6).Visible = False
                'DataGridView1.Columns(7).Visible = False
                cons.Close()
            End Using




        Catch ex As Exception
            'cons.Close()
            MsgBox(ex.Message, vbExclamation, "ERROR#")
        End Try

    End Sub


    Public Sub BaseConnect()
        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        Dim sql As String = "SELECT ID,NAME,EMAIL,FOLDER FROM MAIL"
        'Dim connection As New SqlClient.SqlConnection(connectionString)
        'Dim dataadapter As New SqlDataAdapter(sql, connection)

        Dim dt As DataTable = Nothing
        Dim ds As New DataSet


        Try
            Using cons As New SQLiteConnection(connectionString)


                Using cmd As New SQLiteCommand(sql, cons)


                    cons.Open()

                    Using da As New SQLiteDataAdapter(cmd)
                        da.Fill(ds)
                        dt = ds.Tables(0)


                    End Using
                End Using
                DataGridView1.DataSource = dt.DefaultView
                DataGridView1.Columns(0).DataPropertyName = "ID"
                DataGridView1.Columns(1).DataPropertyName = "NAME"
                DataGridView1.Columns(2).DataPropertyName = "EMAIL"
                DataGridView1.Columns(3).DataPropertyName = "FOLDER"

                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
                DataGridView1.Columns(7).Visible = False
                cons.Close()
            End Using

            Est_Dannie()


        Catch ex As Exception
            'cons.Close()
            MsgBox(ex.Message, vbExclamation, "ERROR#")
        End Try

    End Sub

    Dim NumFile As String
    Dim CSVFile As String
    Dim result As String

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
    Dim mx_count_today As Integer

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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FormAdress.Text = "Адресат новый*"
        FormAdress.ShowDialog()
    End Sub

    'Delete record
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"

        'Declare the main SQLite data access objects
        Dim objConn As SQLiteConnection
        Dim objCommand As SQLiteCommand

        Dim Msg, Style, Title, Response
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Отсутствует адресат для удаления", vbExclamation, "Удаление")
            Exit Sub
        End If
        Msg = "Удалить адресат: " & DataGridView1.Item(1, DataGridView1.CurrentRow.Index).Value() & " ?"  ' Define title.
        Style = vbYesNo + vbExclamation + vbDefaultButton2    ' Define buttons.
        Title = "Удаление"
        'Help = "DEMO.HLP"    ' Define Help file.
        'Ctxt = 1000    ' Define topic context. 
        ' Display message.
        Response = MsgBox(Msg, Style, Title)

        Try
            If Response = vbYes Then    ' User chose Yes.

                'Create a new database connection
                'Note - use New=True to create a new database
                objConn = New SQLiteConnection(connectionString & "New=True;")

                'Open the connection
                objConn.Open()

                'Create a new SQL command
                objCommand = objConn.CreateCommand()

                objCommand.CommandText = "DELETE FROM MAIL WHERE ID ='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value() & "'"
                objCommand.ExecuteNonQuery()


                objConn.Close()

                BaseConnect()



            Else    ' User chose No.

            End If




        Catch ex As Exception
            MessageBox.Show("An error has occurred: " & ex.Message)
        Finally
            'Cleanup and close the connection
            If Not IsNothing(objConn) Then
                objConn.Close()
            End If
        End Try

    End Sub

    Public R_position As String

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click, DataGridView1.CellDoubleClick
        Dim Msg, Style, Title, Response
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("Отсутствует адресат для редактирования", vbExclamation, "Редактирование")
            Exit Sub
        End If
        R_position = DataGridView1.CurrentRow.Index
        FormAdress.Text = "Адресат редактирование"
        FormAdress.ShowDialog()
    End Sub



    Dim RUNNING As Boolean

    Private Sub butRun_Click(sender As Object, e As EventArgs) Handles butRun.Click

        Timer1.Enabled = True

        If butRun.Text = "Пуск" Then
            butRun.ImageIndex = 1
            butRun.Text = "Стоп"
            RUNNING = True
            My.Computer.Audio.Play(My.Application.Info.DirectoryPath & "\Run.wav")
            Call Timer1_Tick(e, e)
        Else

            butRun.Text = "Пуск"
            butRun.ImageIndex = 0
            RUNNING = False
        End If

    End Sub

    Dim DATA_TX As String
    Dim TIME_TX As String
    Dim ADRESSATE_TX As String
    Dim FILES_TX As String
    Dim STATUS_TX As String
    Dim OWNER_FL As String


    Private Sub Log_Write()


        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"


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


            objCommand.CommandText = "INSERT INTO LOGS (DATA, TIME,ADRESSATE,FILES,OWNER,STATUS) VALUES ('" & Mid(DATA_TX, 7, 4) & "-" & Mid(DATA_TX, 4, 2) & "-" & Mid(DATA_TX, 1, 2) & "', '" & TIME_TX & "','" & ADRESSATE_TX & "','" & FILES_TX & "','" & OWNER_FL & "','" & STATUS_TX & "');"
            objCommand.ExecuteNonQuery()

            objConn.Close()

            BaseConnect1()

            Statistic_Emails()
            Total_Days()

            DataGridView2.CurrentCell = DataGridView2.Rows(DataGridView2.Rows.Count - 1).Cells(DataGridView2.CurrentCell.ColumnIndex)
            'MsgBox("Импорт из файла завершен," & vbCrLf & "добавлено: (" & CStr(R) & ") строк.", vbInformation, "Финиш")

        Finally
            'Cleanup and close the connection
            If Not IsNothing(objConn) Then
                objConn.Close()
            End If
        End Try
    End Sub

    'Функция отправки сообщения из таблицы автопроцессинга
    Dim files_poluchatel As String
    Dim pochta As String

    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().

    End Sub

    Private Function RunScript(ByVal scriptText As String) As String

        ' create Powershell runspace 
        Dim MyRunSpace As Runspace = RunspaceFactory.CreateRunspace()

        Dim str_command As String = "$mypasswd = ConvertTo-SecureString 't36xz7Q1' -AsPlainText -Force " &
        "$mycreds = New-Object System.Management.Automation.PSCredential ('tu36', $mypasswd) " &
        "$path1='" & My.Application.Info.DirectoryPath & "\Temp\" & "' " &
        "Send-MailMessage " &
        "-Port " & My.Settings.PortNumber & " " &
        "-From 'tu36@volganet.ru' " &
        "-To '" & ADRESSATE_TX & "' " &
        "-Subject """ & My.Settings.Subject1 & """ " &
        "-Body """ & My.Settings.Message & """ " &
        "-SmtpServer '" & My.Settings.SMTPServer & "' " &
        "-UseSSL " &
        "-Attachments (Get-ChildItem $path1\*.*) " &
        "-DeliveryNotificationOption OnSuccess, OnFailure " &
        "-Credential ($mycreds)"


        ' open it 
        MyRunSpace.Open()

        ' create a pipeline and feed it the script text 
        Dim MyPipeline As Pipeline = MyRunSpace.CreatePipeline()

        MyPipeline.Commands.AddScript(scriptText)

        ' add an extra command to transform the script output objects into nicely formatted strings 
        ' remove this line to get the actual objects that the script returns. For example, the script 
        ' "Get-Process" returns a collection of System.Diagnostics.Process instances. 
        ' MyPipeline.Commands.Add("Out-String")

        MyPipeline.Commands.Add(str_command)

        ' execute the script 
        Dim results As Collection(Of PSObject) = MyPipeline.Invoke()

        ' close the runspace 
        MyRunSpace.Close()

        ' convert the script result into a single string 
        Dim MyStringBuilder As New StringBuilder()

        For Each obj As PSObject In results
            MyStringBuilder.AppendLine(obj.ToString())
        Next

        ' return the results of the script that has 
        ' now been converted to text 
        Return MyStringBuilder.ToString()

    End Function

    Dim AppOutlook As New Outlook.Application

    Private Sub Run_send()

        Try

            DATA_TX = ""
            TIME_TX = ""
            ADRESSATE_TX = ""
            FILES_TX = ""
            STATUS_TX = ""
            OWNER_FL = ""


            'Просмотр по таблице с адресатами
            For i As Integer = 0 To DataGridView1.Rows.Count - 1

                'на случай ошибки покажем кому не отправлено
                pochta = DataGridView1.Rows(i).Cells(2).Value
                'какие файлы не отправлены
                files_poluchatel = DataGridView1.Rows(i).Cells(3).Value

                'Если нажата кнопка стоп, завершить обработку
                If RUNNING = False Then
                    Exit Sub
                End If

                'Проверяем существует ли папка?
                If IO.Directory.Exists(DataGridView1.Rows(i).Cells(3).Value) = False Then
                    GoTo 1
                End If

                'Если папка автопроцессинга пустая
                Dim FilesInFolder = Directory.GetFiles(DataGridView1.Rows(i).Cells(3).Value, "*.*").Count
                Dim h As Integer = 0

                While h <= FilesInFolder
                    h += 1
                End While

                'Если папка пустая переходим по метке
                If FilesInFolder = 0 Then
                    GoTo 1 ' Для перехода к следующей папке в списке
                End If

                'Форируем сообщение для отправки
                '    Dim Smtp_Server As New SmtpClient
                '    Dim e_mail As New MailMessage()
                'Smtp_Server.UseDefaultCredentials = True
                ''Smtp_Server.DeliveryMethod = SmtpDeliveryMethod.Network
                'Dim mail As SmtpPermission

                'Smtp_Server.Credentials = New Net.NetworkCredential(My.Settings.Login, My.Settings.Password)
                'Smtp_Server.Port = My.Settings.PortNumber
                '    Smtp_Server.EnableSsl = My.Settings.SSL
                '    Smtp_Server.Host = My.Settings.SMTPServer
                'Smtp_Server.TargetNa
                ADRESSATE_TX = DataGridView1.Rows(i).Cells(2).Value

                'e_mail = New MailMessage()
                '    e_mail.From = New MailAddress(My.Settings.From)
                '    e_mail.To.Add(ADRESSATE_TX)
                '    e_mail.Subject = My.Settings.Subject1
                '    e_mail.IsBodyHtml = False
                '    e_mail.Body = My.Settings.Message
                '    e_mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess

                'Папка автопроцессинга из таблицы
                Dim dirs As String() = Directory.GetFiles(DataGridView1.Rows(i).Cells(3).Value, "*.*")
                Dim dir As String

                'Если папка темп в программе отсутствует
                If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Temp\") = False Then

                    'Создаем папку темп в  программе
                    My.Computer.FileSystem.CreateDirectory(My.Application.Info.DirectoryPath & "\Temp\")

                End If

                Dim OutlookMessage = AppOutlook.CreateItem(Outlook.OlItemType.olMailItem)
                Dim Recipents As Outlook.Recipients = OutlookMessage.Recipients
                Recipents.Add(ADRESSATE_TX)
                OutlookMessage.Subject = My.Settings.Subject1
                OutlookMessage.Body = My.Settings.Message
                OutlookMessage.OriginatorDeliveryReportRequested = True
                'OutlookMessage.ReadReceiptRequested = True
                OutlookMessage.BodyFormat = Outlook.OlBodyFormat.olFormatHTML


                'Ищем файлы в папке  темп в  программе
                For Each dir In dirs

                    My.Computer.FileSystem.MoveFile(dir, My.Application.Info.DirectoryPath & "\Temp\" & Path.GetFileName(dir))


                    'Вкладываем файлы в сообщение
                    'e_mail.Attachments.Add(New Attachment(My.Application.Info.DirectoryPath & "\Temp\" & Path.GetFileName(dir)))
                    'If e_mail.Attachments.Count > 1 Or e_mail.Attachments.Count < Path.GetFileName(dir).Count Then
                    FILES_TX = FILES_TX & Path.GetFileName(dir) & ","
                    'Else
                    '    FILES_TX = FILES_TX & Path.GetFileName(dir) & ""
                    'End If

                    OWNER_FL = GetFileOwner(My.Application.Info.DirectoryPath & "\Temp\" & Path.GetFileName(dir))
                    OutlookMessage.Attachments.Add(My.Application.Info.DirectoryPath & "\Temp\" & Path.GetFileName(dir))
                Next
                OutlookMessage.Send()



                'Отправляем сообщение
                'Smtp_Server.Send(e_mail)
                '    Dim proc As Process = New Process
                'proc.StartInfo.FileName = "C:\Python38\python.exe"
                ''Default Python Installation
                'proc.StartInfo.Arguments = My.Application.Info.DirectoryPath & "\SMTP.py " & DataGridView1.Rows(i).Cells(2).Value
                ''TextBox1.Text = ""
                'proc.StartInfo.UseShellExecute = False 'required for redirect.
                'proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal 'don't show commandprompt.
                'proc.StartInfo.CreateNoWindow = False
                'proc.StartInfo.RedirectStandardOutput = True 'captures output from commandprompt.
                '    proc.Start()
                '    AddHandler proc.OutputDataReceived, AddressOf proccess_OutputDataReceived
                '    proc.BeginOutputReadLine()
                '    proc.WaitForExit()
                'MsgBox("OK!!!")
                'STATUS_TX = Send_Value


                'RunScript(ToString)

                DATA_TX = DateAndTime.Today.ToShortDateString
                TIME_TX = DateAndTime.TimeOfDay
                STATUS_TX = "Отправлено"
                ADRESSATE_TX = DataGridView1.Rows(i).Cells(2).Value
                My.Computer.Audio.Play(My.Application.Info.DirectoryPath & "\Send.wav")
                Log_Write()
                Total_Emails()
                Total_EmailsToday()
                Total_EmailsTodayErrors()
                'Убиваем процесс отправки почты
                'e_mail.Attachments.Dispose()
                'e_mail.Dispose()

                'Вновь ищем файлы в папке  темп в  программе
                Dim dirs1 As String() = Directory.GetFiles(My.Application.Info.DirectoryPath & "\Temp\", "*.*")
                Dim dir1 As String

                For Each dir1 In dirs1

                    'Удаляем файлы все файлы из темпа (временной папки)
                    My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\Temp\" & Path.GetFileName(dir1))

                Next
1:' Для перехода к следующей папке в списке
            Next

        'AppOutlook = Nothing
        'Recipents = Nothing

        Catch ex As Exception

        RUNNING = False
        My.Computer.Audio.Play(My.Application.Info.DirectoryPath & "\Error.wav")
        DATA_TX = DateAndTime.Today.ToShortDateString
        TIME_TX = DateAndTime.TimeOfDay
        STATUS_TX = "Ошибка"

        'Папка автопроцессинга из таблицы
        Dim dirs As String() = Directory.GetFiles(files_poluchatel, "*.*")
        Dim dir As String


        'Ищем файлы в папке  темп в  программе
        For Each dir In dirs

            FILES_TX = FILES_TX & Path.GetFileName(dir) & ","
            OWNER_FL = GetFileOwner(My.Application.Info.DirectoryPath & "\Temp\" & Path.GetFileName(dir))
        Next

        ADRESSATE_TX = pochta

        Log_Write()
        Total_EmailsTodayErrors()
        MsgBox(ex.Message, vbCritical, "Ошибка")
        butRun.Text = "Пуск"
        butRun.ImageIndex = 0
        Finally

        'AppOutlook = Nothing
        End Try

    End Sub

    Public Sub proccess_OutputDataReceived(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        On Error Resume Next
        If e.Data = "" Then
        Else
            Send_Value = e.Data
        End If
    End Sub


    Function RemoveAccessDatabase(
    ByVal FileName As String,
    ByVal WaitTime As Integer,
    ByVal Loops As Integer) As Boolean

        Dim Success As Boolean = False

        Dim LockFile As String = IO.Path.ChangeExtension(FileName, "*.*")

        For Counter As Integer = 0 To Loops
            If IO.File.Exists(LockFile) Then
                System.Threading.Thread.Sleep(WaitTime)
                IO.File.Delete(FileName)
            Else
                Success = True
                Exit For
            End If
        Next

        Return Success

    End Function


    ' Adds an ACL entry on the specified file for the specified account.
    Sub AddFileSecurity(ByVal fileName As String, ByVal account As String,
        ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(fileName)

        ' Add the FileSystemAccessRule to the security settings. 
        Dim accessRule As FileSystemAccessRule =
            New FileSystemAccessRule(account, rights, controlType)

        fSecurity.AddAccessRule(accessRule)

        ' Set the new access settings.
        File.SetAccessControl(fileName, fSecurity)

    End Sub


    ' Removes an ACL entry on the specified file for the specified account.
    Private Sub RemoveFileSecurity(ByVal fileName As String, ByVal account As String, ByVal rights As FileSystemRights, ByVal controlType As AccessControlType)

        ' Get a FileSecurity object that represents the 
        ' current security settings.
        Dim fSecurity As FileSecurity = File.GetAccessControl(fileName)

        ' Remove the FileSystemAccessRule from the security settings. 
        fSecurity.RemoveAccessRule(New FileSystemAccessRule(account,
            rights, controlType))

        ' Set the new access settings.
        File.SetAccessControl(fileName, fSecurity)

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If RUNNING = True Then
            Timer1.Enabled = True

            Run_send()
        ElseIf RUNNING = False Then
            Timer1.Enabled = False
            My.Computer.Audio.Play(My.Application.Info.DirectoryPath & "\Stop.wav")
            'MsgBox("Отправка остановлена!", MsgBoxStyle.Exclamation, "E-mail Автопроцессинг")
        End If

    End Sub

    Public Function GetFileOwner(ByVal fileName As String) As String
        Try
            Dim fi As New FileInfo(fileName)
            Dim fs As FileSecurity = fi.GetAccessControl
            Dim owner As NTAccount = CType(fs.GetOwner(GetType(WindowsPrincipal)), NTAccount)
            Return owner.ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function


    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Insert Then
            ToolStripButton1_Click(e, e)
        End If

        If e.KeyCode = Keys.Delete And ToolStripButton3.Enabled = True Then
            ToolStripButton3_Click(e, e)
        End If

        If e.KeyCode = Keys.Space And ToolStripButton2.Enabled = True Then
            ToolStripButton2_Click(e, e)
        End If
    End Sub


    Private Sub Est_Dannie()
        If DataGridView1.Rows.Count <= 0 Then
            ToolStripButton3.Enabled = False
            ToolStripButton2.Enabled = False
        Else
            ToolStripButton3.Enabled = True
            ToolStripButton2.Enabled = True
        End If
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        DataGridView1.Select()
    End Sub

    Private Sub ButOptions_Click(sender As Object, e As EventArgs) Handles ButOptions.Click
        OptionDialog2.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim i As Integer = 0
        Do While (i < DataGridView1.RowCount)
            DataGridView1.Rows(i).Selected = False
            Dim j As Integer = 0
            Do While (j < DataGridView1.ColumnCount)
                If (Not (DataGridView1.Rows(i).Cells(j).Value) Is Nothing) Then
                    If DataGridView1.Rows(i).Cells(j).Value.ToString.Contains("%" & ToolStripTextBox1.Text & "%") Then
                        DataGridView1.Rows(i).Selected = True
                        Exit Do
                    End If

                End If

                j = (j + 1)
            Loop

            i = (i + 1)
        Loop

        'End Sub
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        NotifyIcon1.Visible = False
        'NotifyIcon1.Dispose()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case Me.WindowState
            Case FormWindowState.Minimized
                Me.Visible = False
                Me.ShowInTaskbar = False
                NotifyIcon1.Visible = True
                'ToolTip1.Show()
                'NotifyIcon1.Icon.
                'ToolTip1.ShowAlways = True
                'ToolTip1.ToolTipTitle = "Сообщение успешно отправлено"               'NotifyIcon1.BalloonTipTitle = "Сообщение успешно отправлено"
                'NotifyIcon1.BalloonTipText = "А.Жмурков"
                'NotifyIcon1.ShowBalloonTip(1500)
                'NotifyIcon1.Visible = True
        End Select
    End Sub

    Private Sub butAbout_Click(sender As Object, e As EventArgs) Handles butAbout.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If RUNNING = True Then
            MsgBox("Нажмите кнопку- Стоп! Перед выходом из программы!", vbExclamation, "Выход")
            Exit Sub
        End If
    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting

    End Sub

    Private Sub DataGridView2_Paint(sender As Object, e As PaintEventArgs) Handles DataGridView2.Paint
        For i As Integer = 0 To DataGridView2.Rows.Count() - 1 Step +1
            Dim val As String
            val = DataGridView2.Rows(i).Cells(5).Value

            Select Case val
                Case "Ошибка"
                    DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                    DataGridView2.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                    'DataGridView2.Rows(i).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7.8, FontStyle.Bold)
                Case "Отправлено"
                    'DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.ForestGreen
                    'DataGridView2.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End Select

            '    'If val = "Ошибка" Then

            '    'End If
        Next i
    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        'Color_Error()
    End Sub

    Private Sub DataGridView2_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.RowValidated
        'Color_Error()
    End Sub

    Private Sub Color_Error()
        For i As Integer = 0 To DataGridView2.Rows.Count() - 1 Step +1
            Dim val As String
            val = DataGridView2.Rows(i).Cells(5).Value

            Select Case val
                Case "Ошибка"
                    DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.Red
                    DataGridView2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                    'DataGridView2.Rows(i).DefaultCellStyle.Font.Bold = New FontStyle()
                Case "Отправлено"
                    'DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.ForestGreen
                    'DataGridView2.Rows(i).DefaultCellStyle.ForeColor = Color.White
            End Select

        Next i
    End Sub

    Private Sub DataGridView2_Scroll(sender As Object, e As ScrollEventArgs)
        Color_Error()
    End Sub

    Private Sub Total_Days()
        Dim dt_int As String
        Dim first_date As String

        If DataGridView2.Rows.Count > 0 Then

            first_date = DataGridView2.Rows(0).Cells(0).Value
            dt_int = DateDiff("d", first_date, DataGridView2.Rows(DataGridView2.Rows.Count - 1).Cells(0).Value, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            ToolStripLabel5.Text = "Итого за периоуд с: (" & first_date & " по: " & DataGridView2.Rows(DataGridView2.Rows.Count - 1).Cells(0).Value & ")  за " & dt_int & " - дней"
        Else
            ToolStripLabel5.Text = "Итоги за периоуд..."
        End If

    End Sub


End Class
