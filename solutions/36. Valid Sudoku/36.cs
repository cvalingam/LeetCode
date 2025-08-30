public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        // Create 2D boolean arrays to track numbers in rows, columns, and sub-boxes
        bool[][] rowHasNumber = new bool[9][];
        bool[][] columnHasNumber = new bool[9][];
        bool[][] subBoxHasNumber = new bool[9][];

        for (int i = 0; i < 9; i++)
        {
            rowHasNumber[i] = new bool[9];
            columnHasNumber[i] = new bool[9];
            subBoxHasNumber[i] = new bool[9];
        }

        // Iterate through each cell in the 9x9 board
        for (int row = 0; row < 9; row++)
        {
            for (int column = 0; column < 9; column++)
            {
                char currentCell = board[row][column];

                // Skip empty cells
                if (currentCell == '.')
                    continue;

                // Convert character digit to 0-based index (e.g., '1' -> 0, '9' -> 8)
                int digitIndex = currentCell - '0' - 1;

                // Calculate sub-box index (0-8) based on current position
                // Sub-boxes are numbered left-to-right, top-to-bottom
                int subBoxIndex = (row / 3) * 3 + (column / 3);

                // Check if this digit already exists in current row, column, or sub-box
                if (rowHasNumber[row][digitIndex] ||
                    columnHasNumber[column][digitIndex] ||
                    subBoxHasNumber[subBoxIndex][digitIndex])
                    return false;  // Duplicate found, invalid Sudoku

                // Mark this digit as seen in the current row, column, and sub-box
                rowHasNumber[row][digitIndex] = true;
                columnHasNumber[column][digitIndex] = true;
                subBoxHasNumber[subBoxIndex][digitIndex] = true;
            }
        }

        // No duplicates found, valid Sudoku configuration
        return true;
    }
}