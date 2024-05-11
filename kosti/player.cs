using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosti
{
    public class player
    {
        public string name;
        public int scores = 0;
        public int diceState = 0; //0 - Первый бросок, 1 - второй, 2- третий
        public bool is_turn = false;

        public player(string name)
        {
            this.name = name;
        }
    }
}
