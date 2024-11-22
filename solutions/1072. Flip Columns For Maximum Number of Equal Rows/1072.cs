public class Solution
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int ans = 0;
        int[] flip = new int[n];
        HashSet<int> seen = new HashSet<int>();

        for (int i = 0; i < m; ++i)
        {
            if (seen.Contains(i))
                continue;

            int count = 0;

            for (int j = 0; j < n; ++j)
                flip[j] = 1 ^ matrix[i][j];

            for (int k = 0; k < m; ++k)
            {
                if (AreArraysEqual(matrix[k], matrix[i]) || AreArraysEqual(matrix[k], flip))
                {
                    seen.Add(k);
                    ++count;
                }
            }

            ans = Math.Max(ans, count);
        }

        return ans;
    }

    private bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) 
            return false;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i]) 
                return false;
        }
        
        return true;
    }
}