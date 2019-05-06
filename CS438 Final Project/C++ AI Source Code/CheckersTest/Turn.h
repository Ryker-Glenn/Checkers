#pragma once
#include "gamecomm.h"
struct board {
	Piece m[8][8];	// 1, 0, -1
	int r, c, turn, h;	// the move that gets to this board
	board(Piece n[][8], int row = 8, int column = 8, int t = 1) {
		for (int k = 0; k < 8; k++)
			for (int l = 0; l < 8; l++)
				m[k][l] = n[k][l];
		r = row; c = column; turn = t;
	}
};

typedef board *state_t;

struct From {
	From() {}
	From(int r, int c) : frow(r), fcol(c) {}
	int frow;
	int fcol;
};

struct To {
	To() {}
	To(int r, int c) : trow(r), tcol(c) {}
	int trow;
	int tcol;
};

struct Move {
	Move(From from, To to) : f(from), t(to) {}
	From f;
	To t;
	bool jump = false;
};

class Turn {
public:
	Turn() {}
	~Turn() {}

	vector<Move> find_moves(state_t s, int turn) {
		vector<Move> moves;

		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				vector<Move> temp;
				if (s->m[i][j].mark == 'r' && !s->m[i][j].king && turn == -1) {
					temp = red_move(s, i, j);
					for (int k = 0; k < temp.size(); k++)
						moves.push_back(temp[k]);
				}
				if (s->m[i][j].mark == 'b' && !s->m[i][j].king && turn == 1) {
					temp = black_move(s, i, j);
					for (int k = 0; k < temp.size(); k++)
						moves.push_back(temp[k]);
				}
				if (s->m[i][j].mark == 'r' && s->m[i][j].king && turn == -1) {
					temp = red_king_move(s, i, j);
					for (int k = 0; k < temp.size(); k++)
						moves.push_back(temp[k]);
				}
				if (s->m[i][j].mark == 'b' && s->m[i][j].king && turn == 1) {
					temp = black_king_move(s, i, j);
					for (int k = 0; k < temp.size(); k++)
						moves.push_back(temp[k]);
				}
			}
		}

		return moves;
	}

private:

	vector<Move> red_move(state_t s, int i, int j) {
		vector<Move> m;
		if (i < 6) {
			// if red's piece is farthest left edge
			if (j == 0) {
				// forward move
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j + 2].mark == ' ' && s->m[i + 1][j + 1].mark == 'b') {
					From f(i, j);
					To t(i + 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 1) {
				// forward move
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j + 2].mark == ' ' && s->m[i + 1][j + 1].mark == 'b') {
					From f(i, j);
					To t(i + 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is not edge piece
			if (j > 1 && j < 6) {
				// forward move
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j + 2].mark == ' ' && s->m[i + 1][j + 1].mark == 'b') {
					From f(i, j);
					To t(i + 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
				if (s->m[i + 2][j - 2].mark == ' ' && s->m[i + 1][j - 1].mark == 'b') {
					From f(i, j);
					To t(i + 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 6) {
				// forward move
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j - 2].mark == ' ' && s->m[i + 1][j - 1].mark == 'b') {
					From f(i, j);
					To t(i + 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is farthest right edge piece
			if (j == 7) {
				// forward move
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j - 2].mark == ' ' && s->m[i + 1][j - 1].mark == 'b') {
					From f(i, j);
					To t(i + 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
		}
		// for king moves
		if (i == 6) {
			if (j == 0) {
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j >= 1 && j <= 6) {
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j == 7) {
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
		}
		return m;
	}

	vector<Move> black_move(state_t s, int i, int j) {
		vector<Move> m;
		if (i > 1) {
			// if red's piece is farthest left edge
			if (j == 0) {
				// forward move
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j + 2].mark == ' ' && s->m[i - 1][j + 1].mark == 'r') {
					From f(i, j);
					To t(i - 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 1) {
				// forward move
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j + 2].mark == ' ' && s->m[i - 1][j + 1].mark == 'r') {
					From f(i, j);
					To t(i - 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is not edge piece
			if (j > 1 && j < 6) {
				// forward move
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j + 2].mark == ' ' && s->m[i - 1][j + 1].mark == 'r') {
					From f(i, j);
					To t(i - 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
				if (s->m[i - 2][j - 2].mark == ' ' && s->m[i - 1][j - 1].mark == 'r') {
					From f(i, j);
					To t(i - 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 6) {
				// forward move
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j - 2].mark == ' ' && s->m[i - 1][j - 1].mark == 'r') {
					From f(i, j);
					To t(i - 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is farthest right edge piece
			if (j == 7) {
				// forward move
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j - 2].mark == ' ' && s->m[i - 1][j - 1].mark == 'r') {
					From f(i, j);
					To t(i - 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
		}
		// for king moves
		if (i == 1) {
			if (j == 0) {
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j >= 1 && j <= 6) {
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j == 7) {
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
		}
		return m;
	}

	vector<Move> red_back(state_t s, int i, int j) {
		vector<Move> m;
		if (i > 1) {
			// if red's piece is farthest left edge
			if (j == 0) {
				// forward move
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j + 2].mark == ' ' && s->m[i - 1][j + 1].mark == 'b') {
					From f(i, j);
					To t(i - 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 1) {
				// forward move
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j + 2].mark == ' ' && s->m[i - 1][j + 1].mark == 'b') {
					From f(i, j);
					To t(i - 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is not edge piece
			if (j > 1 && j < 6) {
				// forward move
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j + 2].mark == ' ' && s->m[i - 1][j + 1].mark == 'b') {
					From f(i, j);
					To t(i - 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
				if (s->m[i - 2][j - 2].mark == ' ' && s->m[i - 1][j - 1].mark == 'b') {
					From f(i, j);
					To t(i - 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 6) {
				// forward move
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j - 2].mark == ' ' && s->m[i - 1][j - 1].mark == 'b') {
					From f(i, j);
					To t(i - 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is farthest right edge piece
			if (j == 7) {
				// forward move
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i - 2][j - 2].mark == ' ' && s->m[i - 1][j - 1].mark == 'b') {
					From f(i, j);
					To t(i - 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
		}
		// for king moves
		if (i == 1) {
			if (j == 0) {
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j >= 1 && j <= 6) {
				if (s->m[i - 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j == 7) {
				if (s->m[i - 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i - 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
		}
		return m;
	}

	vector<Move> black_back(state_t s, int i, int j) {
		vector<Move> m;
		if (i < 6) {
			// if red's piece is farthest left edge
			if (j == 0) {
				// forward move
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j + 2].mark == ' ' && s->m[i + 1][j + 1].mark == 'r') {
					From f(i, j);
					To t(i + 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 1) {
				// forward move
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j + 2].mark == ' ' && s->m[i + 1][j + 1].mark == 'r') {
					From f(i, j);
					To t(i + 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is not edge piece
			if (j > 1 && j < 6) {
				// forward move
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j + 2].mark == ' ' && s->m[i + 1][j + 1].mark == 'r') {
					From f(i, j);
					To t(i + 2, j + 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
				if (s->m[i + 2][j - 2].mark == ' ' && s->m[i + 1][j - 1].mark == 'r') {
					From f(i, j);
					To t(i + 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			if (j == 6) {
				// forward move
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j - 2].mark == ' ' && s->m[i + 1][j - 1].mark == 'r') {
					From f(i, j);
					To t(i + 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
			// if red's piece is farthest right edge piece
			if (j == 7) {
				// forward move
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
				// forward jump
				if (s->m[i + 2][j - 2].mark == ' ' && s->m[i + 1][j - 1].mark == 'r') {
					From f(i, j);
					To t(i + 2, j - 2);
					Move k(f, t);
					k.jump = true;
					m.push_back(k);
				}
			}
		}
		// for king moves
		if (i == 6) {
			if (j == 0) {
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j >= 1 && j <= 6) {
				if (s->m[i + 1][j + 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j + 1);
					Move k(f, t);
					m.push_back(k);
				}
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
			if (j == 7) {
				if (s->m[i + 1][j - 1].mark == ' ') {
					From f(i, j);
					To t(i + 1, j - 1);
					Move k(f, t);
					m.push_back(k);
				}
			}
		}
		return m;
	}

	vector<Move> red_king_move(state_t s, int i, int j) {
		vector<Move> forward_move = red_move(s, i, j);
		vector<Move> backward_move = red_back(s, i, j);
		vector<Move> all_moves;

		for (int m = 0; m < forward_move.size(); m++) 
			all_moves.push_back(forward_move[m]);

		for (int m = 0; m < backward_move.size(); m++) 
			all_moves.push_back(backward_move[m]);

		return all_moves;
	}

	vector<Move> black_king_move(state_t s, int i, int j) {
		vector<Move> forward_move = black_move(s, i, j);
		vector<Move> backward_move = black_back(s, i, j);
		vector<Move> all_moves;

		for (int m = 0; m < forward_move.size(); m++) 
			all_moves.push_back(forward_move[m]);

		for (int m = 0; m < backward_move.size(); m++)
			all_moves.push_back(backward_move[m]);

		return all_moves;
	}
};