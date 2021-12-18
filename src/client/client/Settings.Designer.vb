<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.checkOpenInBrowser = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.checkPlayBeep = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.checkSaveLocally = New System.Windows.Forms.CheckBox()
        Me.localPath = New System.Windows.Forms.TextBox()
        Me.btnLocalPath = New System.Windows.Forms.Button()
        Me.FBDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numericMaxLinks = New System.Windows.Forms.TextBox()
        Me.numericVideoDuration = New System.Windows.Forms.TextBox()
        Me.checkCopyClipboard = New System.Windows.Forms.CheckBox()
        Me.checkUpdates = New System.Windows.Forms.CheckBox()
        Me.checkNow = New System.Windows.Forms.LinkLabel()
        Me.checkHighlightClicks = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.keyPasteClipboard = New System.Windows.Forms.TextBox()
        Me.modPasteClipboard = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.keyOpenPaste = New System.Windows.Forms.TextBox()
        Me.modOpenPaste = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.keySelectionVID = New System.Windows.Forms.TextBox()
        Me.modSelectionVID = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.keyFullscreenVID = New System.Windows.Forms.TextBox()
        Me.modFullscreenVID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.keySelectionSC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.modSelectionSC = New System.Windows.Forms.ComboBox()
        Me.keyFullscreenSC = New System.Windows.Forms.TextBox()
        Me.modFullscreenSC = New System.Windows.Forms.ComboBox()
        Me.token = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.uploadUrl = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'checkOpenInBrowser
        '
        Me.checkOpenInBrowser.AutoSize = True
        Me.checkOpenInBrowser.Location = New System.Drawing.Point(9, 15)
        Me.checkOpenInBrowser.Name = "checkOpenInBrowser"
        Me.checkOpenInBrowser.Size = New System.Drawing.Size(174, 17)
        Me.checkOpenInBrowser.TabIndex = 1
        Me.checkOpenInBrowser.Text = "Open in browser after capturing"
        Me.checkOpenInBrowser.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(299, 332)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(354, 303)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(49, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(299, 303)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(49, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Undo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'checkPlayBeep
        '
        Me.checkPlayBeep.AutoSize = True
        Me.checkPlayBeep.Location = New System.Drawing.Point(9, 38)
        Me.checkPlayBeep.Name = "checkPlayBeep"
        Me.checkPlayBeep.Size = New System.Drawing.Size(73, 17)
        Me.checkPlayBeep.TabIndex = 5
        Me.checkPlayBeep.Text = "Play beep"
        Me.checkPlayBeep.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Max. links to keep"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Max. video duration"
        '
        'checkSaveLocally
        '
        Me.checkSaveLocally.AutoSize = True
        Me.checkSaveLocally.Location = New System.Drawing.Point(72, 0)
        Me.checkSaveLocally.Name = "checkSaveLocally"
        Me.checkSaveLocally.Size = New System.Drawing.Size(15, 14)
        Me.checkSaveLocally.TabIndex = 10
        Me.checkSaveLocally.UseVisualStyleBackColor = True
        '
        'localPath
        '
        Me.localPath.Location = New System.Drawing.Point(6, 20)
        Me.localPath.Name = "localPath"
        Me.localPath.Size = New System.Drawing.Size(122, 20)
        Me.localPath.TabIndex = 11
        '
        'btnLocalPath
        '
        Me.btnLocalPath.Location = New System.Drawing.Point(130, 19)
        Me.btnLocalPath.Name = "btnLocalPath"
        Me.btnLocalPath.Size = New System.Drawing.Size(26, 22)
        Me.btnLocalPath.TabIndex = 12
        Me.btnLocalPath.Text = ".."
        Me.btnLocalPath.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.checkSaveLocally)
        Me.GroupBox1.Controls.Add(Me.btnLocalPath)
        Me.GroupBox1.Controls.Add(Me.localPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 303)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(162, 47)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Save locally"
        '
        'numericMaxLinks
        '
        Me.numericMaxLinks.Location = New System.Drawing.Point(129, 59)
        Me.numericMaxLinks.Name = "numericMaxLinks"
        Me.numericMaxLinks.Size = New System.Drawing.Size(30, 20)
        Me.numericMaxLinks.TabIndex = 14
        '
        'numericVideoDuration
        '
        Me.numericVideoDuration.Location = New System.Drawing.Point(129, 84)
        Me.numericVideoDuration.Name = "numericVideoDuration"
        Me.numericVideoDuration.Size = New System.Drawing.Size(30, 20)
        Me.numericVideoDuration.TabIndex = 15
        '
        'checkCopyClipboard
        '
        Me.checkCopyClipboard.AutoSize = True
        Me.checkCopyClipboard.Location = New System.Drawing.Point(11, 108)
        Me.checkCopyClipboard.Name = "checkCopyClipboard"
        Me.checkCopyClipboard.Size = New System.Drawing.Size(127, 17)
        Me.checkCopyClipboard.TabIndex = 16
        Me.checkCopyClipboard.Text = "Copy link to clipboard"
        Me.checkCopyClipboard.UseVisualStyleBackColor = True
        '
        'checkUpdates
        '
        Me.checkUpdates.AutoSize = True
        Me.checkUpdates.Location = New System.Drawing.Point(11, 131)
        Me.checkUpdates.Name = "checkUpdates"
        Me.checkUpdates.Size = New System.Drawing.Size(163, 17)
        Me.checkUpdates.TabIndex = 17
        Me.checkUpdates.Text = "Check for updates on startup"
        Me.checkUpdates.UseVisualStyleBackColor = True
        '
        'checkNow
        '
        Me.checkNow.AutoSize = True
        Me.checkNow.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.checkNow.Location = New System.Drawing.Point(329, 0)
        Me.checkNow.Name = "checkNow"
        Me.checkNow.Size = New System.Drawing.Size(82, 12)
        Me.checkNow.TabIndex = 18
        Me.checkNow.TabStop = True
        Me.checkNow.Text = "Check for Updates"
        '
        'checkHighlightClicks
        '
        Me.checkHighlightClicks.AutoSize = True
        Me.checkHighlightClicks.Location = New System.Drawing.Point(11, 150)
        Me.checkHighlightClicks.Name = "checkHighlightClicks"
        Me.checkHighlightClicks.Size = New System.Drawing.Size(142, 17)
        Me.checkHighlightClicks.TabIndex = 19
        Me.checkHighlightClicks.Text = "Highlight clicks in videos"
        Me.checkHighlightClicks.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.keyPasteClipboard)
        Me.GroupBox2.Controls.Add(Me.modPasteClipboard)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.keyOpenPaste)
        Me.GroupBox2.Controls.Add(Me.modOpenPaste)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.keySelectionVID)
        Me.GroupBox2.Controls.Add(Me.modSelectionVID)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.keyFullscreenVID)
        Me.GroupBox2.Controls.Add(Me.modFullscreenVID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.LinkLabel1)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.keySelectionSC)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.modSelectionSC)
        Me.GroupBox2.Controls.Add(Me.keyFullscreenSC)
        Me.GroupBox2.Controls.Add(Me.modFullscreenSC)
        Me.GroupBox2.Location = New System.Drawing.Point(207, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 200)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hotkeys"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(112, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 12)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Set key to -1 to disable"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 158)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Paste Clipboard"
        '
        'keyPasteClipboard
        '
        Me.keyPasteClipboard.Location = New System.Drawing.Point(167, 159)
        Me.keyPasteClipboard.Name = "keyPasteClipboard"
        Me.keyPasteClipboard.Size = New System.Drawing.Size(44, 20)
        Me.keyPasteClipboard.TabIndex = 38
        '
        'modPasteClipboard
        '
        Me.modPasteClipboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modPasteClipboard.FormattingEnabled = True
        Me.modPasteClipboard.Items.AddRange(New Object() {"None", "Ctrl", "Shift", "Alt", "Win"})
        Me.modPasteClipboard.Location = New System.Drawing.Point(100, 159)
        Me.modPasteClipboard.Name = "modPasteClipboard"
        Me.modPasteClipboard.Size = New System.Drawing.Size(61, 21)
        Me.modPasteClipboard.TabIndex = 37
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 131)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Open Paste"
        '
        'keyOpenPaste
        '
        Me.keyOpenPaste.Location = New System.Drawing.Point(167, 132)
        Me.keyOpenPaste.Name = "keyOpenPaste"
        Me.keyOpenPaste.Size = New System.Drawing.Size(44, 20)
        Me.keyOpenPaste.TabIndex = 34
        '
        'modOpenPaste
        '
        Me.modOpenPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modOpenPaste.FormattingEnabled = True
        Me.modOpenPaste.Items.AddRange(New Object() {"None", "Ctrl", "Shift", "Alt", "Win"})
        Me.modOpenPaste.Location = New System.Drawing.Point(100, 132)
        Me.modOpenPaste.Name = "modOpenPaste"
        Me.modOpenPaste.Size = New System.Drawing.Size(61, 21)
        Me.modOpenPaste.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Video toggle"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.Label10.Location = New System.Drawing.Point(7, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 12)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "(Selection)"
        '
        'keySelectionVID
        '
        Me.keySelectionVID.Location = New System.Drawing.Point(167, 105)
        Me.keySelectionVID.Name = "keySelectionVID"
        Me.keySelectionVID.Size = New System.Drawing.Size(44, 20)
        Me.keySelectionVID.TabIndex = 30
        '
        'modSelectionVID
        '
        Me.modSelectionVID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modSelectionVID.FormattingEnabled = True
        Me.modSelectionVID.Items.AddRange(New Object() {"None", "Ctrl", "Shift", "Alt", "Win"})
        Me.modSelectionVID.Location = New System.Drawing.Point(100, 105)
        Me.modSelectionVID.Name = "modSelectionVID"
        Me.modSelectionVID.Size = New System.Drawing.Size(61, 21)
        Me.modSelectionVID.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Video toggle"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.Label8.Location = New System.Drawing.Point(7, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 12)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "(Fullscreen primary)"
        '
        'keyFullscreenVID
        '
        Me.keyFullscreenVID.Location = New System.Drawing.Point(167, 77)
        Me.keyFullscreenVID.Name = "keyFullscreenVID"
        Me.keyFullscreenVID.Size = New System.Drawing.Size(44, 20)
        Me.keyFullscreenVID.TabIndex = 26
        '
        'modFullscreenVID
        '
        Me.modFullscreenVID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modFullscreenVID.FormattingEnabled = True
        Me.modFullscreenVID.Items.AddRange(New Object() {"None", "Ctrl", "Shift", "Alt", "Win"})
        Me.modFullscreenVID.Location = New System.Drawing.Point(100, 77)
        Me.modFullscreenVID.Name = "modFullscreenVID"
        Me.modFullscreenVID.Size = New System.Drawing.Size(61, 21)
        Me.modFullscreenVID.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Screenshot"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(200, -1)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(13, 13)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "?"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.Label6.Location = New System.Drawing.Point(7, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 12)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "(Selection)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Screenshot"
        '
        'keySelectionSC
        '
        Me.keySelectionSC.Location = New System.Drawing.Point(167, 50)
        Me.keySelectionSC.Name = "keySelectionSC"
        Me.keySelectionSC.Size = New System.Drawing.Size(44, 20)
        Me.keySelectionSC.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.25!)
        Me.Label4.Location = New System.Drawing.Point(7, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 12)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "(Fullscreen primary)"
        '
        'modSelectionSC
        '
        Me.modSelectionSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modSelectionSC.FormattingEnabled = True
        Me.modSelectionSC.Items.AddRange(New Object() {"None", "Ctrl", "Shift", "Alt", "Win"})
        Me.modSelectionSC.Location = New System.Drawing.Point(100, 50)
        Me.modSelectionSC.Name = "modSelectionSC"
        Me.modSelectionSC.Size = New System.Drawing.Size(61, 21)
        Me.modSelectionSC.TabIndex = 21
        '
        'keyFullscreenSC
        '
        Me.keyFullscreenSC.Location = New System.Drawing.Point(167, 23)
        Me.keyFullscreenSC.Name = "keyFullscreenSC"
        Me.keyFullscreenSC.Size = New System.Drawing.Size(44, 20)
        Me.keyFullscreenSC.TabIndex = 1
        '
        'modFullscreenSC
        '
        Me.modFullscreenSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modFullscreenSC.FormattingEnabled = True
        Me.modFullscreenSC.Items.AddRange(New Object() {"None", "Ctrl", "Shift", "Alt", "Win"})
        Me.modFullscreenSC.Location = New System.Drawing.Point(100, 23)
        Me.modFullscreenSC.Name = "modFullscreenSC"
        Me.modFullscreenSC.Size = New System.Drawing.Size(61, 21)
        Me.modFullscreenSC.TabIndex = 0
        '
        'token
        '
        Me.token.Location = New System.Drawing.Point(72, 19)
        Me.token.Name = "token"
        Me.token.Size = New System.Drawing.Size(334, 20)
        Me.token.TabIndex = 21
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.uploadUrl)
        Me.GroupBox3.Controls.Add(Me.token)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(412, 74)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Upload settings"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Server URL"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Token"
        '
        'uploadUrl
        '
        Me.uploadUrl.Location = New System.Drawing.Point(72, 45)
        Me.uploadUrl.Name = "uploadUrl"
        Me.uploadUrl.Size = New System.Drawing.Size(334, 20)
        Me.uploadUrl.TabIndex = 22
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.checkOpenInBrowser)
        Me.GroupBox4.Controls.Add(Me.checkPlayBeep)
        Me.GroupBox4.Controls.Add(Me.checkHighlightClicks)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.numericMaxLinks)
        Me.GroupBox4.Controls.Add(Me.checkUpdates)
        Me.GroupBox4.Controls.Add(Me.checkCopyClipboard)
        Me.GroupBox4.Controls.Add(Me.numericVideoDuration)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(189, 200)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Misc"
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 366)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.checkNow)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.Text = "screen.sbs"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents checkOpenInBrowser As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents checkPlayBeep As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents checkSaveLocally As CheckBox
    Friend WithEvents localPath As TextBox
    Friend WithEvents btnLocalPath As Button
    Friend WithEvents FBDialog As FolderBrowserDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents numericMaxLinks As TextBox
    Friend WithEvents numericVideoDuration As TextBox
    Friend WithEvents checkCopyClipboard As CheckBox
    Friend WithEvents checkUpdates As CheckBox
    Friend WithEvents checkNow As LinkLabel
    Friend WithEvents checkHighlightClicks As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents keyFullscreenSC As TextBox
    Friend WithEvents modFullscreenSC As ComboBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label13 As Label
    Friend WithEvents keyPasteClipboard As TextBox
    Friend WithEvents modPasteClipboard As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents keyOpenPaste As TextBox
    Friend WithEvents modOpenPaste As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents keySelectionVID As TextBox
    Friend WithEvents modSelectionVID As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents keyFullscreenVID As TextBox
    Friend WithEvents modFullscreenVID As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents keySelectionSC As TextBox
    Friend WithEvents modSelectionSC As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents token As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents uploadUrl As TextBox
End Class
