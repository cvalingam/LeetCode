public class Solution
{
    public int CountPartitions(int[] nums, int k)
    {
        const int MOD = 1000000007;
        LinkedList<int> maxDq = new LinkedList<int>();
        LinkedList<int> minDq = new LinkedList<int>();
        int n = nums.Length;
        int[] dp = new int[n + 1];
        dp[0] = 1;
        int left = 0, suffix = 0;

        for (int right = 0; right < n; right++)
        {
            suffix = (suffix + dp[right]) % MOD;

            while (maxDq.Count > 0 && nums[maxDq.Last.Value] <= nums[right])
                maxDq.RemoveLast();
            maxDq.AddLast(right);

            while (minDq.Count > 0 && nums[minDq.Last.Value] >= nums[right])
                minDq.RemoveLast();
            minDq.AddLast(right);

            while (nums[maxDq.First.Value] - nums[minDq.First.Value] > k)
            {
                if (minDq.First.Value == left)
                    minDq.RemoveFirst();

                if (maxDq.First.Value == left)
                    maxDq.RemoveFirst();
                    
                suffix = (suffix - dp[left] + MOD) % MOD;
                left++;
            }
            dp[right + 1] = suffix;
        }

        return dp[n];
    }
}