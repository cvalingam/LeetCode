public class Solution
{
    public int[] FindPermutation(int[] nums)
    {
        int n = nums.Length;
        int[][] mem = new int[n][];
        for (int i = 0; i < n; i++)
            mem[i] = new int[1 << n];

        int[][] bestPick = new int[n][];
        for (int i = 0; i < n; i++)
            bestPick[i] = new int[1 << n];

        // Choose 0 as perm[0] since the score function is cyclic.
        GetScore(nums, 0, 1, bestPick, mem);
        return Construct(bestPick);
    }

    // Returns the minimum score, where `last` is the last chosen number and
    // `mask` is the bitmask of the chosen numbers.
    private int GetScore(int[] nums, int last, int mask, int[][] bestPick, int[][] mem)
    {
        if (CountBits(mask) == nums.Length)
            return Math.Abs(last - nums[0]); // |perm[n - 1] - nums[perm[0]]|
        if (mem[last][mask] > 0)
            return mem[last][mask];

        int minScore = int.MaxValue;
        for (int i = 1; i < nums.Length; ++i)
        {
            if ((mask >> i & 1) == 1)
                continue;
            int nextMinScore = Math.Abs(last - nums[i]) + GetScore(nums, i, mask | (1 << i), bestPick, mem);
            if (nextMinScore < minScore)
            {
                minScore = nextMinScore;
                bestPick[last][mask] = i;
            }
        }

        return mem[last][mask] = minScore;
    }

    private int[] Construct(int[][] bestPick)
    {
        int[] ans = new int[bestPick.Length];
        int last = 0;
        int mask = 1;
        for (int i = 0; i < bestPick.Length; ++i)
        {
            ans[i] = last;
            last = bestPick[last][mask];
            mask |= 1 << last;
        }
        return ans;
    }

    private int CountBits(int mask)
    {
        int count = 0;
        while (mask > 0)
        {
            count += mask & 1;
            mask >>= 1;
        }
        return count;
    }
}