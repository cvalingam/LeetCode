public class Solution
{
    public int[][] ConstructProductMatrix(int[][] grid)
    {
        const int kMod = 12345;
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
            ans[i] = new int[n];

        List<int> prefix = new List<int> { 1 };
        int suffix = 1;

        foreach (var row in grid)
        {
            foreach (var num in row)
                prefix.Add((int)((long)prefix[prefix.Count - 1] * num % kMod));
        }

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                ans[i][j] = (int)((long)prefix[i * n + j] * suffix % kMod);
                suffix = (int)((long)suffix * grid[i][j] % kMod);
            }
        }

        return ans;
    }
}