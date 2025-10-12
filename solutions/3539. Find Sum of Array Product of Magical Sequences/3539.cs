class Solution
{
    private const int MOD = 1_000_000_007;

    public int MagicalSum(int m, int k, int[] nums)
    {
        int[][] comb = GetComb(m, m);
        int?[][][][] mem = new int?[m + 1][][][];
        for (int a = 0; a <= m; a++)
        {
            mem[a] = new int?[k + 1][][];
            for (int b = 0; b <= k; b++)
            {
                mem[a][b] = new int?[nums.Length + 1][];
                for (int c = 0; c <= nums.Length; c++)
                    mem[a][b][c] = new int?[m + 1];
            }
        }
        return Dp(m, k, 0, 0, nums, mem, comb);
    }

    private int Dp(int m, int k, int i, int carry, int[] nums, int?[][][][] mem, int[][] comb)
    {
        if (m < 0 || k < 0 || (m + CountBits(carry) < k))
            return 0;
        if (m == 0)
            return k == CountBits(carry) ? 1 : 0;
        if (i == nums.Length)
            return 0;
        if (mem[m][k][i][carry].HasValue)
            return mem[m][k][i][carry].Value;

        int res = 0;
        for (int count = 0; count <= m; count++)
        {
            long contribution = (long)comb[m][count] * ModPow(nums[i], count) % MOD;
            int newCarry = carry + count;
            res = (int)((res + (long)Dp(m - count, k - (newCarry % 2), i + 1, newCarry / 2, nums, mem, comb) * contribution) % MOD);
        }
        mem[m][k][i][carry] = res;
        return res;
    }

    // C(n, k) = C(n - 1, k) + C(n - 1, k - 1)
    private int[][] GetComb(int n, int k)
    {
        int[][] comb = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            comb[i] = new int[k + 1];
            comb[i][0] = 1;
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= k; j++)
                comb[i][j] = (comb[i - 1][j] + comb[i - 1][j - 1]) % MOD;
        }
        return comb;
    }

    private long ModPow(long x, long n)
    {
        if (n == 0)
            return 1;
        if ((n & 1) == 1)
            return x * ModPow(x % MOD, n - 1) % MOD;
        long half = ModPow(x * x % MOD, n / 2);
        return half % MOD;
    }

    private int CountBits(int n)
    {
        int count = 0;
        while (n != 0)
        {
            count += n & 1;
            n >>= 1;
        }
        return count;
    }
}