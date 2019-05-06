using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers {
    class Move {
        private Grid current;
        private Grid next;
        private Grid jump;
        private int score;
        
        public Move() { score = 0; }

        public Grid Current {
            get { return current; }
            set { current = value; }
        }

        public Grid Next {
            get { return next; }
            set { next = value; }
        }

        public Grid Jump {
            get { return jump; }
            set { jump = value; }
        }

        public int Score {
            get { return score; }
            set { score = value; }
        }
    }
}
