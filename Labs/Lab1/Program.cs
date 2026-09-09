using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab1
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
    
    class Program
    {
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
