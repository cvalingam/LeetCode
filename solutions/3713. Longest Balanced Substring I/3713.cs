public class Solution
{
    public int LongestBalanced(string s)
    {
        int n = s.Length;
        int[] cnt = new int[26];
        int ans = 0;
        for (int i = 0; i < n; ++i)
        {
            Array.Clear(cnt, 0, cnt.Length);
            int mx = 0, v = 0;
            for (int j = i; j < n; ++j)
            {
                int c = s[j] - 'a';
                if (++cnt[c] == 1)
                    ++v;

                mx = Math.Max(mx, cnt[c]);
                if (mx * v == j - i + 1)
                    ans = Math.Max(ans, j - i + 1);

            }
        }
        
        return ans;
    }
}