public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] rowsCount = new int[m];
        int[] colsCount = new int[n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    rowsCount[i]++;
                    colsCount[j]++;
                }
            }
        }

        int count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1 && rowsCount[i] == 1 && colsCount[j] == 1)
                    count++;
            }
        }

        return count;
    }
}