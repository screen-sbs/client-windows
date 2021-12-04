Imports System.Environment
Imports System.IO
Imports System.Net

Public Class Paste
    Private Shared filepath = Path.GetTempPath + "screen_sbs_" + CaptureScreen.RandomString(12) + ".txt"

    Public Shared Sub upload(text As String)
        File.WriteAllText(filepath, text)

        If My.Settings.saveLocally Then
            Try
                Dim ext = filepath.Substring(filepath.Length - 4)
                File.Copy(filepath, My.Settings.localPath + "\" + Now.ToString("yyyy-MM-dd_HH-mm-ss") + ext)
            Catch ex As Exception
            End Try
        End If

        Dim resS
        Try
            Dim res
            Using wc As New WebClient
                res = wc.UploadFile("https://upload.screen.sbs/?token=" + My.Settings.token, filepath)
            End Using

            resS = System.Text.Encoding.ASCII.GetString(res)
        Catch ex As Exception
            resS = "error"
        End Try

        If resS = "error" Then
            MessageBox.Show("error")
        Else
            If My.Settings.copyLink Then Clipboard.SetText(resS)
            If My.Settings.playBeep Then Console.Beep()
            If My.Settings.openInBrowser Then Process.Start(resS)
            If My.Settings.maxLinks >= 1 Then
                Dim newLinks As String = resS + vbCrLf
                If File.Exists(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt") Then
                    Dim links As String() = File.ReadAllLines(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt")
                    Dim i As Integer = 1

                    For Each l As String In links
                        If l.StartsWith("https") Then
                            i += 1
                            If Not i > My.Settings.maxLinks - 1 Then
                                newLinks += l + vbCrLf
                            ElseIf i = My.Settings.maxLinks Then
                                newLinks += l
                            End If
                        End If
                    Next
                End If

                If Not Directory.Exists(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\") Then
                    Try
                        Directory.CreateDirectory(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\")
                    Catch ex As Exception
                    End Try
                End If
                Try
                    File.WriteAllText(GetFolderPath(SpecialFolder.ApplicationData) + "\screen.sbs\links.txt", newLinks)
                Catch ex As Exception
                End Try

                LinkList.updateLinks()
            End If
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        upload(RichTextBox1.Text)
        RichTextBox1.Text = ""
        Me.Hide()
    End Sub

End Class