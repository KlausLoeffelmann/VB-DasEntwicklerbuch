'Dies ist die alte Version, die wir im Folgenden 
'durch ihre "Property-Version" ersetzen werden:
'
'Public Class Kontakt
'    Public Vorname As String
'    Public Nachname As String
'    Public PLZ As String
'    Public Ort As String
'End Class

Public Class Kontakt

    Private myVorname As String
    Private myNachname As String
    Private myPLZ As String
    Private myOrt As String

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal value As String)
            myVorname = value
        End Set
    End Property

    Public Property Nachname() As String
        Get
            Return myNachname
        End Get
        Set(ByVal value As String)
            myNachname = value
        End Set
    End Property

    Public Property PLZ() As String
        Get
            Return myPLZ
        End Get
        Set(ByVal value As String)
            myPLZ = value
        End Set
    End Property

    Public Property Ort() As String
        Get
            Return myOrt
        End Get
        Set(ByVal value As String)
            myOrt = EllipseString(value, 30)
        End Set
    End Property

    Public Function KontaktText() As String

        Return Me.Nachname & ", " & Me.Vorname & ", " & _
                Me.PLZ & ", " & Me.Ort

    End Function

    Private Function EllipseString(ByVal text As String, ByVal MaxLength As Integer) As String

        Dim tmpText As String

        If text.Length > MaxLength Then
            tmpText = text.Substring(0, MaxLength - 3) + "..."
        Else
            tmpText = text
        End If
        Return tmpText
    End Function

End Class