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
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(62, 59);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(276, 59);
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(104, 45);
            trackBar2.TabIndex = 1;
            trackBar2.Scroll += trackBar2_Scroll;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(45, 124);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(276, 124);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(115, 193);
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
            label1.Location = new Point(86, 31);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 6;
            label1.Text = "Грошi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(321, 31);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 7;
            label2.Text = "Грошi";
            // 
            // UkrainianTrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 289);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
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
    }
}