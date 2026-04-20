// Approach: Greedy monotonic stack to build the lexicographically smallest result.
// Pre-count character frequencies; use a boolean array to track characters already in the stack.
// For each character: if already in stack, skip it.
// Otherwise, pop the stack top while: top > current AND top appears again later (count > 0).
// Push the current character and mark it as 'in stack'.
// Decrement count for each character processed regardless of whether it is pushed.
// Time: O(n) Space: O(1) since the character set is fixed at 26 letters.

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