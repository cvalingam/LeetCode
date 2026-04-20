// Approach: Sliding window with a 128-slot frequency array for ASCII characters.
// 'required' tracks how many characters from t are still unmet in the current window.
// Expand right pointer: when a required character is found, decrement 'required'.
// Once required == 0 (all characters covered), try shrinking the left pointer.
// Shrink left: when removing a character from t would break coverage, stop and record window size.
// Using an int array (size 128) instead of a Dictionary gives O(1) per character vs O(1) amortised.
// Time: O(n + m) where n = |s|, m = |t|. Space: O(1) since the character set is fixed at 128.

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