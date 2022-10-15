using System.IO;

namespace DNA
{
    internal sealed class CSVdata
    {
        public static void Parsefile(string csvfile, out List<DNAprofile> People, out List<string> basecombinations)
        {
            People = new();
            basecombinations = new();

            string[] csv = File.ReadAllLines(csvfile);
            foreach (string line in csv)
            {
                string[] fields = line.Split(",");
                if (Array.IndexOf(csv, line) == 0)
                {
                    //putting the different bases into a list, the first header "name" is ignored
                    foreach (string item in fields[1..])
                    {
                        basecombinations.Add(item);
                    }
                }
                else
                {
                    DNAprofile person = new()
                    {
                        person_name = fields[0],
                        person_bases = Createbaselist(basecombinations, fields[1..])
                    };
                    People.Add(person);
                }
            }
        }

        private static List<Tuple<string, int>> Createbaselist(List<string> basestrings, string[] basenumbers)
        {
            List<Tuple<string, int>> baselist = new();
            foreach (string basenumber in basenumbers)
            {
                int index = Array.IndexOf(basenumbers, basenumber);
                baselist.Add(new(basestrings[index], int.Parse(basenumber)));
            }
            return baselist;
        }
        
        internal sealed class DNAprofile
        {
            public string person_name { get; set; }
            
            public List<Tuple<string, int>> person_bases { get; set; }
        }
    }
}