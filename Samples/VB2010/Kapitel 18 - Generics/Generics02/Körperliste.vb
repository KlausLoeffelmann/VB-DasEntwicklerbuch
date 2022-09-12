Class Körperliste
    Inherits DynamicList(Of KörperBasis)

    Public ReadOnly Property Gesamtvolumen() As Double
        Get
            Dim locVolumen As Double
            For Each locItem As KörperBasis In Me
                locVolumen += locItem.Volumen
            Next
            Return locVolumen
        End Get
    End Property
End Class

Class KörperlisteImmerNochGenerisch(Of flexiblerDatentyp As KörperBasis)
    Inherits DynamicList(Of flexiblerDatentyp)

    Public ReadOnly Property Gesamtvolumen() As Double
        Get
            Dim locVolumen As Double
            For Each locItem As KörperBasis In Me
                locVolumen += locItem.Volumen
            Next
            Return locVolumen
        End Get
    End Property
End Class
