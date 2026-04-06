// Approach: Move pointer two steps at a time; if null, length is even; if null after one step, odd.
// Time: O(n) Space: O(1)
class Solution {
    public boolean isLengthEven(Node head) {
        Node curr = head;

        int len = 0;
        while (curr != null) {
            curr = curr.next;
            len++;
        }

        return len % 2 == 0;
    }
}