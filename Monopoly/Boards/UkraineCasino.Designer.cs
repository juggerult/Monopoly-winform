namespace Monopoly.Boards
{
    partial class UkraineCasino
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(190, 40);
            label1.Name = "label1";
            label1.Size = new Size(211, 15);
            label1.TabIndex = 0;
            label1.Text = "Вибери три цифри та отримай гроші";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            comboBox1.Location = new Point(81, 71);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            comboBox2.Location = new Point(227, 71);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 2;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            comboBox3.Location = new Point(380, 71);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(227, 204);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 4;
            button1.Text = "Старт";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 109);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Випало:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 140);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 6;
            label3.Text = "Перше значення";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(236, 140);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 7;
            label4.Text = "Друге значення";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(380, 140);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 8;
            label5.Text = "Третє значення";
            // 
            // UkraineCasino
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 261);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "UkraineCasino";
            Text = "Казино";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}