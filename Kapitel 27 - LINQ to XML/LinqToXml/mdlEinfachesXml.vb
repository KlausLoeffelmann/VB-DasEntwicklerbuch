Module EinfachesXml

    Sub Demo()

        ''''
        '''' Beispiel der neuen XML Strukturen in VB 2008
        ''''
        Dim xml As New XDocument
        xml.Add(New XElement("fuhrpark", _
                    New XElement("kennzeichen", "MS - VB 2008"), _
                    New XElement("ladung", _
                                New XAttribute("menge", "10 Tonnen"), _
                                "Salz"), _
                    New XElement("hersteller", "MAN") _
        ))

        xml.Element("fuhrpark").Add(New XElement("baujahr", 1998))

        Console.WriteLine(xml)

        'Mit der Value-Eigenschaft Werte ermitteln
        'Gesamter "Wert":
        Console.WriteLine(xml.Element("fuhrpark").Value)

        'Nur das Baujahr:
        Console.WriteLine(xml.Element("fuhrpark").Element("baujahr").Value)
        Console.ReadKey()



        '' --------------------

        '''''
        ''''' Inline XML
        '''''

        Dim xElem As XElement = <fuhrpark>
                                    <kennzeichen>MS - VB 2008</kennzeichen>
                                    <ladung menge="10 Tonnen">Salz</ladung>
                                    <hersteller>MAN</hersteller>
                                </fuhrpark>
        'xElem.Add(New XElement("baujahr", 1998))
        'xElem.Add(<baujahr>1998</baujahr>)

        Dim myBaujahr As Integer = 1993
        xElem.Add(<baujahr><%= myBaujahr %></baujahr>)

        Dim xDoc As New XDocument(xElem)

        Console.WriteLine(xElem)
        Console.ReadKey()

    End Sub

End Module
