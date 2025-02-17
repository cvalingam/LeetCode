public class Solution
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        int ans = -1;
        int minDist = int.MaxValue;

        for (int i = 0; i < points.Length; ++i)
        {
            int dx = x - points[i][0];
            int dy = y - points[i][1];
            if (dx == 0 || dy == 0)
            {
                int dist = Math.Abs(dx) + Math.Abs(dy);
                if (dist < minDist)
                {
                    minDist = dist;
                    ans = i;
                }
            }
        }

        return ans;
    }
}