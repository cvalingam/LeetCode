// Approach: Binary search for the first letter strictly greater than target; wrap around to letters[0] if none found.
// Time: O(log n) Space: O(1)

public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        int l = 0;
        int r = letters.Length;

        while (l < r)
        {
            int m = (l + r) / 2;
            if (letters[m] > target)
                r = m;
            else
                l = m + 1;
        }

        return letters[l % letters.Length];
    }
}