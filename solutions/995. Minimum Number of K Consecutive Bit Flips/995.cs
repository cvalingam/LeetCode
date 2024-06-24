public class Solution
{
    public int MinKBitFlips(int[] nums, int k)
    {
        int n = nums.Length, ans = 0, times = 0;

        for (int i = 0; i < n; i++)
        {
            if (i >= k && nums[i - k] == 2)
                times--;

            if (nums[i] == times % 2)
            {
                if (i + k > n)
                    return -1;

                ans++;
                times++;
                nums[i] = 2;
            }
        }

        return ans;
    }
}