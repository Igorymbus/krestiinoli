using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow
    {
        
        private int i, j;
        private bool playerXTurn;  

        public MainWindow()
            : base()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            playerXTurn = true; 
            DisableAllButtons();
        }

        private void win(string btnContent)
        {
            if ((Button1.Content == btnContent && Button2.Content == btnContent &&
                 Button3.Content == btnContent)
               || (Button1.Content == btnContent && Button4.Content == btnContent &&
                   Button7.Content == btnContent)
               || (Button1.Content == btnContent && Button5.Content == btnContent &&
                   Button9.Content == btnContent)
               || (Button2.Content == btnContent && Button5.Content == btnContent &&
                   Button8.Content == btnContent)
               || (Button3.Content == btnContent && Button6.Content == btnContent &&
                   Button9.Content == btnContent)
               || (Button4.Content == btnContent && Button5.Content == btnContent &&
                   Button6.Content == btnContent)
               || (Button7.Content == btnContent && Button8.Content == btnContent &&
                   Button9.Content == btnContent)
               || (Button3.Content == btnContent && Button5.Content == btnContent &&
                   Button7.Content == btnContent))
            {
                if (btnContent == "X")
                {
                    MessageBox.Show("ИГРОК X ПОБЕДЯ");
                    Label2.Content = ++j;
                }
                else if (btnContent == "O")
                {
                    MessageBox.Show("ИГРОК O ПОБЕДЯ");
                    Label1.Content = ++i;
                }
                DisableAllButtons();
            }
            else
            {
                bool isGameDraw = true;
                foreach (Button btn in wrapPanel1.Children)
                {
                    if (btn.IsEnabled)
                    {
                        isGameDraw = false;
                        break;
                    }
                }

                if (isGameDraw)
                {
                    MessageBox.Show("ТЫ ПРОДУЛ! НИЧЬЯ!");
                    EnableAllButtons();
                }
            }
            playerXTurn = !playerXTurn; 
        }

        private void DisableAllButtons()
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.IsEnabled = false;
            }
        }

        private void EnableAllButtons()
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content = "X";
            btn.IsEnabled = false;
            win(btn.Content.ToString());



            if (!IsGameFinished())
            {
                
                RobotMove();
            }
        }

        private bool IsGameFinished()
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                if (btn.IsEnabled)
                {
                    return false;
                }
            }
            return true;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }
            EnableAllButtons();
        playerXTurn = !playerXTurn;
        }

        private void RobotMove()
        {
            Random random = new Random();
            int randomIndex;
            do
            {
                randomIndex = random.Next(0, wrapPanel1.Children.Count);
            } while (!((wrapPanel1.Children[randomIndex] as Button).Content as string).Equals(""));

            
            Button robotButton = wrapPanel1.Children[randomIndex] as Button;
            robotButton.Content = "O";
            robotButton.IsEnabled = false;

           
            win("O");
        }
    }
}
