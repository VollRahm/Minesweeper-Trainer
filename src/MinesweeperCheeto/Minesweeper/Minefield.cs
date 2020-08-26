using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MinesweeperCheeto.Vars;

namespace MinesweeperCheeto.Minesweeper
{
    public class Minefield
    {
        public byte[][] Mines
        {
            get => GetMines();
        }

        private long FieldColumns
        {
            get => mem.ReadInt64(mem.ReadInt64(cheat.GameManager.Base + 0x58) + 0x10);
        }

        private byte[][] GetMines()
        {
            int fieldX = cheat.GameManager.FieldSizeX;
            int fieldY = cheat.GameManager.FieldSizeY;

            byte[][] minesArray = new byte[fieldX,fieldY].ToJaggedArray();

            for(int columnIndex = 0; columnIndex < fieldX; columnIndex++)
            {
                var rowPtr = mem.ReadInt64(mem.ReadInt64(FieldColumns + 0x8 * columnIndex) + 0x10);
                minesArray[columnIndex] = mem.ReadBytes(rowPtr, (uint)fieldY);
            }
            return minesArray;
        }

        public byte GetFieldStatus(int x, int y)
        {
            var Columns = mem.ReadInt64(mem.ReadInt64(cheat.GameManager.Base + 0x50) + 0x10);
            var Column = mem.ReadInt64(mem.ReadInt64(Columns + 0x8 * x) + 0x10);
            var Row = Column + y * 0x4;
            byte State = mem.ReadByte(Row);
            return State;
        }
    }

    internal static class ExtensionMethods
    {
        internal static T[][] ToJaggedArray<T>(this T[,] twoDimensionalArray)
        {
            int rowsFirstIndex = twoDimensionalArray.GetLowerBound(0);
            int rowsLastIndex = twoDimensionalArray.GetUpperBound(0);
            int numberOfRows = rowsLastIndex + 1;

            int columnsFirstIndex = twoDimensionalArray.GetLowerBound(1);
            int columnsLastIndex = twoDimensionalArray.GetUpperBound(1);
            int numberOfColumns = columnsLastIndex + 1;

            T[][] jaggedArray = new T[numberOfRows][];
            for (int i = rowsFirstIndex; i <= rowsLastIndex; i++)
            {
                jaggedArray[i] = new T[numberOfColumns];

                for (int j = columnsFirstIndex; j <= columnsLastIndex; j++)
                {
                    jaggedArray[i][j] = twoDimensionalArray[i, j];
                }
            }
            return jaggedArray;
        }
    }
}
