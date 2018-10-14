Class EreignisKlasse

    Event Ereignis(ByVal sender As Object, ByVal e As EreignisArgs)

    Sub EventAusl�sen(ByVal Nachricht As String)
        'L�st das Ereignis aus
        RaiseEvent Ereignis(Me, New EreignisArgs(Nachricht))
    End Sub

End Class

Class EreignisArgs
    Inherits EventArgs

    Private myNachricht As String

    Sub New(ByVal Nachricht As String)
        myNachricht = Nachricht
    End Sub

    Public ReadOnly Property Nachricht() As String
        Get
            Return myNachricht
        End Get
    End Property
End Class

Module mdlMain

    Dim WithEvents myWithEvents As New EreignisKlasse
    Dim myAddedHandler As New EreignisKlasse

    Sub Main()

        VerhaltenAddHandler()
        Console.WriteLine()
        VerhaltenWithEvents()
        Console.ReadLine()

    End Sub

    Sub VerhaltenAddHandler()

        Dim locReferenzAufAddedHandler As EreignisKlasse

        AddHandler myAddedHandler.Ereignis, AddressOf AddHandlerEreignisHandler
        locReferenzAufAddedHandler = myAddedHandler

        locReferenzAufAddedHandler.EventAusl�sen("ausgel�st durch locReferenzAufAddedHandler")
        myAddedHandler.EventAusl�sen("ausgel�st durch myAddedHandler")
        myAddedHandler = Nothing
        locReferenzAufAddedHandler.EventAusl�sen("ausgel�st durch locReferenzAufAddedHandler")

    End Sub

    Sub VerhaltenWithEvents()

        Dim locReferenzAufWithEvents As EreignisKlasse

        locReferenzAufWithEvents = myWithEvents

        locReferenzAufWithEvents.EventAusl�sen("ausgel�st durch locReferenzAufWithEvents")
        myWithEvents.EventAusl�sen("ausgel�st durch myWithEvents")
        myWithEvents = Nothing
        locReferenzAufWithEvents.EventAusl�sen("ausgel�st durch locReferenzAufWithEvents")

    End Sub

    Sub WithEventsEreignisHandler(ByVal sender As Object, ByVal e As EreignisArgs) _
                                                    Handles myWithEvents.Ereignis
        Console.WriteLine("WithEvents-Ereignis: " + e.Nachricht)
    End Sub

    Sub AddHandlerEreignisHandler(ByVal sender As Object, ByVal e As EreignisArgs)
        Console.WriteLine("AddHandler-Ereignis: " + e.Nachricht)
    End Sub


End Module


