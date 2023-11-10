namespace Monopoly.Boards
{
    partial class AmericanTrade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            trackBar2 = new TrackBar();
            trackBar1 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(306, 20);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 23;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(80, 20);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 22;
            label3.Text = "label3";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(270, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 21;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(56, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 20;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(303, 91);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 19;
            label2.Text = "Грошi";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(80, 91);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 18;
            label1.Text = "Грошi";
            // 
            // button2
            // 
            button2.Location = new Point(2, 253);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 17;
            button2.Text = "Вихiд";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(101, 218);
            button1.Name = "button1";
            button1.Size = new Size(209, 29);
            button1.TabIndex = 16;
            button1.Text = "Обмінятися";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(253, 172);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 15;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(35, 172);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 14;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.FromArgb(188, 188, 188);
            trackBar2.Location = new Point(270, 109);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(104, 45);
            trackBar2.TabIndex = 13;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.FromArgb(188, 188, 188);
            trackBar1.Location = new Point(52, 109);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 12;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // AmericanTrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(423, 289);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AmericanTrade";
            Text = "AmericanTrade";
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private TrackBar trackBar2;
        private TrackBar trackBar1;
    }
}