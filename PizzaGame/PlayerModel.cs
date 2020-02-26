using System;
using System.Collections.Generic;

namespace PizzaGame
{
    public class PlayerModel
    {
        public enum States
        {
            Dead,
            Alive
        }

        public Int32 PlayerId { get; set; }
        public String PlayerName { get; set; }
        public Boolean IsCurrentPlayer { get; set; }
        public States State { get; set; }
        public List<Int32> EatablePizzas { get; set; }
        public Int32 SelectedNumberOfPizzas { get; set; }
        public Int32 LastNumberOfEatenPizzas { get; set; }
        public Boolean CanPass { get; set; }

        public PlayerModel()
        {
            PlayerId = 0;
            PlayerName = "";
            IsCurrentPlayer = false;
            State = States.Alive;
            EatablePizzas = new List<Int32>() { 1, 2, 3 };
            SelectedNumberOfPizzas = 1;
            LastNumberOfEatenPizzas = 0;
            CanPass = false;
        }

        public PlayerModel(Int32 playerId, String playerName)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            IsCurrentPlayer = false;
            State = States.Alive;
            EatablePizzas = new List<Int32>() { 1, 2, 3 };
            SelectedNumberOfPizzas = 1;
            LastNumberOfEatenPizzas = 0;
            CanPass = false;
        }
    }
}
