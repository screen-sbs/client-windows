Imports System.Environment
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports ScreenRecorderLib

Public Class CaptureScreen
    Private Shared r As New Random
    Public Shared Function RandomString(length As Integer)
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim sb As New StringBuilder
        For i As Integer = 1 To length
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function


    Private Shared MouseHook As InputHelper.Hooks.MouseHook
    Private Shared frmClickBlock As Form
    Private Shared frmSelection As Form
    Private Shared currentlySelecting As Boolean = False
    Private Shared MouseDownLocation As Point
    Private Shared video As Boolean
    Private Shared WithEvents cursorTimer As Windows.Forms.Timer
    Private Shared curBlack As New Cursor(New IO.MemoryStream(My.Resources.black))
    Private Shared curRed As New Cursor(New IO.MemoryStream(My.Resources.red))

    Public Shared Sub Selection(Optional vid As Boolean = False)
        If MouseHook Is Nothing Then
            video = vid
            MouseHook = New InputHelper.Hooks.MouseHook
            AddHandler MouseHook.MouseMove, AddressOf MouseHook_MouseMove
            AddHandler MouseHook.MouseDown, AddressOf MouseHook_MouseDown
            AddHandler MouseHook.MouseUp, AddressOf MouseHook_MouseUp

            frmClickBlock = New Form With {
                .TransparencyKey = Color.Yellow,
                .BackColor = Color.Yellow,
                .Size = New Point(16, 16),
                .FormBorderStyle = FormBorderStyle.None,
                .TopMost = True,
                .ShowInTaskbar = False,
                .ShowIcon = False,
                .Cursor = Cursors.Cross
            }
            ',
            '.Cusor = curBlack


            frmClickBlock.Show()

            'cursorTimer = New Windows.Forms.Timer
            'cursorTimer.Interval = 500
            'cursorTimer.Start()

            frmSelection = New Selector With {
                .Size = New Point(2, 2),
                .Opacity = 0
            }
            frmSelection.Show()
            startup.lockMenu(True)
        End If
    End Sub

    Public Shared Sub Fullscreen(Optional vid As Boolean = False)
        startup.lockMenu(True)
        video = vid

        If video Then
            record(Windows.Forms.Screen.PrimaryScreen.Bounds.Location, Windows.Forms.Screen.PrimaryScreen.Bounds.Size, True)
        Else
            takeScreenshot(Windows.Forms.Screen.PrimaryScreen.Bounds.Location, Windows.Forms.Screen.PrimaryScreen.Bounds.Size)
        End If
    End Sub

    Private Shared Sub blinkCursor() Handles cursorTimer.Tick
        If frmClickBlock.Cursor = curBlack Then
            frmClickBlock.Cursor = curRed
        Else
            frmClickBlock.Cursor = curBlack
        End If
    End Sub

    Private Shared filepath

    Private Shared Sub takeScreenshot(location As Point, size As Point)
        filepath = Path.GetTempPath + "screen_sbs_" + RandomString(12) + ".png"
        Dim screenGrab As New Bitmap(size.X, size.Y)
        Dim g As Graphics = Graphics.FromImage(screenGrab)
        g.CopyFromScreen(location, New Point(0, 0), size)
        screenGrab.Save(filepath, Imaging.ImageFormat.Png)

        Upload.post(filepath)
        startup.lockMenu(False)
    End Sub

    Private Shared rec As Recorder
    Public Shared starttime As DateTime
    Private Shared WithEvents durationTimer As New Windows.Forms.Timer
    Private Shared border As Form
    Private Shared control As Form

    Private Shared Sub record(location As Point, size As Point, Optional noui As Boolean = False)
        filepath = Path.GetTempPath + "screen_sbs_" + RandomString(12) + ".mp4"

        Dim opts As New RecorderOptions
        opts.DisplayOptions = New DisplayOptions

        Dim capScreen = Windows.Forms.Screen.FromPoint(location)
        opts.DisplayOptions.MonitorDeviceName = capScreen.DeviceName

        'TODO: add conditions for "diagonal" screens
        Dim relativeLocation As Point = location
        If Not capScreen.DeviceName = Windows.Forms.Screen.PrimaryScreen.DeviceName Then
            If capScreen.Bounds.X = 0 And capScreen.Bounds.Y < 0 Then
                ' Top
                relativeLocation = New Point(Math.Abs(capScreen.Bounds.X) + Math.Abs(location.X),
                                             Math.Abs(capScreen.Bounds.Y) - Math.Abs(location.Y))
            ElseIf capScreen.Bounds.X < 0 And capScreen.Bounds.Y = 0 Then
                ' Left
                relativeLocation = New Point(Math.Abs(capScreen.Bounds.X) - Math.Abs(location.X),
                                             Math.Abs(capScreen.Bounds.Y) + Math.Abs(location.Y))
            ElseIf capScreen.Bounds.X > 0 And capScreen.Bounds.Y = 0 Then
                ' Right
                relativeLocation = New Point(Math.Abs(location.X) - Math.Abs(capScreen.Bounds.X),
                                             Math.Abs(capScreen.Bounds.Y) + Math.Abs(location.Y))
            ElseIf capScreen.Bounds.X = 0 And capScreen.Bounds.Y > 0 Then
                ' Bottom
                relativeLocation = New Point(Math.Abs(capScreen.Bounds.X) + Math.Abs(location.X),
                                             Math.Abs(location.Y) - Math.Abs(capScreen.Bounds.Y))
            End If
        End If

        If relativeLocation.X > capScreen.Bounds.Width Or
           relativeLocation.X < 0 Or
           relativeLocation.Y > capScreen.Bounds.Height Or
           relativeLocation.Y < 0 Then
            MessageBox.Show("Error getting screen coordinates." + vbNewLine + capScreen.Bounds.ToString + vbNewLine + relativeLocation.ToString)
        Else
            opts.DisplayOptions.Left = relativeLocation.X
            opts.DisplayOptions.Right = relativeLocation.X + size.X
            opts.DisplayOptions.Top = relativeLocation.Y
            opts.DisplayOptions.Bottom = relativeLocation.Y + size.Y

            opts.RecorderApi = RecorderApi.DesktopDuplication

            opts.VideoOptions = New VideoOptions
            opts.VideoOptions.BitrateMode = BitrateControlMode.UnconstrainedVBR
            opts.VideoOptions.EncoderProfile = H264Profile.Baseline
            opts.VideoOptions.Bitrate = 6000 * 1000
            opts.VideoOptions.Framerate = 29
            opts.VideoOptions.Quality = 80

            If My.Settings.highlightClicks Then
                opts.MouseOptions = New MouseOptions
                opts.MouseOptions.IsMouseClicksDetected = True
                opts.MouseOptions.MouseClickDetectionDuration = 120
                opts.MouseOptions.MouseClickDetectionRadius = 18
                opts.MouseOptions.MouseClickDetectionColor = "#AB2DC2"
                opts.MouseOptions.MouseRightClickDetectionColor = "#46D907"
                opts.MouseOptions.MouseClickDetectionMode = MouseDetectionMode.Polling
            End If

            durationTimer.Interval = 500

            border = New frmBorder
            control = New recControl With {
                    .TopMost = True,
                    .ShowInTaskbar = False,
                    .ShowIcon = False
                }

            If Not noui Then
                border.Show()
                border.Size = New Point(size.X + 4, size.Y + 4)
                border.Location = New Point(location.X - 2, location.Y - 2)

                control.Show()
                control.Size = New Point(76, 27)
            End If

            If capScreen.Bounds.Height - (relativeLocation + size).Y < 60 Then
                control.Location = New Point(location.X - 2, location.Y - 2)
            Else
                control.Location = New Point(location.X + size.X - 74, location.Y + size.Y + 4)
            End If

            Try
                If File.Exists(filepath) Then File.Delete(filepath)
                rec = Recorder.CreateRecorder(opts)
                rec.Record(filepath)
                starttime = Now
                durationTimer.Start()
            Catch ex As Exception
                border.Dispose()
                MessageBox.Show("error")
            End Try
        End If
    End Sub

    Public Shared Sub stopRecording()
        rec.Stop()
        border.Dispose()
        control.Dispose()
        startup.lockMenu(False)
        Upload.post(filepath)
        durationTimer.Stop()
    End Sub

    Private Shared Sub durationTimer_Tick(sender As Object, e As EventArgs) Handles durationTimer.Tick
        If (Now - starttime).Seconds >= My.Settings.maxVideoDuration Then
            stopRecording()
        End If
    End Sub

    Public Shared Function FileAvailable(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing
        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
        Catch ex As Exception
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                Return False
            End If
        End Try
        Return True
    End Function

    Private Shared Function IsFileLocked(exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function

    Private Shared Sub MouseHook_MouseMove(sender As Object, e As InputHelper.EventArgs.MouseHookEventArgs)
        frmClickBlock.Location = New Point(e.Location.X - 8, e.Location.Y - 8)
        If Windows.Forms.Screen.FromPoint(MouseDownLocation).DeviceName =
                Windows.Forms.Screen.FromPoint(e.Location).DeviceName Or video = False Then
            If currentlySelecting Then
                If e.Location.X < MouseDownLocation.X And e.Location.Y < MouseDownLocation.Y Then
                    frmSelection.Location = e.Location
                    frmSelection.Size = MouseDownLocation - e.Location
                ElseIf e.Location.X > MouseDownLocation.X And e.Location.Y > MouseDownLocation.Y Then
                    frmSelection.Location = MouseDownLocation
                    frmSelection.Size = e.Location - MouseDownLocation
                ElseIf e.Location.X < MouseDownLocation.X And e.Location.Y > MouseDownLocation.Y Then
                    frmSelection.Location = New Point(e.Location.X, MouseDownLocation.Y)
                    frmSelection.Size = New Point(MouseDownLocation.X, e.Location.Y) - New Point(e.Location.X, MouseDownLocation.Y)
                ElseIf e.Location.X > MouseDownLocation.X And e.Location.Y < MouseDownLocation.Y Then
                    frmSelection.Location = New Point(MouseDownLocation.X, e.Location.Y)
                    frmSelection.Size = New Point(e.Location.X, MouseDownLocation.Y) - New Point(MouseDownLocation.X, e.Location.Y)
                End If
            End If
        End If
    End Sub

    Private Shared Sub MouseHook_MouseDown(sender As Object, e As InputHelper.EventArgs.MouseHookEventArgs)
        currentlySelecting = True
        MouseDownLocation = e.Location
    End Sub

    Private Shared Sub MouseHook_MouseUp(sender As Object, e As InputHelper.EventArgs.MouseHookEventArgs)
        currentlySelecting = False
        frmSelection.Hide()

        Dim location = frmSelection.Location
        Dim size = frmSelection.Size

        'cursorTimer.Stop()
        frmClickBlock.Dispose()
        frmSelection.Dispose()

        If size.Width > 4 And size.Height > 4 Then
            If video Then
                record(location, size)
            Else
                takeScreenshot(location, size)
                startup.lockMenu(False)
            End If
        Else
            startup.lockMenu(False)
        End If
        RemoveHandler MouseHook.MouseMove, AddressOf MouseHook_MouseMove
        RemoveHandler MouseHook.MouseDown, AddressOf MouseHook_MouseDown
        RemoveHandler MouseHook.MouseUp, AddressOf MouseHook_MouseUp
        MouseHook = Nothing
    End Sub
End Class
