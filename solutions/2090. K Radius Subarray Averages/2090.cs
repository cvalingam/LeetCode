public class Solution
{
    public int[] GetAverages(int[] nums, int k)
    {
        int n = nums.Length;
        int size = 2 * k + 1;
        int[] ans = new int[n];
        Array.Fill(ans, -1);
        if (size > n)
            return ans;

        long sum = 0;

        for (int i = 0; i < size; ++i)
            sum += nums[i];

        for (int i = k; i + k < n; ++i)
        {
            ans[i] = (int)(sum / size);
            if (i + k + 1 < n)
                sum += nums[i + k + 1] - nums[i - k];
        }

        return ans;
    }
}