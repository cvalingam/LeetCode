public class Solution
{
    public int MaxValue(int[][] events, int k)
    {
        // Sort the events array by the end time of each event.
        Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));
        int n = events.Length;

        // Create a DP table where f[i][j] will hold the maximum value for the first i events using j events.
        int[,] dpTable = new int[n + 1, k + 1];

        // Fill in the DP table
        for (int i = 1; i <= n; ++i)
        {
            // Start time and value of the current event
            int startTime = events[i - 1][0];
            int value = events[i - 1][2];

            // Find the previous event that does not overlap with the current event
            int previous = BinarySearch(events, startTime, i - 1);

            for (int j = 1; j <= k; ++j)
                // The value for using j events including the i-th event is either:
                // 1. The same as using the first i-1 events (not using the i-th event), or
                // 2. The value of using j-1 events plus the value of the i-th event 
                // (when j-1 events are used up to the previously non-overlapping event).
                dpTable[i, j] = Math.Max(dpTable[i - 1, j], dpTable[previous, j - 1] + value);
        }

        // Return the maximum value achievable using k events
        return dpTable[n, k];
    }

    // Performs a binary search to find the index of the latest event that finishes before 'endTime'.
    private int BinarySearch(int[][] events, int endTime, int high)
    {
        int low = 0;
        while (low < high)
        {
            int mid = (low + high) >> 1; // Equivalent to (low + high) / 2, but avoids overflow
            if (events[mid][1] >= endTime)
                high = mid;
            else
                low = mid + 1;
        }
        
        return low;
    }
}