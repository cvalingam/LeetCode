// Approach: Divide and Conquer. Recursively split s into special substrings
// (balanced by +1 for '1' and -1 for '0'). For each, recursively process the inner
// part and wrap with '1...0'. Sort resulting strings descending and concatenate.
// Time: O(n^2) Space: O(n)
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