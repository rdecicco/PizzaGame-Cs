using System;
using System.Collections.Generic;


namespace PizzaGame
{
    public class GameManager
    {
        private static GameManager Instance;

        public GameViewModel gameViewModel = new GameViewModel();
        public PlayerViewModel Player1;
        public PlayerViewModel Player2;
        private Boolean fullGame;

        private GameManager()
        {
            gameViewModel.GameResult = "Game Over";
            Player1 = new PlayerViewModel(1, "Player A")
            {
                EatPizzasMethod = EatPizzas,
                IsCurrentPlayer = false,
                IsVisible = false
            };
            Player2 = new PlayerViewModel(2, "Player B")
            {
                EatPizzasMethod = EatPizzas,
                IsCurrentPlayer = false,
                IsVisible = false
            };
        }

        public static GameManager GetInstance()
        {
            if (Instance == null)
                Instance = new GameManager();

            return Instance;
        }

        public void NewGame(Boolean fullGame)
        {
            this.fullGame = fullGame;
            gameViewModel.GameResult = String.Empty;
            gameViewModel.State = GameModel.GameStates.Play;
            Player1 = new PlayerViewModel(1, "Player A")
            {
                EatPizzasMethod = EatPizzas,
                IsCurrentPlayer = true,
                IsVisible = true
            };
            Player2 = new PlayerViewModel(2, "Player B")
            {
                EatPizzasMethod = EatPizzas,
                IsCurrentPlayer = false,
                IsVisible = true
            };
            Random r = new Random(DateTime.Now.Millisecond);
            gameViewModel.NrOfPizzas = r.Next(5, 30);
        }

        public bool EatPizzas(Int32 numberOfEatenPizzas)
        {
            if (gameViewModel.State != GameModel.GameStates.Play)
                return false;

            PlayerViewModel currentPlayer = Player1.IsCurrentPlayer ? Player1 : Player2;
            PlayerViewModel otherPlayer = GetOtherPlayer(currentPlayer.PlayerId);

            if (!currentPlayer.IsCurrentPlayer || otherPlayer.IsCurrentPlayer)
                return false;

            if (numberOfEatenPizzas > gameViewModel.NrOfPizzas)
                return false;

            currentPlayer.LastNumberOfEatenPizzas = numberOfEatenPizzas;

            if (numberOfEatenPizzas == 0)
            {
                SwapPlayers(currentPlayer, otherPlayer);
                return true;
            }

            gameViewModel.NrOfPizzas -= numberOfEatenPizzas;

            if (fullGame)
            {
                if (gameViewModel.NrOfPizzas == 0)
                {
                    gameViewModel.GameResult = "Winner is " + otherPlayer.PlayerName;
                    currentPlayer.State = PlayerModel.States.Dead;
                    gameViewModel.State = GameModel.GameStates.GameOver;
                    currentPlayer.IsVisible = false;
                    otherPlayer.IsVisible = false;
                    return true;
                }
            }
            else
            {
                if (gameViewModel.NrOfPizzas == 0 || gameViewModel.NrOfPizzas == 1)
                {
                    gameViewModel.GameResult = "Winner is " + otherPlayer.PlayerName;
                    currentPlayer.State = PlayerModel.States.Dead;
                    gameViewModel.State = GameModel.GameStates.GameOver;
                    currentPlayer.IsVisible = false;
                    otherPlayer.IsVisible = false;
                    return true;
                }
                else if (gameViewModel.NrOfPizzas == 2)
                {
                    gameViewModel.GameResult = "Winner is " + currentPlayer.PlayerName;
                    otherPlayer.State = PlayerModel.States.Dead;
                    gameViewModel.State = GameModel.GameStates.GameOver;
                    currentPlayer.IsVisible = false;
                    otherPlayer.IsVisible = false;
                    return true;
                }
            }

            SwapPlayers(currentPlayer, otherPlayer);
            return true;
        }

        public Boolean CanPass()
        {
            PlayerViewModel otherPlayer;
            if (Player1.IsCurrentPlayer)
            {
                otherPlayer = Player2;
            }
            else
            {
                otherPlayer = Player1;
            }

            if (otherPlayer.LastNumberOfEatenPizzas == 0)
                return false;

            for (uint i = 1; i < 4; i++)
            {
                if (i != otherPlayer.LastNumberOfEatenPizzas && i <= gameViewModel.NrOfPizzas)
                {
                    return false;
                }
            }

            return true;
        }

        private PlayerViewModel GetOtherPlayer(int playerId)
        {
            if (Player1.PlayerId == playerId)
                return Player2;
            return Player1;
        }

        private void SwapPlayers(PlayerViewModel currentPlayer, PlayerViewModel otherPlayer)
        {
            currentPlayer.IsCurrentPlayer = false;
            otherPlayer.IsCurrentPlayer = true;
            otherPlayer.EatablePizzas = CreatePizzasList(currentPlayer.LastNumberOfEatenPizzas);
            otherPlayer.SelectedNumberOfPizzas = otherPlayer.EatablePizzas[0];
            otherPlayer.CanPass = CanPass();
        }

        private List<Int32> CreatePizzasList(Int32 disabledValue)
        {
            List<Int32> list = new List<Int32>();
            for (Int32 i = 1; i < 4; i++)
            {
                if (i != disabledValue)
                {
                    list.Add(i);
                }
            }
            return list;
        }
    }
}
