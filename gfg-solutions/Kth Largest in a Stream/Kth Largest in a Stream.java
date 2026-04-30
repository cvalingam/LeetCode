
// Approach: Maintain a min-heap of size k. For each element, add it and evict the min if size exceeds k.
// The heap's top (minimum) is the k-th largest seen so far. Output -1 until k elements have been processed.
// Time: O(n log k) Space: O(k)
import java.util.*;

class Solution {

    static ArrayList<Integer> kthLargest(int[] arr, int k) {
        ArrayList<Integer> res = new ArrayList<>();
        PriorityQueue<Integer> pq = new PriorityQueue<>();
        for (int i = 0; i < arr.length; i++) {
            pq.add(arr[i]);
            if (pq.size() > k) {
                pq.poll();
            }

            res.add(pq.size() == k ? pq.peek() : -1);
        }
        return res;
    }
}
