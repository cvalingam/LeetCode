// Approach: The time to move between consecutive points is max(|dx|, |dy|) because diagonal moves are allowed.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        int ans = 0;

        for (int i = 1; i < points.Length; ++i)
            ans += Math.Max(Math.Abs(points[i][0] - points[i - 1][0]),
                            Math.Abs(points[i][1] - points[i - 1][1]));

        return ans;
    }
}