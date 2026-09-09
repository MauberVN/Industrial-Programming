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
