// Approach: For each cell determine flip parity from range queries applied; XOR result.
// Time: O(n * k) Space: O(n²)

public class Solution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        // Iterate through the first half of the rows in the submatrix
        for (int row = x; row < x + k / 2; row++)
        {
            // Calculate the corresponding row from the bottom to swap with
            int mirrorRow = x + k - 1 - (row - x);

            // Swap all elements in the current row with the mirror row
            for (int col = y; col < y + k; col++)
            {
                // Perform the swap using a temporary variable
                int temp = grid[row][col];
                grid[row][col] = grid[mirrorRow][col];
                grid[mirrorRow][col] = temp;
            }
        }

        return grid;
    }
}