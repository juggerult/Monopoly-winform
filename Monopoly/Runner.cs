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

namespace Monopoly
{
    public partial class Runner : Form
    {
        public Runner()
        {
            InitializeComponent();
        }

        public int board = 0;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            switch (trackBar1.Value)
            {
                case 3:
                    textBox1.Visible = true;
                    textBox1.Visible = true;
                    textBox1.Visible = true;

                    textBox4.Visible = false;
                    break;
                case 4:
                    textBox1.Visible = true;
                    textBox1.Visible = true;
                    textBox1.Visible = true;
                    textBox4.Visible = true;

                    break;
                case 5:
                    textBox1.Visible = true;
                    textBox1.Visible = true;
                    textBox1.Visible = true;
                    textBox4.Visible = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int player = 3;
            if (Check())
            {

                switch (trackBar1.Value)
                {
                    case 4:
                        player = 4;
                        break;
                }

                switch (board)
                {
                    case 1:
                        UkrainianBoard board1 = new UkrainianBoard(player, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                        board1.Show();
                        this.Hide();
                        break;
                    case 2:
                        AmericanBoard board2 = new AmericanBoard(player);
                        board2.Show();
                        this.Hide();
                        break;
                }
            }
            else
            {
                return;
            }
        }

        public bool Check()
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Вы ввели не все имена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (board == 0)
            {
                MessageBox.Show("Вы не выбрали стиль игры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            board = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            board = 2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            board = 1;
        }
    }
}
