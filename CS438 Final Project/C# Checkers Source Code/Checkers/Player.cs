using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Player
    {
        public string username;
        public string mark;
        public int wins = 0;
        public int losses = 0;

        public string GetName {
            get { return username; }
            set { username = value; }
        }
    }
}

