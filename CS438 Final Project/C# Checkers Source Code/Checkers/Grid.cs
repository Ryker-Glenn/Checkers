using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{

    public class Grid
    {
        private Button piece;
        private char mark;
        private bool king;
        private int row;
        private int col;
        private int score;

        public Grid() { }

        public Grid(Button _box, char _mark, int _row, int _col)
        {
            piece = _box;
            mark = _mark;
            row = _row;
            col = _col;
            score = 0;
        }

        public Button GetButton {
            get { return piece; }
            set { piece = value; }
        }

        public char Mark {
            get { return mark; }
            set { mark = value; }
        }

        public int Row {
            get { return row; }
            set { row = value; }
        }

        public int Col {
            get { return col; }
            set { col = value; }
        }

        public bool King {
            get { return king; }
            set { king = value; }
        }

        public int Score {
            get { return score; }
            set { score = value; }
        }
    }

}
