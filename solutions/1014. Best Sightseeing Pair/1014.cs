public class Solution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        int ans = 0;
        int bestPrev = 0;

        foreach (var value in values)
        {
            ans = Math.Max(ans, value + bestPrev);
            bestPrev = Math.Max(bestPrev, value) - 1;
        }

        return ans;
    }
}