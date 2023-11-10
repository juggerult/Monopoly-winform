namespace Monopoly.Boards
{
    partial class UkrainianTrade
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
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.FromArgb(188, 188, 188);
            trackBar1.Location = new Point(62, 128);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.BackColor = Color.FromArgb(188, 188, 188);
            trackBar2.Location = new Point(276, 128);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(104, 45);
            trackBar2.TabIndex = 1;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(45, 179);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(276, 179);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(111, 219);
            button1.Name = "button1";
            button1.Size = new Size(209, 29);
            button1.TabIndex = 4;
            button1.Text = "Обмінятися";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 254);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Вихiд";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(90, 92);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 6;
            label1.Text = "Грошi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(298, 92);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 7;
            label2.Text = "Грошi";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 51);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(280, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 9;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(90, 21);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 10;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(316, 21);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 11;
            label4.Text = "label4";
            // 
            // UkrainianTrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Без_имени_12;
            BackgroundImageLayout = ImageLayout.None;
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
            Name = "UkrainianTrade";
            Text = "UkrainianTrade";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Label label4;
    }
}