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
    public partial class UkraineCasino : Form
    {

        public UkraineCasino()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int winMoney = 0;
            int countOfWin = 0;
            Random random = new Random();
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали все числа либо выбрали число за установлеными рамками");
                return;
            }
            else
            {
                label3.Text = random.Next(1, 6).ToString();
                label4.Text = random.Next(1, 6).ToString();
                label5.Text = random.Next(1, 6).ToString();
                if(comboBox1.SelectedItem.ToString() == label3.Text)
                {
                    countOfWin++;
                }
                if (comboBox2.SelectedItem.ToString() == label4.Text)
                {
                    countOfWin++;
                }
                if (comboBox3.SelectedItem.ToString() == label5.Text)
                {
                    countOfWin++;
                }
                switch(countOfWin)
                {
                    case 0:
                        MessageBox.Show("Вы не выиграли ничего");
                        break;
                        case 1:
                        MessageBox.Show("Вы выиграли x2");
                        winMoney = 300000;
                        break;
                        case 2:
                        MessageBox.Show("Вы выиграли x4");
                        winMoney = 600000;
                        break;
                        case 3:
                        MessageBox.Show("Вы выиграли x10");
                        winMoney = 1500000;
                        break;
                }
                UkrainianBoard.Money += winMoney;
                Thread.Sleep(1000);
                this.Close();
            }
            
        }
    }
}
