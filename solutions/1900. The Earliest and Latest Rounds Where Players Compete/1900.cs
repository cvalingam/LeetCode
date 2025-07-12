public class Solution
{
    public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
    {
        int[][][][] mem = new int[n + 1][][][];
        for (int i = 0; i <= n; i++)
        {
            mem[i] = new int[n + 1][][];
            for (int j = 0; j <= n; j++)
            {
                mem[i][j] = new int[n + 1][];
                for (int k = 0; k <= n; k++)
                    mem[i][j][k] = new int[2];
            }
        }
        return Solve(firstPlayer, n - secondPlayer + 1, n, mem);
    }

    // Returns the (earliest, latest) pair, the first player is the l-th player
    // from the front, the second player is the r-th player from the end, and
    // there're k people.
    private int[] Solve(int l, int r, int k, int[][][][] mem)
    {
        if (l == r)
            return new int[] { 1, 1 };
        if (l > r)
            return Solve(r, l, k, mem);
        if (!mem[l][r][k].SequenceEqual(new int[] { 0, 0 }))
            return mem[l][r][k];

        int a = int.MaxValue;
        int b = int.MinValue;

        // Enumerate all the possible positions.
        for (int i = 1; i <= l; ++i)
            for (int j = l - i + 1; j <= r - i; ++j)
            {
                if (i + j > (k + 1) / 2 || i + j < l + r - k / 2)
                    continue;
                int[] res = Solve(i, j, (k + 1) / 2, mem);
                a = Math.Min(a, res[0] + 1);
                b = Math.Max(b, res[1] + 1);
            }

        return mem[l][r][k] = new int[] { a, b };
    }
}