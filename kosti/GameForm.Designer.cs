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
            queue_btn = new Button();
            comboButton = new Button();
            endTurn_btn = new Button();
            box5 = new CheckBox();
            box4 = new CheckBox();
            box3 = new CheckBox();
            box2 = new CheckBox();
            box1 = new CheckBox();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            UseBoxes_btn = new Button();
            pass_button = new Button();
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
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 338);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(queue_btn);
            panel3.Controls.Add(comboButton);
            panel3.Controls.Add(endTurn_btn);
            panel3.Controls.Add(box5);
            panel3.Controls.Add(box4);
            panel3.Controls.Add(box3);
            panel3.Controls.Add(box2);
            panel3.Controls.Add(box1);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(UseBoxes_btn);
            panel3.Controls.Add(pass_button);
            panel3.Controls.Add(game_controller_label);
            panel3.Controls.Add(round_controller_label);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(219, 0);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(481, 338);
            panel3.TabIndex = 1;
            // 
            // queue_btn
            // 
            queue_btn.Location = new Point(164, 153);
            queue_btn.Margin = new Padding(3, 2, 3, 2);
            queue_btn.Name = "queue_btn";
            queue_btn.Size = new Size(140, 22);
            queue_btn.TabIndex = 18;
            queue_btn.Text = "Бросить кубик";
            queue_btn.UseVisualStyleBackColor = true;
            queue_btn.Visible = false;
            queue_btn.Click += queue_btn_Click;
            // 
            // comboButton
            // 
            comboButton.Location = new Point(179, 299);
            comboButton.Margin = new Padding(3, 2, 3, 2);
            comboButton.Name = "comboButton";
            comboButton.Size = new Size(124, 22);
            comboButton.TabIndex = 17;
            comboButton.Text = "Комбинации";
            comboButton.UseVisualStyleBackColor = true;
            comboButton.Click += comboButton_Click;
            // 
            // endTurn_btn
            // 
            endTurn_btn.Location = new Point(164, 153);
            endTurn_btn.Margin = new Padding(3, 2, 3, 2);
            endTurn_btn.Name = "endTurn_btn";
            endTurn_btn.Size = new Size(140, 22);
            endTurn_btn.TabIndex = 16;
            endTurn_btn.Text = "Закончить ход";
            endTurn_btn.UseVisualStyleBackColor = true;
            endTurn_btn.Visible = false;
            endTurn_btn.Click += endTurn_btn_Click;
            // 
            // box5
            // 
            box5.AutoSize = true;
            box5.Location = new Point(408, 124);
            box5.Margin = new Padding(3, 2, 3, 2);
            box5.Name = "box5";
            box5.Size = new Size(15, 14);
            box5.TabIndex = 15;
            box5.UseVisualStyleBackColor = true;
            box5.CheckedChanged += box_CheckedChanged;
            // 
            // box4
            // 
            box4.AutoSize = true;
            box4.Location = new Point(318, 124);
            box4.Margin = new Padding(3, 2, 3, 2);
            box4.Name = "box4";
            box4.Size = new Size(15, 14);
            box4.TabIndex = 14;
            box4.UseVisualStyleBackColor = true;
            box4.CheckedChanged += box_CheckedChanged;
            // 
            // box3
            // 
            box3.AutoSize = true;
            box3.Location = new Point(229, 124);
            box3.Margin = new Padding(3, 2, 3, 2);
            box3.Name = "box3";
            box3.Size = new Size(15, 14);
            box3.TabIndex = 13;
            box3.UseVisualStyleBackColor = true;
            box3.CheckedChanged += box_CheckedChanged;
            // 
            // box2
            // 
            box2.AutoSize = true;
            box2.Location = new Point(138, 124);
            box2.Margin = new Padding(3, 2, 3, 2);
            box2.Name = "box2";
            box2.Size = new Size(15, 14);
            box2.TabIndex = 12;
            box2.UseVisualStyleBackColor = true;
            box2.CheckedChanged += box_CheckedChanged;
            // 
            // box1
            // 
            box1.AutoSize = true;
            box1.Location = new Point(48, 124);
            box1.Margin = new Padding(3, 2, 3, 2);
            box1.Name = "box1";
            box1.Size = new Size(15, 14);
            box1.TabIndex = 11;
            box1.UseVisualStyleBackColor = true;
            box1.CheckedChanged += box_CheckedChanged;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(383, 67);
            pictureBox5.Margin = new Padding(3, 2, 3, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(63, 52);
            pictureBox5.TabIndex = 10;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(296, 67);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(63, 52);
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(206, 67);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(63, 52);
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(116, 67);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(63, 52);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.ImageLocation = "";
            pictureBox1.Location = new Point(24, 67);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 52);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox_Click;
            // 
            // UseBoxes_btn
            // 
            UseBoxes_btn.Location = new Point(287, 153);
            UseBoxes_btn.Margin = new Padding(3, 2, 3, 2);
            UseBoxes_btn.Name = "UseBoxes_btn";
            UseBoxes_btn.Size = new Size(118, 22);
            UseBoxes_btn.TabIndex = 5;
            UseBoxes_btn.Text = "Перекинуть";
            UseBoxes_btn.UseVisualStyleBackColor = true;
            UseBoxes_btn.Click += UseBoxes_btn_Click;
            // 
            // pass_button
            // 
            pass_button.Location = new Point(48, 153);
            pass_button.Margin = new Padding(3, 2, 3, 2);
            pass_button.Name = "pass_button";
            pass_button.Size = new Size(183, 22);
            pass_button.TabIndex = 4;
            pass_button.Text = "Сохранить комбинацию";
            pass_button.UseVisualStyleBackColor = true;
            pass_button.Click += pass_button_Click;
            // 
            // game_controller_label
            // 
            game_controller_label.AutoSize = true;
            game_controller_label.Location = new Point(24, 28);
            game_controller_label.Name = "game_controller_label";
            game_controller_label.Size = new Size(125, 15);
            game_controller_label.TabIndex = 3;
            game_controller_label.Text = "Ожидаем старт игры!";
            // 
            // round_controller_label
            // 
            round_controller_label.AutoSize = true;
            round_controller_label.Location = new Point(164, 7);
            round_controller_label.Name = "round_controller_label";
            round_controller_label.Size = new Size(48, 15);
            round_controller_label.TabIndex = 2;
            round_controller_label.Text = "Раунд 1";
            // 
            // panel2
            // 
            panel2.Controls.Add(playersLabel);
            panel2.Controls.Add(label_for_players);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(219, 338);
            panel2.TabIndex = 0;
            // 
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Location = new Point(10, 28);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(97, 15);
            playersLabel.TabIndex = 1;
            playersLabel.Text = "Waiting players...";
            // 
            // label_for_players
            // 
            label_for_players.AutoSize = true;
            label_for_players.Location = new Point(10, 7);
            label_for_players.Name = "label_for_players";
            label_for_players.Size = new Size(51, 15);
            label_for_players.TabIndex = 0;
            label_for_players.Text = "Игроки:";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button pass_button;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button UseBoxes_btn;
        private CheckBox box1;
        private CheckBox box5;
        private CheckBox box4;
        private CheckBox box3;
        private CheckBox box2;
        private Button endTurn_btn;
        private Button comboButton;
        private Button queue_btn;
    }
}