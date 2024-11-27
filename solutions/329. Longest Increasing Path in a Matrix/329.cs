public class Solution
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int ans = 0;
        // mem[i][j] := the LIP starting from matrix[i][j]
        int[][] mem = new int[m][];

        for (int i = 0; i < m; ++i)
            mem[i] = new int[n];

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
                ans = Math.Max(ans, Dfs(matrix, i, j, int.MinValue, mem));
        }

        return ans;
    }

    private int Dfs(int[][] matrix, int i, int j, int prev, int[][] mem)
    {
        if (i < 0 || i == matrix.Length || j < 0 || j == matrix[0].Length)
            return 0;

        if (matrix[i][j] <= prev)
            return 0;

        if (mem[i][j] > 0)
            return mem[i][j];

        int curr = matrix[i][j];
        int a = Dfs(matrix, i + 1, j, curr, mem);
        int b = Dfs(matrix, i - 1, j, curr, mem);
        int c = Dfs(matrix, i, j + 1, curr, mem);
        int d = Dfs(matrix, i, j - 1, curr, mem);
        
        return mem[i][j] = 1 + Math.Max(Math.Max(a, b), Math.Max(c, d));
    }
}