using System.Diagnostics;
using System;
using System.Xml.Linq;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;


namespace ErsteLinqDemo
{
	public class Artikel
	{
		
		private int myIDGekauftVon;
		private string myArtikelName;
		private string myArtikelNummer;
		private string myKategorie;
		private int myAnzahl;
		private decimal myEinzelpreis;
		
		#region Eigenschaften
		public int IDGekauftVon
		{
			get
			{
				return myIDGekauftVon;
			}
			set
			{
				myIDGekauftVon = value;
			}
		}
		
		public string ArtikelName
		{
			get
			{
				return myArtikelName;
			}
			set
			{
				myArtikelName = value;
			}
		}
		
		public string ArtikelNummer
		{
			get
			{
				return myArtikelNummer;
			}
			set
			{
				myArtikelNummer = value;
			}
		}
		
		public string Kategorie
		{
			get
			{
				return myKategorie;
			}
			set
			{
				myKategorie = value;
			}
		}
		
		public int Anzahl
		{
			get
			{
				return myAnzahl;
			}
			set
			{
				myAnzahl = value;
			}
		}
		
		public decimal Einzelpreis
		{
			get
			{
				return myEinzelpreis;
			}
			set
			{
				myEinzelpreis = value;
			}
		}
		#endregion
		
		public override string ToString()
		{
			return this.ArtikelNummer + ": " + this.ArtikelName;
		}
		
		public static List<Artikel> Zufallsartikel(List<Kontakt> Kontakte)
		{
			
			Random tmpRandom = new Random(DateTime.Now.Millisecond);
			List<Artikel> tmpArtikelliste = new List<Artikel>();
			
			string[] tmpArtikelstamm = {"DVD|Das Leben des Brian|1-234", "DVD|Abgefahren - Mit Vollgas in die Liebe|2-134", "DVD|Das Vermächstnis der Tempelritter|3-123", "DVD|Was diese Frau so alles treibt|9-646", "DVD|Mitten ins Herz|3-534", "DVD|Der Teufel trägt Prada|4-324", "DVD|Desperate Housewives - Staffel 2, Erster Teil|9-423", "DVD|O.C., California - Die komplette zweite Staffel (7 DVDs)|5-554", "DVD|24 - Season 6 [UK Import - Damn It!]|2-424", "Bücher, EDV|Visual Basic 2005 - Das Entwicklerbuch|3-537", "Bücher, EDV|Visual Basic 2008 - Das Entwicklerbuch|5-506", "Bücher, EDV|Visual Basic 2008 - Neue Technologien - Crashkurs|5-518", "Bücher, EDV|Microsoft Visual C# 2005 - Das Entwicklerbuch|3-543", "Bücher, EDV|Programmieren mit dem .NET Compact Framework|5-401", "Bücher, EDV|Microsoft SQL Server 2008 - Einführung in Konfiguration, Administration, Programmierung|5-513", "Hörbuch|Harry Potter und die Heiligtümer des Todes| 4-444", "Hörbuch|Die Rache der Zwerge|2-321", "Hörbuch|Die Wächter|9-009"
				, "Hörbuch|Das Herz der Hölle|7-321", "Bücher, Belletristik|Die Tore der Welt|9-445", "Bücher, Belletristik|Die Kathredale des Meeres|5-436", "Bücher, Belletristik|The Da Vinci Code|4-444", "Bücher, Belletristik|Der Schwarm|3-333", "Bücher, Belletristik|Tod und Teufel|6-666"};
			
			Artikel tmpArtikel;
			
			//Jeder hat was gekauft! :-)
			foreach (var adrItem in Kontakte)
			{
				//Jeder hat zwischen einem und 20 Artikel gekauft
				for (var anzahlGekaufterArtikel = 1; anzahlGekaufterArtikel <= tmpRandom.Next(1, 20); anzahlGekaufterArtikel++)
				{
					tmpArtikel = new Artikel();
					object[] tmpStr = tmpArtikelstamm[tmpRandom.Next(0, tmpArtikelstamm.Count - 1)].Split('|');
					tmpArtikel.IDGekauftVon = adrItem.ID;
					tmpArtikel.ArtikelName = tmpStr(1);
					tmpArtikel.ArtikelNummer = tmpStr(2);
					tmpArtikel.Anzahl = tmpRandom.Next(1, 4);
					tmpArtikel.Einzelpreis =  (@in) ((tmpRandom.Next(1, 20) * 5) - 0.05);
					tmpArtikel.Kategorie = tmpStr(0);
					tmpArtikelliste.Add(tmpArtikel);
				}
			}
			return tmpArtikelliste;
		}
		
		
	}
	
	public class Kontakt
	{
		
		
		//Membervariablen, die die Daten halten:
		private int myID;
		private string myName;
		private string myVorname;
		private string myStraße;
		private string myPLZ;
		private string myOrt;
		
		//Konstruktor - legt eine neue Instanz an
		public Kontakt(int ID, string Name, string Vorname, string Straße, string Plz, string Ort)
			{
			myID = ID;
			myName = Name;
			myVorname = Vorname;
			myStraße = Straße;
			myPLZ = Plz;
			myOrt = Ort;
		}
		
		//Mit Region ausgeblendet:
		//Die Eigenschaften der Klasse, um die Daten offen zu legen
		#region Eigenschaften
		public virtual int ID
		{
			get
			{
				return myID;
			}
			set
			{
				myID = value;
			}
		}
		
		public virtual string Nachname
		{
			get
			{
				return myName;
			}
			set
			{
				myName = value;
			}
		}
		
		public virtual string Vorname
		{
			get
			{
				return myVorname;
			}
			set
			{
				myVorname = value;
			}
		}
		
		public virtual string Straße
		{
			get
			{
				return myStraße;
			}
			set
			{
				myStraße = value;
			}
		}
		
		public virtual string PLZ
		{
			get
			{
				return myPLZ;
			}
			set
			{
				myPLZ = value;
			}
		}
		
		public virtual string Ort
		{
			get
			{
				return myOrt;
			}
			set
			{
				myOrt = value;
			}
		}
		#endregion
		
		public override string ToString()
		{
			return "\"" + Nachname + ", " + Vorname + "\"";
		}
		
		public static List<Kontakt> ZufallsKontakte(int Anzahl)
		{
			
			List<Kontakt> tmpAdressListe = new List<Kontakt>();
			Random tmpRandom = new Random(DateTime.Now.Millisecond);
			
			string[] tmpNachnamen = {"Heckhuis", "Löffelmann", "Thiemann", "Müller", "Wördehoff", "Lehnert", "Sonntag", "Ademmer", "Westermann", "Vüllers", "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", "Clarke", "Lehnert"};
			
			string[] tmpStraßen = {"Wiedenbrückerstr.", "Stauffenbergstr.", "Schloßallee", "Parkstr.", "Kurgartenweg", "Alter Postweg", "Lange Wende", "Marktplatz", "Gassenstr", "Straßengasse", "Postplatz", "Platzstr.", "Gassenplatz", "Himmelsbachweg", "Weidering", "Potterberg", "Am Wördehof", "Leingartenweg", "Lehnertweg"};
			
			string[] tmpVornamen = {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans", "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel", "Lothar", "Gareth", "Angela", "Denise", "Kerstin"};
			
			string[] tmpStädte = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld", "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing", "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"};
			
			for (int i = 1; i <= Anzahl; i++)
			{
				string tmpName;
				string tmpVorname;
				tmpName = tmpNachnamen[tmpRandom.Next(tmpNachnamen.Length - 1)];
				tmpVorname = tmpVornamen[tmpRandom.Next(tmpNachnamen.Length - 1)];
				tmpAdressListe.Add(new Kontakt(i, tmpName, tmpVorname, tmpStraßen[tmpRandom.Next(tmpStraßen.Length - 1)], tmpRandom.Next(99999).ToString("00000"), tmpStädte[tmpRandom.Next(tmpStädte.Length - 1)]));
			}
			return tmpAdressListe;
		}
		
		static public void KontakteAusgeben(List<Kontakt> Kontakte)
		{
			//Option Infer ist 'On', deswegen wird
			//Item automatisch zum Typ 'Adresse'
			foreach (var Item in Kontakte)
			{
				Console.WriteLine(Item);
			}
		}
		
	}
	
	public class AbDaten
	{
		
		string myA;
		string myB;
		
		public AbDaten(string a, string b)
		{
			myA = a;
			myB = b;
		}
		
		public string A
		{
			get
			{
				return myA;
			}
			set
			{
				myA = value;
			}
		}
		
		public string B
		{
			get
			{
				return myB;
			}
			set
			{
				myB = value;
			}
		}
	}
	
	public class CdDaten
	{
		
		string myC;
		string myD;
		
		public CdDaten(string c, string d)
		{
			myC = c;
			myD = d;
		}
		
		public string C
		{
			get
			{
				return myC;
			}
			set
			{
				myC = value;
			}
		}
		
		public string D
		{
			get
			{
				return myD;
			}
			set
			{
				myD = value;
			}
		}
	}
	
}
