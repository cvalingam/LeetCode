public class Solution
{
    public long CountSubarrays(int[] nums, long k)
    {
        long ans = 0;
        long sum = 0;

        for (int l = 0, r = 0; r < nums.Length; ++r)
        {
            sum += nums[r];
            while (sum * (r - l + 1) >= k)
                sum -= nums[l++];
            ans += r - l + 1;
        }

        return ans;
    }
}