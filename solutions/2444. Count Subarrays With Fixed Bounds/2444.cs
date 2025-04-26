public class Solution
{
    public long CountSubarrays(int[] nums, int minK, int maxK)
    {
        long ans = 0;
        int badi = -1, mini = -1, maxi = -1, n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            if (nums[i] < minK || nums[i] > maxK)
                badi = i;

            if (nums[i] == minK)
                mini = i;

            if (nums[i] == maxK)
                maxi = i;

            ans += Math.Max(0, Math.Min(mini, maxi) - badi);
            // Console.WriteLine("i value: " + i + " ans value: " + ans);
        }

        return ans;
    }
}