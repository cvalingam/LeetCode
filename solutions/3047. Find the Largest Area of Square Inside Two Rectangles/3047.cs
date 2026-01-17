public class Solution
{
    public long LargestSquareArea(int[][] bottomLeft, int[][] topRight)
    {
        int minSide = 0;

        for (int i = 0; i < bottomLeft.Length; ++i)
            for (int j = i + 1; j < bottomLeft.Length; ++j)
            {
                int ax1 = bottomLeft[i][0];
                int ay1 = bottomLeft[i][1];
                int ax2 = topRight[i][0];
                int ay2 = topRight[i][1];
                int bx1 = bottomLeft[j][0];
                int by1 = bottomLeft[j][1];
                int bx2 = topRight[j][0];
                int by2 = topRight[j][1];
                int overlapX = Math.Min(ax2, bx2) - Math.Max(ax1, bx1);
                int overlapY = Math.Min(ay2, by2) - Math.Max(ay1, by1);
                minSide = Math.Max(minSide, Math.Min(overlapX, overlapY));
            }

        return (long)minSide * minSide;
    }
}