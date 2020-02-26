using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaGame
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private GameModel gameModel = new GameModel();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public GameModel.GameStates State
        {
            get
            {
                return gameModel.State;
            }

            set
            {
                if (gameModel.State != value)
                {
                    gameModel.State = value;
                    NotifyPropertyChanged("State");
                    NotifyPropertyChanged("IsGameOver");
                    NotifyPropertyChanged("IsPlay");
                }
            }
        }

        public Boolean IsGameOver
        {
            get
            {
                return gameModel.State == GameModel.GameStates.GameOver;
            }
        }

        public Boolean IsPlay
        {
            get
            {
                return gameModel.State == GameModel.GameStates.Play;
            }
        }

        public String GameResult
        {
            get
            {
                return gameModel.GameResult;
            }

            set
            {
                if (gameModel.GameResult != value)
                {
                    gameModel.GameResult = value;
                    NotifyPropertyChanged("GameResult");
                }
            }
        }

        public Int32 NrOfPizzas
        {
            get
            {
                return gameModel.NrOfPizzas;
            }

            set
            {
                if (gameModel.NrOfPizzas != value)
                {
                    gameModel.NrOfPizzas = value;
                    NotifyPropertyChanged("NrOfPizzas");
                }
            }
        }
    }
}
