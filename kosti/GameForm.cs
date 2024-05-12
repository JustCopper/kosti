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
        private Random random = new Random();
        List<player> people = new List<player>();
        int round = 1;

        public GameForm(int players)
        {
            //List<player> people = new List<player>();
            for (int i = 0; i < players; i++)
            {
                player player = new player(i,$"player{i}");
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
            updateScores(people);
            LoadImages();
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
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            int[] diceRolls = new int[5];
            for (int i = 0; i < 5; i++)
            {
                int current_box = random.Next(0,6);
                diceRolls[i] = current_box+1;
                //int index = random.Next(imageFiles.Length);
                pictureBoxes[i].Image = Image.FromFile(imageFiles[current_box]);

                // Отображаем PictureBox
                pictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pictureBoxes[i].Show();
            }
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            
            game_controller_label.Text = $"Выпало: {Convert.ToString( EvaluateCombination(diceRolls))}, оставляем?\nБросок: {nowPlayingPlayer.diceState}";
        }

         object EvaluateCombination(int[] combination)
        {
            player current_player = people.Find(o => o.is_turn == true);
            
            // Стрейт
            if (combination.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) || combination.SequenceEqual(new int[] { 2, 3, 4, 5, 6 }))
            {
                int score = current_player.diceState == 1 ? 25 : 20;
                people[current_player.id].diceState += 1;
                return score;
            }
            // Фул-хаус
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 3) == 1 && combination.GroupBy(x => x).Count(g => g.Count() == 2) == 1)
            {
                int score = current_player.diceState == 1 ? 35 : 30;
                people[current_player.id].diceState += 1;
                return score;
            }
            // Четыре одинарных числа
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 4) == 1)
            {
                int score = current_player.diceState == 1 ? 45 : 40;
                people[current_player.id].diceState += 1;
                return score;
            }
            // Пять одинарных чисел (большой генерал)
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 5) == 1)
            {
                string score = current_player.diceState == 1 ? "Большой генерал" : "Малый генерал";
                people[current_player.id].diceState += 1;
                return score;
            }
            else
            {
                people[current_player.id].diceState += 1;
                return combination.Sum();
            }
        }

        private void startNewRound()
        {
            throw new NotImplementedException();
        }
    }
}
