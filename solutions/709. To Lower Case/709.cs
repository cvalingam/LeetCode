public class Solution
{
    public string ToLowerCase(string s)
    {
        int diff = 'A' - 'a';

        char[] ans = s.ToCharArray();

        for (int i = 0; i < ans.Length; ++i)
        {
            if (ans[i] >= 'A' && ans[i] <= 'Z')
                ans[i] -= (char)diff;
        }

        return new string(ans);
    }
}