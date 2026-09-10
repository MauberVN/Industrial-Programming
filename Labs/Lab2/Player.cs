namespace Lab2
{
    public enum State
    {
        Winner,
        Looser,
        Playing,
        NotInGame
    }

    public class Player
    {
        public string name;
        public int location;
        public State state = State.NotInGame;
        public int distanceTravelled = 0;

        public int boardSize = 0;
        
        public Player(string name)
        {
            this.name = name;
            this.location = -1;
        }

        public void Move(int steps)
        {
            if (state == State.NotInGame)
            {
                location = steps;
                state = State.Winner;
            }
            else
            {
                location = (((location - 1 + steps) % boardSize) + boardSize) % boardSize + 1;
                distanceTravelled += Math.Abs(steps);
            }
        }
    }
}
