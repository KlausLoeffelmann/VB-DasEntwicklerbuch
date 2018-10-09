Imports ActiveDevelop.Wpf.Imaging

Public Class BitmapViewer
    Public Sub ShowPicture(ByVal wbm As WriteableBitmapManager, ByVal statusText As String)
        PreviewImage.Width = wbm.WriteableBitmap.Width
        PreviewImage.Height = wbm.WriteableBitmap.Height
        PreviewImage.Source = wbm.WriteableBitmap
        Me.Title = statusText
    End Sub
End Class
