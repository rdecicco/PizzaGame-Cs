using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaGame
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        public delegate bool EatPizzasDelegate(int NrOfPizzas);

        private PlayerModel Player;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PlayerViewModel()
        {
            Player = new PlayerModel();
        }

        public PlayerViewModel(Int32 playerId, String playerName)
        {
            Player = new PlayerModel(playerId, playerName);
        }

        public EatPizzasDelegate EatPizzasMethod { get; set; }

        public Int32 PlayerId
        {
            get
            {
                return Player.PlayerId;
            }

            set
            {
                if (Player.PlayerId != value)
                {
                    Player.PlayerId = value;
                    NotifyPropertyChanged("PlayerId");
                }
            }
        }

        public String PlayerName
        {
            get
            {
                return Player.PlayerName;
            }

            set
            {
                if (Player.PlayerName != value)
                {
                    Player.PlayerName = value;
                    NotifyPropertyChanged("PlayerName");
                }
            }
        }

        public Boolean IsCurrentPlayer
        {
            get
            {
                return Player.IsCurrentPlayer;
            }

            set
            {
                if (Player.IsCurrentPlayer != value)
                {
                    Player.IsCurrentPlayer = value;
                    NotifyPropertyChanged("IsCurrentPlayer");
                }
            }
        }

        public PlayerModel.States State
        {
            get
            {
                return Player.State;
            }
            set
            {
                if (Player.State != value)
                {
                    Player.State = value;
                    NotifyPropertyChanged("State");
                }
            }
        }

        public List<Int32> EatablePizzas
        {
            get
            {
                return Player.EatablePizzas;
            }
            set
            {
                if (Player.EatablePizzas != value)
                {
                    Player.EatablePizzas = value;
                    NotifyPropertyChanged("EatablePizzas");
                }
            }
        }

        public Int32 SelectedNumberOfPizzas
        {
            get
            {
                return Player.SelectedNumberOfPizzas;
            }

            set
            {
                if (Player.SelectedNumberOfPizzas != value)
                {
                    Player.SelectedNumberOfPizzas = value;
                    NotifyPropertyChanged("SelectedNumberOfPizzas");
                }
            }
        }

        public Int32 LastNumberOfEatenPizzas
        {
            get
            {
                return Player.LastNumberOfEatenPizzas;
            }

            set
            {
                if (Player.LastNumberOfEatenPizzas != value)
                {
                    Player.LastNumberOfEatenPizzas = value;
                    NotifyPropertyChanged("LastNumberOfEatenPizzas");
                }
            }
        }

        public Boolean CanPass
        {
            get
            {
                return Player.CanPass;
            }

            set
            {
                if (Player.CanPass != value)
                {
                    Player.CanPass = value;
                    NotifyPropertyChanged("CanPass");
                }
            }
        }

        private Boolean _IsVisible;
        public Boolean IsVisible
        {
            get
            {
                return _IsVisible;
            }

            set
            {
                if (_IsVisible != value)
                {
                    _IsVisible = value;
                    NotifyPropertyChanged("IsVisible");
                }
            }
        }
    }
}
