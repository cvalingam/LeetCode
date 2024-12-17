public class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        StringBuilder sb = new StringBuilder();
        int[] count = new int[26];

        foreach (char c in s)
            count[c - 'a']++;

        while (true)
        {
            bool addOne = sb.Length > 0 && ShouldAddOne(sb, count);
            int i = GetLargestChar(sb, count);
            if (i == -1)
                break;
            int repeats = addOne ? 1 : Math.Min(count[i], repeatLimit);
            sb.Append(new string((char)('a' + i), repeats));
            count[i] -= repeats;
        }

        return sb.ToString();
    }

    private bool ShouldAddOne(StringBuilder sb, int[] count)
    {
        for (int i = 25; i >= 0; --i)
        {
            if (count[i] > 0)
                return sb[sb.Length - 1] == (char)('a' + i);
        }

        return false;
    }

    private int GetLargestChar(StringBuilder sb, int[] count)
    {
        for (int i = 25; i >= 0; --i)
        {
            if (count[i] > 0 && (sb.Length == 0 || sb[sb.Length - 1] != (char)('a' + i)))
                return i;
        }

        return -1;
    }
}