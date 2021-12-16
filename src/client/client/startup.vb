Imports System.IO

Public Class startup
    Friend Sub NewArgumentsReceived(args As String())
        For Each s As String In args
            Upload.post(s)
        Next
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = Hotkey.WM_HOTKEY Then
            Hotkey.handleHotKeyEvent(m.WParam)
        End If
        MyBase.WndProc(m)
    End Sub

    Public Shared locked As Boolean = False

    Public Shared Sub lockMenu(Optional state As Boolean = True)
        locked = state
        If state = True Then
            state = False
        Else
            state = True
        End If
    End Sub

    Public Shared Sub checkForUpdate(Optional messagenoupdate As Boolean = False)
        Dim version As String = My.Application.Info.Version.ToString
        Try
            Using wc As New Net.WebClient
                version = wc.DownloadString("https://dl.screen.sbs/windows/version.txt")
            End Using
        Catch ex As Exception
        End Try

        If Not version.Replace(vbCr, "").Replace(vbLf, "") = My.Application.Info.Version.ToString Then
            Dim result As DialogResult = MessageBox.Show("New screen.sbs update available!" + vbNewLine + "Update now?", "screen.sbs", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Try
                    If File.Exists(Path.GetTempPath + "setup-screen.sbs.exe") Then
                        Try
                            File.Delete(Path.GetTempPath + "setup-screen.sbs.exe")
                        Catch ex As Exception
                        End Try
                    End If
                    Using wc As New Net.WebClient
                        wc.DownloadFile("https://dl.screen.sbs/windows/setup/latest.exe", Path.GetTempPath + "setup-screen.sbs.exe")
                    End Using
                    Process.Start(Path.GetTempPath + "setup-screen.sbs.exe")
                Catch ex As Exception
                End Try
            End If
        Else
            If messagenoupdate Then
                MessageBox.Show("No updates found.")
            End If
        End If
    End Sub

    Private Shared Function modSettingsToKM(modifier As String)
        Select Case modifier
            Case "Ctrl"
                Return Hotkey.KeyModifier.Control
            Case "Shift"
                Return Hotkey.KeyModifier.Shift
            Case "Alt"
                Return Hotkey.KeyModifier.Alt
            Case "None"
                Return Hotkey.KeyModifier.None
            Case "Win"
                Return Hotkey.KeyModifier.Winkey
        End Select
        Return Hotkey.KeyModifier.None
    End Function

    Public Shared Sub regHotkeys()
        Try
            Hotkey.unregisterAllHotkeys(startup)
        Catch ex As Exception
        End Try

        If Not My.Settings.keyFullscreenSC = -1 Then Hotkey.registerHotkey(startup, 1, My.Settings.keyFullscreenSC, modSettingsToKM(My.Settings.modFullscreenSC))
        If Not My.Settings.keySelectionSC = -1 Then Hotkey.registerHotkey(startup, 2, My.Settings.keySelectionSC, modSettingsToKM(My.Settings.modSelectionSC))
        If Not My.Settings.keyFullscreenVID = -1 Then Hotkey.registerHotkey(startup, 3, My.Settings.keyFullscreenVID, modSettingsToKM(My.Settings.modFullscreenVID))
        If Not My.Settings.keySelectionVID = -1 Then Hotkey.registerHotkey(startup, 4, My.Settings.keySelectionVID, modSettingsToKM(My.Settings.modSelectionVID))
        If Not My.Settings.keyOpenPaste = -1 Then Hotkey.registerHotkey(startup, 5, My.Settings.keyOpenPaste, modSettingsToKM(My.Settings.modOpenPaste))
        If Not My.Settings.keyPasteClipboard = -1 Then Hotkey.registerHotkey(startup, 6, My.Settings.keyPasteClipboard, modSettingsToKM(My.Settings.modPasteClipboard))
    End Sub

    Private Sub startup_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Hotkey.unregisterAllHotkeys(Me)
    End Sub

    Private Sub startup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Settings.Upgrade()
        Catch ex As Exception
        End Try
        Me.Hide()
        Me.WindowState = WindowState.Minimized
        regHotkeys()
        If My.Settings.checkForUpdates Then checkForUpdate()
    End Sub

    Private Sub menuTakeScreenshot_Click(sender As Object, e As EventArgs) Handles menuTakeScreenshot.Click
        CaptureScreen.Selection()
    End Sub

    Private Sub menuExit_Click(sender As Object, e As EventArgs) Handles menuExit.Click
        Hotkey.unregisterAllHotkeys(Me)
        End
    End Sub

    Private Sub menuCaptureVideo_Click(sender As Object, e As EventArgs) Handles menuCaptureVideo.Click
        CaptureScreen.Selection(True)
    End Sub

    Private Sub menuLinkHistory_Click(sender As Object, e As EventArgs) Handles menuLinkHistory.Click
        LinkList.Show()
    End Sub

    Private Sub menuSettings_Click(sender As Object, e As EventArgs) Handles menuSettings.Click
        Settings.Show()
    End Sub

    Private Sub menuPasteText_Click(sender As Object, e As EventArgs) Handles menuPasteText.Click
        Paste.Show()
    End Sub
End Class