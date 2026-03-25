// Approach: For each element that is the minimum of its row, check if it equals the maximum of its column.
// Time: O(m·n) Space: O(1)

public class Solution
{
    public IList<int> LuckyNumbers(int[][] matrix)
    {
        IList<int> ans = new List<int>();

        foreach (int[] row in matrix)
        {
            int minIndex = getMinIndex(row);
            if (row[minIndex] == maxNumOfColumn(matrix, minIndex))
                ans.Add(row[minIndex]);
        }

        return ans;
    }

    private int getMinIndex(int[] row)
    {
        int minIndex = 0;
        for (int j = 0; j < row.Length; j++)
        {
            if (row[j] < row[minIndex])
                minIndex = j;
        }

        return minIndex;
    }

    private int maxNumOfColumn(int[][] matrix, int j)
    {
        int res = 0;
        for (int i = 0; i < matrix.Length; i++)
            res = Math.Max(matrix[i][j], res);

        return res;
    }
}