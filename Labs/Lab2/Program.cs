using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.InputFile = "1.ChaseData.txt";
            Game.OutFile = "1.PursuitLog.txt";

            if (args.Length == 2)
            {
                Game.InputFile = args[0];
                Game.OutFile = args[1];
            }
            
            Game game = new Game(16);
            game.Run();

            Console.WriteLine("Ready. The result was recorded to the file " + Game.OutFile);
        }
    }
}
