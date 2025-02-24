public class Solution
{
    public int FindSubstringInWraproundString(string p)
    {
        int maxLength = 1;
        // count[i] := the number of substrings ending in ('a' + i)
        int[] count = new int[26];

        for (int i = 0; i < p.Length; ++i)
        {
            if (i > 0 && (p[i] - p[i - 1] == 1 || p[i - 1] - p[i] == 25))
                ++maxLength;
            else
                maxLength = 1;
            int index = p[i] - 'a';
            count[index] = Math.Max(count[index], maxLength);
        }

        return count.Sum();
    }
}