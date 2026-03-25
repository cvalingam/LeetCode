// Approach: Iterate over the char array; subtract the ASCII difference
// ('A'-'a') from each uppercase letter.
// Time: O(n) Space: O(n)

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