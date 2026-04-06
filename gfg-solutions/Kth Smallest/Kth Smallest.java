// Approach: Min-heap merge of k sorted arrays, or binary search on value with counting.
// Time: O(k log n) Space: O(n)
import java.util.*;

class Solution {
    public static int kthSmallest(int[] arr, int k) {
        PriorityQueue<Integer> pq = new PriorityQueue<>((a, b) -> b - a);

        for (int val : arr) {
            pq.offer(val);

            if (pq.size() > k)
                pq.poll();
        }

        return pq.poll();
    }
}