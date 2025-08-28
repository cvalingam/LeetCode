public class Solution
{
    public int[][] SortMatrix(int[][] grid)
    {
        int n = grid.Length;

        // Sort the diagonals starting from the last column and moving upwards
        for (int startRow = n - 2; startRow >= 0; --startRow)
        {
            int i = startRow, j = 0;
            List<int> diagonalElements = new List<int>();

            // Collect elements of the current diagonal
            while (i < n && j < n)
            {
                diagonalElements.Add(grid[i][j]);
                i++;
                j++;
            }

            // Sort the collected diagonal elements
            diagonalElements.Sort();

            // Place the sorted elements back into the grid
            for (int elementIndex = 0; elementIndex < diagonalElements.Count; elementIndex++)
                grid[--i][--j] = diagonalElements[elementIndex];
        }

        // Sort the diagonals starting from the last row and moving to the first row
        for (int startColumn = n - 2; startColumn > 0; --startColumn)
        {
            int i = startColumn, j = n - 1;
            List<int> diagonalElements = new List<int>();

            // Collect elements of the current diagonal
            while (i >= 0 && j >= 0)
            {
                diagonalElements.Add(grid[i][j]);
                i--;
                j--;
            }

            // Sort the collected diagonal elements
            diagonalElements.Sort();

            // Place the sorted elements back into the grid
            for (int elementIndex = 0; elementIndex < diagonalElements.Count; elementIndex++)
                grid[++i][++j] = diagonalElements[elementIndex];
        }

        // Return the sorted grid
        return grid;
    }
}