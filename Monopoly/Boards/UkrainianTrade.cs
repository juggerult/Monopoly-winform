using Monopoly.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monopoly.Boards
{
    public partial class UkrainianTrade : Form
    {
        double moneyLeft = 0;
        double moneyRight = 0;
        List<Monopoly.Main.UkrainianBoard.Business> LeftBiz = new List<Main.UkrainianBoard.Business>();
        List<Monopoly.Main.UkrainianBoard.Business> RightBiz = new List<Main.UkrainianBoard.Business>();
        public UkrainianTrade(double MoneyLeft, double MoneyRight, List<Monopoly.Main.UkrainianBoard.Business> leftBiz, List<Monopoly.Main.UkrainianBoard.Business> rightBiz)
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
            if(comboBox1.SelectedItem.ToString() != "Нiчого")
            {
                Main.UkrainianBoard.Business biz = LeftBiz[comboBox1.SelectedIndex - 1];
                LeftBiz.Remove(biz);
                RightBiz.Add(biz);
            }
            if(comboBox2.SelectedItem.ToString() != "Нiчого")
            {
                Main.UkrainianBoard.Business biz = RightBiz[comboBox2.SelectedIndex - 1];
                RightBiz.Remove(biz);
                LeftBiz.Add(biz);
            }
            if(trackBar1.Value != null)
            {
                moneyRight += trackBar1.Value;
                moneyLeft -= trackBar1.Value;
            }
            if(trackBar2.Value != null)
            {
                moneyRight -= trackBar2.Value;
                moneyLeft += trackBar2.Value;
            }

            UkrainianBoard.MoneyLeftTrade = moneyLeft;
            UkrainianBoard.MoneyRightTrade = moneyRight;
            UkrainianBoard.BizLeftTrade = LeftBiz;
            UkrainianBoard.BizRightTrade = RightBiz;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            this.Close();
        }
    }
}
