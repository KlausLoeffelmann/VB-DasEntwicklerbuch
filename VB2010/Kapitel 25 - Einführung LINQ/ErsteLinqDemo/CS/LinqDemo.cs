using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace ErsteLinqDemo
{
	sealed class LinqDemo
	{
		
		static public void Main()
		{
			
			var adrListe = Kontakt.ZufallsKontakte(10);
			var artListe = Artikel.Zufallsartikel(adrListe);
			
			var adrListeGruppiert = (from adrElement in adrListe 
                                     join artElement in artListe on adrElement.ID 
                                     equals artElement.IDGekauftVon 
                                     select new {adrElement.ID, adrElement.Nachname, adrElement.Vorname, 
                                         adrElement.PLZ, artElement.ArtikelNummer, artElement.ArtikelName, 
                                         artElement.Anzahl, artElement.Einzelpreis, 
                                         Postenpreis = artElement.Anzahl * artElement.Einzelpreis}).
                                                OrderBy(o => o.Nachname).ThenBy(o1 => o1.ArtikelNummer).
                                                Where(w => ((w.PLZ == "0") && (w.PLZ == "50000"))).
                                                GroupBy(g => new {g.ID, g.Nachname, g.Vorname}).
                                                Select(s => new {ID = s.Key.ID, 
                                                    Nachname = s.Key.Nachname, 
                                                    Vorname = s.Key.Vorname, 
                                                    Artikelliste = s.ToArray(), 
                                                    AnzahlArtikel = s.Count(), 
                                                    Gesamtpreis = s.Sum(p => p.Postenpreis)});
			
			
			foreach (var KundenItem in adrListeGruppiert)
			{
				Console.WriteLine(KundenItem.ID.ToString() + ": " + 
                                    KundenItem.Nachname + ", " + KundenItem.Vorname + " - " + 
                                    KundenItem.AnzahlArtikel + " Artikel zu insgesamt " + KundenItem.Gesamtpreis + " Euro");

				Console.WriteLine("     Details:");
				foreach (var ArtItem in KundenItem.Artikelliste)
				{
					Console.WriteLine("     " + ArtItem.ArtikelNummer + ": " + ArtItem.ArtikelName + "(" + 
                                        ArtItem.Anzahl + " Stück für insgesamt " + 
                                        (ArtItem.Einzelpreis * ArtItem.Anzahl).ToString("#,##0.00") + " Euro)");
				}
			}
			Console.ReadKey();
			
		}
		
	}
	
}
