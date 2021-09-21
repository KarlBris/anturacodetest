using System;
using System.IO;

namespace AnturaCodeTestCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                OccurrenceCounter counter = new OccurrenceCounter(args[0]);
                try
                {
                    string searchWord = Path.GetFileNameWithoutExtension(counter.filename);
                    int count = counter.CountOccurrences(searchWord);
                    Console.WriteLine("found {0}", count);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The program encountered an error: {0}", e.Message);
                }
            }
            else
            {
                Console.WriteLine("Please supply exactly one argument (file path) to run the program.");
            }
        }
    }
}
