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