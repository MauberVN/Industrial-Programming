using System;

namespace Lab2
{
    class Program
    {
        static void main(string[] args)
        {
            Game game = new Game(16);
            game.Run();

            Console.WriteLine("Ready. The result was recorded to the file " + Game.OutFile);
        }
    }
}
