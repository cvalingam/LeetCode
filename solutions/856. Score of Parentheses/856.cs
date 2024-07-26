public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        int ans = 0, layer = 0;
        for (int i = 0; i + 1 < s.Length; i++)
        {
            char a = s[i];
            char b = s[i + 1];

            if (a == '(' && b == ')')
                ans += (1 << layer);
            layer += (a == '(') ? 1 : -1;
        }

        return ans;
    }
}