using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Main
{
    public partial class UkrainianBoard : Form
    {
        private int currentPlayerIndex = 0;
        private Player[] players;
        private int numberOfPlayers = 3;
        private Random random = new Random();
        private string firstPlayer = string.Empty;
        private string secondPlayer = string.Empty;
        private string thirdPlayer = string.Empty;
        private string fourthPlayer = string.Empty;
        public UkrainianBoard(int player, string firstName, string secondName, string thirdName, string fourthName)
        {
            numberOfPlayers = player;
            firstPlayer = firstName;
            secondPlayer = secondName;
            thirdPlayer = thirdName;
            fourthPlayer = fourthName;

            InitializePlayers();
            InitializeComponent();
            UpdateMoney();
            UpdateChat();

            if (player == 4)
            {
                nameLabel4.Text = players[3].Name.ToString();
                moneyLabel4.Text = players[3].Money.ToString();
                panel4.BackColor = players[3].Color;
            }
            else
            {
                panel4.Visible = false;

            }
        }

        private void InitializePlayers()
        {
            players = new Player[numberOfPlayers];
            string name = string.Empty;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Color color = Color.White;
                switch (i)
                {
                    case 0:
                        name = firstPlayer;
                        color = Color.Red; break;
                    case 1:
                        name = secondPlayer;
                        color = Color.Blue; break;
                    case 2:
                        name = thirdPlayer;
                        color = Color.Yellow; break;
                    case 3:
                        name = fourthPlayer;
                        color = Color.Green; break;

                }
                players[i] = new Player(name, color, 10000, 0);
            }
        }

        private void UpdateChat()
        {
            chat.Items.Add($"Ход игрока: {players[currentPlayerIndex].Name}");
        }
        private void UpdateMoney()
        {
            moneyLabel1.Text = players[0].Money.ToString();
            moneyLabel2.Text = players[1].Money.ToString();
            moneyLabel3.Text = players[2].Money.ToString();

            panel1.BackColor = players[0].Color;
            panel2.BackColor = players[1].Color;
            panel3.BackColor = players[2].Color;

            nameLabel1.Text = players[0].Name.ToString();
            nameLabel2.Text = players[1].Name.ToString();
            nameLabel3.Text = players[2].Name.ToString();
        }

        private int animationStep = 0;
        private void MovePlayers(int steps)
        {
            animationStep = steps;
            RollDiceButton.Visible = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[,] bishopImages = new PictureBox[4, 34];

            bishopImages[0, 0] = redBishopStep1;
            bishopImages[0, 1] = redBishopStep2;
            bishopImages[0, 2] = redBishopStep3;
            bishopImages[0, 3] = redBishopStep4;
            bishopImages[0, 4] = redBishopStep5;
            bishopImages[0, 5] = redBishopStep6;
            bishopImages[0, 6] = redBishopStep7;
            bishopImages[0, 7] = redBishopStep8;
            bishopImages[0, 8] = redBishopStep9;
            bishopImages[0, 9] = redBishopStep10;
            bishopImages[0, 10] = redBishopStep11;
            bishopImages[0, 11] = redBishopStep12;
            bishopImages[0, 12] = redBishopStep13;
            bishopImages[0, 13] = redBishopStep14;
            bishopImages[0, 14] = redBishopStep15;
            bishopImages[0, 15] = redBishopStep16;
            bishopImages[0, 16] = redBishopStep17;
            bishopImages[0, 17] = redBishopStep18;
            bishopImages[0, 18] = redBishopStep19;
            bishopImages[0, 19] = redBishopStep20;
            bishopImages[0, 20] = redBishopStep21;
            bishopImages[0, 21] = redBishopStep22;
            bishopImages[0, 22] = redBishopStep23;
            bishopImages[0, 23] = redBishopStep24;
            bishopImages[0, 24] = redBishopStep25;
            bishopImages[0, 25] = redBishopStep26;
            bishopImages[0, 26] = redBishopStep27;
            bishopImages[0, 27] = redBishopStep28;
            bishopImages[0, 28] = redBishopStep29;
            bishopImages[0, 29] = redBishopStep30;
            bishopImages[0, 30] = redBishopStep31;
            bishopImages[0, 31] = redBishopStep32;
            bishopImages[0, 32] = redBishopStep33;
            bishopImages[0, 33] = redBishopStep34;

            bishopImages[1, 0] = blueBishopStep1;
            bishopImages[1, 1] = blueBishopStep2;
            bishopImages[1, 2] = blueBishopStep3;
            bishopImages[1, 3] = blueBishopStep4;
            bishopImages[1, 4] = blueBishopStep5;
            bishopImages[1, 5] = blueBishopStep6;
            bishopImages[1, 6] = blueBishopStep7;
            bishopImages[1, 7] = blueBishopStep8;
            bishopImages[1, 8] = blueBishopStep9;
            bishopImages[1, 9] = blueBishopStep10;
            bishopImages[1, 10] = blueBishopStep11;
            bishopImages[1, 11] = blueBishopStep12;
            bishopImages[1, 12] = blueBishopStep13;
            bishopImages[1, 13] = blueBishopStep14;
            bishopImages[1, 14] = blueBishopStep15;
            bishopImages[1, 15] = blueBishopStep16;
            bishopImages[1, 16] = blueBishopStep17;
            bishopImages[1, 17] = blueBishopStep18;
            bishopImages[1, 18] = blueBishopStep19;
            bishopImages[1, 19] = blueBishopStep20;
            bishopImages[1, 20] = blueBishopStep21;
            bishopImages[1, 21] = blueBishopStep22;
            bishopImages[1, 22] = blueBishopStep23;
            bishopImages[1, 23] = blueBishopStep24;
            bishopImages[1, 24] = blueBishopStep25;
            bishopImages[1, 25] = blueBishopStep26;
            bishopImages[1, 26] = blueBishopStep27;
            bishopImages[1, 27] = blueBishopStep28;
            bishopImages[1, 28] = blueBishopStep29;
            bishopImages[1, 29] = blueBishopStep30;
            bishopImages[1, 30] = blueBishopStep31;
            bishopImages[1, 31] = blueBishopStep32;
            bishopImages[1, 32] = blueBishopStep33;
            bishopImages[1, 33] = blueBishopStep34;

            bishopImages[2, 0] = yellowBishopStep1;
            bishopImages[2, 1] = yellowBishopStep2;
            bishopImages[2, 2] = yellowBishopStep3;
            bishopImages[2, 3] = yellowBishopStep4;
            bishopImages[2, 4] = yellowBishopStep5;
            bishopImages[2, 5] = yellowBishopStep6;
            bishopImages[2, 6] = yellowBishopStep7;
            bishopImages[2, 7] = yellowBishopStep8;
            bishopImages[2, 8] = yellowBishopStep9;
            bishopImages[2, 9] = yellowBishopStep10;
            bishopImages[2, 10] = yellowBishopStep11;
            bishopImages[2, 11] = yellowBishopStep12;
            bishopImages[2, 12] = yellowBishopStep13;
            bishopImages[2, 13] = yellowBishopStep14;
            bishopImages[2, 14] = yellowBishopStep15;
            bishopImages[2, 15] = yellowBishopStep16;
            bishopImages[2, 16] = yellowBishopStep17;
            bishopImages[2, 17] = yellowBishopStep18;
            bishopImages[2, 18] = yellowBishopStep19;
            bishopImages[2, 19] = yellowBishopStep20;
            bishopImages[2, 20] = yellowBishopStep21;
            bishopImages[2, 21] = yellowBishopStep22;
            bishopImages[2, 22] = yellowBishopStep23;
            bishopImages[2, 23] = yellowBishopStep24;
            bishopImages[2, 24] = yellowBishopStep25;
            bishopImages[2, 25] = yellowBishopStep26;
            bishopImages[2, 26] = yellowBishopStep27;
            bishopImages[2, 27] = yellowBishopStep28;
            bishopImages[2, 28] = yellowBishopStep29;
            bishopImages[2, 29] = yellowBishopStep30;
            bishopImages[2, 30] = yellowBishopStep31;
            bishopImages[2, 31] = yellowBishopStep32;
            bishopImages[2, 32] = yellowBishopStep33;
            bishopImages[2, 33] = yellowBishopStep34;

            bishopImages[3, 0] = greenBishopStep1;
            bishopImages[3, 1] = greenBishopStep2;
            bishopImages[3, 2] = greenBishopStep3;
            bishopImages[3, 3] = greenBishopStep4;
            bishopImages[3, 4] = greenBishopStep5;
            bishopImages[3, 5] = greenBishopStep6;
            bishopImages[3, 6] = greenBishopStep7;
            bishopImages[3, 7] = greenBishopStep8;
            bishopImages[3, 8] = greenBishopStep9;
            bishopImages[3, 9] = greenBishopStep10;
            bishopImages[3, 10] = greenBishopStep11;
            bishopImages[3, 11] = greenBishopStep12;
            bishopImages[3, 12] = greenBishopStep13;
            bishopImages[3, 13] = greenBishopStep14;
            bishopImages[3, 14] = greenBishopStep15;
            bishopImages[3, 15] = greenBishopStep16;
            bishopImages[3, 16] = greenBishopStep17;
            bishopImages[3, 17] = greenBishopStep18;
            bishopImages[3, 18] = greenBishopStep19;
            bishopImages[3, 19] = greenBishopStep20;
            bishopImages[3, 20] = greenBishopStep21;
            bishopImages[3, 21] = greenBishopStep22;
            bishopImages[3, 22] = greenBishopStep23;
            bishopImages[3, 23] = greenBishopStep24;
            bishopImages[3, 24] = greenBishopStep25;
            bishopImages[3, 25] = greenBishopStep26;
            bishopImages[3, 26] = greenBishopStep27;
            bishopImages[3, 27] = greenBishopStep28;
            bishopImages[3, 28] = greenBishopStep29;
            bishopImages[3, 29] = greenBishopStep30;
            bishopImages[3, 30] = greenBishopStep31;
            bishopImages[3, 31] = greenBishopStep32;
            bishopImages[3, 32] = greenBishopStep33;
            bishopImages[3, 33] = greenBishopStep34;

            if (players[currentPlayerIndex].CurrentPosition >= 34)
            {
                players[currentPlayerIndex].Money += 1000;
                players[currentPlayerIndex].CurrentPosition = players[currentPlayerIndex].CurrentPosition % 34;
                UpdateMoney();
            }

            PictureBox image = bishopImages[currentPlayerIndex, players[currentPlayerIndex].CurrentPosition % 34];
            PictureBox image2 = bishopImages[currentPlayerIndex, (players[currentPlayerIndex].CurrentPosition + 1) % 34];
            image.Visible = false;
            image2.Visible = true;
            players[currentPlayerIndex].CurrentPosition++;
            animationStep--;

            if (animationStep < 1)
            {
                timer1.Stop();
                RollDiceButton.Visible = true;
                currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                UpdateChat();
                return;
            }
        }

        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            int firstDice = random.Next(1, 6);
            int secondDice = random.Next(1, 6);
            int diceResult = firstDice + secondDice;

            chat.Items.Add($"Выпало: {diceResult}");
            switch (firstDice)
            {
                case 1:
                    kub1.Image = Properties.Resources._1; break;
                case 2:
                    kub1.Image = Properties.Resources._2; break;
                case 3:
                    kub1.Image = Properties.Resources._3; break;
                case 4:
                    kub1.Image = Properties.Resources._4; break;
                case 5:
                    kub1.Image = Properties.Resources._5; break;
                case 6:
                    kub1.Image = Properties.Resources._6; break;
            }
            switch (secondDice)
            {
                case 1:
                    kub2.Image = Properties.Resources._1; break;
                case 2:
                    kub2.Image = Properties.Resources._2; break;
                case 3:
                    kub2.Image = Properties.Resources._3; break;
                case 4:
                    kub2.Image = Properties.Resources._4; break;
                case 5:
                    kub2.Image = Properties.Resources._5; break;
                case 6:
                    kub2.Image = Properties.Resources._6; break;
            }
            MovePlayers(diceResult);
            UpdateMoney();
        }


        public class Player
        {
            public string Name { get; set; }
            public Color Color { get; set; }
            public double Money { get; set; }
            public int CurrentPosition { get; set; }
            public Player(string name, Color color, double money, int currentPosition)
            {
                Name = name;
                Color = color;
                Money = money;
                CurrentPosition = currentPosition;

            }
        }

    }
}
