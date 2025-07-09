public class Solution
{
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
    {
        int[] gaps = GetGaps(eventTime, startTime, endTime);
        int windowSum = gaps.Take(k + 1).Sum();
        int ans = windowSum;

        for (int i = k + 1; i < gaps.Length; i++)
        {
            windowSum += gaps[i] - gaps[i - k - 1];
            ans = Math.Max(ans, windowSum);
        }

        return ans;
    }

    private int[] GetGaps(int eventTime, int[] startTime, int[] endTime)
    {
        int[] gaps = new int[startTime.Length + 1];
        gaps[0] = startTime[0];
        for (int i = 1; i < startTime.Length; ++i)
            gaps[i] = startTime[i] - endTime[i - 1];
        gaps[startTime.Length] = eventTime - endTime[endTime.Length - 1];
        
        return gaps;
    }
}