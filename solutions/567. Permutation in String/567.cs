// Approach: Sliding window with a 26-element frequency array and a required-
// count variable; shrink left while all characters are matched.
// Time: O(m+n) Space: O(1)

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        int[] count = new int[26];
        int required = s1.Length;

        foreach (char c in s1)
            ++count[c - 'a'];

        for (int l = 0, r = 0; r < s2.Length; ++r)
        {
            if (--count[s2[r] - 'a'] >= 0)
                --required;
            while (required == 0)
            {
                if (r - l + 1 == s1.Length)
                    return true;
                if (++count[s2[l++] - 'a'] > 0)
                    ++required;
            }
        }

        return false;
    }
}