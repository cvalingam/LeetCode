public class Solution
{
    private int m;
    private int n;
    private int[,] mem = new int[1000, 1024];
    private const int MOD = 1_000_000_007;

    public int ColorTheGrid(int m, int n)
    {
        this.m = m;
        this.n = n;
        return Dp(0, 0, 0, 0);
    }

    private int Dp(int r, int c, int prevColMask, int currColMask)
    {
        if (c == n)
            return 1;
        if (mem[c, prevColMask] != 0)
            return mem[c, prevColMask];
        if (r == m)
            return Dp(0, c + 1, currColMask, 0);

        int ans = 0;

        // 1 := red, 2 := green, 3 := blue
        for (int color = 1; color <= 3; ++color)
        {
            if (GetColor(prevColMask, r) == color)
                continue;
            if (r > 0 && GetColor(currColMask, r - 1) == color)
                continue;
            ans += Dp(r + 1, c, prevColMask, SetColor(currColMask, r, color));
            ans %= MOD;
        }

        if (r == 0)
            mem[c, prevColMask] = ans;

        return ans;
    }

    // e.g. __ __ __ __ __
    //      01 10 11 11 11
    //      R  G  B  B  B
    // GetColor(0110111111, 3) -> G
    private int GetColor(int mask, int r)
    {
        return (mask >> (r * 2)) & 3;
    }

    private int SetColor(int mask, int r, int color)
    {
        return mask | (color << (r * 2));
    }
}