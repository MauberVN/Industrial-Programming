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
            public string protein;
            public string organism;
            public string amino_acids;
        }

        struct Command
        {
            public string name;
            public string parameter1;
            public string parameter2;
        }

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
                    gd.protein = parts[0];
                    gd.organism = parts[1];
                    gd.amino_acids = parts[2];
                    
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
                    command.name = parts[0];
                    command.parameter1 = parts.Length > 1 ? parts[1] : String.Empty;
                    command.parameter2 = parts.Length > 2 ? parts[2] : String.Empty;
                    
                    commands.Add(command);
                }
            }
            return commands;
        }

        static string RLDecoding(string amino_acids)
        {
            StringBuilder decoded = new StringBuilder();

            int i = 0;
            while (i < amino_acids.Length)
            {
                char ch = amino_acids[i];

                if (char.IsDigit(ch))
                {
                    int count = ch - '0';
                    char letter = amino_acids[i + 1];
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

        static void CommandHandler(List<GeneticData> data, List<Command> commands, StreamWriter writer)
        {
            writer.WriteLine("NOVIK_VLADISLAV");
            writer.WriteLine("Genetic Search");
            writer.WriteLine(SEPARATOR);

            int operationNumber = 1;

            foreach (Command command in commands)
            {
                string header;

                if (command.name == "diff")
                {
                    header = string.Format("{0:D3}   {1}   {2}   {3}", 
                        operationNumber, command.name, command.parameter1, command.parameter2);
                }
                else if (command.name == "search")
                {
                    header = string.Format("{0:D3}   {1}   {2}", 
                        operationNumber, command.name, RLDecoding(command.parameter1));
                }
                else
                {
                    header = string.Format("{0:D3}   {1}   {2}",
                        operationNumber, command.name, command.parameter1);
                }
                
                writer.WriteLine(header);

                if (command.name == "search")
                    DoSearch(data, command.parameter1, writer);
                else if (command.name == "diff")
                    DoDiff(data, command.parameter1, command.parameter2, writer);
                else if (command.name == "mode")
                    DoMode(data, command.parameter1, writer);
                
                writer.WriteLine(SEPARATOR);

                operationNumber++;
            }
        }
        
        static void Main(String[] args)
        {
            string sequenceFile = "sequence.0.txt";
            string commandFile = "command.0.txt";
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
