public class Solution
{
    public int MaxScore(string s)
    {
        int ans = 0;
        int zeros = 0;
        int ones = s.Count(c => c == '1');

        for (int i = 0; i + 1 < s.Length; ++i)
        {
            if (s[i] == '0')
                ++zeros;
            else
                --ones;
            ans = Math.Max(ans, zeros + ones);
        }

        return ans;
    }
}