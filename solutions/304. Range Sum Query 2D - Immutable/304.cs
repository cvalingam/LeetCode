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