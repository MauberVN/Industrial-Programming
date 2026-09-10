using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Program
    {
        struct GeneticData
        {
            public string Protein;
            public string Organism;
            public string AminoAcids;
        }

        struct Command
        {
            public string Name;
            public string Parameter1;
            public string Parameter2;
        }

        private const string STUDENT_NAME = "Novik Vladislav";
        private const int ORGANISM_COLUMN_WIDTH = 25;
        private const int AMINO_ACID_COLUMN_WIDTH = 11;
        private const string SEPARATOR = 
            "--------------------------------------------------------------------------";

        static List<GeneticData> ReadData(string filename)
        {
            List<GeneticData> data = new List<GeneticData>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split('\t');

                    GeneticData gd;
                    gd.Protein = parts[0];
                    gd.Organism = parts[1];
                    gd.AminoAcids = parts[2];
                    
                    data.Add(gd);
                }
            }
            return data;
        }

        static List<Command> ReadCommands(string filename)
        {
            List<Command> commands = new List<Command>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split('\t');

                    Command command;
                    command.Name = parts[0];
                    command.Parameter1 = parts.Length > 1 ? parts[1] : String.Empty;
                    command.Parameter2 = parts.Length > 2 ? parts[2] : String.Empty;
                    
                    commands.Add(command);
                }
            }
            return commands;
        }

        private static string RLDecoding(string aminoAcids)
        {
            StringBuilder decoded = new StringBuilder();

            int i = 0;
            while (i < aminoAcids.Length)
            {
                char ch = aminoAcids[i];

                if (char.IsDigit(ch))
                {
                    int count = ch - '0';
                    char letter = aminoAcids[i + 1];
                    decoded.Append(letter, count);
                    i += 2;
                }
                else
                {
                    decoded.Append(ch);
                    i += 1;
                }
            }

            return decoded.ToString();
        }

        static void DoSearch(List<GeneticData> data, string sequence, StreamWriter writer)
        {
            string decodedSequence = RLDecoding(sequence);

            writer.WriteLine("organism".PadRight(ORGANISM_COLUMN_WIDTH) + "protein");

            bool found = false;
            foreach (GeneticData gd in data)
            {
                if (gd.AminoAcids.Contains(decodedSequence))
                {
                    writer.WriteLine(gd.Organism.PadRight(ORGANISM_COLUMN_WIDTH) + gd.Protein);
                    found = true;
                }
            }

            if (!found)
            {
                writer.WriteLine("NOT FOUND");
            }
        }

        static void DoDiff(List<GeneticData> data, string proteinName1, string proteinName2, StreamWriter writer)
        {
            writer.WriteLine("amino-acids difference:");

            GeneticData? protein1 = FindProtein(data, proteinName1);
            GeneticData? protein2 = FindProtein(data, proteinName2);

            if (protein1 == null || protein2 == null)
            {
                writer.WriteLine("MISSING:");
                
                if (protein1 == null)
                    writer.WriteLine(protein1);
                if (protein2 == null)
                    writer.WriteLine(protein2);

                return;
            }

            string a = protein1.Value.AminoAcids;
            string b = protein2.Value.AminoAcids;
            
            int minLenght = Math.Min(a.Length, b.Length);
            int difference = 0;
            
            for (int i = 0; i < minLenght; i++)
                if (a[i] != b[i])
                    difference++;

            difference += Math.Abs(a.Length - b.Length);
            
            writer.WriteLine(difference);
        }

        static void DoMode(List<GeneticData> data, string proteinName, StreamWriter writer)
        {
            writer.WriteLine("amino-acid occurs:");

            GeneticData? protein = FindProtein(data, proteinName);

            if (protein == null)
            {
                writer.WriteLine("MISSING:");
                writer.WriteLine(proteinName);
                return;
            }
            
            string aminoAcids = protein.Value.AminoAcids;

            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (char ch in aminoAcids)
            {
                if (!counts.TryAdd(ch, 1))
                    counts[ch]++;
            }

            char bestLetter = ' ';
            int bestCount = -1;

            foreach (KeyValuePair<char, int> kvp in counts.OrderBy(kvp => kvp.Key))
            {
                if (kvp.Value > bestCount)
                {
                    bestCount = kvp.Value;
                    bestLetter = kvp.Key;
                }
            }

            writer.WriteLine(bestLetter.ToString().PadRight(AMINO_ACID_COLUMN_WIDTH) + bestCount);
        }

        static GeneticData? FindProtein(List<GeneticData> data, string proteinName)
        {
            foreach (GeneticData gd in data)
                if (gd.Protein == proteinName)
                    return gd;

            return null;
        }

        static void CommandHandler(List<GeneticData> data, List<Command> commands, StreamWriter writer)
        {
            writer.WriteLine(STUDENT_NAME);
            writer.WriteLine("Genetic Searching");
            writer.WriteLine(SEPARATOR);

            int operationNumber = 1;

            foreach (Command command in commands)
            {
                string header;

                if (command.Name == "diff")
                {
                    header = string.Format("{0:D3}   {1}   {2}   {3}", 
                        operationNumber, command.Name, command.Parameter1, command.Parameter2);
                }
                else if (command.Name == "search")
                {
                    header = string.Format("{0:D3}   {1}   {2}", 
                        operationNumber, command.Name, RLDecoding(command.Parameter1));
                }
                else
                {
                    header = string.Format("{0:D3}   {1}   {2}",
                        operationNumber, command.Name, command.Parameter1);
                }
                
                writer.WriteLine(header);

                if (command.Name == "search")
                    DoSearch(data, command.Parameter1, writer);
                else if (command.Name == "diff")
                    DoDiff(data, command.Parameter1, command.Parameter2, writer);
                else if (command.Name == "mode")
                    DoMode(data, command.Parameter1, writer);
                
                writer.WriteLine(SEPARATOR);

                operationNumber++;
            }
        }
        
        static void Main(String[] args)
        {
            string sequenceFile = "sequences.0.txt";
            string commandFile = "commands.0.txt";
            string outputFile = "genedata.0.txt";

            if (args.Length == 3)
            {
                sequenceFile = args[0];
                commandFile = args[1];
                outputFile = args[2];
            }

            List<GeneticData> data = ReadData(sequenceFile);
            List<Command> commands = ReadCommands(commandFile);

            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                CommandHandler(data, commands, writer);
            }

            Console.WriteLine("Ready! The result is written to a file " + outputFile);
        }
    }
}
