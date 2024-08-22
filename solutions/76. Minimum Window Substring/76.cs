public class Solution
{
    public string MinWindow(string s, string t)
    {
        int required = t.Length;
        int[] count = new int[128];
        int minLength = s.Length + 1;
        int leftIndex = -1;

        foreach (char c in t)
            ++count[c];

        int l = 0, r = 0;
        while (r < s.Length)
        {
            if (--count[s[r]] >= 0)
                --required;

            while (required == 0)
            {
                if (r - l + 1 < minLength)
                {
                    leftIndex = l;
                    minLength = r - l + 1;
                }

                if (++count[s[l]] > 0)
                    ++required;
                l++;
            }
            r++;
        }

        return leftIndex == -1 ? "" : s.Substring(leftIndex, minLength);
    }
}