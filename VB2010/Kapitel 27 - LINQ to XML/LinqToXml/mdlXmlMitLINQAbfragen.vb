Imports <xmlns:fuhrparkns="http://vb2008.activedevelop.de/fuhrpark">

Module XmlMitLINQAbfragen

    Sub Demo()

        ' XML Element festlegen
        Dim fuhrpark = <?xml version="1.0"?>
                       <fuhrparkns:fuhrpark>
                           <fuhrparkns:fahrzeug>
                               <fuhrparkns:kennzeichen>MS-VB 2008</fuhrparkns:kennzeichen>
                               <fuhrparkns:hersteller>MAN</fuhrparkns:hersteller>
                               <fuhrparkns:ladung menge="10000">Salz</fuhrparkns:ladung>
                           </fuhrparkns:fahrzeug>
                           <fahrzeug>
                               <fuhrparkns:kennzeichen>MS-C# 2008</fuhrparkns:kennzeichen>
                               <fuhrparkns:hersteller>Mercedes-Benz</fuhrparkns:hersteller>
                               <fuhrparkns:ladung menge="20000">Erdnüsse</fuhrparkns:ladung>
                           </fahrzeug>
                           <fahrzeug>
                               <fuhrparkns:kennzeichen>MS-J# 2008</fuhrparkns:kennzeichen>
                               <fuhrparkns:hersteller>DAF</fuhrparkns:hersteller>
                               <fuhrparkns:ladung menge="5000">Wackeldackel</fuhrparkns:ladung>
                           </fahrzeug>
                       </fuhrparkns:fuhrpark>

        ' Alle MAN-Fahrzeuge mit LINQ ermitteln
        ' d.h. Werte eines Elements überprüfen
        'Dim manFahrzeuge = From fahrzeug In fuhrpark...<fahrzeug> _
        '                   Where fahrzeug.<hersteller>.Value = "MAN"

        Dim manFahrzeuge = From fahrzeuge In fuhrpark.<fuhrparkns:fuhrpark> _
                           Where fahrzeuge.<fuhrparkns:hersteller>.Value = "Man"

        For Each fahrzeug In manFahrzeuge
            Console.WriteLine(fahrzeug)
        Next

        'Alle Fahrzeuge mit einer Ladung > 15000 ermitteln
        'd.h.Attributwerte(überprüfen)
        Dim schwerBeladen = From fahrzeug In fuhrpark.<fuhrparkns:fuhrpark> _
                            Where CDbl(fahrzeug.<fuhrparkns:fahrzeug>.<fuhrparkns:ladung>.@menge) > 15000

        Console.WriteLine("Schwer beladen")
        For Each fahrzeug In schwerBeladen
            Console.WriteLine(fahrzeug)
        Next
        Console.ReadKey()
    End Sub

End Module
