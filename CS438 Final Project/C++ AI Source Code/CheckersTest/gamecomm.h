#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <cstdlib>
#include <sstream>
#include <vector>
#define ROWS 8
#define COLS 8

using namespace std;

struct Piece {
	Piece() {}
	char mark;
	bool king = false;
};

int getGameBoard(Piece gameBoard[ROWS][COLS]) {
	string current, inter;
	ifstream in("board.txt");
	int i = 0;
	int turn = 0;
	while (getline(in, current)) {
		Piece c;
		vector<string> tokens;
		stringstream tkns(current);
		while (getline(tkns, inter, ',')) {
			tokens.push_back(inter);
		}
		
		if (tokens.size() == 1) {
			if (tokens[0] == "b") 
				turn = 1;
			else 
				turn = -1;
		}
		else {
			for (int j = 0; j < COLS; j++) {
				if (tokens[j] == "B") {
					c.mark = 'b';
					c.king = true;
					gameBoard[i][j] = c;
				}
				else if (tokens[j] == "R") {
					c.mark = 'r';
					c.king = true;
					gameBoard[i][j] = c;
				}
				else if (tokens[j] == "b") {
					c.mark = 'b';
					c.king = false;
					gameBoard[i][j] = c;
				}
				else if (tokens[j] == "r") {
					c.mark = 'r';
					c.king = false;
					gameBoard[i][j] = c;
				}
				else if (tokens[j] == " ") {
					c.mark = ' ';
					c.king = false;
					gameBoard[i][j] = c;
				}
				else {
					c.mark = '-';
					c.king = false;
					gameBoard[i][j] = c;
				}
			}
		}
		i++;
	}
	
	in.close();
	return turn;
}

bool putMove(int fromRow, int fromCol, int toRow, int toCol) {
	ofstream out("move.txt", ofstream::out);

	if (toCol >= COLS || toCol < 0)
		return false;
	if (toRow >= ROWS || toRow < 0)
		return false;
	out << fromRow << " " << fromCol << " " << toRow << " " << toCol << endl;
	out.close();
	return true;
}