'Wichtig: Das Extension-Attribut ist in diesem Namespace versteckt
Imports System.Runtime.CompilerServices

'Wichtig: Der Namespace mit der Erweiterungsmethode für einen Typ muss importiert werden!
Imports ErweiterungsmethodenDemo.MeineErweiterungsmethode

Module Hauptmodul

    Sub Main()

        Dim t = "Dies ist die erste Zeile!\nUnd dieses hier die zweite."
        Console.WriteLine(t.Formatted)

        'Auf Taste warten.
        Console.ReadKey()
    End Sub

End Module

Namespace MeineErweiterungsmethode

    Module ErweiterungsmethodenModul

        'Das Extension-Attribut kennzeichnet eine Methode
        'als Erweiterungsmethode. Der Typ des ersten Parameters
        'bestimmt den Typ, der erweitert werden soll.
        <Extension()> _
        Public Function Formatted(ByVal text As String) As String
            'Aus \n ein CR+LF machen.
            Return text.Replace("\n", vbNewLine)
        End Function

    End Module
End Namespace


