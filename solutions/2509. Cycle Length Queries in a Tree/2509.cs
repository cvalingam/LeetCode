public class Solution
{
    public int[] CycleLengthQueries(int n, int[][] queries)
    {
        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; ++i)
        {
            ++ans[i];
            int a = queries[i][0];
            int b = queries[i][1];
            while (a != b)
            {
                if (a > b)
                    a /= 2;
                else
                    b /= 2;
                ++ans[i];
            }
        }

        return ans;
    }
}