public class Solution
{
    public int MinSubarray(int[] nums, int p)
    {
        long sum = 0;
        foreach (int val in nums)
            sum = sum + val;

        int remainder = (int)(sum % p);
        if (remainder == 0)
            return 0;

        int ans = nums.Length;
        int prefix = 0;
        Dictionary<int, int> prefixToIndex = new Dictionary<int, int>();
        prefixToIndex[0] = -1;

        for (int i = 0; i < nums.Length; ++i)
        {
            prefix += nums[i];
            prefix %= p;
            int target = (prefix - remainder + p) % p;
            if (prefixToIndex.ContainsKey(target))
                ans = Math.Min(ans, i - prefixToIndex[target]);
            prefixToIndex[prefix] = i;
        }

        return ans == nums.Length ? -1 : ans;
    }
}