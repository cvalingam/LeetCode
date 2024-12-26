public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int n = nums.Length;
        int totalSum = 0;
        for (int i = 0; i < n; i++)
            totalSum += nums[i];

        int remaining = totalSum - target;

        if (remaining < 0 || remaining % 2 > 0)
            return 0;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            int[] arr = new int[(remaining / 2) + 1];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }
        return topDown(n - 1, remaining / 2, nums, dp);
    }

    private static int topDown(int ind, int target, int[] arr, int[][] dp)
    {
        if (ind == 0)
        {
            if (target == 0 && arr[ind] == 0)
                return 2;

            if (target == 0 || arr[ind] == target)
                return 1;

            return 0;
        }

        if (dp[ind][target] != -1)
            return dp[ind][target];

        int notTake = topDown(ind - 1, target, arr, dp);
        int take = 0;
        if (arr[ind] <= target)
            take = topDown(ind - 1, target - arr[ind], arr, dp);

        int ans = take + notTake;
        dp[ind][target] = ans;
        return ans;
    }
}