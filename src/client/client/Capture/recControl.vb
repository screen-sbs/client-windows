Public Class recControl
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CaptureScreen.stopRecording()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = (My.Settings.maxVideoDuration - (DateTime.Now - CaptureScreen.starttime).Seconds).ToString
    End Sub

    Private Sub recControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class