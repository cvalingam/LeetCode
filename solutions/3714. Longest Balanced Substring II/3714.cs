public class Solution
{
    public int LongestBalanced(string s)
    {
        char[] cs = s.ToCharArray();
        int x = Calc1(cs);
        int y = Math.Max(Calc2(cs, 'a', 'b'), Math.Max(Calc2(cs, 'b', 'c'), Calc2(cs, 'a', 'c')));
        int z = Calc3(cs);
        return Math.Max(x, Math.Max(y, z));
    }

    private int Calc1(char[] s)
    {
        int res = 0;
        int i = 0, n = s.Length;
        while (i < n)
        {
            int j = i + 1;
            while (j < n && s[j] == s[i])
                j++;

            res = Math.Max(res, j - i);
            i = j;
        }
        return res;
    }

    private int Calc2(char[] s, char a, char b)
    {
        int res = 0;
        int i = 0, n = s.Length;
        while (i < n)
        {
            while (i < n && s[i] != a && s[i] != b)
                i++;

            Dictionary<int, int> pos = new Dictionary<int, int>();
            pos[0] = i - 1;
            int d = 0;
            while (i < n && (s[i] == a || s[i] == b))
            {
                d += (s[i] == a) ? 1 : -1;
                if (pos.TryGetValue(d, out int prev))
                    res = Math.Max(res, i - prev);
                else
                    pos[d] = i;

                i++;
            }
        }
        return res;
    }

    private int Calc3(char[] s)
    {
        Dictionary<long, int> pos = new Dictionary<long, int>();
        pos[F(0, 0)] = -1;

        int[] cnt = new int[3];
        int res = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            cnt[c - 'a']++;
            int x = cnt[0] - cnt[1];
            int y = cnt[1] - cnt[2];
            long k = F(x, y);

            if (pos.TryGetValue(k, out int prev))
                res = Math.Max(res, i - prev);

            else
                pos[k] = i;
        }
        return res;
    }

    private long F(int x, int y)
    {
        return ((long)(x + 100000) << 20) | (uint)(y + 100000);
    }
}