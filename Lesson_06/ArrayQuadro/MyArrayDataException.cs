using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayQuadro
{
    [Serializable]
    class MyArrayDataException : Exception
    {
        int row, column;

        public MyArrayDataException(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}