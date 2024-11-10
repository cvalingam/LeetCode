public class Solution
{
    public int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
    {
        if (a == e || b == f)
        {
            if (a == e && a == c
            && ((d - b) * (d - f)) < 0)
                return 2;

            if (b == f && b == d
            && (c - a) * (c - e) < 0)
                return 2;
            return 1;
        }

        if (Math.Abs(c - e) == Math.Abs(d - f))
        {
            if (Math.Abs(c - a) == Math.Abs(d - b)
            && ((b - f) * (b - d)) < 0)
                return 2;
            return 1;
        }

        return 2;
    }
}