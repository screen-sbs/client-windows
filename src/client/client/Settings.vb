Imports System.Text.RegularExpressions

Public Class Settings
    Private Sub updateUi()
        checkOpenInBrowser.Checked = My.Settings.openInBrowser
        checkPlayBeep.Checked = My.Settings.playBeep
        checkSaveLocally.Checked = My.Settings.saveLocally
        numericMaxLinks.Text = My.Settings.maxLinks.ToString
        numericVideoDuration.Text = My.Settings.maxVideoDuration.ToString
        localPath.Enabled = My.Settings.saveLocally
        localPath.Text = My.Settings.localPath
        btnLocalPath.Enabled = My.Settings.saveLocally
        checkCopyClipboard.Checked = My.Settings.copyLink
        checkUpdates.Checked = My.Settings.checkForUpdates
        checkHighlightClicks.Checked = My.Settings.highlightClicks
        keyFullscreenSC.Text = My.Settings.keyFullscreenSC
        modFullscreenSC.Text = My.Settings.modFullscreenSC
        keySelectionSC.Text = My.Settings.keySelectionSC
        modSelectionSC.Text = My.Settings.modSelectionSC
        keyFullscreenVID.Text = My.Settings.keyFullscreenVID
        modFullscreenVID.Text = My.Settings.modFullscreenVID
        keySelectionVID.Text = My.Settings.keySelectionVID
        modSelectionVID.Text = My.Settings.modSelectionVID
        keyOpenPaste.Text = My.Settings.keyOpenPaste
        modOpenPaste.Text = My.Settings.modOpenPaste
        keyPasteClipboard.Text = My.Settings.keyPasteClipboard
        modPasteClipboard.Text = My.Settings.modPasteClipboard
        token.Text = My.Settings.token
        uploadUrl.Text = My.Settings.serverUrl
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateUi()
    End Sub

    Private Sub Settings_Activate(sender As Object, e As EventArgs) Handles MyBase.Activated
        updateUi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.Save()
        startup.regHotkeys()
        updateUi()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.Reset()
        updateUi()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.Reload()
        updateUi()
    End Sub

    Private Sub checkOpenInBrowser_CheckedChanged(sender As Object, e As EventArgs) Handles checkOpenInBrowser.CheckedChanged
        My.Settings.openInBrowser = checkOpenInBrowser.Checked
        updateUi()
    End Sub

    Private Sub checkPlayBeep_CheckedChanged(sender As Object, e As EventArgs) Handles checkPlayBeep.CheckedChanged
        My.Settings.playBeep = checkPlayBeep.Checked
        updateUi()
    End Sub

    Private Sub numericMaxLinks_TextChanged(sender As Object, e As EventArgs) Handles numericMaxLinks.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(numericMaxLinks.Text, i)
        If i > 0 Then
            My.Settings.maxLinks = i
        End If
        updateUi()
    End Sub

    Private Sub numericVideoDuration_TextChanged(sender As Object, e As EventArgs) Handles numericVideoDuration.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(numericVideoDuration.Text, i)
        If i > 0 Then
            My.Settings.maxVideoDuration = i
        End If
        updateUi()
    End Sub

    Private videoNotificationShown As Boolean = False
    Private Sub numericVideoDuration_Click() Handles numericVideoDuration.Click
        If Not videoNotificationShown Then
            videoNotificationShown = True
            MessageBox.Show("Warning: The server will reject files bigger than 20MB. Be careful when increasing the video duration!")
        End If
        updateUi()
    End Sub

    Private Sub localPath_TextChanged(sender As Object, e As EventArgs) Handles localPath.TextChanged
        My.Settings.localPath = localPath.Text
        updateUi()
    End Sub

    Private Sub btnLocalPath_Click(sender As Object, e As EventArgs) Handles btnLocalPath.Click
        FBDialog.ShowDialog()
        My.Settings.localPath = FBDialog.SelectedPath
        updateUi()
    End Sub

    Private Sub checkSaveLocally_CheckedChanged(sender As Object, e As EventArgs) Handles checkSaveLocally.CheckedChanged
        My.Settings.saveLocally = checkSaveLocally.Checked
        updateUi()
    End Sub

    Private Sub checkCopyClipboard_CheckedChanged(sender As Object, e As EventArgs) Handles checkCopyClipboard.CheckedChanged
        My.Settings.copyLink = checkCopyClipboard.Checked
        updateUi()
    End Sub

    Private Sub checkUpdates_CheckedChanged(sender As Object, e As EventArgs) Handles checkUpdates.CheckedChanged
        My.Settings.checkForUpdates = checkUpdates.Checked
        updateUi()
    End Sub

    Private Sub checkNow_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles checkNow.LinkClicked
        startup.checkForUpdate(True)
    End Sub

    Private Sub checkHighlightClicks_CheckedChanged(sender As Object, e As EventArgs) Handles checkHighlightClicks.CheckedChanged
        My.Settings.highlightClicks = checkHighlightClicks.Checked
        updateUi()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-5.0")
    End Sub

    Private Sub keyFullscreenSC_TextChanged(sender As Object, e As EventArgs) Handles keyFullscreenSC.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(keyFullscreenSC.Text, i)
        My.Settings.keyFullscreenSC = i
    End Sub


    Private Sub keySelectionSC_TextChanged(sender As Object, e As EventArgs) Handles keySelectionSC.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(keySelectionSC.Text, i)
        My.Settings.keySelectionSC = i
    End Sub

    Private Sub keyFullscreenVID_TextChanged(sender As Object, e As EventArgs) Handles keyFullscreenVID.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(keyFullscreenVID.Text, i)
        My.Settings.keyFullscreenVID = i
    End Sub

    Private Sub keySelectionVID_TextChanged(sender As Object, e As EventArgs) Handles keySelectionVID.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(keySelectionVID.Text, i)
        My.Settings.keySelectionVID = i
    End Sub

    Private Sub keyOpenPaste_TextChanged(sender As Object, e As EventArgs) Handles keyOpenPaste.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(keyOpenPaste.Text, i)
        My.Settings.keyOpenPaste = i
    End Sub

    Private Sub keyPasteClipboard_TextChanged(sender As Object, e As EventArgs) Handles keyPasteClipboard.TextChanged
        Dim i As Integer = -1
        Int32.TryParse(keyPasteClipboard.Text, i)
        My.Settings.keyPasteClipboard = i
    End Sub

    Private Sub modFullscreenSC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modFullscreenSC.SelectedIndexChanged
        My.Settings.modFullscreenSC = modFullscreenSC.Text
    End Sub

    Private Sub modSelectionSC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modSelectionSC.SelectedIndexChanged
        My.Settings.modSelectionSC = modSelectionSC.Text
    End Sub

    Private Sub modFullscreenVID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modFullscreenVID.SelectedIndexChanged
        My.Settings.modFullscreenVID = modFullscreenVID.Text
    End Sub

    Private Sub modSelectionVID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modSelectionVID.SelectedIndexChanged
        My.Settings.modSelectionVID = modSelectionVID.Text
    End Sub

    Private Sub modOpenPaste_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modOpenPaste.SelectedIndexChanged
        My.Settings.modOpenPaste = modOpenPaste.Text
    End Sub

    Private Sub modPasteClipboard_SelectedIndexChanged(sender As Object, e As EventArgs) Handles modPasteClipboard.SelectedIndexChanged
        My.Settings.modPasteClipboard = modPasteClipboard.Text
    End Sub

    Private Sub token_TextChanged(sender As Object, e As EventArgs) Handles token.TextChanged
        My.Settings.token = token.Text
    End Sub

    Private Sub uploadUrl_TextChanged(sender As Object, e As EventArgs) Handles uploadUrl.TextChanged
        If uploadUrl.Text = "" Then
            My.Settings.serverUrl = "https://screen.sbs/"
        Else
            My.Settings.serverUrl = uploadUrl.Text
        End If
    End Sub
End Class
