public class Solution
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        int[][] xs = new int[rectangles.Length][];
        int[][] ys = new int[rectangles.Length][];

        for (int i = 0; i < rectangles.Length; ++i)
        {
            xs[i] = new int[2];
            xs[i][0] = rectangles[i][0];
            xs[i][1] = rectangles[i][2];
            ys[i] = new int[2];
            ys[i][0] = rectangles[i][1];
            ys[i][1] = rectangles[i][3];
        }

        return Math.Max(CountMerged(xs), CountMerged(ys)) >= 3;
    }

    private int CountMerged(int[][] intervals)
    {
        int count = 0;
        int prevEnd = 0;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        foreach (var interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];
            if (start < prevEnd)
                prevEnd = Math.Max(prevEnd, end);
            else
            {
                prevEnd = end;
                ++count;
            }
        }

        return count;
    }
}