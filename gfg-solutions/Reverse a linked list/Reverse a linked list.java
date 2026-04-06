// Approach: Iterative three-pointer reversal: prev, current, next. Update links and advance.
// Time: O(n) Space: O(1)
class Node {
    int data;
    Node next;

    Node(int value) {
        this.value = value;
    }
}

class Solution {
    Node reverseList(Node head) {
        Node prev = null;
        Node curr = head;

        while (curr != null) {
            Node temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }

        return prev;
    }
}
