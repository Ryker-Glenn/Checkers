// CheckersTest.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include "gamecomm.h"
#include "Turn.h"
#include <vector>
#include <ctime>

using namespace std;

int turn = 0;

//void outputGameBoard(Piece n[8][8]) {
//	ofstream out("translated.txt");
//
//	if (turn == 1) { out << "Black took a move" << endl << endl; }
//	else if (turn == -1) { out << "Red took a move" << endl << endl; }
//
//	for (int i = 0; i < 8; i++) {
//		for (int j = 0; j < 8; j++) {
//			out << n[i][j].mark << " ";
//		}
//		out << endl;
//	}
//
//	out.close();
//}

int main() {
	Piece n[8][8];
	vector<Move> moves;
	Turn t;
	int frow = -1, fcol = -1, trow = -1, tcol = -1, random;

	turn = getGameBoard(n);
	state_t s = new board(n);
	/*outputGameBoard(n);*/
	moves = t.find_moves(s, turn);
	srand(time(NULL));

	if (moves.size() > 0) {
		for (int i = 0; i < moves.size(); i++) {
			if (moves[i].jump) {
				frow = moves[i].f.frow;
				fcol = moves[i].f.fcol;
				trow = moves[i].t.trow;
				tcol = moves[i].t.tcol;
				putMove(frow, fcol, trow, tcol);
				return 0;
			}
		}
		random = rand() % moves.size();
		frow = moves[random].f.frow;
		fcol = moves[random].f.fcol;
		trow = moves[random].t.trow;
		tcol = moves[random].t.tcol;
		putMove(frow, fcol, trow, tcol);
	}

	return 0;
}

