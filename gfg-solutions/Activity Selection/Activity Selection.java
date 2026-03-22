import java.util.*;

class Solution {
    public int activitySelection(int[] start, int[] finish) {
        PriorityQueue<int[]> pq = new PriorityQueue<>((a, b) -> a[1] - b[1]);

        for (int i = 0; i < start.length; ++i)
            pq.offer(new int[] { start[i], finish[i] });

        int cnt = 1;
        int ans = pq.peek()[1];

        while (!pq.isEmpty()) {
            if (pq.peek()[0] > ans) {
                cnt++;
                ans = pq.peek()[1];
            }
            pq.poll();
        }
        return cnt;
    }
}
