/*
 * Lauren Hutchens
 * CST-250
 * 2/9/2025
 * In class Activity
 * Activity 2
 */
using System.Runtime.CompilerServices;
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

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
Healper.PrintBoard(board);
// Prompt the user for the type of chess piece
Console.Write("Enter the type of piece you want to place (knight, Rook, Bishop, queen, king): ");
piece = Console.ReadLine();
// prompt the user for the location of the chess piece
result = Healper.GetRowAndCol();
// Mark the legal move based on the input
board = boardLogic.MarkLegalMoves(board, board.Grid[result.Item1, result.Item2], piece);
// Print the new chess board
Healper.PrintBoard(board);



//----------------------------------------------
// End of Main Method
//---------------------------------------------



//---------------------------------------------
// Define Utility Class

class Healper
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
                    Console.Write(" + ");
                }
                else if (cell.PieceOccupyingCell != "")
                {
                    Console.Write($" {cell.PieceOccupyingCell} ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            // Add a newline character after each row is printed
            Console.WriteLine(); // This is the crucial addition
        }
    }// end of PrintBoard method

    public static Tuple<int, int> GetRowAndCol()
    {
        // Declear initialize
        int rwo = -1, col = -1;

        Console.Write("Enter the row number of the piece: ");
        int row = int.Parse(Console.ReadLine());

        Console.Write("Enter the col number of the piece: ");
        col = int.Parse(Console.ReadLine());

        return Tuple.Create(row, col);
    }
}