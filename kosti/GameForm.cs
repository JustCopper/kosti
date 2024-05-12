using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;



namespace kosti
{
    public partial class GameForm : Form
    {
        private string[] imageFiles;
        List<CheckBox> checkboxes = new List<CheckBox>(); // Список для хранения ссылок на чекбоксы


        private Random random = new Random();
        List<player> people = new List<player>();
        int round = 1;

        public GameForm(int players)
        {

            for (int i = 0; i < players; i++)
            {
                player player = new player(i, $"player{i}");
                people.Add(player);
            }
            people[0].is_turn = true;
            // Бросаем 5 костей
            //for (int i = 0; i < 5; i++)
            //{
            //    int diceRoll = random.Next(1, 7); // Генерируем случайное число от 1 до 6
            //    Console.WriteLine($"Кубик {i + 1} показывает: {diceRoll}");
            //    totalScore += diceRoll;
            //}
            InitializeComponent();
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox

            updateScores(people);
            LoadImages();
            foreach (var pb in pictureBoxes)
            {
                pb.Image = Image.FromFile("C:\\Users\\JustCopper\\source\\repos\\kosti\\kosti\\unknown.png");

                // Отображаем PictureBox
                pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pb.Show();
            }
        }
        public void updateScores(List<player> people)
        {
            string Text = "";
            for (int i = 0; i < people.Count; i++)
            {
                Text += $"{people[i].name} - {people[i].scores} очков\n";
            }
            playersLabel.Text = Text;
        }

        private void LoadImages()
        {

            // Получаем список всех файлов изображений в папке
            imageFiles = Directory.GetFiles($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\Images", "*.png"); // Измените расширение файла, если ваши изображения имеют другое расширение

        }



        private void UseBoxes_btn_Click(object sender, EventArgs e)
        {
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            people[nowPlayingPlayer.id].diceState += 1;
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox

            int[] diceRolls = new int[5];
            foreach (var box in checkboxes)
            {
                int id = Convert.ToInt32(box.Name.Substring(3)) - 1;
                int current_box = random.Next(0, 6);
                people[nowPlayingPlayer.id].cards[id] = current_box + 1;

                //diceRolls[id] = current_box + 1;
                pictureBoxes[id].Image = Image.FromFile(imageFiles[current_box]);

                // Отображаем PictureBox
                pictureBoxes[id].SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pictureBoxes[id].Show();
            }
            //for (int i = 0; i < 5; i++)
            //{
            //    int current_box = random.Next(0, 6);
            //    diceRolls[i] = current_box + 1;
            //    //int index = random.Next(imageFiles.Length);
            //    pictureBoxes[i].Image = Image.FromFile(imageFiles[current_box]);

            //    // Отображаем PictureBox
            //    pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
            //    pictureBoxes[i].Show();
            //}
            string total_scores = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards));
            if (total_scores == "Большой генерал") 
            {
                round_controller_label.Text = "Игра закончена!";
                pass_button.Enabled = false;
                UseBoxes_btn.Enabled = false;
                game_controller_label.Text = $"Игрок {nowPlayingPlayer.name} победил, выбросив 'Большого генерала'!";
                return;
            }
            game_controller_label.Text = $"Выпало: {Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards))}, оставляем?\nБросок: {nowPlayingPlayer.diceState}";
            if (people[nowPlayingPlayer.id].diceState == 3)
            {
                people[nowPlayingPlayer.id].is_turn = false;
                people[nowPlayingPlayer.id].scores += Convert.ToInt32( total_scores);
                updateScores(people);
                if (nowPlayingPlayer.id + 1 == people.Count())
                {
                    startNewRound();
                }
                else
                {
                    people[nowPlayingPlayer.id + 1].is_turn = true;
                }
            }
        }

        object EvaluateCombination(int[] combination)
        {
            player current_player = people.Find(o => o.is_turn == true);

            // Стрейт
            if (combination.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) || combination.SequenceEqual(new int[] { 2, 3, 4, 5, 6 }))
            {
                int score = current_player.diceState == 1 ? 25 : 20;
                //people[current_player.id].diceState += 1;
                return score;
            }
            // Фул-хаус
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 3) == 1 && combination.GroupBy(x => x).Count(g => g.Count() == 2) == 1)
            {
                int score = current_player.diceState == 1 ? 35 : 30;
                //people[current_player.id].diceState += 1;
                return score;
            }
            // Четыре одинарных числа
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 4) == 1)
            {
                int score = current_player.diceState == 1 ? 45 : 40;
                //people[current_player.id].diceState += 1;
                return score;
            }
            // Пять одинарных чисел (большой генерал)
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 5) == 1)
            {
                return current_player.diceState == 1 ? "Большой генерал" : 60;
                //string score = current_player.diceState == 1 ? "Большой генерал" : 60;
                //people[current_player.id].diceState += 1;
                //return score;
            }
            else
            {
                //people[current_player.id].diceState += 1;
                return combination.Sum();
            }
        }

        private void startNewRound()
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            round += 1;
            round_controller_label.Text = $"Раунд {round}";
            foreach (var p in people)
            {
                p.diceState = 1;
                p.cards = new int[5];
                p.is_turn = false;
            }
            people[0].is_turn = true;
            if (round == 11)
            {
                var winner = people.OrderByDescending(x => x.scores).FirstOrDefault();
                game_controller_label.Text = $"Победил: {winner.name} - {winner.scores} очков!";
                round_controller_label.Text = "Игра закончена!";
                pass_button.Enabled = false;
                UseBoxes_btn.Enabled = false;
                foreach (var pb in pictureBoxes)
                {
                    pb.Image = Image.FromFile("C:\\Users\\JustCopper\\source\\repos\\kosti\\kosti\\unknown.png");

                    // Отображаем PictureBox
                    pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                    pb.Show();
                }
            }
        }

        private void box2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void box_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox here = (CheckBox)sender;
            if (here.Checked)
            {
                checkboxes.Add(here);
            }
            else
            {
                checkboxes.Remove(here);
            }
        }

        private void pass_button_Click(object sender, EventArgs e)
        {

        }
    }
}
