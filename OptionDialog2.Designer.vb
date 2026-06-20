<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionDialog2
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionDialog2))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtSubject1 = New System.Windows.Forms.TextBox()
        Me.txtSaveOptions = New System.Windows.Forms.Button()
        Me.txtPortNumber = New System.Windows.Forms.TextBox()
        Me.txtSMTPServer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkSSL = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butExport = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.butImport = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.butTestEmail = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.grBox = New System.Windows.Forms.GroupBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grBox.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(761, 473)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "ОК"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Отмена"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.txtSubject1)
        Me.GroupBox1.Controls.Add(Me.txtSaveOptions)
        Me.GroupBox1.Controls.Add(Me.txtPortNumber)
        Me.GroupBox1.Controls.Add(Me.txtSMTPServer)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtFrom)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtLogin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.chkSSL)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 104)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(238, 345)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Настройки (SMTP) - сервера"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 254)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(211, 36)
        Me.TextBox1.TabIndex = 13
        '
        'txtSubject1
        '
        Me.txtSubject1.Location = New System.Drawing.Point(58, 223)
        Me.txtSubject1.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSubject1.Name = "txtSubject1"
        Me.txtSubject1.Size = New System.Drawing.Size(162, 20)
        Me.txtSubject1.TabIndex = 12
        '
        'txtSaveOptions
        '
        Me.txtSaveOptions.Location = New System.Drawing.Point(8, 306)
        Me.txtSaveOptions.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSaveOptions.Name = "txtSaveOptions"
        Me.txtSaveOptions.Size = New System.Drawing.Size(211, 26)
        Me.txtSaveOptions.TabIndex = 11
        Me.txtSaveOptions.Text = "Сохранить настройки"
        Me.txtSaveOptions.UseVisualStyleBackColor = True
        '
        'txtPortNumber
        '
        Me.txtPortNumber.Enabled = False
        Me.txtPortNumber.Location = New System.Drawing.Point(99, 120)
        Me.txtPortNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPortNumber.Name = "txtPortNumber"
        Me.txtPortNumber.Size = New System.Drawing.Size(120, 20)
        Me.txtPortNumber.TabIndex = 10
        Me.txtPortNumber.Text = "587"
        '
        'txtSMTPServer
        '
        Me.txtSMTPServer.Enabled = False
        Me.txtSMTPServer.Location = New System.Drawing.Point(98, 86)
        Me.txtSMTPServer.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSMTPServer.Name = "txtSMTPServer"
        Me.txtSMTPServer.Size = New System.Drawing.Size(121, 20)
        Me.txtSMTPServer.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 226)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Тема:"
        '
        'txtFrom
        '
        Me.txtFrom.Enabled = False
        Me.txtFrom.Location = New System.Drawing.Point(56, 189)
        Me.txtFrom.Margin = New System.Windows.Forms.Padding(2)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(163, 20)
        Me.txtFrom.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(98, 54)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(121, 20)
        Me.txtPassword.TabIndex = 8
        '
        'txtLogin
        '
        Me.txtLogin.Enabled = False
        Me.txtLogin.Location = New System.Drawing.Point(99, 27)
        Me.txtLogin.Margin = New System.Windows.Forms.Padding(2)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(120, 20)
        Me.txtLogin.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 189)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "От кого:"
        '
        'chkSSL
        '
        Me.chkSSL.AutoSize = True
        Me.chkSSL.Enabled = False
        Me.chkSSL.Location = New System.Drawing.Point(20, 155)
        Me.chkSSL.Margin = New System.Windows.Forms.Padding(2)
        Me.chkSSL.Name = "chkSSL"
        Me.chkSSL.Size = New System.Drawing.Size(140, 17)
        Me.chkSSL.TabIndex = 6
        Me.chkSSL.Text = "Защита SSL включена"
        Me.chkSSL.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 120)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Номер порта:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 86)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "SMTP Сервер:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Пароль:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Логин:"
        '
        'butExport
        '
        Me.butExport.Location = New System.Drawing.Point(445, 95)
        Me.butExport.Margin = New System.Windows.Forms.Padding(2)
        Me.butExport.Name = "butExport"
        Me.butExport.Size = New System.Drawing.Size(208, 31)
        Me.butExport.TabIndex = 8
        Me.butExport.Text = "Экспорт E-Mail адресов в файл CSV"
        Me.butExport.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(308, 69)
        Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(102, 13)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Пример файла.csv"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(9, 41)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(432, 46)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = resources.GetString("Label11.Text")
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(11, 22)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 14)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "ВНИМАНИЕ:"
        '
        'butImport
        '
        Me.butImport.Location = New System.Drawing.Point(445, 41)
        Me.butImport.Margin = New System.Windows.Forms.Padding(2)
        Me.butImport.Name = "butImport"
        Me.butImport.Size = New System.Drawing.Size(208, 31)
        Me.butImport.TabIndex = 4
        Me.butImport.Text = "Импорт E-Mail адресов из файла CSV"
        Me.butImport.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 98)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(432, 28)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Для выгрузки из программы адресов электронной почты нажмите кнопку -""Экспорт E-Ma" &
    "il адресов в файл CSV""."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtMessage)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtSubject)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtTo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.butTestEmail)
        Me.GroupBox2.Location = New System.Drawing.Point(253, 104)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(240, 158)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Тестовое письмо"
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(69, 82)
        Me.txtMessage.Margin = New System.Windows.Forms.Padding(2)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(150, 19)
        Me.txtMessage.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(-2, 86)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Сообщение:"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(69, 54)
        Me.txtSubject.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(150, 20)
        Me.txtSubject.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 58)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Тема:"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(69, 29)
        Me.txtTo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(150, 20)
        Me.txtTo.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 29)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Кому:"
        '
        'butTestEmail
        '
        Me.butTestEmail.Location = New System.Drawing.Point(12, 116)
        Me.butTestEmail.Margin = New System.Windows.Forms.Padding(2)
        Me.butTestEmail.Name = "butTestEmail"
        Me.butTestEmail.Size = New System.Drawing.Size(206, 26)
        Me.butTestEmail.TabIndex = 0
        Me.butTestEmail.Text = "Отправить тестовое письмо!"
        Me.butTestEmail.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.butImport)
        Me.GroupBox5.Controls.Add(Me.butExport)
        Me.GroupBox5.Controls.Add(Me.LinkLabel1)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Location = New System.Drawing.Point(254, 267)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox5.Size = New System.Drawing.Size(666, 183)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "(Импорт\Экспорт) E-Mail адресов из файла CSV"
        '
        'grBox
        '
        Me.grBox.Controls.Add(Me.CheckBox4)
        Me.grBox.Controls.Add(Me.CheckBox3)
        Me.grBox.Controls.Add(Me.CheckBox2)
        Me.grBox.Controls.Add(Me.CheckBox1)
        Me.grBox.Location = New System.Drawing.Point(502, 104)
        Me.grBox.Margin = New System.Windows.Forms.Padding(2)
        Me.grBox.Name = "grBox"
        Me.grBox.Padding = New System.Windows.Forms.Padding(2)
        Me.grBox.Size = New System.Drawing.Size(418, 158)
        Me.grBox.TabIndex = 9
        Me.grBox.TabStop = False
        Me.grBox.Text = "Уведомления"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(24, 94)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(236, 17)
        Me.CheckBox4.TabIndex = 3
        Me.CheckBox4.Text = "Сообщать только о критических ошибках"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(24, 48)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(324, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Сворачивать окно программы при нажатии кнопки ""Пуск"""
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(24, 71)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(265, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Отключить звуковые уведомления программы"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(24, 25)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(299, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Сворачивать окно программы вместе с окном в трей"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(81, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(174, 16)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Настройки программы"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(937, 71)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'OptionDialog2
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(932, 514)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.grBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionDialog2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Настройки"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.grBox.ResumeLayout(False)
        Me.grBox.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtSubject1 As TextBox
    Friend WithEvents txtSaveOptions As Button
    Friend WithEvents txtPortNumber As TextBox
    Friend WithEvents txtSMTPServer As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtFrom As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkSSL As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents butExport As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents butImport As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtMessage As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents butTestEmail As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents grBox As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label13 As Label
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
