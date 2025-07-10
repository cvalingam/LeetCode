public class Solution
{
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
    {
        int n = startTime.Length; // Total number of meetings
        int maxFreeTime = 0; // Variable to store maximum free time

        // Calculate maximum gaps from the left side
        int[] leftGaps = new int[n];
        leftGaps[0] = startTime[0]; // Free time before the first meeting starts
        for (int i = 1; i < n; i++)
            leftGaps[i] = Math.Max(leftGaps[i - 1], startTime[i] - endTime[i - 1]);

        // Calculate maximum gaps from the right side
        int[] rightGaps = new int[n];
        rightGaps[n - 1] = eventTime - endTime[n - 1]; // Free time after the last meeting ends
        for (int i = n - 2; i >= 0; i--)
            rightGaps[i] = Math.Max(rightGaps[i + 1], startTime[i + 1] - endTime[i]);

        // Compute maximum free time by evaluating each meeting
        for (int i = 0; i < n; i++)
        {
            // Calculate the gap before the current meeting
            int leftGap = (i == 0) ? leftGaps[i] : startTime[i] - endTime[i - 1];
            // Calculate the gap after the current meeting
            int rightGap = (i == n - 1) ? rightGaps[i] : startTime[i + 1] - endTime[i];

            // Calculate the total interval of free time
            int interval = 0;
            if ((i != 0 && leftGaps[i - 1] >= (endTime[i] - startTime[i]))
                || (i != n - 1 && rightGaps[i + 1] >= (endTime[i] - startTime[i])))
                // Interval only relevant if the gap exists
                interval = endTime[i] - startTime[i];

            // Update the maximum free time found
            maxFreeTime = Math.Max(maxFreeTime, leftGap + interval + rightGap);
        }

        return maxFreeTime;
    }
}