public class Solution
{
    public long CountSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int max = nums.Max();

        int l = 0, r = 0, freq = 0;
        long ans = 0;
        while (r < n)
        {
            if (nums[r] == max)
                freq++;

            while (freq >= k)
            {
                ans += (n - r);
                if (nums[l] == max)
                    freq--;
                l++;
            }
            r++;
        }

        return ans;
    }
}