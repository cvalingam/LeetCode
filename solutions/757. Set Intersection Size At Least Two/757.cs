public class Solution
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        // Sort intervals by end point ascending, if equal then by start point descending
        // This ensures we process intervals with earlier endpoints first
        // When endpoints are equal, we prefer intervals with larger start points (smaller intervals)
        Array.Sort(intervals, (a, b) => a[1] == b[1] ? b[0] - a[0] : a[1] - b[1]);

        // Initialize the result counter for minimum points needed
        int result = 0;

        // Track the last two points in our intersection set
        // secondLast: the second-to-last point added to the set
        // last: the most recent point added to the set
        int secondLast = -1;
        int last = -1;

        // Process each interval in sorted order
        foreach (var interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];

            // Case 1: Current interval already contains both tracked points
            // No new points needed
            if (start <= secondLast)
                continue;

            // Case 2: Current interval doesn't contain any of the tracked points
            // Need to add 2 new points (the last two points of current interval)
            if (start > last)
            {
                result += 2;
                secondLast = end - 1;
                last = end;
            }
            // Case 3: Current interval contains only the last point
            // Need to add 1 new point (the endpoint of current interval)
            else
            {
                result += 1;
                secondLast = last;
                last = end;
            }
        }

        return result;
    }
}