public class Solution
{
    public int MaxOperations(string s)
    {
        int ans = 0;
        int ones = 0;

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == '1')
                ++ones;
            else if (i == s.Length - 1 || s[i + 1] == '1')
                ans += ones;
        }

        return ans;
    }
}