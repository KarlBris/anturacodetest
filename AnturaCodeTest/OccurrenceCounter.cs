using System;
using System.IO;


namespace AnturaCodeTestCSharp
{

    /*
     * Specifikation är:
     * - Kommandopromptsprogram som tar exakt ett argument
     * - Argumentet är en sökväg till en fil
     * - Söksträng är filnamnet utan filändelse
     * - Programmet ska skriva ut hur många gånger filnamnet existerar i filen
     * -- Jag väljer att tolka det som att överlappande strängar räknas individuellt: "anturantura" -> 2 förekomster av "antura",
     * -- också att programmet skiljer på versaler och gemener
     * 
     * Programmet innehåller buggar. Hanterar fel dåligt. Är inte fint strukturerat. Saknar tester.
     * 
     * Din uppgift är att skriva om det så att det blir fint, vältestat, hanterar corner cases,
     * och allt det där andra som hör produktionskvalitet till.
     * 
     * Språk: C#/F# enligt tyckte och smak. Med fördel kan svaret levereras på Github eller liknande, 
     * men det går bra att skicka en zip-fil. Gärna ett färdigt projekt som går att kompilera och köra.
     * */

    public class OccurrenceCounter
    {
        public readonly string filename;

        public OccurrenceCounter(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Counts occurrences of a string in another string. Will also count overlapping occurrences.
        /// </summary>
        /// <param name="wholeString">The string in which to search</param>
        /// <param name="searchString">The string to search for</param>
        /// <returns>The number of occurrences of searchString in wholeString</returns>
        public static int CountOccurrencesInString(string wholeString, string searchString)
        {
            int searchStringLength = searchString.Length;

            char[] wholeChars = wholeString.ToCharArray();
            char[] searchChars = searchString.ToCharArray();

            int count = 0;
            for (int i = 0; i < wholeString.Length - searchStringLength + 1; i++)
            {
                bool found = true;

                for(int j = 0; j < searchStringLength; j++)
                {

                    if (wholeChars[i+j] != searchChars[j])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    count += 1;
                }
            }

            return count;
        }

        /// <summary>
        /// Opens the file specified for this OccurenceCounter, and counts the number of occurrences of the given word within
        /// </summary>
        /// <param name="word">The word to search for</param>
        /// <returns>The number of occurrences of the given word in the file</returns>
        public int CountOccurrences(string word)
        {
            using (FileStream fileStream = File.Open(filename, FileMode.Open))
            { 
                StreamReader file = new StreamReader(fileStream);

                string line;
                int counter = 0;
                while ((line = file.ReadLine()) != null)
                {
                    counter += CountOccurrencesInString(line, word);
                }
                return counter;
            }
        }
    }
}