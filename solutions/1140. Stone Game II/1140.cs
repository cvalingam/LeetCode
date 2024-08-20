public class Solution
{
    public int StoneGameII(int[] piles)
    {
        int n = piles.Length;
        int[][] mem = new int[n][];
        int[] suffix = new int[n]; // suffix[i] := sum(piles[i..n))

        for (int i = 0; i < n; i++)
        {
            int[] row = new int[n];
            Array.Fill(row, -1);
            mem[i] = row;
        }

        suffix[n - 1] = piles[n - 1];
        for (int i = n - 2; i >= 0; --i)
            suffix[i] = suffix[i + 1] + piles[i];
        return StoneGameII(suffix, 0, 1, mem);
    }

    // Returns the maximum number of stones Alice can get from piles[i..n) with M.
    private int StoneGameII(int[] suffix, int i, int M, int[][] mem)
    {
        if (i + 2 * M >= suffix.Length)
            return suffix[i];
        if (mem[i][M] != -1)
            return mem[i][M];

        int opponent = suffix[i];

        for (int X = 1; X <= 2 * M; ++X)
            opponent = Math.Min(opponent, StoneGameII(suffix, i + X, Math.Max(M, X), mem));

        return mem[i][M] = suffix[i] - opponent;
    }
}