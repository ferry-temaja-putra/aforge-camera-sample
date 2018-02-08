Imports System.Drawing.Imaging

Public Class ImageStore

    Public Shared Sub SaveToJpeg(image As Bitmap, fileName As String)

        Dim codecInfo = GetEncoderInfo(ImageFormat.Jpeg)
        Dim encoder = Imaging.Encoder.Quality
        Dim encoderParams = New EncoderParameters(1)

        Dim encoderParam = New EncoderParameter(encoder, CType(100L, Int32))
        encoderParams.Param(0) = encoderParam
        image.Save(fileName, codecInfo, encoderParams)

    End Sub

    Private Shared Function GetEncoderInfo(ByVal format As ImageFormat) As ImageCodecInfo

        Dim j As Integer = 0
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()

        While j < encoders.Length
            If encoders(j).FormatID = format.Guid Then
                Return encoders(j)
            End If
            j += 1
        End While
        Return Nothing

    End Function

End Class
