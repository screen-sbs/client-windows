Imports System.Environment
Imports System.IO
Imports System.Net

Public Class Paste
    Private Shared filepath = Path.GetTempPath + "screen_sbs_" + CaptureScreen.RandomString(12) + ".txt"

    Public Shared Sub uploadText(text As String)
        File.WriteAllText(filepath, text)
        Upload.post(filepath)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        uploadText(RichTextBox1.Text)
        RichTextBox1.Text = ""
        Me.Hide()
    End Sub
End Class