import java.util.*;

class Solution {
    static ArrayList<int[]> insertInterval(int[][] intervals, int[] newInterval) {
        ArrayList<int[]> result = new ArrayList<>();
        int i = 0, n = intervals.length;

        // Add intervals before the new interval
        while (i < n && intervals[i][1] < newInterval[0]) {
            result.add(intervals[i]);
            i++;
        }

        // Merge overlapping intervals
        while (i < n && intervals[i][0] <= newInterval[1]) {
            newInterval[0] = Math.min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.max(newInterval[1], intervals[i][1]);
            i++;
        }
        result.add(newInterval); // Add the merged interval

        // Add intervals after the new interval
        while (i < n) {
            result.add(intervals[i]);
            i++;
        }

        return result;
    }
}