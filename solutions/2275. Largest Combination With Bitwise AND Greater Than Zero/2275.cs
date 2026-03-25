// Approach: For each bit position count how many candidates have that bit set; return max count.
// Time: O(n * 24) Space: O(1)

public class Solution
{
    public int LargestCombination(int[] candidates)
    {
        const int kMaxBit = 24;
        int ans = 0;

        for (int i = 0; i < kMaxBit; ++i)
        {
            int count = 0;
            foreach (var candidate in candidates)
            {
                if ((candidate >> i & 1) == 1)
                    ++count;
            }
            ans = Math.Max(ans, count);
        }

        return ans;
    }
}