using System.Windows;

namespace PizzaGame
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager gameManager;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            gameManager = GameManager.GetInstance();
            DataContext = gameManager.gameViewModel;
            Player1.Player = gameManager.Player1;
            Player2.Player = gameManager.Player2;
        }

        private void NewFullGameClicked(object sender, RoutedEventArgs e)
        {
            gameManager.NewGame(true);
            InitNewGame();
        }
        private void NewGameClicked(object sender, RoutedEventArgs e)
        {
            gameManager.NewGame(false);
            InitNewGame();
        }

        private void InitNewGame()
        {
            Player1.Player = gameManager.Player1;
            Player2.Player = gameManager.Player2;
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
