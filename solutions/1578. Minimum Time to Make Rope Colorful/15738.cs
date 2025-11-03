public class Solution
{
    public int MinCost(string colors, int[] neededTime)
    {
        int n = colors.Length;
        int ans = 0;
        int maxNeededTime = neededTime[0];

        for (int i = 1; i < n; i++)
        {
            if (colors[i - 1] == colors[i])
            {
                ans = ans + Math.Min(maxNeededTime, neededTime[i]);
                maxNeededTime = Math.Max(maxNeededTime, neededTime[i]);
            }
            else
                maxNeededTime = neededTime[i];
        }

        return ans;
    }
}