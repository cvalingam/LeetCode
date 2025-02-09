public class Solution
{
    public long CountBadPairs(int[] nums)
    {
        long ans = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();  // (nums[i] - i)

        for (int i = 0; i < nums.Length; ++i)
        {
            int key = nums[i] - i;
            if (!count.ContainsKey(key))
                count[key] = 0;

            ans += i - count[key]++;
        }

        return ans;
    }
}