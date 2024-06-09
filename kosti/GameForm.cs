using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;





namespace kosti
{
    public partial class GameForm : Form
    {
        private string[] imageFiles;
        private string[] grayImageFiles;

        List<CheckBox> checkboxes = new List<CheckBox>(); // Список для хранения ссылок на чекбоксы
        Dictionary<int, string> comboDict = new Dictionary<int, string>();


        private Random random = new Random();
        List<player> people = new List<player>();
        string notCombo = "";
        int round = 1;
        bool isStarted = false;
        //int kek = 0;
        public GameForm(int players)
        {

            for (int i = 0; i < players; i++)
            {
                player player = new player(i, $"player{i}");
                people.Add(player);
            }
            people[0].is_turn = true;
            InitializeComponent();
            comboDict[60] = "Малый генерал";
            comboDict[45] = "Каре";
            comboDict[40] = "Дособрано Каре";
            comboDict[35] = "Фулл хаус";
            comboDict[30] = "Дособран Фулл хаус ";
            comboDict[25] = "Стрит";
            comboDict[20] = "Дособран Стрит";

            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox

            updateScores(people);
            LoadImages();
            foreach (var pb in pictureBoxes)
            {
                //pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                pb.Image = Image.FromFile($"unknown.png");

                // Отображаем PictureBox
                pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pb.Show();
            }
            resetCheckBoxes();
            startPreparingRound();
            switchPictureBoxes(false); // Вылючаем картиночки в начале игры

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
            //imageFiles = Directory.GetFiles($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\Images", "*.png"); // Измените расширение файла, если ваши изображения имеют другое расширение
            //grayImageFiles = Directory.GetFiles($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\ImagesGray", "*.png"); // Измените расширение файла, если ваши изображения имеют другое расширение
            imageFiles = Directory.GetFiles($"./Images/", "*.png"); // Измените расширение файла, если ваши изображения имеют другое расширение
            grayImageFiles = Directory.GetFiles($"./ImagesGray/", "*.png"); // Измените расширение файла, если ваши изображения имеют другое расширение

        }



        private void UseBoxes_btn_Click(object sender, EventArgs e) // Коменты есть :3
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Картиночки
            var cbs = new[] { box1, box2, box3, box4, box5 }; // Чекбоксы
            player nowPlayingPlayer = people.Find(o => o.is_turn == true); // нАходим игрока который ходит
            people[nowPlayingPlayer.id].diceState += 1; // Плюсуем 1 к броску

            foreach (var box in checkboxes) //Перебор чекбоксов
            {
                int id = Convert.ToInt32(box.Name.Substring(3)) - 1; //Из имени чекбоксов получаем и обрезаем число, благодаря ему меняем выбранный кубик в прошлой руке
                int current_box = random.Next(0, 6);
                people[nowPlayingPlayer.id].cards[id] = current_box + 1; // Меняем кубик в картах
                pictureBoxes[id].Image = Image.FromFile(imageFiles[current_box]); //Ставим картинку выпавшего кубика
                pictureBoxes[id].SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pictureBoxes[id].Show(); //Показать картинку
            }
            if (nowPlayingPlayer.diceState == 1) 
            {
                resetCheckBoxes(false);//Включаем чекбоксы на 1 бросок ( Чтобы нельзя было оставить вопросики)
                                       //people[nowPlayingPlayer.id].setCards([3, 3, 3, 5, 5]);
                checkComboCards(); // Каждый раунд проверяем на наличии выпадения комбинации

            }
            if (nowPlayingPlayer.diceState == 2)
            {
                // ДЛЯ ДЕБАГА КОМБИНАЦИЙ!!!!
                //people[nowPlayingPlayer.id].setCards([1, 2, 3, 4, 5]);
                //people[nowPlayingPlayer.id].setLastCards([1, 2, 3, 4, 5]);
                // ДЕБАГ!!!
                checkComboCards(); // Каждый раунд проверяем на наличии выпадения комбинации

            }
            if (people[nowPlayingPlayer.id].diceState == 3)
            {
                //if (kek == 0)  people[nowPlayingPlayer.id].setCards([3, 3, 3, 5, 5]);
                //kek += 1;
                checkComboCards(); // Каждый раунд проверяем на наличии выпадения комбинации

                var comboValue = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards)); //Текущее комбо
                var lastcomboValue = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].lastCards)); //Предыдущее комбо
                

                pass_button.Visible = false; //Выключаем видимость кнопку паса
                pass_button.Enabled = false;
                UseBoxes_btn.Visible = false;//Выключаем видимость кнопку броска
                endTurn_btn.Visible = true; //Включаем видимость кнопки завершения хода
                endTurn_btn.Enabled = false; //Выключаем кнопки конца хода

                foreach (var cb in cbs)
                {

                    cb.Visible = false; // Выключаем чекбоксы на 3 ход

                }
                if (people[nowPlayingPlayer.id].isCombo() && comboValue != lastcomboValue) //Если у нас комбо и оно не равно предыдущему
                {

                    switchPictureBoxes(false); // Выключаем картиночки ибо у нас комбо
                    endTurn_btn.Enabled = true; //Включаем кнопку завершение хода
                    return;
                }
                //game_controller_label.Text = $"{nowPlayingPlayer.name}, Комбинация не собрана.\nВыберите кубик с очками"; //Если у нас не комбо или оно равно предыдущему
                switchPictureBoxes(true); // Включаем картиночки на выбор кубика финального хода
                checkOnSameCards(); //Проверяем пред. не комбо число и блокаем его
                endTurn_btn.Enabled = false; //Включаем кнопку завершение хода

            }
        }

        object EvaluateCombination(int[] combination) //Функция по определению комбинаций,передаем сюда кубики игрока
        {
            player current_player = people.Find(o => o.is_turn == true); // Теккущий игрок который ходит
            if (combination.Any(x => x == 0)) return false;

            // Стрейт
            if (combination.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) || combination.SequenceEqual(new int[] { 2, 3, 4, 5, 6 }) || combination.SequenceEqual(new int[] { 1, 3, 4, 5, 6 }) || combination.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }))
            {
                int score = current_player.diceState == 1 ? 25 : 20; //Если комбинация выброшена 1 броском - больше баллов.
                return score;
            }
            // Фул-хаус
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 3) == 1 && combination.GroupBy(x => x).Count(g => g.Count() == 2) == 1)
            {
                int score = current_player.diceState == 1 ? 35 : 30;//Если комбинация выброшена 1 броском - больше баллов.
                return score;
            }
            // Четыре одинарных числа (флеш?)
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 4) == 1)
            {
                int score = current_player.diceState == 1 ? 45 : 40;//Если комбинация выброшена 1 броском - больше баллов.
                return score;
            }
            // Пять одинарных чисел (большой генерал)
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 5) == 1)
            {
                return current_player.diceState == 1 ? "Большой генерал" : 60;//Если комбинация выброшена 1 броском - больше баллов.

            }
            else // Комбинации нет
            {
                
                return false;
            }
        }

        private void startNewRound()
        {
            game_controller_label.Text = $"Ваш ход {people[0].name} - {people[0].scores} очков\nБросайте кубики!";
            //resetCheckBoxes();
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // PictureBox
            round += 1;
            round_controller_label.Text = $"Раунд {round}";
            foreach (var p in people)
            {
                p.diceState = 0;
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
                    //pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                    pb.Image = Image.FromFile($"unknown.png");
                    // Отображаем PictureBox
                    pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                    pb.Show();
                }
            }
            foreach (var pb in pictureBoxes)
            {
                //pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                pb.Image = Image.FromFile($"unknown.png");

                // Отображаем PictureBox
                pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pb.Show();
            }
        }

        private void resetCheckBoxes(bool check = true)
        {
            var cbs = new[] { box1, box2, box3, box4, box5 };
            foreach (var checkbox in cbs)
            {
                checkbox.Enabled = !checkbox.Enabled;
                if (check) checkbox.Checked = true;

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
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            string total_scores = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards));
            var cbs = new[] { box1, box2, box3, box4, box5 };
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };
            people[nowPlayingPlayer.id].is_turn = false;
            if (!people[nowPlayingPlayer.id].isCombo())
            {
                people[nowPlayingPlayer.id].scores += Convert.ToInt32(people[nowPlayingPlayer.id].notCombo);
                people[nowPlayingPlayer.id].setLastCards(people[nowPlayingPlayer.id].notCombo);

                //    people[nowPlayingPlayer.id].notComboDice = Convert.ToInt32(notCombo);
            }
            else
            {
                people[nowPlayingPlayer.id].scores += Convert.ToInt32(total_scores);
                people[nowPlayingPlayer.id].setLastCards(people[nowPlayingPlayer.id].cards);

                //people[nowPlayingPlayer.id].notCombo = 0;
            }
            people[nowPlayingPlayer.id].resetCards();
            updateScores(people);
            endTurn_btn.Visible = false;
            UseBoxes_btn.Visible = true;
            pass_button.Visible = true;
            pass_button.Enabled = false;
            resetCheckBoxes();
            switchPictureBoxes(false); // Выключаем картиночки после паса (необязательно)

            //foreach (var cb in cbs)
            //{

            //    cb.Visible = true;

            //}


            if (nowPlayingPlayer.id + 1 == people.Count())
            {
                startNewRound();
            }
            else
            {
                people[nowPlayingPlayer.id + 1].is_turn = true;
                game_controller_label.Text = $"Ваш ход {people[nowPlayingPlayer.id + 1].name} - {people[nowPlayingPlayer.id + 1].scores} очков\nБросайте кубики!";
                foreach (var pb in pictureBoxes)
                {
                    //pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                    pb.Image = Image.FromFile($"unknown.png");

                    pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                    pb.Show();
                }
            }
        }

        private void endTurn_btn_Click(object sender, EventArgs e)
        {
            endTurn_btn.Visible = false;
            if (!isStarted)
            {
                notStartedGameFunc();

                return;
            }
            endTurn_btn.Enabled = false;
            switchPictureBoxes(false); // Выключаем картиночки после завершения хода
            var cbs = new[] { box1, box2, box3, box4, box5 };
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };

            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            string total_scores = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards));
            //if (Convert.ToBoolean(total_scores) == false) 

            people[nowPlayingPlayer.id].is_turn = false;
            if (!people[nowPlayingPlayer.id].isCombo())
            {
                people[nowPlayingPlayer.id].setLastCards(people[nowPlayingPlayer.id].notCombo);
                int num = Convert.ToInt32(people[nowPlayingPlayer.id].notCombo);
                int sumNum = people[nowPlayingPlayer.id].cards.Where(x => x == num).Sum();
                people[nowPlayingPlayer.id].scores += sumNum;
                //    people[nowPlayingPlayer.id].notComboDice = Convert.ToInt32(notCombo);
            }
            else
            {
                people[nowPlayingPlayer.id].scores += Convert.ToInt32(total_scores);
                people[nowPlayingPlayer.id].setLastCards(people[nowPlayingPlayer.id].cards);
                //people[nowPlayingPlayer.id].notCombo = 0;
            }
            people[nowPlayingPlayer.id].resetCards(); 
            updateScores(people);
            endTurn_btn.Visible = false;
            UseBoxes_btn.Visible = true;
            pass_button.Visible = true;
            pass_button.Enabled = false;
            resetCheckBoxes();
            foreach (var cb in cbs)
            {

                cb.Visible = true;

            }


            if (nowPlayingPlayer.id + 1 == people.Count())
            {
                startNewRound();
            }
            else
            {
                people[nowPlayingPlayer.id + 1].is_turn = true;
                game_controller_label.Text = $"Ваш ход {people[nowPlayingPlayer.id + 1].name} - {people[nowPlayingPlayer.id + 1].scores} очков\nБросайте кубики!";
                foreach (var pb in pictureBoxes)
                {
                    //pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                    pb.Image = Image.FromFile($"unknown.png");

                    pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                    pb.Show();
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            var selected_card = sender as PictureBox;
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox

            foreach (var pb in pictureBoxes)
            {
                if (pb.BorderStyle == BorderStyle.FixedSingle) pb.BorderStyle = BorderStyle.None;
            }

            int id = Convert.ToInt32(selected_card.Name.Substring(selected_card.Name.Count() - 1));
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            selected_card.BorderStyle = BorderStyle.FixedSingle;
            //nowPlayingPlayer.scores += nowPlayingPlayer.cards[id];
            var cardValue = Convert.ToInt32(nowPlayingPlayer.cards[id - 1]);
            people[nowPlayingPlayer.id].notCombo = Convert.ToInt32(nowPlayingPlayer.cards[id - 1]);
            //notCombo = Convert.ToString(nowPlayingPlayer.cards.Where(n => n == cardValue).Sum());

            endTurn_btn.Enabled = true;
        }

        private void comboButton_Click(object sender, EventArgs e)
        {
            ComboForm comboForm = new ComboForm(people);
            comboForm.Show();
        }
        private void checkComboCards()
        {
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            string total_scores = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards));
            if (total_scores == "Большой генерал")
            {
                round_controller_label.Text = "Игра закончена!";
                pass_button.Enabled = false;
                UseBoxes_btn.Enabled = false;
                game_controller_label.Text = $"Игрок {nowPlayingPlayer.name} победил, выбросив 'Большого генерала'!";
                return;
            }
            if (total_scores == "False")
            {
                game_controller_label.Text = $"{nowPlayingPlayer.name}, Комбинации не выпало!\nБросок: {nowPlayingPlayer.diceState}";
            }
            else
            {
                var comboValue = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].cards));
                var lastcomboValue = Convert.ToString(EvaluateCombination(people[nowPlayingPlayer.id].lastCards));
                if (comboValue == lastcomboValue)
                {
                    game_controller_label.Text = $"{nowPlayingPlayer.name}, Выпало: {comboDict[Convert.ToInt32(comboValue)]} ({comboValue}). Комбинация уже была выброшена!\nБросок: {nowPlayingPlayer.diceState}";
                    pass_button.Enabled = false;
                    return;
                }
                game_controller_label.Text = $"{nowPlayingPlayer.name}, Выпало: {comboDict[Convert.ToInt32(comboValue)]} ({comboValue})\nБросок: {nowPlayingPlayer.diceState}";
                pass_button.Enabled = true;

            }
        }
        public void startPreparingRound()
        {
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            var cbs = new[] { box1, box2, box3, box4, box5 };
            for (int i = 0; i < 5; i++)
            {
                if (i == 2) continue;
                pictureBoxes[i].Visible = false;
                cbs[i].Visible = false;
            }
            pass_button.Visible = false;
            UseBoxes_btn.Visible = false;
            endTurn_btn.Visible = false;
            queue_btn.Visible = true;
            game_controller_label.Text = $"Ваша очередь {people[nowPlayingPlayer.id].name}\nБросайте кубик!";
            round_controller_label.Text = "Подготовительный раунд";

        }
        public void endPreparingRound()
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            var cbs = new[] { box1, box2, box3, box4, box5 };
            for (int i = 0; i < 5; i++)
            {

                pictureBoxes[i].Visible = true;
                cbs[i].Visible = true;
            }
            pass_button.Visible = true;
            UseBoxes_btn.Visible = true;
            pass_button.Enabled = false;
            UseBoxes_btn.Visible = true;

            people = sortPlayers();
            updateScores(people);
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            game_controller_label.Text = $"Ваша очередь {people[nowPlayingPlayer.id].name}\nБросайте кубик!";
            round_controller_label.Text = "Раунд 1";


        }
        public List<player> sortPlayers()
        {
            // Находим индекс игрока с минимальным номером
            int minIndex = people.FindIndex(p => p.notCombo == people.Min(p2 => p2.notCombo));
            // Извлекаем игрока с минимальным номером
            player minPlayer = people[minIndex];

            // Разделяем список на две части
            List<player> beforeMin = people.GetRange(0, minIndex);
            List<player> afterMin = people.GetRange(minIndex + 1, people.Count - minIndex - 1);

            // Создаем новый список согласно заданным критериям
            List<player> sortedPlayers = new List<player> { minPlayer };
            sortedPlayers.AddRange(afterMin);
            sortedPlayers.AddRange(beforeMin);
            for (int i = 0; i < sortedPlayers.Count;i++)
            {
                sortedPlayers[i].id = i;
                sortedPlayers[i].resetCards();
            }
            sortedPlayers[0].is_turn = true;
            return sortedPlayers;
        }
        public void notStartedGameFunc()
        {
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox

            if (nowPlayingPlayer.id == people.Count()-1) //Ластовый игрок
            {
                people[nowPlayingPlayer.id ].is_turn = false;

                
                foreach (var pb in pictureBoxes)
                {
                    //pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                    pb.Image = Image.FromFile($"unknown.png");

                    pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                    pb.Show();
                }
                isStarted = true;
                endPreparingRound();
            }
            else
            {
                people[nowPlayingPlayer.id].is_turn = false;
                people[nowPlayingPlayer.id + 1].is_turn = true;
                game_controller_label.Text = $"Ваша очередь {people[nowPlayingPlayer.id+1].name}\nБросайте кубик!";
                //pictureBoxes[2].Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                pictureBoxes[2].Image = Image.FromFile($"unknown.png");

                pictureBoxes[2].SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                pictureBoxes[2].Show();
                //foreach (var pb in pictureBoxes)
                //{
                //    pb.Image = Image.FromFile($"C:\\Users\\{Environment.UserName}\\source\\repos\\kosti\\kosti\\unknown.png");
                //    pb.SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
                //    pb.Show();
                //}
                queue_btn.Visible = true;
                endTurn_btn.Visible = false;
            }
        }

        private void queue_btn_Click(object sender, EventArgs e)
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            int current_box = random.Next(0, 6);
            people[nowPlayingPlayer.id].notCombo = current_box + 1;
            pictureBoxes[2].Image = Image.FromFile(imageFiles[current_box]);
            pictureBoxes[2].SizeMode = PictureBoxSizeMode.StretchImage; // Устанавливаем режим отображения, чтобы изображение масштабировалось
            pictureBoxes[2].Show();
            queue_btn.Visible = false;
            endTurn_btn.Visible = true;
            game_controller_label.Text = $"{people[nowPlayingPlayer.id].name}\nВыпало: {people[nowPlayingPlayer.id].notCombo}";

        }
        public void checkOnSameCards()
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            player nowPlayingPlayer = people.Find(o => o.is_turn == true);
            for (int i = 0;i<5;i++)
            {
               if (people[nowPlayingPlayer.id].cards[i] == people[nowPlayingPlayer.id].lastNotCombo)
                {
                    pictureBoxes[i].Enabled = false;
                    pictureBoxes[i].Image = Image.FromFile(grayImageFiles[people[nowPlayingPlayer.id].cards[i]-1]);
                }
            }
        }
        public void switchPictureBoxes(bool switcher)
        {
            var pictureBoxes = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 }; // Замените на имена ваших PictureBox
            foreach (var p in pictureBoxes)
            {
                p.Enabled = switcher;
                
            }
        }
    }
}
