using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosti
{
    public class player
    {
        public int id;
        public string name;
        public int scores = 0;
        public int diceState = 0; 
        public bool is_turn = false;
        public int[] cards = new int[5];
        public int[] lastCards = new int[5];
        public int notCombo = 0;
        public int lastNotCombo = 0;

        public player(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public void setCards(int[] cards)
        {
            this.cards = cards;
        }
        public void resetCards()
        {
            this.cards = new int[5];
            this.notCombo = 0;
        }
        public void setLastCards(int[] lastCards)
        {
            this.lastCards = lastCards;
            this.lastNotCombo = 0;
        }
        public void setLastCards(int lastCards)
        {
            this.lastNotCombo = lastCards;
            this.lastCards = new int[5];
        }
        //public bool isCombo()
        //{
        //    return this.notCombo == 0 ? true : false;
        //}
        public bool isCombo() //Функция по определению комбинаций,передаем сюда кубики игрока
        {
            int[] combination = this.cards;
            //player current_player = people.Find(o => o.is_turn == true); // Теккущий игрок который ходит
            if (combination.Any(x => x == 0)) return false;

            // Стрейт
            if (combination.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }) || combination.SequenceEqual(new int[] { 2, 3, 4, 5, 6 }) || combination.SequenceEqual(new int[] { 1, 3, 4, 5, 6 }) || combination.SequenceEqual(new int[] { 1, 2, 3, 4, 5 }))
            {
                //int score = current_player.diceState == 1 ? 25 : 20; //Если комбинация выброшена 1 броском - больше баллов.
                return true;
            }
            // Фул-хаус
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 3) == 1 && combination.GroupBy(x => x).Count(g => g.Count() == 2) == 1)
            {
                //int score = current_player.diceState == 1 ? 35 : 30;//Если комбинация выброшена 1 броском - больше баллов.
                return true;
            }
            // Четыре одинарных числа (флеш?)
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 4) == 1)
            {
                //int score = current_player.diceState == 1 ? 45 : 40;//Если комбинация выброшена 1 броском - больше баллов.
                return true;
            }
            // Пять одинарных чисел (большой генерал)
            else if (combination.GroupBy(x => x).Count(g => g.Count() == 5) == 1)
            {
                //return current_player.diceState == 1 ? "Большой генерал" : 60;//Если комбинация выброшена 1 броском - больше баллов.
                return true;
            }
            else // Комбинации нет
            {

                return false;
            }
        }
    }
    
}
