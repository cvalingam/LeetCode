// Approach: Sliding window of size k; count max 'B's in any window; answer = k - maxB.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MinimumRecolors(string blocks, int k)
    {
        int countB = 0;
        int maxCountB = 0;

        for (int i = 0; i < blocks.Length; ++i)
        {
            if (blocks[i] == 'B')
                ++countB;
            if (i >= k && blocks[i - k] == 'B')
                --countB;
            maxCountB = Math.Max(maxCountB, countB);
        }

        return k - maxCountB;
    }
}