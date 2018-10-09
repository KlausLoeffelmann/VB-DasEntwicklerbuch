Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Imports System.Windows
Imports System.Windows.Media.Imaging
Imports System.Runtime.InteropServices
Imports System.IO

Public Class WriteableBitmapManager

    Private myWriteableBitmap As WriteableBitmap
    Private myBitmapBits As Byte()
    Private myBitmapRect As Int32Rect
    Private myBitmapStride As Integer
    Private myGdiImage As Bitmap
    Private myColorGetter As Func(Of Byte(), Integer, Integer, Color)
    Private myColorSetter As Action(Of Byte(), Integer, Integer, Color)

    Sub New(ByVal fileName As String)
        'Erst 'mal ne GDI+-Bitmap erstellen
        myGdiImage = New Bitmap(fileName)

        'Ausmaße ermitteln
        myBitmapRect = New Int32Rect(0, 0, myGdiImage.Width, myGdiImage.Height)

        InitializeWpfBitmaps()
    End Sub

    Private Sub New(ByVal width As Integer, ByVal height As Integer, ByVal template As WriteableBitmapManager)

        'Neues GDI-Bild anlegen
        myGdiImage = New Bitmap(width, height, GetGdiPixelFormatFromWpfPixelFormat(template.myWriteableBitmap.Format))

        'Ausmaße "ermitteln"
        myBitmapRect = New Int32Rect(0, 0, width, height)

        InitializeWpfBitmaps()
    End Sub

    Private Sub InitializeWpfBitmaps()
        'Die Pixelbytes ermitteln
        GetBytesFromGdiBitmap()

        'Daraus eine neue WritableBitmap machen, und so werden wir WPF kompatibel:
        myWriteableBitmap = New WriteableBitmap(myGdiImage.Width, myGdiImage.Height,
                                                myGdiImage.HorizontalResolution, myGdiImage.VerticalResolution,
                                                GetWpfPixelFormatFromGdiPixelFormat(myGdiImage.PixelFormat), Nothing)
        myWriteableBitmap.WritePixels(myBitmapRect, myBitmapBits, myBitmapStride, 0)

        If myGdiImage.PixelFormat = PixelFormat.Format24bppRgb Then
            myColorGetter = Function(bitmapbits As Byte(), x As Integer, y As Integer) As Color
                                Dim pointer = y * myBitmapStride + x * 3
                                Dim tempi As Integer = (CInt(bitmapbits(pointer)) << 16) Or
                                                      (CInt(bitmapbits(pointer + 1)) << 8) Or
                                                      bitmapbits(pointer + 2)
                                Return Color.FromArgb(tempi)
                            End Function

            myColorSetter = Sub(bitmapbits As Byte(), x As Integer, y As Integer, c As Color)
                                Dim pointer = y * myBitmapStride + x * 3
                                bitmapbits(pointer) = c.R
                                bitmapbits(pointer + 1) = c.G
                                bitmapbits(pointer + 2) = c.B
                            End Sub
        End If
    End Sub

    Public Function CreateCompatible(ByVal width As Integer) As WriteableBitmapManager
        Return New WriteableBitmapManager(width,
                                          width / Me.WriteableBitmap.PixelWidth * Me.WriteableBitmap.PixelHeight, Me)
    End Function

    Public Function CreateCompatible(ByVal Width As Integer, ByVal height As Integer) As WriteableBitmapManager
        Return New WriteableBitmapManager(Width, height, Me)
    End Function

    Private Sub GetBytesFromGdiBitmap()

        'Ausmaße des Rechtecks.
        Dim rect As New Rectangle(0, 0, myGdiImage.Width, myGdiImage.Height)

        ' Bits der Bitmap für den Moment schützen (locken), damit kein 
        ' anderer Prozess darauf zugreifen kann, während wir 
        ' die Daten der Bitmap in ein Byte-Array kopieren
        Dim bmpData As System.Drawing.Imaging.BitmapData = myGdiImage.LockBits(rect, _
            System.Drawing.Imaging.ImageLockMode.ReadWrite, myGdiImage.PixelFormat)

        ' Adresse der ersten Zeile ermitteln
        Dim pointerToBitmapdata As IntPtr = bmpData.Scan0

        ' Stride (Pixelschrittzahl - Bytes pro Pixel) ermitteln.
        myBitmapStride = bmpData.Stride

        'Byte-Array deklarieren und definieren, dass die Bitmap-Daten hält.
        Dim byteCount As Integer = bmpData.Stride * myGdiImage.Height
        myBitmapBits = New Byte(byteCount - 1) {}

        ' Die Farbwerte der Pixel in das Array kopieren.
        System.Runtime.InteropServices.Marshal.Copy(pointerToBitmapdata, myBitmapBits, 0, byteCount)

        ' Bits der Bitmap wieder freigeben.
        myGdiImage.UnlockBits(bmpData)
    End Sub

    Private Sub SetBytesInGdiBitmap()

        'Ausmaße des Rechtecks.
        Dim rect As New Rectangle(0, 0, myGdiImage.Width, myGdiImage.Height)

        ' Bits der Bitmap für den Moment schützen (locken), damit kein 
        ' anderer Prozess darauf zugreifen kann, während wir 
        ' die Daten der Bitmap in ein Byte-Array kopieren
        Dim bmpData As System.Drawing.Imaging.BitmapData = myGdiImage.LockBits(rect, _
                System.Drawing.Imaging.ImageLockMode.ReadWrite, myGdiImage.PixelFormat)

        ' Adresse der ersten Zeile ermitteln
        Dim pointerToBitmapdata As IntPtr = bmpData.Scan0

        ' Stride (Pixelschrittzahl - Bytes pro Pixel) ermitteln.
        myBitmapStride = bmpData.Stride

        Dim byteCount As Integer = bmpData.Stride * myGdiImage.Height

        ' Die Farbwerte der Pixel aus dem Byte-Array in die Grafik übertragen
        System.Runtime.InteropServices.Marshal.Copy(myBitmapBits, 0, pointerToBitmapdata, byteCount)

        ' Bits der Bitmap wieder freigeben.
        myGdiImage.UnlockBits(bmpData)

    End Sub

    'Aus dem GDI+ Pixelformat das WPF-Pixelformat machen.
    '(Wir beschränken uns hier auf die beiden häufigsten)
    Private Function GetWpfPixelFormatFromGdiPixelFormat(ByVal PixelFormat As System.Drawing.Imaging.PixelFormat) As System.Windows.Media.PixelFormat
        Select Case PixelFormat

            Case System.Drawing.Imaging.PixelFormat.Format32bppArgb
                Return System.Windows.Media.PixelFormats.Bgra32

            Case System.Drawing.Imaging.PixelFormat.Format24bppRgb
                Return System.Windows.Media.PixelFormats.Bgr24

            Case Else
                Throw New NotSupportedException("Dieses Pixelformat wird z.Z. nicht unterstützt.")

        End Select
    End Function

    'Aus dem WPF-Pixelformat das GDI+-Pixelformat machen.
    '(Wir beschränken uns hier auf die beiden häufigsten)
    Private Function GetGdiPixelFormatFromWpfPixelFormat(ByVal PixelFormat As System.Windows.Media.PixelFormat) As System.Drawing.Imaging.PixelFormat

        Select Case PixelFormat
            Case System.Windows.Media.PixelFormats.Bgra32
                Return System.Drawing.Imaging.PixelFormat.Format32bppArgb

            Case System.Windows.Media.PixelFormats.Bgr24
                Return System.Drawing.Imaging.PixelFormat.Format24bppRgb

            Case Else
                Throw New NotSupportedException("Dieses Pixelformat wird z.Z. nicht unterstützt.")
        End Select
    End Function

    Public Sub UpdateBitmap()
        myWriteableBitmap.WritePixels(myBitmapRect, myBitmapBits, myBitmapStride, 0)
    End Sub

    Public Function GetPixel(ByVal x As Integer, ByVal y As Integer) As Color
        Return myColorGetter(myBitmapBits, x, y)
    End Function

    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal c As Color)
        myColorSetter(myBitmapBits, x, y, c)
        Dim g As Double

    End Sub

    Public Sub SaveBitmap(ByVal filename As String)
        SetBytesInGdiBitmap()

        'Falls der Ordner noch nicht existiert, versuchen ihn anzulegen
        Dim fi = New FileInfo(filename)
        If Not fi.Directory.Exists Then
            fi.Directory.Create()
        End If
        myGdiImage.Save(filename)
    End Sub

    Public Property WriteableBitmap As WriteableBitmap
        Get
            Return myWriteableBitmap
        End Get
        Set(ByVal value As WriteableBitmap)
            myWriteableBitmap = value
        End Set
    End Property
End Class
