using Monopoly.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Boards
{
    public partial class AmericanCasino : Form
    {
        public double Money = 0;
        public AmericanCasino(double money)
        {
            InitializeComponent();
            Money = money;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0 && Convert.ToInt32(textBox1.Text) <= Money)
                {
                    Random firstPanelRandmon = new Random();
                    int value = firstPanelRandmon.Next(1, 100);
                    if (value <= 30)
                    {
                        Money += Convert.ToDouble(textBox1.Text) * 2.25;
                        MessageBox.Show($"Вы выиграли {Convert.ToDouble(textBox1.Text) * 2.25}");
                    }
                    else
                    {
                        Money -= Convert.ToDouble(textBox1.Text);
                        MessageBox.Show("Вы проиграли");
                    }
                    AmericanBoard.Money = Money;
                    Thread.Sleep(1000);
                    this.Close();
                }
            }
            catch
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0 && Convert.ToInt32(textBox2.Text) <= Money)
                {
                    Random secondPanelRandmon = new Random();
                    int value = secondPanelRandmon.Next(1, 100);
                    if (value <= 40)
                    {
                        Money += Convert.ToDouble(textBox2.Text) * 1.85;
                        MessageBox.Show($"Вы выиграли {Convert.ToDouble(textBox2.Text) * 1.85}");
                    }
                    else
                    {
                        Money -= Convert.ToDouble(textBox2.Text);
                        MessageBox.Show("Вы проиграли");
                    }
                    AmericanBoard.Money = Money;
                    Thread.Sleep(1000);
                    this.Close();
                }
            }
            catch
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Length > 0 && Convert.ToInt32(textBox3.Text) <= Money)
                {
                    Random thirdPanelRandmon = new Random();
                    int value = thirdPanelRandmon.Next(1, 100);
                    if (value <= 50)
                    {
                        Money += Convert.ToDouble(textBox3.Text) * 1.50;
                        MessageBox.Show($"Вы выиграли {Convert.ToDouble(textBox3.Text) * 1.50}");
                    }
                    else
                    {
                        Money -= Convert.ToDouble(textBox3.Text);
                        MessageBox.Show("Вы проиграли");
                    }
                    AmericanBoard.Money = Money;
                    Thread.Sleep(1000);
                    this.Close();
                }
            }
            catch
            {
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text.Length > 0 && Convert.ToInt32(textBox4.Text) <= Money)
                {
                    Random fourthPanelRandmon = new Random();
                    int value = fourthPanelRandmon.Next(1, 100);
                    if (value <= 60)
                    {
                        Money += Convert.ToDouble(textBox4.Text) * 1.25;
                        MessageBox.Show($"Вы выиграли {Convert.ToDouble(textBox4.Text) * 1.35}");
                    }
                    else
                    {
                        Money -= Convert.ToDouble(textBox4.Text);
                        MessageBox.Show("Вы проиграли");
                    }
                    AmericanBoard.Money = Money;
                    Thread.Sleep(1000);
                    this.Close();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
