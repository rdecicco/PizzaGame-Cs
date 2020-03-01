using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PizzaGame
{
    /// <summary>
    /// Logica di interazione per Player.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PlayerUserControl()
        {
            InitializeComponent();
        }

        private PlayerViewModel _Player;
        public PlayerViewModel Player
        {
            get
            {
                return _Player;
            }

            set
            {
                if (_Player != value)
                {
                    _Player = value;
                    DataContext = _Player;
                }
            }
        }

        public Visibility UserControlVisibility
        {
            get { return (Visibility)GetValue(UserControlVisibilityProperty); }
            set { 
                SetValue(UserControlVisibilityProperty, value);
                NotifyPropertyChanged("UserControlVisibility");
            }
        }

        public static DependencyProperty UserControlVisibilityProperty =
            DependencyProperty.Register("UserControlVisibility", typeof(Visibility), typeof(PlayerUserControl), new PropertyMetadata(Visibility.Visible));

        private void ConfirmClicked(object sender, RoutedEventArgs e)
        {
            if (Player != null && Player.EatPizzasMethod != null)
                Player.EatPizzasMethod(Player.SelectedNumberOfPizzas);
        }

        private void PassClicked(object sender, RoutedEventArgs e)
        {
            if (Player != null && Player.EatPizzasMethod != null)
                Player.EatPizzasMethod(0);
        }
    }
}
