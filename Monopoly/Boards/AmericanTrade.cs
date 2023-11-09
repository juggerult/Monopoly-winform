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
    public partial class AmericanTrade : Form
    {
        double moneyLeft = 0;
        double moneyRight = 0;
        List<Monopoly.Main.AmericanBoard.Business> LeftBiz = new List<Main.AmericanBoard.Business>();
        List<Monopoly.Main.AmericanBoard.Business> RightBiz = new List<Main.AmericanBoard.Business>();
        public AmericanTrade(double MoneyLeft, double MoneyRight, List<Monopoly.Main.AmericanBoard.Business> leftBiz, List<Monopoly.Main.AmericanBoard.Business> rightBiz, string firstName, string secondName)
        {
            InitializeComponent();
            moneyLeft = MoneyLeft; moneyRight = MoneyRight;
            LeftBiz = (leftBiz);
            RightBiz = (rightBiz);

            comboBox1.Items.Add("Нiчого");
            comboBox2.Items.Add("Нiчого");
            for (int i = 0; i < leftBiz.Count; i++)
            {
                comboBox1.Items.Add(leftBiz[i].Name);
            }
            for (int i = 0; i < rightBiz.Count; i++)
            {
                comboBox2.Items.Add(rightBiz[i].Name);
            }

            label3.Text = firstName;
            label4.Text = secondName;
            trackBar1.Maximum = Convert.ToInt32(MoneyLeft);
            trackBar2.Maximum = Convert.ToInt32(MoneyRight);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Нiчого")
            {
                Main.AmericanBoard.Business biz = LeftBiz[comboBox1.SelectedIndex - 1];
                LeftBiz.Remove(biz);
                RightBiz.Add(biz);
            }
            if (comboBox2.SelectedItem != null && comboBox2.SelectedItem.ToString() != "Нiчого")
            {
                Main.AmericanBoard.Business biz = RightBiz[comboBox2.SelectedIndex - 1];
                RightBiz.Remove(biz);
                LeftBiz.Add(biz);
            }
            if (trackBar1.Value != null)
            {
                moneyRight += trackBar1.Value;
                moneyLeft -= trackBar1.Value;
            }
            if (trackBar2.Value != null)
            {
                moneyRight -= trackBar2.Value;
                moneyLeft += trackBar2.Value;
            }

            AmericanBoard.MoneyLeftTrade = moneyLeft;
            AmericanBoard.MoneyRightTrade = moneyRight;
            AmericanBoard.BizLeftTrade = LeftBiz;
            AmericanBoard.BizRightTrade = RightBiz;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0 && Convert.ToInt32(textBox1.Text) < trackBar1.Maximum)
                {
                    trackBar1.Value = Convert.ToInt32(textBox1.Text);
                    label1.Text = trackBar1.Value.ToString();
                }
            }
            catch
            {
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length > 0 && Convert.ToInt32(textBox2.Text) < trackBar2.Maximum)
                {
                    trackBar2.Value = Convert.ToInt32(textBox2.Text);
                    label2.Text = trackBar2.Value.ToString();
                }
            }
            catch
            {
                return;

            }
        }
    }
}
