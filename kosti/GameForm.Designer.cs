namespace kosti
{
    partial class GameForm
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
            panel1 = new Panel();
            panel3 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            UseBoxes_btn = new Button();
            button1 = new Button();
            game_controller_label = new Label();
            round_controller_label = new Label();
            panel2 = new Panel();
            playersLabel = new Label();
            label_for_players = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 450);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(UseBoxes_btn);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(game_controller_label);
            panel3.Controls.Add(round_controller_label);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(250, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(550, 450);
            panel3.TabIndex = 1;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(438, 89);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(72, 70);
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(338, 89);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(72, 70);
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(235, 89);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(72, 70);
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(132, 89);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(72, 70);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(27, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // UseBoxes_btn
            // 
            UseBoxes_btn.Location = new Point(286, 256);
            UseBoxes_btn.Name = "UseBoxes_btn";
            UseBoxes_btn.Size = new Size(135, 29);
            UseBoxes_btn.TabIndex = 5;
            UseBoxes_btn.Text = "Перекинуть";
            UseBoxes_btn.UseVisualStyleBackColor = true;
            UseBoxes_btn.Click += UseBoxes_btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(115, 256);
            button1.Name = "button1";
            button1.Size = new Size(145, 29);
            button1.TabIndex = 4;
            button1.Text = "Оставить";
            button1.UseVisualStyleBackColor = true;
            // 
            // game_controller_label
            // 
            game_controller_label.AutoSize = true;
            game_controller_label.Location = new Point(27, 38);
            game_controller_label.Name = "game_controller_label";
            game_controller_label.Size = new Size(158, 20);
            game_controller_label.TabIndex = 3;
            game_controller_label.Text = "Ожидаем старт игры!";
            // 
            // round_controller_label
            // 
            round_controller_label.AutoSize = true;
            round_controller_label.Location = new Point(226, 9);
            round_controller_label.Name = "round_controller_label";
            round_controller_label.Size = new Size(110, 20);
            round_controller_label.TabIndex = 2;
            round_controller_label.Text = "Первый раунд";
            // 
            // panel2
            // 
            panel2.Controls.Add(playersLabel);
            panel2.Controls.Add(label_for_players);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 450);
            panel2.TabIndex = 0;
            // 
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Location = new Point(12, 38);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(120, 20);
            playersLabel.TabIndex = 1;
            playersLabel.Text = "Waiting players...";
            // 
            // label_for_players
            // 
            label_for_players.AutoSize = true;
            label_for_players.Location = new Point(12, 9);
            label_for_players.Name = "label_for_players";
            label_for_players.Size = new Size(63, 20);
            label_for_players.TabIndex = 0;
            label_for_players.Text = "Игроки:";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "GameForm";
            Text = "GameForm";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Label game_controller_label;
        private Label round_controller_label;
        private Label playersLabel;
        private Label label_for_players;
        private Button button1;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button UseBoxes_btn;
    }
}