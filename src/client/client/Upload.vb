Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Net
Imports System.Environment
Imports Newtonsoft.Json

Public Class Upload
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

    Public Class serverConfig
        <JsonProperty("fileSizeLimit")>
        Public Property fileSizeLimit As Integer

        <JsonProperty("fileNameLength")>
        Public Property fileNameLength As Integer
    End Class

    Private Shared Sub doUpload(filePath As String, url As String)
        Do Until FileAvailable(New FileInfo(filePath))
            Thread.Sleep(100)
        Loop

        ' convert .jp(e)g and .bmp to .png
        If filePath.EndsWith(".jpg") Or filePath.EndsWith(".jpeg") Or filePath.EndsWith(".bmp") Then
            Dim newPath = Path.GetTempPath + "screen_sbs_" + CaptureScreen.RandomString(12) + ".png"
            Dim src = Image.FromFile(filePath)
            src.Save(newPath, Imaging.ImageFormat.Png)
            src.Dispose()
            filePath = newPath
        End If

        Dim resS
        Try
            Dim res
            Using wc As New WebClient
                Dim cfg = wc.DownloadString(My.Settings.serverUrl + "/config")
                Dim json = JsonConvert.DeserializeObject(Of serverConfig)(cfg)
                If New FileInfo(filePath).Length / 1024 / 1024 > json.fileSizeLimit Then
                    resS = "error_size"
                    Throw New WebException
                End If
                res = wc.UploadFile(My.Settings.serverUrl + "/upload/" + My.Settings.token, filePath)
            End Using

            resS = Text.Encoding.ASCII.GetString(res)

            If resS = "error" Then Throw New WebException
        Catch ex As WebException
            If resS = "error_size" Then
                MessageBox.Show("File size exceeds server limit.")
                resS = "error"
                Exit Try
            End If
            Try
                Dim statusCode = TryCast(ex.Response, HttpWebResponse).StatusCode
                If statusCode = 400 Then
                    MessageBox.Show("Uploaded file was empty. Check your paths or try running as admin")
                ElseIf statusCode = 401 Then
                    MessageBox.Show("Invalid upload token")
                ElseIf statusCode = 413 Then
                    MessageBox.Show("File size limit exceeded. If this was a video try reducing the duration")
                ElseIf statusCode = 500 Then
                    MessageBox.Show("Server error while handling upload")
                Else
                    MessageBox.Show("Error while uploading")
                End If
            Catch ex2 As Exception
                MessageBox.Show("Error while uploading")
                resS = "error"
            End Try
            resS = "error"
        End Try

        If Not resS = "error" Then
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

        If My.Settings.saveLocally Then
            Try
                Dim ext = filePath.Substring(filePath.Length - 4)
                File.Copy(filePath, My.Settings.localPath + "\" + Now.ToString("yyyy-MM-dd_HH-mm-ss") + ext)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Shared Function post(filePath As String)
        If filePath.EndsWith(".png") Or filePath.EndsWith(".mp4") Or
            filePath.EndsWith(".txt") Or filePath.EndsWith(".jpg") Or
            filePath.EndsWith(".jpeg") Or filePath.EndsWith(".bmp") Then

            Dim uploadThread As New Thread(Sub() doUpload(filePath, My.Settings.serverUrl + "/upload/"))
            uploadThread.SetApartmentState(ApartmentState.STA)
            uploadThread.Start()

            Return uploadThread
        Else
            MessageBox.Show("Only png, jp(e)g, bmp, mp4 and txt files are currently supported")
            Return Nothing
        End If
    End Function
End Class
