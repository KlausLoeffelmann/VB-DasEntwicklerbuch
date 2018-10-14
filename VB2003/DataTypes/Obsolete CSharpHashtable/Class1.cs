using System;
using System.Collections;

namespace CSharpHashtable
{
	/// <summary>
	/// Zusammenfassung für Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Create 100 random Elementes
			int[] array=new int[100];
			Random ran=new Random();

			for (int i=0; i<100; i++)
				array[i]=ran.Next();

			// Calling function FindMax, passing it the array and retrieving the Maximum
			int max=FindMax(array);

			// Printin out the Maximum
			Console.WriteLine(max);

			// Wait for Return
			Console.ReadLine();

		}

		static int FindMax(int[] theArrayToSearch)
		{
			// Functions considers only to have elements of type int!
			int tempValue;

			// Start with an initial value, so the first comparation can be made
			tempValue=theArrayToSearch[0];

			for (int i=0; i<theArrayToSearch.Length; i++)
				// current element > tempvalue?
				if (tempValue<theArrayToSearch[i])
					// yes, tempValue becomes current Element
					tempValue=theArrayToSearch[i];

			// Done! tempValue contains highest value.
			return tempValue;
		}

	}
}
