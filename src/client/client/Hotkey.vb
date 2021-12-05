'https://gist.github.com/kirsbo/3b01a1412311e7a1d565

Public Class Hotkey
#Region "Declarations - WinAPI, Hotkey constant and Modifier Enum"
    Private Declare Function RegisterHotKey Lib "user32" _
    (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer

    Private Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer

    Public Const WM_HOTKEY As Integer = &H312

    Enum KeyModifier
        None = 0
        Alt = &H1
        Control = &H2
        Shift = &H4
        Winkey = &H8
    End Enum
#End Region

#Region "Hotkey registration, unregistration and handling"
    Public Shared hotkeysArr As New List(Of Integer)
    Public Shared Sub registerHotkey(ByRef sourceForm As Form, ByVal hotkeyID As Integer, ByVal triggerKey As Integer, ByVal modifier As KeyModifier)
        RegisterHotKey(sourceForm.Handle, hotkeyID, modifier, triggerKey)
        hotkeysArr.Add(hotkeyID)
    End Sub
    Public Shared Sub unregisterHotkey(ByRef sourceForm As Form, ByVal hotkeyID As IntPtr)
        UnregisterHotKey(sourceForm.Handle, hotkeyID)
        hotkeysArr.Remove(hotkeyID)
    End Sub
    Public Shared Sub unregisterAllHotkeys(ByRef sourceForm As Form, Optional ByVal pause As Boolean = False)
        If pause Then
            For Each i As IntPtr In hotkeysArr
                If Not i = 1 Then UnregisterHotKey(sourceForm.Handle, i)
            Next
        Else
            For Each i As IntPtr In hotkeysArr
                UnregisterHotKey(sourceForm.Handle, i)
            Next
        End If

        hotkeysArr = New List(Of Integer)
    End Sub
    Public Shared Sub handleHotKeyEvent(ByVal hotkeyID As IntPtr)
        Select Case hotkeyID
            Case 1
                If startup.locked = False Then CaptureScreen.Fullscreen()
            Case 2
                If startup.locked = False Then CaptureScreen.Selection()
            Case 3
                If startup.locked = False Then
                    CaptureScreen.Fullscreen(True)
                Else
                    CaptureScreen.stopRecording()
                End If
            Case 4
                If startup.locked = False Then
                    CaptureScreen.Selection(True)
                Else
                    CaptureScreen.stopRecording()
                End If
            Case 5
                Paste.Show()
            Case 6
                Dim cb = Clipboard.GetText()
                If Not cb = "" And
                        Not cb = " " And
                        Not cb = vbCrLf And
                        Not cb = vbCr And
                        Not cb = vbLf Then
                    Paste.uploadText(Clipboard.GetText)
                End If
        End Select
    End Sub
#End Region

End Class