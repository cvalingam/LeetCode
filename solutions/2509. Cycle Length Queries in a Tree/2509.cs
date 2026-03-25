// Approach: Walk both nodes up to LCA by halving (parent = node/2); count total steps + 1.
// Time: O(q log n) Space: O(1)

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