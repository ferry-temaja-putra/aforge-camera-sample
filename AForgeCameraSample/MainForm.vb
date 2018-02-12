Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading
Imports AForge.Video.DirectShow
Imports AForge.Video.FFMPEG

Public Class MainForm

#Region " Private Variables "

    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private currentVideoDeviceIndex As Integer
    Private videoWriter As VideoFileWriter
    Private stopwatch As Stopwatch
    Private currentFrame As Image

    Private isStoppingRecording As Boolean
    Private isRecording As Boolean
    Private isCapturing As Boolean
    Private tempVideoKey As String
    Private videoWriterLock As Object

    Private Const imageExtension = ".jpg"
    Private Const videoExtension = ".avi"

#End Region

#Region " Constructors "

    Sub New()

        InitializeComponent()

        videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        videoWriter = New VideoFileWriter
        stopwatch = New Stopwatch

        If videoDevices.Count > 0 Then
            currentVideoDeviceIndex = 0
            ConfigureVideoSource()
        End If

        isCapturing = False
        isRecording = False
        isStoppingRecording = False
        videoWriterLock = New Object

    End Sub

#End Region

#Region " Private Methods "

    Private Sub ConfigureVideoSource()

        Dim isStartRequired = False

        If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
            ReleaseVideoSource()
            isStartRequired = True
        End If

        videoSource = New VideoCaptureDevice(videoDevices(currentVideoDeviceIndex).MonikerString)
        AddHandler videoSource.NewFrame, AddressOf videoSource_NewFrame

        PopulateResolutionControl()
        SetVideoResolution(videoSource.VideoCapabilities.First)

        If isStartRequired Then
            videoSource.Start()
        End If
    End Sub

    Private Sub ReleaseVideoSource()
        videoSource.SignalToStop()
        videoSource.WaitForStop()
        RemoveHandler videoSource.NewFrame, AddressOf videoSource_NewFrame
    End Sub

    Private Sub PopulateResolutionControl()

        resolutionCbo.Items.Clear()

        For Each capability In videoSource.VideoCapabilities
            resolutionCbo.Items.Add(String.Format("{0} x {1} - {2} FPS", capability.FrameSize.Width, capability.FrameSize.Height, capability.AverageFrameRate))
        Next

        resolutionCbo.SelectedIndex = 0

    End Sub

    Private Sub SetVideoResolution(capability As VideoCapabilities)

        Dim isStartRequired = False

        If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
            videoSource.SignalToStop()
            videoSource.WaitForStop()
            isStartRequired = True
        End If

        videoSource.VideoResolution = capability

        If isStartRequired Then
            videoSource.Start()
        End If

    End Sub

    Private Sub StartRecording()
        tempVideoKey = Guid.NewGuid.ToString
        videoWriter.Open(Path.Combine(Path.GetTempPath, tempVideoKey & videoExtension),
                         videoSource.VideoResolution.FrameSize.Width,
                         videoSource.VideoResolution.FrameSize.Height,
                         videoSource.VideoResolution.AverageFrameRate,
                         VideoCodec.MPEG4)
    End Sub

    Private Sub StopRecording(image As Bitmap)
        videoWriter.Close()

        Dim listViewItem As New ListViewItem
        With listViewItem
            .Name = tempVideoKey
            .Text = tempVideoKey
            .ImageKey = tempVideoKey
            .Tag = videoExtension
        End With

        Me.BeginInvoke(Sub()
                           captureIml.Images.Add(tempVideoKey, image)
                           captureLsv.Items.Add(listViewItem)
                       End Sub)

    End Sub

    Private Sub WriteVideo(image As Object)
        SyncLock videoWriterLock
            videoWriter.WriteVideoFrame(DirectCast(image, Bitmap))
        End SyncLock
    End Sub

    Private Sub CaptureImage(image As Bitmap)

        Dim imageKey = Guid.NewGuid().ToString

        SaveToJpeg(image, Path.Combine(Path.GetTempPath, imageKey & imageExtension))

        Dim listViewItem As New ListViewItem
        With listViewItem
            .Name = imageKey
            .Text = imageKey
            .ImageKey = imageKey
            .Tag = imageExtension
        End With

        BeginInvoke(Sub()
                        captureIml.Images.Add(imageKey, image)
                        captureLsv.Items.Add(listViewItem)
                    End Sub)
    End Sub

    Private Sub DisplayElapsedLabel()
        recordingLbl.Text = String.Format("Recording...[{0:00}:{1:00}:{2:00}]",
                                          stopwatch.Elapsed.Hours,
                                          stopwatch.Elapsed.Minutes,
                                          stopwatch.Elapsed.Seconds)
    End Sub

    Private Function GetFileName(listViewItem As ListViewItem) As String
        Dim fileName = String.Format("{0}{1}", listViewItem.ImageKey, listViewItem.Tag)
        Return Path.Combine(Path.GetTempPath, fileName)
    End Function

    Private Shared Sub SaveToJpeg(image As Bitmap, fileName As String)

        Dim codecInfo As ImageCodecInfo = ImageCodecInfo.GetImageEncoders.
            FirstOrDefault(Function(x) x.FormatID = ImageFormat.Jpeg.Guid)

        Dim encoderParams = New EncoderParameters(1)
        encoderParams.Param(0) = New EncoderParameter(Encoder.Quality, 100L)

        image.Save(fileName, codecInfo, encoderParams)

    End Sub

#End Region

#Region " Controls Event Handlers "

    Private Sub videoSource_NewFrame(sender As Object, eventArgs As AForge.Video.NewFrameEventArgs)
        Dim frame = New Bitmap(eventArgs.Frame)

        If isCapturing Then
            isCapturing = False
            CaptureImage(New Bitmap(frame))
        End If

        If isRecording Then
            ThreadPool.QueueUserWorkItem(AddressOf WriteVideo, New Bitmap(frame))
        End If

        If isStoppingRecording Then
            isStoppingRecording = False
            StopRecording(New Bitmap(frame))
        End If

        If currentFrame IsNot Nothing Then
            currentFrame.Dispose()
        End If

        currentFrame = frame
        videoPic.Invalidate()
    End Sub

    Private Sub captureBtn_Click(sender As System.Object, e As System.EventArgs) Handles captureBtn.Click
        isCapturing = True
    End Sub

    Private Sub recordBtn_Click(sender As System.Object, e As System.EventArgs) Handles recordBtn.Click

        If isRecording Then
            isRecording = False
            isStoppingRecording = True
            stopwatch.Stop()
            elapsedTmr.Stop()
            recordingLbl.Hide()
            recordBtn.Text = "Record"
        Else
            isRecording = True
            stopwatch.Reset()
            stopwatch.Start()
            elapsedTmr.Start()
            recordingLbl.Show()
            DisplayElapsedLabel()
            recordBtn.Text = "Stop"
            StartRecording()
        End If

    End Sub

    Private Sub resolutionCbo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles resolutionCbo.SelectedIndexChanged
        SetVideoResolution(videoSource.VideoCapabilities(resolutionCbo.SelectedIndex))
    End Sub

    Private Sub nextCameraBtn_Click(sender As System.Object, e As System.EventArgs) Handles nextCameraBtn.Click

        If isRecording Then
            MessageBox.Show("Please stop the recording before switching the camera!", "Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        currentVideoDeviceIndex += 1

        If currentVideoDeviceIndex > videoDevices.Count - 1 Then
            currentVideoDeviceIndex = 0
        End If

        ConfigureVideoSource()
    End Sub

    Private Sub captureLsv_DoubleClick(sender As System.Object, e As System.EventArgs) Handles captureLsv.DoubleClick

        If captureLsv.SelectedItems.Count = 0 Then Return

        Dim fileName = GetFileName(captureLsv.SelectedItems(0))

        Process.Start(fileName)

    End Sub

    Private Sub elapsedTmr_Tick(sender As System.Object, e As System.EventArgs) Handles elapsedTmr.Tick
        DisplayElapsedLabel()
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RemoveToolStripMenuItem.Click

        If captureLsv.SelectedItems.Count = 0 Then Return

        Dim imageKey = captureLsv.SelectedItems(0).ImageKey

        captureLsv.Items.RemoveByKey(imageKey)
        captureIml.Images.RemoveByKey(imageKey)

    End Sub

    Private Sub CopyPathToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyPathToolStripMenuItem.Click
        If captureLsv.SelectedItems.Count = 0 Then Return

        Dim fileName = GetFileName(captureLsv.SelectedItems(0))

        Clipboard.SetText(fileName)

        MessageBox.Show("File Name is copied to the clipboard", "File Name Copied", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        videoSource.Start()
    End Sub

    Private Sub MainForm_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If isRecording Then
            isStoppingRecording = True
        End If

        If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
            ReleaseVideoSource()
        End If

    End Sub

    Private Sub videoPic_Paint(sender As Object, e As PaintEventArgs) Handles videoPic.Paint

        If currentFrame Is Nothing Then Return

        Dim frameWidth = videoPic.Height * currentFrame.Width \ currentFrame.Height

        e.Graphics.DrawImage(currentFrame, 0, 0, frameWidth, videoPic.Height)

    End Sub

#End Region

End Class
