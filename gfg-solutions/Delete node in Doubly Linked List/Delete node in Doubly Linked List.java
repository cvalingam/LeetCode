//Definition for doubly Link List Node
class Node {
    int data;
    Node next;
    Node prev;

    Node(int x) {
        data = x;
        next = null;
        prev = null;
    }
}

class Solution {
    public Node deleteNode(Node head, int x) {
        if (head == null)
            return null;

        if (x == 1)
            return head.next;

        Node curr = head;

        for (int i = 1; i < x; i++)
            curr = curr.next;

        if (curr.next == null) {
            curr = curr.prev;
            curr.next = null;
        } else
            curr.prev.next = curr.next;

        return head;
    }
}
