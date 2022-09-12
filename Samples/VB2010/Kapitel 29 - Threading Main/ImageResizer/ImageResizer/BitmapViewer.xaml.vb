Imports ActiveDevelop.Wpf.Imaging

Public Class BitmapViewer

    Private myWbm As WriteableBitmapManager

    Public Sub ShowPicture(ByVal wbm As WriteableBitmapManager, ByVal statusText As String)
        PreviewImage.Width = wbm.WriteableBitmap.Width
        PreviewImage.Height = wbm.WriteableBitmap.Height
        PreviewImage.Source = wbm.WriteableBitmap
        myWbm = wbm
        Me.Title = statusText
    End Sub

    Public Sub SavePicture(ByVal newfilename As String)
        If myWbm IsNot Nothing Then
            myWbm.SaveBitmap(newfilename)
        End If
    End Sub
End Class
