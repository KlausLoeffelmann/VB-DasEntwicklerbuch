Imports <xmlns:fuhrparkns="http://vb2008.activedevelop.de/fuhrpark2>">

Module Main

    Sub Main()

        EinfachesXml.Demo()
        'LinqToXml.Demo()
        'XmlMitLINQAbfragen.Demo()
        Return

        Dim fuhrpark = <fuhrparkns:fuhrpark>
                           <fuhrparkns:fahrzeug>
                               <fuhrparkns:kennzeichen>MS-VB 2008</fuhrparkns:kennzeichen>
                               <fuhrparkns:hersteller>MAN</fuhrparkns:hersteller>
                               <fuhrparkns:ladung menge="10000">Salz</fuhrparkns:ladung>
                           </fuhrparkns:fahrzeug>
                           <fuhrparkns:fahrzeug>
                               <fuhrparkns:kennzeichen>MS-C# 2008</fuhrparkns:kennzeichen>
                               <fuhrparkns:hersteller>Mercedes-Benz</fuhrparkns:hersteller>
                               <fuhrparkns:ladung menge="20000">Erdnüsse</fuhrparkns:ladung>
                           </fuhrparkns:fahrzeug>
                           <fuhrparkns:fahrzeug>
                               <fuhrparkns:kennzeichen>MS-J# 2008</fuhrparkns:kennzeichen>
                               <fuhrparkns:hersteller>DAF</fuhrparkns:hersteller>
                               <fuhrparkns:ladung menge="5000">Wackeldackel</fuhrparkns:ladung>
                           </fuhrparkns:fahrzeug>
                       </fuhrparkns:fuhrpark>

        ' Alle MAN-Fahrzeuge mit LINQ ermitteln
        ' d.h. Werte eines Elements überprüfen
        Dim manFahrzeuge = From hersteller In fuhrpark...<fuhrparkns:hersteller> _
                            Where hersteller.Value = "MAN"
        For Each fahrzeug In manFahrzeuge
            Console.WriteLine(fahrzeug)
        Next

        Console.ReadKey()

    End Sub
End Module
