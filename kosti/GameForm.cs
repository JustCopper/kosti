using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kosti
{
    public partial class GameForm : Form
    {
        public GameForm(int players)
        {
            List<player> people = new List<player>();
            for (int i = 0; i < players; i++)
            {
                player player = new player($"player{i}");
                people.Add(player);
            }
            // Бросаем 5 костей
            //for (int i = 0; i < 5; i++)
            //{
            //    int diceRoll = random.Next(1, 7); // Генерируем случайное число от 1 до 6
            //    Console.WriteLine($"Кубик {i + 1} показывает: {diceRoll}");
            //    totalScore += diceRoll;
            //}
            InitializeComponent();
        }
        public updateScores
    }
}
