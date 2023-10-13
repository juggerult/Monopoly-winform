using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Monopoly.Main.UkrainianBoard;

namespace Monopoly.Main
{
    public partial class UkrainianBoard : Form
    {
        private int currentPlayerIndex = 0;
        private Player[] players;
        private Business[] businesses;
        private Board board;
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

            board = new Board();

            InitializePlayers();
            InitializeComponent();
            UpdateMoney();
            UpdateChat();
            if (player == 4)
            {
                nameLabel4.Text = players[3].Name.ToString();
                moneyLabel4.Text = players[3].Money.ToString();
                greenBishopStep1.Visible = true;
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
                        color = Color.FromArgb(240, 110, 110); break;
                    case 1:
                        name = secondPlayer;
                        color = Color.FromArgb(82, 100, 242); break;
                    case 2:
                        name = thirdPlayer;
                        color = Color.FromArgb(236, 244, 108); break;
                    case 3:
                        name = fourthPlayer;
                        color = Color.FromArgb(130, 255, 127); break;

                }
                players[i] = new Player(name, color, 1500000000, 0);
            }
        }
        public class Board
        {
            private Business[] businesses;

            public Board()
            {
                InitializeBusinesses();
            }

            private void InitializeBusinesses()
            {
                businesses = new Business[40];
                // Здесь инициализируйте все бизнесы на игровой доске
                businesses[1] = new Business("Staff", 60000000, 2000000, "Active", new double[] { 2000000, 10000000, 30000000, 90000000, 160000000, 250000000 }, 50000000, 30000000, 0);
                businesses[3] = new Business("VOVK", 85000000, 4000000, "Active", new double[] { 4000000, 20000000, 60000000, 90000000, 180000000, 450000000 }, 50000000, 42500000, 0);
                businesses[5] = new Business("ЧАЗ", 20000000, 40000000, "Passive", new double[] { 40000000, 80000000, 160000000, 200000000 }, 0, 100000000, 0);
                businesses[6] = new Business("АТБ", 100000000, 6000000, "Active", new double[] { 6000000, 30000000, 90000000, 270000000, 400000000, 550000000 }, 60000000, 50000000, 0);
                businesses[7] = new Business("Варус", 110000000, 6000000, "Active", new double[] { 6000000, 35000000, 100000000, 280000000, 410000000, 570000000 }, 60000000, 60000000, 0);
                businesses[9] = new Business("Сiльпо", 120000000, 8000000, "Active", new double[] { 8000000, 40000000, 100000000, 300000000, 450000000, 60000000 }, 60000000, 60000000, 0);
                businesses[11] = new Business("Roshen", 150000000, 10000000, "Active", new double[] { 1000000, 50000000, 150000000, 450000000, 625000000, 75000000 }, 75000000, 75000000, 0);
                businesses[13] = new Business("Lucas", 150000000, 10000000, "Active", new double[] { 1000000, 50000000, 150000000, 450000000, 625000000, 75000000 }, 75000000, 75000000, 0);
                businesses[14] = new Business("АВК", 160000000, 12000000, "Active", new double[] { 12000000, 60000000, 180000000, 500000000, 700000000, 90000000 }, 75000000, 80000000, 0);
                businesses[15] = new Business("Богдан", 20000000, 40000000, "Passive", new double[] { 40000000, 80000000, 160000000, 200000000 }, 0, 100000000, 0);
                businesses[16] = new Business("Челентано", 180000000, 14000000, "Active", new double[] { 14000000, 70000000, 200000000, 550000000, 750000000, 95000000 }, 100000000, 90000000, 0);
                businesses[17] = new Business("МсФокси", 180000000, 14000000, "Active", new double[] { 14000000, 70000000, 200000000, 550000000, 750000000, 95000000 }, 100000000, 90000000, 0);
                businesses[18] = new Business("4A Games", 200000000, 10000000, "UltraPassive", new double[] { 10000000, 25000000 }, 0, 100000000, 0);
                businesses[19] = new Business("ПузатаХата", 200000000, 16000000, "Active", new double[] { 16000000, 80000000, 220000000, 600000000, 800000000, 100000000 }, 100000000, 100000000, 0);
                businesses[21] = new Business("Vodafone", 220000000, 18000000, "Active", new double[] { 18000000, 90000000, 250000000, 700000000, 875000000, 1050000000 }, 125000000, 110000000, 0);
                businesses[23] = new Business("Lifecell", 220000000, 18000000, "Active", new double[] { 18000000, 90000000, 250000000, 700000000, 875000000, 1050000000 }, 125000000, 110000000, 0);
                businesses[24] = new Business("Kiyvstart", 240000000, 20000000, "Active", new double[] { 20000000, 100000000, 300000000, 750000000, 925000000, 1100000000 }, 125000000, 120000000, 0);
                businesses[25] = new Business("ЗАЗ", 20000000, 40000000, "Passive", new double[] { 40000000, 80000000, 160000000, 200000000 }, 0, 100000000, 0);
                businesses[26] = new Business("Hotel LVIV", 260000000, 22000000, "Active", new double[] { 22000000, 110000000, 330000000, 800000000, 975000000, 1150000000 }, 150000000, 130000000, 0);
                businesses[27] = new Business("Ibis", 260000000, 22000000, "Active", new double[] { 22000000, 110000000, 330000000, 800000000, 975000000, 1150000000 }, 150000000, 130000000, 0);
                businesses[29] = new Business("Senator", 280000000, 24000000, "Active", new double[] { 24000000, 120000000, 360000000, 850000000, 1025000000, 1200000000 }, 150000000, 140000000, 0);
                businesses[31] = new Business("SkyUp", 300000000, 26000000, "Active", new double[] { 26000000, 130000000, 390000000, 900000000, 1100000000, 1275000000 }, 175000000, 150000000, 0);
                businesses[33] = new Business("UIA", 300000000, 26000000, "Active", new double[] { 26000000, 130000000, 390000000, 900000000, 1100000000, 1275000000 }, 175000000, 150000000, 0);
                businesses[34] = new Business("WindRise", 320000000, 28000000, "Active", new double[] { 28000000, 150000000, 450000000, 1000000000, 1200000000, 1400000000 }, 175000000, 160000000, 0);
                businesses[35] = new Business("КРАЗ", 20000000, 40000000, "Passive", new double[] { 40000000, 80000000, 160000000, 200000000 }, 0, 100000000, 0);
                businesses[37] = new Business("МоноБанк", 350000000, 35000000, "Active", new double[] { 35000000, 175000000, 500000000, 1100000000, 1300000000, 1500000000 }, 200000000, 175000000, 0);
                businesses[38] = new Business("GSC", 200000000, 10000000, "UltraPassive", new double[] { 10000000, 25000000 }, 0, 100000000, 0);
                businesses[39] = new Business("ПриватБанк", 400000000, 50000000, "Active", new double[] { 50000000, 200000000, 600000000, 1400000000, 1700000000, 2000000000 }, 200000000, 200000000, 0);

            }

            public Business GetBusiness(int position)
            {
                return businesses[position];
            }
        }

        private void UpdateChat()
        {
            chat.Items.Add($"Ход игрока: {players[currentPlayerIndex].Name} Его позиция: {players[currentPlayerIndex].CurrentPosition}");
        }
        private void UpdateMoney()
        {
            moneyLabel1.Text = players[0].Money.ToString();
            moneyLabel2.Text = players[1].Money.ToString();
            moneyLabel3.Text = players[2].Money.ToString();

            nameLabel1.Text = players[0].Name.ToString();
            nameLabel2.Text = players[1].Name.ToString();
            nameLabel3.Text = players[2].Name.ToString();

            if (numberOfPlayers == 4)
            {
                nameLabel4.Text = players[3].Name.ToString();
                moneyLabel4.Text = players[3].Money.ToString();
            }
        }

        private int animationStep = 0;
        private int countOfDouble = 0;
        private void MovePlayers(int steps)
        {
            animationStep = steps;
            RollDiceButton.Visible = false;
            timer1.Start();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            PictureBox[,] bishopImages = new PictureBox[4, 40];

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
            bishopImages[0, 34] = redBishopStep35;
            bishopImages[0, 35] = redBishopStep36;
            bishopImages[0, 36] = redBishopStep37;
            bishopImages[0, 37] = redBishopStep38;
            bishopImages[0, 38] = redBishopStep39;
            bishopImages[0, 39] = redBishopStep40;

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
            bishopImages[1, 34] = blueBishopStep35;
            bishopImages[1, 35] = blueBishopStep36;
            bishopImages[1, 36] = blueBishopStep37;
            bishopImages[1, 37] = blueBishopStep38;
            bishopImages[1, 38] = blueBishopStep39;
            bishopImages[1, 39] = blueBishopStep40;

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
            bishopImages[2, 34] = yellowBishopStep35;
            bishopImages[2, 35] = yellowBishopStep36;
            bishopImages[2, 36] = yellowBishopStep37;
            bishopImages[2, 37] = yellowBishopStep38;
            bishopImages[2, 38] = yellowBishopStep39;
            bishopImages[2, 39] = yellowBishopStep40;

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
            bishopImages[3, 34] = greenBishopStep35;
            bishopImages[3, 35] = greenBishopStep36;
            bishopImages[3, 36] = greenBishopStep37;
            bishopImages[3, 37] = greenBishopStep38;
            bishopImages[3, 38] = greenBishopStep39;
            bishopImages[3, 39] = greenBishopStep40;

            if (players[currentPlayerIndex].CurrentPosition >= 40)
            {
                players[currentPlayerIndex].Money += 1000;
                players[currentPlayerIndex].CurrentPosition = players[currentPlayerIndex].CurrentPosition - 40;
                UpdateMoney();
            }

            PictureBox image = bishopImages[currentPlayerIndex, players[currentPlayerIndex].CurrentPosition % 40];
            PictureBox image2 = bishopImages[currentPlayerIndex, (players[currentPlayerIndex].CurrentPosition + 1) % 40];
            image.Visible = false;
            image2.Visible = true;
            players[currentPlayerIndex].CurrentPosition++;
            animationStep--;

            if (animationStep < 1)
            {
                RollDiceButton.Visible = true;
                timer1.Stop();
                if (CheckJail())
                {
                    image2.Visible = false;
                    image2 = bishopImages[currentPlayerIndex, 10];
                    image2.Visible = true;
                    players[currentPlayerIndex].IsDouble = false;
                    currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                    UpdateChat();
                    return;
                }
                if (players[currentPlayerIndex].CurrentPosition == 2 || players[currentPlayerIndex].CurrentPosition == 32)
                {
                    Teleportation();
                    return;
                }

                BusinessActivity();

                await Task.Run(async () =>
                {
                    while (timer3.Enabled)
                    {
                        await Task.Delay(1000);
                    }
                });
                if (players[currentPlayerIndex].IsDouble)
                {
                    countOfDouble++;
                    if (countOfDouble == 3)
                    {
                        players[currentPlayerIndex].IsJail = true;
                        players[currentPlayerIndex].CurrentPosition = 10;
                        image2.Visible = false;
                        image2 = bishopImages[currentPlayerIndex, 10];
                        image2.Visible = true;
                        chat.Items.Add($"Гравець {players[currentPlayerIndex].Name} вирушаєте до в'язницi за випадiння трьох дублiв вряд");
                        countOfDouble = 0;
                        currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                        return;
                    }
                    chat.Items.Add($"Гравцю{players[currentPlayerIndex].Name} випав дубль, i тому вiн может зробити ще один хiд");
                    players[currentPlayerIndex].IsDouble = false;
                    RollDiceButton_Click(sender, e);
                    return;
                }
                currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                UpdateChat();
                countOfDouble = 0; ;
                return;
            }
        }
        private double moneyRent = 0;
        public async void BusinessActivity()
        {
            int currentPosition = players[currentPlayerIndex].CurrentPosition;
            if (currentPosition == 4 || currentPosition == 28)
            {
                moneyRent = 100000000;
                payButton.Visible = true;
                button2.Visible = true;
                RollDiceButton.Visible = false;
                timer3.Start();
                return;
            }
            else if (currentPosition == 12 || currentPosition == 8 || currentPosition == 22 || currentPosition == 36) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\\
            {
                players[currentPlayerIndex].Money += 200000000;
                chat.Items.Add("НАБУ видав премiю за сдачу корупцiонера");
                return;
            }

            if (currentPosition == 10 || currentPosition == 20) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\\\
            {
                return;
            }

            Business currentBusiness = board.GetBusiness(currentPosition);
            moneyRent = currentBusiness.Rent;

            if (currentBusiness.Owner == null)
            {
                DialogResult result = MessageBox.Show($"Хотите купить {currentBusiness.Name} за {currentBusiness.PurchasePrice}?", "Покупка бизнеса", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Покупка бизнеса
                    if (players[currentPlayerIndex].Money >= currentBusiness.PurchasePrice)
                    {
                        players[currentPlayerIndex].Money -= currentBusiness.PurchasePrice;
                        currentBusiness.Owner = players[currentPlayerIndex];
                        UpdateMoney();
                        MessageBox.Show($"Вы купили {currentBusiness.Name}");
                    }
                    else
                    {
                        MessageBox.Show("У вас недостаточно денег для покупки этого бизнеса.");
                    }
                }
            }
            else if (currentBusiness.Owner != players[currentPlayerIndex])
            {
                // Этот бизнес принадлежит другому игроку, соберите аренду
                chat.Items.Add($"Вы стали на бизнес {currentBusiness.Owner.Name}, и вам нужно заплатить {currentBusiness.Rent}");
                currentBusiness.Owner.Money += moneyRent;
                payButton.Visible = true;
                button2.Visible = true;
                RollDiceButton.Visible = false;
                timer3.Start();


            }

        }

        public void Teleportation()
        {
            int stepMove = random.Next(1, 6);
            chat.Items.Add($"Игрок {players[currentPlayerIndex].Name} попал на поле путешествие, и он передвигается на {stepMove} шагов вперед");
            MovePlayers(stepMove);
            return;
        }

        public bool CheckJail()
        {
            if (players[currentPlayerIndex].CurrentPosition == 30)
            {
                players[currentPlayerIndex].IsJail = true;
                players[currentPlayerIndex].CurrentPosition = 10;

                int randomJailReason = random.Next(1, 4);
                string jailReason = string.Empty;
                if (randomJailReason == 1)
                {
                    jailReason = "за крадіжку державного майна";
                }
                else if (randomJailReason == 2)
                {
                    jailReason = " статтею №190.4";
                }
                else if (randomJailReason == 3)
                {
                    jailReason = "за проїзд на червоне світло свiтлофора";
                }
                else if (randomJailReason == 4)
                {
                    jailReason = "за те, що ви дуже багаті";
                }

                chat.Items.Add($"Гравець {players[currentPlayerIndex].Name} вирушаєте до в'язницi за {jailReason}");
                return true;

            }
            return false;
        }




        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            int firstDice = random.Next(1, 6);
            int secondDice = random.Next(1, 6);
            int diceResult = firstDice + secondDice;
            if (firstDice == secondDice)
            {
                players[currentPlayerIndex].IsDouble = true;
            }
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

            if (players[currentPlayerIndex].IsJail)
            {
                if (firstDice == secondDice)
                {
                    players[currentPlayerIndex].IsJail = false;
                    MessageBox.Show("Ви знаходились у тюрмi, але випал дубль, i тому вы покинули тюрму");
                    players[currentPlayerIndex].IsDouble = false;
                    goto dalshe;
                }
                DialogResult jailResult = MessageBox.Show("Ви знаходитеся у тюрмi, ви можете вийти за 5000 або сидiти далi поки не випаде дубль", "Будете платити?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (jailResult == DialogResult.Yes)
                {
                    players[currentPlayerIndex].IsJail = false;
                    players[currentPlayerIndex].Money = players[currentPlayerIndex].Money - 5000;
                }
                else
                {
                    currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                    UpdateChat();
                    return;
                }
            }
        dalshe:
            MovePlayers(diceResult);
            UpdateMoney();
        }


        public class Player
        {
            public string Name { get; set; }
            public Color Color { get; set; }
            public double Money { get; set; }
            public int CurrentPosition { get; set; }
            public bool IsDouble { get; set; }
            public bool IsJail { get; set; }
            public bool IsActive { get; set; }
            public Player(string name, Color color, double money, int currentPosition)
            {
                Name = name;
                Color = color;
                Money = money;
                CurrentPosition = currentPosition;
                IsDouble = false;
                IsJail = false;
                IsActive = true;

            }
        }
        public class Business
        {
            public string Name { get; set; }
            public double PurchasePrice { get; set; }
            public double Rent { get; set; }
            public Player Owner { get; set; }
            public string Type { get; set; }
            public double[] Levels { get; set; }
            public double UpgradePrice { get; set; }
            public double SellPrice { get; set; }

            public int CurrentLevel { get; set; }
            public Business(string name, double purchasePrice, double rent, string type, double[] levels, double upgradePrice, double sellPrice, int currentLevel)
            {
                Name = name;
                PurchasePrice = purchasePrice;
                Rent = rent;
                Owner = null;
                Type = type;
                Levels = levels;
                UpgradePrice = upgradePrice;
                SellPrice = sellPrice;
                CurrentLevel = currentLevel;
                CurrentLevel = currentLevel;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateMoney();
            if (board.GetBusiness(1).Owner != null)
            {
                label1.Text = board.GetBusiness(1).Rent.ToString();
                panelStep2.BackColor = board.GetBusiness(1).Owner.Color;
            }
            if (board.GetBusiness(3).Owner != null)
            {
                label2.Text = board.GetBusiness(3).Rent.ToString();
                panelStep4.BackColor = board.GetBusiness(3).Owner.Color;
            }
            if (board.GetBusiness(5).Owner != null)
            {
                label3.Text = board.GetBusiness(5).Rent.ToString();
                panelStep6.BackColor = board.GetBusiness(5).Owner.Color;
            }
            if (board.GetBusiness(6).Owner != null)
            {
                label4.Text = board.GetBusiness(6).Rent.ToString();
                panelStep7.BackColor = board.GetBusiness(6).Owner.Color;
            }
            if (board.GetBusiness(7).Owner != null)
            {
                label5.Text = board.GetBusiness(7).Rent.ToString();
                panelStep8.BackColor = board.GetBusiness(7).Owner.Color;
            }
            if (board.GetBusiness(9).Owner != null)
            {
                label6.Text = board.GetBusiness(9).Rent.ToString();
                panelStep10.BackColor = board.GetBusiness(9).Owner.Color;
            }

            if (board.GetBusiness(11).Owner != null)
            {
                label7.Text = board.GetBusiness(11).Rent.ToString();
                panelStep12.BackColor = board.GetBusiness(11).Owner.Color;
            }
            if (board.GetBusiness(13).Owner != null)
            {
                label8.Text = board.GetBusiness(13).Rent.ToString();
                panelStep14.BackColor = board.GetBusiness(13).Owner.Color;
            }
            if (board.GetBusiness(14).Owner != null)
            {
                label9.Text = board.GetBusiness(14).Rent.ToString();
                panelStep15.BackColor = board.GetBusiness(14).Owner.Color;
            }
            if (board.GetBusiness(15).Owner != null)
            {
                label10.Text = board.GetBusiness(15).Rent.ToString();
                panelStep16.BackColor = board.GetBusiness(15).Owner.Color;
            }
            if (board.GetBusiness(16).Owner != null)
            {
                label11.Text = board.GetBusiness(16).Rent.ToString();
                panelStep17.BackColor = board.GetBusiness(16).Owner.Color;
            }
            if (board.GetBusiness(17).Owner != null)
            {
                label12.Text = board.GetBusiness(17).Rent.ToString();
                panelStep18.BackColor = board.GetBusiness(17).Owner.Color;
            }
            if (board.GetBusiness(18).Owner != null)
            {
                label13.Text = board.GetBusiness(18).Rent.ToString();
                panelStep19.BackColor = board.GetBusiness(18).Owner.Color;
            }
            if (board.GetBusiness(19).Owner != null)
            {
                label14.Text = board.GetBusiness(19).Rent.ToString();
                panelStep20.BackColor = board.GetBusiness(19).Owner.Color;
            }
            if (board.GetBusiness(21).Owner != null)
            {
                label15.Text = board.GetBusiness(21).Rent.ToString();
                panelStep22.BackColor = board.GetBusiness(21).Owner.Color;
            }
            if (board.GetBusiness(23).Owner != null)
            {
                label16.Text = board.GetBusiness(23).Rent.ToString();
                panelStep24.BackColor = board.GetBusiness(23).Owner.Color;
            }
            if (board.GetBusiness(24).Owner != null)
            {
                label17.Text = board.GetBusiness(24).Rent.ToString();
                panelStep25.BackColor = board.GetBusiness(24).Owner.Color;
            }
            if (board.GetBusiness(25).Owner != null)
            {
                label18.Text = board.GetBusiness(25).Rent.ToString();
                panelStep26.BackColor = board.GetBusiness(25).Owner.Color;
            }
            if (board.GetBusiness(26).Owner != null)
            {
                label19.Text = board.GetBusiness(26).Rent.ToString();
                panelStep27.BackColor = board.GetBusiness(26).Owner.Color;
            }
            if (board.GetBusiness(27).Owner != null)
            {
                label20.Text = board.GetBusiness(27).Rent.ToString();
                panelStep28.BackColor = board.GetBusiness(27).Owner.Color;
            }
            if (board.GetBusiness(29).Owner != null)
            {
                label21.Text = board.GetBusiness(29).Rent.ToString();
                panelStep30.BackColor = board.GetBusiness(29).Owner.Color;
            }
            if (board.GetBusiness(31).Owner != null)
            {
                label22.Text = board.GetBusiness(31).Rent.ToString();
                panelStep32.BackColor = board.GetBusiness(31).Owner.Color;
            }
            if (board.GetBusiness(33).Owner != null)
            {
                label23.Text = board.GetBusiness(33).Rent.ToString();
                panelStep34.BackColor = board.GetBusiness(33).Owner.Color;
            }
            if (board.GetBusiness(34).Owner != null)
            {
                label24.Text = board.GetBusiness(34).Rent.ToString();
                panelStep35.BackColor = board.GetBusiness(34).Owner.Color;
            }
            if (board.GetBusiness(35).Owner != null)
            {
                label25.Text = board.GetBusiness(35).Rent.ToString();
                panelStep36.BackColor = board.GetBusiness(35).Owner.Color;
            }
            if (board.GetBusiness(37).Owner != null)
            {
                label26.Text = board.GetBusiness(37).Rent.ToString();
                panelStep38.BackColor = board.GetBusiness(37).Owner.Color;
            }
            if (board.GetBusiness(38).Owner != null)
            {
                label27.Text = board.GetBusiness(38).Rent.ToString();
                panelStep39.BackColor = board.GetBusiness(38).Owner.Color;
            }
            if (board.GetBusiness(39).Owner != null)
            {
                label28.Text = board.GetBusiness(39).Rent.ToString();
                panelStep40.BackColor = board.GetBusiness(39).Owner.Color;
            }
        }
        private void payButton_Click(object sender, EventArgs e)
        {
            players[currentPlayerIndex].Money = players[currentPlayerIndex].Money - moneyRent;
            payButton.Visible = false; // Скрыть кнопку после оплаты аренды
            button2.Visible = false; // Скрыть вторую кнопку
            RollDiceButton.Visible = true; // Показать кнопку для броска костей

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (RollDiceButton.Visible == true)
            {
                timer3.Stop();
            }
        }
    }
}
