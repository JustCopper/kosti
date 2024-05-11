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
            panel2 = new Panel();
            panel3 = new Panel();
            label_for_players = new Label();
            playersLabel = new Label();
            round_controller_label = new Label();
            game_controller_label = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
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
            // panel3
            // 
            panel3.Controls.Add(game_controller_label);
            panel3.Controls.Add(round_controller_label);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(250, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(550, 450);
            panel3.TabIndex = 1;
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
            // playersLabel
            // 
            playersLabel.AutoSize = true;
            playersLabel.Location = new Point(12, 38);
            playersLabel.Name = "playersLabel";
            playersLabel.Size = new Size(120, 20);
            playersLabel.TabIndex = 1;
            playersLabel.Text = "Waiting players...";
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
            // game_controller_label
            // 
            game_controller_label.AutoSize = true;
            game_controller_label.Location = new Point(27, 38);
            game_controller_label.Name = "game_controller_label";
            game_controller_label.Size = new Size(158, 20);
            game_controller_label.TabIndex = 3;
            game_controller_label.Text = "Ожидаем старт игры!";
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
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
    }
}