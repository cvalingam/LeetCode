// Approach: Two-pointer over s and spaces array; insert space at each specified index.
// Time: O(n) Space: O(n)

public class Solution
{
    public string AddSpaces(string s, int[] spaces)
    {
        StringBuilder sb = new StringBuilder();
        int j = 0; // spaces' index

        for (int i = 0; i < s.Length; ++i)
        {
            if (j < spaces.Length && i == spaces[j])
            {
                sb.Append(' ');
                ++j;
            }
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}