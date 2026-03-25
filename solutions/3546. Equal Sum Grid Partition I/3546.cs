// Approach: Prefix row sums; check if any horizontal or vertical cut splits into equal halves.
// Time: O(mn) Space: O(1)

public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        long totalSum = grid.SelectMany(row => row).Sum(x => (long)x);
        return CanPartition(grid, totalSum) || CanPartition(Transposed(grid), totalSum);
    }

    private bool CanPartition(int[][] lines, long totalSum)
    {
        long runningSum = 0;
        foreach (var line in lines)
        {
            runningSum += line.Sum(x => (long)x);
            if (runningSum * 2 == totalSum)
                return true;
        }
        
        return false;
    }

    private int[][] Transposed(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int[][] res = new int[cols][];
        for (int j = 0; j < cols; j++)
        {
            res[j] = new int[rows];
            for (int i = 0; i < rows; i++)
                res[j][i] = grid[i][j];
        }

        return res;
    }
}