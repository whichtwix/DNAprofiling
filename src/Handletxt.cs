using System.IO;

namespace DNA
{
    internal sealed class DNAstring
    {
        public static void Parsestring(string txtfile, List<string> basecombinations, out List<Tuple<string, int>> basecounts)
        {
            string dna = File.ReadAllText(txtfile);
            basecounts = Calculatebasesfromstring(basecombinations, dna);
        }
        
        public static List<Tuple<string, int>> Calculatebasesfromstring(List<string> basecombinations, string dna)
        {
            //using the dna to make a list similar to the CSVdata.people one for comparison
            //we are looking for consecutive bases and not totals
            List<Tuple<string, int>> basecounts = new();
            int currentcount = 0;
            int maxcount = 0;
            foreach (string basecombination in basecombinations)
            {
                int firstfound = dna.IndexOf(basecombination);
                for (int i = firstfound; i < dna.Length; i += 4)
                {

                    int index = i + 4;
                    if (index > dna.Length) index = dna.Length - 1;
                    if (basecombination == dna[i..index])
                    {
                        // this 2nd if together wth the else handles for when the combination happens at the very end of the dna string
                        if (index != dna.Length)
                        {
                            currentcount++;
                        }
                        else
                        {
                            currentcount++;
                            maxcount = currentcount;
                            currentcount = 0;
                        }
                    }
                    else
                    {
                        if (currentcount > maxcount) maxcount = currentcount;
                        currentcount = 0;
                    }
                }
                basecounts.Add(new(basecombination, maxcount));
                maxcount = 0;
            }
            return basecounts;
        }
    }
}
