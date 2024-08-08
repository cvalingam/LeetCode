public class Solution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        int[] dx = { 1, 0, -1, 0 };
        int[] dy = { 0, 1, 0, -1 };
        var ans = new List<int[]> { new int[] { rStart, cStart } };

        for (int i = 0; ans.Count < rows * cols; i++)
        {
            for (int step = 0; step < i / 2 + 1; step++)
            {
                rStart += dy[i % 4];
                cStart += dx[i % 4];

                if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    ans.Add(new int[] { rStart, cStart });
            }
        }

        return ans.ToArray();
    }
}