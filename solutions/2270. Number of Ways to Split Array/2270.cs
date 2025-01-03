public class Solution
{
    public int WaysToSplitArray(int[] nums)
    {
        int ans = 0;
        long prefix = 0, suffix = 0;
        foreach (int val in nums)
            suffix += val;

        for (int i = 0; i < nums.Length - 1; ++i)
        {
            prefix += nums[i];
            suffix -= nums[i];
            if (prefix >= suffix)
                ++ans;
        }

        return ans;
    }
}