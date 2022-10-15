global using System;
global using System.Collections.Generic;
       using System.Linq;

namespace DNA
{
    internal sealed class DNA
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the path of the csv file");
            string csvpath = Console.ReadLine();
            Console.WriteLine("Enter the path of the text file");
            string txtpath = Console.ReadLine();

            CSVdata.Parsefile($@"{csvpath}", out List<CSVdata.DNAprofile> People, out List<string> basecombinations);
            DNAstring.Parsestring($@"{txtpath}", basecombinations, out List<Tuple<string, int>> basecounts);
            Comparebases(People, basecounts, out string match);
            Console.WriteLine($"the parsed dna matched with {match}");
        }
        
        private static string Comparebases(List<CSVdata.DNAprofile> people, List<Tuple<string, int>> basecounts, out string match)
        {
            foreach (var person in people)
            {
                if (person.person_bases.SequenceEqual(basecounts))
                {
                    return match = person.person_name;
                }
            }
            return match = "No one";
        }
    }
}