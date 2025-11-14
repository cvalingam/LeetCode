public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        // Initialize n x n matrix with all zeros
        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
            matrix[i] = new int[n];

        // Apply difference array technique for 2D range updates
        // Mark the boundaries of each query rectangle
        foreach (var query in queries)
        {
            int row1 = query[0];
            int col1 = query[1];
            int row2 = query[2];
            int col2 = query[3];

            // Mark the top-left corner with +1
            matrix[row1][col1]++;

            // Mark the position below the bottom-right corner with -1
            if (row2 + 1 < n)
                matrix[row2 + 1][col1]--;

            // Mark the position to the right of the bottom-right corner with -1
            if (col2 + 1 < n)
                matrix[row1][col2 + 1]--;

            // Mark the diagonal position (row2+1, col2+1) with +1 to compensate
            if (row2 + 1 < n && col2 + 1 < n)
                matrix[row2 + 1][col2 + 1]++;
        }

        // Build the final matrix using 2D prefix sum
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                // Add value from the cell above
                if (row > 0)
                    matrix[row][col] += matrix[row - 1][col];

                // Add value from the cell to the left
                if (col > 0)
                    matrix[row][col] += matrix[row][col - 1];

                // Subtract the diagonal cell (included twice) to avoid double counting
                if (row > 0 && col > 0)
                    matrix[row][col] -= matrix[row - 1][col - 1];
            }
        }

        return matrix;
    }
}