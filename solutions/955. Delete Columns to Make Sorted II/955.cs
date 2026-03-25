// Approach: Greedy scan; track which adjacent row pairs are already strictly sorted; delete a column only if it creates an inversion in an unsorted pair.
// Time: O(n·m) Space: O(n)

public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int n = strs.Length;
        int ans = 0;
        bool[] sorted = new bool[n - 1];

        for (int j = 0; j < strs[0].Length; ++j)
        {
            int i;
            for (i = 0; i + 1 < n; ++i)
            {
                if (!sorted[i] && strs[i][j] > strs[i + 1][j])
                {
                    ++ans;
                    break;
                }
            }
            if (i + 1 == n)
            {
                for (i = 0; i + 1 < n; ++i)
                    sorted[i] = sorted[i] || strs[i][j] < strs[i + 1][j];
            }
        }

        return ans;
    }
}