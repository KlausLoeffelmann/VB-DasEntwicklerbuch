using System;

namespace CSElements
{
	/// <summary>
	/// Zusammenfassung für Class1.
	/// </summary>
	public class CSIntElements
	{
		private	int[] myIntElements;

		public CSIntElements(int AmountOfElements)
		{
			myIntElements = new int[AmountOfElements];
			Random locRandom = new Random(DateTime.Now.Millisecond);

			for (int locCount=0; locCount<AmountOfElements; locCount++)
				myIntElements[locCount]= locRandom.Next();
		}

		public void ShellSort()
		{
			int locOutCount, locInCount;
			int locDelta;
			int locIntTemp;

			locDelta = 1;

			// Größten Wert der Distanzfolge ermitteln
			do 
				locDelta = 3 * locDelta + 1;
			while (locDelta <= myIntElements.Length);

			do
			{
				//War einen zu groß, also wieder teilen
				locDelta /= 3;

				//Shellsort's Kernalgorithmus
				for (locOutCount = locDelta; locOutCount<myIntElements.Length;locOutCount++)
				{
					locIntTemp = myIntElements[locOutCount];
					locInCount = locOutCount;
					while (myIntElements[locInCount - locDelta] < locIntTemp)
					{
						myIntElements[locInCount] = myIntElements[locInCount - locDelta];
						locInCount = locInCount - locDelta;
						if (locInCount <= locDelta) break;
					}
			
					myIntElements[locInCount] = locIntTemp;
				}
			}
			while (locDelta != 0);
		}
	}

	public class CSStrElements
	{
		const int cChars=10;
		private	string[] myStrElements;

		public CSStrElements(int AmountOfElements)
		{
			char[] locChars=new char[cChars];
			
			myStrElements = new String[AmountOfElements];
			Random locRandom = new Random(DateTime.Now.Millisecond);

			for (int locOutCount = 0; locOutCount<AmountOfElements; locOutCount++)
			{
				for (int locInCount=0; locInCount<cChars; locInCount++)
				{
					int locIntTemp = (int) (locRandom.NextDouble() * 52);
					if (locIntTemp > 26) 
						locIntTemp += 97 - 26;
					else
						locIntTemp += 65;
					
					// Einziger Vorteil bislang: einen Wert über Byte nach Char casten,
					// um damit den ASCII in das eigentliche Zeichen zu wandeln
					locChars[locInCount] = (char) (byte) locIntTemp;
				}
		
				myStrElements[locOutCount] = new String(locChars);
			}
		}

		public void ShellSort()
		{
			int locOutCount, locInCount;
			int locDelta;
			string locStrTemp;

			locDelta = 1;

			// Größten Wert der Distanzfolge ermitteln
			do 
				locDelta = 3 * locDelta + 1;
			while (locDelta <= myStrElements.Length);

			do
			{
				//War einen zu groß, also wieder teilen
				locDelta /= 3;

				//Shellsort's Kernalgorithmus
				for (locOutCount = locDelta; locOutCount<myStrElements.Length;locOutCount++)
				{
					locStrTemp = myStrElements[locOutCount];
					locInCount = locOutCount;
					while (String.Compare(myStrElements[locInCount - locDelta],locStrTemp)<0)
					{
						myStrElements[locInCount] = myStrElements[locInCount - locDelta];
						locInCount = locInCount - locDelta;
						if (locInCount <= locDelta) break;
					}
			
					myStrElements[locInCount] = locStrTemp;
				}
			}
			while (locDelta != 0);
		}
	}

}
