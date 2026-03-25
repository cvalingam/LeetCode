// Approach: Simple range check; count students whose [startTime, endTime] interval includes queryTime.
// Time: O(n) Space: O(1)

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