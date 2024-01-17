# Minesweeper App - Technical Details

This console application is built on .NET Core 7.0 framework using Visual Studio.

The code is divided into 4 parts: Models, Services, Utilities, and the  core file itself (Program.cs).

## Models
This carries the properties of the Grid, Location and list of status for the Game Result needed on the Minesweeper App.

### Grid class
To have a grid class, it needs to have a size value to set the number of squares in a grid. It is also where the cell value can be pulled from.

### Location class
This only has two properties: Row and Column. This is usually needed to determine the placement of a cell on the grid.

### GameResult enum
This only has three values: Continue, Win and Loss. These values determine the breakpoint of the game.


## Services
This includes the methods used to build the template of the minesweeper app and the displaying of the values of each square after each play. It includes an interface.

###Create Mine Field
This method is where the foundation of the grid is built. It creates the layout to specify the row and column labels, and the cell values.

### Add Mines
This method places the mines randomly on the field. And also updating the cell values surrounding the mine to correctly display the count of nearby mines.

### Uncover Field
This method is used to change the value of the selected cell and its surrounding if necessary. Its changed value will determine the display of the square in the next move.

### Show All Fields
This method is used to show all the cell values of the grid after a mine has been uncovered.


## Utilities
This holds the validation methods used to check the user input for the grid size, number of mines and cell. It includes an interface.

### Validate Postive Number
This method will validate if the input is a postive number.

### Validate Size
This method will validate if the number inputted is between 3 to 26. Making sure that the grid field is suitable for playing.

### Validate Mine Count
This method will validate if the number inputted does not exceed the 35% number of squares in total.
This means that the number of mines should at least have one mine and be only at max of 35% of all squares.

### Validate Cell
This method will validate if the input is a cell on the grid. It will check first if the first character is a letter, then check if it is included on the row list.
Then it will check the succeeding characters if it is a valid number and is included on the column list.

### Validate Hidden Cell Value
This method will check if the cell is still not yet uncovered or if the square has already been selected.


## Program.cs
This is where the code is executed to run the minesweeper app and to display messages to the user.


## How To Run
Unzip the file, then open the project on Visual Studio. Simply run the console app by clicking on the Play button on top.
Once done, the player will now start to play the Minesweeper app by inputting the size of the grid.
