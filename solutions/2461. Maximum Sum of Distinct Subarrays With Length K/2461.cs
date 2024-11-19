public class Solution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        long ans = 0;
        long sum = 0;
        int distinct = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            sum += nums[i];

            if (count.TryGetValue(nums[i], out int currentCount))
                count[nums[i]] = currentCount + 1;
            else
            {
                count[nums[i]] = 1;
                distinct++;
            }

            if (i >= k)
            {
                if (count.TryGetValue(nums[i - k], out currentCount))
                {
                    if (currentCount == 1)
                    {
                        count.Remove(nums[i - k]);
                        distinct--;
                    }
                    else
                        count[nums[i - k]] = currentCount - 1;
                }
                sum -= nums[i - k];
            }

            if (i >= k - 1 && distinct == k)
                ans = Math.Max(ans, sum);
        }

        return ans;
    }
}