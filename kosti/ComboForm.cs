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
        public ComboForm(List<player> players)
        {
            InitializeComponent();
            
            // Настройка DataGridView
            DataTable dt = new DataTable();
            DataColumn emptyCell = new DataColumn("Комбинации");
            dt.Columns.Add(emptyCell);

            for (int i = 0;i < players.Count; i++)
            {
                DataColumn dataColumn = new DataColumn(players[i].name);
                dt.Columns.Add(dataColumn);
            }
            


           
            for (int i = 0; i < labels.Count; i++)
            {
                DataRow newRow = dt.NewRow();
                newRow["Комбинации"] = labels[i];
                dt.Rows.Add(newRow);
            }
            
            
            
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
