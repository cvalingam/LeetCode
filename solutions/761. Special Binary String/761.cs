public class Solution
{
    public string MakeLargestSpecial(string s)
    {
        List<string> specials = new List<string>();
        int count = 0;

        for (int i = 0, j = 0; j < s.Length; ++j)
        {
            count += s[j] == '1' ? 1 : -1;
            if (count == 0)
            {
                specials.Add("1" + MakeLargestSpecial(s.Substring(i + 1, j - i - 1)) + "0");
                i = j + 1;
            }
        }

        specials.Sort((a, b) => string.Compare(b, a, StringComparison.Ordinal));
        return string.Concat(specials);
    }
}