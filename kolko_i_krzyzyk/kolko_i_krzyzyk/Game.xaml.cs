using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kolko_i_krzyzyk
{
    /// <summary>
    /// Logika interakcji dla klasy Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Enum[] results;

        public bool player1Turn;

        public bool gameover;

        public Game()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            results = new Enum[25];

            for (var i = 0; i < results.Length; i++)
                results[i] = Enum.empty;

            player1Turn = true;
            gameover = false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameover)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;
            var collumn = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = collumn + (row * 5);

            if (results[index] != Enum.empty)
                return;

            if (player1Turn)
            {
                results[index] = Enum.X;
                button.Content = "X";
                player1Turn = false;
            }
            else
            {
                results[index] = Enum.O;
                button.Content = "O";
                player1Turn = true;
            }

            CheckWinner();

        }

        private void CheckWinner()
        {

        }
    }
}
