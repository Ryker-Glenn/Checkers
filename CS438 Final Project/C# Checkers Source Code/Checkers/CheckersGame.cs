using System;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Checkers {
    public partial class CheckersGame : Form {

        Grid[,] buttons = new Grid[8, 8];   // Button Grid used to identify pieces/status
        bool turn = true;                   // turn taken, turn = black !turn = red
        private Grid selectedPiece;         // Piece selected 
        private Grid moveToSquare;          // Square chosen to move to
        string b = "";                      // file to run from black side
        string r = "";                      // file to run from red side
        bool pVAI = false;                  // if red has a file and black doesn't, black is the user and the user will have the first turn
        bool aIVP = false;                  // vice versa of above
        
        public CheckersGame() {
            InitializeComponent();
        }

        // Instantiate the initial game board
        private void Board_Load(object sender, EventArgs e) {
            buttons[0, 0] = new Grid(square1, 'r', 0, 0);
            buttons[0, 1] = new Grid(dead1, '-', 0, 1);
            buttons[0, 2] = new Grid(square2, 'r', 0, 2);
            buttons[0, 3] = new Grid(dead2, '-', 0, 3);
            buttons[0, 4] = new Grid(square3, 'r', 0, 4);
            buttons[0, 5] = new Grid(dead3, '-', 0, 5);
            buttons[0, 6] = new Grid(square4, 'r', 0, 6);
            buttons[0, 7] = new Grid(dead4, '-', 0, 7);

            buttons[1, 0] = new Grid(dead5, '-', 1, 0);
            buttons[1, 1] = new Grid(square5, 'r', 1, 1);
            buttons[1, 2] = new Grid(dead6, '-', 1, 2);
            buttons[1, 3] = new Grid(square6, 'r', 1, 3);
            buttons[1, 4] = new Grid(dead7, '-', 1, 4);
            buttons[1, 5] = new Grid(square7, 'r', 1, 5);
            buttons[1, 6] = new Grid(dead8, '-', 1, 6);
            buttons[1, 7] = new Grid(square8, 'r', 1, 7);

            buttons[2, 0] = new Grid(square9, 'r', 2, 0);
            buttons[2, 1] = new Grid(dead9, '-', 2, 1);
            buttons[2, 2] = new Grid(square10, 'r', 2, 2);
            buttons[2, 3] = new Grid(dead10, '-', 2, 3);
            buttons[2, 4] = new Grid(square11, 'r', 2, 4);
            buttons[2, 5] = new Grid(dead11, '-', 2, 5);
            buttons[2, 6] = new Grid(square12, 'r', 2, 6);
            buttons[2, 7] = new Grid(dead12, '-', 2, 7);

            buttons[3, 0] = new Grid(dead13, '-', 3, 0);
            buttons[3, 1] = new Grid(square13, ' ', 3, 1);
            buttons[3, 2] = new Grid(dead14, '-', 3, 2);
            buttons[3, 3] = new Grid(square14, ' ', 3, 3);
            buttons[3, 4] = new Grid(dead15, '-', 3, 4);
            buttons[3, 5] = new Grid(square15, ' ', 3, 5);
            buttons[3, 6] = new Grid(dead16, '-', 3, 6);
            buttons[3, 7] = new Grid(square16, ' ', 3, 7);

            buttons[4, 0] = new Grid(square17, ' ', 4, 0);
            buttons[4, 1] = new Grid(dead17, '-', 4, 1);
            buttons[4, 2] = new Grid(square18, ' ', 4, 2);
            buttons[4, 3] = new Grid(dead18, '-', 4, 3);
            buttons[4, 4] = new Grid(square19, ' ', 4, 4);
            buttons[4, 5] = new Grid(dead19, '-', 4, 5);
            buttons[4, 6] = new Grid(square20, ' ', 4, 6);
            buttons[4, 7] = new Grid(dead20, '-', 4, 7);

            buttons[5, 0] = new Grid(dead21, '-', 5, 0);
            buttons[5, 1] = new Grid(square21, 'b', 5, 1);
            buttons[5, 2] = new Grid(dead22, '-', 5, 2);
            buttons[5, 3] = new Grid(square22, 'b', 5, 3);
            buttons[5, 4] = new Grid(dead23, '-', 5, 4);
            buttons[5, 5] = new Grid(square23, 'b', 5, 5);
            buttons[5, 6] = new Grid(dead24, '-', 5, 6);
            buttons[5, 7] = new Grid(square24, 'b', 5, 7);

            buttons[6, 0] = new Grid(square25, 'b', 6, 0);
            buttons[6, 1] = new Grid(dead25, '-', 6, 1);
            buttons[6, 2] = new Grid(square26, 'b', 6, 2);
            buttons[6, 3] = new Grid(dead26, '-', 6, 3);
            buttons[6, 4] = new Grid(square27, 'b', 6, 4);
            buttons[6, 5] = new Grid(dead27, '-', 6, 5);
            buttons[6, 6] = new Grid(square28, 'b', 6, 6);
            buttons[6, 7] = new Grid(dead28, '-', 6, 7);

            buttons[7, 0] = new Grid(dead29, '-', 7, 0);
            buttons[7, 1] = new Grid(square29, 'b', 7, 1);
            buttons[7, 2] = new Grid(dead30, '-', 7, 2);
            buttons[7, 3] = new Grid(square30, 'b', 7, 3);
            buttons[7, 4] = new Grid(dead31, '-', 7, 4);
            buttons[7, 5] = new Grid(square31, 'b', 7, 5);
            buttons[7, 6] = new Grid(dead32, '-', 7, 6);
            buttons[7, 7] = new Grid(square32, 'b', 7, 7);

            FillGrid();
        }

        // Disable play until user starts the game
        private void FillGrid() {
            try {
                for (int i = 0; i < 8; i++) {
                    for (int j = 0; j < 8; j++) {
                        if (buttons[i, j].Mark == 'r') {
                            buttons[i, j].GetButton.Image = Checkers.Properties.Resources.red11;
                            buttons[i, j].GetButton.Enabled = false;
                        } else if (buttons[i, j].Mark == 'b') {
                            buttons[i, j].GetButton.Image = Checkers.Properties.Resources.b1ack11;
                            buttons[i, j].GetButton.Enabled = false;
                        } else if (buttons[i, j].GetButton.BackColor == Color.Red) {
                            buttons[i, j].GetButton.Enabled = false;
                        } else {
                            buttons[i, j].GetButton.Image = null;

                        }
                    }
                }
            } catch (IndexOutOfRangeException) {
                MessageBox.Show("Error: please click 'X' in Program Window and exit.");
            }
        }

        // Find a file for black side on browse click
        private void blackBrowse_Click(object sender, EventArgs e) {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                blackExe.Text = openFileDialog1.FileName;
            }
        }

        // Find a file for red side on browse click
        private void redBrowse_Click(object sender, EventArgs e) {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                redExe.Text = openFileDialog1.FileName;
            }
        }

        // start the game and determine how the game is going to be played
        private void startBtn_Click(object sender, EventArgs e) {
            redExe.Enabled = false;
            redBrowse.Enabled = false;
            blackExe.Enabled = false;
            blackBrowse.Enabled = false;
            r = redExe.Text;
            b = blackExe.Text;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (buttons[i, j].GetButton.BackColor != Color.Red) {
                        buttons[i, j].GetButton.Enabled = true;
                    }
                }
            }
            if (redExe.Text != "" && blackExe.Text != "") {
                AiVsAi(r, b);
            } else if (r == "" && b != "") {
                aIVP = true;
                AiVsPlayer(b);
            } else if (b == "" && r != "") {
                pVAI = true;
            }
        }

        // If a user clicks a button, determine if it is a good click
        private void Mouse_Click(object sender, MouseEventArgs e) {
            redExe.Enabled = false;
            redBrowse.Enabled = false;
            blackExe.Enabled = false;
            blackBrowse.Enabled = false;
            Button currentbutton = (Button)sender;
            PlayerVsPlayer(currentbutton);

        }

        // This function is the driver for the ai vs human user
        // alternating turns depending on which files were entered
        private void AiVsPlayer(string file) {
            int winner = 0;
            int[] m;
            int k = 0;
            if (file == r) {
                SetBoard();
                var redRun = Process.Start(file);
                redRun.WaitForExit();
                m = GetMove();
                winner = TakeTurn(m);
                turn = !turn;
                SetTurn();
                while (k != 1000000) {
                    k++;
                }
            } else if (file == b) {
                SetBoard();
                Process blackRun = Process.Start(file);
                blackRun.WaitForExit();
                m = GetMove();
                winner = TakeTurn(m);
                turn = !turn;
                SetTurn();
                while (k != 1000000) {
                    k++;
                }
            }
            if (winner == 0) { winner = IsWinner(); }
        }

        // Function driver for player vs player
        private void PlayerVsPlayer(Button currentButton) {
            int move;
            int winner = IsWinner();
            // if piece has been selected
            if (selectedPiece != null) {
                // find selected square in button list and check if the selected move is legal
                moveToSquare = FindPiece(currentButton);
                move = IsLegal(selectedPiece, moveToSquare, turn);
                if (move == 1) {
                    MakeMove();
                    turn = !turn;
                } else if (move == 2) {
                    MakeJump();
                    winner = IsWinner();
                    while (HasAnotherJump(moveToSquare)) {; }
                    turn = !turn;
                }
                SetTurn();
            } else { SetPiece(currentButton); }

            if (pVAI && !turn) {
                AiVsPlayer(r);
            } else if (aIVP && turn) {
                AiVsPlayer(b);
            }
            if (winner == 1) { MessageBox.Show("Black Wins"); }
            if (winner == 2) { MessageBox.Show("Red Wins"); }
        }

        // Ai vs Ai driver if two executables are entered
        private void AiVsAi(string black, string red) {
            int winner = 0;
            int[] m;
            while (winner == 0) {
                if (turn) {
                    SetBoard();
                    Process blackRun = Process.Start(black);
                    blackRun.WaitForExit();
                    m = GetMove();
                    winner = TakeTurn(m);
                    turn = !turn;
                    SetTurn();
                } else {
                    SetBoard();
                    var redRun = Process.Start(red);
                    redRun.WaitForExit();
                    m = GetMove();
                    winner = TakeTurn(m);
                    turn = !turn;
                    SetTurn();
                }
                if (winner == 0) { winner = IsWinner(); }
                Thread.SpinWait(10000000);
            }

            if (winner == 1) { MessageBox.Show("Black Wins"); }
            if (winner == 2) { MessageBox.Show("Red Wins"); }

        }

        // Checks for winner of the game
        private int IsWinner() {
            int winner = 0;
            int bpieces = 0;
            int rpieces = 0;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (buttons[i, j].Mark == 'b') {
                        bpieces++;
                    }
                    if (buttons[i, j].Mark == 'r') {
                        rpieces++;
                    }
                }
            }
            piecesLbl.Text = bpieces.ToString();
            guestPiecesLbl.Text = rpieces.ToString();
            if (bpieces == 0) {
                winner = 2;
            }
            if (rpieces == 0) {
                winner = 1;
            }
            return winner;
        }

        // Set up a text file representation of the board 
        // for the external executable to use
        private void SetBoard() {
            string line;
            string[] lines = new string[9];
            int i = 0;
            for (i = 0; i < 8; i++) {
                line = "";
                if (buttons[i, 0].Mark == 'b' && buttons[i, 0].King) {
                    line += "B";
                } else if (buttons[i, 0].Mark == 'r' && buttons[i, 0].King) {
                    line += "R";
                } else {
                    line += buttons[i, 0].Mark;
                }
                for (int j = 1; j < 8; j++) {
                    if (buttons[i, j].Mark == 'b' && buttons[i, j].King) {
                        line += ",B";
                    } else if (buttons[i, j].Mark == 'r' && buttons[i, j].King) {
                        line += ",R";
                    } else {
                        line += "," + buttons[i, j].Mark;
                    }
                }
                lines[i] = line;
            }

            lines[i++] = (turn) ? "b" : "r";
            File.WriteAllLines("board.txt", lines);
        }

        // Take the move from the move file that
        // the externalexecutable worked out
        private int[] GetMove() {
            int i = 0;
            int[] move = new int[4];
            string text = File.ReadAllText("move.txt");
            File.AppendAllText("Log.txt", text);
            string[] words = text.Split(' ');

            foreach (var w in words) {
                move[i++] = Int32.Parse(w);
            }
            return move;
        }

        // Make the move on the board if the move is legal
        // if the move wasn't legal, output in a message box
        private int TakeTurn(int[] m) {
            int move;
            selectedPiece = buttons[m[0], m[1]];
            moveToSquare = buttons[m[2], m[3]];

            move = IsLegal(selectedPiece, moveToSquare, turn);
            if (move == 1) {
                MakeMove();
                return 0;
            } else if (move == 2) {
                MakeJump();
                while (HasAnotherJump(moveToSquare)) {; }
                return 0;
            } else {
                if (turn) {
                    MessageBox.Show("Red won because black made a bad move");
                    return 2;
                } else {
                    MessageBox.Show("Black won because red made a bad move");
                    return 1;
                }
            }
        }

        // Work out if move is legal based
        // upon whose turnand pieces selected
        private int IsLegal(Grid s, Grid m, bool turn) {
            if (s.Mark == 'b' && turn && !s.King) 
                return BlackMove(s, m);

            if (s.Mark == 'r' && !turn && !s.King) 
                return RedMove(s, m);
            
            if (s.Mark == 'b' && turn && s.King) 
                return BlackKing(s, m);
            
            if (s.Mark == 'r' && !turn && s.King) 
                return RedKing(s, m);
            
            return 0;
        }

        // If the piece is a red man, check 
        // if the move selected is valid
        private int RedMove(Grid s, Grid m) {
            if (s.Col == 0) {
                if (s.Row + 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') {
                    return 1;
                }
                if (s.Row + 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 1) {
                if ((s.Row + 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') ||
                    (s.Row + 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ')) {
                    return 1;
                }
                if (s.Row + 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col > 1 && s.Col < 6) {
                if ((s.Row + 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') ||
                    (s.Row + 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ')) {
                    return 1;
                }
                if ((s.Row + 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'b' && m.Mark == ' ') ||
                    (s.Row + 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row + 1, s.Col - 1].Mark == 'b' && m.Mark == ' ')) {
                    return 2;
                }
            }
            if (s.Col == 6) {
                if ((s.Row + 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') ||
                    (s.Row + 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ')) {
                    return 1;
                }
                if (s.Row + 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row + 1, s.Col - 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 7) {
                if (s.Row + 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ') {
                    return 1;
                }
                if (s.Row + 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row + 1, s.Col - 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            return 0;
        }

        // If the piece is a black man, check
        // if the move selected is valid
        private int BlackMove(Grid s, Grid m) {
            if (s.Col == 0) {
                if (s.Row - 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') {
                    return 1;
                }
                if (s.Row - 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row - 1, s.Col + 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 1) {
                if ((s.Row - 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') ||
                    (s.Row - 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ')) {
                    return 1;
                }
                if (s.Row - 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row - 1, s.Col + 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col > 1 && s.Col < 6) {
                if ((s.Row - 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') ||
                    (s.Row - 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ')) {
                    return 1;
                }
                if ((s.Row - 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row - 1, s.Col + 1].Mark == 'r' && m.Mark == ' ') ||
                    (s.Row - 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row - 1, s.Col - 1].Mark == 'r' && m.Mark == ' ')) {
                    return 2;
                }
            }
            if (s.Col == 6) {
                if ((s.Row - 1 == m.Row && s.Col + 1 == m.Col && m.Mark == ' ') ||
                    (s.Row - 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ')) {
                    return 1;
                }
                if (s.Row - 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row - 1, s.Col - 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 7) {
                if (s.Row - 1 == m.Row && s.Col - 1 == m.Col && m.Mark == ' ') {
                    return 1;
                }
                if (s.Row - 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row - 1, s.Col - 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            return 0;
        }

        // Checks if the king's move is valid
        private int RedKing(Grid s, Grid m) {
            int move = 0;
            if (s.Row < m.Row) {
                move = RedMove(s, m);
            }
            if (s.Row > m.Row) {
                move = BlackMove(s, m);
            }
            if (s.Col == 0) {
                if (s.Row - 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 1) {
                if (s.Row - 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row - 1, s.Col + 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col > 1 && s.Col < 6) {
                if ((s.Row - 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row - 1, s.Col + 1].Mark == 'b' && m.Mark == ' ') ||
                    (s.Row - 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row - 1, s.Col - 1].Mark == 'b' && m.Mark == ' ')) {
                    return 2;
                }
            }
            if (s.Col == 6) {
                if (s.Row - 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row - 1, s.Col - 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 7) {
                if (s.Row - 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row - 1, s.Col - 1].Mark == 'b' && m.Mark == ' ') {
                    return 2;
                }
            }
            return move;
        }

        // Checks if the king's move is valid
        private int BlackKing(Grid s, Grid m) {
            int move = 0;
            if (s.Row < m.Row) {
                move = RedMove(s, m);
            }
            if (s.Row > m.Row) {
                move = BlackMove(s, m);
            }
            if (s.Col == 0) {
                if (s.Row + 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 1) {
                if (s.Row + 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col > 1 && s.Col < 6) {
                if ((s.Row + 2 == m.Row && s.Col + 2 == m.Col && buttons[s.Row + 1, s.Col + 1].Mark == 'r' && m.Mark == ' ') ||
                    (s.Row + 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row + 1, s.Col - 1].Mark == 'r' && m.Mark == ' ')) {
                    return 2;
                }
            }
            if (s.Col == 6) {
                if (s.Row + 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row + 1, s.Col - 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            if (s.Col == 7) {
                if (s.Row + 2 == m.Row && s.Col - 2 == m.Col && buttons[s.Row + 1, s.Col - 1].Mark == 'r' && m.Mark == ' ') {
                    return 2;
                }
            }
            return move;
        }

        // swap the images on the board
        private void MakeMove() {
            Image temp = selectedPiece.GetButton.Image;         // temp image set to previously selected piece
            selectedPiece.GetButton.Image = null;               // blank out where selected piece was
            moveToSquare.GetButton.Image = temp;                // set selected legal move to checker piece
            selectedPiece.GetButton.BackColor = Color.Black;
            if (selectedPiece.King) {
                buttons[selectedPiece.Row, selectedPiece.Col].King = false;
                buttons[moveToSquare.Row, moveToSquare.Col].King = true;
            }
            moveToSquare.Mark = selectedPiece.Mark;
            selectedPiece.Mark = ' ';
            CheckKing();
        }

        // If the move is a jump, make the move on the board
        private void MakeJump() {
            int srow = 0, scol = 0;
            int trow = 0, tcol = 0;
            int bwrow = 0, bwcol = 0;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (selectedPiece.GetButton.Name == buttons[i, j].GetButton.Name) {
                        srow = i;
                        scol = j;
                    }
                    if (moveToSquare.GetButton.Name == buttons[i, j].GetButton.Name) {
                        trow = i;
                        tcol = j;
                    }
                }
            }
            bwrow = (srow + trow) / 2;
            bwcol = (scol + tcol) / 2;
            buttons[bwrow, bwcol].GetButton.Image = null;
            buttons[bwrow, bwcol].Mark = ' ';
            MakeMove();
            // find the piece jumped by taking the average of the row and the column
            
        }

        // If the move is another jump, make it before 
        // turning over turn
        private bool HasAnotherJump(Grid moved) {
            if (turn && moved.Mark == 'b' && !moved.King) {
                if (moved.Row > 1) {
                    if (moved.Col == 0) {
                        if (buttons[moved.Row - 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col + 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col > 1 && moved.Col < 6) {
                        if (buttons[moved.Row - 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col + 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                        if (buttons[moved.Row - 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col - 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col == 7) {
                        if (buttons[moved.Row - 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col - 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                }
            }
            if (!turn && moved.Mark == 'r' && !moved.King) {
                if (moved.Row < 6) {
                    if (moved.Col == 0) {
                        if (buttons[moved.Row + 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col + 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col > 1 && moved.Col < 6) {
                        if (buttons[moved.Row + 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col + 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                        if (buttons[moved.Row + 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col - 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col == 7) {
                        if (buttons[moved.Row + 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col - 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                }
            }
            if (turn && moved.Mark == 'b' && moved.King) {
                if (moved.Row > 1) {
                    if (moved.Col == 0) {
                        if (buttons[moved.Row - 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col + 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col > 1 && moved.Col < 6) {
                        if (buttons[moved.Row - 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col + 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                        if (buttons[moved.Row - 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col - 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col == 7) {
                        if (buttons[moved.Row - 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col - 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                }
                if (moved.Row < 6) {
                    if (moved.Col == 0) {
                        if (buttons[moved.Row + 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col + 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col > 1 && moved.Col < 6) {
                        if (buttons[moved.Row + 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col + 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                        if (buttons[moved.Row + 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col - 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col == 7) {
                        if (buttons[moved.Row + 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col - 1].Mark == 'r') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                }
            }
            if (!turn && moved.Mark == 'r' && moved.King) {
                if (moved.Row > 1) {
                    if (moved.Col == 0) {
                        if (buttons[moved.Row - 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col + 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col > 1 && moved.Col < 6) {
                        if (buttons[moved.Row - 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col + 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                        if (buttons[moved.Row - 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col - 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col == 7) {
                        if (buttons[moved.Row - 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row - 1, moved.Col - 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row - 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                }
                if (moved.Row < 6) {
                    if (moved.Col == 0) {
                        if (buttons[moved.Row + 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col + 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col > 1 && moved.Col < 6) {
                        if (buttons[moved.Row + 2, moved.Col + 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col + 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col + 2];
                            MakeJump();
                            return true;
                        }
                        if (buttons[moved.Row + 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col - 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                    if (moved.Col == 7) {
                        if (buttons[moved.Row + 2, moved.Col - 2].GetButton.Image == null && buttons[moved.Row + 1, moved.Col - 1].Mark == 'b') {
                            selectedPiece = moved;
                            moveToSquare = buttons[moved.Row + 2, moved.Col - 2];
                            MakeJump();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Reset buttons so the opponent user
        // has a clean slate
        private void SetTurn() {
            selectedPiece.GetButton.BackColor = Color.Black;
            selectedPiece = null;
            moveToSquare = null;
        }

        // If the man has become a king
        // display it on board
        private void CheckKing() {
            if (turn && moveToSquare.Row == 0) {
                moveToSquare.GetButton.Image = Checkers.Properties.Resources.black_king;
                buttons[moveToSquare.Row, moveToSquare.Col].King = true;
            }
            if (!turn && moveToSquare.Row == 7) {
                moveToSquare.GetButton.Image = Checkers.Properties.Resources.red_king;
                buttons[moveToSquare.Row, moveToSquare.Col].King = true;
            }
        }

        // Finds the button that the user clicked on the board
        Grid FindPiece(Button clicked) {
            Grid piece = null;
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    if (clicked.Name == buttons[i, j].GetButton.Name) {
                        piece = buttons[i, j];
                        break;
                    }
                }
            }
            return piece;
        }

        // ends the game
        private void quitBtn_Click(object sender, EventArgs e) {
            CheckersGame gm = new CheckersGame();
            gm.Show();
            this.Close();
        }

        // Set the piece from the grid corresponding
        // to the user's click
        private void SetPiece(Button button) {
            selectedPiece = FindPiece(button);
            if (turn && selectedPiece.Mark == 'b') {
                selectedPiece.GetButton.BackColor = Color.GreenYellow;
            }
            if (!turn && selectedPiece.Mark == 'r') {
                selectedPiece.GetButton.BackColor = Color.GreenYellow;
            }
        }

        // If a button is not clicked by the user, 
        // do nothing instead of throwing an error
        private void Picture_Click(object sender, MouseEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
