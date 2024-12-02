public class Solution
{
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
    {
        int n = startTime.Length;
        int ans = 0;

        for (int i = 0; i < n; ++i)
        {
            if (startTime[i] <= queryTime && queryTime <= endTime[i])
                ++ans;
        }

        return ans;
    }
}