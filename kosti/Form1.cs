namespace kosti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Если нет, то считаем событие обработанным и не записываем символ
                e.Handled = true;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            int players = int.Parse(textBox1.Text);
            GameForm gameForm = new GameForm(players);
            gameForm.Show();
            this.Hide();
        }
    }
}
