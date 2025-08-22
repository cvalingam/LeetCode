public class Solution
{
    public int MinimumArea(int[][] grid)
    {
        int x1 = int.MaxValue;
        int y1 = int.MaxValue;
        int x2 = 0;
        int y2 = 0;

        for (int i = 0; i < grid.Length; ++i)
        {
            for (int j = 0; j < grid[0].Length; ++j)
            {
                if (grid[i][j] == 1)
                {
                    x1 = Math.Min(x1, i);
                    y1 = Math.Min(y1, j);
                    x2 = Math.Max(x2, i);
                    y2 = Math.Max(y2, j);
                }
            }
        }

        return (x2 - x1 + 1) * (y2 - y1 + 1);
    }
}