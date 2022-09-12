Public Class Form1

    Delegate Sub TestDelegate(ByVal Text As String)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click

        Dim locDel As TestDelegate

        If sender Is Button1 Then
            locDel = AddressOf BehandlungsroutineButton1
        Else
            locDel = AddressOf BehandlungsroutineButton2
        End If
        locDel.Invoke("Dies kam über einen Delegaten!")

    End Sub

    'Demonstriert das Multicast-Delegating, bei dem mehrere Aufrufe
    'durch *ein* Invoke erledigt werden. Jeder Delegate ist im Grunde genommen
    'eine Auflistung von Delegaten - kann also mehrere Prozedurenadressen speichern.
    'Ein Delegate muss zu diesem Zweck mit einem anderen kombiniert werden.
    'Durch das Kombinieren eines Delegaten mit einem anderen (oder bereits mehreren
    'kombinierten) werden dann mit *einem* Invoke *alle* Prozeduren nacheinander aufgerufen,
    'die in dem Delegaten (eigentlich: der Delegate-Auflistung) vorhanden sind.
    Private Sub Button1und2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1und2.Click
        Dim locDel As TestDelegate

        'Hier beinhaltet der Delegat erst die Adresse einer Prozedur.
        locDel = AddressOf BehandlungsroutineButton1
        'Ab hier beinhaltet der Delegat eine weitere Prozedurenadresse ...
        locDel = DirectCast(TestDelegate.Combine(locDel, New TestDelegate(AddressOf BehandlungsroutineButton2)), TestDelegate)
        '... und Invoke bewirkt, dass alle Adressen der Delegate-Auflistung
        'aufgerufen werden (in diesem Fall zwei).
        locDel.Invoke("Multicast delegating in action!")
    End Sub

    Private Sub BehandlungsroutineButton1(ByVal Text As String)
        MessageBox.Show("Behandlungsroutine für Button1 sagt: " & Text)
    End Sub

    Private Sub BehandlungsroutineButton2(ByVal Text As String)
        MessageBox.Show("Behandlungsroutine für Button2 sagt: " & Text)
    End Sub
End Class
