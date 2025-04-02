public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        long ans = 0;
        int maxDiff = 0; // max(nums[i] - nums[j])
        int maxNum = 0;  // max(nums[i])

        foreach (var num in nums)
        {
            ans = Math.Max(ans, (long)maxDiff * num); // num := nums[k]
            maxDiff = Math.Max(maxDiff, maxNum - num); // num := nums[j]
            maxNum = Math.Max(maxNum, num);            // num := nums[i]
        }

        return ans;
    }
}