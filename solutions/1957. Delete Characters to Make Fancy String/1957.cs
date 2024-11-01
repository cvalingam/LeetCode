public class Solution
{
    public string MakeFancyString(string s)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            if (sb.Length < 2 ||
                sb[sb.Length - 1] != c || sb[sb.Length - 2] != c)
                sb.Append(c);
        }
        return sb.ToString();
    }
}