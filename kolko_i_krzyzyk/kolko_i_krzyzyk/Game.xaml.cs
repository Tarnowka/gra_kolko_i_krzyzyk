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

        public int player1 { get; set; }
        public int player2 { get; set; }
        public int draw { get; set; }

        public Game()
        {
            InitializeComponent();
            player1 = 0;
            player2 = 0;
            draw = 0;
            NewGame();
        }

        private void NewGame()
        {
            results = new Enum[25];

            for (var i = 0; i < results.Length; i++)
                results[i] = Enum.empty;

            player1Turn = true;
            gameover = false;

            container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
            });
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
            if (results[0] != Enum.empty && (results[0] & results[1] & results[2] & results[3] & results[4]) == results[0])
            {
                gameover = true;
                button00.Background = button10.Background = button20.Background = button30.Background = button40.Background = Brushes.Green;
                Score();
            }
            if (results[5] != Enum.empty && (results[5] & results[6] & results[7] & results[8] & results[9]) == results[5])
            {
                gameover = true;
                button01.Background = button11.Background = button21.Background = button31.Background = button41.Background = Brushes.Green;
                Score();
            }
            if (results[10] != Enum.empty && (results[10] & results[11] & results[12] & results[13] & results[14]) == results[10])
            {
                gameover = true;
                button02.Background = button12.Background = button22.Background = button32.Background = button42.Background = Brushes.Green;
                Score();
            }
            if (results[15] != Enum.empty && (results[15] & results[16] & results[17] & results[18] & results[19]) == results[15])
            {
                gameover = true;
                button03.Background = button13.Background = button23.Background = button33.Background = button43.Background = Brushes.Green;
                Score();
            }
            if (results[20] != Enum.empty && (results[20] & results[21] & results[22] & results[23] & results[24]) == results[20])
            {
                gameover = true;
                button04.Background = button14.Background = button24.Background = button34.Background = button44.Background = Brushes.Green;
                Score();
            }


            if (results[0] != Enum.empty && (results[0] & results[5] & results[10] & results[15] & results[20]) == results[0])
            {
                gameover = true;
                button00.Background = button01.Background = button02.Background = button03.Background = button04.Background = Brushes.Green;
                Score();
            }
            if (results[1] != Enum.empty && (results[1] & results[6] & results[11] & results[16] & results[21]) == results[1])
            {
                gameover = true;
                button10.Background = button11.Background = button12.Background = button13.Background = button14.Background = Brushes.Green;
                Score();
            }
            if (results[2] != Enum.empty && (results[2] & results[7] & results[12] & results[17] & results[22]) == results[2])
            {
                gameover = true;
                button20.Background = button21.Background = button22.Background = button23.Background = button24.Background = Brushes.Green;
                Score();
            }
            if (results[3] != Enum.empty && (results[3] & results[8] & results[13] & results[18] & results[23]) == results[3])
            {
                gameover = true;
                button30.Background = button31.Background = button32.Background = button33.Background = button34.Background = Brushes.Green;
                Score();
            }
            if (results[4] != Enum.empty && (results[4] & results[9] & results[14] & results[19] & results[24]) == results[4])
            {
                gameover = true;
                button40.Background = button41.Background = button42.Background = button43.Background = button44.Background = Brushes.Green;
                Score();
            }


            if (results[0] != Enum.empty && (results[0] & results[6] & results[12] & results[18] & results[24]) == results[0])
            {
                gameover = true;
                button00.Background = button11.Background = button22.Background = button33.Background = button44.Background = Brushes.Green;
                Score();
            }
            if (results[4] != Enum.empty && (results[4] & results[8] & results[12] & results[16] & results[20]) == results[4])
            {
                gameover = true;
                button04.Background = button13.Background = button22.Background = button31.Background = button40.Background = Brushes.Green;
                Score();
            }

            if (!results.Any(x => x == Enum.empty))
            {
                gameover = true;
                draw++;
                remis.Content = draw;
            }
        }

        private void Score()
        {
            if (player1Turn)
            {
                player1++;
                pl1.Content = player1;
            }
            else
            {
                player2++;
                pl2.Content = player2;
            }
        }
    }
}