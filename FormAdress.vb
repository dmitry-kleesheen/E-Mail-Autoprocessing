Imports System.Data.SQLite

Public Class FormAdress
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim dialog = New FolderBrowserDialog()
        If txtFolderSend.Text = "" Then
            FolderBrowserDialog1.SelectedPath = Environ("MyDocuments")
        Else
            FolderBrowserDialog1.SelectedPath = txtFolderSend.Text
        End If

        If DialogResult.OK = FolderBrowserDialog1.ShowDialog() Then
            txtFolderSend.Text = FolderBrowserDialog1.SelectedPath.ToString
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub FormAdress_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"

        'Declare the main SQLite data access objects
        Dim objConn As SQLiteConnection
        Dim objCommand As SQLiteCommand

        txtName.Select(0, 0)

        Select Case Me.Text

            Case "Адресат новый*"
                lblAdressate.Text = "Адресат новый"
                txtID.Text = ""
                txtName.Text = ""
                txtEmail.Text = ""
                txtFolderSend.Text = ""


                Rows_Total()

                If mx_count = 0 Then
                    result = 0
                Else
                    Call Last_Num()
                End If

                'Create a new database connection
                'Note - use New=True to create a new database
                objConn = New SQLiteConnection(connectionString & "New=True;")

                'Open the connection
                objConn.Open()

                'Create a new SQL command
                objCommand = objConn.CreateCommand()
                txtID.Text = result + 1
                'objCommand.CommandText = "INSERT INTO MAIL (ID, NAME,EMAIL,FOLDER) VALUES (" & txtID.Text & ", '" & txtName.Text & "','" & txtEmail.Text & "','" & txtFolderSend.Text & "');"
                'objCommand.ExecuteNonQuery()

            Case "Адресат редактирование"
                'txtName.Selec
                lblAdressate.Text = "Адресат редактирование"
                txtID.Text = Form1.DataGridView1.Item(0, Form1.DataGridView1.CurrentRow.Index).Value()
                txtName.Text = Form1.DataGridView1.Item(1, Form1.DataGridView1.CurrentRow.Index).Value()
                txtEmail.Text = Form1.DataGridView1.Item(2, Form1.DataGridView1.CurrentRow.Index).Value()
                txtFolderSend.Text = Form1.DataGridView1.Item(3, Form1.DataGridView1.CurrentRow.Index).Value()


        End Select

    End Sub

    Dim mx_count As Integer

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim connectionString As String = "Data Source=" & My.Application.Info.DirectoryPath & "\EmailBase.db3;Version=3;"
        'Dim sql As String = "SELECT MAX([ID]) FROM [MAIL]"

        'Declare the main SQLite data access objects
        Dim objConn As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try


            Select Case Me.Text

                Case "Адресат новый*"

                    Rows_Total()

                    If mx_count = 0 Then
                        result = 0
                    Else
                        Call Last_Num()
                    End If

                    'Create a new database connection
                    'Note - use New=True to create a new database
                    objConn = New SQLiteConnection(connectionString & "New=True;")

                    'Open the connection
                    objConn.Open()

                    'Create a new SQL command
                    objCommand = objConn.CreateCommand()
                    'txtID.Text = result + 1
                    objCommand.CommandText = "INSERT INTO MAIL (ID, NAME,EMAIL,FOLDER) VALUES (" & txtID.Text & ", '" & txtName.Text & "','" & txtEmail.Text & "','" & txtFolderSend.Text & "');"
                    objCommand.ExecuteNonQuery()
                    Form1.BaseConnect()
                    Me.Close()

                Case "Адресат редактирование"

                    'Create a new database connection
                    'Note - use New=True to create a new database
                    objConn = New SQLiteConnection(connectionString & "New=True;")

                    'Open the connection
                    objConn.Open()

                    'Create a new SQL command
                    objCommand = objConn.CreateCommand()
                    'txtID.Text = result + 1
                    objCommand.CommandText = "UPDATE MAIL SET NAME='" & txtName.Text & "', EMAIL='" & txtEmail.Text & "', FOLDER='" & txtFolderSend.Text & "' WHERE ID='" & txtID.Text & "'"
                    objCommand.ExecuteNonQuery()
                    Form1.BaseConnect()

                    Form1.DataGridView1.CurrentCell = Form1.DataGridView1.Rows(Form1.R_position).Cells(2)
                    Form1.DataGridView1.Rows.Item(Form1.R_position).Selected = True

                    Me.Close()

                    'Form1.DataGridView1.Item(0, Form1.DataGridView1.CurrentRow.Index).Value()
            End Select



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub FormAdress_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()

            Case Keys.Enter
                Button2_Click(e, e)
        End Select
    End Sub
End Class