// Approach: Greedy recursive; always use up to 2 of the most-frequent character, then 1 of the second most.
// Time: O(a+b+c) Space: O(a+b+c)

public class Solution
{
    public string LongestDiverseString(int a, int b, int c, char A = 'a', char B = 'b', char C = 'c')
    {
        if (a < b)
            return LongestDiverseString(b, a, c, B, A, C);
        if (b < c)
            return LongestDiverseString(a, c, b, A, C, B);
        if (b == 0)
            return new string(A, Math.Min(a, 2));

        int useA = Math.Min(a, 2);
        int useB = (a - useA >= b) ? 1 : 0;
        return new string(A, useA) + new string(B, useB) +
               LongestDiverseString(a - useA, b - useB, c, A, B, C);
    }
}