// Approach: Monotonic stack — pop the stack when the top char is larger than
// the current and still appears later; mark characters as permanently placed.
// Time: O(n) Space: O(1)

public class Solution
{
    public string RemoveDuplicateLetters(string s)
    {
        StringBuilder sb = new StringBuilder();
        int[] count = new int[128];
        bool[] used = new bool[128];

        foreach (char c in s)
            ++count[c];

        foreach (char c in s)
        {
            --count[c];
            if (used[c])
                continue;
            while (sb.Length > 0 && Last(sb) > c && count[Last(sb)] > 0)
            {
                used[Last(sb)] = false;
                sb.Length--;
            }
            used[c] = true;
            sb.Append(c);
        }

        return sb.ToString();
    }

    private char Last(StringBuilder sb)
    {
        return sb[sb.Length - 1];
    }
}