/*
 * Lauren Hutchens
 * CST-250
 * 2/9/2025
 * Activity 2: Chess Board App
 * In class activity
 */
using System.Runtime.CompilerServices;
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;
using System.Drawing; // Add this for Color

// ------------------------------------------
// Start of Main Method
//-------------------------------------------
// Declear and initialize
string piece = " ";
Tuple<int, int>? result = null;
// Create an instance of our Business layer
BoardLogic boardLogic = new BoardLogic();
// Welcome the user

Console.WriteLine("Welcome, Our Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);
//Show the empty chess board
Helper.PrintBoard(board);
// Prompt the user for the type of chess piece
Console.Write("Enter the type of piece you want to place (knight, Rook, Bishop, queen, king): ");
piece = Console.ReadLine();
// prompt the user for the location of the chess piece
result = Helper.GetRowAndCol();
// Mark the legal move based on the input
board = boardLogic.MarkLegalMoves(board, board.Grid[result.Item1, result.Item2], piece);
// Print the new chess board
Helper.PrintBoard(board);



//----------------------------------------------
// End of Main Method
//---------------------------------------------



//---------------------------------------------
// Define Utility Class

class Helper
{
    /// <summary>
    /// Print the given board to the console
    /// </summary>
    /// <param name="board"></param>
    public static void PrintBoard(BoardModel board)
    {
        for (int row = 0; row < board.Size; row++)
        {
            for (int col = 0; col < board.Size; col++)
            {
                CellModel cell = board.Grid[row, col];

                if (cell.IsLegalNextMove)
                {
                    SetConsoleColor(ConsoleColor.DarkGray, ConsoleColor.Black); // Legal move - Example colors
                    Console.Write(" + ");
                    Console.ResetColor();
                }
                else if (cell.PieceOccupyingCell != "")
                {
                    switch (cell.PieceOccupyingCell.ToLower())
                    {
                        case "n": // Knight
                            SetConsoleColor(ConsoleColor.DarkBlue, ConsoleColor.Black); // Example
                            break;
                        case "r": // Rook
                            SetConsoleColor(ConsoleColor.DarkRed, ConsoleColor.Black); // Example
                            break;
                        case "b": // Bishop
                            SetConsoleColor(ConsoleColor.DarkGreen, ConsoleColor.Black); // Example
                            break;
                        case "q": // Queen
                            SetConsoleColor(ConsoleColor.Yellow, ConsoleColor.Black); // Example
                            break;
                        case "k": // King
                            SetConsoleColor(ConsoleColor.Magenta, ConsoleColor.Black); // Example
                            break;
                        default:
                            Console.ResetColor(); // Default color if unknown piece
                            break;
                    }
                    Console.Write($" {cell.PieceOccupyingCell} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine(); // Newline after each row for proper board display
        }
    }
    //adding 
    /// <summary>
    /// Sets both foreground and background console colors.
    /// </summary>
    /// <param name="foreground"></param>
    /// <param name="background"></param>
    private static void SetConsoleColor(ConsoleColor foreground, ConsoleColor background)
    {
        Console.ForegroundColor = foreground;
        Console.BackgroundColor = background;
        }
    }// end of PrintBoard method

    public static Tuple<int, int> GetRowAndCol()
    {
        int row = -1, col = -1;

        Console.Write("Enter the row number of the piece (0-7): ");
        if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < 8)
        {

        }
        else
        {
            Console.WriteLine("Invalid input. Row number must be between 0 and 7");
            return GetRowAndCol();
        }

        Console.Write("Enter the col number of the piece (0-7): ");
        if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < 8)
        {

        }
        else
        {
            Console.WriteLine("Invalid input. Col number must be between 0 and 7");
            return GetRowAndCol();
        }

        return Tuple.Create(row, col);
    }
}