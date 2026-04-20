// Approach: 2D prefix sum (summed-area table) for O(1) rectangular queries.
// Precompute preSum[i][j] = sum of all elements in the rectangle from (0,0) to (i-1,j-1).
// Build using: preSum[i][j] = matrix[i-1][j-1] + preSum[i-1][j] + preSum[i][j-1] - preSum[i-1][j-1].
// Any rectangle sum (r1,c1) to (r2,c2) = preSum[r2+1][c2+1] - preSum[r1][c2+1] - preSum[r2+1][c1] + preSum[r1][c1].
// The +1 offset avoids boundary checks for the top row and left column.
// Time: O(m x n) build, O(1) per query. Space: O(m x n) for the prefix table.

public class NumMatrix
{

    private int[,] preSum;
    public NumMatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        preSum = new int[m + 1, n + 1];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                preSum[i + 1, j + 1] = preSum[i + 1, j] + preSum[i, j + 1] + matrix[i][j] - preSum[i, j];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return preSum[row2 + 1, col2 + 1] - preSum[row1, col2 + 1]
            - preSum[row2 + 1, col1] + preSum[row1, col1];
    }
}