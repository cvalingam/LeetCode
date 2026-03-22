import java.util.*;

class Solution {
    // Function to find the maximum number of meetings that can
    // be performed in a meeting room.
    public int maxMeetings(int n, int start[], int end[]) {
        int[][] ans = new int[n][2];

        for (int i = 0; i < n; i++) {
            ans[i][0] = start[i];
            ans[i][1] = end[i];
        }

        Arrays.sort(ans, (a, b) -> a[1] - b[1]);

        int cnt = 0;
        int endTime = ans[0][1];

        for (int i = 1; i < n; i++) {
            if (ans[i][0] <= endTime)
                continue;
            else {
                cnt++;
                endTime = ans[i][1];
            }
        }

        return cnt + 1;
    }
}
