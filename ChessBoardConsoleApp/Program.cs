using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            // show the empty chessboard
            printGrid(myBoard);

            // get the location of the chess piece
            Cell myLocation = setCurrentCell();

            // calcualte and mark the cells where legal moves are possible
            myBoard.MarkNextLegalMoves(myLocation, selectPiece());

            // Show the chessboard and use "." for an empty square, "X" for the piece location and "+" for a possible legal move
            printGrid(myBoard);

            // Wait for another return key to exit the program
            Console.ReadKey();
        }

        static public void printGrid(Board myBoard)
        {
            // print the board to the console. use "X" for current location, "+" for legal move, and "." for empty square
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    if (myBoard.theGrid[i, j].CurrentlyOccupied)
                    {
                        Console.Write("X");
                    }
                    else if (myBoard.theGrid[i, j].LegalNextMove)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("================================");
        }

        static public string selectPiece()
        {
            Console.WriteLine("Which piece would you let to select? (King, Queen, Bishop, Rook, Knight)");
            bool valid = false;

            do
            {
                string input = Console.ReadLine();
                if (input.All(char.IsDigit))
                {
                    Console.WriteLine("Please enter a valid string");
                }
                else if (input != "King" && input != "Queen" && input != "Bishop" && input != "Rook" && input != "Knight")
                {
                    Console.WriteLine("Please enter a valid string (Case sensitive)");
                }
                else
                {
                    return input;
                    valid = true;
                }
            } while (!valid);

            return null;
        }

        static public Cell setCurrentCell()
        {
            bool valid = false;
            int currentRow = 0;
            int currentCol= 0;
            int i;

            Console.Out.Write("Enter your current row number ");
            do
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out i))
                {
                    Console.WriteLine("Please enter an integer");
                }
                else if (i < 0 || i > 7)
                {
                    Console.WriteLine("Please enter a number between 0 and 7");
                }
                else
                {
                    currentRow = i;
                    valid = true;
                }
            } while (!valid);

            Console.Out.Write("enter your current column number ");
            do
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out i))
                {
                    Console.WriteLine("Please enter an integer");
                }
                else if (i < 0 || i > 7)
                {
                    Console.WriteLine("Please enter a number between 0 and 7");
                }
                else
                {
                    currentCol = i;
                    valid = true;
                }
            } while (!valid);
            
            myBoard.theGrid[currentRow, currentCol].CurrentlyOccupied = true;
            return myBoard.theGrid[currentRow, currentCol];
        }
    }
}