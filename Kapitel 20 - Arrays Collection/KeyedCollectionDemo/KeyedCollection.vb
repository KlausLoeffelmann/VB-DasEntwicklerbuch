Imports System.Collections.ObjectModel

Module KeyedCollection

    Sub Main()
        'Ersteinmal eine normale Arraylist definieren,
        'die aus 100 Zufallsadressen besteht.
        Dim locArrayList As ArrayList = Adresse.ZufallsAdressen(100)

        'Das ist die "selbst gestrickte" KeyedCollection
        Dim locKeyedAdressen As New Adressen

        'Mit den Elementen der Arraylist f�llen wir die KeyedCollection
        For Each locAdressItem As Adresse In locArrayList
            locKeyedAdressen.Add(locAdressItem)
        Next

        'Abrufen der Elemente aus der KeyedCollection:
        'Variation Nr.1 - abrufen �ber den Index
        For c As Integer = 0 To 10
            Console.WriteLine(locKeyedAdressen(c).ToString)
        Next

        'Leerzeile - der besseren �bersicht wegen:
        Console.WriteLine()

        'Irgendeine herauspicken, um an den Matchcode zu kommen:
        Dim locMatchcode As String = locKeyedAdressen(10).Matchcode

        'Variation Nr. 2: Eine Adresse kann auch �ber den Key 
        '(in diesem Fall �ber den Matchcode) abgerufen werden.
        Dim locAdresse As Adresse = locKeyedAdressen(locMatchcode)
        Console.WriteLine("Die Adresse mit dem Matchcode " & locMatchcode & " lautet:")
        Console.WriteLine(locAdresse.ToString)
        Console.WriteLine()
        Console.WriteLine("Taste dr�cken zum Beenden!")
        Console.ReadKey()
    End Sub
End Module

''' <summary>
''' Verwaltet Objekte vom Typ Adresse als W�rterbuch-Auflistung. 
''' Abgeleitet von der abstrakten Basisklasse KeyedCollection.
''' </summary>
''' <remarks></remarks>
Public Class Adressen
    Inherits KeyedCollection(Of String, Adresse)

    'Diese Methode muss �berschrieben werden, um zu garantieren, 
    'dass f�r jedes Element ein Schl�ssel existiert.
    Protected Overrides Function GetKeyForItem(ByVal item As Adresse) As String
        'Hier wird bestimmt, dass der eindeutige Key der Matchcode ist.
        Return item.Matchcode
    End Function
End Class
