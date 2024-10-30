public class Solution
{
    public int MinimumMountainRemovals(int[] nums)
    {
        int[] l = LengthOfLIS(nums);
        int[] r = Reversed(LengthOfLIS(Reversed(nums)));
        int maxMountainSeq = 0;

        for (int i = 0; i < nums.Length; ++i)
            if (l[i] > 1 && r[i] > 1)
                maxMountainSeq = Math.Max(maxMountainSeq, l[i] + r[i] - 1);

        return nums.Length - maxMountainSeq;
    }

    // Similar to 300. Longest Increasing Subsequence
    private int[] LengthOfLIS(int[] nums)
    {
        // tails[i] := the minimum tail of all the increasing subsequences with
        // length i + 1
        List<int> tails = new List<int>();
        // dp[i] := the length of LIS ending in nums[i]
        int[] dp = new int[nums.Length];
        for (int i = 0; i < nums.Length; ++i)
        {
            int num = nums[i];
            if (tails.Count == 0 || num > tails[tails.Count - 1])
                tails.Add(num);
            else
                tails[FirstGreaterEqual(tails, num)] = num;
            dp[i] = tails.Count;
        }
        return dp;
    }

    private int FirstGreaterEqual(List<int> A, int target)
    {
        int i = A.BinarySearch(target);
        return i < 0 ? -i - 1 : i;
    }

    private int[] Reversed(int[] nums)
    {
        int[] A = (int[])nums.Clone();
        int l = 0;
        int r = nums.Length - 1;
        while (l < r)
            Swap(A, l++, r--);
        return A;
    }

    private void Swap(int[] A, int i, int j)
    {
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }
}