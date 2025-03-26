public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] arr = new int[m * n];
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
                arr[i * n + j] = grid[i][j];
        }

        if (arr.Any(a => (a - arr[0]) % x != 0))
            return -1;

        int ans = 0;

        Array.Sort(arr);

        foreach (var a in arr)
            ans += Math.Abs(a - arr[arr.Length / 2]) / x;

        return ans;
    }
}