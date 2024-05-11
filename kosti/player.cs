using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosti
{
    public class player
    {
        string name;
        int scores = 0;

        bool is_turn = false;

        public player(string name)
        {
            this.name = name;
        }
    }
}
