using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace Game
{
    public enum GameState
    {
        Start,
        End
    }

    public class Game
    {
        public int size;
        public Player cat;
        public Player mouse;
        public GameState state;

        public static string InputFile;
        public static string OutFile;

        private string[] commands;
        private int commandIndex = 0;
        private List<String> reportLines = new List<string>();
        private bool mouseCaught = false;
        private int caughtAtLocation = -1;

        public Game(int size)
        {
            this.size = size;
            cat = new Player("Cat");
            mouse = new Player("Mouse");
            cat.boardSize = size;
            state = GameState.Start;
        }

        private void LoadInput()
        {
            string[] allLines = File.ReadAllLines(InputFile);
            if (allLines.Length == 0)
                throw new InvalidDataException("Input file is empty!");

            size = int.Parse(allLines[0].Trim(), CultureInfo.InvariantCulture);
            cat.boardSize = size;
            mouse.boarddSize = size;

            commands = new string[allLines.Length - 1];
            Array.Copy(allLines, 1, commands, 0, allLines.Length - 1);
        }

        public void Run()
        {
            LoadInput();

            while (state != GameState.End)
            {
                if (commandIndex >= commands.Length)
                {
                    state = GameState.End;
                    break;
                }

                string line = commands[commandIndex++].Trim();
                if (line.Length == 0)
                    continue;

                char command = line[0];

                if (command == 'P')
                {
                    DoPrintCommand();
                }
                else
                {
                    int steps = int.Parse(line.Substring(1).Trim(), CultureInfo.InvariantCulture);
                    DoMoveCommand(command, steps);
                }

                if (mouseCaught)
                    state = GameState.End;
            }

            WriteReport();
        }
        
        private void DoMoveCommand(char command, int steps)
        {
            switch (command)
            {
                case 'M':
                    mouse.Move(steps);
                    break;
                case 'C':
                    cat.Move(steps);
                    break;
            }

            if (cat.state == State.Playing && mouse.satet == State.Playing &&
                cat.location == mouse.location)
            {
                cat.state = State.Winner;
                mouse.state = State.Looser;
                mouseCaught = true;
                caughtAtLocation = mouse.Location;
            }
        }

        private void DoPrintCommand()
        {
            string catField = cat.state == GameState.NotInGame
                ? "??".PadLeft(3)
                : cat.location.ToString(CultureInfo.InvariantCulture).PadLeft(6);
            
            string mouseField = mouse.state == GameState.NotInGame
                ? "??".PadLeft(3)
                : cat.location.ToString(CultureInfo.InvariantCulture).PadLeft(6);

            string line = catField + mouseField;

            if (cat.state != GameState.NotInGame && mouse.state != GameState.NotInGame)
            {
                int distance = GetDistance();
                line += distance.ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }
            
            reportLines.Add(line);
        }
        
        private int GetDistance()
        {
            return Math.Abs(cat.location - mouse.location);
        }
        
        private void WriteReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Cat and Mouse\n");
            sb.Append("\n");
            sb.Append("Cat Mouse  Distance\n");
            sb.Append("-------------------\n");

            foreach (string line in reportLines)
            {
                sb.Append(line);
                sb.Append("\n");
            }

            sb.Append("-------------------\n");
            sb.Append("\n");
            sb.Append("\n");
            sb.Append("Distance traveled:   Mouse    Cat\n");

            sb.Append(mouse.distanceTraveled.ToString(CultureInfo.InvariantCulture).PadLeft(26));
            sb.Append(cat.distanceTraveled.ToString(CultureInfo.InvariantCulture).PadLeft(7));
            sb.Append("\n");
            sb.Append("\n");

            if (mouseCaught)
            {
                sb.Append("Mouse caught at:");
                sb.Append(caughtAtLocation.ToString(CultureInfo.InvariantCulture).PadLeft(3));
                sb.Append("\n");
            }
            else
            {
                sb.Append("Mouse evaded Cat\n");
            }

            File.WriteAllText(OutFile, sb.ToString());
        }
    }
}
