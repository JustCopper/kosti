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
        public int diceState = 1; 
        public bool is_turn = false;

        public player(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
