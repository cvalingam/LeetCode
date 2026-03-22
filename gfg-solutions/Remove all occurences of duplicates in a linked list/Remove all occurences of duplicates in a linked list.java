
class Node {
    int data;
    Node next;

    Node(int d) {
        data = d;
        next = null;
    }
}

class Solution {
    public Node removeAllDuplicates(Node head) {
        Node curr = head;
        Node dummy = new Node(-1);
        Node newCurr = dummy;

        while (curr != null) {
            int d = curr.data;
            if ((curr.next != null && d != curr.next.data) || curr.next == null) {
                newCurr.next = new Node(d);
                newCurr = newCurr.next;
                curr = curr.next;
            } else {
                while (curr != null && d == curr.data)
                    curr = curr.next;
            }
        }

        return dummy.next;
    }
}