public class Solution
{
    public int MinZeroArray(int[] nums, int[][] queries)
    {
        int[] line = new int[nums.Length + 1];
        int decrement = 0;
        int k = 0;

        for (int i = 0; i < nums.Length; ++i)
        {
            while (decrement + line[i] < nums[i])
            {
                if (k == queries.Length)
                    return -1;
                int l = queries[k][0];
                int r = queries[k][1];
                int val = queries[k][2];
                ++k;
                if (r < i)
                    continue;
                line[Math.Max(l, i)] += val;
                line[r + 1] -= val;
            }
            decrement += line[i];
        }

        return k;
    }
}