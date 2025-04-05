public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;

        for (int i = 0; i < (1 << n); i++)
        {
            int subsetXOR = 0;
            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) != 0)
                    subsetXOR ^= nums[j];
            }
            ans += subsetXOR;
        }

        return ans;
    }
}