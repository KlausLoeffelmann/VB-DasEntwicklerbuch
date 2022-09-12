Imports System.Collections.ObjectModel

Public Structure PolarCoordinate
    Private myLength_X As Single
    Private myLength_Y As Single
    Private myAngle As Single
    Private myOffset As PointF
    Private myCartesian As PointF
    Private myOriginalOffset As PointF
    Private myOriginalAngle As Single

    Sub New(ByVal Offset As PointF, ByVal Length As Single, ByVal Angle As Single)
        myLength_X = Length
        myLength_Y = Length
        myAngle = Angle
        myOriginalAngle = Angle
        myOffset = Offset
        myOriginalOffset = Offset
        recalculate()
    End Sub

    Sub New(ByVal Offset As PointF, ByVal Length_X As Single, ByVal Length_Y As Single, ByVal Angle As Single)
        myLength_X = Length_X
        myLength_Y = Length_Y
        myAngle = Angle
        myOriginalAngle = Angle
        myOffset = Offset
        myOriginalOffset = Offset
        recalculate()
    End Sub

    ''' <summary>
    ''' Liefert die Polarkoordinate als Kartesische Koordinate zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Cartesian() As PointF
        Get
            Return myCartesian
        End Get
    End Property

    ''' <summary>
    ''' Die X-Radiuslänge
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Length_X() As Single
        Get
            Return myLength_X
        End Get
        Set(ByVal value As Single)
            myLength_X = value
            recalculate()
        End Set
    End Property

    ''' <summary>
    ''' Die Y-Radiuslänge (gleich X-Radius bei einem Kreis)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Length_Y() As Single
        Get
            Return myLength_Y
        End Get
        Set(ByVal value As Single)
            myLength_Y = value
            recalculate()
        End Set
    End Property

    ''' <summary>
    ''' Der Winkel
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Angle() As Single
        Get
            Return myAngle
        End Get
        Set(ByVal value As Single)
            myAngle = value
            recalculate()
        End Set
    End Property

    ''' <summary>
    ''' Offset, um den die Koordinate bei Umrechnung in das kartesische System 
    ''' nach rechts und unten verschoben wird.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Offset() As PointF
        Get
            Return myOffset
        End Get
        Set(ByVal value As PointF)
            myOffset = value
            recalculate()
        End Set
    End Property

    Friend ReadOnly Property OriginalAngle() As Single
        Get
            Return myOriginalAngle
        End Get
    End Property

    ''' <summary>
    ''' Interne Routine zum Neuberechnen der kartesischen Koordinaten nach Veränderung einer Eigenschaft
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub recalculate()
        myCartesian.X = CSng(Offset.X + Math.Cos(Angle * Math.PI / 180) * Length_X)
        myCartesian.Y = CSng(Offset.Y + Math.Sin(Angle * Math.PI / 180) * Length_Y)
    End Sub
End Structure

Public Class PolarCoordinates
    Inherits Collection(Of PolarCoordinate)

    Public Sub AddAngle(ByVal AngleToAdd As Single)
        For Each locItem As PolarCoordinate In Me
            locItem.Angle += AngleToAdd
        Next
    End Sub

    Public Sub ResetAngle()
        For Each locItem As PolarCoordinate In Me
            locItem.Angle = locItem.OriginalAngle
        Next
    End Sub
End Class