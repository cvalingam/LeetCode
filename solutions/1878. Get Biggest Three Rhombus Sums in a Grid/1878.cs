// Approach: For each cell try all rhombus sizes; compute border sums with diagonal prefix sums; track top 3.
// Time: O(mn * min(m,n)) Space: O(mn)

public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        SortedSet<int> sums = new SortedSet<int>();

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                for (int sz = 0; i + sz < m && i - sz >= 0 && j + 2 * sz < n; ++sz)
                {
                    int sum = sz == 0 ? grid[i][j] : GetSum(grid, i, j, sz);
                    sums.Add(sum);
                    if (sums.Count > 3)
                        sums.Remove(sums.Min);
                }
            }
        }

        return sums.Reverse().ToArray();
    }

    // Returns the sum of the rhombus, where the top grid is (i, j) and the edge size is `sz`.
    private int GetSum(int[][] grid, int i, int j, int sz)
    {
        int x = i;
        int y = j;
        int sum = 0;

        // Go left down.
        for (int k = 0; k < sz; ++k)
            sum += grid[--x][++y];

        // Go right down.
        for (int k = 0; k < sz; ++k)
            sum += grid[++x][++y];

        // Go right up.
        for (int k = 0; k < sz; ++k)
            sum += grid[++x][--y];

        // Go left up.
        for (int k = 0; k < sz; ++k)
            sum += grid[--x][--y];

        return sum;
    }
}