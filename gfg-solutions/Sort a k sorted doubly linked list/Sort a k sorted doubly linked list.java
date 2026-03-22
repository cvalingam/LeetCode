
// User function Template for Java
class Solution {
    public DLLNode sortAKSortedDLL(DLLNode head, int k) {
        if (head == null || head.next == null) {
            return head;
        }

        PriorityQueue<DLLNode> minHeap = new PriorityQueue<>((a, b) -> a.data - b.data);
        DLLNode newHead = null, last = null;

        // Add first k+1 elements to the min heap
        for (int i = 0; i <= k && head != null; i++) {
            minHeap.add(head);
            head = head.next;
        }

        // Process the remaining elements
        while (!minHeap.isEmpty()) {
            if (newHead == null) {
                newHead = minHeap.poll();
                newHead.prev = null;
                last = newHead;
            } else {
                last.next = minHeap.poll();
                last.next.prev = last;
                last = last.next;
            }

            if (head != null) {
                minHeap.add(head);
                head = head.next;
            }
        }
        last.next = null;

        return newHead;
    }
}