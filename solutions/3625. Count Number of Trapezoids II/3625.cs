public class Solution
{
    public int CountTrapezoids(int[][] points)
    {
        var lookupSlope = new Dictionary<(int, int), int>();
        var lookupLine = new Dictionary<(int, int, int), int>();
        var lookupSlopeLength = new Dictionary<(int, int, int), int>();
        var lookupLineLength = new Dictionary<(int, int, int, int), int>();

        int result = 0, same = 0;
        int n = points.Length;

        for (int i = 0; i < n; i++)
        {
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = 0; j < i; j++)
            {
                int x2 = points[j][0], y2 = points[j][1];
                int dx = x2 - x1, dy = y2 - y1;
                int g = Gcd(dx, dy);
                int a = dx / g, b = dy / g;
                if (a < 0 || (a == 0 && b < 0))
                {
                    a = -a;
                    b = -b;
                }
                int c = b * x1 - a * y1;

                var slopeKey = (a, b);
                var lineKey = (a, b, c);
                int slopeCount = lookupSlope.ContainsKey(slopeKey) ? lookupSlope[slopeKey] : 0;
                int lineCount = lookupLine.ContainsKey(lineKey) ? lookupLine[lineKey] : 0;
                result += slopeCount - lineCount;
                lookupSlope[slopeKey] = slopeCount + 1;
                lookupLine[lineKey] = lineCount + 1;

                int l = dx * dx + dy * dy;
                var slopeLengthKey = (a, b, l);
                var lineLengthKey = (a, b, c, l);
                int slopeLengthCount = lookupSlopeLength.ContainsKey(slopeLengthKey) ? lookupSlopeLength[slopeLengthKey] : 0;
                int lineLengthCount = lookupLineLength.ContainsKey(lineLengthKey) ? lookupLineLength[lineLengthKey] : 0;
                same += slopeLengthCount - lineLengthCount;
                lookupSlopeLength[slopeLengthKey] = slopeLengthCount + 1;
                lookupLineLength[lineLengthKey] = lineLengthCount + 1;
            }
        }
        return result - same / 2;
    }

    int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
}