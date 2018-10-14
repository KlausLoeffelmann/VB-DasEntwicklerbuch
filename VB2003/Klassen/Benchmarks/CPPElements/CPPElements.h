// CPPElements.h

#pragma once

using namespace System;

namespace CPPElements
{
	public __gc class CPPIntElements
	{
	private:
		// Sonderform von Arrays (da verwaltet) werden mit __gc gekennzeichnet
		int myIntElements __gc[];

	public:
		CPPIntElements(int AmountOfElements)
		{
			myIntElements = new int __gc[AmountOfElements];
			System::Random *locRandom = new System::Random(System::DateTime::Now.Millisecond);

			for (int locCount=0; locCount<AmountOfElements; locCount++)
				myIntElements[locCount]= locRandom->Next();

		}

		System::Void ShellSort()
		{
			int locOutCount, locInCount;
			int locDelta;
			int locIntTemp;

			locDelta = 1;

			// Größten Wert der Distanzfolge ermitteln
			do 
				locDelta = 3 * locDelta + 1;
			while (locDelta <= myIntElements->Length);

			do
			{
				//War einen zu groß, also wieder teilen
				locDelta /= 3;

				//Shellsort's Kernalgorithmus
				for (locOutCount = locDelta; locOutCount<myIntElements->Length;locOutCount++)
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

	};

	public __gc class CPPStrElements
	{

	private:
		String* myStrElements __gc[];
		const static cChars=10;

	public:
		CPPStrElements(int AmountOfElements)
		{
			Char locChars __gc[]=new Char __gc[cChars];


			myStrElements= new String* __gc[AmountOfElements];
			System::Random *locRandom = new System::Random(System::DateTime::Now.Millisecond);

			for (int locOutCount = 0; locOutCount<AmountOfElements-1; locOutCount++)
			{
				for (int locInCount=0; locInCount<cChars; locInCount++)
				{
					int locIntTemp = (int) (locRandom->NextDouble() * 52);
					if (locIntTemp > 26) 
						locIntTemp += 97 - 26;
					else
						locIntTemp += 65;
					
					locChars[locInCount] = System::Convert::ToChar(locIntTemp);
				}
		
				myStrElements[locOutCount] = new String(locChars);
			}
		}

		System::Void ShellSort()
		{
			int locOutCount, locInCount;
			int locDelta;
			String* locStrTemp;

			locDelta = 1;

			// Größten Wert der Distanzfolge ermitteln
			do 
				locDelta = 3 * locDelta + 1;
			while (locDelta <= myStrElements->Length);

			do
			{
				//War einen zu groß, also wieder teilen
				locDelta /= 3;

				//Shellsort's Kernalgorithmus
				for (locOutCount = locDelta; locOutCount<myStrElements->Length;locOutCount++)
				{
					locStrTemp = myStrElements[locOutCount];
					locInCount = locOutCount;
					
					// Strings können nur über 'Compare' miteinander verglichen werden
					while (myStrElements[locInCount - locDelta]->CompareTo(locStrTemp)<0)
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
	};
}
