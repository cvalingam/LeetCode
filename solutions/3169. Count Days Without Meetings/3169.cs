public class Solution
{
    public int CountDays(int days, int[][] meetings)
    {
        int freeDays = 0;
        int prevEnd = 0;

        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

        foreach (var meeting in meetings)
        {
            int start = meeting[0];
            int end = meeting[1];
            if (start > prevEnd)
                freeDays += start - prevEnd - 1;
            prevEnd = Math.Max(prevEnd, end);
        }

        return freeDays + Math.Max(0, days - prevEnd);
    }
}