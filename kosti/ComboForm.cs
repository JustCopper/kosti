using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kosti
{
    public partial class ComboForm : Form
    {
        List<string> labels = new List<string>() { "Единицы", "Двойки", "Тройки","Четверки","Пятерки", "Шестёрки","Стрит", "Фул хаус", "Каре", "Генерал" };
        List<player> players = new List<player>();
        Dictionary<int, string> comboDict = new Dictionary<int, string>();
        
        public ComboForm(List<player> players)
        {
            InitializeComponent();
            comboDict[60] = "Малый генерал";
            comboDict[45] = "Каре";
            comboDict[40] = "Дособрано Каре";
            comboDict[35] = "Фулл хаус";
            comboDict[30] = "Дособран Фулл хаус ";
            comboDict[25] = "Стрит";
            comboDict[20] = "Дособран Стрит";
            

            this.players = players;
            // Настройка DataGridView
            DataTable dt = new DataTable();
            DataColumn emptyCell = new DataColumn("Комбинации");
            dt.Columns.Add(emptyCell);

            
            


           
            for (int i = 0; i < labels.Count; i++)
            {
                DataRow newRow = dt.NewRow();
                newRow["Комбинации"] = labels[i];
                dt.Rows.Add(newRow);
            }
            for (int i = 0; i < players.Count; i++)
            {
                DataColumn dataColumn = new DataColumn(players[i].name);
                dt.Columns.Add(dataColumn);
                
            }



            dataGridView1.DataSource = dt;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].notComboDice != 0) // Если комбо не выпало и выбрана цифра
                {
                    dataGridView1.Rows[players[i].notComboDice-1].Cells[i+1].Value = "*";

                }
            }
            }

        object EvaluateCombination(int[] combination)
        {
            player current_player = players.Find(o => o.is_turn == true);

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
                //return combination.Sum();
                return false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
