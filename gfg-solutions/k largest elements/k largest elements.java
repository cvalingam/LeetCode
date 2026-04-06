// Approach: Min-heap of size k. For each element > heap top, pop and insert. Heap contains k largest.
// Time: O(n log k) Space: O(k)
class Solution {
    public ArrayList<Integer> kLargest(int[] arr, int k) {
        PriorityQueue<Integer> pq = new PriorityQueue<>();
        for (int num : arr) {
            pq.offer(num);
            if (pq.size() > k)
                pq.poll();
        }
        ArrayList<Integer> ans = new ArrayList<>(Collections.nCopies(k, 0));
        while (!pq.isEmpty())
            ans.set(--k, pq.poll());
        return ans;
    }
}