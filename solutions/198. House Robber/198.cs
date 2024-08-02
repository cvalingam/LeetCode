public class Solution
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, -1);

        return topDown(n - 1, nums, dp);
    }

    private int topDown(int ind, int[] nums, int[] dp)
    {
        if (ind < 0)
            return 0;

        if (dp[ind] != -1)
            return dp[ind];

        int take = nums[ind] + topDown(ind - 2, nums, dp);
        int notTake = topDown(ind - 1, nums, dp);

        return dp[ind] = Math.Max(take, notTake);
    }
}