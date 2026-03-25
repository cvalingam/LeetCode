// Approach: Validate m*n == len; fill 2D array row by row from 1D index.
// Time: O(mn) Space: O(mn)

public class Solution
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        int[][] result = new int[m][];

        if ((m * n) != original.Length)
            return new int[0][];

        int k = 0;

        for (int i = 0; i < m; i++)
        {
            result[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                result[i][j] = original[k++];
            }
        }

        return result;
    }
}