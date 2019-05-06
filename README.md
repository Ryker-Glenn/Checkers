# Checkers

CS438 final project contains an AI-playable version of the game of checkers. The folders found in the **CS438 Final Project Folder** are as follows:

1. C# Checkers Source Code
  * Contains C# source code for the board as well as the logic to judge moves
2. C++ AI Source Code
  * Contains the source code for a computer to judge moves
3. Checkers Game
  * Contains the executable checkers game, a shortcut with a neat little icon, a test AI executable, and the text files necessary to transfer information between the AI executable written in C++ and the game

## The Game

To start the game, the user must enter the **Checkers Game** directory when in the CS438 Final Project Folder directory. From there, the user selects the Checkers Game executable. A checkers board will appear on screen with all pieces disabled. The user then has the option to play 4 different game types.

#### Person vs. Person

The PvP game is only playable if two players are sharing the same computer, there is no option to play via the internet. To start a PvP game, the user(s) will leave both of the files blank. For all modes, once the user clicks the start button, all pieces will be enabled and the game will begin with the player on the black side going first. When it is a player's turn, they will click a piece. If the piece is moveable, the board square will be highlighted green, indicating that the player may select a square to move to. If a good move is entered, the board will update with the piece on its new square.

![PvP gif was here](https://github.com/Ryker-Glenn/Checkers/tree/master/CS438%20Final%20Project/gifs/PvP.gif)

#### Person vs. AI program

The PvAI, AIvP and AIvAI game only works with an executable of the C++ source code that has been included in the package. Because this is a class project, the C++ source code is included so as to edit the source code with any method the user chooses in order to play the game better.

The PvAI game is started when the user enters a valid executable file compiled from the C++ source code on the **red side**. In checkers, black goes first, so the user will have the first move. If they click a moveable piece, the square will be highlighted green. They will then click a black square. If the move is good, the move will be made. The AI will not take its turn until the user has made a move on the board. The game will continue until one player has no more moves to make or one player captures the rest of the other players' pieces.

![PvAI gif was here](https://github.com/Ryker-Glenn/Checkers/tree/master/CS438%20Final%20Project/gifs/PvAI.gif)

#### AI program vs. Person

The AIvP mode has the same  flow as the PvAI mode. The only difference is that this mode is enabled when the user enters a valid executable file compiled from the C++ source code file from the **black side**. When the user clicks the start game button, the AI on the black side will make its first move automatically, then the computer gives the turn to the user. 

![AIvP gif was here](https://github.com/Ryker-Glenn/Checkers/tree/master/CS438%20Final%20Project/gifs/AIvP.gif)

#### AI vs. AI

The AIvAI mode is triggered when a valid executable file compiled from the C++ source code file has been entered on **both** the black side and the red side. To test the game, the file *BaseAIFile.exe* can be entered in both text boxes. The base AI executable was developed purely to test the validity of returned moves, but will play the game regardless because it returns a random legal move or the first jump it encounters (based on the forced capture rule). When it is either AI's turn to go, it will start the \*.exe file externally. The \*.exe file determines which move to take and journals it in the file *move.txt*. The code currently existing in the original C++ source code file should not be changed, only added to, save for changing how a move is to be journaled.

If a bad move is made by the \*.exe file, the user will be notified via popup message that their piece has made a bad move and will declare the opponent the winner. The game is won when either player captures all of their opponents' pieces.

![AIvAI gif was here](https://github.com/Ryker-Glenn/Checkers/tree/master/CS438%20Final%20Project/gifs/AIvAI.gif)

# Checkers
