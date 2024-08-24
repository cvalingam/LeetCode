public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> mergedIntervals = new List<int[]>();

        if (intervals.Length == 0 || intervals == null)
        {
            return mergedIntervals.ToArray();
        }

        Array.Sort(intervals, (a, b) => a[0] - b[0]);

        int start = intervals[0][0];
        int end = intervals[0][1];

        for (int i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= end)
            {
                end = Math.Max(end, intervals[i][1]);
            }
            else
            {
                mergedIntervals.Add(new int[] { start, end });
                start = intervals[i][0];
                end = intervals[i][1];
            }
        }
        mergedIntervals.Add(new int[] { start, end });

        return mergedIntervals.ToArray();
    }
}