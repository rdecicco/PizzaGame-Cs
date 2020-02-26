using System;

namespace PizzaGame
{
    public class GameModel
    {
        public enum GameStates
        {
            GameOver,
            Play
        }

        public GameStates State { get; set; }

        public String GameResult { get; set; }

        public Int32 NrOfPizzas { get; set; }
    }
}
