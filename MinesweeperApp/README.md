#Minesweeper App

This simple console application allows the player to play a minesweeper game.
Here are the rules the player needs to know:

##1. Determine the size of the grid.
The player should input a valid number to determine the size of the grid of the mine field.
It should only range between 3 to 26 for a better playing experience.

##2. Add mines.
The player will then input a number determining the quantity of mines to be spread across the grid.
Take note that a grid could only hold up to 35% of its squares for the number of mines and should have at least 1.

##3. Choose a square.
The player will see letters on the left side which corresponds to the rows of the grid. Above, the numbers indicate the columns.
To get a cell value, just combine a letter from the left side and a number on the top (e.g. A1).It should only allow accept cell values within the grid.
If the player chooses an uncovered square, the game will notify to choose a different cell.

##4. Continue the game if still alive.
If the player did not select a mine, just continue choosing another square until all squares are cleared.


##5. Play again.
After losing or winning, the player could restart the game by pressing on any key.


And that's it!

Try now by running the app and see how many times you could win with the Minesweeper app!