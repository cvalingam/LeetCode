public class Solution
{
    private const int kMod = 1000000007;
    private const int kPrimesCount = 10;
    private static readonly int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

    public int SquareFreeSubsets(int[] nums)
    {
        int[][] mem = new int[nums.Length][];

        for (int i = 0; i < nums.Length; i++)
        {
            int[] row = new int[1 << (kPrimesCount + 1)];
            Array.Fill(row, -1);
            mem[i] = row;
        }

        int[] masks = new int[nums.Length];

        for (int i = 0; i < nums.Length; ++i)
            masks[i] = GetMask(nums[i]);

        // -1 means that we take no number.
        // `used` is initialized to 1 so that -1 & 1 = 1 instead of 0.
        return (SquareFreeSubsets(masks, 0, /*used=*/1, mem) - 1 + kMod) % kMod;
    }

    private int SquareFreeSubsets(int[] masks, int i, int used, int[][] mem)
    {
        if (i == masks.Length)
            return 1;
        if (mem[i][used] != -1)
            return mem[i][used];
        int pick = (masks[i] & used) == 0 ? SquareFreeSubsets(masks, i + 1, used | masks[i], mem) : 0;
        int skip = SquareFreeSubsets(masks, i + 1, used, mem);
        return mem[i][used] = (pick + skip) % kMod;
    }

    // e.g. num = 10 = 2 * 5, so mask = 0b101 -> 0b1010 (append a 0)
    //      num = 15 = 3 * 5, so mask = 0b110 -> 0b1100 (append a 0)
    //      num = 25 = 5 * 5, so mask =  0b-1 -> 0b1..1 (invalid)
    private int GetMask(int num)
    {
        int mask = 0;
        for (int i = 0; i < primes.Length; ++i)
        {
            int rootCount = 0;
            while (num % primes[i] == 0)
            {
                num /= primes[i];
                ++rootCount;
            }
            if (rootCount >= 2)
                return -1;
            if (rootCount == 1)
                mask |= 1 << i;
        }
        return mask << 1;
    }
}