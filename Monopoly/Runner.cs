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
                        AmericanBoard board2 = new AmericanBoard(player, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Загальні відомості:\r\n\"Монополія\" - настільна гра в жанрі економічної стратегії для двох і більше осіб. Набула великої популярності у XX столітті в багатьох країнах світу. Мета гри - раціонально використовуючи стартовий капітал, домогтися банкрутства інших гравців. Фактично \"Монополія\" являє собою ігрове поле, що складається з квадратів, які проходять по колу всі гравці по черзі. Квадрати поділяються на активи (підприємство, цінна річ) і події. Коли гравцеві випадає черга ходити, то кидком кубика він визначає, яку кількість кроків він повинен зробити на ігровому полі за цей хід (кожен крок відповідає одному очку на кубику та одному квадрату на ігровому полі).\r\n\r\n\r\nПравила гри:\r\nПравила гри прості: гравці по черзі кидають кубики і роблять відповідну кількість ходів на гральному полі (якщо на кубиках випали однакові числа, гравець отримує право на ще один хід). Ставши на поле з фірмою, гравець може придбати її, якщо фірма вільна; а якщо фірма належить іншому гравцеві, то гравець зобов'язаний заплатити за відвідування цього поля оренду за встановленим правилами прейскурантом (сума оренди вказується на ярличку поля). Під час відвідування поля з подіями гравець отримує вказівку слідувати події, яка випала йому (наприклад, отримати гроші, заплатити штраф, або відправитися до в'язниці).\r\n\r\nУ грі всі фірми належать до різних галузей (наприклад, одяг, авіалінії або банки), в одній галузі може бути від двох до чотирьох фірм. На ігровому полі фірми однієї галузі, як правило, розташовані поруч і мають ярличок одного кольору. Гравець, який володіє всіма фірмами однієї галузі, стає монополістом, що дає йому право вкладати свої гроші в будівництво філій, що збільшує вартість потрапляння супротивника на поле. Таким чином, кожен гравець для перемоги повинен намагатися придбати не просто поля, а поля однієї галузі, щоб мати можливість розвинутися.\r\nГравець може обмінювати свої поля на чужі в інших гравців, при цьому, звісно, одержувач пропозиції може відмовитися від вашої угоди. Пам'ятайте, вигідна угода збільшує ваш шанс на перемогу.\r\n\r\nГравець може опинитися у в'язниці, наприклад, потрапивши на поле \"Поліція\" або викинувши три дублі поспіль. Вийти з в'язниці можна або заплативши гроші, або викинувши дубль (на цей варіант дається три спроби).", "Правила гри", MessageBoxButtons.OK);
        }
    }
}
