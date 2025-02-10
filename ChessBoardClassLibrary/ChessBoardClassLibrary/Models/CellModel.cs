/*
 * Lauren Hutchens
 * CST-250
 * 2/9/2025
 * In class Activity
 * Activity 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardClassLibrary.Models
{
    public class CellModel
    {
        // Class level properties
        public int Row { get; set; }
        public int Column { get; set; }
        public string PieceOccupyingCell { get; set; }
        public bool IsLegalNextMove { get; set; }

        /// <summary>
        /// Parameterized Constructor for cell model class
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public CellModel(int row, int column)
        {
            Row = row;
            Column = column;

            // Set default value with other properties
            PieceOccupyingCell = "";
            IsLegalNextMove = false;
        }
    }

}
