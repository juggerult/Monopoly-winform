﻿using Monopoly.Boards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
    public partial class AmericanBoard : Form
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
        public AmericanBoard(int player, string firstName, string secondName, string thirdName, string fourthName)
        {
            InitializeComponent();
            numberOfPlayers = player;
            firstPlayer = firstName;
            secondPlayer = secondName;
            thirdPlayer = thirdName;
            fourthPlayer = fourthName;

            board = new Board();

            InitializePlayers();
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
            timer2.Start();


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
                players[i] = new Player(name, color, 15000, 0);
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
                businesses[1] = new Business("H&M", 600, 20, "Одяг", new double[] { 20, 100, 300, 900, 1600, 2500 }, 500, 300, 0);
                businesses[3] = new Business("Louis Vuitton", 850, 40, "Одяг", new double[] { 40, 200, 600, 1800, 3200, 4500 }, 500, 425, 0);
                businesses[5] = new Business("BMW", 2000, 400, "Автосалон", new double[] { 400, 800, 1600, 2000 }, 0, 1000, 0);
                businesses[6] = new Business("Puma", 1000, 60, "Спортивний магазин", new double[] { 60, 300, 900, 2700, 4000, 5500 }, 600, 500, 0);
                businesses[7] = new Business("Adidas", 1100, 60, "Спортивний магазин", new double[] { 60, 300, 1000, 2800, 4100, 5700 }, 600, 600, 0);
                businesses[9] = new Business("Nike", 1200, 80, "Спортивний магазин", new double[] { 80, 400, 1000, 3000, 4500, 6000 }, 600, 600, 0);
                businesses[11] = new Business("Coca-Cola", 1500, 100, "Напої", new double[] { 100, 500, 1500, 4500, 6250, 7500 }, 750, 750, 0);
                businesses[13] = new Business("Pepsi", 1500, 100, "Напої", new double[] { 100, 500, 1500, 4500, 6250, 7500 }, 750, 750, 0);
                businesses[14] = new Business("Red Bull", 1600, 120, "Напої", new double[] { 120, 600, 1800, 5000, 7000, 9000 }, 750, 800, 0);
                businesses[15] = new Business("Volkswagen", 2000, 400, "Автосалоны", new double[] { 400, 800, 1600, 2000 }, 0, 1000, 0);
                businesses[16] = new Business("Spotify", 1800, 140, "Музика", new double[] { 140, 700, 2000, 5500, 7500, 9500 }, 1000, 900, 0);
                businesses[17] = new Business("Soundcloud", 1800, 140, "Музика", new double[] { 140, 700, 2000, 5500, 7500, 9500 }, 1000, 900, 0);
                businesses[18] = new Business("EA Games", 1750, 100, "Ігри", new double[] { 100, 250 }, 0, 1000, 0);
                businesses[19] = new Business("Shazam", 2000, 160, "Музика", new double[] { 160, 800, 2200, 6000, 8000, 10000 }, 1000, 1000, 0);
                businesses[21] = new Business("McDonalds", 2200, 180, "Ресторани", new double[] { 180, 900, 2500, 7000, 8750, 10000 }, 12000, 11000, 0);
                businesses[23] = new Business("KFC", 2200, 180, "Ресторани", new double[] { 180, 900, 2500, 7000, 8700, 10000 }, 12500, 11000, 0);
                businesses[24] = new Business("Burger KING", 2400, 200, "Ресторани", new double[] { 200, 1000, 3000, 7500, 9250, 11000 }, 1250, 1200, 0);
                businesses[25] = new Business("Tesla", 2000, 400, "Автосалон", new double[] { 400, 800, 1600, 2000 }, 0, 1000, 0);
                businesses[26] = new Business("American Airlines", 2600, 220, "Авіалінії", new double[] { 220, 1100, 3300, 8000, 9750, 11500 }, 1500, 1300, 0);
                businesses[27] = new Business("Etihad AIRWAYS", 2600, 220, "Авіалінії", new double[] { 220, 1100, 3300, 8000, 9750, 11500 }, 1500, 1300, 0);
                businesses[29] = new Business("Qatar Airlines", 2800, 240, "Авіалінії", new double[] { 240, 1200, 3600, 8500, 10250, 12000 }, 1500, 1400, 0);
                businesses[31] = new Business("Netflix", 3000, 260, "Кiно-компанії", new double[] { 260, 1300, 3900, 9000, 11000, 12750 }, 1750, 1500, 0);
                businesses[33] = new Business("Universal Pictures", 3000, 260, "Кiно-компанії", new double[] { 260, 1300, 3900, 9000, 11000, 12750 }, 1750, 1500, 0);
                businesses[34] = new Business("Warner Bros", 3200, 280, "Кiно-компанії", new double[] { 280, 1500, 4500, 10000, 12000, 14000 }, 1750, 1600, 0);
                businesses[35] = new Business("Mercedes-Benz", 2000, 400, "Автосалон", new double[] { 400, 800, 1600, 2000 }, 0, 1000, 0);
                businesses[37] = new Business("Samsung", 3500, 350, "IT-компанії", new double[] { 350, 1750, 5000, 11000, 13000, 15000 }, 2000, 1750, 0);
                businesses[38] = new Business("Ubisoft", 1750, 100, "Ігри", new double[] { 100, 250 }, 0, 1000, 0);
                businesses[39] = new Business("Apple", 4000, 500, "IT-компанії", new double[] { 500, 2000, 6000, 14000, 17000, 20000 }, 2000, 2000, 0);
            }

            public Business GetBusiness(int position)
            {
                return businesses[position];
            }
        }

        private void UpdateChat()
        {
        again:
            if (players[currentPlayerIndex].IsActive)
            {
                chat.Items.Add($"Хід гравця: {players[currentPlayerIndex].Name}");
            }
            else
            {
                currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                goto again;
            }
            RollDiceButton.Visible = true;
        }
        public void UpdateMoney()
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
        private int countOfStep = 0;
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


            PictureBox image = bishopImages[currentPlayerIndex, players[currentPlayerIndex].CurrentPosition % 40];
            PictureBox image2 = bishopImages[currentPlayerIndex, (players[currentPlayerIndex].CurrentPosition + 1) % 40];
            image.Visible = false;
            image2.Visible = true;
            players[currentPlayerIndex].CurrentPosition++;
            animationStep--;

            if (players[currentPlayerIndex].CurrentPosition == 40)
            {
                players[currentPlayerIndex].Money += 2000;
                players[currentPlayerIndex].CurrentPosition = players[currentPlayerIndex].CurrentPosition - 40;
                UpdateMoney();
            }
            countOfStep++;

            if (animationStep < 1)
            {
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

                BusinessActivity(countOfStep);

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
                        UpdateChat();
                        return;
                    }
                    chat.Items.Add($"Гравцю {players[currentPlayerIndex].Name} випав дубль, i тому вiн может зробити ще один хiд");
                    players[currentPlayerIndex].IsDouble = false;
                    RollDiceButton.Visible = true;
                    return;
                }
                currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
                UpdateChat();
                countOfDouble = 0;
                countOfStep = 0;
                return;
            }
        }
        private double moneyRent = 0;
        public static double Money { get; set; } = 0;
        public async void BusinessActivity(int coutLastSteps)
        {
            int currentPosition = players[currentPlayerIndex].CurrentPosition;
            if (currentPosition == 4 || currentPosition == 28)
            {
                moneyRent = 100;
                payButton.Visible = true;
                button2.Visible = true;
                RollDiceButton.Visible = false;
                timer3.Start();
                return;
            }
            else if (currentPosition == 12)
            {
                players[currentPlayerIndex].Money += 2000;
                chat.Items.Add("За видатний внесок у глобальні інновації, ви отримуєте відзнаку та премію від Міжнародного Союзу Інноваторів. Нові горизонти та успіхи чекають на вас!");
                return;
            }
            if (currentPosition == 8 || currentPosition == 22 || currentPosition == 36)
            {
                int randomPrize = random.Next(1, 18);
                Prize(randomPrize);
                return;

            }

            if (currentPosition == 10 || currentPosition == 0) //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\\\
            {
                return;
            }
            if (currentPosition == 20)
            {
                DialogResult result = MessageBox.Show($"Ви стали на поле бiржi, чи будете грати? ", "Запрошення до бiржi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Money = players[currentPlayerIndex].Money;
                    AmericanCasino americanCasino = new AmericanCasino(Money);
                    americanCasino.ShowDialog();
                    players[currentPlayerIndex].Money = Money;
                    return;
                }
                else
                {
                    chat.Items.Add($"Гравець {players[currentPlayerIndex].Name} відмовився грати на бiржi");
                    return;
                }
            }


            Business currentBusiness = board.GetBusiness(currentPosition);
            moneyRent = currentBusiness.Rent;

            if (currentBusiness.Owner == null)
            {
                DialogResult result = MessageBox.Show($"Хочете купити {currentBusiness.Name} за {currentBusiness.PurchasePrice}?", "Купівля бізнесу", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Покупка бизнеса
                    if (players[currentPlayerIndex].Money >= currentBusiness.PurchasePrice)
                    {
                        players[currentPlayerIndex].Money -= currentBusiness.PurchasePrice;
                        currentBusiness.Owner = players[currentPlayerIndex];
                        players[currentPlayerIndex].OwnedBusinesses.Add(currentBusiness);
                        UpdateMoney();
                        MessageBox.Show($"Ви купили {currentBusiness.Name}");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("У вас недостатньо грошей для купівлі цього бізнесу.");
                        return;
                    }
                }
            }
            else if (currentBusiness.Owner != players[currentPlayerIndex])
            {
                // Этот бизнес принадлежит другому игроку, соберите аренду
                if (currentPosition == 38 || currentPosition == 18)
                {
                    moneyRent = countOfStep * currentBusiness.Rent;
                }
                chat.Items.Add($"Ви стали на бізнес {currentBusiness.Owner.Name}, і вам потрібно заплатити {moneyRent}");
                currentBusiness.Owner.Money += moneyRent;
                payButton.Visible = true;
                button2.Visible = true;
                RollDiceButton.Visible = false;
                timer3.Start();


            }

        }
        public void Prize(int number)
        {
            switch (number)
            {
                case 1:
                    chat.Items.Add("Ви виграли конкурс і отримуєте приз від мiжнародного банку банку - отримайте 500");
                    players[currentPlayerIndex].Money += 500;
                    break;
                case 2:
                    chat.Items.Add("За високі стандарти справедливості та праворучності, ви отримуєте глобальну визнаність та премію. Цей приз передбачається Міжнародним Комітетом за Захист Справедливості - отримайте 1500 ");
                    players[currentPlayerIndex].Money += 1500;
                    break;
                case 3:
                    chat.Items.Add("У вас день народження, кожен гравець дарує вам по 1000");
                    players[currentPlayerIndex].Money += 1000 * numberOfPlayers - 1;
                    for (int i = 0; i < numberOfPlayers; i++)
                    {
                        if (i != currentPlayerIndex)
                        {
                            if (players[i].Money < 1000)
                            {
                                players[i].Money = 0;
                            }
                            else
                            {
                                players[i].Money -= 1000;
                            }
                        }

                    }
                    break;
                case 4:
                    chat.Items.Add("Ви виграли в лотереї - отримайте 2200 ");
                    players[currentPlayerIndex].Money += 2200;
                    break;
                case 5:
                    chat.Items.Add("Заплатіть банку податок на нерухомість - 709");
                    moneyRent = 700;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 6:
                    chat.Items.Add("Ваш автомобіль пройшов міжнародний технічний огляд - заплатіть 1000 ");
                    moneyRent = 1000;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 7:
                    chat.Items.Add("Заплатіть штраф за перевищення швидкості - 500.");
                    moneyRent = 500;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 8:
                    chat.Items.Add("Ваше місце проживання потребує оновлення. Витратте 800 на  ремонт та модернізацію.");
                    moneyRent = 800;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 9:
                    chat.Items.Add("Ви знайшли коштовну антикварну річ - отримайте 750");
                    players[currentPlayerIndex].Money += 750;
                    break;
                case 10:
                    chat.Items.Add("Банк помилився в вашу користь. Отримайте 900.");
                    players[currentPlayerIndex].Money += 900;
                    break;
                case 11:
                    chat.Items.Add("Ви виграли право на впровадження міжнародного інноваційного вдосконалення. Оновіть будь-який свій готівковий гаманець на сучасні електронні технології та отримайте додатковий прибуток 1000 ");
                    players[currentPlayerIndex].Money += 1000;
                    break;
                case 12:
                    chat.Items.Add("Ви програли у казино. Платіть 1000  ");
                    moneyRent = 1000;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 13:
                    chat.Items.Add("Ви захворіли і повинні оплатити лікарняні. Заплатіть 750");
                    moneyRent = 750;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 14:
                    chat.Items.Add("Ви отримали штраф за паркування. Заплатіть 200 штрафу");
                    moneyRent = 200;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 15:
                    chat.Items.Add("Вам знадобилася юридична консультація. Заплатіть 500 за послуги юриста.");
                    moneyRent = 500;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 16:
                    chat.Items.Add("Ваше майно пошкоджено під час бунту на вулицях. Заплатіть 500 за ремонт");
                    moneyRent = 500;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 17:
                    chat.Items.Add("Ваші діти потребують дорогого навчання. Заплатіть 800 за їхню освіту.");
                    moneyRent = 800;
                    payButton.Visible = true;
                    button2.Visible = true;
                    RollDiceButton.Visible = false;
                    timer3.Start();
                    break;
                case 18:
                    chat.Items.Add("Ви зробили успішну інвестицію. Отримайте додаткові 500");
                    players[currentPlayerIndex].Money += 500;
                    break;
            }
            return;
        }
        public void Teleportation()
        {
            int stepMove = random.Next(1, 6);
            chat.Items.Add($"Гравець {players[currentPlayerIndex].Name} потрапив на поле подорож, і він пересувається на {stepMove} кроків вперед");
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
                    jailReason = "глобальне фінансове порушення";
                }
                else if (randomJailReason == 2)
                {
                    jailReason = "участь у глобальному інциденті безпеки";
                }
                else if (randomJailReason == 3)
                {
                    jailReason = "за проїзд на червоне світло свiтлофора";
                }
                else if (randomJailReason == 4)
                {
                    jailReason = "участь у міжнародному кіберзлочині";
                }

                chat.Items.Add($"Гравець {players[currentPlayerIndex].Name} вирушаєте до в'язницi за {jailReason}");
                return true;

            }
            return false;
        }




        private void RollDiceButton_Click(object sender, EventArgs e)
        {
            if (!players[currentPlayerIndex].IsActive)
            {
                currentPlayerIndex = (currentPlayerIndex + 1) % numberOfPlayers;
            }
            countOfUpgrade = 0;
            int firstDice = random.Next(1, 6);
            int secondDice = random.Next(1, 6);
            int diceResult = firstDice + secondDice;
            if (firstDice == secondDice)
            {
                players[currentPlayerIndex].IsDouble = true;
            }
            chat.Items.Add($"Випало: {diceResult}");
            switch (firstDice)
            {
                case 1:
                    kub1.Image = Properties.Resources.firstKUB; break;
                case 2:
                    kub1.Image = Properties.Resources.secondKub; break;
                case 3:
                    kub1.Image = Properties.Resources.thirdKub; break;
                case 4:
                    kub1.Image = Properties.Resources.fourthKub; break;
                case 5:
                    kub1.Image = Properties.Resources.fiveKub; break;
                case 6:
                    kub1.Image = Properties.Resources.sixKub; break;
            }
            switch (secondDice)
            {
                case 1:
                    kub2.Image = Properties.Resources.firstKUB; break;
                case 2:
                    kub2.Image = Properties.Resources.secondKub; break;
                case 3:
                    kub2.Image = Properties.Resources.thirdKub; break;
                case 4:
                    kub2.Image = Properties.Resources.fourthKub; break;
                case 5:
                    kub2.Image = Properties.Resources.fiveKub; break;
                case 6:
                    kub2.Image = Properties.Resources.sixKub; break;
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
                DialogResult jailResult = MessageBox.Show("Ви знаходитеся у тюрмi, ви можете вийти за 500 або сидiти далi поки не випаде дубль", "Будете платити?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (jailResult == DialogResult.Yes)
                {
                    players[currentPlayerIndex].IsJail = false;
                    players[currentPlayerIndex].Money = players[currentPlayerIndex].Money - 500;
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
        private void button2_Click(object sender, EventArgs e)
        {
            chat.Items.Add($"Гравець {players[currentPlayerIndex].Name} сдався");
            switch (currentPlayerIndex)
            {
                case 0:
                    panel1.Visible = false;
                    break;
                case 1:
                    panel2.Visible = false;
                    break;
                case 2:
                    panel3.Visible = false;
                    break;
                case 3:
                    panel4.Visible = false;
                    break;
            }
            players[currentPlayerIndex].IsActive = false;
            foreach (Business busines in players[currentPlayerIndex].OwnedBusinesses)
            {
                busines.Owner = null;
                busines.CurrentLevel = 0;
            }

            int surrenderedCount = 0;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (!players[i].IsActive)
                {
                    surrenderedCount++;
                    if (surrenderedCount == numberOfPlayers - 1)
                    {
                        for (int j = 0; j < numberOfPlayers; j++)
                        {
                            if (players[j].IsActive)
                            {
                                MessageBox.Show($"Гра закончилась. Победитель: {players[j].Name}, поздравляем!");
                                Thread.Sleep(3000);
                                Application.Exit();
                            }
                        }
                    }
                }
            }

            payButton.Visible = false;
            button2.Visible = false;
            RollDiceButton.Visible = true;
            return;
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
            public List<Business> OwnedBusinesses { get; set; }
            public Player(string name, Color color, double money, int currentPosition)
            {
                Name = name;
                Color = color;
                Money = money;
                CurrentPosition = currentPosition;
                IsDouble = false;
                IsJail = false;
                IsActive = true;
                OwnedBusinesses = new List<Business>();

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
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateMoney();
            if (((board.GetBusiness(18).Owner == board.GetBusiness(38).Owner) && (board.GetBusiness(38).Owner != null && board.GetBusiness(18).Owner != null) && (board.GetBusiness(38).CurrentLevel != 1 || board.GetBusiness(18).CurrentLevel != 1)))
            {
                board.GetBusiness(18).CurrentLevel++;
                board.GetBusiness(18).Rent = board.GetBusiness(18).Levels[board.GetBusiness(18).CurrentLevel];
                board.GetBusiness(38).CurrentLevel++;
                board.GetBusiness(38).Rent = board.GetBusiness(18).Levels[board.GetBusiness(38).CurrentLevel];
            }

            int countOfPassiveBusinesses = 0;
            for (int i = 5; i < 36; i += 10)
            {
                if ((board.GetBusiness(i).Owner != null) && (board.GetBusiness(i).Owner.Name == players[currentPlayerIndex].Name))
                {
                    countOfPassiveBusinesses++;
                }
            }

            foreach (int businessNumber in new int[] { 5, 15, 25, 35 })
            {
                Business business = board.GetBusiness(businessNumber);
                if (business.Owner != null && business.Owner.Name == players[currentPlayerIndex].Name)
                {
                    business.CurrentLevel = countOfPassiveBusinesses - 1;
                    business.Rent = business.Levels[business.CurrentLevel];
                }
            }

            for (int i = 0; i < numberOfPlayers; i++)
            {
                string playerName = players[i].Name;
                if (players[i].IsActive)
                {
                    bool playerExistsInComboBox = false;

                    foreach (object item in comboBox1.Items)
                    {
                        if (item.ToString() == playerName)
                        {
                            playerExistsInComboBox = true; break;
                        }
                    }

                    if (!playerExistsInComboBox)
                    {
                        comboBox1.Items.Add(playerName);
                    }
                }
                else
                {
                    for (int j = 0; j < comboBox1.Items.Count; j++)
                    {
                        if (comboBox1.Items[j].ToString() == playerName)
                        {
                            comboBox1.Items.RemoveAt(j); break;
                        }
                    }
                }
            }


            if (board.GetBusiness(1).Owner != null)
            {
                board.GetBusiness(1).Rent = board.GetBusiness(1).Levels[board.GetBusiness(1).CurrentLevel];
                label1.Text = board.GetBusiness(1).Rent.ToString();
                panelStep2.BackColor = board.GetBusiness(1).Owner.Color;
            }
            else
            {
                label1.Text = "600";
                panelStep2.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(3).Owner != null)
            {
                board.GetBusiness(3).Rent = board.GetBusiness(3).Levels[board.GetBusiness(3).CurrentLevel];
                label2.Text = board.GetBusiness(3).Rent.ToString();
                panelStep4.BackColor = board.GetBusiness(3).Owner.Color;
            }
            else
            {
                label2.Text = "850";
                panelStep4.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(5).Owner != null)
            {
                board.GetBusiness(5).Rent = board.GetBusiness(5).Levels[board.GetBusiness(5).CurrentLevel];
                label3.Text = board.GetBusiness(5).Rent.ToString();
                panelStep6.BackColor = board.GetBusiness(5).Owner.Color;
            }
            else
            {
                label3.Text = "2000";
                panelStep6.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(6).Owner != null)
            {
                board.GetBusiness(6).Rent = board.GetBusiness(6).Levels[board.GetBusiness(6).CurrentLevel];
                label4.Text = board.GetBusiness(6).Rent.ToString();
                panelStep7.BackColor = board.GetBusiness(6).Owner.Color;
            }
            else
            {
                label4.Text = "1000";
                panelStep7.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(7).Owner != null)
            {
                board.GetBusiness(7).Rent = board.GetBusiness(7).Levels[board.GetBusiness(7).CurrentLevel];
                label5.Text = board.GetBusiness(7).Rent.ToString();
                panelStep8.BackColor = board.GetBusiness(7).Owner.Color;
            }
            else
            {
                label5.Text = "1100";
                panelStep8.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(9).Owner != null)
            {
                board.GetBusiness(9).Rent = board.GetBusiness(9).Levels[board.GetBusiness(9).CurrentLevel];
                label6.Text = board.GetBusiness(9).Rent.ToString();
                panelStep10.BackColor = board.GetBusiness(9).Owner.Color;
            }
            else
            {
                label6.Text = "1200";
                panelStep10.BackColor = Color.LightGray;
            }

            if (board.GetBusiness(11).Owner != null)
            {
                board.GetBusiness(11).Rent = board.GetBusiness(11).Levels[board.GetBusiness(11).CurrentLevel];
                label7.Text = board.GetBusiness(11).Rent.ToString();
                panelStep12.BackColor = board.GetBusiness(11).Owner.Color;
            }
            else
            {
                label7.Text = "1500";
                panelStep12.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(13).Owner != null)
            {
                board.GetBusiness(13).Rent = board.GetBusiness(13).Levels[board.GetBusiness(13).CurrentLevel];
                label8.Text = board.GetBusiness(13).Rent.ToString();
                panelStep14.BackColor = board.GetBusiness(13).Owner.Color;
            }
            else
            {
                label8.Text = "1500";
                panelStep14.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(14).Owner != null)
            {
                board.GetBusiness(14).Rent = board.GetBusiness(14).Levels[board.GetBusiness(14).CurrentLevel];
                label9.Text = board.GetBusiness(14).Rent.ToString();
                panelStep15.BackColor = board.GetBusiness(14).Owner.Color;
            }
            else
            {
                label9.Text = "1600";
                panelStep15.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(15).Owner != null)
            {
                board.GetBusiness(15).Rent = board.GetBusiness(15).Levels[board.GetBusiness(15).CurrentLevel];
                label10.Text = board.GetBusiness(15).Rent.ToString();
                panelStep16.BackColor = board.GetBusiness(15).Owner.Color;
            }
            else
            {
                label10.Text = "2000";
                panelStep16.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(16).Owner != null)
            {
                board.GetBusiness(16).Rent = board.GetBusiness(16).Levels[board.GetBusiness(16).CurrentLevel];
                label11.Text = board.GetBusiness(16).Rent.ToString();
                panelStep17.BackColor = board.GetBusiness(16).Owner.Color;
            }
            else
            {
                label11.Text = "1800";
                panelStep17.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(17).Owner != null)
            {
                board.GetBusiness(17).Rent = board.GetBusiness(17).Levels[board.GetBusiness(17).CurrentLevel];
                label12.Text = board.GetBusiness(17).Rent.ToString();
                panelStep18.BackColor = board.GetBusiness(17).Owner.Color;
            }
            else
            {
                label12.Text = "1800";
                panelStep18.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(18).Owner != null)
            {
                board.GetBusiness(18).Rent = board.GetBusiness(18).Levels[board.GetBusiness(18).CurrentLevel];
                label13.Text = $"{board.GetBusiness(18).Rent.ToString()}X";
                panelStep19.BackColor = board.GetBusiness(18).Owner.Color;
            }
            else
            {
                label13.Text = "1750";
                panelStep19.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(19).Owner != null)
            {
                board.GetBusiness(19).Rent = board.GetBusiness(19).Levels[board.GetBusiness(19).CurrentLevel];
                label14.Text = board.GetBusiness(19).Rent.ToString();
                panelStep20.BackColor = board.GetBusiness(19).Owner.Color;
            }
            else
            {
                label14.Text = "2000";
                panelStep20.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(21).Owner != null)
            {
                board.GetBusiness(21).Rent = board.GetBusiness(21).Levels[board.GetBusiness(21).CurrentLevel];
                label15.Text = board.GetBusiness(21).Rent.ToString();
                panelStep22.BackColor = board.GetBusiness(21).Owner.Color;
            }
            else
            {
                label15.Text = "2200";
                panelStep22.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(23).Owner != null)
            {
                board.GetBusiness(23).Rent = board.GetBusiness(23).Levels[board.GetBusiness(23).CurrentLevel];
                label16.Text = board.GetBusiness(23).Rent.ToString();
                panelStep24.BackColor = board.GetBusiness(23).Owner.Color;
            }
            else
            {
                label16.Text = "2200";
                panelStep24.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(24).Owner != null)
            {
                board.GetBusiness(24).Rent = board.GetBusiness(24).Levels[board.GetBusiness(24).CurrentLevel];
                label17.Text = board.GetBusiness(24).Rent.ToString();
                panelStep25.BackColor = board.GetBusiness(24).Owner.Color;
            }
            else
            {
                label17.Text = "2400";
                panelStep25.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(25).Owner != null)
            {
                board.GetBusiness(25).Rent = board.GetBusiness(25).Levels[board.GetBusiness(25).CurrentLevel];
                label18.Text = board.GetBusiness(25).Rent.ToString();
                panelStep26.BackColor = board.GetBusiness(25).Owner.Color;
            }
            else
            {
                label18.Text = "2000";
                panelStep26.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(26).Owner != null)
            {
                board.GetBusiness(26).Rent = board.GetBusiness(26).Levels[board.GetBusiness(26).CurrentLevel];
                label19.Text = board.GetBusiness(26).Rent.ToString();
                panelStep27.BackColor = board.GetBusiness(26).Owner.Color;
            }
            else
            {
                label19.Text = "2600";
                panelStep27.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(27).Owner != null)
            {
                board.GetBusiness(27).Rent = board.GetBusiness(27).Levels[board.GetBusiness(27).CurrentLevel];
                label20.Text = board.GetBusiness(27).Rent.ToString();
                panelStep28.BackColor = board.GetBusiness(27).Owner.Color;
            }
            else
            {
                label20.Text = "2600";
                panelStep28.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(29).Owner != null)
            {
                board.GetBusiness(29).Rent = board.GetBusiness(29).Levels[board.GetBusiness(29).CurrentLevel];
                label21.Text = board.GetBusiness(29).Rent.ToString();
                panelStep30.BackColor = board.GetBusiness(29).Owner.Color;
            }
            else
            {
                label21.Text = "2800";
                panelStep30.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(31).Owner != null)
            {
                board.GetBusiness(31).Rent = board.GetBusiness(31).Levels[board.GetBusiness(31).CurrentLevel];
                label22.Text = board.GetBusiness(31).Rent.ToString();
                panelStep32.BackColor = board.GetBusiness(31).Owner.Color;
            }
            else
            {
                label22.Text = "3000";
                panelStep32.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(33).Owner != null)
            {
                board.GetBusiness(33).Rent = board.GetBusiness(33).Levels[board.GetBusiness(33).CurrentLevel];
                label23.Text = board.GetBusiness(33).Rent.ToString();
                panelStep34.BackColor = board.GetBusiness(33).Owner.Color;
            }
            else
            {
                label23.Text = "3000";
                panelStep34.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(34).Owner != null)
            {
                board.GetBusiness(34).Rent = board.GetBusiness(34).Levels[board.GetBusiness(34).CurrentLevel];
                label24.Text = board.GetBusiness(34).Rent.ToString();
                panelStep35.BackColor = board.GetBusiness(34).Owner.Color;
            }
            else
            {
                label24.Text = "3200";
                panelStep35.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(35).Owner != null)
            {
                board.GetBusiness(35).Rent = board.GetBusiness(35).Levels[board.GetBusiness(35).CurrentLevel];
                label25.Text = board.GetBusiness(35).Rent.ToString();
                panelStep36.BackColor = board.GetBusiness(35).Owner.Color;
            }
            else
            {
                label25.Text = "2000";
                panelStep36.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(37).Owner != null)
            {
                board.GetBusiness(37).Rent = board.GetBusiness(37).Levels[board.GetBusiness(37).CurrentLevel];
                label26.Text = board.GetBusiness(37).Rent.ToString();
                panelStep38.BackColor = board.GetBusiness(37).Owner.Color;
            }
            else
            {
                label26.Text = "3500";
                panelStep38.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(38).Owner != null)
            {
                board.GetBusiness(38).Rent = board.GetBusiness(38).Levels[board.GetBusiness(38).CurrentLevel];
                label27.Text = $"{board.GetBusiness(38).Rent.ToString()}X";
                panelStep39.BackColor = board.GetBusiness(38).Owner.Color;
            }
            else
            {
                label27.Text = "1750";
                panelStep39.BackColor = Color.LightGray;
            }
            if (board.GetBusiness(39).Owner != null)
            {
                board.GetBusiness(39).Rent = board.GetBusiness(39).Levels[board.GetBusiness(39).CurrentLevel];
                label28.Text = board.GetBusiness(39).Rent.ToString();
                panelStep40.BackColor = board.GetBusiness(39).Owner.Color;
            }
            else
            {
                label28.Text = "4000";
                panelStep40.BackColor = Color.LightGray;
            }
        }
        private void payButton_Click(object sender, EventArgs e)
        {
            if (players[currentPlayerIndex].Money > moneyRent)
            {
                players[currentPlayerIndex].Money = players[currentPlayerIndex].Money - moneyRent;
            }
            else
            {
                MessageBox.Show("У вас недостаточно денег");
                return;
            }
            payButton.Visible = false;
            button2.Visible = false;
            RollDiceButton.Visible = true;

        }

        int countOfUpgrade = 0;
        private void buttonUpgrade_Click(object sender, EventArgs e)
        {
            if (isFull == false)
            {
                MessageBox.Show("У вас не всi бiзнеси цього типу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (countOfUpgrade >= 2)
            {
                MessageBox.Show("Гравцi вже використали всi апгрейди на цьому крузi", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (CurrentBussines.CurrentLevel == CurrentBussines.Levels.Length - 1)
                {
                    MessageBox.Show("Бiзнес максимального рiвня", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (CurrentBussines.Owner.Money < CurrentBussines.UpgradePrice)
                    {
                        MessageBox.Show("У вас невистачає грошей для покращення цього бiзнесу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            countOfUpgrade++;
            CurrentBussines.CurrentLevel++;
            CurrentBussines.Owner.Money -= CurrentBussines.UpgradePrice;
        }
        private void buttonSell_Click(object sender, EventArgs e)
        {
            if (CurrentBussines.Owner == null)
            {
                MessageBox.Show("Цей бізнес не куплений, ви не можете його продати", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CurrentBussines.CurrentLevel == 0)
                {
                    CurrentBussines.Owner.Money += CurrentBussines.SellPrice;
                    CurrentBussines.Owner = null;
                }
                else
                {
                    CurrentBussines.Owner.Money += CurrentBussines.UpgradePrice;
                    CurrentBussines.CurrentLevel--;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (RollDiceButton.Visible == true)
            {
                timer3.Stop();
            }
        }










        bool isFull = false;
        Business CurrentBussines = null; /// Глобальная переменна для улучшения бизнесов.
                                         /// Метод в котором будет выводиться информация о карточках. А так же возможность прокачать филию если одним типом бизнесса владеет один и тот же человек
        private void panelStep2_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(1);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (board.GetBusiness(1).Owner == board.GetBusiness(3).Owner && board.GetBusiness(1).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(1).CurrentLevel = 0;
                board.GetBusiness(3).CurrentLevel = 0;
            }

            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";



        }

        private void panelStep4_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(3);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (board.GetBusiness(1).Owner == board.GetBusiness(3).Owner && board.GetBusiness(3).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }

            if (!isFull)
            {
                board.GetBusiness(1).CurrentLevel = 0;
                board.GetBusiness(3).CurrentLevel = 0;
            }

            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep7_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(6);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(6).Owner == board.GetBusiness(7).Owner) && (board.GetBusiness(7).Owner == board.GetBusiness(9).Owner)) && board.GetBusiness(6).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }

            if (!isFull)
            {
                board.GetBusiness(6).CurrentLevel = 0;
                board.GetBusiness(7).CurrentLevel = 0;
                board.GetBusiness(9).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep8_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(7);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(6).Owner == board.GetBusiness(7).Owner) && (board.GetBusiness(7).Owner == board.GetBusiness(9).Owner)) && board.GetBusiness(7).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(6).CurrentLevel = 0;
                board.GetBusiness(7).CurrentLevel = 0;
                board.GetBusiness(9).CurrentLevel = 0;
            }

            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep10_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(9);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(6).Owner == board.GetBusiness(7).Owner) && (board.GetBusiness(7).Owner == board.GetBusiness(9).Owner)) && board.GetBusiness(9).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(6).CurrentLevel = 0;
                board.GetBusiness(7).CurrentLevel = 0;
                board.GetBusiness(9).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep6_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            buttonSell.Visible = true;
            Business curBiz = board.GetBusiness(5);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Вартість поля: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* * = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * * = {curBiz.Levels[3]}";
            labelInfo4.Text = " ";
            labelInfo5.Text = " ";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: Цей бізнес пасивний";
        }

        private void panelStep12_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(11);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(11).Owner == board.GetBusiness(13).Owner) && (board.GetBusiness(13).Owner == board.GetBusiness(14).Owner)) && board.GetBusiness(11).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(11).CurrentLevel = 0;
                board.GetBusiness(13).CurrentLevel = 0;
                board.GetBusiness(14).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep14_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(13);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(11).Owner == board.GetBusiness(13).Owner) && (board.GetBusiness(13).Owner == board.GetBusiness(14).Owner)) && board.GetBusiness(13).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(11).CurrentLevel = 0;
                board.GetBusiness(13).CurrentLevel = 0;
                board.GetBusiness(14).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep15_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(14);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(11).Owner == board.GetBusiness(13).Owner) && (board.GetBusiness(13).Owner == board.GetBusiness(14).Owner)) && board.GetBusiness(14).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(11).CurrentLevel = 0;
                board.GetBusiness(13).CurrentLevel = 0;
                board.GetBusiness(14).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep17_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(16);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(16).Owner == board.GetBusiness(17).Owner) && (board.GetBusiness(17).Owner == board.GetBusiness(19).Owner)) && board.GetBusiness(16).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(16).CurrentLevel = 0;
                board.GetBusiness(17).CurrentLevel = 0;
                board.GetBusiness(19).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep18_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(17);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(16).Owner == board.GetBusiness(17).Owner) && (board.GetBusiness(17).Owner == board.GetBusiness(19).Owner)) && board.GetBusiness(17).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(16).CurrentLevel = 0;
                board.GetBusiness(17).CurrentLevel = 0;
                board.GetBusiness(19).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep20_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(19);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(16).Owner == board.GetBusiness(17).Owner) && (board.GetBusiness(17).Owner == board.GetBusiness(19).Owner)) && board.GetBusiness(19).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(16).CurrentLevel = 0;
                board.GetBusiness(17).CurrentLevel = 0;
                board.GetBusiness(19).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep22_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(21);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(21).Owner == board.GetBusiness(23).Owner) && (board.GetBusiness(23).Owner == board.GetBusiness(24).Owner)) && board.GetBusiness(21).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(21).CurrentLevel = 0;
                board.GetBusiness(23).CurrentLevel = 0;
                board.GetBusiness(24).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep24_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(23);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(21).Owner == board.GetBusiness(23).Owner) && (board.GetBusiness(23).Owner == board.GetBusiness(24).Owner)) && board.GetBusiness(23).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(21).CurrentLevel = 0;
                board.GetBusiness(23).CurrentLevel = 0;
                board.GetBusiness(24).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep25_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(24);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(21).Owner == board.GetBusiness(23).Owner) && (board.GetBusiness(23).Owner == board.GetBusiness(24).Owner)) && board.GetBusiness(24).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(21).CurrentLevel = 0;
                board.GetBusiness(23).CurrentLevel = 0;
                board.GetBusiness(24).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep27_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(26);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(26).Owner == board.GetBusiness(27).Owner) && (board.GetBusiness(27).Owner == board.GetBusiness(29).Owner)) && board.GetBusiness(26).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(26).CurrentLevel = 0;
                board.GetBusiness(27).CurrentLevel = 0;
                board.GetBusiness(29).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep28_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(27);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(26).Owner == board.GetBusiness(27).Owner) && (board.GetBusiness(27).Owner == board.GetBusiness(29).Owner)) && board.GetBusiness(27).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(26).CurrentLevel = 0;
                board.GetBusiness(27).CurrentLevel = 0;
                board.GetBusiness(29).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep30_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(29);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(26).Owner == board.GetBusiness(27).Owner) && (board.GetBusiness(27).Owner == board.GetBusiness(29).Owner)) && board.GetBusiness(29).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(26).CurrentLevel = 0;
                board.GetBusiness(27).CurrentLevel = 0;
                board.GetBusiness(29).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep32_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(31);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(31).Owner == board.GetBusiness(33).Owner) && (board.GetBusiness(33).Owner == board.GetBusiness(34).Owner)) && board.GetBusiness(31).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(31).CurrentLevel = 0;
                board.GetBusiness(33).CurrentLevel = 0;
                board.GetBusiness(34).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep34_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(33);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(31).Owner == board.GetBusiness(33).Owner) && (board.GetBusiness(33).Owner == board.GetBusiness(34).Owner)) && board.GetBusiness(33).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(31).CurrentLevel = 0;
                board.GetBusiness(33).CurrentLevel = 0;
                board.GetBusiness(34).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep35_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(34);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (((board.GetBusiness(31).Owner == board.GetBusiness(33).Owner) && (board.GetBusiness(33).Owner == board.GetBusiness(34).Owner)) && board.GetBusiness(34).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(31).CurrentLevel = 0;
                board.GetBusiness(33).CurrentLevel = 0;
                board.GetBusiness(34).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep38_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(37);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (board.GetBusiness(37).Owner == board.GetBusiness(39).Owner && board.GetBusiness(37).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(37).CurrentLevel = 0;
                board.GetBusiness(39).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep40_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            isFull = false;
            Business curBiz = board.GetBusiness(39);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            if (board.GetBusiness(37).Owner == board.GetBusiness(39).Owner && board.GetBusiness(39).Owner != null)
            {
                buttonUpgrade.Visible = true;
                isFull = true;
            }
            if (!isFull)
            {
                board.GetBusiness(37).CurrentLevel = 0;
                board.GetBusiness(39).CurrentLevel = 0;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Базова рента: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * = {curBiz.Levels[3]}";
            labelInfo4.Text = $"* * * * = {curBiz.Levels[4]}";
            labelInfo5.Text = $"* * * * * = {curBiz.Levels[5]}";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: {curBiz.UpgradePrice.ToString()}";
        }

        private void panelStep16_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            Business curBiz = board.GetBusiness(15);
            CurrentBussines = curBiz;
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Вартість поля: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* * = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * * = {curBiz.Levels[3]}";
            labelInfo4.Text = " ";
            labelInfo5.Text = " ";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: Цей бізнес пасивний";
        }

        private void panelStep26_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            Business curBiz = board.GetBusiness(25);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Вартість поля: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* * = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * * = {curBiz.Levels[3]}";
            labelInfo4.Text = " ";
            labelInfo5.Text = " ";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: Цей бізнес пасивний";
        }

        private void panelStep36_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            Business curBiz = board.GetBusiness(35);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Вартість поля: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"* * = {curBiz.Levels[1]}";
            labelInfo2.Text = $"* * * = {curBiz.Levels[2]}";
            labelInfo3.Text = $"* * * * = {curBiz.Levels[3]}";
            labelInfo4.Text = " ";
            labelInfo5.Text = " ";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: Цей бізнес пасивний";
        }

        private void panelStep19_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            Business curBiz = board.GetBusiness(18);
            CurrentBussines = curBiz;
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Вартість поля: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"*  = 100x";
            labelInfo2.Text = $"* *  = 250x";
            labelInfo3.Text = " ";
            labelInfo4.Text = " ";
            labelInfo5.Text = " ";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: Цей бізнес пасивний";
        }

        private void panelStep39_MouseEnter(object sender, EventArgs e)
        {
            buttonUpgrade.Visible = false;
            Business curBiz = board.GetBusiness(38);
            if (CurrentBussines != null && CurrentBussines.Owner != null)
            {
                buttonSell.Visible = true;
            }
            else
            {
                buttonSell.Visible = false;
            }
            CurrentBussines = curBiz;
            labelNameInfo.Text = curBiz.Name.ToString();
            labelInfoType.Text = curBiz.Type.ToString();
            labelInfoLevel.Text = curBiz.CurrentLevel.ToString();
            if (curBiz.Owner != null)
            {
                panel7.BackColor = curBiz.Owner.Color;
            }
            else
            {
                panel7.BackColor = Color.LightGray;
            }
            labelInfoBase.Text = $"Вартість поля: {curBiz.Levels[0].ToString()}";
            labelInfo1.Text = $"*  = 100x";
            labelInfo2.Text = $"* *  = 250x";
            labelInfo3.Text = " ";
            labelInfo4.Text = " ";
            labelInfo5.Text = " ";

            labelInfoPrice.Text = $"Вартість поля: {curBiz.PurchasePrice.ToString()}";
            labelInfoSellPrice.Text = $"Застава поля: {curBiz.SellPrice.ToString()}";
            labelInfoFillial.Text = $"Ціна філії: Цей бізнес пасивний";
        }

        private void label30_Click(object sender, EventArgs e)
        {
            this.Close();
            Runner runner = new Runner();
            runner.Show();
        }

        public static double MoneyLeftTrade { get; set; } = 0;
        public static double MoneyRightTrade { get; set; } = 0;
        public static List<Business> BizLeftTrade { get; set; } = new List<Business>();
        public static List<Business> BizRightTrade { get; set; } = new List<Business>();
        private void tradeButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                return;
            }
            else if (players[currentPlayerIndex].Name == comboBox1.SelectedItem.ToString())
            {
                MessageBox.Show("Ви не можете обмiнюватися з самим собою", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int I = 0;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (players[i].Name == comboBox1.SelectedItem.ToString())
                {
                    MoneyRightTrade = players[i].Money;
                    BizRightTrade = players[i].OwnedBusinesses;
                    I = i;
                }
            }

            MoneyLeftTrade = players[currentPlayerIndex].Money;
            BizLeftTrade = players[currentPlayerIndex].OwnedBusinesses;

            AmericanTrade trade = new AmericanTrade(MoneyLeftTrade, MoneyRightTrade, BizLeftTrade, BizRightTrade, players[currentPlayerIndex].Name, players[I].Name);
            trade.ShowDialog();

            players[I].Money = MoneyRightTrade;
            players[I].OwnedBusinesses = BizRightTrade;

            players[currentPlayerIndex].Money = MoneyLeftTrade;
            players[currentPlayerIndex].OwnedBusinesses = BizLeftTrade;

            for (int i = 0; i < numberOfPlayers; i++)
            {
                foreach (Business biz in players[i].OwnedBusinesses)
                {
                    biz.Owner = players[i];
                }

            }
        }
    }
}
